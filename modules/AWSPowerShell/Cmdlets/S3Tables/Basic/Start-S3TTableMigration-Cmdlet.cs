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
using Amazon.S3Tables;
using Amazon.S3Tables.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.S3T
{
    /// <summary>
    /// Starts migrating an Amazon Web Services Glue Data Catalog table into a new table in
    /// a table bucket. The migration runs asynchronously: this operation returns the migration
    /// ID and its initial state, and you track progress with <c>GetTableMigration</c>.
    /// 
    ///  
    /// <para>
    /// The namespace must already exist, and a table with the specified name must not. The
    /// migration creates the table during planning and commits data to it as it runs. Until
    /// you call <c>CompleteTableMigration</c>, you can read the table but you can't write
    /// to it. If the migration fails or is cancelled, the table and the data already committed
    /// to it remain.
    /// </para><para>
    /// The migration first checks the source and the destination, and writes the table compatibility
    /// and object compatibility reports to the bucket that you specify in <c>migrationOutput</c>.
    /// If you set <c>reviewMigrationPlan</c> to <c>true</c>, the migration waits in the <c>pendingReview</c>
    /// state so that you can review the reports, and continues only when you call <c>UpdateTableMigration</c>
    /// with <c>requestedState</c> set to <c>queued</c>. If you don't continue or cancel the
    /// migration within 30 days, the migration fails. Otherwise it continues to migrate the
    /// data, and writes the object migration report when the migration ends. If planning
    /// fails, the migration writes no object migration report.
    /// </para><dl><dt>Permissions</dt><dd><ul><li><para>
    /// You must have the <c>s3tables:StartTableMigration</c> permission to use this operation.
    /// </para></li><li><para>
    /// You must have the <c>iam:PassRole</c> permission on the role that you specify in <c>roleARN</c>,
    /// with a condition that allows passing it to <c>migration.s3tables.amazonaws.com</c>.
    /// The associated resource is the table bucket.
    /// </para></li><li><para>
    /// If <c>destinationTable</c> specifies SSE-KMS encryption, you must have the <c>kms:DescribeKey</c>
    /// and <c>kms:GenerateDataKey</c> permissions on the KMS key. You must also grant the
    /// S3 Tables maintenance principal access to the key. For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/s3-tables-kms-permissions.html">Permissions
    /// requirements for S3 Tables SSE-KMS encryption</a>.
    /// </para></li></ul></dd></dl>
    /// </summary>
    [Cmdlet("Start", "S3TTableMigration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.S3Tables.Model.StartTableMigrationResponse")]
    [AWSCmdlet("Calls the Amazon S3 Tables StartTableMigration API operation.", Operation = new[] {"StartTableMigration"}, SelectReturnType = typeof(Amazon.S3Tables.Model.StartTableMigrationResponse))]
    [AWSCmdletOutput("Amazon.S3Tables.Model.StartTableMigrationResponse",
        "This cmdlet returns an Amazon.S3Tables.Model.StartTableMigrationResponse object containing multiple properties."
    )]
    public partial class StartS3TTableMigrationCmdlet : AmazonS3TablesClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter MigrationOutput_Bucket
        /// <summary>
        /// <para>
        /// <para>The general purpose bucket that the migration writes every report to.</para>
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
        public System.String MigrationOutput_Bucket { get; set; }
        #endregion
        
        #region Parameter Source_GlueTable_CatalogId
        /// <summary>
        /// <para>
        /// <para>The ID of the Data Catalog that contains the table. It must be your account ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Source_GlueTable_CatalogId { get; set; }
        #endregion
        
        #region Parameter DestinationTable_Properties_CompressionCodec
        /// <summary>
        /// <para>
        /// <para>The compression codec of the data files. The default is <c>zstd</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3Tables.CompressionCodec")]
        public Amazon.S3Tables.CompressionCodec DestinationTable_Properties_CompressionCodec { get; set; }
        #endregion
        
        #region Parameter Source_GlueTable_DatabaseName
        /// <summary>
        /// <para>
        /// <para>The name of the database that contains the table.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Source_GlueTable_DatabaseName { get; set; }
        #endregion
        
        #region Parameter DestinationTable_Properties_DictionaryEncoding
        /// <summary>
        /// <para>
        /// <para>Specifies whether the data files use dictionary encoding. The default is <c>true</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DestinationTable_Properties_DictionaryEncoding { get; set; }
        #endregion
        
        #region Parameter DestinationTable_IcebergSortOrder_Field
        /// <summary>
        /// <para>
        /// <para>The list of sort fields that define how data is sorted within files. Each field specifies
        /// a source field, sort direction, and null ordering. This field is required if <c>writeOrder</c>
        /// is provided.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DestinationTable_IcebergSortOrder_Fields")]
        public Amazon.S3Tables.Model.IcebergSortField[] DestinationTable_IcebergSortOrder_Field { get; set; }
        #endregion
        
        #region Parameter DestinationTable_Schema_Field
        /// <summary>
        /// <para>
        /// <para>The schema fields for the table. Each field defines a column in the table, including
        /// its name, type, and whether it is required.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DestinationTable_Schema_Fields")]
        public Amazon.S3Tables.Model.SchemaV2Field[] DestinationTable_Schema_Field { get; set; }
        #endregion
        
        #region Parameter DestinationTable_Properties_IcebergFormatVersion
        /// <summary>
        /// <para>
        /// <para>The Iceberg format version of the destination table. Valid values are <c>2</c> and
        /// <c>3</c>. The default is <c>2</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? DestinationTable_Properties_IcebergFormatVersion { get; set; }
        #endregion
        
        #region Parameter DestinationTable_Schema_IdentifierFieldId
        /// <summary>
        /// <para>
        /// <para>A list of field IDs that are used as the identifier fields for the table. Identifier
        /// fields uniquely identify a row in the table.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DestinationTable_Schema_IdentifierFieldIds")]
        public System.Int32[] DestinationTable_Schema_IdentifierFieldId { get; set; }
        #endregion
        
        #region Parameter DataMigration_MigrationPolicies_IncompatibleValuesPolicy
        /// <summary>
        /// <para>
        /// <para>The migration policy for a source value that the destination column's type can't hold.
        /// Valid values:</para><ul><li><para><c>fail</c> - Fails the migration. This is the default.</para></li><li><para><c>setNull</c> - Writes null for a value that the destination column's type can't
        /// hold. If a column's type in a source object is incompatible with the destination column's
        /// type, the column is null for that whole object.</para></li></ul><para>A required column, or a type that migration doesn't support, fails the migration under
        /// either value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3Tables.IncompatibleValuesPolicy")]
        public Amazon.S3Tables.IncompatibleValuesPolicy DataMigration_MigrationPolicies_IncompatibleValuesPolicy { get; set; }
        #endregion
        
        #region Parameter DestinationTable_EncryptionConfiguration_KmsKeyArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the KMS key to use for encryption. This field is
        /// required only when <c>sseAlgorithm</c> is set to <c>aws:kms</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DestinationTable_EncryptionConfiguration_KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter DataMigration_MaintenanceSettings_IcebergSnapshotManagement_MaxSnapshotAgeHour
        /// <summary>
        /// <para>
        /// <para>The maximum age, in hours, of a snapshot before it can be expired. The default is
        /// 120.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataMigration_MaintenanceSettings_IcebergSnapshotManagement_MaxSnapshotAgeHours")]
        public System.Int32? DataMigration_MaintenanceSettings_IcebergSnapshotManagement_MaxSnapshotAgeHour { get; set; }
        #endregion
        
        #region Parameter DataMigration_MaintenanceSettings_IcebergSnapshotManagement_MinSnapshotsToKeep
        /// <summary>
        /// <para>
        /// <para>The minimum number of snapshots to keep. The value must be 3 or more. The default
        /// is 3.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? DataMigration_MaintenanceSettings_IcebergSnapshotManagement_MinSnapshotsToKeep { get; set; }
        #endregion
        
        #region Parameter DestinationTable_Name
        /// <summary>
        /// <para>
        /// <para>The name of the table to create.</para>
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
        public System.String DestinationTable_Name { get; set; }
        #endregion
        
        #region Parameter DestinationTable_Namespace
        /// <summary>
        /// <para>
        /// <para>The namespace to create the table in.</para>
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
        public System.String DestinationTable_Namespace { get; set; }
        #endregion
        
        #region Parameter MigrationOutput_Prefixes_ObjectCompatibilityReport
        /// <summary>
        /// <para>
        /// <para>The key prefix for the object compatibility report, up to 512 bytes. If not specified,
        /// the report's keys start at the root of the bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MigrationOutput_Prefixes_ObjectCompatibilityReport { get; set; }
        #endregion
        
        #region Parameter MigrationOutput_Prefixes_ObjectMigrationReport
        /// <summary>
        /// <para>
        /// <para>The key prefix for the object migration report, up to 512 bytes. If not specified,
        /// the report's keys start at the root of the bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MigrationOutput_Prefixes_ObjectMigrationReport { get; set; }
        #endregion
        
        #region Parameter DestinationTable_IcebergSortOrder_OrderId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for this sort order. If not specified, defaults to <c>1</c>.
        /// The order ID is used by Apache Iceberg to track sort order evolution.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? DestinationTable_IcebergSortOrder_OrderId { get; set; }
        #endregion
        
        #region Parameter ReviewMigrationPlan
        /// <summary>
        /// <para>
        /// <para>Specifies whether the migration waits in the <c>pendingReview</c> state, so that you
        /// can review the compatibility reports before it migrates any data. If <c>true</c>,
        /// the migration continues when you call <c>UpdateTableMigration</c> with <c>requestedState</c>
        /// set to <c>queued</c>. If you don't continue or cancel the migration within 30 days,
        /// the migration fails. The default is <c>false</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ReviewMigrationPlan { get; set; }
        #endregion
        
        #region Parameter RoleARN
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role that the migration uses to read the
        /// source table and its data and to write the destination table and the reports. The
        /// role must be in your account, and its trust policy must allow <c>migration.s3tables.amazonaws.com</c>
        /// to assume it. You can limit the trust policy to the destination table bucket with
        /// the <c>aws:SourceArn</c> and <c>aws:SourceAccount</c> condition keys.</para>
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
        public System.String RoleARN { get; set; }
        #endregion
        
        #region Parameter DestinationTable_Schema_SchemaId
        /// <summary>
        /// <para>
        /// <para>An optional unique identifier for the schema. Schema IDs are used by Apache Iceberg
        /// to track schema evolution.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? DestinationTable_Schema_SchemaId { get; set; }
        #endregion
        
        #region Parameter SourceType
        /// <summary>
        /// <para>
        /// <para>The type of the source. It must match the member that you set in <c>source</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.S3Tables.MigrationSourceType")]
        public Amazon.S3Tables.MigrationSourceType SourceType { get; set; }
        #endregion
        
        #region Parameter DestinationTable_EncryptionConfiguration_SseAlgorithm
        /// <summary>
        /// <para>
        /// <para>The server-side encryption algorithm to use. Valid values are <c>AES256</c> for S3-managed
        /// encryption keys, or <c>aws:kms</c> for Amazon Web Services KMS-managed encryption
        /// keys. If you choose SSE-KMS encryption you must grant the S3 Tables maintenance principal
        /// access to your KMS key. For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/s3-tables-kms-permissions.html">Permissions
        /// requirements for S3 Tables SSE-KMS encryption</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3Tables.SSEAlgorithm")]
        public Amazon.S3Tables.SSEAlgorithm DestinationTable_EncryptionConfiguration_SseAlgorithm { get; set; }
        #endregion
        
        #region Parameter DestinationTable_StorageClassConfiguration_StorageClass
        /// <summary>
        /// <para>
        /// <para>The storage class for the table or table bucket. Valid values include storage classes
        /// optimized for different access patterns and cost profiles.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3Tables.StorageClass")]
        public Amazon.S3Tables.StorageClass DestinationTable_StorageClassConfiguration_StorageClass { get; set; }
        #endregion
        
        #region Parameter DataMigration_MaintenanceSettings_IcebergCompaction_Strategy
        /// <summary>
        /// <para>
        /// <para>The compaction strategy. The only valid value is <c>binpack</c>, which is the default.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3Tables.IcebergCompactionStrategy")]
        public Amazon.S3Tables.IcebergCompactionStrategy DataMigration_MaintenanceSettings_IcebergCompaction_Strategy { get; set; }
        #endregion
        
        #region Parameter DestinationTable_TableBucketARN
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the table bucket to create the table in.</para>
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
        public System.String DestinationTable_TableBucketARN { get; set; }
        #endregion
        
        #region Parameter MigrationOutput_Prefixes_TableCompatibilityReport
        /// <summary>
        /// <para>
        /// <para>The key prefix for the table compatibility report, up to 512 bytes. If not specified,
        /// the report's keys start at the root of the bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MigrationOutput_Prefixes_TableCompatibilityReport { get; set; }
        #endregion
        
        #region Parameter Source_GlueTable_TableName
        /// <summary>
        /// <para>
        /// <para>The name of the table.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Source_GlueTable_TableName { get; set; }
        #endregion
        
        #region Parameter DestinationTable_Tag
        /// <summary>
        /// <para>
        /// <para>The tags to add to the table. A tag is a key-value pair that you apply to your resources.
        /// For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/tagging.html">Tagging
        /// for cost allocation or attribute-based access control (ABAC)</a>. If you specify tags,
        /// the migration role must have the <c>s3tables:TagResource</c> permission.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DestinationTable_Tags")]
        public System.Collections.Hashtable DestinationTable_Tag { get; set; }
        #endregion
        
        #region Parameter DataMigration_MaintenanceSettings_IcebergCompaction_TargetFileSizeMB
        /// <summary>
        /// <para>
        /// <para>The target size, from 64 to 512 MB, of the data files that the migration writes, and
        /// of the files that compaction writes after you complete the migration. The default
        /// is 512.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? DataMigration_MaintenanceSettings_IcebergCompaction_TargetFileSizeMB { get; set; }
        #endregion
        
        #region Parameter DestinationTable_Schema_Type
        /// <summary>
        /// <para>
        /// <para>The type of the top-level schema, which is always a <c>struct</c> type as defined
        /// in the <a href="https://iceberg.apache.org/spec/#schemas-and-data-types">Apache Iceberg
        /// specification</a>. This value must be <c>struct</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3Tables.SchemaV2FieldType")]
        public Amazon.S3Tables.SchemaV2FieldType DestinationTable_Schema_Type { get; set; }
        #endregion
        
        #region Parameter DataMigration_MigrationPolicies_UnmatchedSourceFieldsPolicy
        /// <summary>
        /// <para>
        /// <para>The migration policy for a source field that has no matching column in the destination
        /// schema. Valid values:</para><ul><li><para><c>fail</c> - Fails the migration. This is the default.</para></li><li><para><c>drop</c> - Leaves source columns that the destination schema doesn't have out
        /// of the destination table, and doesn't migrate source objects outside the Amazon Web
        /// Services Glue table's partition locations.</para></li></ul><para>A destination schema that leaves out a partition column or a field of a struct column
        /// fails the migration under either value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3Tables.UnmatchedSourceFieldsPolicy")]
        public Amazon.S3Tables.UnmatchedSourceFieldsPolicy DataMigration_MigrationPolicies_UnmatchedSourceFieldsPolicy { get; set; }
        #endregion
        
        #region Parameter DestinationTable_Properties_WriteFormat
        /// <summary>
        /// <para>
        /// <para>The file format of the data files. The only supported format is <c>parquet</c>, the
        /// default.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3Tables.DataFileFormat")]
        public Amazon.S3Tables.DataFileFormat DestinationTable_Properties_WriteFormat { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3Tables.Model.StartTableMigrationResponse).
        /// Specifying the name of a property of type Amazon.S3Tables.Model.StartTableMigrationResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RoleARN), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-S3TTableMigration (StartTableMigration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3Tables.Model.StartTableMigrationResponse, StartS3TTableMigrationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DataMigration_MaintenanceSettings_IcebergCompaction_Strategy = this.DataMigration_MaintenanceSettings_IcebergCompaction_Strategy;
            context.DataMigration_MaintenanceSettings_IcebergCompaction_TargetFileSizeMB = this.DataMigration_MaintenanceSettings_IcebergCompaction_TargetFileSizeMB;
            context.DataMigration_MaintenanceSettings_IcebergSnapshotManagement_MaxSnapshotAgeHour = this.DataMigration_MaintenanceSettings_IcebergSnapshotManagement_MaxSnapshotAgeHour;
            context.DataMigration_MaintenanceSettings_IcebergSnapshotManagement_MinSnapshotsToKeep = this.DataMigration_MaintenanceSettings_IcebergSnapshotManagement_MinSnapshotsToKeep;
            context.DataMigration_MigrationPolicies_IncompatibleValuesPolicy = this.DataMigration_MigrationPolicies_IncompatibleValuesPolicy;
            context.DataMigration_MigrationPolicies_UnmatchedSourceFieldsPolicy = this.DataMigration_MigrationPolicies_UnmatchedSourceFieldsPolicy;
            context.DestinationTable_EncryptionConfiguration_KmsKeyArn = this.DestinationTable_EncryptionConfiguration_KmsKeyArn;
            context.DestinationTable_EncryptionConfiguration_SseAlgorithm = this.DestinationTable_EncryptionConfiguration_SseAlgorithm;
            if (this.DestinationTable_IcebergSortOrder_Field != null)
            {
                context.DestinationTable_IcebergSortOrder_Field = new List<Amazon.S3Tables.Model.IcebergSortField>(this.DestinationTable_IcebergSortOrder_Field);
            }
            context.DestinationTable_IcebergSortOrder_OrderId = this.DestinationTable_IcebergSortOrder_OrderId;
            context.DestinationTable_Name = this.DestinationTable_Name;
            #if MODULAR
            if (this.DestinationTable_Name == null && ParameterWasBound(nameof(this.DestinationTable_Name)))
            {
                WriteWarning("You are passing $null as a value for parameter DestinationTable_Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DestinationTable_Namespace = this.DestinationTable_Namespace;
            #if MODULAR
            if (this.DestinationTable_Namespace == null && ParameterWasBound(nameof(this.DestinationTable_Namespace)))
            {
                WriteWarning("You are passing $null as a value for parameter DestinationTable_Namespace which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DestinationTable_Properties_CompressionCodec = this.DestinationTable_Properties_CompressionCodec;
            context.DestinationTable_Properties_DictionaryEncoding = this.DestinationTable_Properties_DictionaryEncoding;
            context.DestinationTable_Properties_IcebergFormatVersion = this.DestinationTable_Properties_IcebergFormatVersion;
            context.DestinationTable_Properties_WriteFormat = this.DestinationTable_Properties_WriteFormat;
            if (this.DestinationTable_Schema_Field != null)
            {
                context.DestinationTable_Schema_Field = new List<Amazon.S3Tables.Model.SchemaV2Field>(this.DestinationTable_Schema_Field);
            }
            if (this.DestinationTable_Schema_IdentifierFieldId != null)
            {
                context.DestinationTable_Schema_IdentifierFieldId = new List<System.Int32>(this.DestinationTable_Schema_IdentifierFieldId);
            }
            context.DestinationTable_Schema_SchemaId = this.DestinationTable_Schema_SchemaId;
            context.DestinationTable_Schema_Type = this.DestinationTable_Schema_Type;
            context.DestinationTable_StorageClassConfiguration_StorageClass = this.DestinationTable_StorageClassConfiguration_StorageClass;
            context.DestinationTable_TableBucketARN = this.DestinationTable_TableBucketARN;
            #if MODULAR
            if (this.DestinationTable_TableBucketARN == null && ParameterWasBound(nameof(this.DestinationTable_TableBucketARN)))
            {
                WriteWarning("You are passing $null as a value for parameter DestinationTable_TableBucketARN which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.DestinationTable_Tag != null)
            {
                context.DestinationTable_Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.DestinationTable_Tag.Keys)
                {
                    context.DestinationTable_Tag.Add((String)hashKey, (System.String)(this.DestinationTable_Tag[hashKey]));
                }
            }
            context.MigrationOutput_Bucket = this.MigrationOutput_Bucket;
            #if MODULAR
            if (this.MigrationOutput_Bucket == null && ParameterWasBound(nameof(this.MigrationOutput_Bucket)))
            {
                WriteWarning("You are passing $null as a value for parameter MigrationOutput_Bucket which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MigrationOutput_Prefixes_ObjectCompatibilityReport = this.MigrationOutput_Prefixes_ObjectCompatibilityReport;
            context.MigrationOutput_Prefixes_ObjectMigrationReport = this.MigrationOutput_Prefixes_ObjectMigrationReport;
            context.MigrationOutput_Prefixes_TableCompatibilityReport = this.MigrationOutput_Prefixes_TableCompatibilityReport;
            context.ReviewMigrationPlan = this.ReviewMigrationPlan;
            context.RoleARN = this.RoleARN;
            #if MODULAR
            if (this.RoleARN == null && ParameterWasBound(nameof(this.RoleARN)))
            {
                WriteWarning("You are passing $null as a value for parameter RoleARN which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Source_GlueTable_CatalogId = this.Source_GlueTable_CatalogId;
            context.Source_GlueTable_DatabaseName = this.Source_GlueTable_DatabaseName;
            context.Source_GlueTable_TableName = this.Source_GlueTable_TableName;
            context.SourceType = this.SourceType;
            #if MODULAR
            if (this.SourceType == null && ParameterWasBound(nameof(this.SourceType)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.S3Tables.Model.StartTableMigrationRequest();
            
            
             // populate DataMigration
            var requestDataMigrationIsNull = true;
            request.DataMigration = new Amazon.S3Tables.Model.DataMigrationSettings();
            Amazon.S3Tables.Model.MaintenanceSettings requestDataMigration_dataMigration_MaintenanceSettings = null;
            
             // populate MaintenanceSettings
            var requestDataMigration_dataMigration_MaintenanceSettingsIsNull = true;
            requestDataMigration_dataMigration_MaintenanceSettings = new Amazon.S3Tables.Model.MaintenanceSettings();
            Amazon.S3Tables.Model.MigrationCompactionSettings requestDataMigration_dataMigration_MaintenanceSettings_dataMigration_MaintenanceSettings_IcebergCompaction = null;
            
             // populate IcebergCompaction
            var requestDataMigration_dataMigration_MaintenanceSettings_dataMigration_MaintenanceSettings_IcebergCompactionIsNull = true;
            requestDataMigration_dataMigration_MaintenanceSettings_dataMigration_MaintenanceSettings_IcebergCompaction = new Amazon.S3Tables.Model.MigrationCompactionSettings();
            Amazon.S3Tables.IcebergCompactionStrategy requestDataMigration_dataMigration_MaintenanceSettings_dataMigration_MaintenanceSettings_IcebergCompaction_dataMigration_MaintenanceSettings_IcebergCompaction_Strategy = null;
            if (cmdletContext.DataMigration_MaintenanceSettings_IcebergCompaction_Strategy != null)
            {
                requestDataMigration_dataMigration_MaintenanceSettings_dataMigration_MaintenanceSettings_IcebergCompaction_dataMigration_MaintenanceSettings_IcebergCompaction_Strategy = cmdletContext.DataMigration_MaintenanceSettings_IcebergCompaction_Strategy;
            }
            if (requestDataMigration_dataMigration_MaintenanceSettings_dataMigration_MaintenanceSettings_IcebergCompaction_dataMigration_MaintenanceSettings_IcebergCompaction_Strategy != null)
            {
                requestDataMigration_dataMigration_MaintenanceSettings_dataMigration_MaintenanceSettings_IcebergCompaction.Strategy = requestDataMigration_dataMigration_MaintenanceSettings_dataMigration_MaintenanceSettings_IcebergCompaction_dataMigration_MaintenanceSettings_IcebergCompaction_Strategy;
                requestDataMigration_dataMigration_MaintenanceSettings_dataMigration_MaintenanceSettings_IcebergCompactionIsNull = false;
            }
            System.Int32? requestDataMigration_dataMigration_MaintenanceSettings_dataMigration_MaintenanceSettings_IcebergCompaction_dataMigration_MaintenanceSettings_IcebergCompaction_TargetFileSizeMB = null;
            if (cmdletContext.DataMigration_MaintenanceSettings_IcebergCompaction_TargetFileSizeMB != null)
            {
                requestDataMigration_dataMigration_MaintenanceSettings_dataMigration_MaintenanceSettings_IcebergCompaction_dataMigration_MaintenanceSettings_IcebergCompaction_TargetFileSizeMB = cmdletContext.DataMigration_MaintenanceSettings_IcebergCompaction_TargetFileSizeMB.Value;
            }
            if (requestDataMigration_dataMigration_MaintenanceSettings_dataMigration_MaintenanceSettings_IcebergCompaction_dataMigration_MaintenanceSettings_IcebergCompaction_TargetFileSizeMB != null)
            {
                requestDataMigration_dataMigration_MaintenanceSettings_dataMigration_MaintenanceSettings_IcebergCompaction.TargetFileSizeMB = requestDataMigration_dataMigration_MaintenanceSettings_dataMigration_MaintenanceSettings_IcebergCompaction_dataMigration_MaintenanceSettings_IcebergCompaction_TargetFileSizeMB.Value;
                requestDataMigration_dataMigration_MaintenanceSettings_dataMigration_MaintenanceSettings_IcebergCompactionIsNull = false;
            }
             // determine if requestDataMigration_dataMigration_MaintenanceSettings_dataMigration_MaintenanceSettings_IcebergCompaction should be set to null
            if (requestDataMigration_dataMigration_MaintenanceSettings_dataMigration_MaintenanceSettings_IcebergCompactionIsNull)
            {
                requestDataMigration_dataMigration_MaintenanceSettings_dataMigration_MaintenanceSettings_IcebergCompaction = null;
            }
            if (requestDataMigration_dataMigration_MaintenanceSettings_dataMigration_MaintenanceSettings_IcebergCompaction != null)
            {
                requestDataMigration_dataMigration_MaintenanceSettings.IcebergCompaction = requestDataMigration_dataMigration_MaintenanceSettings_dataMigration_MaintenanceSettings_IcebergCompaction;
                requestDataMigration_dataMigration_MaintenanceSettingsIsNull = false;
            }
            Amazon.S3Tables.Model.MigrationSnapshotManagementSettings requestDataMigration_dataMigration_MaintenanceSettings_dataMigration_MaintenanceSettings_IcebergSnapshotManagement = null;
            
             // populate IcebergSnapshotManagement
            var requestDataMigration_dataMigration_MaintenanceSettings_dataMigration_MaintenanceSettings_IcebergSnapshotManagementIsNull = true;
            requestDataMigration_dataMigration_MaintenanceSettings_dataMigration_MaintenanceSettings_IcebergSnapshotManagement = new Amazon.S3Tables.Model.MigrationSnapshotManagementSettings();
            System.Int32? requestDataMigration_dataMigration_MaintenanceSettings_dataMigration_MaintenanceSettings_IcebergSnapshotManagement_dataMigration_MaintenanceSettings_IcebergSnapshotManagement_MaxSnapshotAgeHour = null;
            if (cmdletContext.DataMigration_MaintenanceSettings_IcebergSnapshotManagement_MaxSnapshotAgeHour != null)
            {
                requestDataMigration_dataMigration_MaintenanceSettings_dataMigration_MaintenanceSettings_IcebergSnapshotManagement_dataMigration_MaintenanceSettings_IcebergSnapshotManagement_MaxSnapshotAgeHour = cmdletContext.DataMigration_MaintenanceSettings_IcebergSnapshotManagement_MaxSnapshotAgeHour.Value;
            }
            if (requestDataMigration_dataMigration_MaintenanceSettings_dataMigration_MaintenanceSettings_IcebergSnapshotManagement_dataMigration_MaintenanceSettings_IcebergSnapshotManagement_MaxSnapshotAgeHour != null)
            {
                requestDataMigration_dataMigration_MaintenanceSettings_dataMigration_MaintenanceSettings_IcebergSnapshotManagement.MaxSnapshotAgeHours = requestDataMigration_dataMigration_MaintenanceSettings_dataMigration_MaintenanceSettings_IcebergSnapshotManagement_dataMigration_MaintenanceSettings_IcebergSnapshotManagement_MaxSnapshotAgeHour.Value;
                requestDataMigration_dataMigration_MaintenanceSettings_dataMigration_MaintenanceSettings_IcebergSnapshotManagementIsNull = false;
            }
            System.Int32? requestDataMigration_dataMigration_MaintenanceSettings_dataMigration_MaintenanceSettings_IcebergSnapshotManagement_dataMigration_MaintenanceSettings_IcebergSnapshotManagement_MinSnapshotsToKeep = null;
            if (cmdletContext.DataMigration_MaintenanceSettings_IcebergSnapshotManagement_MinSnapshotsToKeep != null)
            {
                requestDataMigration_dataMigration_MaintenanceSettings_dataMigration_MaintenanceSettings_IcebergSnapshotManagement_dataMigration_MaintenanceSettings_IcebergSnapshotManagement_MinSnapshotsToKeep = cmdletContext.DataMigration_MaintenanceSettings_IcebergSnapshotManagement_MinSnapshotsToKeep.Value;
            }
            if (requestDataMigration_dataMigration_MaintenanceSettings_dataMigration_MaintenanceSettings_IcebergSnapshotManagement_dataMigration_MaintenanceSettings_IcebergSnapshotManagement_MinSnapshotsToKeep != null)
            {
                requestDataMigration_dataMigration_MaintenanceSettings_dataMigration_MaintenanceSettings_IcebergSnapshotManagement.MinSnapshotsToKeep = requestDataMigration_dataMigration_MaintenanceSettings_dataMigration_MaintenanceSettings_IcebergSnapshotManagement_dataMigration_MaintenanceSettings_IcebergSnapshotManagement_MinSnapshotsToKeep.Value;
                requestDataMigration_dataMigration_MaintenanceSettings_dataMigration_MaintenanceSettings_IcebergSnapshotManagementIsNull = false;
            }
             // determine if requestDataMigration_dataMigration_MaintenanceSettings_dataMigration_MaintenanceSettings_IcebergSnapshotManagement should be set to null
            if (requestDataMigration_dataMigration_MaintenanceSettings_dataMigration_MaintenanceSettings_IcebergSnapshotManagementIsNull)
            {
                requestDataMigration_dataMigration_MaintenanceSettings_dataMigration_MaintenanceSettings_IcebergSnapshotManagement = null;
            }
            if (requestDataMigration_dataMigration_MaintenanceSettings_dataMigration_MaintenanceSettings_IcebergSnapshotManagement != null)
            {
                requestDataMigration_dataMigration_MaintenanceSettings.IcebergSnapshotManagement = requestDataMigration_dataMigration_MaintenanceSettings_dataMigration_MaintenanceSettings_IcebergSnapshotManagement;
                requestDataMigration_dataMigration_MaintenanceSettingsIsNull = false;
            }
             // determine if requestDataMigration_dataMigration_MaintenanceSettings should be set to null
            if (requestDataMigration_dataMigration_MaintenanceSettingsIsNull)
            {
                requestDataMigration_dataMigration_MaintenanceSettings = null;
            }
            if (requestDataMigration_dataMigration_MaintenanceSettings != null)
            {
                request.DataMigration.MaintenanceSettings = requestDataMigration_dataMigration_MaintenanceSettings;
                requestDataMigrationIsNull = false;
            }
            Amazon.S3Tables.Model.MigrationPolicies requestDataMigration_dataMigration_MigrationPolicies = null;
            
             // populate MigrationPolicies
            var requestDataMigration_dataMigration_MigrationPoliciesIsNull = true;
            requestDataMigration_dataMigration_MigrationPolicies = new Amazon.S3Tables.Model.MigrationPolicies();
            Amazon.S3Tables.IncompatibleValuesPolicy requestDataMigration_dataMigration_MigrationPolicies_dataMigration_MigrationPolicies_IncompatibleValuesPolicy = null;
            if (cmdletContext.DataMigration_MigrationPolicies_IncompatibleValuesPolicy != null)
            {
                requestDataMigration_dataMigration_MigrationPolicies_dataMigration_MigrationPolicies_IncompatibleValuesPolicy = cmdletContext.DataMigration_MigrationPolicies_IncompatibleValuesPolicy;
            }
            if (requestDataMigration_dataMigration_MigrationPolicies_dataMigration_MigrationPolicies_IncompatibleValuesPolicy != null)
            {
                requestDataMigration_dataMigration_MigrationPolicies.IncompatibleValuesPolicy = requestDataMigration_dataMigration_MigrationPolicies_dataMigration_MigrationPolicies_IncompatibleValuesPolicy;
                requestDataMigration_dataMigration_MigrationPoliciesIsNull = false;
            }
            Amazon.S3Tables.UnmatchedSourceFieldsPolicy requestDataMigration_dataMigration_MigrationPolicies_dataMigration_MigrationPolicies_UnmatchedSourceFieldsPolicy = null;
            if (cmdletContext.DataMigration_MigrationPolicies_UnmatchedSourceFieldsPolicy != null)
            {
                requestDataMigration_dataMigration_MigrationPolicies_dataMigration_MigrationPolicies_UnmatchedSourceFieldsPolicy = cmdletContext.DataMigration_MigrationPolicies_UnmatchedSourceFieldsPolicy;
            }
            if (requestDataMigration_dataMigration_MigrationPolicies_dataMigration_MigrationPolicies_UnmatchedSourceFieldsPolicy != null)
            {
                requestDataMigration_dataMigration_MigrationPolicies.UnmatchedSourceFieldsPolicy = requestDataMigration_dataMigration_MigrationPolicies_dataMigration_MigrationPolicies_UnmatchedSourceFieldsPolicy;
                requestDataMigration_dataMigration_MigrationPoliciesIsNull = false;
            }
             // determine if requestDataMigration_dataMigration_MigrationPolicies should be set to null
            if (requestDataMigration_dataMigration_MigrationPoliciesIsNull)
            {
                requestDataMigration_dataMigration_MigrationPolicies = null;
            }
            if (requestDataMigration_dataMigration_MigrationPolicies != null)
            {
                request.DataMigration.MigrationPolicies = requestDataMigration_dataMigration_MigrationPolicies;
                requestDataMigrationIsNull = false;
            }
             // determine if request.DataMigration should be set to null
            if (requestDataMigrationIsNull)
            {
                request.DataMigration = null;
            }
            
             // populate DestinationTable
            var requestDestinationTableIsNull = true;
            request.DestinationTable = new Amazon.S3Tables.Model.DestinationTable();
            System.String requestDestinationTable_destinationTable_Name = null;
            if (cmdletContext.DestinationTable_Name != null)
            {
                requestDestinationTable_destinationTable_Name = cmdletContext.DestinationTable_Name;
            }
            if (requestDestinationTable_destinationTable_Name != null)
            {
                request.DestinationTable.Name = requestDestinationTable_destinationTable_Name;
                requestDestinationTableIsNull = false;
            }
            System.String requestDestinationTable_destinationTable_Namespace = null;
            if (cmdletContext.DestinationTable_Namespace != null)
            {
                requestDestinationTable_destinationTable_Namespace = cmdletContext.DestinationTable_Namespace;
            }
            if (requestDestinationTable_destinationTable_Namespace != null)
            {
                request.DestinationTable.Namespace = requestDestinationTable_destinationTable_Namespace;
                requestDestinationTableIsNull = false;
            }
            System.String requestDestinationTable_destinationTable_TableBucketARN = null;
            if (cmdletContext.DestinationTable_TableBucketARN != null)
            {
                requestDestinationTable_destinationTable_TableBucketARN = cmdletContext.DestinationTable_TableBucketARN;
            }
            if (requestDestinationTable_destinationTable_TableBucketARN != null)
            {
                request.DestinationTable.TableBucketARN = requestDestinationTable_destinationTable_TableBucketARN;
                requestDestinationTableIsNull = false;
            }
            Dictionary<System.String, System.String> requestDestinationTable_destinationTable_Tag = null;
            if (cmdletContext.DestinationTable_Tag != null)
            {
                requestDestinationTable_destinationTable_Tag = cmdletContext.DestinationTable_Tag;
            }
            if (requestDestinationTable_destinationTable_Tag != null)
            {
                request.DestinationTable.Tags = requestDestinationTable_destinationTable_Tag;
                requestDestinationTableIsNull = false;
            }
            Amazon.S3Tables.Model.StorageClassConfiguration requestDestinationTable_destinationTable_StorageClassConfiguration = null;
            
             // populate StorageClassConfiguration
            var requestDestinationTable_destinationTable_StorageClassConfigurationIsNull = true;
            requestDestinationTable_destinationTable_StorageClassConfiguration = new Amazon.S3Tables.Model.StorageClassConfiguration();
            Amazon.S3Tables.StorageClass requestDestinationTable_destinationTable_StorageClassConfiguration_destinationTable_StorageClassConfiguration_StorageClass = null;
            if (cmdletContext.DestinationTable_StorageClassConfiguration_StorageClass != null)
            {
                requestDestinationTable_destinationTable_StorageClassConfiguration_destinationTable_StorageClassConfiguration_StorageClass = cmdletContext.DestinationTable_StorageClassConfiguration_StorageClass;
            }
            if (requestDestinationTable_destinationTable_StorageClassConfiguration_destinationTable_StorageClassConfiguration_StorageClass != null)
            {
                requestDestinationTable_destinationTable_StorageClassConfiguration.StorageClass = requestDestinationTable_destinationTable_StorageClassConfiguration_destinationTable_StorageClassConfiguration_StorageClass;
                requestDestinationTable_destinationTable_StorageClassConfigurationIsNull = false;
            }
             // determine if requestDestinationTable_destinationTable_StorageClassConfiguration should be set to null
            if (requestDestinationTable_destinationTable_StorageClassConfigurationIsNull)
            {
                requestDestinationTable_destinationTable_StorageClassConfiguration = null;
            }
            if (requestDestinationTable_destinationTable_StorageClassConfiguration != null)
            {
                request.DestinationTable.StorageClassConfiguration = requestDestinationTable_destinationTable_StorageClassConfiguration;
                requestDestinationTableIsNull = false;
            }
            Amazon.S3Tables.Model.EncryptionConfiguration requestDestinationTable_destinationTable_EncryptionConfiguration = null;
            
             // populate EncryptionConfiguration
            var requestDestinationTable_destinationTable_EncryptionConfigurationIsNull = true;
            requestDestinationTable_destinationTable_EncryptionConfiguration = new Amazon.S3Tables.Model.EncryptionConfiguration();
            System.String requestDestinationTable_destinationTable_EncryptionConfiguration_destinationTable_EncryptionConfiguration_KmsKeyArn = null;
            if (cmdletContext.DestinationTable_EncryptionConfiguration_KmsKeyArn != null)
            {
                requestDestinationTable_destinationTable_EncryptionConfiguration_destinationTable_EncryptionConfiguration_KmsKeyArn = cmdletContext.DestinationTable_EncryptionConfiguration_KmsKeyArn;
            }
            if (requestDestinationTable_destinationTable_EncryptionConfiguration_destinationTable_EncryptionConfiguration_KmsKeyArn != null)
            {
                requestDestinationTable_destinationTable_EncryptionConfiguration.KmsKeyArn = requestDestinationTable_destinationTable_EncryptionConfiguration_destinationTable_EncryptionConfiguration_KmsKeyArn;
                requestDestinationTable_destinationTable_EncryptionConfigurationIsNull = false;
            }
            Amazon.S3Tables.SSEAlgorithm requestDestinationTable_destinationTable_EncryptionConfiguration_destinationTable_EncryptionConfiguration_SseAlgorithm = null;
            if (cmdletContext.DestinationTable_EncryptionConfiguration_SseAlgorithm != null)
            {
                requestDestinationTable_destinationTable_EncryptionConfiguration_destinationTable_EncryptionConfiguration_SseAlgorithm = cmdletContext.DestinationTable_EncryptionConfiguration_SseAlgorithm;
            }
            if (requestDestinationTable_destinationTable_EncryptionConfiguration_destinationTable_EncryptionConfiguration_SseAlgorithm != null)
            {
                requestDestinationTable_destinationTable_EncryptionConfiguration.SseAlgorithm = requestDestinationTable_destinationTable_EncryptionConfiguration_destinationTable_EncryptionConfiguration_SseAlgorithm;
                requestDestinationTable_destinationTable_EncryptionConfigurationIsNull = false;
            }
             // determine if requestDestinationTable_destinationTable_EncryptionConfiguration should be set to null
            if (requestDestinationTable_destinationTable_EncryptionConfigurationIsNull)
            {
                requestDestinationTable_destinationTable_EncryptionConfiguration = null;
            }
            if (requestDestinationTable_destinationTable_EncryptionConfiguration != null)
            {
                request.DestinationTable.EncryptionConfiguration = requestDestinationTable_destinationTable_EncryptionConfiguration;
                requestDestinationTableIsNull = false;
            }
            Amazon.S3Tables.Model.IcebergSortOrder requestDestinationTable_destinationTable_IcebergSortOrder = null;
            
             // populate IcebergSortOrder
            var requestDestinationTable_destinationTable_IcebergSortOrderIsNull = true;
            requestDestinationTable_destinationTable_IcebergSortOrder = new Amazon.S3Tables.Model.IcebergSortOrder();
            List<Amazon.S3Tables.Model.IcebergSortField> requestDestinationTable_destinationTable_IcebergSortOrder_destinationTable_IcebergSortOrder_Field = null;
            if (cmdletContext.DestinationTable_IcebergSortOrder_Field != null)
            {
                requestDestinationTable_destinationTable_IcebergSortOrder_destinationTable_IcebergSortOrder_Field = cmdletContext.DestinationTable_IcebergSortOrder_Field;
            }
            if (requestDestinationTable_destinationTable_IcebergSortOrder_destinationTable_IcebergSortOrder_Field != null)
            {
                requestDestinationTable_destinationTable_IcebergSortOrder.Fields = requestDestinationTable_destinationTable_IcebergSortOrder_destinationTable_IcebergSortOrder_Field;
                requestDestinationTable_destinationTable_IcebergSortOrderIsNull = false;
            }
            System.Int32? requestDestinationTable_destinationTable_IcebergSortOrder_destinationTable_IcebergSortOrder_OrderId = null;
            if (cmdletContext.DestinationTable_IcebergSortOrder_OrderId != null)
            {
                requestDestinationTable_destinationTable_IcebergSortOrder_destinationTable_IcebergSortOrder_OrderId = cmdletContext.DestinationTable_IcebergSortOrder_OrderId.Value;
            }
            if (requestDestinationTable_destinationTable_IcebergSortOrder_destinationTable_IcebergSortOrder_OrderId != null)
            {
                requestDestinationTable_destinationTable_IcebergSortOrder.OrderId = requestDestinationTable_destinationTable_IcebergSortOrder_destinationTable_IcebergSortOrder_OrderId.Value;
                requestDestinationTable_destinationTable_IcebergSortOrderIsNull = false;
            }
             // determine if requestDestinationTable_destinationTable_IcebergSortOrder should be set to null
            if (requestDestinationTable_destinationTable_IcebergSortOrderIsNull)
            {
                requestDestinationTable_destinationTable_IcebergSortOrder = null;
            }
            if (requestDestinationTable_destinationTable_IcebergSortOrder != null)
            {
                request.DestinationTable.IcebergSortOrder = requestDestinationTable_destinationTable_IcebergSortOrder;
                requestDestinationTableIsNull = false;
            }
            Amazon.S3Tables.Model.MigrationTableProperties requestDestinationTable_destinationTable_Properties = null;
            
             // populate Properties
            var requestDestinationTable_destinationTable_PropertiesIsNull = true;
            requestDestinationTable_destinationTable_Properties = new Amazon.S3Tables.Model.MigrationTableProperties();
            Amazon.S3Tables.CompressionCodec requestDestinationTable_destinationTable_Properties_destinationTable_Properties_CompressionCodec = null;
            if (cmdletContext.DestinationTable_Properties_CompressionCodec != null)
            {
                requestDestinationTable_destinationTable_Properties_destinationTable_Properties_CompressionCodec = cmdletContext.DestinationTable_Properties_CompressionCodec;
            }
            if (requestDestinationTable_destinationTable_Properties_destinationTable_Properties_CompressionCodec != null)
            {
                requestDestinationTable_destinationTable_Properties.CompressionCodec = requestDestinationTable_destinationTable_Properties_destinationTable_Properties_CompressionCodec;
                requestDestinationTable_destinationTable_PropertiesIsNull = false;
            }
            System.Boolean? requestDestinationTable_destinationTable_Properties_destinationTable_Properties_DictionaryEncoding = null;
            if (cmdletContext.DestinationTable_Properties_DictionaryEncoding != null)
            {
                requestDestinationTable_destinationTable_Properties_destinationTable_Properties_DictionaryEncoding = cmdletContext.DestinationTable_Properties_DictionaryEncoding.Value;
            }
            if (requestDestinationTable_destinationTable_Properties_destinationTable_Properties_DictionaryEncoding != null)
            {
                requestDestinationTable_destinationTable_Properties.DictionaryEncoding = requestDestinationTable_destinationTable_Properties_destinationTable_Properties_DictionaryEncoding.Value;
                requestDestinationTable_destinationTable_PropertiesIsNull = false;
            }
            System.Int32? requestDestinationTable_destinationTable_Properties_destinationTable_Properties_IcebergFormatVersion = null;
            if (cmdletContext.DestinationTable_Properties_IcebergFormatVersion != null)
            {
                requestDestinationTable_destinationTable_Properties_destinationTable_Properties_IcebergFormatVersion = cmdletContext.DestinationTable_Properties_IcebergFormatVersion.Value;
            }
            if (requestDestinationTable_destinationTable_Properties_destinationTable_Properties_IcebergFormatVersion != null)
            {
                requestDestinationTable_destinationTable_Properties.IcebergFormatVersion = requestDestinationTable_destinationTable_Properties_destinationTable_Properties_IcebergFormatVersion.Value;
                requestDestinationTable_destinationTable_PropertiesIsNull = false;
            }
            Amazon.S3Tables.DataFileFormat requestDestinationTable_destinationTable_Properties_destinationTable_Properties_WriteFormat = null;
            if (cmdletContext.DestinationTable_Properties_WriteFormat != null)
            {
                requestDestinationTable_destinationTable_Properties_destinationTable_Properties_WriteFormat = cmdletContext.DestinationTable_Properties_WriteFormat;
            }
            if (requestDestinationTable_destinationTable_Properties_destinationTable_Properties_WriteFormat != null)
            {
                requestDestinationTable_destinationTable_Properties.WriteFormat = requestDestinationTable_destinationTable_Properties_destinationTable_Properties_WriteFormat;
                requestDestinationTable_destinationTable_PropertiesIsNull = false;
            }
             // determine if requestDestinationTable_destinationTable_Properties should be set to null
            if (requestDestinationTable_destinationTable_PropertiesIsNull)
            {
                requestDestinationTable_destinationTable_Properties = null;
            }
            if (requestDestinationTable_destinationTable_Properties != null)
            {
                request.DestinationTable.Properties = requestDestinationTable_destinationTable_Properties;
                requestDestinationTableIsNull = false;
            }
            Amazon.S3Tables.Model.IcebergSchemaV2 requestDestinationTable_destinationTable_Schema = null;
            
             // populate Schema
            var requestDestinationTable_destinationTable_SchemaIsNull = true;
            requestDestinationTable_destinationTable_Schema = new Amazon.S3Tables.Model.IcebergSchemaV2();
            List<Amazon.S3Tables.Model.SchemaV2Field> requestDestinationTable_destinationTable_Schema_destinationTable_Schema_Field = null;
            if (cmdletContext.DestinationTable_Schema_Field != null)
            {
                requestDestinationTable_destinationTable_Schema_destinationTable_Schema_Field = cmdletContext.DestinationTable_Schema_Field;
            }
            if (requestDestinationTable_destinationTable_Schema_destinationTable_Schema_Field != null)
            {
                requestDestinationTable_destinationTable_Schema.Fields = requestDestinationTable_destinationTable_Schema_destinationTable_Schema_Field;
                requestDestinationTable_destinationTable_SchemaIsNull = false;
            }
            List<System.Int32> requestDestinationTable_destinationTable_Schema_destinationTable_Schema_IdentifierFieldId = null;
            if (cmdletContext.DestinationTable_Schema_IdentifierFieldId != null)
            {
                requestDestinationTable_destinationTable_Schema_destinationTable_Schema_IdentifierFieldId = cmdletContext.DestinationTable_Schema_IdentifierFieldId;
            }
            if (requestDestinationTable_destinationTable_Schema_destinationTable_Schema_IdentifierFieldId != null)
            {
                requestDestinationTable_destinationTable_Schema.IdentifierFieldIds = requestDestinationTable_destinationTable_Schema_destinationTable_Schema_IdentifierFieldId;
                requestDestinationTable_destinationTable_SchemaIsNull = false;
            }
            System.Int32? requestDestinationTable_destinationTable_Schema_destinationTable_Schema_SchemaId = null;
            if (cmdletContext.DestinationTable_Schema_SchemaId != null)
            {
                requestDestinationTable_destinationTable_Schema_destinationTable_Schema_SchemaId = cmdletContext.DestinationTable_Schema_SchemaId.Value;
            }
            if (requestDestinationTable_destinationTable_Schema_destinationTable_Schema_SchemaId != null)
            {
                requestDestinationTable_destinationTable_Schema.SchemaId = requestDestinationTable_destinationTable_Schema_destinationTable_Schema_SchemaId.Value;
                requestDestinationTable_destinationTable_SchemaIsNull = false;
            }
            Amazon.S3Tables.SchemaV2FieldType requestDestinationTable_destinationTable_Schema_destinationTable_Schema_Type = null;
            if (cmdletContext.DestinationTable_Schema_Type != null)
            {
                requestDestinationTable_destinationTable_Schema_destinationTable_Schema_Type = cmdletContext.DestinationTable_Schema_Type;
            }
            if (requestDestinationTable_destinationTable_Schema_destinationTable_Schema_Type != null)
            {
                requestDestinationTable_destinationTable_Schema.Type = requestDestinationTable_destinationTable_Schema_destinationTable_Schema_Type;
                requestDestinationTable_destinationTable_SchemaIsNull = false;
            }
             // determine if requestDestinationTable_destinationTable_Schema should be set to null
            if (requestDestinationTable_destinationTable_SchemaIsNull)
            {
                requestDestinationTable_destinationTable_Schema = null;
            }
            if (requestDestinationTable_destinationTable_Schema != null)
            {
                request.DestinationTable.Schema = requestDestinationTable_destinationTable_Schema;
                requestDestinationTableIsNull = false;
            }
             // determine if request.DestinationTable should be set to null
            if (requestDestinationTableIsNull)
            {
                request.DestinationTable = null;
            }
            
             // populate MigrationOutput
            var requestMigrationOutputIsNull = true;
            request.MigrationOutput = new Amazon.S3Tables.Model.MigrationOutputConfiguration();
            System.String requestMigrationOutput_migrationOutput_Bucket = null;
            if (cmdletContext.MigrationOutput_Bucket != null)
            {
                requestMigrationOutput_migrationOutput_Bucket = cmdletContext.MigrationOutput_Bucket;
            }
            if (requestMigrationOutput_migrationOutput_Bucket != null)
            {
                request.MigrationOutput.Bucket = requestMigrationOutput_migrationOutput_Bucket;
                requestMigrationOutputIsNull = false;
            }
            Amazon.S3Tables.Model.MigrationReportPrefixes requestMigrationOutput_migrationOutput_Prefixes = null;
            
             // populate Prefixes
            var requestMigrationOutput_migrationOutput_PrefixesIsNull = true;
            requestMigrationOutput_migrationOutput_Prefixes = new Amazon.S3Tables.Model.MigrationReportPrefixes();
            System.String requestMigrationOutput_migrationOutput_Prefixes_migrationOutput_Prefixes_ObjectCompatibilityReport = null;
            if (cmdletContext.MigrationOutput_Prefixes_ObjectCompatibilityReport != null)
            {
                requestMigrationOutput_migrationOutput_Prefixes_migrationOutput_Prefixes_ObjectCompatibilityReport = cmdletContext.MigrationOutput_Prefixes_ObjectCompatibilityReport;
            }
            if (requestMigrationOutput_migrationOutput_Prefixes_migrationOutput_Prefixes_ObjectCompatibilityReport != null)
            {
                requestMigrationOutput_migrationOutput_Prefixes.ObjectCompatibilityReport = requestMigrationOutput_migrationOutput_Prefixes_migrationOutput_Prefixes_ObjectCompatibilityReport;
                requestMigrationOutput_migrationOutput_PrefixesIsNull = false;
            }
            System.String requestMigrationOutput_migrationOutput_Prefixes_migrationOutput_Prefixes_ObjectMigrationReport = null;
            if (cmdletContext.MigrationOutput_Prefixes_ObjectMigrationReport != null)
            {
                requestMigrationOutput_migrationOutput_Prefixes_migrationOutput_Prefixes_ObjectMigrationReport = cmdletContext.MigrationOutput_Prefixes_ObjectMigrationReport;
            }
            if (requestMigrationOutput_migrationOutput_Prefixes_migrationOutput_Prefixes_ObjectMigrationReport != null)
            {
                requestMigrationOutput_migrationOutput_Prefixes.ObjectMigrationReport = requestMigrationOutput_migrationOutput_Prefixes_migrationOutput_Prefixes_ObjectMigrationReport;
                requestMigrationOutput_migrationOutput_PrefixesIsNull = false;
            }
            System.String requestMigrationOutput_migrationOutput_Prefixes_migrationOutput_Prefixes_TableCompatibilityReport = null;
            if (cmdletContext.MigrationOutput_Prefixes_TableCompatibilityReport != null)
            {
                requestMigrationOutput_migrationOutput_Prefixes_migrationOutput_Prefixes_TableCompatibilityReport = cmdletContext.MigrationOutput_Prefixes_TableCompatibilityReport;
            }
            if (requestMigrationOutput_migrationOutput_Prefixes_migrationOutput_Prefixes_TableCompatibilityReport != null)
            {
                requestMigrationOutput_migrationOutput_Prefixes.TableCompatibilityReport = requestMigrationOutput_migrationOutput_Prefixes_migrationOutput_Prefixes_TableCompatibilityReport;
                requestMigrationOutput_migrationOutput_PrefixesIsNull = false;
            }
             // determine if requestMigrationOutput_migrationOutput_Prefixes should be set to null
            if (requestMigrationOutput_migrationOutput_PrefixesIsNull)
            {
                requestMigrationOutput_migrationOutput_Prefixes = null;
            }
            if (requestMigrationOutput_migrationOutput_Prefixes != null)
            {
                request.MigrationOutput.Prefixes = requestMigrationOutput_migrationOutput_Prefixes;
                requestMigrationOutputIsNull = false;
            }
             // determine if request.MigrationOutput should be set to null
            if (requestMigrationOutputIsNull)
            {
                request.MigrationOutput = null;
            }
            if (cmdletContext.ReviewMigrationPlan != null)
            {
                request.ReviewMigrationPlan = cmdletContext.ReviewMigrationPlan.Value;
            }
            if (cmdletContext.RoleARN != null)
            {
                request.RoleARN = cmdletContext.RoleARN;
            }
            
             // populate Source
            var requestSourceIsNull = true;
            request.Source = new Amazon.S3Tables.Model.SourceConfiguration();
            Amazon.S3Tables.Model.GlueTableSource requestSource_source_GlueTable = null;
            
             // populate GlueTable
            var requestSource_source_GlueTableIsNull = true;
            requestSource_source_GlueTable = new Amazon.S3Tables.Model.GlueTableSource();
            System.String requestSource_source_GlueTable_source_GlueTable_CatalogId = null;
            if (cmdletContext.Source_GlueTable_CatalogId != null)
            {
                requestSource_source_GlueTable_source_GlueTable_CatalogId = cmdletContext.Source_GlueTable_CatalogId;
            }
            if (requestSource_source_GlueTable_source_GlueTable_CatalogId != null)
            {
                requestSource_source_GlueTable.CatalogId = requestSource_source_GlueTable_source_GlueTable_CatalogId;
                requestSource_source_GlueTableIsNull = false;
            }
            System.String requestSource_source_GlueTable_source_GlueTable_DatabaseName = null;
            if (cmdletContext.Source_GlueTable_DatabaseName != null)
            {
                requestSource_source_GlueTable_source_GlueTable_DatabaseName = cmdletContext.Source_GlueTable_DatabaseName;
            }
            if (requestSource_source_GlueTable_source_GlueTable_DatabaseName != null)
            {
                requestSource_source_GlueTable.DatabaseName = requestSource_source_GlueTable_source_GlueTable_DatabaseName;
                requestSource_source_GlueTableIsNull = false;
            }
            System.String requestSource_source_GlueTable_source_GlueTable_TableName = null;
            if (cmdletContext.Source_GlueTable_TableName != null)
            {
                requestSource_source_GlueTable_source_GlueTable_TableName = cmdletContext.Source_GlueTable_TableName;
            }
            if (requestSource_source_GlueTable_source_GlueTable_TableName != null)
            {
                requestSource_source_GlueTable.TableName = requestSource_source_GlueTable_source_GlueTable_TableName;
                requestSource_source_GlueTableIsNull = false;
            }
             // determine if requestSource_source_GlueTable should be set to null
            if (requestSource_source_GlueTableIsNull)
            {
                requestSource_source_GlueTable = null;
            }
            if (requestSource_source_GlueTable != null)
            {
                request.Source.GlueTable = requestSource_source_GlueTable;
                requestSourceIsNull = false;
            }
             // determine if request.Source should be set to null
            if (requestSourceIsNull)
            {
                request.Source = null;
            }
            if (cmdletContext.SourceType != null)
            {
                request.SourceType = cmdletContext.SourceType;
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
        
        private Amazon.S3Tables.Model.StartTableMigrationResponse CallAWSServiceOperation(IAmazonS3Tables client, Amazon.S3Tables.Model.StartTableMigrationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon S3 Tables", "StartTableMigration");
            try
            {
                return client.StartTableMigrationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.S3Tables.IcebergCompactionStrategy DataMigration_MaintenanceSettings_IcebergCompaction_Strategy { get; set; }
            public System.Int32? DataMigration_MaintenanceSettings_IcebergCompaction_TargetFileSizeMB { get; set; }
            public System.Int32? DataMigration_MaintenanceSettings_IcebergSnapshotManagement_MaxSnapshotAgeHour { get; set; }
            public System.Int32? DataMigration_MaintenanceSettings_IcebergSnapshotManagement_MinSnapshotsToKeep { get; set; }
            public Amazon.S3Tables.IncompatibleValuesPolicy DataMigration_MigrationPolicies_IncompatibleValuesPolicy { get; set; }
            public Amazon.S3Tables.UnmatchedSourceFieldsPolicy DataMigration_MigrationPolicies_UnmatchedSourceFieldsPolicy { get; set; }
            public System.String DestinationTable_EncryptionConfiguration_KmsKeyArn { get; set; }
            public Amazon.S3Tables.SSEAlgorithm DestinationTable_EncryptionConfiguration_SseAlgorithm { get; set; }
            public List<Amazon.S3Tables.Model.IcebergSortField> DestinationTable_IcebergSortOrder_Field { get; set; }
            public System.Int32? DestinationTable_IcebergSortOrder_OrderId { get; set; }
            public System.String DestinationTable_Name { get; set; }
            public System.String DestinationTable_Namespace { get; set; }
            public Amazon.S3Tables.CompressionCodec DestinationTable_Properties_CompressionCodec { get; set; }
            public System.Boolean? DestinationTable_Properties_DictionaryEncoding { get; set; }
            public System.Int32? DestinationTable_Properties_IcebergFormatVersion { get; set; }
            public Amazon.S3Tables.DataFileFormat DestinationTable_Properties_WriteFormat { get; set; }
            public List<Amazon.S3Tables.Model.SchemaV2Field> DestinationTable_Schema_Field { get; set; }
            public List<System.Int32> DestinationTable_Schema_IdentifierFieldId { get; set; }
            public System.Int32? DestinationTable_Schema_SchemaId { get; set; }
            public Amazon.S3Tables.SchemaV2FieldType DestinationTable_Schema_Type { get; set; }
            public Amazon.S3Tables.StorageClass DestinationTable_StorageClassConfiguration_StorageClass { get; set; }
            public System.String DestinationTable_TableBucketARN { get; set; }
            public Dictionary<System.String, System.String> DestinationTable_Tag { get; set; }
            public System.String MigrationOutput_Bucket { get; set; }
            public System.String MigrationOutput_Prefixes_ObjectCompatibilityReport { get; set; }
            public System.String MigrationOutput_Prefixes_ObjectMigrationReport { get; set; }
            public System.String MigrationOutput_Prefixes_TableCompatibilityReport { get; set; }
            public System.Boolean? ReviewMigrationPlan { get; set; }
            public System.String RoleARN { get; set; }
            public System.String Source_GlueTable_CatalogId { get; set; }
            public System.String Source_GlueTable_DatabaseName { get; set; }
            public System.String Source_GlueTable_TableName { get; set; }
            public Amazon.S3Tables.MigrationSourceType SourceType { get; set; }
            public System.Func<Amazon.S3Tables.Model.StartTableMigrationResponse, StartS3TTableMigrationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
