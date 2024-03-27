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
using Amazon.BedrockAgent;
using Amazon.BedrockAgent.Model;

namespace Amazon.PowerShell.Cmdlets.AAB
{
    /// <summary>
    /// Creates a knowledge base that contains data sources from which information can be
    /// queried and used by LLMs. To create a knowledge base, you must first set up your data
    /// sources and configure a supported vector store. For more information, see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/knowledge-base-setup.html">Set
    /// up your data for ingestion</a>.
    /// 
    ///  <note><para>
    /// If you prefer to let Amazon Bedrock create and manage a vector store for you in Amazon
    /// OpenSearch Service, use the console. For more information, see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/knowledge-base-create">Create
    /// a knowledge base</a>.
    /// </para></note><ul><li><para>
    /// Provide the <c>name</c> and an optional <c>description</c>.
    /// </para></li><li><para>
    /// Provide the ARN with permissions to create a knowledge base in the <c>roleArn</c>
    /// field.
    /// </para></li><li><para>
    /// Provide the embedding model to use in the <c>embeddingModelArn</c> field in the <c>knowledgeBaseConfiguration</c>
    /// object.
    /// </para></li><li><para>
    /// Provide the configuration for your vector store in the <c>storageConfiguration</c>
    /// object.
    /// </para><ul><li><para>
    /// For an Amazon OpenSearch Service database, use the <c>opensearchServerlessConfiguration</c>
    /// object. For more information, see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/knowledge-base-setup-oss.html">Create
    /// a vector store in Amazon OpenSearch Service</a>.
    /// </para></li><li><para>
    /// For an Amazon Aurora database, use the <c>RdsConfiguration</c> object. For more information,
    /// see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/knowledge-base-setup-rds.html">Create
    /// a vector store in Amazon Aurora</a>.
    /// </para></li><li><para>
    /// For a Pinecone database, use the <c>pineconeConfiguration</c> object. For more information,
    /// see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/knowledge-base-setup-pinecone.html">Create
    /// a vector store in Pinecone</a>.
    /// </para></li><li><para>
    /// For a Redis Enterprise Cloud database, use the <c>redisEnterpriseCloudConfiguration</c>
    /// object. For more information, see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/knowledge-base-setup-redis.html">Create
    /// a vector store in Redis Enterprise Cloud</a>.
    /// </para></li></ul></li></ul>
    /// </summary>
    [Cmdlet("New", "AABKnowledgeBase", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BedrockAgent.Model.KnowledgeBase")]
    [AWSCmdlet("Calls the Agents for Amazon Bedrock CreateKnowledgeBase API operation.", Operation = new[] {"CreateKnowledgeBase"}, SelectReturnType = typeof(Amazon.BedrockAgent.Model.CreateKnowledgeBaseResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgent.Model.KnowledgeBase or Amazon.BedrockAgent.Model.CreateKnowledgeBaseResponse",
        "This cmdlet returns an Amazon.BedrockAgent.Model.KnowledgeBase object.",
        "The service call response (type Amazon.BedrockAgent.Model.CreateKnowledgeBaseResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewAABKnowledgeBaseCmdlet : AmazonBedrockAgentClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter OpensearchServerlessConfiguration_CollectionArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the OpenSearch Service vector store.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StorageConfiguration_OpensearchServerlessConfiguration_CollectionArn")]
        public System.String OpensearchServerlessConfiguration_CollectionArn { get; set; }
        #endregion
        
        #region Parameter PineconeConfiguration_ConnectionString
        /// <summary>
        /// <para>
        /// <para>The endpoint URL for your index management page.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StorageConfiguration_PineconeConfiguration_ConnectionString")]
        public System.String PineconeConfiguration_ConnectionString { get; set; }
        #endregion
        
        #region Parameter PineconeConfiguration_CredentialsSecretArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the secret that you created in Secrets Manager that is linked to your Pinecone
        /// API key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StorageConfiguration_PineconeConfiguration_CredentialsSecretArn")]
        public System.String PineconeConfiguration_CredentialsSecretArn { get; set; }
        #endregion
        
        #region Parameter RdsConfiguration_CredentialsSecretArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the secret that you created in Secrets Manager that is linked to your Amazon
        /// RDS database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StorageConfiguration_RdsConfiguration_CredentialsSecretArn")]
        public System.String RdsConfiguration_CredentialsSecretArn { get; set; }
        #endregion
        
        #region Parameter RedisEnterpriseCloudConfiguration_CredentialsSecretArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the secret that you created in Secrets Manager that is linked to your Redis
        /// Enterprise Cloud database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StorageConfiguration_RedisEnterpriseCloudConfiguration_CredentialsSecretArn")]
        public System.String RedisEnterpriseCloudConfiguration_CredentialsSecretArn { get; set; }
        #endregion
        
        #region Parameter RdsConfiguration_DatabaseName
        /// <summary>
        /// <para>
        /// <para>The name of your Amazon RDS database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StorageConfiguration_RdsConfiguration_DatabaseName")]
        public System.String RdsConfiguration_DatabaseName { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the knowledge base.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter VectorKnowledgeBaseConfiguration_EmbeddingModelArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the model used to create vector embeddings for the knowledge base.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KnowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_EmbeddingModelArn")]
        public System.String VectorKnowledgeBaseConfiguration_EmbeddingModelArn { get; set; }
        #endregion
        
        #region Parameter RedisEnterpriseCloudConfiguration_Endpoint
        /// <summary>
        /// <para>
        /// <para>The endpoint URL of the Redis Enterprise Cloud database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StorageConfiguration_RedisEnterpriseCloudConfiguration_Endpoint")]
        public System.String RedisEnterpriseCloudConfiguration_Endpoint { get; set; }
        #endregion
        
        #region Parameter StorageConfiguration_OpensearchServerlessConfiguration_FieldMapping_MetadataField
        /// <summary>
        /// <para>
        /// <para>The name of the field in which Amazon Bedrock stores metadata about the vector store.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StorageConfiguration_OpensearchServerlessConfiguration_FieldMapping_MetadataField { get; set; }
        #endregion
        
        #region Parameter StorageConfiguration_PineconeConfiguration_FieldMapping_MetadataField
        /// <summary>
        /// <para>
        /// <para>The name of the field in which Amazon Bedrock stores metadata about the vector store.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StorageConfiguration_PineconeConfiguration_FieldMapping_MetadataField { get; set; }
        #endregion
        
        #region Parameter FieldMapping_MetadataField
        /// <summary>
        /// <para>
        /// <para>The name of the field in which Amazon Bedrock stores metadata about the vector store.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StorageConfiguration_RdsConfiguration_FieldMapping_MetadataField")]
        public System.String FieldMapping_MetadataField { get; set; }
        #endregion
        
        #region Parameter StorageConfiguration_RedisEnterpriseCloudConfiguration_FieldMapping_MetadataField
        /// <summary>
        /// <para>
        /// <para>The name of the field in which Amazon Bedrock stores metadata about the vector store.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StorageConfiguration_RedisEnterpriseCloudConfiguration_FieldMapping_MetadataField { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A name for the knowledge base.</para>
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
        
        #region Parameter PineconeConfiguration_Namespace
        /// <summary>
        /// <para>
        /// <para>The namespace to be used to write new data to your database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StorageConfiguration_PineconeConfiguration_Namespace")]
        public System.String PineconeConfiguration_Namespace { get; set; }
        #endregion
        
        #region Parameter FieldMapping_PrimaryKeyField
        /// <summary>
        /// <para>
        /// <para>The name of the field in which Amazon Bedrock stores the ID for each entry.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StorageConfiguration_RdsConfiguration_FieldMapping_PrimaryKeyField")]
        public System.String FieldMapping_PrimaryKeyField { get; set; }
        #endregion
        
        #region Parameter RdsConfiguration_ResourceArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the vector store.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StorageConfiguration_RdsConfiguration_ResourceArn")]
        public System.String RdsConfiguration_ResourceArn { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role with permissions to create the knowledge base.</para>
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
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter RdsConfiguration_TableName
        /// <summary>
        /// <para>
        /// <para>The name of the table in the database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StorageConfiguration_RdsConfiguration_TableName")]
        public System.String RdsConfiguration_TableName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Specify the key-value pairs for the tags that you want to attach to your knowledge
        /// base in this object.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter StorageConfiguration_OpensearchServerlessConfiguration_FieldMapping_TextField
        /// <summary>
        /// <para>
        /// <para>The name of the field in which Amazon Bedrock stores the raw text from your data.
        /// The text is split according to the chunking strategy you choose.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StorageConfiguration_OpensearchServerlessConfiguration_FieldMapping_TextField { get; set; }
        #endregion
        
        #region Parameter StorageConfiguration_PineconeConfiguration_FieldMapping_TextField
        /// <summary>
        /// <para>
        /// <para>The name of the field in which Amazon Bedrock stores the raw text from your data.
        /// The text is split according to the chunking strategy you choose.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StorageConfiguration_PineconeConfiguration_FieldMapping_TextField { get; set; }
        #endregion
        
        #region Parameter FieldMapping_TextField
        /// <summary>
        /// <para>
        /// <para>The name of the field in which Amazon Bedrock stores the raw text from your data.
        /// The text is split according to the chunking strategy you choose.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StorageConfiguration_RdsConfiguration_FieldMapping_TextField")]
        public System.String FieldMapping_TextField { get; set; }
        #endregion
        
        #region Parameter StorageConfiguration_RedisEnterpriseCloudConfiguration_FieldMapping_TextField
        /// <summary>
        /// <para>
        /// <para>The name of the field in which Amazon Bedrock stores the raw text from your data.
        /// The text is split according to the chunking strategy you choose.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StorageConfiguration_RedisEnterpriseCloudConfiguration_FieldMapping_TextField { get; set; }
        #endregion
        
        #region Parameter KnowledgeBaseConfiguration_Type
        /// <summary>
        /// <para>
        /// <para>The type of data that the data source is converted into for the knowledge base.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.BedrockAgent.KnowledgeBaseType")]
        public Amazon.BedrockAgent.KnowledgeBaseType KnowledgeBaseConfiguration_Type { get; set; }
        #endregion
        
        #region Parameter StorageConfiguration_Type
        /// <summary>
        /// <para>
        /// <para>The vector store service in which the knowledge base is stored.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.BedrockAgent.KnowledgeBaseStorageType")]
        public Amazon.BedrockAgent.KnowledgeBaseStorageType StorageConfiguration_Type { get; set; }
        #endregion
        
        #region Parameter StorageConfiguration_OpensearchServerlessConfiguration_FieldMapping_VectorField
        /// <summary>
        /// <para>
        /// <para>The name of the field in which Amazon Bedrock stores the vector embeddings for your
        /// data sources.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StorageConfiguration_OpensearchServerlessConfiguration_FieldMapping_VectorField { get; set; }
        #endregion
        
        #region Parameter FieldMapping_VectorField
        /// <summary>
        /// <para>
        /// <para>The name of the field in which Amazon Bedrock stores the vector embeddings for your
        /// data sources.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StorageConfiguration_RdsConfiguration_FieldMapping_VectorField")]
        public System.String FieldMapping_VectorField { get; set; }
        #endregion
        
        #region Parameter StorageConfiguration_RedisEnterpriseCloudConfiguration_FieldMapping_VectorField
        /// <summary>
        /// <para>
        /// <para>The name of the field in which Amazon Bedrock stores the vector embeddings for your
        /// data sources.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StorageConfiguration_RedisEnterpriseCloudConfiguration_FieldMapping_VectorField { get; set; }
        #endregion
        
        #region Parameter OpensearchServerlessConfiguration_VectorIndexName
        /// <summary>
        /// <para>
        /// <para>The name of the vector store.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StorageConfiguration_OpensearchServerlessConfiguration_VectorIndexName")]
        public System.String OpensearchServerlessConfiguration_VectorIndexName { get; set; }
        #endregion
        
        #region Parameter RedisEnterpriseCloudConfiguration_VectorIndexName
        /// <summary>
        /// <para>
        /// <para>The name of the vector index.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StorageConfiguration_RedisEnterpriseCloudConfiguration_VectorIndexName")]
        public System.String RedisEnterpriseCloudConfiguration_VectorIndexName { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier to ensure that the API request completes no more
        /// than one time. If this token matches a previous request, Amazon Bedrock ignores the
        /// request, but does not return an error. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/Run_Instance_Idempotency.html">Ensuring
        /// idempotency</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'KnowledgeBase'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgent.Model.CreateKnowledgeBaseResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgent.Model.CreateKnowledgeBaseResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "KnowledgeBase";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-AABKnowledgeBase (CreateKnowledgeBase)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgent.Model.CreateKnowledgeBaseResponse, NewAABKnowledgeBaseCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.KnowledgeBaseConfiguration_Type = this.KnowledgeBaseConfiguration_Type;
            #if MODULAR
            if (this.KnowledgeBaseConfiguration_Type == null && ParameterWasBound(nameof(this.KnowledgeBaseConfiguration_Type)))
            {
                WriteWarning("You are passing $null as a value for parameter KnowledgeBaseConfiguration_Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VectorKnowledgeBaseConfiguration_EmbeddingModelArn = this.VectorKnowledgeBaseConfiguration_EmbeddingModelArn;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RoleArn = this.RoleArn;
            #if MODULAR
            if (this.RoleArn == null && ParameterWasBound(nameof(this.RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OpensearchServerlessConfiguration_CollectionArn = this.OpensearchServerlessConfiguration_CollectionArn;
            context.StorageConfiguration_OpensearchServerlessConfiguration_FieldMapping_MetadataField = this.StorageConfiguration_OpensearchServerlessConfiguration_FieldMapping_MetadataField;
            context.StorageConfiguration_OpensearchServerlessConfiguration_FieldMapping_TextField = this.StorageConfiguration_OpensearchServerlessConfiguration_FieldMapping_TextField;
            context.StorageConfiguration_OpensearchServerlessConfiguration_FieldMapping_VectorField = this.StorageConfiguration_OpensearchServerlessConfiguration_FieldMapping_VectorField;
            context.OpensearchServerlessConfiguration_VectorIndexName = this.OpensearchServerlessConfiguration_VectorIndexName;
            context.PineconeConfiguration_ConnectionString = this.PineconeConfiguration_ConnectionString;
            context.PineconeConfiguration_CredentialsSecretArn = this.PineconeConfiguration_CredentialsSecretArn;
            context.StorageConfiguration_PineconeConfiguration_FieldMapping_MetadataField = this.StorageConfiguration_PineconeConfiguration_FieldMapping_MetadataField;
            context.StorageConfiguration_PineconeConfiguration_FieldMapping_TextField = this.StorageConfiguration_PineconeConfiguration_FieldMapping_TextField;
            context.PineconeConfiguration_Namespace = this.PineconeConfiguration_Namespace;
            context.RdsConfiguration_CredentialsSecretArn = this.RdsConfiguration_CredentialsSecretArn;
            context.RdsConfiguration_DatabaseName = this.RdsConfiguration_DatabaseName;
            context.FieldMapping_MetadataField = this.FieldMapping_MetadataField;
            context.FieldMapping_PrimaryKeyField = this.FieldMapping_PrimaryKeyField;
            context.FieldMapping_TextField = this.FieldMapping_TextField;
            context.FieldMapping_VectorField = this.FieldMapping_VectorField;
            context.RdsConfiguration_ResourceArn = this.RdsConfiguration_ResourceArn;
            context.RdsConfiguration_TableName = this.RdsConfiguration_TableName;
            context.RedisEnterpriseCloudConfiguration_CredentialsSecretArn = this.RedisEnterpriseCloudConfiguration_CredentialsSecretArn;
            context.RedisEnterpriseCloudConfiguration_Endpoint = this.RedisEnterpriseCloudConfiguration_Endpoint;
            context.StorageConfiguration_RedisEnterpriseCloudConfiguration_FieldMapping_MetadataField = this.StorageConfiguration_RedisEnterpriseCloudConfiguration_FieldMapping_MetadataField;
            context.StorageConfiguration_RedisEnterpriseCloudConfiguration_FieldMapping_TextField = this.StorageConfiguration_RedisEnterpriseCloudConfiguration_FieldMapping_TextField;
            context.StorageConfiguration_RedisEnterpriseCloudConfiguration_FieldMapping_VectorField = this.StorageConfiguration_RedisEnterpriseCloudConfiguration_FieldMapping_VectorField;
            context.RedisEnterpriseCloudConfiguration_VectorIndexName = this.RedisEnterpriseCloudConfiguration_VectorIndexName;
            context.StorageConfiguration_Type = this.StorageConfiguration_Type;
            #if MODULAR
            if (this.StorageConfiguration_Type == null && ParameterWasBound(nameof(this.StorageConfiguration_Type)))
            {
                WriteWarning("You are passing $null as a value for parameter StorageConfiguration_Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.BedrockAgent.Model.CreateKnowledgeBaseRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            
             // populate KnowledgeBaseConfiguration
            var requestKnowledgeBaseConfigurationIsNull = true;
            request.KnowledgeBaseConfiguration = new Amazon.BedrockAgent.Model.KnowledgeBaseConfiguration();
            Amazon.BedrockAgent.KnowledgeBaseType requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_Type = null;
            if (cmdletContext.KnowledgeBaseConfiguration_Type != null)
            {
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_Type = cmdletContext.KnowledgeBaseConfiguration_Type;
            }
            if (requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_Type != null)
            {
                request.KnowledgeBaseConfiguration.Type = requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_Type;
                requestKnowledgeBaseConfigurationIsNull = false;
            }
            Amazon.BedrockAgent.Model.VectorKnowledgeBaseConfiguration requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration = null;
            
             // populate VectorKnowledgeBaseConfiguration
            var requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfigurationIsNull = true;
            requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration = new Amazon.BedrockAgent.Model.VectorKnowledgeBaseConfiguration();
            System.String requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_vectorKnowledgeBaseConfiguration_EmbeddingModelArn = null;
            if (cmdletContext.VectorKnowledgeBaseConfiguration_EmbeddingModelArn != null)
            {
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_vectorKnowledgeBaseConfiguration_EmbeddingModelArn = cmdletContext.VectorKnowledgeBaseConfiguration_EmbeddingModelArn;
            }
            if (requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_vectorKnowledgeBaseConfiguration_EmbeddingModelArn != null)
            {
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration.EmbeddingModelArn = requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_vectorKnowledgeBaseConfiguration_EmbeddingModelArn;
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfigurationIsNull = false;
            }
             // determine if requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration should be set to null
            if (requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfigurationIsNull)
            {
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration = null;
            }
            if (requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration != null)
            {
                request.KnowledgeBaseConfiguration.VectorKnowledgeBaseConfiguration = requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration;
                requestKnowledgeBaseConfigurationIsNull = false;
            }
             // determine if request.KnowledgeBaseConfiguration should be set to null
            if (requestKnowledgeBaseConfigurationIsNull)
            {
                request.KnowledgeBaseConfiguration = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            
             // populate StorageConfiguration
            var requestStorageConfigurationIsNull = true;
            request.StorageConfiguration = new Amazon.BedrockAgent.Model.StorageConfiguration();
            Amazon.BedrockAgent.KnowledgeBaseStorageType requestStorageConfiguration_storageConfiguration_Type = null;
            if (cmdletContext.StorageConfiguration_Type != null)
            {
                requestStorageConfiguration_storageConfiguration_Type = cmdletContext.StorageConfiguration_Type;
            }
            if (requestStorageConfiguration_storageConfiguration_Type != null)
            {
                request.StorageConfiguration.Type = requestStorageConfiguration_storageConfiguration_Type;
                requestStorageConfigurationIsNull = false;
            }
            Amazon.BedrockAgent.Model.OpenSearchServerlessConfiguration requestStorageConfiguration_storageConfiguration_OpensearchServerlessConfiguration = null;
            
             // populate OpensearchServerlessConfiguration
            var requestStorageConfiguration_storageConfiguration_OpensearchServerlessConfigurationIsNull = true;
            requestStorageConfiguration_storageConfiguration_OpensearchServerlessConfiguration = new Amazon.BedrockAgent.Model.OpenSearchServerlessConfiguration();
            System.String requestStorageConfiguration_storageConfiguration_OpensearchServerlessConfiguration_opensearchServerlessConfiguration_CollectionArn = null;
            if (cmdletContext.OpensearchServerlessConfiguration_CollectionArn != null)
            {
                requestStorageConfiguration_storageConfiguration_OpensearchServerlessConfiguration_opensearchServerlessConfiguration_CollectionArn = cmdletContext.OpensearchServerlessConfiguration_CollectionArn;
            }
            if (requestStorageConfiguration_storageConfiguration_OpensearchServerlessConfiguration_opensearchServerlessConfiguration_CollectionArn != null)
            {
                requestStorageConfiguration_storageConfiguration_OpensearchServerlessConfiguration.CollectionArn = requestStorageConfiguration_storageConfiguration_OpensearchServerlessConfiguration_opensearchServerlessConfiguration_CollectionArn;
                requestStorageConfiguration_storageConfiguration_OpensearchServerlessConfigurationIsNull = false;
            }
            System.String requestStorageConfiguration_storageConfiguration_OpensearchServerlessConfiguration_opensearchServerlessConfiguration_VectorIndexName = null;
            if (cmdletContext.OpensearchServerlessConfiguration_VectorIndexName != null)
            {
                requestStorageConfiguration_storageConfiguration_OpensearchServerlessConfiguration_opensearchServerlessConfiguration_VectorIndexName = cmdletContext.OpensearchServerlessConfiguration_VectorIndexName;
            }
            if (requestStorageConfiguration_storageConfiguration_OpensearchServerlessConfiguration_opensearchServerlessConfiguration_VectorIndexName != null)
            {
                requestStorageConfiguration_storageConfiguration_OpensearchServerlessConfiguration.VectorIndexName = requestStorageConfiguration_storageConfiguration_OpensearchServerlessConfiguration_opensearchServerlessConfiguration_VectorIndexName;
                requestStorageConfiguration_storageConfiguration_OpensearchServerlessConfigurationIsNull = false;
            }
            Amazon.BedrockAgent.Model.OpenSearchServerlessFieldMapping requestStorageConfiguration_storageConfiguration_OpensearchServerlessConfiguration_storageConfiguration_OpensearchServerlessConfiguration_FieldMapping = null;
            
             // populate FieldMapping
            var requestStorageConfiguration_storageConfiguration_OpensearchServerlessConfiguration_storageConfiguration_OpensearchServerlessConfiguration_FieldMappingIsNull = true;
            requestStorageConfiguration_storageConfiguration_OpensearchServerlessConfiguration_storageConfiguration_OpensearchServerlessConfiguration_FieldMapping = new Amazon.BedrockAgent.Model.OpenSearchServerlessFieldMapping();
            System.String requestStorageConfiguration_storageConfiguration_OpensearchServerlessConfiguration_storageConfiguration_OpensearchServerlessConfiguration_FieldMapping_storageConfiguration_OpensearchServerlessConfiguration_FieldMapping_MetadataField = null;
            if (cmdletContext.StorageConfiguration_OpensearchServerlessConfiguration_FieldMapping_MetadataField != null)
            {
                requestStorageConfiguration_storageConfiguration_OpensearchServerlessConfiguration_storageConfiguration_OpensearchServerlessConfiguration_FieldMapping_storageConfiguration_OpensearchServerlessConfiguration_FieldMapping_MetadataField = cmdletContext.StorageConfiguration_OpensearchServerlessConfiguration_FieldMapping_MetadataField;
            }
            if (requestStorageConfiguration_storageConfiguration_OpensearchServerlessConfiguration_storageConfiguration_OpensearchServerlessConfiguration_FieldMapping_storageConfiguration_OpensearchServerlessConfiguration_FieldMapping_MetadataField != null)
            {
                requestStorageConfiguration_storageConfiguration_OpensearchServerlessConfiguration_storageConfiguration_OpensearchServerlessConfiguration_FieldMapping.MetadataField = requestStorageConfiguration_storageConfiguration_OpensearchServerlessConfiguration_storageConfiguration_OpensearchServerlessConfiguration_FieldMapping_storageConfiguration_OpensearchServerlessConfiguration_FieldMapping_MetadataField;
                requestStorageConfiguration_storageConfiguration_OpensearchServerlessConfiguration_storageConfiguration_OpensearchServerlessConfiguration_FieldMappingIsNull = false;
            }
            System.String requestStorageConfiguration_storageConfiguration_OpensearchServerlessConfiguration_storageConfiguration_OpensearchServerlessConfiguration_FieldMapping_storageConfiguration_OpensearchServerlessConfiguration_FieldMapping_TextField = null;
            if (cmdletContext.StorageConfiguration_OpensearchServerlessConfiguration_FieldMapping_TextField != null)
            {
                requestStorageConfiguration_storageConfiguration_OpensearchServerlessConfiguration_storageConfiguration_OpensearchServerlessConfiguration_FieldMapping_storageConfiguration_OpensearchServerlessConfiguration_FieldMapping_TextField = cmdletContext.StorageConfiguration_OpensearchServerlessConfiguration_FieldMapping_TextField;
            }
            if (requestStorageConfiguration_storageConfiguration_OpensearchServerlessConfiguration_storageConfiguration_OpensearchServerlessConfiguration_FieldMapping_storageConfiguration_OpensearchServerlessConfiguration_FieldMapping_TextField != null)
            {
                requestStorageConfiguration_storageConfiguration_OpensearchServerlessConfiguration_storageConfiguration_OpensearchServerlessConfiguration_FieldMapping.TextField = requestStorageConfiguration_storageConfiguration_OpensearchServerlessConfiguration_storageConfiguration_OpensearchServerlessConfiguration_FieldMapping_storageConfiguration_OpensearchServerlessConfiguration_FieldMapping_TextField;
                requestStorageConfiguration_storageConfiguration_OpensearchServerlessConfiguration_storageConfiguration_OpensearchServerlessConfiguration_FieldMappingIsNull = false;
            }
            System.String requestStorageConfiguration_storageConfiguration_OpensearchServerlessConfiguration_storageConfiguration_OpensearchServerlessConfiguration_FieldMapping_storageConfiguration_OpensearchServerlessConfiguration_FieldMapping_VectorField = null;
            if (cmdletContext.StorageConfiguration_OpensearchServerlessConfiguration_FieldMapping_VectorField != null)
            {
                requestStorageConfiguration_storageConfiguration_OpensearchServerlessConfiguration_storageConfiguration_OpensearchServerlessConfiguration_FieldMapping_storageConfiguration_OpensearchServerlessConfiguration_FieldMapping_VectorField = cmdletContext.StorageConfiguration_OpensearchServerlessConfiguration_FieldMapping_VectorField;
            }
            if (requestStorageConfiguration_storageConfiguration_OpensearchServerlessConfiguration_storageConfiguration_OpensearchServerlessConfiguration_FieldMapping_storageConfiguration_OpensearchServerlessConfiguration_FieldMapping_VectorField != null)
            {
                requestStorageConfiguration_storageConfiguration_OpensearchServerlessConfiguration_storageConfiguration_OpensearchServerlessConfiguration_FieldMapping.VectorField = requestStorageConfiguration_storageConfiguration_OpensearchServerlessConfiguration_storageConfiguration_OpensearchServerlessConfiguration_FieldMapping_storageConfiguration_OpensearchServerlessConfiguration_FieldMapping_VectorField;
                requestStorageConfiguration_storageConfiguration_OpensearchServerlessConfiguration_storageConfiguration_OpensearchServerlessConfiguration_FieldMappingIsNull = false;
            }
             // determine if requestStorageConfiguration_storageConfiguration_OpensearchServerlessConfiguration_storageConfiguration_OpensearchServerlessConfiguration_FieldMapping should be set to null
            if (requestStorageConfiguration_storageConfiguration_OpensearchServerlessConfiguration_storageConfiguration_OpensearchServerlessConfiguration_FieldMappingIsNull)
            {
                requestStorageConfiguration_storageConfiguration_OpensearchServerlessConfiguration_storageConfiguration_OpensearchServerlessConfiguration_FieldMapping = null;
            }
            if (requestStorageConfiguration_storageConfiguration_OpensearchServerlessConfiguration_storageConfiguration_OpensearchServerlessConfiguration_FieldMapping != null)
            {
                requestStorageConfiguration_storageConfiguration_OpensearchServerlessConfiguration.FieldMapping = requestStorageConfiguration_storageConfiguration_OpensearchServerlessConfiguration_storageConfiguration_OpensearchServerlessConfiguration_FieldMapping;
                requestStorageConfiguration_storageConfiguration_OpensearchServerlessConfigurationIsNull = false;
            }
             // determine if requestStorageConfiguration_storageConfiguration_OpensearchServerlessConfiguration should be set to null
            if (requestStorageConfiguration_storageConfiguration_OpensearchServerlessConfigurationIsNull)
            {
                requestStorageConfiguration_storageConfiguration_OpensearchServerlessConfiguration = null;
            }
            if (requestStorageConfiguration_storageConfiguration_OpensearchServerlessConfiguration != null)
            {
                request.StorageConfiguration.OpensearchServerlessConfiguration = requestStorageConfiguration_storageConfiguration_OpensearchServerlessConfiguration;
                requestStorageConfigurationIsNull = false;
            }
            Amazon.BedrockAgent.Model.PineconeConfiguration requestStorageConfiguration_storageConfiguration_PineconeConfiguration = null;
            
             // populate PineconeConfiguration
            var requestStorageConfiguration_storageConfiguration_PineconeConfigurationIsNull = true;
            requestStorageConfiguration_storageConfiguration_PineconeConfiguration = new Amazon.BedrockAgent.Model.PineconeConfiguration();
            System.String requestStorageConfiguration_storageConfiguration_PineconeConfiguration_pineconeConfiguration_ConnectionString = null;
            if (cmdletContext.PineconeConfiguration_ConnectionString != null)
            {
                requestStorageConfiguration_storageConfiguration_PineconeConfiguration_pineconeConfiguration_ConnectionString = cmdletContext.PineconeConfiguration_ConnectionString;
            }
            if (requestStorageConfiguration_storageConfiguration_PineconeConfiguration_pineconeConfiguration_ConnectionString != null)
            {
                requestStorageConfiguration_storageConfiguration_PineconeConfiguration.ConnectionString = requestStorageConfiguration_storageConfiguration_PineconeConfiguration_pineconeConfiguration_ConnectionString;
                requestStorageConfiguration_storageConfiguration_PineconeConfigurationIsNull = false;
            }
            System.String requestStorageConfiguration_storageConfiguration_PineconeConfiguration_pineconeConfiguration_CredentialsSecretArn = null;
            if (cmdletContext.PineconeConfiguration_CredentialsSecretArn != null)
            {
                requestStorageConfiguration_storageConfiguration_PineconeConfiguration_pineconeConfiguration_CredentialsSecretArn = cmdletContext.PineconeConfiguration_CredentialsSecretArn;
            }
            if (requestStorageConfiguration_storageConfiguration_PineconeConfiguration_pineconeConfiguration_CredentialsSecretArn != null)
            {
                requestStorageConfiguration_storageConfiguration_PineconeConfiguration.CredentialsSecretArn = requestStorageConfiguration_storageConfiguration_PineconeConfiguration_pineconeConfiguration_CredentialsSecretArn;
                requestStorageConfiguration_storageConfiguration_PineconeConfigurationIsNull = false;
            }
            System.String requestStorageConfiguration_storageConfiguration_PineconeConfiguration_pineconeConfiguration_Namespace = null;
            if (cmdletContext.PineconeConfiguration_Namespace != null)
            {
                requestStorageConfiguration_storageConfiguration_PineconeConfiguration_pineconeConfiguration_Namespace = cmdletContext.PineconeConfiguration_Namespace;
            }
            if (requestStorageConfiguration_storageConfiguration_PineconeConfiguration_pineconeConfiguration_Namespace != null)
            {
                requestStorageConfiguration_storageConfiguration_PineconeConfiguration.Namespace = requestStorageConfiguration_storageConfiguration_PineconeConfiguration_pineconeConfiguration_Namespace;
                requestStorageConfiguration_storageConfiguration_PineconeConfigurationIsNull = false;
            }
            Amazon.BedrockAgent.Model.PineconeFieldMapping requestStorageConfiguration_storageConfiguration_PineconeConfiguration_storageConfiguration_PineconeConfiguration_FieldMapping = null;
            
             // populate FieldMapping
            var requestStorageConfiguration_storageConfiguration_PineconeConfiguration_storageConfiguration_PineconeConfiguration_FieldMappingIsNull = true;
            requestStorageConfiguration_storageConfiguration_PineconeConfiguration_storageConfiguration_PineconeConfiguration_FieldMapping = new Amazon.BedrockAgent.Model.PineconeFieldMapping();
            System.String requestStorageConfiguration_storageConfiguration_PineconeConfiguration_storageConfiguration_PineconeConfiguration_FieldMapping_storageConfiguration_PineconeConfiguration_FieldMapping_MetadataField = null;
            if (cmdletContext.StorageConfiguration_PineconeConfiguration_FieldMapping_MetadataField != null)
            {
                requestStorageConfiguration_storageConfiguration_PineconeConfiguration_storageConfiguration_PineconeConfiguration_FieldMapping_storageConfiguration_PineconeConfiguration_FieldMapping_MetadataField = cmdletContext.StorageConfiguration_PineconeConfiguration_FieldMapping_MetadataField;
            }
            if (requestStorageConfiguration_storageConfiguration_PineconeConfiguration_storageConfiguration_PineconeConfiguration_FieldMapping_storageConfiguration_PineconeConfiguration_FieldMapping_MetadataField != null)
            {
                requestStorageConfiguration_storageConfiguration_PineconeConfiguration_storageConfiguration_PineconeConfiguration_FieldMapping.MetadataField = requestStorageConfiguration_storageConfiguration_PineconeConfiguration_storageConfiguration_PineconeConfiguration_FieldMapping_storageConfiguration_PineconeConfiguration_FieldMapping_MetadataField;
                requestStorageConfiguration_storageConfiguration_PineconeConfiguration_storageConfiguration_PineconeConfiguration_FieldMappingIsNull = false;
            }
            System.String requestStorageConfiguration_storageConfiguration_PineconeConfiguration_storageConfiguration_PineconeConfiguration_FieldMapping_storageConfiguration_PineconeConfiguration_FieldMapping_TextField = null;
            if (cmdletContext.StorageConfiguration_PineconeConfiguration_FieldMapping_TextField != null)
            {
                requestStorageConfiguration_storageConfiguration_PineconeConfiguration_storageConfiguration_PineconeConfiguration_FieldMapping_storageConfiguration_PineconeConfiguration_FieldMapping_TextField = cmdletContext.StorageConfiguration_PineconeConfiguration_FieldMapping_TextField;
            }
            if (requestStorageConfiguration_storageConfiguration_PineconeConfiguration_storageConfiguration_PineconeConfiguration_FieldMapping_storageConfiguration_PineconeConfiguration_FieldMapping_TextField != null)
            {
                requestStorageConfiguration_storageConfiguration_PineconeConfiguration_storageConfiguration_PineconeConfiguration_FieldMapping.TextField = requestStorageConfiguration_storageConfiguration_PineconeConfiguration_storageConfiguration_PineconeConfiguration_FieldMapping_storageConfiguration_PineconeConfiguration_FieldMapping_TextField;
                requestStorageConfiguration_storageConfiguration_PineconeConfiguration_storageConfiguration_PineconeConfiguration_FieldMappingIsNull = false;
            }
             // determine if requestStorageConfiguration_storageConfiguration_PineconeConfiguration_storageConfiguration_PineconeConfiguration_FieldMapping should be set to null
            if (requestStorageConfiguration_storageConfiguration_PineconeConfiguration_storageConfiguration_PineconeConfiguration_FieldMappingIsNull)
            {
                requestStorageConfiguration_storageConfiguration_PineconeConfiguration_storageConfiguration_PineconeConfiguration_FieldMapping = null;
            }
            if (requestStorageConfiguration_storageConfiguration_PineconeConfiguration_storageConfiguration_PineconeConfiguration_FieldMapping != null)
            {
                requestStorageConfiguration_storageConfiguration_PineconeConfiguration.FieldMapping = requestStorageConfiguration_storageConfiguration_PineconeConfiguration_storageConfiguration_PineconeConfiguration_FieldMapping;
                requestStorageConfiguration_storageConfiguration_PineconeConfigurationIsNull = false;
            }
             // determine if requestStorageConfiguration_storageConfiguration_PineconeConfiguration should be set to null
            if (requestStorageConfiguration_storageConfiguration_PineconeConfigurationIsNull)
            {
                requestStorageConfiguration_storageConfiguration_PineconeConfiguration = null;
            }
            if (requestStorageConfiguration_storageConfiguration_PineconeConfiguration != null)
            {
                request.StorageConfiguration.PineconeConfiguration = requestStorageConfiguration_storageConfiguration_PineconeConfiguration;
                requestStorageConfigurationIsNull = false;
            }
            Amazon.BedrockAgent.Model.RedisEnterpriseCloudConfiguration requestStorageConfiguration_storageConfiguration_RedisEnterpriseCloudConfiguration = null;
            
             // populate RedisEnterpriseCloudConfiguration
            var requestStorageConfiguration_storageConfiguration_RedisEnterpriseCloudConfigurationIsNull = true;
            requestStorageConfiguration_storageConfiguration_RedisEnterpriseCloudConfiguration = new Amazon.BedrockAgent.Model.RedisEnterpriseCloudConfiguration();
            System.String requestStorageConfiguration_storageConfiguration_RedisEnterpriseCloudConfiguration_redisEnterpriseCloudConfiguration_CredentialsSecretArn = null;
            if (cmdletContext.RedisEnterpriseCloudConfiguration_CredentialsSecretArn != null)
            {
                requestStorageConfiguration_storageConfiguration_RedisEnterpriseCloudConfiguration_redisEnterpriseCloudConfiguration_CredentialsSecretArn = cmdletContext.RedisEnterpriseCloudConfiguration_CredentialsSecretArn;
            }
            if (requestStorageConfiguration_storageConfiguration_RedisEnterpriseCloudConfiguration_redisEnterpriseCloudConfiguration_CredentialsSecretArn != null)
            {
                requestStorageConfiguration_storageConfiguration_RedisEnterpriseCloudConfiguration.CredentialsSecretArn = requestStorageConfiguration_storageConfiguration_RedisEnterpriseCloudConfiguration_redisEnterpriseCloudConfiguration_CredentialsSecretArn;
                requestStorageConfiguration_storageConfiguration_RedisEnterpriseCloudConfigurationIsNull = false;
            }
            System.String requestStorageConfiguration_storageConfiguration_RedisEnterpriseCloudConfiguration_redisEnterpriseCloudConfiguration_Endpoint = null;
            if (cmdletContext.RedisEnterpriseCloudConfiguration_Endpoint != null)
            {
                requestStorageConfiguration_storageConfiguration_RedisEnterpriseCloudConfiguration_redisEnterpriseCloudConfiguration_Endpoint = cmdletContext.RedisEnterpriseCloudConfiguration_Endpoint;
            }
            if (requestStorageConfiguration_storageConfiguration_RedisEnterpriseCloudConfiguration_redisEnterpriseCloudConfiguration_Endpoint != null)
            {
                requestStorageConfiguration_storageConfiguration_RedisEnterpriseCloudConfiguration.Endpoint = requestStorageConfiguration_storageConfiguration_RedisEnterpriseCloudConfiguration_redisEnterpriseCloudConfiguration_Endpoint;
                requestStorageConfiguration_storageConfiguration_RedisEnterpriseCloudConfigurationIsNull = false;
            }
            System.String requestStorageConfiguration_storageConfiguration_RedisEnterpriseCloudConfiguration_redisEnterpriseCloudConfiguration_VectorIndexName = null;
            if (cmdletContext.RedisEnterpriseCloudConfiguration_VectorIndexName != null)
            {
                requestStorageConfiguration_storageConfiguration_RedisEnterpriseCloudConfiguration_redisEnterpriseCloudConfiguration_VectorIndexName = cmdletContext.RedisEnterpriseCloudConfiguration_VectorIndexName;
            }
            if (requestStorageConfiguration_storageConfiguration_RedisEnterpriseCloudConfiguration_redisEnterpriseCloudConfiguration_VectorIndexName != null)
            {
                requestStorageConfiguration_storageConfiguration_RedisEnterpriseCloudConfiguration.VectorIndexName = requestStorageConfiguration_storageConfiguration_RedisEnterpriseCloudConfiguration_redisEnterpriseCloudConfiguration_VectorIndexName;
                requestStorageConfiguration_storageConfiguration_RedisEnterpriseCloudConfigurationIsNull = false;
            }
            Amazon.BedrockAgent.Model.RedisEnterpriseCloudFieldMapping requestStorageConfiguration_storageConfiguration_RedisEnterpriseCloudConfiguration_storageConfiguration_RedisEnterpriseCloudConfiguration_FieldMapping = null;
            
             // populate FieldMapping
            var requestStorageConfiguration_storageConfiguration_RedisEnterpriseCloudConfiguration_storageConfiguration_RedisEnterpriseCloudConfiguration_FieldMappingIsNull = true;
            requestStorageConfiguration_storageConfiguration_RedisEnterpriseCloudConfiguration_storageConfiguration_RedisEnterpriseCloudConfiguration_FieldMapping = new Amazon.BedrockAgent.Model.RedisEnterpriseCloudFieldMapping();
            System.String requestStorageConfiguration_storageConfiguration_RedisEnterpriseCloudConfiguration_storageConfiguration_RedisEnterpriseCloudConfiguration_FieldMapping_storageConfiguration_RedisEnterpriseCloudConfiguration_FieldMapping_MetadataField = null;
            if (cmdletContext.StorageConfiguration_RedisEnterpriseCloudConfiguration_FieldMapping_MetadataField != null)
            {
                requestStorageConfiguration_storageConfiguration_RedisEnterpriseCloudConfiguration_storageConfiguration_RedisEnterpriseCloudConfiguration_FieldMapping_storageConfiguration_RedisEnterpriseCloudConfiguration_FieldMapping_MetadataField = cmdletContext.StorageConfiguration_RedisEnterpriseCloudConfiguration_FieldMapping_MetadataField;
            }
            if (requestStorageConfiguration_storageConfiguration_RedisEnterpriseCloudConfiguration_storageConfiguration_RedisEnterpriseCloudConfiguration_FieldMapping_storageConfiguration_RedisEnterpriseCloudConfiguration_FieldMapping_MetadataField != null)
            {
                requestStorageConfiguration_storageConfiguration_RedisEnterpriseCloudConfiguration_storageConfiguration_RedisEnterpriseCloudConfiguration_FieldMapping.MetadataField = requestStorageConfiguration_storageConfiguration_RedisEnterpriseCloudConfiguration_storageConfiguration_RedisEnterpriseCloudConfiguration_FieldMapping_storageConfiguration_RedisEnterpriseCloudConfiguration_FieldMapping_MetadataField;
                requestStorageConfiguration_storageConfiguration_RedisEnterpriseCloudConfiguration_storageConfiguration_RedisEnterpriseCloudConfiguration_FieldMappingIsNull = false;
            }
            System.String requestStorageConfiguration_storageConfiguration_RedisEnterpriseCloudConfiguration_storageConfiguration_RedisEnterpriseCloudConfiguration_FieldMapping_storageConfiguration_RedisEnterpriseCloudConfiguration_FieldMapping_TextField = null;
            if (cmdletContext.StorageConfiguration_RedisEnterpriseCloudConfiguration_FieldMapping_TextField != null)
            {
                requestStorageConfiguration_storageConfiguration_RedisEnterpriseCloudConfiguration_storageConfiguration_RedisEnterpriseCloudConfiguration_FieldMapping_storageConfiguration_RedisEnterpriseCloudConfiguration_FieldMapping_TextField = cmdletContext.StorageConfiguration_RedisEnterpriseCloudConfiguration_FieldMapping_TextField;
            }
            if (requestStorageConfiguration_storageConfiguration_RedisEnterpriseCloudConfiguration_storageConfiguration_RedisEnterpriseCloudConfiguration_FieldMapping_storageConfiguration_RedisEnterpriseCloudConfiguration_FieldMapping_TextField != null)
            {
                requestStorageConfiguration_storageConfiguration_RedisEnterpriseCloudConfiguration_storageConfiguration_RedisEnterpriseCloudConfiguration_FieldMapping.TextField = requestStorageConfiguration_storageConfiguration_RedisEnterpriseCloudConfiguration_storageConfiguration_RedisEnterpriseCloudConfiguration_FieldMapping_storageConfiguration_RedisEnterpriseCloudConfiguration_FieldMapping_TextField;
                requestStorageConfiguration_storageConfiguration_RedisEnterpriseCloudConfiguration_storageConfiguration_RedisEnterpriseCloudConfiguration_FieldMappingIsNull = false;
            }
            System.String requestStorageConfiguration_storageConfiguration_RedisEnterpriseCloudConfiguration_storageConfiguration_RedisEnterpriseCloudConfiguration_FieldMapping_storageConfiguration_RedisEnterpriseCloudConfiguration_FieldMapping_VectorField = null;
            if (cmdletContext.StorageConfiguration_RedisEnterpriseCloudConfiguration_FieldMapping_VectorField != null)
            {
                requestStorageConfiguration_storageConfiguration_RedisEnterpriseCloudConfiguration_storageConfiguration_RedisEnterpriseCloudConfiguration_FieldMapping_storageConfiguration_RedisEnterpriseCloudConfiguration_FieldMapping_VectorField = cmdletContext.StorageConfiguration_RedisEnterpriseCloudConfiguration_FieldMapping_VectorField;
            }
            if (requestStorageConfiguration_storageConfiguration_RedisEnterpriseCloudConfiguration_storageConfiguration_RedisEnterpriseCloudConfiguration_FieldMapping_storageConfiguration_RedisEnterpriseCloudConfiguration_FieldMapping_VectorField != null)
            {
                requestStorageConfiguration_storageConfiguration_RedisEnterpriseCloudConfiguration_storageConfiguration_RedisEnterpriseCloudConfiguration_FieldMapping.VectorField = requestStorageConfiguration_storageConfiguration_RedisEnterpriseCloudConfiguration_storageConfiguration_RedisEnterpriseCloudConfiguration_FieldMapping_storageConfiguration_RedisEnterpriseCloudConfiguration_FieldMapping_VectorField;
                requestStorageConfiguration_storageConfiguration_RedisEnterpriseCloudConfiguration_storageConfiguration_RedisEnterpriseCloudConfiguration_FieldMappingIsNull = false;
            }
             // determine if requestStorageConfiguration_storageConfiguration_RedisEnterpriseCloudConfiguration_storageConfiguration_RedisEnterpriseCloudConfiguration_FieldMapping should be set to null
            if (requestStorageConfiguration_storageConfiguration_RedisEnterpriseCloudConfiguration_storageConfiguration_RedisEnterpriseCloudConfiguration_FieldMappingIsNull)
            {
                requestStorageConfiguration_storageConfiguration_RedisEnterpriseCloudConfiguration_storageConfiguration_RedisEnterpriseCloudConfiguration_FieldMapping = null;
            }
            if (requestStorageConfiguration_storageConfiguration_RedisEnterpriseCloudConfiguration_storageConfiguration_RedisEnterpriseCloudConfiguration_FieldMapping != null)
            {
                requestStorageConfiguration_storageConfiguration_RedisEnterpriseCloudConfiguration.FieldMapping = requestStorageConfiguration_storageConfiguration_RedisEnterpriseCloudConfiguration_storageConfiguration_RedisEnterpriseCloudConfiguration_FieldMapping;
                requestStorageConfiguration_storageConfiguration_RedisEnterpriseCloudConfigurationIsNull = false;
            }
             // determine if requestStorageConfiguration_storageConfiguration_RedisEnterpriseCloudConfiguration should be set to null
            if (requestStorageConfiguration_storageConfiguration_RedisEnterpriseCloudConfigurationIsNull)
            {
                requestStorageConfiguration_storageConfiguration_RedisEnterpriseCloudConfiguration = null;
            }
            if (requestStorageConfiguration_storageConfiguration_RedisEnterpriseCloudConfiguration != null)
            {
                request.StorageConfiguration.RedisEnterpriseCloudConfiguration = requestStorageConfiguration_storageConfiguration_RedisEnterpriseCloudConfiguration;
                requestStorageConfigurationIsNull = false;
            }
            Amazon.BedrockAgent.Model.RdsConfiguration requestStorageConfiguration_storageConfiguration_RdsConfiguration = null;
            
             // populate RdsConfiguration
            var requestStorageConfiguration_storageConfiguration_RdsConfigurationIsNull = true;
            requestStorageConfiguration_storageConfiguration_RdsConfiguration = new Amazon.BedrockAgent.Model.RdsConfiguration();
            System.String requestStorageConfiguration_storageConfiguration_RdsConfiguration_rdsConfiguration_CredentialsSecretArn = null;
            if (cmdletContext.RdsConfiguration_CredentialsSecretArn != null)
            {
                requestStorageConfiguration_storageConfiguration_RdsConfiguration_rdsConfiguration_CredentialsSecretArn = cmdletContext.RdsConfiguration_CredentialsSecretArn;
            }
            if (requestStorageConfiguration_storageConfiguration_RdsConfiguration_rdsConfiguration_CredentialsSecretArn != null)
            {
                requestStorageConfiguration_storageConfiguration_RdsConfiguration.CredentialsSecretArn = requestStorageConfiguration_storageConfiguration_RdsConfiguration_rdsConfiguration_CredentialsSecretArn;
                requestStorageConfiguration_storageConfiguration_RdsConfigurationIsNull = false;
            }
            System.String requestStorageConfiguration_storageConfiguration_RdsConfiguration_rdsConfiguration_DatabaseName = null;
            if (cmdletContext.RdsConfiguration_DatabaseName != null)
            {
                requestStorageConfiguration_storageConfiguration_RdsConfiguration_rdsConfiguration_DatabaseName = cmdletContext.RdsConfiguration_DatabaseName;
            }
            if (requestStorageConfiguration_storageConfiguration_RdsConfiguration_rdsConfiguration_DatabaseName != null)
            {
                requestStorageConfiguration_storageConfiguration_RdsConfiguration.DatabaseName = requestStorageConfiguration_storageConfiguration_RdsConfiguration_rdsConfiguration_DatabaseName;
                requestStorageConfiguration_storageConfiguration_RdsConfigurationIsNull = false;
            }
            System.String requestStorageConfiguration_storageConfiguration_RdsConfiguration_rdsConfiguration_ResourceArn = null;
            if (cmdletContext.RdsConfiguration_ResourceArn != null)
            {
                requestStorageConfiguration_storageConfiguration_RdsConfiguration_rdsConfiguration_ResourceArn = cmdletContext.RdsConfiguration_ResourceArn;
            }
            if (requestStorageConfiguration_storageConfiguration_RdsConfiguration_rdsConfiguration_ResourceArn != null)
            {
                requestStorageConfiguration_storageConfiguration_RdsConfiguration.ResourceArn = requestStorageConfiguration_storageConfiguration_RdsConfiguration_rdsConfiguration_ResourceArn;
                requestStorageConfiguration_storageConfiguration_RdsConfigurationIsNull = false;
            }
            System.String requestStorageConfiguration_storageConfiguration_RdsConfiguration_rdsConfiguration_TableName = null;
            if (cmdletContext.RdsConfiguration_TableName != null)
            {
                requestStorageConfiguration_storageConfiguration_RdsConfiguration_rdsConfiguration_TableName = cmdletContext.RdsConfiguration_TableName;
            }
            if (requestStorageConfiguration_storageConfiguration_RdsConfiguration_rdsConfiguration_TableName != null)
            {
                requestStorageConfiguration_storageConfiguration_RdsConfiguration.TableName = requestStorageConfiguration_storageConfiguration_RdsConfiguration_rdsConfiguration_TableName;
                requestStorageConfiguration_storageConfiguration_RdsConfigurationIsNull = false;
            }
            Amazon.BedrockAgent.Model.RdsFieldMapping requestStorageConfiguration_storageConfiguration_RdsConfiguration_storageConfiguration_RdsConfiguration_FieldMapping = null;
            
             // populate FieldMapping
            var requestStorageConfiguration_storageConfiguration_RdsConfiguration_storageConfiguration_RdsConfiguration_FieldMappingIsNull = true;
            requestStorageConfiguration_storageConfiguration_RdsConfiguration_storageConfiguration_RdsConfiguration_FieldMapping = new Amazon.BedrockAgent.Model.RdsFieldMapping();
            System.String requestStorageConfiguration_storageConfiguration_RdsConfiguration_storageConfiguration_RdsConfiguration_FieldMapping_fieldMapping_MetadataField = null;
            if (cmdletContext.FieldMapping_MetadataField != null)
            {
                requestStorageConfiguration_storageConfiguration_RdsConfiguration_storageConfiguration_RdsConfiguration_FieldMapping_fieldMapping_MetadataField = cmdletContext.FieldMapping_MetadataField;
            }
            if (requestStorageConfiguration_storageConfiguration_RdsConfiguration_storageConfiguration_RdsConfiguration_FieldMapping_fieldMapping_MetadataField != null)
            {
                requestStorageConfiguration_storageConfiguration_RdsConfiguration_storageConfiguration_RdsConfiguration_FieldMapping.MetadataField = requestStorageConfiguration_storageConfiguration_RdsConfiguration_storageConfiguration_RdsConfiguration_FieldMapping_fieldMapping_MetadataField;
                requestStorageConfiguration_storageConfiguration_RdsConfiguration_storageConfiguration_RdsConfiguration_FieldMappingIsNull = false;
            }
            System.String requestStorageConfiguration_storageConfiguration_RdsConfiguration_storageConfiguration_RdsConfiguration_FieldMapping_fieldMapping_PrimaryKeyField = null;
            if (cmdletContext.FieldMapping_PrimaryKeyField != null)
            {
                requestStorageConfiguration_storageConfiguration_RdsConfiguration_storageConfiguration_RdsConfiguration_FieldMapping_fieldMapping_PrimaryKeyField = cmdletContext.FieldMapping_PrimaryKeyField;
            }
            if (requestStorageConfiguration_storageConfiguration_RdsConfiguration_storageConfiguration_RdsConfiguration_FieldMapping_fieldMapping_PrimaryKeyField != null)
            {
                requestStorageConfiguration_storageConfiguration_RdsConfiguration_storageConfiguration_RdsConfiguration_FieldMapping.PrimaryKeyField = requestStorageConfiguration_storageConfiguration_RdsConfiguration_storageConfiguration_RdsConfiguration_FieldMapping_fieldMapping_PrimaryKeyField;
                requestStorageConfiguration_storageConfiguration_RdsConfiguration_storageConfiguration_RdsConfiguration_FieldMappingIsNull = false;
            }
            System.String requestStorageConfiguration_storageConfiguration_RdsConfiguration_storageConfiguration_RdsConfiguration_FieldMapping_fieldMapping_TextField = null;
            if (cmdletContext.FieldMapping_TextField != null)
            {
                requestStorageConfiguration_storageConfiguration_RdsConfiguration_storageConfiguration_RdsConfiguration_FieldMapping_fieldMapping_TextField = cmdletContext.FieldMapping_TextField;
            }
            if (requestStorageConfiguration_storageConfiguration_RdsConfiguration_storageConfiguration_RdsConfiguration_FieldMapping_fieldMapping_TextField != null)
            {
                requestStorageConfiguration_storageConfiguration_RdsConfiguration_storageConfiguration_RdsConfiguration_FieldMapping.TextField = requestStorageConfiguration_storageConfiguration_RdsConfiguration_storageConfiguration_RdsConfiguration_FieldMapping_fieldMapping_TextField;
                requestStorageConfiguration_storageConfiguration_RdsConfiguration_storageConfiguration_RdsConfiguration_FieldMappingIsNull = false;
            }
            System.String requestStorageConfiguration_storageConfiguration_RdsConfiguration_storageConfiguration_RdsConfiguration_FieldMapping_fieldMapping_VectorField = null;
            if (cmdletContext.FieldMapping_VectorField != null)
            {
                requestStorageConfiguration_storageConfiguration_RdsConfiguration_storageConfiguration_RdsConfiguration_FieldMapping_fieldMapping_VectorField = cmdletContext.FieldMapping_VectorField;
            }
            if (requestStorageConfiguration_storageConfiguration_RdsConfiguration_storageConfiguration_RdsConfiguration_FieldMapping_fieldMapping_VectorField != null)
            {
                requestStorageConfiguration_storageConfiguration_RdsConfiguration_storageConfiguration_RdsConfiguration_FieldMapping.VectorField = requestStorageConfiguration_storageConfiguration_RdsConfiguration_storageConfiguration_RdsConfiguration_FieldMapping_fieldMapping_VectorField;
                requestStorageConfiguration_storageConfiguration_RdsConfiguration_storageConfiguration_RdsConfiguration_FieldMappingIsNull = false;
            }
             // determine if requestStorageConfiguration_storageConfiguration_RdsConfiguration_storageConfiguration_RdsConfiguration_FieldMapping should be set to null
            if (requestStorageConfiguration_storageConfiguration_RdsConfiguration_storageConfiguration_RdsConfiguration_FieldMappingIsNull)
            {
                requestStorageConfiguration_storageConfiguration_RdsConfiguration_storageConfiguration_RdsConfiguration_FieldMapping = null;
            }
            if (requestStorageConfiguration_storageConfiguration_RdsConfiguration_storageConfiguration_RdsConfiguration_FieldMapping != null)
            {
                requestStorageConfiguration_storageConfiguration_RdsConfiguration.FieldMapping = requestStorageConfiguration_storageConfiguration_RdsConfiguration_storageConfiguration_RdsConfiguration_FieldMapping;
                requestStorageConfiguration_storageConfiguration_RdsConfigurationIsNull = false;
            }
             // determine if requestStorageConfiguration_storageConfiguration_RdsConfiguration should be set to null
            if (requestStorageConfiguration_storageConfiguration_RdsConfigurationIsNull)
            {
                requestStorageConfiguration_storageConfiguration_RdsConfiguration = null;
            }
            if (requestStorageConfiguration_storageConfiguration_RdsConfiguration != null)
            {
                request.StorageConfiguration.RdsConfiguration = requestStorageConfiguration_storageConfiguration_RdsConfiguration;
                requestStorageConfigurationIsNull = false;
            }
             // determine if request.StorageConfiguration should be set to null
            if (requestStorageConfigurationIsNull)
            {
                request.StorageConfiguration = null;
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
        
        private Amazon.BedrockAgent.Model.CreateKnowledgeBaseResponse CallAWSServiceOperation(IAmazonBedrockAgent client, Amazon.BedrockAgent.Model.CreateKnowledgeBaseRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Agents for Amazon Bedrock", "CreateKnowledgeBase");
            try
            {
                #if DESKTOP
                return client.CreateKnowledgeBase(request);
                #elif CORECLR
                return client.CreateKnowledgeBaseAsync(request).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public Amazon.BedrockAgent.KnowledgeBaseType KnowledgeBaseConfiguration_Type { get; set; }
            public System.String VectorKnowledgeBaseConfiguration_EmbeddingModelArn { get; set; }
            public System.String Name { get; set; }
            public System.String RoleArn { get; set; }
            public System.String OpensearchServerlessConfiguration_CollectionArn { get; set; }
            public System.String StorageConfiguration_OpensearchServerlessConfiguration_FieldMapping_MetadataField { get; set; }
            public System.String StorageConfiguration_OpensearchServerlessConfiguration_FieldMapping_TextField { get; set; }
            public System.String StorageConfiguration_OpensearchServerlessConfiguration_FieldMapping_VectorField { get; set; }
            public System.String OpensearchServerlessConfiguration_VectorIndexName { get; set; }
            public System.String PineconeConfiguration_ConnectionString { get; set; }
            public System.String PineconeConfiguration_CredentialsSecretArn { get; set; }
            public System.String StorageConfiguration_PineconeConfiguration_FieldMapping_MetadataField { get; set; }
            public System.String StorageConfiguration_PineconeConfiguration_FieldMapping_TextField { get; set; }
            public System.String PineconeConfiguration_Namespace { get; set; }
            public System.String RdsConfiguration_CredentialsSecretArn { get; set; }
            public System.String RdsConfiguration_DatabaseName { get; set; }
            public System.String FieldMapping_MetadataField { get; set; }
            public System.String FieldMapping_PrimaryKeyField { get; set; }
            public System.String FieldMapping_TextField { get; set; }
            public System.String FieldMapping_VectorField { get; set; }
            public System.String RdsConfiguration_ResourceArn { get; set; }
            public System.String RdsConfiguration_TableName { get; set; }
            public System.String RedisEnterpriseCloudConfiguration_CredentialsSecretArn { get; set; }
            public System.String RedisEnterpriseCloudConfiguration_Endpoint { get; set; }
            public System.String StorageConfiguration_RedisEnterpriseCloudConfiguration_FieldMapping_MetadataField { get; set; }
            public System.String StorageConfiguration_RedisEnterpriseCloudConfiguration_FieldMapping_TextField { get; set; }
            public System.String StorageConfiguration_RedisEnterpriseCloudConfiguration_FieldMapping_VectorField { get; set; }
            public System.String RedisEnterpriseCloudConfiguration_VectorIndexName { get; set; }
            public Amazon.BedrockAgent.KnowledgeBaseStorageType StorageConfiguration_Type { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.BedrockAgent.Model.CreateKnowledgeBaseResponse, NewAABKnowledgeBaseCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.KnowledgeBase;
        }
        
    }
}
