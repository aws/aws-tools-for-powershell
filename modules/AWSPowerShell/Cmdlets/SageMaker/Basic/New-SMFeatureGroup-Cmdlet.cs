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
using Amazon.SageMaker;
using Amazon.SageMaker.Model;

namespace Amazon.PowerShell.Cmdlets.SM
{
    /// <summary>
    /// Create a new <code>FeatureGroup</code>. A <code>FeatureGroup</code> is a group of
    /// <code>Features</code> defined in the <code>FeatureStore</code> to describe a <code>Record</code>.
    /// 
    /// 
    ///  
    /// <para>
    /// The <code>FeatureGroup</code> defines the schema and features contained in the FeatureGroup.
    /// A <code>FeatureGroup</code> definition is composed of a list of <code>Features</code>,
    /// a <code>RecordIdentifierFeatureName</code>, an <code>EventTimeFeatureName</code> and
    /// configurations for its <code>OnlineStore</code> and <code>OfflineStore</code>. Check
    /// <a href="https://docs.aws.amazon.com/general/latest/gr/aws_service_limits.html">Amazon
    /// Web Services service quotas</a> to see the <code>FeatureGroup</code>s quota for your
    /// Amazon Web Services account.
    /// </para><important><para>
    /// You must include at least one of <code>OnlineStoreConfig</code> and <code>OfflineStoreConfig</code>
    /// to create a <code>FeatureGroup</code>.
    /// </para></important>
    /// </summary>
    [Cmdlet("New", "SMFeatureGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service CreateFeatureGroup API operation.", Operation = new[] {"CreateFeatureGroup"}, SelectReturnType = typeof(Amazon.SageMaker.Model.CreateFeatureGroupResponse))]
    [AWSCmdletOutput("System.String or Amazon.SageMaker.Model.CreateFeatureGroupResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SageMaker.Model.CreateFeatureGroupResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewSMFeatureGroupCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
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
        /// <para>A free-form description of a <code>FeatureGroup</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter OfflineStoreConfig_DisableGlueTableCreation
        /// <summary>
        /// <para>
        /// <para>Set to <code>True</code> to disable the automatic creation of an Amazon Web Services
        /// Glue table when configuring an <code>OfflineStore</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? OfflineStoreConfig_DisableGlueTableCreation { get; set; }
        #endregion
        
        #region Parameter OnlineStoreConfig_EnableOnlineStore
        /// <summary>
        /// <para>
        /// <para>Turn <code>OnlineStore</code> off by specifying <code>False</code> for the <code>EnableOnlineStore</code>
        /// flag. Turn <code>OnlineStore</code> on by specifying <code>True</code> for the <code>EnableOnlineStore</code>
        /// flag. </para><para>The default value is <code>False</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? OnlineStoreConfig_EnableOnlineStore { get; set; }
        #endregion
        
        #region Parameter EventTimeFeatureName
        /// <summary>
        /// <para>
        /// <para>The name of the feature that stores the <code>EventTime</code> of a <code>Record</code>
        /// in a <code>FeatureGroup</code>.</para><para>An <code>EventTime</code> is a point in time when a new event occurs that corresponds
        /// to the creation or update of a <code>Record</code> in a <code>FeatureGroup</code>.
        /// All <code>Records</code> in the <code>FeatureGroup</code> must have a corresponding
        /// <code>EventTime</code>.</para><para>An <code>EventTime</code> can be a <code>String</code> or <code>Fractional</code>.
        /// </para><ul><li><para><code>Fractional</code>: <code>EventTime</code> feature values must be a Unix timestamp
        /// in seconds.</para></li><li><para><code>String</code>: <code>EventTime</code> feature values must be an ISO-8601 string
        /// in the format. The following formats are supported <code>yyyy-MM-dd'T'HH:mm:ssZ</code>
        /// and <code>yyyy-MM-dd'T'HH:mm:ss.SSSZ</code> where <code>yyyy</code>, <code>MM</code>,
        /// and <code>dd</code> represent the year, month, and day respectively and <code>HH</code>,
        /// <code>mm</code>, <code>ss</code>, and if applicable, <code>SSS</code> represent the
        /// hour, month, second and milliseconds respsectively. <code>'T'</code> and <code>Z</code>
        /// are constants.</para></li></ul>
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
        /// <para>A list of <code>Feature</code> names and types. <code>Name</code> and <code>Type</code>
        /// is compulsory per <code>Feature</code>. </para><para>Valid feature <code>FeatureType</code>s are <code>Integral</code>, <code>Fractional</code>
        /// and <code>String</code>.</para><para><code>FeatureName</code>s cannot be any of the following: <code>is_deleted</code>,
        /// <code>write_time</code>, <code>api_invocation_time</code></para><para>You can create up to 2,500 <code>FeatureDefinition</code>s per <code>FeatureGroup</code>.</para>
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
        /// <para>The name of the <code>FeatureGroup</code>. The name must be unique within an Amazon
        /// Web Services Region in an Amazon Web Services account. The name:</para><ul><li><para>Must start and end with an alphanumeric character.</para></li><li><para>Can only contain alphanumeric character and hyphens. Spaces are not allowed. </para></li></ul>
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
        /// <para>The Amazon Web Services Key Management Service (KMS) key ID of the key used to encrypt
        /// any objects written into the <code>OfflineStore</code> S3 location.</para><para>The IAM <code>roleARN</code> that is passed as a parameter to <code>CreateFeatureGroup</code>
        /// must have below permissions to the <code>KmsKeyId</code>:</para><ul><li><para><code>"kms:GenerateDataKey"</code></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OfflineStoreConfig_S3StorageConfig_KmsKeyId")]
        public System.String S3StorageConfig_KmsKeyId { get; set; }
        #endregion
        
        #region Parameter SecurityConfig_KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Web Services Key Management Service (Amazon Web Services KMS)
        /// key that SageMaker Feature Store uses to encrypt the Amazon S3 objects at rest using
        /// Amazon S3 server-side encryption.</para><para>The caller (either IAM user or IAM role) of <code>CreateFeatureGroup</code> must have
        /// below permissions to the <code>OnlineStore</code><code>KmsKeyId</code>:</para><ul><li><para><code>"kms:Encrypt"</code></para></li><li><para><code>"kms:Decrypt"</code></para></li><li><para><code>"kms:DescribeKey"</code></para></li><li><para><code>"kms:CreateGrant"</code></para></li><li><para><code>"kms:RetireGrant"</code></para></li><li><para><code>"kms:ReEncryptFrom"</code></para></li><li><para><code>"kms:ReEncryptTo"</code></para></li><li><para><code>"kms:GenerateDataKey"</code></para></li><li><para><code>"kms:ListAliases"</code></para></li><li><para><code>"kms:ListGrants"</code></para></li><li><para><code>"kms:RevokeGrant"</code></para></li></ul><para>The caller (either IAM user or IAM role) to all DataPlane operations (<code>PutRecord</code>,
        /// <code>GetRecord</code>, <code>DeleteRecord</code>) must have the following permissions
        /// to the <code>KmsKeyId</code>:</para><ul><li><para><code>"kms:Decrypt"</code></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OnlineStoreConfig_SecurityConfig_KmsKeyId")]
        public System.String SecurityConfig_KmsKeyId { get; set; }
        #endregion
        
        #region Parameter RecordIdentifierFeatureName
        /// <summary>
        /// <para>
        /// <para>The name of the <code>Feature</code> whose value uniquely identifies a <code>Record</code>
        /// defined in the <code>FeatureStore</code>. Only the latest record per identifier value
        /// will be stored in the <code>OnlineStore</code>. <code>RecordIdentifierFeatureName</code>
        /// must be one of feature definitions' names.</para><para>You use the <code>RecordIdentifierFeatureName</code> to access data in a <code>FeatureStore</code>.</para><para>This name:</para><ul><li><para>Must start and end with an alphanumeric character.</para></li><li><para>Can only contains alphanumeric characters, hyphens, underscores. Spaces are not allowed.
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
        /// the <code>OfflineStore</code> if an <code>OfflineStoreConfig</code> is provided.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter S3StorageConfig_S3Uri
        /// <summary>
        /// <para>
        /// <para>The S3 URI, or location in Amazon S3, of <code>OfflineStore</code>.</para><para>S3 URIs have a format similar to the following: <code>s3://example-bucket/prefix/</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OfflineStoreConfig_S3StorageConfig_S3Uri")]
        public System.String S3StorageConfig_S3Uri { get; set; }
        #endregion
        
        #region Parameter OfflineStoreConfig_TableFormat
        /// <summary>
        /// <para>
        /// <para>Format for the offline store feature group. <code>Iceberg</code> is the optimal format
        /// for feature groups shared between offline and online stores.</para>
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
        /// <para>Tags used to identify <code>Features</code> in each <code>FeatureGroup</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.SageMaker.Model.Tag[] Tag { get; set; }
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
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the FeatureGroupName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^FeatureGroupName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^FeatureGroupName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FeatureGroupName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SMFeatureGroup (CreateFeatureGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.CreateFeatureGroupResponse, NewSMFeatureGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.FeatureGroupName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
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
                #if DESKTOP
                return client.CreateFeatureGroup(request);
                #elif CORECLR
                return client.CreateFeatureGroupAsync(request).GetAwaiter().GetResult();
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
            public System.String RecordIdentifierFeatureName { get; set; }
            public System.String RoleArn { get; set; }
            public List<Amazon.SageMaker.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.SageMaker.Model.CreateFeatureGroupResponse, NewSMFeatureGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.FeatureGroupArn;
        }
        
    }
}
