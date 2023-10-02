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
using Amazon.Keyspaces;
using Amazon.Keyspaces.Model;

namespace Amazon.PowerShell.Cmdlets.KS
{
    /// <summary>
    /// The <code>CreateTable</code> operation adds a new table to the specified keyspace.
    /// Within a keyspace, table names must be unique.
    /// 
    ///  
    /// <para><code>CreateTable</code> is an asynchronous operation. When the request is received,
    /// the status of the table is set to <code>CREATING</code>. You can monitor the creation
    /// status of the new table by using the <code>GetTable</code> operation, which returns
    /// the current <code>status</code> of the table. You can start using a table when the
    /// status is <code>ACTIVE</code>.
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/keyspaces/latest/devguide/working-with-tables.html#tables-create">Creating
    /// tables</a> in the <i>Amazon Keyspaces Developer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "KSTable", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Keyspaces CreateTable API operation.", Operation = new[] {"CreateTable"}, SelectReturnType = typeof(Amazon.Keyspaces.Model.CreateTableResponse))]
    [AWSCmdletOutput("System.String or Amazon.Keyspaces.Model.CreateTableResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Keyspaces.Model.CreateTableResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewKSTableCmdlet : AmazonKeyspacesClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter SchemaDefinition_AllColumn
        /// <summary>
        /// <para>
        /// <para>The regular columns of the table.</para>
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
        [Alias("SchemaDefinition_AllColumns")]
        public Amazon.Keyspaces.Model.ColumnDefinition[] SchemaDefinition_AllColumn { get; set; }
        #endregion
        
        #region Parameter SchemaDefinition_ClusteringKey
        /// <summary>
        /// <para>
        /// <para>The columns that are part of the clustering key of the table.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SchemaDefinition_ClusteringKeys")]
        public Amazon.Keyspaces.Model.ClusteringKey[] SchemaDefinition_ClusteringKey { get; set; }
        #endregion
        
        #region Parameter DefaultTimeToLive
        /// <summary>
        /// <para>
        /// <para>The default Time to Live setting in seconds for the table.</para><para>For more information, see <a href="https://docs.aws.amazon.com/keyspaces/latest/devguide/TTL-how-it-works.html#ttl-howitworks_default_ttl">Setting
        /// the default TTL value for a table</a> in the <i>Amazon Keyspaces Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? DefaultTimeToLive { get; set; }
        #endregion
        
        #region Parameter KeyspaceName
        /// <summary>
        /// <para>
        /// <para>The name of the keyspace that the table is going to be created in.</para>
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
        public System.String KeyspaceName { get; set; }
        #endregion
        
        #region Parameter EncryptionSpecification_KmsKeyIdentifier
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the customer managed KMS key, for example <code>kms_key_identifier:ARN</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EncryptionSpecification_KmsKeyIdentifier { get; set; }
        #endregion
        
        #region Parameter Comment_Message
        /// <summary>
        /// <para>
        /// <para>An optional description of the table.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Comment_Message { get; set; }
        #endregion
        
        #region Parameter SchemaDefinition_PartitionKey
        /// <summary>
        /// <para>
        /// <para>The columns that are part of the partition key of the table .</para>
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
        [Alias("SchemaDefinition_PartitionKeys")]
        public Amazon.Keyspaces.Model.PartitionKey[] SchemaDefinition_PartitionKey { get; set; }
        #endregion
        
        #region Parameter CapacitySpecification_ReadCapacityUnit
        /// <summary>
        /// <para>
        /// <para>The throughput capacity specified for <code>read</code> operations defined in <code>read
        /// capacity units</code><code>(RCUs)</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CapacitySpecification_ReadCapacityUnits")]
        public System.Int64? CapacitySpecification_ReadCapacityUnit { get; set; }
        #endregion
        
        #region Parameter SchemaDefinition_StaticColumn
        /// <summary>
        /// <para>
        /// <para>The columns that have been defined as <code>STATIC</code>. Static columns store values
        /// that are shared by all rows in the same partition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SchemaDefinition_StaticColumns")]
        public Amazon.Keyspaces.Model.StaticColumn[] SchemaDefinition_StaticColumn { get; set; }
        #endregion
        
        #region Parameter ClientSideTimestamps_Status
        /// <summary>
        /// <para>
        /// <para>Shows how to enable client-side timestamps settings for the specified table.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Keyspaces.ClientSideTimestampsStatus")]
        public Amazon.Keyspaces.ClientSideTimestampsStatus ClientSideTimestamps_Status { get; set; }
        #endregion
        
        #region Parameter PointInTimeRecovery_Status
        /// <summary>
        /// <para>
        /// <para>The options are:</para><ul><li><para><code>status=ENABLED</code></para></li><li><para><code>status=DISABLED</code></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Keyspaces.PointInTimeRecoveryStatus")]
        public Amazon.Keyspaces.PointInTimeRecoveryStatus PointInTimeRecovery_Status { get; set; }
        #endregion
        
        #region Parameter Ttl_Status
        /// <summary>
        /// <para>
        /// <para>Shows how to enable custom Time to Live (TTL) settings for the specified table.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Keyspaces.TimeToLiveStatus")]
        public Amazon.Keyspaces.TimeToLiveStatus Ttl_Status { get; set; }
        #endregion
        
        #region Parameter TableName
        /// <summary>
        /// <para>
        /// <para>The name of the table.</para>
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
        public System.String TableName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of key-value pair tags to be attached to the resource. </para><para>For more information, see <a href="https://docs.aws.amazon.com/keyspaces/latest/devguide/tagging-keyspaces.html">Adding
        /// tags and labels to Amazon Keyspaces resources</a> in the <i>Amazon Keyspaces Developer
        /// Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.Keyspaces.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter CapacitySpecification_ThroughputMode
        /// <summary>
        /// <para>
        /// <para>The read/write throughput capacity mode for a table. The options are:</para><ul><li><para><code>throughputMode:PAY_PER_REQUEST</code> and </para></li><li><para><code>throughputMode:PROVISIONED</code> - Provisioned capacity mode requires <code>readCapacityUnits</code>
        /// and <code>writeCapacityUnits</code> as input.</para></li></ul><para>The default is <code>throughput_mode:PAY_PER_REQUEST</code>.</para><para>For more information, see <a href="https://docs.aws.amazon.com/keyspaces/latest/devguide/ReadWriteCapacityMode.html">Read/write
        /// capacity modes</a> in the <i>Amazon Keyspaces Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Keyspaces.ThroughputMode")]
        public Amazon.Keyspaces.ThroughputMode CapacitySpecification_ThroughputMode { get; set; }
        #endregion
        
        #region Parameter EncryptionSpecification_Type
        /// <summary>
        /// <para>
        /// <para>The encryption option specified for the table. You can choose one of the following
        /// KMS keys (KMS keys):</para><ul><li><para><code>type:AWS_OWNED_KMS_KEY</code> - This key is owned by Amazon Keyspaces. </para></li><li><para><code>type:CUSTOMER_MANAGED_KMS_KEY</code> - This key is stored in your account and
        /// is created, owned, and managed by you. This option requires the <code>kms_key_identifier</code>
        /// of the KMS key in Amazon Resource Name (ARN) format as input. </para></li></ul><para>The default is <code>type:AWS_OWNED_KMS_KEY</code>. </para><para>For more information, see <a href="https://docs.aws.amazon.com/keyspaces/latest/devguide/EncryptionAtRest.html">Encryption
        /// at rest</a> in the <i>Amazon Keyspaces Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Keyspaces.EncryptionType")]
        public Amazon.Keyspaces.EncryptionType EncryptionSpecification_Type { get; set; }
        #endregion
        
        #region Parameter CapacitySpecification_WriteCapacityUnit
        /// <summary>
        /// <para>
        /// <para>The throughput capacity specified for <code>write</code> operations defined in <code>write
        /// capacity units</code><code>(WCUs)</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CapacitySpecification_WriteCapacityUnits")]
        public System.Int64? CapacitySpecification_WriteCapacityUnit { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ResourceArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Keyspaces.Model.CreateTableResponse).
        /// Specifying the name of a property of type Amazon.Keyspaces.Model.CreateTableResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ResourceArn";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-KSTable (CreateTable)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Keyspaces.Model.CreateTableResponse, NewKSTableCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CapacitySpecification_ReadCapacityUnit = this.CapacitySpecification_ReadCapacityUnit;
            context.CapacitySpecification_ThroughputMode = this.CapacitySpecification_ThroughputMode;
            context.CapacitySpecification_WriteCapacityUnit = this.CapacitySpecification_WriteCapacityUnit;
            context.ClientSideTimestamps_Status = this.ClientSideTimestamps_Status;
            context.Comment_Message = this.Comment_Message;
            context.DefaultTimeToLive = this.DefaultTimeToLive;
            context.EncryptionSpecification_KmsKeyIdentifier = this.EncryptionSpecification_KmsKeyIdentifier;
            context.EncryptionSpecification_Type = this.EncryptionSpecification_Type;
            context.KeyspaceName = this.KeyspaceName;
            #if MODULAR
            if (this.KeyspaceName == null && ParameterWasBound(nameof(this.KeyspaceName)))
            {
                WriteWarning("You are passing $null as a value for parameter KeyspaceName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PointInTimeRecovery_Status = this.PointInTimeRecovery_Status;
            if (this.SchemaDefinition_AllColumn != null)
            {
                context.SchemaDefinition_AllColumn = new List<Amazon.Keyspaces.Model.ColumnDefinition>(this.SchemaDefinition_AllColumn);
            }
            #if MODULAR
            if (this.SchemaDefinition_AllColumn == null && ParameterWasBound(nameof(this.SchemaDefinition_AllColumn)))
            {
                WriteWarning("You are passing $null as a value for parameter SchemaDefinition_AllColumn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.SchemaDefinition_ClusteringKey != null)
            {
                context.SchemaDefinition_ClusteringKey = new List<Amazon.Keyspaces.Model.ClusteringKey>(this.SchemaDefinition_ClusteringKey);
            }
            if (this.SchemaDefinition_PartitionKey != null)
            {
                context.SchemaDefinition_PartitionKey = new List<Amazon.Keyspaces.Model.PartitionKey>(this.SchemaDefinition_PartitionKey);
            }
            #if MODULAR
            if (this.SchemaDefinition_PartitionKey == null && ParameterWasBound(nameof(this.SchemaDefinition_PartitionKey)))
            {
                WriteWarning("You are passing $null as a value for parameter SchemaDefinition_PartitionKey which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.SchemaDefinition_StaticColumn != null)
            {
                context.SchemaDefinition_StaticColumn = new List<Amazon.Keyspaces.Model.StaticColumn>(this.SchemaDefinition_StaticColumn);
            }
            context.TableName = this.TableName;
            #if MODULAR
            if (this.TableName == null && ParameterWasBound(nameof(this.TableName)))
            {
                WriteWarning("You are passing $null as a value for parameter TableName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.Keyspaces.Model.Tag>(this.Tag);
            }
            context.Ttl_Status = this.Ttl_Status;
            
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
            var request = new Amazon.Keyspaces.Model.CreateTableRequest();
            
            
             // populate CapacitySpecification
            var requestCapacitySpecificationIsNull = true;
            request.CapacitySpecification = new Amazon.Keyspaces.Model.CapacitySpecification();
            System.Int64? requestCapacitySpecification_capacitySpecification_ReadCapacityUnit = null;
            if (cmdletContext.CapacitySpecification_ReadCapacityUnit != null)
            {
                requestCapacitySpecification_capacitySpecification_ReadCapacityUnit = cmdletContext.CapacitySpecification_ReadCapacityUnit.Value;
            }
            if (requestCapacitySpecification_capacitySpecification_ReadCapacityUnit != null)
            {
                request.CapacitySpecification.ReadCapacityUnits = requestCapacitySpecification_capacitySpecification_ReadCapacityUnit.Value;
                requestCapacitySpecificationIsNull = false;
            }
            Amazon.Keyspaces.ThroughputMode requestCapacitySpecification_capacitySpecification_ThroughputMode = null;
            if (cmdletContext.CapacitySpecification_ThroughputMode != null)
            {
                requestCapacitySpecification_capacitySpecification_ThroughputMode = cmdletContext.CapacitySpecification_ThroughputMode;
            }
            if (requestCapacitySpecification_capacitySpecification_ThroughputMode != null)
            {
                request.CapacitySpecification.ThroughputMode = requestCapacitySpecification_capacitySpecification_ThroughputMode;
                requestCapacitySpecificationIsNull = false;
            }
            System.Int64? requestCapacitySpecification_capacitySpecification_WriteCapacityUnit = null;
            if (cmdletContext.CapacitySpecification_WriteCapacityUnit != null)
            {
                requestCapacitySpecification_capacitySpecification_WriteCapacityUnit = cmdletContext.CapacitySpecification_WriteCapacityUnit.Value;
            }
            if (requestCapacitySpecification_capacitySpecification_WriteCapacityUnit != null)
            {
                request.CapacitySpecification.WriteCapacityUnits = requestCapacitySpecification_capacitySpecification_WriteCapacityUnit.Value;
                requestCapacitySpecificationIsNull = false;
            }
             // determine if request.CapacitySpecification should be set to null
            if (requestCapacitySpecificationIsNull)
            {
                request.CapacitySpecification = null;
            }
            
             // populate ClientSideTimestamps
            var requestClientSideTimestampsIsNull = true;
            request.ClientSideTimestamps = new Amazon.Keyspaces.Model.ClientSideTimestamps();
            Amazon.Keyspaces.ClientSideTimestampsStatus requestClientSideTimestamps_clientSideTimestamps_Status = null;
            if (cmdletContext.ClientSideTimestamps_Status != null)
            {
                requestClientSideTimestamps_clientSideTimestamps_Status = cmdletContext.ClientSideTimestamps_Status;
            }
            if (requestClientSideTimestamps_clientSideTimestamps_Status != null)
            {
                request.ClientSideTimestamps.Status = requestClientSideTimestamps_clientSideTimestamps_Status;
                requestClientSideTimestampsIsNull = false;
            }
             // determine if request.ClientSideTimestamps should be set to null
            if (requestClientSideTimestampsIsNull)
            {
                request.ClientSideTimestamps = null;
            }
            
             // populate Comment
            var requestCommentIsNull = true;
            request.Comment = new Amazon.Keyspaces.Model.Comment();
            System.String requestComment_comment_Message = null;
            if (cmdletContext.Comment_Message != null)
            {
                requestComment_comment_Message = cmdletContext.Comment_Message;
            }
            if (requestComment_comment_Message != null)
            {
                request.Comment.Message = requestComment_comment_Message;
                requestCommentIsNull = false;
            }
             // determine if request.Comment should be set to null
            if (requestCommentIsNull)
            {
                request.Comment = null;
            }
            if (cmdletContext.DefaultTimeToLive != null)
            {
                request.DefaultTimeToLive = cmdletContext.DefaultTimeToLive.Value;
            }
            
             // populate EncryptionSpecification
            var requestEncryptionSpecificationIsNull = true;
            request.EncryptionSpecification = new Amazon.Keyspaces.Model.EncryptionSpecification();
            System.String requestEncryptionSpecification_encryptionSpecification_KmsKeyIdentifier = null;
            if (cmdletContext.EncryptionSpecification_KmsKeyIdentifier != null)
            {
                requestEncryptionSpecification_encryptionSpecification_KmsKeyIdentifier = cmdletContext.EncryptionSpecification_KmsKeyIdentifier;
            }
            if (requestEncryptionSpecification_encryptionSpecification_KmsKeyIdentifier != null)
            {
                request.EncryptionSpecification.KmsKeyIdentifier = requestEncryptionSpecification_encryptionSpecification_KmsKeyIdentifier;
                requestEncryptionSpecificationIsNull = false;
            }
            Amazon.Keyspaces.EncryptionType requestEncryptionSpecification_encryptionSpecification_Type = null;
            if (cmdletContext.EncryptionSpecification_Type != null)
            {
                requestEncryptionSpecification_encryptionSpecification_Type = cmdletContext.EncryptionSpecification_Type;
            }
            if (requestEncryptionSpecification_encryptionSpecification_Type != null)
            {
                request.EncryptionSpecification.Type = requestEncryptionSpecification_encryptionSpecification_Type;
                requestEncryptionSpecificationIsNull = false;
            }
             // determine if request.EncryptionSpecification should be set to null
            if (requestEncryptionSpecificationIsNull)
            {
                request.EncryptionSpecification = null;
            }
            if (cmdletContext.KeyspaceName != null)
            {
                request.KeyspaceName = cmdletContext.KeyspaceName;
            }
            
             // populate PointInTimeRecovery
            var requestPointInTimeRecoveryIsNull = true;
            request.PointInTimeRecovery = new Amazon.Keyspaces.Model.PointInTimeRecovery();
            Amazon.Keyspaces.PointInTimeRecoveryStatus requestPointInTimeRecovery_pointInTimeRecovery_Status = null;
            if (cmdletContext.PointInTimeRecovery_Status != null)
            {
                requestPointInTimeRecovery_pointInTimeRecovery_Status = cmdletContext.PointInTimeRecovery_Status;
            }
            if (requestPointInTimeRecovery_pointInTimeRecovery_Status != null)
            {
                request.PointInTimeRecovery.Status = requestPointInTimeRecovery_pointInTimeRecovery_Status;
                requestPointInTimeRecoveryIsNull = false;
            }
             // determine if request.PointInTimeRecovery should be set to null
            if (requestPointInTimeRecoveryIsNull)
            {
                request.PointInTimeRecovery = null;
            }
            
             // populate SchemaDefinition
            var requestSchemaDefinitionIsNull = true;
            request.SchemaDefinition = new Amazon.Keyspaces.Model.SchemaDefinition();
            List<Amazon.Keyspaces.Model.ColumnDefinition> requestSchemaDefinition_schemaDefinition_AllColumn = null;
            if (cmdletContext.SchemaDefinition_AllColumn != null)
            {
                requestSchemaDefinition_schemaDefinition_AllColumn = cmdletContext.SchemaDefinition_AllColumn;
            }
            if (requestSchemaDefinition_schemaDefinition_AllColumn != null)
            {
                request.SchemaDefinition.AllColumns = requestSchemaDefinition_schemaDefinition_AllColumn;
                requestSchemaDefinitionIsNull = false;
            }
            List<Amazon.Keyspaces.Model.ClusteringKey> requestSchemaDefinition_schemaDefinition_ClusteringKey = null;
            if (cmdletContext.SchemaDefinition_ClusteringKey != null)
            {
                requestSchemaDefinition_schemaDefinition_ClusteringKey = cmdletContext.SchemaDefinition_ClusteringKey;
            }
            if (requestSchemaDefinition_schemaDefinition_ClusteringKey != null)
            {
                request.SchemaDefinition.ClusteringKeys = requestSchemaDefinition_schemaDefinition_ClusteringKey;
                requestSchemaDefinitionIsNull = false;
            }
            List<Amazon.Keyspaces.Model.PartitionKey> requestSchemaDefinition_schemaDefinition_PartitionKey = null;
            if (cmdletContext.SchemaDefinition_PartitionKey != null)
            {
                requestSchemaDefinition_schemaDefinition_PartitionKey = cmdletContext.SchemaDefinition_PartitionKey;
            }
            if (requestSchemaDefinition_schemaDefinition_PartitionKey != null)
            {
                request.SchemaDefinition.PartitionKeys = requestSchemaDefinition_schemaDefinition_PartitionKey;
                requestSchemaDefinitionIsNull = false;
            }
            List<Amazon.Keyspaces.Model.StaticColumn> requestSchemaDefinition_schemaDefinition_StaticColumn = null;
            if (cmdletContext.SchemaDefinition_StaticColumn != null)
            {
                requestSchemaDefinition_schemaDefinition_StaticColumn = cmdletContext.SchemaDefinition_StaticColumn;
            }
            if (requestSchemaDefinition_schemaDefinition_StaticColumn != null)
            {
                request.SchemaDefinition.StaticColumns = requestSchemaDefinition_schemaDefinition_StaticColumn;
                requestSchemaDefinitionIsNull = false;
            }
             // determine if request.SchemaDefinition should be set to null
            if (requestSchemaDefinitionIsNull)
            {
                request.SchemaDefinition = null;
            }
            if (cmdletContext.TableName != null)
            {
                request.TableName = cmdletContext.TableName;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
             // populate Ttl
            var requestTtlIsNull = true;
            request.Ttl = new Amazon.Keyspaces.Model.TimeToLive();
            Amazon.Keyspaces.TimeToLiveStatus requestTtl_ttl_Status = null;
            if (cmdletContext.Ttl_Status != null)
            {
                requestTtl_ttl_Status = cmdletContext.Ttl_Status;
            }
            if (requestTtl_ttl_Status != null)
            {
                request.Ttl.Status = requestTtl_ttl_Status;
                requestTtlIsNull = false;
            }
             // determine if request.Ttl should be set to null
            if (requestTtlIsNull)
            {
                request.Ttl = null;
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
        
        private Amazon.Keyspaces.Model.CreateTableResponse CallAWSServiceOperation(IAmazonKeyspaces client, Amazon.Keyspaces.Model.CreateTableRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Keyspaces", "CreateTable");
            try
            {
                #if DESKTOP
                return client.CreateTable(request);
                #elif CORECLR
                return client.CreateTableAsync(request).GetAwaiter().GetResult();
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
            public System.Int64? CapacitySpecification_ReadCapacityUnit { get; set; }
            public Amazon.Keyspaces.ThroughputMode CapacitySpecification_ThroughputMode { get; set; }
            public System.Int64? CapacitySpecification_WriteCapacityUnit { get; set; }
            public Amazon.Keyspaces.ClientSideTimestampsStatus ClientSideTimestamps_Status { get; set; }
            public System.String Comment_Message { get; set; }
            public System.Int32? DefaultTimeToLive { get; set; }
            public System.String EncryptionSpecification_KmsKeyIdentifier { get; set; }
            public Amazon.Keyspaces.EncryptionType EncryptionSpecification_Type { get; set; }
            public System.String KeyspaceName { get; set; }
            public Amazon.Keyspaces.PointInTimeRecoveryStatus PointInTimeRecovery_Status { get; set; }
            public List<Amazon.Keyspaces.Model.ColumnDefinition> SchemaDefinition_AllColumn { get; set; }
            public List<Amazon.Keyspaces.Model.ClusteringKey> SchemaDefinition_ClusteringKey { get; set; }
            public List<Amazon.Keyspaces.Model.PartitionKey> SchemaDefinition_PartitionKey { get; set; }
            public List<Amazon.Keyspaces.Model.StaticColumn> SchemaDefinition_StaticColumn { get; set; }
            public System.String TableName { get; set; }
            public List<Amazon.Keyspaces.Model.Tag> Tag { get; set; }
            public Amazon.Keyspaces.TimeToLiveStatus Ttl_Status { get; set; }
            public System.Func<Amazon.Keyspaces.Model.CreateTableResponse, NewKSTableCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ResourceArn;
        }
        
    }
}
