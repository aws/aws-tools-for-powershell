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
using Amazon.SageMaker;
using Amazon.SageMaker.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SM
{
    /// <summary>
    /// Create a new <c>FeatureGroup</c>. A <c>FeatureGroup</c> is a group of <c>Features</c>
    /// defined in the <c>FeatureStore</c> to describe a <c>Record</c>. 
    /// 
    ///  
    /// <para>
    /// The <c>FeatureGroup</c> defines the schema and features contained in the <c>FeatureGroup</c>.
    /// A <c>FeatureGroup</c> definition is composed of a list of <c>Features</c>, a <c>RecordIdentifierFeatureName</c>,
    /// an <c>EventTimeFeatureName</c> and configurations for its <c>OnlineStore</c> and <c>OfflineStore</c>.
    /// Check <a href="https://docs.aws.amazon.com/general/latest/gr/aws_service_limits.html">Amazon
    /// Web Services service quotas</a> to see the <c>FeatureGroup</c>s quota for your Amazon
    /// Web Services account.
    /// </para><para>
    /// Note that it can take approximately 10-15 minutes to provision an <c>OnlineStore</c><c>FeatureGroup</c> with the <c>InMemory</c><c>StorageType</c>.
    /// </para><important><para>
    /// You must include at least one of <c>OnlineStoreConfig</c> and <c>OfflineStoreConfig</c>
    /// to create a <c>FeatureGroup</c>.
    /// </para></important>
    /// </summary>
    [Cmdlet("New", "SMFeatureGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service CreateFeatureGroup API operation.", Operation = new[] {"CreateFeatureGroup"}, SelectReturnType = typeof(Amazon.SageMaker.Model.CreateFeatureGroupResponse))]
    [AWSCmdletOutput("System.String or Amazon.SageMaker.Model.CreateFeatureGroupResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SageMaker.Model.CreateFeatureGroupResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewSMFeatureGroupCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DataCatalogConfig_Catalog
        /// <summary>
        /// <para>
        /// <para>The name of the Glue table catalog.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OfflineStoreConfig_DataCatalogConfig_Catalog")]
        public System.String DataCatalogConfig_Catalog { get; set; }
        #endregion
        
        #region Parameter DataCatalogConfig_Database
        /// <summary>
        /// <para>
        /// <para>The name of the Glue table database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OfflineStoreConfig_DataCatalogConfig_Database")]
        public System.String DataCatalogConfig_Database { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A free-form description of a <c>FeatureGroup</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter OfflineStoreConfig_DisableGlueTableCreation
        /// <summary>
        /// <para>
        /// <para>Set to <c>True</c> to disable the automatic creation of an Amazon Web Services Glue
        /// table when configuring an <c>OfflineStore</c>. If set to <c>False</c>, Feature Store
        /// will name the <c>OfflineStore</c> Glue table following <a href="https://docs.aws.amazon.com/athena/latest/ug/tables-databases-columns-names.html">Athena's
        /// naming recommendations</a>.</para><para>The default value is <c>False</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? OfflineStoreConfig_DisableGlueTableCreation { get; set; }
        #endregion
        
        #region Parameter OnlineStoreConfig_EnableOnlineStore
        /// <summary>
        /// <para>
        /// <para>Turn <c>OnlineStore</c> off by specifying <c>False</c> for the <c>EnableOnlineStore</c>
        /// flag. Turn <c>OnlineStore</c> on by specifying <c>True</c> for the <c>EnableOnlineStore</c>
        /// flag. </para><para>The default value is <c>False</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? OnlineStoreConfig_EnableOnlineStore { get; set; }
        #endregion
        
        #region Parameter EventTimeFeatureName
        /// <summary>
        /// <para>
        /// <para>The name of the feature that stores the <c>EventTime</c> of a <c>Record</c> in a <c>FeatureGroup</c>.</para><para>An <c>EventTime</c> is a point in time when a new event occurs that corresponds to
        /// the creation or update of a <c>Record</c> in a <c>FeatureGroup</c>. All <c>Records</c>
        /// in the <c>FeatureGroup</c> must have a corresponding <c>EventTime</c>.</para><para>An <c>EventTime</c> can be a <c>String</c> or <c>Fractional</c>. </para><ul><li><para><c>Fractional</c>: <c>EventTime</c> feature values must be a Unix timestamp in seconds.</para></li><li><para><c>String</c>: <c>EventTime</c> feature values must be an ISO-8601 string in the
        /// format. The following formats are supported <c>yyyy-MM-dd'T'HH:mm:ssZ</c> and <c>yyyy-MM-dd'T'HH:mm:ss.SSSZ</c>
        /// where <c>yyyy</c>, <c>MM</c>, and <c>dd</c> represent the year, month, and day respectively
        /// and <c>HH</c>, <c>mm</c>, <c>ss</c>, and if applicable, <c>SSS</c> represent the hour,
        /// month, second and milliseconds respsectively. <c>'T'</c> and <c>Z</c> are constants.</para></li></ul>
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
        public System.String EventTimeFeatureName { get; set; }
        #endregion
        
        #region Parameter FeatureDefinition
        /// <summary>
        /// <para>
        /// <para>A list of <c>Feature</c> names and types. <c>Name</c> and <c>Type</c> is compulsory
        /// per <c>Feature</c>. </para><para>Valid feature <c>FeatureType</c>s are <c>Integral</c>, <c>Fractional</c> and <c>String</c>.</para><para><c>FeatureName</c>s cannot be any of the following: <c>is_deleted</c>, <c>write_time</c>,
        /// <c>api_invocation_time</c></para><para>You can create up to 2,500 <c>FeatureDefinition</c>s per <c>FeatureGroup</c>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
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
        [Alias("FeatureDefinitions")]
        public Amazon.SageMaker.Model.FeatureDefinition[] FeatureDefinition { get; set; }
        #endregion
        
        #region Parameter FeatureGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the <c>FeatureGroup</c>. The name must be unique within an Amazon Web
        /// Services Region in an Amazon Web Services account.</para><para>The name:</para><ul><li><para>Must start with an alphanumeric character.</para></li><li><para>Can only include alphanumeric characters, underscores, and hyphens. Spaces are not
        /// allowed.</para></li></ul>
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
        public System.String FeatureGroupName { get; set; }
        #endregion
        
        #region Parameter S3StorageConfig_KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services Key Management Service (KMS) key ARN of the key used to encrypt
        /// any objects written into the <c>OfflineStore</c> S3 location.</para><para>The IAM <c>roleARN</c> that is passed as a parameter to <c>CreateFeatureGroup</c>
        /// must have below permissions to the <c>KmsKeyId</c>:</para><ul><li><para><c>"kms:GenerateDataKey"</c></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OfflineStoreConfig_S3StorageConfig_KmsKeyId")]
        public System.String S3StorageConfig_KmsKeyId { get; set; }
        #endregion
        
        #region Parameter SecurityConfig_KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services Key Management Service (KMS) key ARN that SageMaker Feature
        /// Store uses to encrypt the Amazon S3 objects at rest using Amazon S3 server-side encryption.</para><para>The caller (either user or IAM role) of <c>CreateFeatureGroup</c> must have below
        /// permissions to the <c>OnlineStore</c><c>KmsKeyId</c>:</para><ul><li><para><c>"kms:Encrypt"</c></para></li><li><para><c>"kms:Decrypt"</c></para></li><li><para><c>"kms:DescribeKey"</c></para></li><li><para><c>"kms:CreateGrant"</c></para></li><li><para><c>"kms:RetireGrant"</c></para></li><li><para><c>"kms:ReEncryptFrom"</c></para></li><li><para><c>"kms:ReEncryptTo"</c></para></li><li><para><c>"kms:GenerateDataKey"</c></para></li><li><para><c>"kms:ListAliases"</c></para></li><li><para><c>"kms:ListGrants"</c></para></li><li><para><c>"kms:RevokeGrant"</c></para></li></ul><para>The caller (either user or IAM role) to all DataPlane operations (<c>PutRecord</c>,
        /// <c>GetRecord</c>, <c>DeleteRecord</c>) must have the following permissions to the
        /// <c>KmsKeyId</c>:</para><ul><li><para><c>"kms:Decrypt"</c></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OnlineStoreConfig_SecurityConfig_KmsKeyId")]
        public System.String SecurityConfig_KmsKeyId { get; set; }
        #endregion
        
        #region Parameter ThroughputConfig_ProvisionedReadCapacityUnit
        /// <summary>
        /// <para>
        /// <para> For provisioned feature groups with online store enabled, this indicates the read
        /// throughput you are billed for and can consume without throttling. </para><para>This field is not applicable for on-demand feature groups. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ThroughputConfig_ProvisionedReadCapacityUnits")]
        public System.Int32? ThroughputConfig_ProvisionedReadCapacityUnit { get; set; }
        #endregion
        
        #region Parameter ThroughputConfig_ProvisionedWriteCapacityUnit
        /// <summary>
        /// <para>
        /// <para> For provisioned feature groups, this indicates the write throughput you are billed
        /// for and can consume without throttling. </para><para>This field is not applicable for on-demand feature groups. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ThroughputConfig_ProvisionedWriteCapacityUnits")]
        public System.Int32? ThroughputConfig_ProvisionedWriteCapacityUnit { get; set; }
        #endregion
        
        #region Parameter RecordIdentifierFeatureName
        /// <summary>
        /// <para>
        /// <para>The name of the <c>Feature</c> whose value uniquely identifies a <c>Record</c> defined
        /// in the <c>FeatureStore</c>. Only the latest record per identifier value will be stored
        /// in the <c>OnlineStore</c>. <c>RecordIdentifierFeatureName</c> must be one of feature
        /// definitions' names.</para><para>You use the <c>RecordIdentifierFeatureName</c> to access data in a <c>FeatureStore</c>.</para><para>This name:</para><ul><li><para>Must start with an alphanumeric character.</para></li><li><para>Can only contains alphanumeric characters, hyphens, underscores. Spaces are not allowed.
        /// </para></li></ul>
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
        public System.String RecordIdentifierFeatureName { get; set; }
        #endregion
        
        #region Parameter S3StorageConfig_ResolvedOutputS3Uri
        /// <summary>
        /// <para>
        /// <para>The S3 path where offline records are written.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OfflineStoreConfig_S3StorageConfig_ResolvedOutputS3Uri")]
        public System.String S3StorageConfig_ResolvedOutputS3Uri { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM execution role used to persist data into
        /// the <c>OfflineStore</c> if an <c>OfflineStoreConfig</c> is provided.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter S3StorageConfig_S3Uri
        /// <summary>
        /// <para>
        /// <para>The S3 URI, or location in Amazon S3, of <c>OfflineStore</c>.</para><para>S3 URIs have a format similar to the following: <c>s3://example-bucket/prefix/</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OfflineStoreConfig_S3StorageConfig_S3Uri")]
        public System.String S3StorageConfig_S3Uri { get; set; }
        #endregion
        
        #region Parameter OnlineStoreConfig_StorageType
        /// <summary>
        /// <para>
        /// <para>Option for different tiers of low latency storage for real-time data retrieval.</para><ul><li><para><c>Standard</c>: A managed low latency data store for feature groups.</para></li><li><para><c>InMemory</c>: A managed data store for feature groups that supports very low latency
        /// retrieval. </para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.StorageType")]
        public Amazon.SageMaker.StorageType OnlineStoreConfig_StorageType { get; set; }
        #endregion
        
        #region Parameter OfflineStoreConfig_TableFormat
        /// <summary>
        /// <para>
        /// <para>Format for the offline store table. Supported formats are Glue (Default) and <a href="https://iceberg.apache.org/">Apache
        /// Iceberg</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.TableFormat")]
        public Amazon.SageMaker.TableFormat OfflineStoreConfig_TableFormat { get; set; }
        #endregion
        
        #region Parameter DataCatalogConfig_TableName
        /// <summary>
        /// <para>
        /// <para>The name of the Glue table.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OfflineStoreConfig_DataCatalogConfig_TableName")]
        public System.String DataCatalogConfig_TableName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Tags used to identify <c>Features</c> in each <c>FeatureGroup</c>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.SageMaker.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter ThroughputConfig_ThroughputMode
        /// <summary>
        /// <para>
        /// <para>The mode used for your feature group throughput: <c>ON_DEMAND</c> or <c>PROVISIONED</c>.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.ThroughputMode")]
        public Amazon.SageMaker.ThroughputMode ThroughputConfig_ThroughputMode { get; set; }
        #endregion
        
        #region Parameter TtlDuration_Unit
        /// <summary>
        /// <para>
        /// <para><c>TtlDuration</c> time unit.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OnlineStoreConfig_TtlDuration_Unit")]
        [AWSConstantClassSource("Amazon.SageMaker.TtlDurationUnit")]
        public Amazon.SageMaker.TtlDurationUnit TtlDuration_Unit { get; set; }
        #endregion
        
        #region Parameter TtlDuration_Value
        /// <summary>
        /// <para>
        /// <para><c>TtlDuration</c> time value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OnlineStoreConfig_TtlDuration_Value")]
        public System.Int32? TtlDuration_Value { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'FeatureGroupArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.CreateFeatureGroupResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.CreateFeatureGroupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "FeatureGroupArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FeatureGroupName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SMFeatureGroup (CreateFeatureGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.CreateFeatureGroupResponse, NewSMFeatureGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Description = this.Description;
            context.EventTimeFeatureName = this.EventTimeFeatureName;
            #if MODULAR
            if (this.EventTimeFeatureName == null && ParameterWasBound(nameof(this.EventTimeFeatureName)))
            {
                WriteWarning("You are passing $null as a value for parameter EventTimeFeatureName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.FeatureDefinition != null)
            {
                context.FeatureDefinition = new List<Amazon.SageMaker.Model.FeatureDefinition>(this.FeatureDefinition);
            }
            #if MODULAR
            if (this.FeatureDefinition == null && ParameterWasBound(nameof(this.FeatureDefinition)))
            {
                WriteWarning("You are passing $null as a value for parameter FeatureDefinition which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FeatureGroupName = this.FeatureGroupName;
            #if MODULAR
            if (this.FeatureGroupName == null && ParameterWasBound(nameof(this.FeatureGroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter FeatureGroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DataCatalogConfig_Catalog = this.DataCatalogConfig_Catalog;
            context.DataCatalogConfig_Database = this.DataCatalogConfig_Database;
            context.DataCatalogConfig_TableName = this.DataCatalogConfig_TableName;
            context.OfflineStoreConfig_DisableGlueTableCreation = this.OfflineStoreConfig_DisableGlueTableCreation;
            context.S3StorageConfig_KmsKeyId = this.S3StorageConfig_KmsKeyId;
            context.S3StorageConfig_ResolvedOutputS3Uri = this.S3StorageConfig_ResolvedOutputS3Uri;
            context.S3StorageConfig_S3Uri = this.S3StorageConfig_S3Uri;
            context.OfflineStoreConfig_TableFormat = this.OfflineStoreConfig_TableFormat;
            context.OnlineStoreConfig_EnableOnlineStore = this.OnlineStoreConfig_EnableOnlineStore;
            context.SecurityConfig_KmsKeyId = this.SecurityConfig_KmsKeyId;
            context.OnlineStoreConfig_StorageType = this.OnlineStoreConfig_StorageType;
            context.TtlDuration_Unit = this.TtlDuration_Unit;
            context.TtlDuration_Value = this.TtlDuration_Value;
            context.RecordIdentifierFeatureName = this.RecordIdentifierFeatureName;
            #if MODULAR
            if (this.RecordIdentifierFeatureName == null && ParameterWasBound(nameof(this.RecordIdentifierFeatureName)))
            {
                WriteWarning("You are passing $null as a value for parameter RecordIdentifierFeatureName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RoleArn = this.RoleArn;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.SageMaker.Model.Tag>(this.Tag);
            }
            context.ThroughputConfig_ProvisionedReadCapacityUnit = this.ThroughputConfig_ProvisionedReadCapacityUnit;
            context.ThroughputConfig_ProvisionedWriteCapacityUnit = this.ThroughputConfig_ProvisionedWriteCapacityUnit;
            context.ThroughputConfig_ThroughputMode = this.ThroughputConfig_ThroughputMode;
            
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
            var request = new Amazon.SageMaker.Model.CreateFeatureGroupRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.EventTimeFeatureName != null)
            {
                request.EventTimeFeatureName = cmdletContext.EventTimeFeatureName;
            }
            if (cmdletContext.FeatureDefinition != null)
            {
                request.FeatureDefinitions = cmdletContext.FeatureDefinition;
            }
            if (cmdletContext.FeatureGroupName != null)
            {
                request.FeatureGroupName = cmdletContext.FeatureGroupName;
            }
            
             // populate OfflineStoreConfig
            var requestOfflineStoreConfigIsNull = true;
            request.OfflineStoreConfig = new Amazon.SageMaker.Model.OfflineStoreConfig();
            System.Boolean? requestOfflineStoreConfig_offlineStoreConfig_DisableGlueTableCreation = null;
            if (cmdletContext.OfflineStoreConfig_DisableGlueTableCreation != null)
            {
                requestOfflineStoreConfig_offlineStoreConfig_DisableGlueTableCreation = cmdletContext.OfflineStoreConfig_DisableGlueTableCreation.Value;
            }
            if (requestOfflineStoreConfig_offlineStoreConfig_DisableGlueTableCreation != null)
            {
                request.OfflineStoreConfig.DisableGlueTableCreation = requestOfflineStoreConfig_offlineStoreConfig_DisableGlueTableCreation.Value;
                requestOfflineStoreConfigIsNull = false;
            }
            Amazon.SageMaker.TableFormat requestOfflineStoreConfig_offlineStoreConfig_TableFormat = null;
            if (cmdletContext.OfflineStoreConfig_TableFormat != null)
            {
                requestOfflineStoreConfig_offlineStoreConfig_TableFormat = cmdletContext.OfflineStoreConfig_TableFormat;
            }
            if (requestOfflineStoreConfig_offlineStoreConfig_TableFormat != null)
            {
                request.OfflineStoreConfig.TableFormat = requestOfflineStoreConfig_offlineStoreConfig_TableFormat;
                requestOfflineStoreConfigIsNull = false;
            }
            Amazon.SageMaker.Model.DataCatalogConfig requestOfflineStoreConfig_offlineStoreConfig_DataCatalogConfig = null;
            
             // populate DataCatalogConfig
            var requestOfflineStoreConfig_offlineStoreConfig_DataCatalogConfigIsNull = true;
            requestOfflineStoreConfig_offlineStoreConfig_DataCatalogConfig = new Amazon.SageMaker.Model.DataCatalogConfig();
            System.String requestOfflineStoreConfig_offlineStoreConfig_DataCatalogConfig_dataCatalogConfig_Catalog = null;
            if (cmdletContext.DataCatalogConfig_Catalog != null)
            {
                requestOfflineStoreConfig_offlineStoreConfig_DataCatalogConfig_dataCatalogConfig_Catalog = cmdletContext.DataCatalogConfig_Catalog;
            }
            if (requestOfflineStoreConfig_offlineStoreConfig_DataCatalogConfig_dataCatalogConfig_Catalog != null)
            {
                requestOfflineStoreConfig_offlineStoreConfig_DataCatalogConfig.Catalog = requestOfflineStoreConfig_offlineStoreConfig_DataCatalogConfig_dataCatalogConfig_Catalog;
                requestOfflineStoreConfig_offlineStoreConfig_DataCatalogConfigIsNull = false;
            }
            System.String requestOfflineStoreConfig_offlineStoreConfig_DataCatalogConfig_dataCatalogConfig_Database = null;
            if (cmdletContext.DataCatalogConfig_Database != null)
            {
                requestOfflineStoreConfig_offlineStoreConfig_DataCatalogConfig_dataCatalogConfig_Database = cmdletContext.DataCatalogConfig_Database;
            }
            if (requestOfflineStoreConfig_offlineStoreConfig_DataCatalogConfig_dataCatalogConfig_Database != null)
            {
                requestOfflineStoreConfig_offlineStoreConfig_DataCatalogConfig.Database = requestOfflineStoreConfig_offlineStoreConfig_DataCatalogConfig_dataCatalogConfig_Database;
                requestOfflineStoreConfig_offlineStoreConfig_DataCatalogConfigIsNull = false;
            }
            System.String requestOfflineStoreConfig_offlineStoreConfig_DataCatalogConfig_dataCatalogConfig_TableName = null;
            if (cmdletContext.DataCatalogConfig_TableName != null)
            {
                requestOfflineStoreConfig_offlineStoreConfig_DataCatalogConfig_dataCatalogConfig_TableName = cmdletContext.DataCatalogConfig_TableName;
            }
            if (requestOfflineStoreConfig_offlineStoreConfig_DataCatalogConfig_dataCatalogConfig_TableName != null)
            {
                requestOfflineStoreConfig_offlineStoreConfig_DataCatalogConfig.TableName = requestOfflineStoreConfig_offlineStoreConfig_DataCatalogConfig_dataCatalogConfig_TableName;
                requestOfflineStoreConfig_offlineStoreConfig_DataCatalogConfigIsNull = false;
            }
             // determine if requestOfflineStoreConfig_offlineStoreConfig_DataCatalogConfig should be set to null
            if (requestOfflineStoreConfig_offlineStoreConfig_DataCatalogConfigIsNull)
            {
                requestOfflineStoreConfig_offlineStoreConfig_DataCatalogConfig = null;
            }
            if (requestOfflineStoreConfig_offlineStoreConfig_DataCatalogConfig != null)
            {
                request.OfflineStoreConfig.DataCatalogConfig = requestOfflineStoreConfig_offlineStoreConfig_DataCatalogConfig;
                requestOfflineStoreConfigIsNull = false;
            }
            Amazon.SageMaker.Model.S3StorageConfig requestOfflineStoreConfig_offlineStoreConfig_S3StorageConfig = null;
            
             // populate S3StorageConfig
            var requestOfflineStoreConfig_offlineStoreConfig_S3StorageConfigIsNull = true;
            requestOfflineStoreConfig_offlineStoreConfig_S3StorageConfig = new Amazon.SageMaker.Model.S3StorageConfig();
            System.String requestOfflineStoreConfig_offlineStoreConfig_S3StorageConfig_s3StorageConfig_KmsKeyId = null;
            if (cmdletContext.S3StorageConfig_KmsKeyId != null)
            {
                requestOfflineStoreConfig_offlineStoreConfig_S3StorageConfig_s3StorageConfig_KmsKeyId = cmdletContext.S3StorageConfig_KmsKeyId;
            }
            if (requestOfflineStoreConfig_offlineStoreConfig_S3StorageConfig_s3StorageConfig_KmsKeyId != null)
            {
                requestOfflineStoreConfig_offlineStoreConfig_S3StorageConfig.KmsKeyId = requestOfflineStoreConfig_offlineStoreConfig_S3StorageConfig_s3StorageConfig_KmsKeyId;
                requestOfflineStoreConfig_offlineStoreConfig_S3StorageConfigIsNull = false;
            }
            System.String requestOfflineStoreConfig_offlineStoreConfig_S3StorageConfig_s3StorageConfig_ResolvedOutputS3Uri = null;
            if (cmdletContext.S3StorageConfig_ResolvedOutputS3Uri != null)
            {
                requestOfflineStoreConfig_offlineStoreConfig_S3StorageConfig_s3StorageConfig_ResolvedOutputS3Uri = cmdletContext.S3StorageConfig_ResolvedOutputS3Uri;
            }
            if (requestOfflineStoreConfig_offlineStoreConfig_S3StorageConfig_s3StorageConfig_ResolvedOutputS3Uri != null)
            {
                requestOfflineStoreConfig_offlineStoreConfig_S3StorageConfig.ResolvedOutputS3Uri = requestOfflineStoreConfig_offlineStoreConfig_S3StorageConfig_s3StorageConfig_ResolvedOutputS3Uri;
                requestOfflineStoreConfig_offlineStoreConfig_S3StorageConfigIsNull = false;
            }
            System.String requestOfflineStoreConfig_offlineStoreConfig_S3StorageConfig_s3StorageConfig_S3Uri = null;
            if (cmdletContext.S3StorageConfig_S3Uri != null)
            {
                requestOfflineStoreConfig_offlineStoreConfig_S3StorageConfig_s3StorageConfig_S3Uri = cmdletContext.S3StorageConfig_S3Uri;
            }
            if (requestOfflineStoreConfig_offlineStoreConfig_S3StorageConfig_s3StorageConfig_S3Uri != null)
            {
                requestOfflineStoreConfig_offlineStoreConfig_S3StorageConfig.S3Uri = requestOfflineStoreConfig_offlineStoreConfig_S3StorageConfig_s3StorageConfig_S3Uri;
                requestOfflineStoreConfig_offlineStoreConfig_S3StorageConfigIsNull = false;
            }
             // determine if requestOfflineStoreConfig_offlineStoreConfig_S3StorageConfig should be set to null
            if (requestOfflineStoreConfig_offlineStoreConfig_S3StorageConfigIsNull)
            {
                requestOfflineStoreConfig_offlineStoreConfig_S3StorageConfig = null;
            }
            if (requestOfflineStoreConfig_offlineStoreConfig_S3StorageConfig != null)
            {
                request.OfflineStoreConfig.S3StorageConfig = requestOfflineStoreConfig_offlineStoreConfig_S3StorageConfig;
                requestOfflineStoreConfigIsNull = false;
            }
             // determine if request.OfflineStoreConfig should be set to null
            if (requestOfflineStoreConfigIsNull)
            {
                request.OfflineStoreConfig = null;
            }
            
             // populate OnlineStoreConfig
            var requestOnlineStoreConfigIsNull = true;
            request.OnlineStoreConfig = new Amazon.SageMaker.Model.OnlineStoreConfig();
            System.Boolean? requestOnlineStoreConfig_onlineStoreConfig_EnableOnlineStore = null;
            if (cmdletContext.OnlineStoreConfig_EnableOnlineStore != null)
            {
                requestOnlineStoreConfig_onlineStoreConfig_EnableOnlineStore = cmdletContext.OnlineStoreConfig_EnableOnlineStore.Value;
            }
            if (requestOnlineStoreConfig_onlineStoreConfig_EnableOnlineStore != null)
            {
                request.OnlineStoreConfig.EnableOnlineStore = requestOnlineStoreConfig_onlineStoreConfig_EnableOnlineStore.Value;
                requestOnlineStoreConfigIsNull = false;
            }
            Amazon.SageMaker.StorageType requestOnlineStoreConfig_onlineStoreConfig_StorageType = null;
            if (cmdletContext.OnlineStoreConfig_StorageType != null)
            {
                requestOnlineStoreConfig_onlineStoreConfig_StorageType = cmdletContext.OnlineStoreConfig_StorageType;
            }
            if (requestOnlineStoreConfig_onlineStoreConfig_StorageType != null)
            {
                request.OnlineStoreConfig.StorageType = requestOnlineStoreConfig_onlineStoreConfig_StorageType;
                requestOnlineStoreConfigIsNull = false;
            }
            Amazon.SageMaker.Model.OnlineStoreSecurityConfig requestOnlineStoreConfig_onlineStoreConfig_SecurityConfig = null;
            
             // populate SecurityConfig
            var requestOnlineStoreConfig_onlineStoreConfig_SecurityConfigIsNull = true;
            requestOnlineStoreConfig_onlineStoreConfig_SecurityConfig = new Amazon.SageMaker.Model.OnlineStoreSecurityConfig();
            System.String requestOnlineStoreConfig_onlineStoreConfig_SecurityConfig_securityConfig_KmsKeyId = null;
            if (cmdletContext.SecurityConfig_KmsKeyId != null)
            {
                requestOnlineStoreConfig_onlineStoreConfig_SecurityConfig_securityConfig_KmsKeyId = cmdletContext.SecurityConfig_KmsKeyId;
            }
            if (requestOnlineStoreConfig_onlineStoreConfig_SecurityConfig_securityConfig_KmsKeyId != null)
            {
                requestOnlineStoreConfig_onlineStoreConfig_SecurityConfig.KmsKeyId = requestOnlineStoreConfig_onlineStoreConfig_SecurityConfig_securityConfig_KmsKeyId;
                requestOnlineStoreConfig_onlineStoreConfig_SecurityConfigIsNull = false;
            }
             // determine if requestOnlineStoreConfig_onlineStoreConfig_SecurityConfig should be set to null
            if (requestOnlineStoreConfig_onlineStoreConfig_SecurityConfigIsNull)
            {
                requestOnlineStoreConfig_onlineStoreConfig_SecurityConfig = null;
            }
            if (requestOnlineStoreConfig_onlineStoreConfig_SecurityConfig != null)
            {
                request.OnlineStoreConfig.SecurityConfig = requestOnlineStoreConfig_onlineStoreConfig_SecurityConfig;
                requestOnlineStoreConfigIsNull = false;
            }
            Amazon.SageMaker.Model.TtlDuration requestOnlineStoreConfig_onlineStoreConfig_TtlDuration = null;
            
             // populate TtlDuration
            var requestOnlineStoreConfig_onlineStoreConfig_TtlDurationIsNull = true;
            requestOnlineStoreConfig_onlineStoreConfig_TtlDuration = new Amazon.SageMaker.Model.TtlDuration();
            Amazon.SageMaker.TtlDurationUnit requestOnlineStoreConfig_onlineStoreConfig_TtlDuration_ttlDuration_Unit = null;
            if (cmdletContext.TtlDuration_Unit != null)
            {
                requestOnlineStoreConfig_onlineStoreConfig_TtlDuration_ttlDuration_Unit = cmdletContext.TtlDuration_Unit;
            }
            if (requestOnlineStoreConfig_onlineStoreConfig_TtlDuration_ttlDuration_Unit != null)
            {
                requestOnlineStoreConfig_onlineStoreConfig_TtlDuration.Unit = requestOnlineStoreConfig_onlineStoreConfig_TtlDuration_ttlDuration_Unit;
                requestOnlineStoreConfig_onlineStoreConfig_TtlDurationIsNull = false;
            }
            System.Int32? requestOnlineStoreConfig_onlineStoreConfig_TtlDuration_ttlDuration_Value = null;
            if (cmdletContext.TtlDuration_Value != null)
            {
                requestOnlineStoreConfig_onlineStoreConfig_TtlDuration_ttlDuration_Value = cmdletContext.TtlDuration_Value.Value;
            }
            if (requestOnlineStoreConfig_onlineStoreConfig_TtlDuration_ttlDuration_Value != null)
            {
                requestOnlineStoreConfig_onlineStoreConfig_TtlDuration.Value = requestOnlineStoreConfig_onlineStoreConfig_TtlDuration_ttlDuration_Value.Value;
                requestOnlineStoreConfig_onlineStoreConfig_TtlDurationIsNull = false;
            }
             // determine if requestOnlineStoreConfig_onlineStoreConfig_TtlDuration should be set to null
            if (requestOnlineStoreConfig_onlineStoreConfig_TtlDurationIsNull)
            {
                requestOnlineStoreConfig_onlineStoreConfig_TtlDuration = null;
            }
            if (requestOnlineStoreConfig_onlineStoreConfig_TtlDuration != null)
            {
                request.OnlineStoreConfig.TtlDuration = requestOnlineStoreConfig_onlineStoreConfig_TtlDuration;
                requestOnlineStoreConfigIsNull = false;
            }
             // determine if request.OnlineStoreConfig should be set to null
            if (requestOnlineStoreConfigIsNull)
            {
                request.OnlineStoreConfig = null;
            }
            if (cmdletContext.RecordIdentifierFeatureName != null)
            {
                request.RecordIdentifierFeatureName = cmdletContext.RecordIdentifierFeatureName;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
             // populate ThroughputConfig
            var requestThroughputConfigIsNull = true;
            request.ThroughputConfig = new Amazon.SageMaker.Model.ThroughputConfig();
            System.Int32? requestThroughputConfig_throughputConfig_ProvisionedReadCapacityUnit = null;
            if (cmdletContext.ThroughputConfig_ProvisionedReadCapacityUnit != null)
            {
                requestThroughputConfig_throughputConfig_ProvisionedReadCapacityUnit = cmdletContext.ThroughputConfig_ProvisionedReadCapacityUnit.Value;
            }
            if (requestThroughputConfig_throughputConfig_ProvisionedReadCapacityUnit != null)
            {
                request.ThroughputConfig.ProvisionedReadCapacityUnits = requestThroughputConfig_throughputConfig_ProvisionedReadCapacityUnit.Value;
                requestThroughputConfigIsNull = false;
            }
            System.Int32? requestThroughputConfig_throughputConfig_ProvisionedWriteCapacityUnit = null;
            if (cmdletContext.ThroughputConfig_ProvisionedWriteCapacityUnit != null)
            {
                requestThroughputConfig_throughputConfig_ProvisionedWriteCapacityUnit = cmdletContext.ThroughputConfig_ProvisionedWriteCapacityUnit.Value;
            }
            if (requestThroughputConfig_throughputConfig_ProvisionedWriteCapacityUnit != null)
            {
                request.ThroughputConfig.ProvisionedWriteCapacityUnits = requestThroughputConfig_throughputConfig_ProvisionedWriteCapacityUnit.Value;
                requestThroughputConfigIsNull = false;
            }
            Amazon.SageMaker.ThroughputMode requestThroughputConfig_throughputConfig_ThroughputMode = null;
            if (cmdletContext.ThroughputConfig_ThroughputMode != null)
            {
                requestThroughputConfig_throughputConfig_ThroughputMode = cmdletContext.ThroughputConfig_ThroughputMode;
            }
            if (requestThroughputConfig_throughputConfig_ThroughputMode != null)
            {
                request.ThroughputConfig.ThroughputMode = requestThroughputConfig_throughputConfig_ThroughputMode;
                requestThroughputConfigIsNull = false;
            }
             // determine if request.ThroughputConfig should be set to null
            if (requestThroughputConfigIsNull)
            {
                request.ThroughputConfig = null;
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
        
        private Amazon.SageMaker.Model.CreateFeatureGroupResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.CreateFeatureGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "CreateFeatureGroup");
            try
            {
                return client.CreateFeatureGroupAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.String EventTimeFeatureName { get; set; }
            public List<Amazon.SageMaker.Model.FeatureDefinition> FeatureDefinition { get; set; }
            public System.String FeatureGroupName { get; set; }
            public System.String DataCatalogConfig_Catalog { get; set; }
            public System.String DataCatalogConfig_Database { get; set; }
            public System.String DataCatalogConfig_TableName { get; set; }
            public System.Boolean? OfflineStoreConfig_DisableGlueTableCreation { get; set; }
            public System.String S3StorageConfig_KmsKeyId { get; set; }
            public System.String S3StorageConfig_ResolvedOutputS3Uri { get; set; }
            public System.String S3StorageConfig_S3Uri { get; set; }
            public Amazon.SageMaker.TableFormat OfflineStoreConfig_TableFormat { get; set; }
            public System.Boolean? OnlineStoreConfig_EnableOnlineStore { get; set; }
            public System.String SecurityConfig_KmsKeyId { get; set; }
            public Amazon.SageMaker.StorageType OnlineStoreConfig_StorageType { get; set; }
            public Amazon.SageMaker.TtlDurationUnit TtlDuration_Unit { get; set; }
            public System.Int32? TtlDuration_Value { get; set; }
            public System.String RecordIdentifierFeatureName { get; set; }
            public System.String RoleArn { get; set; }
            public List<Amazon.SageMaker.Model.Tag> Tag { get; set; }
            public System.Int32? ThroughputConfig_ProvisionedReadCapacityUnit { get; set; }
            public System.Int32? ThroughputConfig_ProvisionedWriteCapacityUnit { get; set; }
            public Amazon.SageMaker.ThroughputMode ThroughputConfig_ThroughputMode { get; set; }
            public System.Func<Amazon.SageMaker.Model.CreateFeatureGroupResponse, NewSMFeatureGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.FeatureGroupArn;
        }
        
    }
}
