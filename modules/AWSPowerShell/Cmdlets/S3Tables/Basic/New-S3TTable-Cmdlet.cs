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
    /// Creates a new table associated with the given namespace in a table bucket. For more
    /// information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/s3-tables-create.html">Creating
    /// an Amazon S3 table</a> in the <i>Amazon Simple Storage Service User Guide</i>.
    /// 
    ///  <dl><dt>Permissions</dt><dd><ul><li><para>
    /// You must have the <c>s3tables:CreateTable</c> permission to use this operation. 
    /// </para></li><li><para>
    /// If you use this operation with the optional <c>metadata</c> request parameter you
    /// must have the <c>s3tables:PutTableData</c> permission. 
    /// </para></li><li><para>
    /// If you use this operation with the optional <c>encryptionConfiguration</c> request
    /// parameter you must have the <c>s3tables:PutTableEncryption</c> permission. 
    /// </para></li><li><para>
    /// If you use this operation with the <c>storageClassConfiguration</c> request parameter,
    /// you must have the <c>s3tables:PutTableStorageClass</c> permission.
    /// </para></li><li><para>
    /// To create a table with tags, you must have the <c>s3tables:TagResource</c> permission
    /// in addition to <c>s3tables:CreateTable</c> permission.
    /// </para></li></ul><note><para>
    /// Additionally, If you choose SSE-KMS encryption you must grant the S3 Tables maintenance
    /// principal access to your KMS key. For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/s3-tables-kms-permissions.html">Permissions
    /// requirements for S3 Tables SSE-KMS encryption</a>. 
    /// </para></note></dd></dl>
    /// </summary>
    [Cmdlet("New", "S3TTable", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.S3Tables.Model.CreateTableResponse")]
    [AWSCmdlet("Calls the Amazon S3 Tables CreateTable API operation.", Operation = new[] {"CreateTable"}, SelectReturnType = typeof(Amazon.S3Tables.Model.CreateTableResponse))]
    [AWSCmdletOutput("Amazon.S3Tables.Model.CreateTableResponse",
        "This cmdlet returns an Amazon.S3Tables.Model.CreateTableResponse object containing multiple properties."
    )]
    public partial class NewS3TTableCmdlet : AmazonS3TablesClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Metadata_Iceberg_PartitionSpec_Field
        /// <summary>
        /// <para>
        /// <para>The list of partition fields that define how the table data is partitioned. Each field
        /// specifies a source field and a transform to apply. This field is required if <c>partitionSpec</c>
        /// is provided.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Metadata_Iceberg_PartitionSpec_Fields")]
        public Amazon.S3Tables.Model.IcebergPartitionField[] Metadata_Iceberg_PartitionSpec_Field { get; set; }
        #endregion
        
        #region Parameter Schema_Field
        /// <summary>
        /// <para>
        /// <para>The schema fields for the table</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Metadata_Iceberg_Schema_Fields")]
        public Amazon.S3Tables.Model.SchemaField[] Schema_Field { get; set; }
        #endregion
        
        #region Parameter Metadata_Iceberg_WriteOrder_Field
        /// <summary>
        /// <para>
        /// <para>The list of sort fields that define how data is sorted within files. Each field specifies
        /// a source field, sort direction, and null ordering. This field is required if <c>writeOrder</c>
        /// is provided.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Metadata_Iceberg_WriteOrder_Fields")]
        public Amazon.S3Tables.Model.IcebergSortField[] Metadata_Iceberg_WriteOrder_Field { get; set; }
        #endregion
        
        #region Parameter Format
        /// <summary>
        /// <para>
        /// <para>The format for the table.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.S3Tables.OpenTableFormat")]
        public Amazon.S3Tables.OpenTableFormat Format { get; set; }
        #endregion
        
        #region Parameter EncryptionConfiguration_KmsKeyArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the KMS key to use for encryption. This field is
        /// required only when <c>sseAlgorithm</c> is set to <c>aws:kms</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EncryptionConfiguration_KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name for the table.</para>
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
        
        #region Parameter Namespace
        /// <summary>
        /// <para>
        /// <para>The namespace to associated with the table.</para>
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
        public System.String Namespace { get; set; }
        #endregion
        
        #region Parameter Metadata_Iceberg_WriteOrder_OrderId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for this sort order. If not specified, defaults to <c>1</c>.
        /// The order ID is used by Apache Iceberg to track sort order evolution.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Metadata_Iceberg_WriteOrder_OrderId { get; set; }
        #endregion
        
        #region Parameter Iceberg_Property
        /// <summary>
        /// <para>
        /// <para>A map of custom configuration properties for the Iceberg table.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Metadata_Iceberg_Properties")]
        public System.Collections.Hashtable Iceberg_Property { get; set; }
        #endregion
        
        #region Parameter Metadata_Iceberg_PartitionSpec_SpecId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for this partition specification. If not specified, defaults
        /// to <c>0</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Metadata_Iceberg_PartitionSpec_SpecId { get; set; }
        #endregion
        
        #region Parameter EncryptionConfiguration_SseAlgorithm
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
        public Amazon.S3Tables.SSEAlgorithm EncryptionConfiguration_SseAlgorithm { get; set; }
        #endregion
        
        #region Parameter StorageClassConfiguration_StorageClass
        /// <summary>
        /// <para>
        /// <para>The storage class for the table or table bucket. Valid values include storage classes
        /// optimized for different access patterns and cost profiles.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3Tables.StorageClass")]
        public Amazon.S3Tables.StorageClass StorageClassConfiguration_StorageClass { get; set; }
        #endregion
        
        #region Parameter TableBucketARN
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
        public System.String TableBucketARN { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A map of user-defined tags that you would like to apply to the table that you are
        /// creating. A tag is a key-value pair that you apply to your resources. Tags can help
        /// you organize, track costs for, and control access to resources. For more information,
        /// see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/tagging.html">Tagging
        /// for cost allocation or attribute-based access control (ABAC)</a>.</para><note><para>You must have the <c>s3tables:TagResource</c> permission in addition to <c>s3tables:CreateTable</c>
        /// permission to create a table with tags.</para></note><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3Tables.Model.CreateTableResponse).
        /// Specifying the name of a property of type Amazon.S3Tables.Model.CreateTableResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-S3TTable (CreateTable)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3Tables.Model.CreateTableResponse, NewS3TTableCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.EncryptionConfiguration_KmsKeyArn = this.EncryptionConfiguration_KmsKeyArn;
            context.EncryptionConfiguration_SseAlgorithm = this.EncryptionConfiguration_SseAlgorithm;
            context.Format = this.Format;
            #if MODULAR
            if (this.Format == null && ParameterWasBound(nameof(this.Format)))
            {
                WriteWarning("You are passing $null as a value for parameter Format which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Metadata_Iceberg_PartitionSpec_Field != null)
            {
                context.Metadata_Iceberg_PartitionSpec_Field = new List<Amazon.S3Tables.Model.IcebergPartitionField>(this.Metadata_Iceberg_PartitionSpec_Field);
            }
            context.Metadata_Iceberg_PartitionSpec_SpecId = this.Metadata_Iceberg_PartitionSpec_SpecId;
            if (this.Iceberg_Property != null)
            {
                context.Iceberg_Property = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Iceberg_Property.Keys)
                {
                    context.Iceberg_Property.Add((String)hashKey, (System.String)(this.Iceberg_Property[hashKey]));
                }
            }
            if (this.Schema_Field != null)
            {
                context.Schema_Field = new List<Amazon.S3Tables.Model.SchemaField>(this.Schema_Field);
            }
            if (this.Metadata_Iceberg_WriteOrder_Field != null)
            {
                context.Metadata_Iceberg_WriteOrder_Field = new List<Amazon.S3Tables.Model.IcebergSortField>(this.Metadata_Iceberg_WriteOrder_Field);
            }
            context.Metadata_Iceberg_WriteOrder_OrderId = this.Metadata_Iceberg_WriteOrder_OrderId;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Namespace = this.Namespace;
            #if MODULAR
            if (this.Namespace == null && ParameterWasBound(nameof(this.Namespace)))
            {
                WriteWarning("You are passing $null as a value for parameter Namespace which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StorageClassConfiguration_StorageClass = this.StorageClassConfiguration_StorageClass;
            context.TableBucketARN = this.TableBucketARN;
            #if MODULAR
            if (this.TableBucketARN == null && ParameterWasBound(nameof(this.TableBucketARN)))
            {
                WriteWarning("You are passing $null as a value for parameter TableBucketARN which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.S3Tables.Model.CreateTableRequest();
            
            
             // populate EncryptionConfiguration
            var requestEncryptionConfigurationIsNull = true;
            request.EncryptionConfiguration = new Amazon.S3Tables.Model.EncryptionConfiguration();
            System.String requestEncryptionConfiguration_encryptionConfiguration_KmsKeyArn = null;
            if (cmdletContext.EncryptionConfiguration_KmsKeyArn != null)
            {
                requestEncryptionConfiguration_encryptionConfiguration_KmsKeyArn = cmdletContext.EncryptionConfiguration_KmsKeyArn;
            }
            if (requestEncryptionConfiguration_encryptionConfiguration_KmsKeyArn != null)
            {
                request.EncryptionConfiguration.KmsKeyArn = requestEncryptionConfiguration_encryptionConfiguration_KmsKeyArn;
                requestEncryptionConfigurationIsNull = false;
            }
            Amazon.S3Tables.SSEAlgorithm requestEncryptionConfiguration_encryptionConfiguration_SseAlgorithm = null;
            if (cmdletContext.EncryptionConfiguration_SseAlgorithm != null)
            {
                requestEncryptionConfiguration_encryptionConfiguration_SseAlgorithm = cmdletContext.EncryptionConfiguration_SseAlgorithm;
            }
            if (requestEncryptionConfiguration_encryptionConfiguration_SseAlgorithm != null)
            {
                request.EncryptionConfiguration.SseAlgorithm = requestEncryptionConfiguration_encryptionConfiguration_SseAlgorithm;
                requestEncryptionConfigurationIsNull = false;
            }
             // determine if request.EncryptionConfiguration should be set to null
            if (requestEncryptionConfigurationIsNull)
            {
                request.EncryptionConfiguration = null;
            }
            if (cmdletContext.Format != null)
            {
                request.Format = cmdletContext.Format;
            }
            
             // populate Metadata
            var requestMetadataIsNull = true;
            request.Metadata = new Amazon.S3Tables.Model.TableMetadata();
            Amazon.S3Tables.Model.IcebergMetadata requestMetadata_metadata_Iceberg = null;
            
             // populate Iceberg
            var requestMetadata_metadata_IcebergIsNull = true;
            requestMetadata_metadata_Iceberg = new Amazon.S3Tables.Model.IcebergMetadata();
            Dictionary<System.String, System.String> requestMetadata_metadata_Iceberg_iceberg_Property = null;
            if (cmdletContext.Iceberg_Property != null)
            {
                requestMetadata_metadata_Iceberg_iceberg_Property = cmdletContext.Iceberg_Property;
            }
            if (requestMetadata_metadata_Iceberg_iceberg_Property != null)
            {
                requestMetadata_metadata_Iceberg.Properties = requestMetadata_metadata_Iceberg_iceberg_Property;
                requestMetadata_metadata_IcebergIsNull = false;
            }
            Amazon.S3Tables.Model.IcebergSchema requestMetadata_metadata_Iceberg_metadata_Iceberg_Schema = null;
            
             // populate Schema
            var requestMetadata_metadata_Iceberg_metadata_Iceberg_SchemaIsNull = true;
            requestMetadata_metadata_Iceberg_metadata_Iceberg_Schema = new Amazon.S3Tables.Model.IcebergSchema();
            List<Amazon.S3Tables.Model.SchemaField> requestMetadata_metadata_Iceberg_metadata_Iceberg_Schema_schema_Field = null;
            if (cmdletContext.Schema_Field != null)
            {
                requestMetadata_metadata_Iceberg_metadata_Iceberg_Schema_schema_Field = cmdletContext.Schema_Field;
            }
            if (requestMetadata_metadata_Iceberg_metadata_Iceberg_Schema_schema_Field != null)
            {
                requestMetadata_metadata_Iceberg_metadata_Iceberg_Schema.Fields = requestMetadata_metadata_Iceberg_metadata_Iceberg_Schema_schema_Field;
                requestMetadata_metadata_Iceberg_metadata_Iceberg_SchemaIsNull = false;
            }
             // determine if requestMetadata_metadata_Iceberg_metadata_Iceberg_Schema should be set to null
            if (requestMetadata_metadata_Iceberg_metadata_Iceberg_SchemaIsNull)
            {
                requestMetadata_metadata_Iceberg_metadata_Iceberg_Schema = null;
            }
            if (requestMetadata_metadata_Iceberg_metadata_Iceberg_Schema != null)
            {
                requestMetadata_metadata_Iceberg.Schema = requestMetadata_metadata_Iceberg_metadata_Iceberg_Schema;
                requestMetadata_metadata_IcebergIsNull = false;
            }
            Amazon.S3Tables.Model.IcebergPartitionSpec requestMetadata_metadata_Iceberg_metadata_Iceberg_PartitionSpec = null;
            
             // populate PartitionSpec
            var requestMetadata_metadata_Iceberg_metadata_Iceberg_PartitionSpecIsNull = true;
            requestMetadata_metadata_Iceberg_metadata_Iceberg_PartitionSpec = new Amazon.S3Tables.Model.IcebergPartitionSpec();
            List<Amazon.S3Tables.Model.IcebergPartitionField> requestMetadata_metadata_Iceberg_metadata_Iceberg_PartitionSpec_metadata_Iceberg_PartitionSpec_Field = null;
            if (cmdletContext.Metadata_Iceberg_PartitionSpec_Field != null)
            {
                requestMetadata_metadata_Iceberg_metadata_Iceberg_PartitionSpec_metadata_Iceberg_PartitionSpec_Field = cmdletContext.Metadata_Iceberg_PartitionSpec_Field;
            }
            if (requestMetadata_metadata_Iceberg_metadata_Iceberg_PartitionSpec_metadata_Iceberg_PartitionSpec_Field != null)
            {
                requestMetadata_metadata_Iceberg_metadata_Iceberg_PartitionSpec.Fields = requestMetadata_metadata_Iceberg_metadata_Iceberg_PartitionSpec_metadata_Iceberg_PartitionSpec_Field;
                requestMetadata_metadata_Iceberg_metadata_Iceberg_PartitionSpecIsNull = false;
            }
            System.Int32? requestMetadata_metadata_Iceberg_metadata_Iceberg_PartitionSpec_metadata_Iceberg_PartitionSpec_SpecId = null;
            if (cmdletContext.Metadata_Iceberg_PartitionSpec_SpecId != null)
            {
                requestMetadata_metadata_Iceberg_metadata_Iceberg_PartitionSpec_metadata_Iceberg_PartitionSpec_SpecId = cmdletContext.Metadata_Iceberg_PartitionSpec_SpecId.Value;
            }
            if (requestMetadata_metadata_Iceberg_metadata_Iceberg_PartitionSpec_metadata_Iceberg_PartitionSpec_SpecId != null)
            {
                requestMetadata_metadata_Iceberg_metadata_Iceberg_PartitionSpec.SpecId = requestMetadata_metadata_Iceberg_metadata_Iceberg_PartitionSpec_metadata_Iceberg_PartitionSpec_SpecId.Value;
                requestMetadata_metadata_Iceberg_metadata_Iceberg_PartitionSpecIsNull = false;
            }
             // determine if requestMetadata_metadata_Iceberg_metadata_Iceberg_PartitionSpec should be set to null
            if (requestMetadata_metadata_Iceberg_metadata_Iceberg_PartitionSpecIsNull)
            {
                requestMetadata_metadata_Iceberg_metadata_Iceberg_PartitionSpec = null;
            }
            if (requestMetadata_metadata_Iceberg_metadata_Iceberg_PartitionSpec != null)
            {
                requestMetadata_metadata_Iceberg.PartitionSpec = requestMetadata_metadata_Iceberg_metadata_Iceberg_PartitionSpec;
                requestMetadata_metadata_IcebergIsNull = false;
            }
            Amazon.S3Tables.Model.IcebergSortOrder requestMetadata_metadata_Iceberg_metadata_Iceberg_WriteOrder = null;
            
             // populate WriteOrder
            var requestMetadata_metadata_Iceberg_metadata_Iceberg_WriteOrderIsNull = true;
            requestMetadata_metadata_Iceberg_metadata_Iceberg_WriteOrder = new Amazon.S3Tables.Model.IcebergSortOrder();
            List<Amazon.S3Tables.Model.IcebergSortField> requestMetadata_metadata_Iceberg_metadata_Iceberg_WriteOrder_metadata_Iceberg_WriteOrder_Field = null;
            if (cmdletContext.Metadata_Iceberg_WriteOrder_Field != null)
            {
                requestMetadata_metadata_Iceberg_metadata_Iceberg_WriteOrder_metadata_Iceberg_WriteOrder_Field = cmdletContext.Metadata_Iceberg_WriteOrder_Field;
            }
            if (requestMetadata_metadata_Iceberg_metadata_Iceberg_WriteOrder_metadata_Iceberg_WriteOrder_Field != null)
            {
                requestMetadata_metadata_Iceberg_metadata_Iceberg_WriteOrder.Fields = requestMetadata_metadata_Iceberg_metadata_Iceberg_WriteOrder_metadata_Iceberg_WriteOrder_Field;
                requestMetadata_metadata_Iceberg_metadata_Iceberg_WriteOrderIsNull = false;
            }
            System.Int32? requestMetadata_metadata_Iceberg_metadata_Iceberg_WriteOrder_metadata_Iceberg_WriteOrder_OrderId = null;
            if (cmdletContext.Metadata_Iceberg_WriteOrder_OrderId != null)
            {
                requestMetadata_metadata_Iceberg_metadata_Iceberg_WriteOrder_metadata_Iceberg_WriteOrder_OrderId = cmdletContext.Metadata_Iceberg_WriteOrder_OrderId.Value;
            }
            if (requestMetadata_metadata_Iceberg_metadata_Iceberg_WriteOrder_metadata_Iceberg_WriteOrder_OrderId != null)
            {
                requestMetadata_metadata_Iceberg_metadata_Iceberg_WriteOrder.OrderId = requestMetadata_metadata_Iceberg_metadata_Iceberg_WriteOrder_metadata_Iceberg_WriteOrder_OrderId.Value;
                requestMetadata_metadata_Iceberg_metadata_Iceberg_WriteOrderIsNull = false;
            }
             // determine if requestMetadata_metadata_Iceberg_metadata_Iceberg_WriteOrder should be set to null
            if (requestMetadata_metadata_Iceberg_metadata_Iceberg_WriteOrderIsNull)
            {
                requestMetadata_metadata_Iceberg_metadata_Iceberg_WriteOrder = null;
            }
            if (requestMetadata_metadata_Iceberg_metadata_Iceberg_WriteOrder != null)
            {
                requestMetadata_metadata_Iceberg.WriteOrder = requestMetadata_metadata_Iceberg_metadata_Iceberg_WriteOrder;
                requestMetadata_metadata_IcebergIsNull = false;
            }
             // determine if requestMetadata_metadata_Iceberg should be set to null
            if (requestMetadata_metadata_IcebergIsNull)
            {
                requestMetadata_metadata_Iceberg = null;
            }
            if (requestMetadata_metadata_Iceberg != null)
            {
                request.Metadata.Iceberg = requestMetadata_metadata_Iceberg;
                requestMetadataIsNull = false;
            }
             // determine if request.Metadata should be set to null
            if (requestMetadataIsNull)
            {
                request.Metadata = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Namespace != null)
            {
                request.Namespace = cmdletContext.Namespace;
            }
            
             // populate StorageClassConfiguration
            var requestStorageClassConfigurationIsNull = true;
            request.StorageClassConfiguration = new Amazon.S3Tables.Model.StorageClassConfiguration();
            Amazon.S3Tables.StorageClass requestStorageClassConfiguration_storageClassConfiguration_StorageClass = null;
            if (cmdletContext.StorageClassConfiguration_StorageClass != null)
            {
                requestStorageClassConfiguration_storageClassConfiguration_StorageClass = cmdletContext.StorageClassConfiguration_StorageClass;
            }
            if (requestStorageClassConfiguration_storageClassConfiguration_StorageClass != null)
            {
                request.StorageClassConfiguration.StorageClass = requestStorageClassConfiguration_storageClassConfiguration_StorageClass;
                requestStorageClassConfigurationIsNull = false;
            }
             // determine if request.StorageClassConfiguration should be set to null
            if (requestStorageClassConfigurationIsNull)
            {
                request.StorageClassConfiguration = null;
            }
            if (cmdletContext.TableBucketARN != null)
            {
                request.TableBucketARN = cmdletContext.TableBucketARN;
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
        
        private Amazon.S3Tables.Model.CreateTableResponse CallAWSServiceOperation(IAmazonS3Tables client, Amazon.S3Tables.Model.CreateTableRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon S3 Tables", "CreateTable");
            try
            {
                return client.CreateTableAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String EncryptionConfiguration_KmsKeyArn { get; set; }
            public Amazon.S3Tables.SSEAlgorithm EncryptionConfiguration_SseAlgorithm { get; set; }
            public Amazon.S3Tables.OpenTableFormat Format { get; set; }
            public List<Amazon.S3Tables.Model.IcebergPartitionField> Metadata_Iceberg_PartitionSpec_Field { get; set; }
            public System.Int32? Metadata_Iceberg_PartitionSpec_SpecId { get; set; }
            public Dictionary<System.String, System.String> Iceberg_Property { get; set; }
            public List<Amazon.S3Tables.Model.SchemaField> Schema_Field { get; set; }
            public List<Amazon.S3Tables.Model.IcebergSortField> Metadata_Iceberg_WriteOrder_Field { get; set; }
            public System.Int32? Metadata_Iceberg_WriteOrder_OrderId { get; set; }
            public System.String Name { get; set; }
            public System.String Namespace { get; set; }
            public Amazon.S3Tables.StorageClass StorageClassConfiguration_StorageClass { get; set; }
            public System.String TableBucketARN { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.S3Tables.Model.CreateTableResponse, NewS3TTableCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
