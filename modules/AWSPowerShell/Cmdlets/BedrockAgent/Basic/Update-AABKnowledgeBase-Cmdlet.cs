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
using Amazon.BedrockAgent;
using Amazon.BedrockAgent.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.AAB
{
    /// <summary>
    /// Updates the configuration of a knowledge base with the fields that you specify. Because
    /// all fields will be overwritten, you must include the same values for fields that you
    /// want to keep the same.
    /// 
    ///  
    /// <para>
    /// You can change the following fields:
    /// </para><ul><li><para><c>name</c></para></li><li><para><c>description</c></para></li><li><para><c>roleArn</c></para></li></ul><para>
    /// You can't change the <c>knowledgeBaseConfiguration</c> or <c>storageConfiguration</c>
    /// fields, so you must specify the same configurations as when you created the knowledge
    /// base. You can send a <a href="https://docs.aws.amazon.com/bedrock/latest/APIReference/API_agent_GetKnowledgeBase.html">GetKnowledgeBase</a>
    /// request and copy the same configurations.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "AABKnowledgeBase", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BedrockAgent.Model.KnowledgeBase")]
    [AWSCmdlet("Calls the Agents for Amazon Bedrock UpdateKnowledgeBase API operation.", Operation = new[] {"UpdateKnowledgeBase"}, SelectReturnType = typeof(Amazon.BedrockAgent.Model.UpdateKnowledgeBaseResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgent.Model.KnowledgeBase or Amazon.BedrockAgent.Model.UpdateKnowledgeBaseResponse",
        "This cmdlet returns an Amazon.BedrockAgent.Model.KnowledgeBase object.",
        "The service call response (type Amazon.BedrockAgent.Model.UpdateKnowledgeBaseResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateAABKnowledgeBaseCmdlet : AmazonBedrockAgentClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter BedrockEmbeddingModelConfiguration_Audio
        /// <summary>
        /// <para>
        /// <para>Configuration settings for processing audio content in multimodal knowledge bases.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KnowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_EmbeddingModelConfiguration_BedrockEmbeddingModelConfiguration_Audio")]
        public Amazon.BedrockAgent.Model.AudioConfiguration[] BedrockEmbeddingModelConfiguration_Audio { get; set; }
        #endregion
        
        #region Parameter ProvisionedConfiguration_ClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Redshift cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KnowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_ClusterIdentifier")]
        public System.String ProvisionedConfiguration_ClusterIdentifier { get; set; }
        #endregion
        
        #region Parameter OpensearchServerlessConfiguration_CollectionArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the OpenSearch Service vector store.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StorageConfiguration_OpensearchServerlessConfiguration_CollectionArn")]
        public System.String OpensearchServerlessConfiguration_CollectionArn { get; set; }
        #endregion
        
        #region Parameter MongoDbAtlasConfiguration_CollectionName
        /// <summary>
        /// <para>
        /// <para>The collection name of the knowledge base in MongoDB Atlas.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StorageConfiguration_MongoDbAtlasConfiguration_CollectionName")]
        public System.String MongoDbAtlasConfiguration_CollectionName { get; set; }
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
        
        #region Parameter MongoDbAtlasConfiguration_CredentialsSecretArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the secret that you created in Secrets Manager that
        /// contains user credentials for your MongoDB Atlas cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StorageConfiguration_MongoDbAtlasConfiguration_CredentialsSecretArn")]
        public System.String MongoDbAtlasConfiguration_CredentialsSecretArn { get; set; }
        #endregion
        
        #region Parameter PineconeConfiguration_CredentialsSecretArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the secret that you created in Secrets Manager that
        /// is linked to your Pinecone API key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StorageConfiguration_PineconeConfiguration_CredentialsSecretArn")]
        public System.String PineconeConfiguration_CredentialsSecretArn { get; set; }
        #endregion
        
        #region Parameter RdsConfiguration_CredentialsSecretArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the secret that you created in Secrets Manager that
        /// is linked to your Amazon RDS database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StorageConfiguration_RdsConfiguration_CredentialsSecretArn")]
        public System.String RdsConfiguration_CredentialsSecretArn { get; set; }
        #endregion
        
        #region Parameter RedisEnterpriseCloudConfiguration_CredentialsSecretArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the secret that you created in Secrets Manager that
        /// is linked to your Redis Enterprise Cloud database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StorageConfiguration_RedisEnterpriseCloudConfiguration_CredentialsSecretArn")]
        public System.String RedisEnterpriseCloudConfiguration_CredentialsSecretArn { get; set; }
        #endregion
        
        #region Parameter GenerationContext_CuratedQuery
        /// <summary>
        /// <para>
        /// <para>An array of objects, each of which defines information about example queries to help
        /// the query engine generate appropriate SQL queries.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KnowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryGenerationConfiguration_GenerationContext_CuratedQueries")]
        public Amazon.BedrockAgent.Model.CuratedQuery[] GenerationContext_CuratedQuery { get; set; }
        #endregion
        
        #region Parameter FieldMapping_CustomMetadataField
        /// <summary>
        /// <para>
        /// <para>Provide a name for the universal metadata field where Amazon Bedrock will store any
        /// custom metadata from your data source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StorageConfiguration_RdsConfiguration_FieldMapping_CustomMetadataField")]
        public System.String FieldMapping_CustomMetadataField { get; set; }
        #endregion
        
        #region Parameter MongoDbAtlasConfiguration_DatabaseName
        /// <summary>
        /// <para>
        /// <para>The database name in your MongoDB Atlas cluster for your knowledge base.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StorageConfiguration_MongoDbAtlasConfiguration_DatabaseName")]
        public System.String MongoDbAtlasConfiguration_DatabaseName { get; set; }
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
        
        #region Parameter AuthConfiguration_DatabaseUser
        /// <summary>
        /// <para>
        /// <para>The database username for authentication to an Amazon Redshift provisioned data warehouse.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KnowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_AuthConfiguration_DatabaseUser")]
        public System.String AuthConfiguration_DatabaseUser { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>Specifies a new description for the knowledge base.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter BedrockEmbeddingModelConfiguration_Dimension
        /// <summary>
        /// <para>
        /// <para>The dimensions details for the vector configuration used on the Bedrock embeddings
        /// model.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KnowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_EmbeddingModelConfiguration_BedrockEmbeddingModelConfiguration_Dimensions")]
        public System.Int32? BedrockEmbeddingModelConfiguration_Dimension { get; set; }
        #endregion
        
        #region Parameter OpensearchManagedClusterConfiguration_DomainArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the OpenSearch domain.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StorageConfiguration_OpensearchManagedClusterConfiguration_DomainArn")]
        public System.String OpensearchManagedClusterConfiguration_DomainArn { get; set; }
        #endregion
        
        #region Parameter OpensearchManagedClusterConfiguration_DomainEndpoint
        /// <summary>
        /// <para>
        /// <para>The endpoint URL the OpenSearch domain.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StorageConfiguration_OpensearchManagedClusterConfiguration_DomainEndpoint")]
        public System.String OpensearchManagedClusterConfiguration_DomainEndpoint { get; set; }
        #endregion
        
        #region Parameter BedrockEmbeddingModelConfiguration_EmbeddingDataType
        /// <summary>
        /// <para>
        /// <para>The data type for the vectors when using a model to convert text into vector embeddings.
        /// The model must support the specified data type for vector embeddings. Floating-point
        /// (float32) is the default data type, and is supported by most models for vector embeddings.
        /// See <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/knowledge-base-supported.html">Supported
        /// embeddings models</a> for information on the available models and their vector data
        /// types.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KnowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_EmbeddingModelConfiguration_BedrockEmbeddingModelConfiguration_EmbeddingDataType")]
        [AWSConstantClassSource("Amazon.BedrockAgent.EmbeddingDataType")]
        public Amazon.BedrockAgent.EmbeddingDataType BedrockEmbeddingModelConfiguration_EmbeddingDataType { get; set; }
        #endregion
        
        #region Parameter VectorKnowledgeBaseConfiguration_EmbeddingModelArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the model used to create vector embeddings for the
        /// knowledge base.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KnowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_EmbeddingModelArn")]
        public System.String VectorKnowledgeBaseConfiguration_EmbeddingModelArn { get; set; }
        #endregion
        
        #region Parameter MongoDbAtlasConfiguration_Endpoint
        /// <summary>
        /// <para>
        /// <para>The endpoint URL of your MongoDB Atlas cluster for your knowledge base.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StorageConfiguration_MongoDbAtlasConfiguration_Endpoint")]
        public System.String MongoDbAtlasConfiguration_Endpoint { get; set; }
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
        
        #region Parameter MongoDbAtlasConfiguration_EndpointServiceName
        /// <summary>
        /// <para>
        /// <para>The name of the VPC endpoint service in your account that is connected to your MongoDB
        /// Atlas cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StorageConfiguration_MongoDbAtlasConfiguration_EndpointServiceName")]
        public System.String MongoDbAtlasConfiguration_EndpointServiceName { get; set; }
        #endregion
        
        #region Parameter QueryGenerationConfiguration_ExecutionTimeoutSecond
        /// <summary>
        /// <para>
        /// <para>The time after which query generation will time out.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KnowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryGenerationConfiguration_ExecutionTimeoutSeconds")]
        public System.Int32? QueryGenerationConfiguration_ExecutionTimeoutSecond { get; set; }
        #endregion
        
        #region Parameter NeptuneAnalyticsConfiguration_GraphArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Neptune Analytics vector store.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StorageConfiguration_NeptuneAnalyticsConfiguration_GraphArn")]
        public System.String NeptuneAnalyticsConfiguration_GraphArn { get; set; }
        #endregion
        
        #region Parameter S3VectorsConfiguration_IndexArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the vector index used for the knowledge base. This
        /// ARN identifies the specific vector index resource within Amazon Bedrock.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StorageConfiguration_S3VectorsConfiguration_IndexArn")]
        public System.String S3VectorsConfiguration_IndexArn { get; set; }
        #endregion
        
        #region Parameter S3VectorsConfiguration_IndexName
        /// <summary>
        /// <para>
        /// <para>The name of the vector index used for the knowledge base. This name identifies the
        /// vector index within the Amazon Bedrock service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StorageConfiguration_S3VectorsConfiguration_IndexName")]
        public System.String S3VectorsConfiguration_IndexName { get; set; }
        #endregion
        
        #region Parameter KendraKnowledgeBaseConfiguration_KendraIndexArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the Amazon Kendra index.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KnowledgeBaseConfiguration_KendraKnowledgeBaseConfiguration_KendraIndexArn")]
        public System.String KendraKnowledgeBaseConfiguration_KendraIndexArn { get; set; }
        #endregion
        
        #region Parameter KnowledgeBaseId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the knowledge base to update.</para>
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
        public System.String KnowledgeBaseId { get; set; }
        #endregion
        
        #region Parameter StorageConfiguration_MongoDbAtlasConfiguration_FieldMapping_MetadataField
        /// <summary>
        /// <para>
        /// <para>The name of the field in which Amazon Bedrock stores metadata about the vector store.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StorageConfiguration_MongoDbAtlasConfiguration_FieldMapping_MetadataField { get; set; }
        #endregion
        
        #region Parameter StorageConfiguration_NeptuneAnalyticsConfiguration_FieldMapping_MetadataField
        /// <summary>
        /// <para>
        /// <para>The name of the field in which Amazon Bedrock stores metadata about the vector store.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StorageConfiguration_NeptuneAnalyticsConfiguration_FieldMapping_MetadataField { get; set; }
        #endregion
        
        #region Parameter StorageConfiguration_OpensearchManagedClusterConfiguration_FieldMapping_MetadataField
        /// <summary>
        /// <para>
        /// <para>The name of the field in which Amazon Bedrock stores metadata about the vector store.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StorageConfiguration_OpensearchManagedClusterConfiguration_FieldMapping_MetadataField { get; set; }
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
        
        #region Parameter StorageConfiguration_RdsConfiguration_FieldMapping_MetadataField
        /// <summary>
        /// <para>
        /// <para>The name of the field in which Amazon Bedrock stores metadata about the vector store.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FieldMapping_MetadataField")]
        public System.String StorageConfiguration_RdsConfiguration_FieldMapping_MetadataField { get; set; }
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
        /// <para>Specifies a new name for the knowledge base.</para>
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
        /// <para>The Amazon Resource Name (ARN) of the vector store.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StorageConfiguration_RdsConfiguration_ResourceArn")]
        public System.String RdsConfiguration_ResourceArn { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>Specifies a different Amazon Resource Name (ARN) of the IAM role with permissions
        /// to invoke API operations on the knowledge base.</para>
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
        
        #region Parameter RedshiftConfiguration_StorageConfiguration
        /// <summary>
        /// <para>
        /// <para>Specifies configurations for Amazon Redshift database storage.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KnowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_StorageConfigurations")]
        public Amazon.BedrockAgent.Model.RedshiftQueryEngineStorageConfiguration[] RedshiftConfiguration_StorageConfiguration { get; set; }
        #endregion
        
        #region Parameter SupplementalDataStorageConfiguration_StorageLocation
        /// <summary>
        /// <para>
        /// <para>A list of objects specifying storage locations for images extracted from multimodal
        /// documents in your data source.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KnowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_SupplementalDataStorageConfiguration_StorageLocations")]
        public Amazon.BedrockAgent.Model.SupplementalDataStorageLocation[] SupplementalDataStorageConfiguration_StorageLocation { get; set; }
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
        
        #region Parameter GenerationContext_Table
        /// <summary>
        /// <para>
        /// <para>An array of objects, each of which defines information about a table in the database.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KnowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryGenerationConfiguration_GenerationContext_Tables")]
        public Amazon.BedrockAgent.Model.QueryGenerationTable[] GenerationContext_Table { get; set; }
        #endregion
        
        #region Parameter StorageConfiguration_MongoDbAtlasConfiguration_FieldMapping_TextField
        /// <summary>
        /// <para>
        /// <para>The name of the field in which Amazon Bedrock stores the raw text from your data.
        /// The text is split according to the chunking strategy you choose.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StorageConfiguration_MongoDbAtlasConfiguration_FieldMapping_TextField { get; set; }
        #endregion
        
        #region Parameter StorageConfiguration_NeptuneAnalyticsConfiguration_FieldMapping_TextField
        /// <summary>
        /// <para>
        /// <para>The name of the field in which Amazon Bedrock stores the raw text from your data.
        /// The text is split according to the chunking strategy you choose.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StorageConfiguration_NeptuneAnalyticsConfiguration_FieldMapping_TextField { get; set; }
        #endregion
        
        #region Parameter StorageConfiguration_OpensearchManagedClusterConfiguration_FieldMapping_TextField
        /// <summary>
        /// <para>
        /// <para>The name of the field in which Amazon Bedrock stores the raw text from your data.
        /// The text is split according to the chunking strategy you choose.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StorageConfiguration_OpensearchManagedClusterConfiguration_FieldMapping_TextField { get; set; }
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
        
        #region Parameter StorageConfiguration_RdsConfiguration_FieldMapping_TextField
        /// <summary>
        /// <para>
        /// <para>The name of the field in which Amazon Bedrock stores the raw text from your data.
        /// The text is split according to the chunking strategy you choose.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FieldMapping_TextField")]
        public System.String StorageConfiguration_RdsConfiguration_FieldMapping_TextField { get; set; }
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
        
        #region Parameter MongoDbAtlasConfiguration_TextIndexName
        /// <summary>
        /// <para>
        /// <para>The name of the text search index in the MongoDB collection. This is required for
        /// using the hybrid search feature.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StorageConfiguration_MongoDbAtlasConfiguration_TextIndexName")]
        public System.String MongoDbAtlasConfiguration_TextIndexName { get; set; }
        #endregion
        
        #region Parameter KnowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_AuthConfiguration_Type
        /// <summary>
        /// <para>
        /// <para>The type of authentication to use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockAgent.RedshiftProvisionedAuthType")]
        public Amazon.BedrockAgent.RedshiftProvisionedAuthType KnowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_AuthConfiguration_Type { get; set; }
        #endregion
        
        #region Parameter AuthConfiguration_Type
        /// <summary>
        /// <para>
        /// <para>The type of authentication to use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KnowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ServerlessConfiguration_AuthConfiguration_Type")]
        [AWSConstantClassSource("Amazon.BedrockAgent.RedshiftServerlessAuthType")]
        public Amazon.BedrockAgent.RedshiftServerlessAuthType AuthConfiguration_Type { get; set; }
        #endregion
        
        #region Parameter QueryEngineConfiguration_Type
        /// <summary>
        /// <para>
        /// <para>The type of query engine.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KnowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_Type")]
        [AWSConstantClassSource("Amazon.BedrockAgent.RedshiftQueryEngineType")]
        public Amazon.BedrockAgent.RedshiftQueryEngineType QueryEngineConfiguration_Type { get; set; }
        #endregion
        
        #region Parameter SqlKnowledgeBaseConfiguration_Type
        /// <summary>
        /// <para>
        /// <para>The type of SQL database to connect to the knowledge base.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KnowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_Type")]
        [AWSConstantClassSource("Amazon.BedrockAgent.QueryEngineType")]
        public Amazon.BedrockAgent.QueryEngineType SqlKnowledgeBaseConfiguration_Type { get; set; }
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockAgent.KnowledgeBaseStorageType")]
        public Amazon.BedrockAgent.KnowledgeBaseStorageType StorageConfiguration_Type { get; set; }
        #endregion
        
        #region Parameter KnowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_AuthConfiguration_UsernamePasswordSecretArn
        /// <summary>
        /// <para>
        /// <para>The ARN of an Secrets Manager secret for authentication.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KnowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_AuthConfiguration_UsernamePasswordSecretArn { get; set; }
        #endregion
        
        #region Parameter AuthConfiguration_UsernamePasswordSecretArn
        /// <summary>
        /// <para>
        /// <para>The ARN of an Secrets Manager secret for authentication.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KnowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ServerlessConfiguration_AuthConfiguration_UsernamePasswordSecretArn")]
        public System.String AuthConfiguration_UsernamePasswordSecretArn { get; set; }
        #endregion
        
        #region Parameter S3VectorsConfiguration_VectorBucketArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the S3 bucket where vector embeddings are stored.
        /// This bucket contains the vector data used by the knowledge base.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StorageConfiguration_S3VectorsConfiguration_VectorBucketArn")]
        public System.String S3VectorsConfiguration_VectorBucketArn { get; set; }
        #endregion
        
        #region Parameter StorageConfiguration_MongoDbAtlasConfiguration_FieldMapping_VectorField
        /// <summary>
        /// <para>
        /// <para>The name of the field in which Amazon Bedrock stores the vector embeddings for your
        /// data sources.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StorageConfiguration_MongoDbAtlasConfiguration_FieldMapping_VectorField { get; set; }
        #endregion
        
        #region Parameter StorageConfiguration_OpensearchManagedClusterConfiguration_FieldMapping_VectorField
        /// <summary>
        /// <para>
        /// <para>The name of the field in which Amazon Bedrock stores the vector embeddings for your
        /// data sources.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StorageConfiguration_OpensearchManagedClusterConfiguration_FieldMapping_VectorField { get; set; }
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
        
        #region Parameter StorageConfiguration_RdsConfiguration_FieldMapping_VectorField
        /// <summary>
        /// <para>
        /// <para>The name of the field in which Amazon Bedrock stores the vector embeddings for your
        /// data sources.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FieldMapping_VectorField")]
        public System.String StorageConfiguration_RdsConfiguration_FieldMapping_VectorField { get; set; }
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
        
        #region Parameter MongoDbAtlasConfiguration_VectorIndexName
        /// <summary>
        /// <para>
        /// <para>The name of the MongoDB Atlas vector search index.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StorageConfiguration_MongoDbAtlasConfiguration_VectorIndexName")]
        public System.String MongoDbAtlasConfiguration_VectorIndexName { get; set; }
        #endregion
        
        #region Parameter OpensearchManagedClusterConfiguration_VectorIndexName
        /// <summary>
        /// <para>
        /// <para>The name of the vector store.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StorageConfiguration_OpensearchManagedClusterConfiguration_VectorIndexName")]
        public System.String OpensearchManagedClusterConfiguration_VectorIndexName { get; set; }
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
        
        #region Parameter BedrockEmbeddingModelConfiguration_Video
        /// <summary>
        /// <para>
        /// <para>Configuration settings for processing video content in multimodal knowledge bases.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KnowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_EmbeddingModelConfiguration_BedrockEmbeddingModelConfiguration_Video")]
        public Amazon.BedrockAgent.Model.VideoConfiguration[] BedrockEmbeddingModelConfiguration_Video { get; set; }
        #endregion
        
        #region Parameter ServerlessConfiguration_WorkgroupArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the Amazon Redshift workgroup.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KnowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ServerlessConfiguration_WorkgroupArn")]
        public System.String ServerlessConfiguration_WorkgroupArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'KnowledgeBase'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgent.Model.UpdateKnowledgeBaseResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgent.Model.UpdateKnowledgeBaseResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "KnowledgeBase";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.KnowledgeBaseId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-AABKnowledgeBase (UpdateKnowledgeBase)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgent.Model.UpdateKnowledgeBaseResponse, UpdateAABKnowledgeBaseCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Description = this.Description;
            context.KendraKnowledgeBaseConfiguration_KendraIndexArn = this.KendraKnowledgeBaseConfiguration_KendraIndexArn;
            context.AuthConfiguration_DatabaseUser = this.AuthConfiguration_DatabaseUser;
            context.KnowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_AuthConfiguration_Type = this.KnowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_AuthConfiguration_Type;
            context.KnowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_AuthConfiguration_UsernamePasswordSecretArn = this.KnowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_AuthConfiguration_UsernamePasswordSecretArn;
            context.ProvisionedConfiguration_ClusterIdentifier = this.ProvisionedConfiguration_ClusterIdentifier;
            context.AuthConfiguration_Type = this.AuthConfiguration_Type;
            context.AuthConfiguration_UsernamePasswordSecretArn = this.AuthConfiguration_UsernamePasswordSecretArn;
            context.ServerlessConfiguration_WorkgroupArn = this.ServerlessConfiguration_WorkgroupArn;
            context.QueryEngineConfiguration_Type = this.QueryEngineConfiguration_Type;
            context.QueryGenerationConfiguration_ExecutionTimeoutSecond = this.QueryGenerationConfiguration_ExecutionTimeoutSecond;
            if (this.GenerationContext_CuratedQuery != null)
            {
                context.GenerationContext_CuratedQuery = new List<Amazon.BedrockAgent.Model.CuratedQuery>(this.GenerationContext_CuratedQuery);
            }
            if (this.GenerationContext_Table != null)
            {
                context.GenerationContext_Table = new List<Amazon.BedrockAgent.Model.QueryGenerationTable>(this.GenerationContext_Table);
            }
            if (this.RedshiftConfiguration_StorageConfiguration != null)
            {
                context.RedshiftConfiguration_StorageConfiguration = new List<Amazon.BedrockAgent.Model.RedshiftQueryEngineStorageConfiguration>(this.RedshiftConfiguration_StorageConfiguration);
            }
            context.SqlKnowledgeBaseConfiguration_Type = this.SqlKnowledgeBaseConfiguration_Type;
            context.KnowledgeBaseConfiguration_Type = this.KnowledgeBaseConfiguration_Type;
            #if MODULAR
            if (this.KnowledgeBaseConfiguration_Type == null && ParameterWasBound(nameof(this.KnowledgeBaseConfiguration_Type)))
            {
                WriteWarning("You are passing $null as a value for parameter KnowledgeBaseConfiguration_Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VectorKnowledgeBaseConfiguration_EmbeddingModelArn = this.VectorKnowledgeBaseConfiguration_EmbeddingModelArn;
            if (this.BedrockEmbeddingModelConfiguration_Audio != null)
            {
                context.BedrockEmbeddingModelConfiguration_Audio = new List<Amazon.BedrockAgent.Model.AudioConfiguration>(this.BedrockEmbeddingModelConfiguration_Audio);
            }
            context.BedrockEmbeddingModelConfiguration_Dimension = this.BedrockEmbeddingModelConfiguration_Dimension;
            context.BedrockEmbeddingModelConfiguration_EmbeddingDataType = this.BedrockEmbeddingModelConfiguration_EmbeddingDataType;
            if (this.BedrockEmbeddingModelConfiguration_Video != null)
            {
                context.BedrockEmbeddingModelConfiguration_Video = new List<Amazon.BedrockAgent.Model.VideoConfiguration>(this.BedrockEmbeddingModelConfiguration_Video);
            }
            if (this.SupplementalDataStorageConfiguration_StorageLocation != null)
            {
                context.SupplementalDataStorageConfiguration_StorageLocation = new List<Amazon.BedrockAgent.Model.SupplementalDataStorageLocation>(this.SupplementalDataStorageConfiguration_StorageLocation);
            }
            context.KnowledgeBaseId = this.KnowledgeBaseId;
            #if MODULAR
            if (this.KnowledgeBaseId == null && ParameterWasBound(nameof(this.KnowledgeBaseId)))
            {
                WriteWarning("You are passing $null as a value for parameter KnowledgeBaseId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            context.MongoDbAtlasConfiguration_CollectionName = this.MongoDbAtlasConfiguration_CollectionName;
            context.MongoDbAtlasConfiguration_CredentialsSecretArn = this.MongoDbAtlasConfiguration_CredentialsSecretArn;
            context.MongoDbAtlasConfiguration_DatabaseName = this.MongoDbAtlasConfiguration_DatabaseName;
            context.MongoDbAtlasConfiguration_Endpoint = this.MongoDbAtlasConfiguration_Endpoint;
            context.MongoDbAtlasConfiguration_EndpointServiceName = this.MongoDbAtlasConfiguration_EndpointServiceName;
            context.StorageConfiguration_MongoDbAtlasConfiguration_FieldMapping_MetadataField = this.StorageConfiguration_MongoDbAtlasConfiguration_FieldMapping_MetadataField;
            context.StorageConfiguration_MongoDbAtlasConfiguration_FieldMapping_TextField = this.StorageConfiguration_MongoDbAtlasConfiguration_FieldMapping_TextField;
            context.StorageConfiguration_MongoDbAtlasConfiguration_FieldMapping_VectorField = this.StorageConfiguration_MongoDbAtlasConfiguration_FieldMapping_VectorField;
            context.MongoDbAtlasConfiguration_TextIndexName = this.MongoDbAtlasConfiguration_TextIndexName;
            context.MongoDbAtlasConfiguration_VectorIndexName = this.MongoDbAtlasConfiguration_VectorIndexName;
            context.StorageConfiguration_NeptuneAnalyticsConfiguration_FieldMapping_MetadataField = this.StorageConfiguration_NeptuneAnalyticsConfiguration_FieldMapping_MetadataField;
            context.StorageConfiguration_NeptuneAnalyticsConfiguration_FieldMapping_TextField = this.StorageConfiguration_NeptuneAnalyticsConfiguration_FieldMapping_TextField;
            context.NeptuneAnalyticsConfiguration_GraphArn = this.NeptuneAnalyticsConfiguration_GraphArn;
            context.OpensearchManagedClusterConfiguration_DomainArn = this.OpensearchManagedClusterConfiguration_DomainArn;
            context.OpensearchManagedClusterConfiguration_DomainEndpoint = this.OpensearchManagedClusterConfiguration_DomainEndpoint;
            context.StorageConfiguration_OpensearchManagedClusterConfiguration_FieldMapping_MetadataField = this.StorageConfiguration_OpensearchManagedClusterConfiguration_FieldMapping_MetadataField;
            context.StorageConfiguration_OpensearchManagedClusterConfiguration_FieldMapping_TextField = this.StorageConfiguration_OpensearchManagedClusterConfiguration_FieldMapping_TextField;
            context.StorageConfiguration_OpensearchManagedClusterConfiguration_FieldMapping_VectorField = this.StorageConfiguration_OpensearchManagedClusterConfiguration_FieldMapping_VectorField;
            context.OpensearchManagedClusterConfiguration_VectorIndexName = this.OpensearchManagedClusterConfiguration_VectorIndexName;
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
            context.FieldMapping_CustomMetadataField = this.FieldMapping_CustomMetadataField;
            context.StorageConfiguration_RdsConfiguration_FieldMapping_MetadataField = this.StorageConfiguration_RdsConfiguration_FieldMapping_MetadataField;
            context.FieldMapping_PrimaryKeyField = this.FieldMapping_PrimaryKeyField;
            context.StorageConfiguration_RdsConfiguration_FieldMapping_TextField = this.StorageConfiguration_RdsConfiguration_FieldMapping_TextField;
            context.StorageConfiguration_RdsConfiguration_FieldMapping_VectorField = this.StorageConfiguration_RdsConfiguration_FieldMapping_VectorField;
            context.RdsConfiguration_ResourceArn = this.RdsConfiguration_ResourceArn;
            context.RdsConfiguration_TableName = this.RdsConfiguration_TableName;
            context.RedisEnterpriseCloudConfiguration_CredentialsSecretArn = this.RedisEnterpriseCloudConfiguration_CredentialsSecretArn;
            context.RedisEnterpriseCloudConfiguration_Endpoint = this.RedisEnterpriseCloudConfiguration_Endpoint;
            context.StorageConfiguration_RedisEnterpriseCloudConfiguration_FieldMapping_MetadataField = this.StorageConfiguration_RedisEnterpriseCloudConfiguration_FieldMapping_MetadataField;
            context.StorageConfiguration_RedisEnterpriseCloudConfiguration_FieldMapping_TextField = this.StorageConfiguration_RedisEnterpriseCloudConfiguration_FieldMapping_TextField;
            context.StorageConfiguration_RedisEnterpriseCloudConfiguration_FieldMapping_VectorField = this.StorageConfiguration_RedisEnterpriseCloudConfiguration_FieldMapping_VectorField;
            context.RedisEnterpriseCloudConfiguration_VectorIndexName = this.RedisEnterpriseCloudConfiguration_VectorIndexName;
            context.S3VectorsConfiguration_IndexArn = this.S3VectorsConfiguration_IndexArn;
            context.S3VectorsConfiguration_IndexName = this.S3VectorsConfiguration_IndexName;
            context.S3VectorsConfiguration_VectorBucketArn = this.S3VectorsConfiguration_VectorBucketArn;
            context.StorageConfiguration_Type = this.StorageConfiguration_Type;
            
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
            var request = new Amazon.BedrockAgent.Model.UpdateKnowledgeBaseRequest();
            
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
            Amazon.BedrockAgent.Model.KendraKnowledgeBaseConfiguration requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_KendraKnowledgeBaseConfiguration = null;
            
             // populate KendraKnowledgeBaseConfiguration
            var requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_KendraKnowledgeBaseConfigurationIsNull = true;
            requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_KendraKnowledgeBaseConfiguration = new Amazon.BedrockAgent.Model.KendraKnowledgeBaseConfiguration();
            System.String requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_KendraKnowledgeBaseConfiguration_kendraKnowledgeBaseConfiguration_KendraIndexArn = null;
            if (cmdletContext.KendraKnowledgeBaseConfiguration_KendraIndexArn != null)
            {
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_KendraKnowledgeBaseConfiguration_kendraKnowledgeBaseConfiguration_KendraIndexArn = cmdletContext.KendraKnowledgeBaseConfiguration_KendraIndexArn;
            }
            if (requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_KendraKnowledgeBaseConfiguration_kendraKnowledgeBaseConfiguration_KendraIndexArn != null)
            {
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_KendraKnowledgeBaseConfiguration.KendraIndexArn = requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_KendraKnowledgeBaseConfiguration_kendraKnowledgeBaseConfiguration_KendraIndexArn;
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_KendraKnowledgeBaseConfigurationIsNull = false;
            }
             // determine if requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_KendraKnowledgeBaseConfiguration should be set to null
            if (requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_KendraKnowledgeBaseConfigurationIsNull)
            {
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_KendraKnowledgeBaseConfiguration = null;
            }
            if (requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_KendraKnowledgeBaseConfiguration != null)
            {
                request.KnowledgeBaseConfiguration.KendraKnowledgeBaseConfiguration = requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_KendraKnowledgeBaseConfiguration;
                requestKnowledgeBaseConfigurationIsNull = false;
            }
            Amazon.BedrockAgent.Model.SqlKnowledgeBaseConfiguration requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration = null;
            
             // populate SqlKnowledgeBaseConfiguration
            var requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfigurationIsNull = true;
            requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration = new Amazon.BedrockAgent.Model.SqlKnowledgeBaseConfiguration();
            Amazon.BedrockAgent.QueryEngineType requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_sqlKnowledgeBaseConfiguration_Type = null;
            if (cmdletContext.SqlKnowledgeBaseConfiguration_Type != null)
            {
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_sqlKnowledgeBaseConfiguration_Type = cmdletContext.SqlKnowledgeBaseConfiguration_Type;
            }
            if (requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_sqlKnowledgeBaseConfiguration_Type != null)
            {
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration.Type = requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_sqlKnowledgeBaseConfiguration_Type;
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfigurationIsNull = false;
            }
            Amazon.BedrockAgent.Model.RedshiftConfiguration requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration = null;
            
             // populate RedshiftConfiguration
            var requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfigurationIsNull = true;
            requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration = new Amazon.BedrockAgent.Model.RedshiftConfiguration();
            List<Amazon.BedrockAgent.Model.RedshiftQueryEngineStorageConfiguration> requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_redshiftConfiguration_StorageConfiguration = null;
            if (cmdletContext.RedshiftConfiguration_StorageConfiguration != null)
            {
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_redshiftConfiguration_StorageConfiguration = cmdletContext.RedshiftConfiguration_StorageConfiguration;
            }
            if (requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_redshiftConfiguration_StorageConfiguration != null)
            {
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration.StorageConfigurations = requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_redshiftConfiguration_StorageConfiguration;
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfigurationIsNull = false;
            }
            Amazon.BedrockAgent.Model.QueryGenerationConfiguration requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryGenerationConfiguration = null;
            
             // populate QueryGenerationConfiguration
            var requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryGenerationConfigurationIsNull = true;
            requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryGenerationConfiguration = new Amazon.BedrockAgent.Model.QueryGenerationConfiguration();
            System.Int32? requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryGenerationConfiguration_queryGenerationConfiguration_ExecutionTimeoutSecond = null;
            if (cmdletContext.QueryGenerationConfiguration_ExecutionTimeoutSecond != null)
            {
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryGenerationConfiguration_queryGenerationConfiguration_ExecutionTimeoutSecond = cmdletContext.QueryGenerationConfiguration_ExecutionTimeoutSecond.Value;
            }
            if (requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryGenerationConfiguration_queryGenerationConfiguration_ExecutionTimeoutSecond != null)
            {
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryGenerationConfiguration.ExecutionTimeoutSeconds = requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryGenerationConfiguration_queryGenerationConfiguration_ExecutionTimeoutSecond.Value;
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryGenerationConfigurationIsNull = false;
            }
            Amazon.BedrockAgent.Model.QueryGenerationContext requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryGenerationConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryGenerationConfiguration_GenerationContext = null;
            
             // populate GenerationContext
            var requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryGenerationConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryGenerationConfiguration_GenerationContextIsNull = true;
            requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryGenerationConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryGenerationConfiguration_GenerationContext = new Amazon.BedrockAgent.Model.QueryGenerationContext();
            List<Amazon.BedrockAgent.Model.CuratedQuery> requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryGenerationConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryGenerationConfiguration_GenerationContext_generationContext_CuratedQuery = null;
            if (cmdletContext.GenerationContext_CuratedQuery != null)
            {
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryGenerationConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryGenerationConfiguration_GenerationContext_generationContext_CuratedQuery = cmdletContext.GenerationContext_CuratedQuery;
            }
            if (requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryGenerationConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryGenerationConfiguration_GenerationContext_generationContext_CuratedQuery != null)
            {
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryGenerationConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryGenerationConfiguration_GenerationContext.CuratedQueries = requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryGenerationConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryGenerationConfiguration_GenerationContext_generationContext_CuratedQuery;
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryGenerationConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryGenerationConfiguration_GenerationContextIsNull = false;
            }
            List<Amazon.BedrockAgent.Model.QueryGenerationTable> requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryGenerationConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryGenerationConfiguration_GenerationContext_generationContext_Table = null;
            if (cmdletContext.GenerationContext_Table != null)
            {
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryGenerationConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryGenerationConfiguration_GenerationContext_generationContext_Table = cmdletContext.GenerationContext_Table;
            }
            if (requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryGenerationConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryGenerationConfiguration_GenerationContext_generationContext_Table != null)
            {
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryGenerationConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryGenerationConfiguration_GenerationContext.Tables = requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryGenerationConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryGenerationConfiguration_GenerationContext_generationContext_Table;
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryGenerationConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryGenerationConfiguration_GenerationContextIsNull = false;
            }
             // determine if requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryGenerationConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryGenerationConfiguration_GenerationContext should be set to null
            if (requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryGenerationConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryGenerationConfiguration_GenerationContextIsNull)
            {
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryGenerationConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryGenerationConfiguration_GenerationContext = null;
            }
            if (requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryGenerationConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryGenerationConfiguration_GenerationContext != null)
            {
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryGenerationConfiguration.GenerationContext = requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryGenerationConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryGenerationConfiguration_GenerationContext;
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryGenerationConfigurationIsNull = false;
            }
             // determine if requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryGenerationConfiguration should be set to null
            if (requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryGenerationConfigurationIsNull)
            {
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryGenerationConfiguration = null;
            }
            if (requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryGenerationConfiguration != null)
            {
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration.QueryGenerationConfiguration = requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryGenerationConfiguration;
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfigurationIsNull = false;
            }
            Amazon.BedrockAgent.Model.RedshiftQueryEngineConfiguration requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration = null;
            
             // populate QueryEngineConfiguration
            var requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfigurationIsNull = true;
            requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration = new Amazon.BedrockAgent.Model.RedshiftQueryEngineConfiguration();
            Amazon.BedrockAgent.RedshiftQueryEngineType requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_queryEngineConfiguration_Type = null;
            if (cmdletContext.QueryEngineConfiguration_Type != null)
            {
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_queryEngineConfiguration_Type = cmdletContext.QueryEngineConfiguration_Type;
            }
            if (requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_queryEngineConfiguration_Type != null)
            {
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration.Type = requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_queryEngineConfiguration_Type;
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfigurationIsNull = false;
            }
            Amazon.BedrockAgent.Model.RedshiftProvisionedConfiguration requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration = null;
            
             // populate ProvisionedConfiguration
            var requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfigurationIsNull = true;
            requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration = new Amazon.BedrockAgent.Model.RedshiftProvisionedConfiguration();
            System.String requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_provisionedConfiguration_ClusterIdentifier = null;
            if (cmdletContext.ProvisionedConfiguration_ClusterIdentifier != null)
            {
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_provisionedConfiguration_ClusterIdentifier = cmdletContext.ProvisionedConfiguration_ClusterIdentifier;
            }
            if (requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_provisionedConfiguration_ClusterIdentifier != null)
            {
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration.ClusterIdentifier = requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_provisionedConfiguration_ClusterIdentifier;
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfigurationIsNull = false;
            }
            Amazon.BedrockAgent.Model.RedshiftProvisionedAuthConfiguration requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_AuthConfiguration = null;
            
             // populate AuthConfiguration
            var requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_AuthConfigurationIsNull = true;
            requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_AuthConfiguration = new Amazon.BedrockAgent.Model.RedshiftProvisionedAuthConfiguration();
            System.String requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_AuthConfiguration_authConfiguration_DatabaseUser = null;
            if (cmdletContext.AuthConfiguration_DatabaseUser != null)
            {
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_AuthConfiguration_authConfiguration_DatabaseUser = cmdletContext.AuthConfiguration_DatabaseUser;
            }
            if (requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_AuthConfiguration_authConfiguration_DatabaseUser != null)
            {
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_AuthConfiguration.DatabaseUser = requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_AuthConfiguration_authConfiguration_DatabaseUser;
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_AuthConfigurationIsNull = false;
            }
            Amazon.BedrockAgent.RedshiftProvisionedAuthType requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_AuthConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_AuthConfiguration_Type = null;
            if (cmdletContext.KnowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_AuthConfiguration_Type != null)
            {
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_AuthConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_AuthConfiguration_Type = cmdletContext.KnowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_AuthConfiguration_Type;
            }
            if (requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_AuthConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_AuthConfiguration_Type != null)
            {
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_AuthConfiguration.Type = requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_AuthConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_AuthConfiguration_Type;
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_AuthConfigurationIsNull = false;
            }
            System.String requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_AuthConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_AuthConfiguration_UsernamePasswordSecretArn = null;
            if (cmdletContext.KnowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_AuthConfiguration_UsernamePasswordSecretArn != null)
            {
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_AuthConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_AuthConfiguration_UsernamePasswordSecretArn = cmdletContext.KnowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_AuthConfiguration_UsernamePasswordSecretArn;
            }
            if (requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_AuthConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_AuthConfiguration_UsernamePasswordSecretArn != null)
            {
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_AuthConfiguration.UsernamePasswordSecretArn = requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_AuthConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_AuthConfiguration_UsernamePasswordSecretArn;
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_AuthConfigurationIsNull = false;
            }
             // determine if requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_AuthConfiguration should be set to null
            if (requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_AuthConfigurationIsNull)
            {
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_AuthConfiguration = null;
            }
            if (requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_AuthConfiguration != null)
            {
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration.AuthConfiguration = requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_AuthConfiguration;
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfigurationIsNull = false;
            }
             // determine if requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration should be set to null
            if (requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfigurationIsNull)
            {
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration = null;
            }
            if (requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration != null)
            {
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration.ProvisionedConfiguration = requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration;
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfigurationIsNull = false;
            }
            Amazon.BedrockAgent.Model.RedshiftServerlessConfiguration requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ServerlessConfiguration = null;
            
             // populate ServerlessConfiguration
            var requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ServerlessConfigurationIsNull = true;
            requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ServerlessConfiguration = new Amazon.BedrockAgent.Model.RedshiftServerlessConfiguration();
            System.String requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ServerlessConfiguration_serverlessConfiguration_WorkgroupArn = null;
            if (cmdletContext.ServerlessConfiguration_WorkgroupArn != null)
            {
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ServerlessConfiguration_serverlessConfiguration_WorkgroupArn = cmdletContext.ServerlessConfiguration_WorkgroupArn;
            }
            if (requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ServerlessConfiguration_serverlessConfiguration_WorkgroupArn != null)
            {
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ServerlessConfiguration.WorkgroupArn = requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ServerlessConfiguration_serverlessConfiguration_WorkgroupArn;
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ServerlessConfigurationIsNull = false;
            }
            Amazon.BedrockAgent.Model.RedshiftServerlessAuthConfiguration requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ServerlessConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ServerlessConfiguration_AuthConfiguration = null;
            
             // populate AuthConfiguration
            var requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ServerlessConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ServerlessConfiguration_AuthConfigurationIsNull = true;
            requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ServerlessConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ServerlessConfiguration_AuthConfiguration = new Amazon.BedrockAgent.Model.RedshiftServerlessAuthConfiguration();
            Amazon.BedrockAgent.RedshiftServerlessAuthType requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ServerlessConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ServerlessConfiguration_AuthConfiguration_authConfiguration_Type = null;
            if (cmdletContext.AuthConfiguration_Type != null)
            {
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ServerlessConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ServerlessConfiguration_AuthConfiguration_authConfiguration_Type = cmdletContext.AuthConfiguration_Type;
            }
            if (requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ServerlessConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ServerlessConfiguration_AuthConfiguration_authConfiguration_Type != null)
            {
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ServerlessConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ServerlessConfiguration_AuthConfiguration.Type = requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ServerlessConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ServerlessConfiguration_AuthConfiguration_authConfiguration_Type;
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ServerlessConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ServerlessConfiguration_AuthConfigurationIsNull = false;
            }
            System.String requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ServerlessConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ServerlessConfiguration_AuthConfiguration_authConfiguration_UsernamePasswordSecretArn = null;
            if (cmdletContext.AuthConfiguration_UsernamePasswordSecretArn != null)
            {
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ServerlessConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ServerlessConfiguration_AuthConfiguration_authConfiguration_UsernamePasswordSecretArn = cmdletContext.AuthConfiguration_UsernamePasswordSecretArn;
            }
            if (requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ServerlessConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ServerlessConfiguration_AuthConfiguration_authConfiguration_UsernamePasswordSecretArn != null)
            {
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ServerlessConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ServerlessConfiguration_AuthConfiguration.UsernamePasswordSecretArn = requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ServerlessConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ServerlessConfiguration_AuthConfiguration_authConfiguration_UsernamePasswordSecretArn;
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ServerlessConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ServerlessConfiguration_AuthConfigurationIsNull = false;
            }
             // determine if requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ServerlessConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ServerlessConfiguration_AuthConfiguration should be set to null
            if (requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ServerlessConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ServerlessConfiguration_AuthConfigurationIsNull)
            {
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ServerlessConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ServerlessConfiguration_AuthConfiguration = null;
            }
            if (requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ServerlessConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ServerlessConfiguration_AuthConfiguration != null)
            {
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ServerlessConfiguration.AuthConfiguration = requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ServerlessConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ServerlessConfiguration_AuthConfiguration;
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ServerlessConfigurationIsNull = false;
            }
             // determine if requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ServerlessConfiguration should be set to null
            if (requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ServerlessConfigurationIsNull)
            {
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ServerlessConfiguration = null;
            }
            if (requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ServerlessConfiguration != null)
            {
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration.ServerlessConfiguration = requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ServerlessConfiguration;
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfigurationIsNull = false;
            }
             // determine if requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration should be set to null
            if (requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfigurationIsNull)
            {
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration = null;
            }
            if (requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration != null)
            {
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration.QueryEngineConfiguration = requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration;
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfigurationIsNull = false;
            }
             // determine if requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration should be set to null
            if (requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfigurationIsNull)
            {
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration = null;
            }
            if (requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration != null)
            {
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration.RedshiftConfiguration = requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration;
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfigurationIsNull = false;
            }
             // determine if requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration should be set to null
            if (requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfigurationIsNull)
            {
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration = null;
            }
            if (requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration != null)
            {
                request.KnowledgeBaseConfiguration.SqlKnowledgeBaseConfiguration = requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration;
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
            Amazon.BedrockAgent.Model.EmbeddingModelConfiguration requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_EmbeddingModelConfiguration = null;
            
             // populate EmbeddingModelConfiguration
            var requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_EmbeddingModelConfigurationIsNull = true;
            requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_EmbeddingModelConfiguration = new Amazon.BedrockAgent.Model.EmbeddingModelConfiguration();
            Amazon.BedrockAgent.Model.BedrockEmbeddingModelConfiguration requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_EmbeddingModelConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_EmbeddingModelConfiguration_BedrockEmbeddingModelConfiguration = null;
            
             // populate BedrockEmbeddingModelConfiguration
            var requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_EmbeddingModelConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_EmbeddingModelConfiguration_BedrockEmbeddingModelConfigurationIsNull = true;
            requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_EmbeddingModelConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_EmbeddingModelConfiguration_BedrockEmbeddingModelConfiguration = new Amazon.BedrockAgent.Model.BedrockEmbeddingModelConfiguration();
            List<Amazon.BedrockAgent.Model.AudioConfiguration> requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_EmbeddingModelConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_EmbeddingModelConfiguration_BedrockEmbeddingModelConfiguration_bedrockEmbeddingModelConfiguration_Audio = null;
            if (cmdletContext.BedrockEmbeddingModelConfiguration_Audio != null)
            {
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_EmbeddingModelConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_EmbeddingModelConfiguration_BedrockEmbeddingModelConfiguration_bedrockEmbeddingModelConfiguration_Audio = cmdletContext.BedrockEmbeddingModelConfiguration_Audio;
            }
            if (requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_EmbeddingModelConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_EmbeddingModelConfiguration_BedrockEmbeddingModelConfiguration_bedrockEmbeddingModelConfiguration_Audio != null)
            {
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_EmbeddingModelConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_EmbeddingModelConfiguration_BedrockEmbeddingModelConfiguration.Audio = requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_EmbeddingModelConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_EmbeddingModelConfiguration_BedrockEmbeddingModelConfiguration_bedrockEmbeddingModelConfiguration_Audio;
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_EmbeddingModelConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_EmbeddingModelConfiguration_BedrockEmbeddingModelConfigurationIsNull = false;
            }
            System.Int32? requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_EmbeddingModelConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_EmbeddingModelConfiguration_BedrockEmbeddingModelConfiguration_bedrockEmbeddingModelConfiguration_Dimension = null;
            if (cmdletContext.BedrockEmbeddingModelConfiguration_Dimension != null)
            {
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_EmbeddingModelConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_EmbeddingModelConfiguration_BedrockEmbeddingModelConfiguration_bedrockEmbeddingModelConfiguration_Dimension = cmdletContext.BedrockEmbeddingModelConfiguration_Dimension.Value;
            }
            if (requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_EmbeddingModelConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_EmbeddingModelConfiguration_BedrockEmbeddingModelConfiguration_bedrockEmbeddingModelConfiguration_Dimension != null)
            {
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_EmbeddingModelConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_EmbeddingModelConfiguration_BedrockEmbeddingModelConfiguration.Dimensions = requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_EmbeddingModelConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_EmbeddingModelConfiguration_BedrockEmbeddingModelConfiguration_bedrockEmbeddingModelConfiguration_Dimension.Value;
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_EmbeddingModelConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_EmbeddingModelConfiguration_BedrockEmbeddingModelConfigurationIsNull = false;
            }
            Amazon.BedrockAgent.EmbeddingDataType requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_EmbeddingModelConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_EmbeddingModelConfiguration_BedrockEmbeddingModelConfiguration_bedrockEmbeddingModelConfiguration_EmbeddingDataType = null;
            if (cmdletContext.BedrockEmbeddingModelConfiguration_EmbeddingDataType != null)
            {
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_EmbeddingModelConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_EmbeddingModelConfiguration_BedrockEmbeddingModelConfiguration_bedrockEmbeddingModelConfiguration_EmbeddingDataType = cmdletContext.BedrockEmbeddingModelConfiguration_EmbeddingDataType;
            }
            if (requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_EmbeddingModelConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_EmbeddingModelConfiguration_BedrockEmbeddingModelConfiguration_bedrockEmbeddingModelConfiguration_EmbeddingDataType != null)
            {
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_EmbeddingModelConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_EmbeddingModelConfiguration_BedrockEmbeddingModelConfiguration.EmbeddingDataType = requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_EmbeddingModelConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_EmbeddingModelConfiguration_BedrockEmbeddingModelConfiguration_bedrockEmbeddingModelConfiguration_EmbeddingDataType;
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_EmbeddingModelConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_EmbeddingModelConfiguration_BedrockEmbeddingModelConfigurationIsNull = false;
            }
            List<Amazon.BedrockAgent.Model.VideoConfiguration> requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_EmbeddingModelConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_EmbeddingModelConfiguration_BedrockEmbeddingModelConfiguration_bedrockEmbeddingModelConfiguration_Video = null;
            if (cmdletContext.BedrockEmbeddingModelConfiguration_Video != null)
            {
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_EmbeddingModelConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_EmbeddingModelConfiguration_BedrockEmbeddingModelConfiguration_bedrockEmbeddingModelConfiguration_Video = cmdletContext.BedrockEmbeddingModelConfiguration_Video;
            }
            if (requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_EmbeddingModelConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_EmbeddingModelConfiguration_BedrockEmbeddingModelConfiguration_bedrockEmbeddingModelConfiguration_Video != null)
            {
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_EmbeddingModelConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_EmbeddingModelConfiguration_BedrockEmbeddingModelConfiguration.Video = requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_EmbeddingModelConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_EmbeddingModelConfiguration_BedrockEmbeddingModelConfiguration_bedrockEmbeddingModelConfiguration_Video;
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_EmbeddingModelConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_EmbeddingModelConfiguration_BedrockEmbeddingModelConfigurationIsNull = false;
            }
             // determine if requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_EmbeddingModelConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_EmbeddingModelConfiguration_BedrockEmbeddingModelConfiguration should be set to null
            if (requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_EmbeddingModelConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_EmbeddingModelConfiguration_BedrockEmbeddingModelConfigurationIsNull)
            {
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_EmbeddingModelConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_EmbeddingModelConfiguration_BedrockEmbeddingModelConfiguration = null;
            }
            if (requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_EmbeddingModelConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_EmbeddingModelConfiguration_BedrockEmbeddingModelConfiguration != null)
            {
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_EmbeddingModelConfiguration.BedrockEmbeddingModelConfiguration = requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_EmbeddingModelConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_EmbeddingModelConfiguration_BedrockEmbeddingModelConfiguration;
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_EmbeddingModelConfigurationIsNull = false;
            }
             // determine if requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_EmbeddingModelConfiguration should be set to null
            if (requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_EmbeddingModelConfigurationIsNull)
            {
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_EmbeddingModelConfiguration = null;
            }
            if (requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_EmbeddingModelConfiguration != null)
            {
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration.EmbeddingModelConfiguration = requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_EmbeddingModelConfiguration;
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfigurationIsNull = false;
            }
            Amazon.BedrockAgent.Model.SupplementalDataStorageConfiguration requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_SupplementalDataStorageConfiguration = null;
            
             // populate SupplementalDataStorageConfiguration
            var requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_SupplementalDataStorageConfigurationIsNull = true;
            requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_SupplementalDataStorageConfiguration = new Amazon.BedrockAgent.Model.SupplementalDataStorageConfiguration();
            List<Amazon.BedrockAgent.Model.SupplementalDataStorageLocation> requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_SupplementalDataStorageConfiguration_supplementalDataStorageConfiguration_StorageLocation = null;
            if (cmdletContext.SupplementalDataStorageConfiguration_StorageLocation != null)
            {
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_SupplementalDataStorageConfiguration_supplementalDataStorageConfiguration_StorageLocation = cmdletContext.SupplementalDataStorageConfiguration_StorageLocation;
            }
            if (requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_SupplementalDataStorageConfiguration_supplementalDataStorageConfiguration_StorageLocation != null)
            {
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_SupplementalDataStorageConfiguration.StorageLocations = requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_SupplementalDataStorageConfiguration_supplementalDataStorageConfiguration_StorageLocation;
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_SupplementalDataStorageConfigurationIsNull = false;
            }
             // determine if requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_SupplementalDataStorageConfiguration should be set to null
            if (requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_SupplementalDataStorageConfigurationIsNull)
            {
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_SupplementalDataStorageConfiguration = null;
            }
            if (requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_SupplementalDataStorageConfiguration != null)
            {
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration.SupplementalDataStorageConfiguration = requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_knowledgeBaseConfiguration_VectorKnowledgeBaseConfiguration_SupplementalDataStorageConfiguration;
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
            if (cmdletContext.KnowledgeBaseId != null)
            {
                request.KnowledgeBaseId = cmdletContext.KnowledgeBaseId;
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
            Amazon.BedrockAgent.Model.NeptuneAnalyticsConfiguration requestStorageConfiguration_storageConfiguration_NeptuneAnalyticsConfiguration = null;
            
             // populate NeptuneAnalyticsConfiguration
            var requestStorageConfiguration_storageConfiguration_NeptuneAnalyticsConfigurationIsNull = true;
            requestStorageConfiguration_storageConfiguration_NeptuneAnalyticsConfiguration = new Amazon.BedrockAgent.Model.NeptuneAnalyticsConfiguration();
            System.String requestStorageConfiguration_storageConfiguration_NeptuneAnalyticsConfiguration_neptuneAnalyticsConfiguration_GraphArn = null;
            if (cmdletContext.NeptuneAnalyticsConfiguration_GraphArn != null)
            {
                requestStorageConfiguration_storageConfiguration_NeptuneAnalyticsConfiguration_neptuneAnalyticsConfiguration_GraphArn = cmdletContext.NeptuneAnalyticsConfiguration_GraphArn;
            }
            if (requestStorageConfiguration_storageConfiguration_NeptuneAnalyticsConfiguration_neptuneAnalyticsConfiguration_GraphArn != null)
            {
                requestStorageConfiguration_storageConfiguration_NeptuneAnalyticsConfiguration.GraphArn = requestStorageConfiguration_storageConfiguration_NeptuneAnalyticsConfiguration_neptuneAnalyticsConfiguration_GraphArn;
                requestStorageConfiguration_storageConfiguration_NeptuneAnalyticsConfigurationIsNull = false;
            }
            Amazon.BedrockAgent.Model.NeptuneAnalyticsFieldMapping requestStorageConfiguration_storageConfiguration_NeptuneAnalyticsConfiguration_storageConfiguration_NeptuneAnalyticsConfiguration_FieldMapping = null;
            
             // populate FieldMapping
            var requestStorageConfiguration_storageConfiguration_NeptuneAnalyticsConfiguration_storageConfiguration_NeptuneAnalyticsConfiguration_FieldMappingIsNull = true;
            requestStorageConfiguration_storageConfiguration_NeptuneAnalyticsConfiguration_storageConfiguration_NeptuneAnalyticsConfiguration_FieldMapping = new Amazon.BedrockAgent.Model.NeptuneAnalyticsFieldMapping();
            System.String requestStorageConfiguration_storageConfiguration_NeptuneAnalyticsConfiguration_storageConfiguration_NeptuneAnalyticsConfiguration_FieldMapping_storageConfiguration_NeptuneAnalyticsConfiguration_FieldMapping_MetadataField = null;
            if (cmdletContext.StorageConfiguration_NeptuneAnalyticsConfiguration_FieldMapping_MetadataField != null)
            {
                requestStorageConfiguration_storageConfiguration_NeptuneAnalyticsConfiguration_storageConfiguration_NeptuneAnalyticsConfiguration_FieldMapping_storageConfiguration_NeptuneAnalyticsConfiguration_FieldMapping_MetadataField = cmdletContext.StorageConfiguration_NeptuneAnalyticsConfiguration_FieldMapping_MetadataField;
            }
            if (requestStorageConfiguration_storageConfiguration_NeptuneAnalyticsConfiguration_storageConfiguration_NeptuneAnalyticsConfiguration_FieldMapping_storageConfiguration_NeptuneAnalyticsConfiguration_FieldMapping_MetadataField != null)
            {
                requestStorageConfiguration_storageConfiguration_NeptuneAnalyticsConfiguration_storageConfiguration_NeptuneAnalyticsConfiguration_FieldMapping.MetadataField = requestStorageConfiguration_storageConfiguration_NeptuneAnalyticsConfiguration_storageConfiguration_NeptuneAnalyticsConfiguration_FieldMapping_storageConfiguration_NeptuneAnalyticsConfiguration_FieldMapping_MetadataField;
                requestStorageConfiguration_storageConfiguration_NeptuneAnalyticsConfiguration_storageConfiguration_NeptuneAnalyticsConfiguration_FieldMappingIsNull = false;
            }
            System.String requestStorageConfiguration_storageConfiguration_NeptuneAnalyticsConfiguration_storageConfiguration_NeptuneAnalyticsConfiguration_FieldMapping_storageConfiguration_NeptuneAnalyticsConfiguration_FieldMapping_TextField = null;
            if (cmdletContext.StorageConfiguration_NeptuneAnalyticsConfiguration_FieldMapping_TextField != null)
            {
                requestStorageConfiguration_storageConfiguration_NeptuneAnalyticsConfiguration_storageConfiguration_NeptuneAnalyticsConfiguration_FieldMapping_storageConfiguration_NeptuneAnalyticsConfiguration_FieldMapping_TextField = cmdletContext.StorageConfiguration_NeptuneAnalyticsConfiguration_FieldMapping_TextField;
            }
            if (requestStorageConfiguration_storageConfiguration_NeptuneAnalyticsConfiguration_storageConfiguration_NeptuneAnalyticsConfiguration_FieldMapping_storageConfiguration_NeptuneAnalyticsConfiguration_FieldMapping_TextField != null)
            {
                requestStorageConfiguration_storageConfiguration_NeptuneAnalyticsConfiguration_storageConfiguration_NeptuneAnalyticsConfiguration_FieldMapping.TextField = requestStorageConfiguration_storageConfiguration_NeptuneAnalyticsConfiguration_storageConfiguration_NeptuneAnalyticsConfiguration_FieldMapping_storageConfiguration_NeptuneAnalyticsConfiguration_FieldMapping_TextField;
                requestStorageConfiguration_storageConfiguration_NeptuneAnalyticsConfiguration_storageConfiguration_NeptuneAnalyticsConfiguration_FieldMappingIsNull = false;
            }
             // determine if requestStorageConfiguration_storageConfiguration_NeptuneAnalyticsConfiguration_storageConfiguration_NeptuneAnalyticsConfiguration_FieldMapping should be set to null
            if (requestStorageConfiguration_storageConfiguration_NeptuneAnalyticsConfiguration_storageConfiguration_NeptuneAnalyticsConfiguration_FieldMappingIsNull)
            {
                requestStorageConfiguration_storageConfiguration_NeptuneAnalyticsConfiguration_storageConfiguration_NeptuneAnalyticsConfiguration_FieldMapping = null;
            }
            if (requestStorageConfiguration_storageConfiguration_NeptuneAnalyticsConfiguration_storageConfiguration_NeptuneAnalyticsConfiguration_FieldMapping != null)
            {
                requestStorageConfiguration_storageConfiguration_NeptuneAnalyticsConfiguration.FieldMapping = requestStorageConfiguration_storageConfiguration_NeptuneAnalyticsConfiguration_storageConfiguration_NeptuneAnalyticsConfiguration_FieldMapping;
                requestStorageConfiguration_storageConfiguration_NeptuneAnalyticsConfigurationIsNull = false;
            }
             // determine if requestStorageConfiguration_storageConfiguration_NeptuneAnalyticsConfiguration should be set to null
            if (requestStorageConfiguration_storageConfiguration_NeptuneAnalyticsConfigurationIsNull)
            {
                requestStorageConfiguration_storageConfiguration_NeptuneAnalyticsConfiguration = null;
            }
            if (requestStorageConfiguration_storageConfiguration_NeptuneAnalyticsConfiguration != null)
            {
                request.StorageConfiguration.NeptuneAnalyticsConfiguration = requestStorageConfiguration_storageConfiguration_NeptuneAnalyticsConfiguration;
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
            Amazon.BedrockAgent.Model.S3VectorsConfiguration requestStorageConfiguration_storageConfiguration_S3VectorsConfiguration = null;
            
             // populate S3VectorsConfiguration
            var requestStorageConfiguration_storageConfiguration_S3VectorsConfigurationIsNull = true;
            requestStorageConfiguration_storageConfiguration_S3VectorsConfiguration = new Amazon.BedrockAgent.Model.S3VectorsConfiguration();
            System.String requestStorageConfiguration_storageConfiguration_S3VectorsConfiguration_s3VectorsConfiguration_IndexArn = null;
            if (cmdletContext.S3VectorsConfiguration_IndexArn != null)
            {
                requestStorageConfiguration_storageConfiguration_S3VectorsConfiguration_s3VectorsConfiguration_IndexArn = cmdletContext.S3VectorsConfiguration_IndexArn;
            }
            if (requestStorageConfiguration_storageConfiguration_S3VectorsConfiguration_s3VectorsConfiguration_IndexArn != null)
            {
                requestStorageConfiguration_storageConfiguration_S3VectorsConfiguration.IndexArn = requestStorageConfiguration_storageConfiguration_S3VectorsConfiguration_s3VectorsConfiguration_IndexArn;
                requestStorageConfiguration_storageConfiguration_S3VectorsConfigurationIsNull = false;
            }
            System.String requestStorageConfiguration_storageConfiguration_S3VectorsConfiguration_s3VectorsConfiguration_IndexName = null;
            if (cmdletContext.S3VectorsConfiguration_IndexName != null)
            {
                requestStorageConfiguration_storageConfiguration_S3VectorsConfiguration_s3VectorsConfiguration_IndexName = cmdletContext.S3VectorsConfiguration_IndexName;
            }
            if (requestStorageConfiguration_storageConfiguration_S3VectorsConfiguration_s3VectorsConfiguration_IndexName != null)
            {
                requestStorageConfiguration_storageConfiguration_S3VectorsConfiguration.IndexName = requestStorageConfiguration_storageConfiguration_S3VectorsConfiguration_s3VectorsConfiguration_IndexName;
                requestStorageConfiguration_storageConfiguration_S3VectorsConfigurationIsNull = false;
            }
            System.String requestStorageConfiguration_storageConfiguration_S3VectorsConfiguration_s3VectorsConfiguration_VectorBucketArn = null;
            if (cmdletContext.S3VectorsConfiguration_VectorBucketArn != null)
            {
                requestStorageConfiguration_storageConfiguration_S3VectorsConfiguration_s3VectorsConfiguration_VectorBucketArn = cmdletContext.S3VectorsConfiguration_VectorBucketArn;
            }
            if (requestStorageConfiguration_storageConfiguration_S3VectorsConfiguration_s3VectorsConfiguration_VectorBucketArn != null)
            {
                requestStorageConfiguration_storageConfiguration_S3VectorsConfiguration.VectorBucketArn = requestStorageConfiguration_storageConfiguration_S3VectorsConfiguration_s3VectorsConfiguration_VectorBucketArn;
                requestStorageConfiguration_storageConfiguration_S3VectorsConfigurationIsNull = false;
            }
             // determine if requestStorageConfiguration_storageConfiguration_S3VectorsConfiguration should be set to null
            if (requestStorageConfiguration_storageConfiguration_S3VectorsConfigurationIsNull)
            {
                requestStorageConfiguration_storageConfiguration_S3VectorsConfiguration = null;
            }
            if (requestStorageConfiguration_storageConfiguration_S3VectorsConfiguration != null)
            {
                request.StorageConfiguration.S3VectorsConfiguration = requestStorageConfiguration_storageConfiguration_S3VectorsConfiguration;
                requestStorageConfigurationIsNull = false;
            }
            Amazon.BedrockAgent.Model.OpenSearchManagedClusterConfiguration requestStorageConfiguration_storageConfiguration_OpensearchManagedClusterConfiguration = null;
            
             // populate OpensearchManagedClusterConfiguration
            var requestStorageConfiguration_storageConfiguration_OpensearchManagedClusterConfigurationIsNull = true;
            requestStorageConfiguration_storageConfiguration_OpensearchManagedClusterConfiguration = new Amazon.BedrockAgent.Model.OpenSearchManagedClusterConfiguration();
            System.String requestStorageConfiguration_storageConfiguration_OpensearchManagedClusterConfiguration_opensearchManagedClusterConfiguration_DomainArn = null;
            if (cmdletContext.OpensearchManagedClusterConfiguration_DomainArn != null)
            {
                requestStorageConfiguration_storageConfiguration_OpensearchManagedClusterConfiguration_opensearchManagedClusterConfiguration_DomainArn = cmdletContext.OpensearchManagedClusterConfiguration_DomainArn;
            }
            if (requestStorageConfiguration_storageConfiguration_OpensearchManagedClusterConfiguration_opensearchManagedClusterConfiguration_DomainArn != null)
            {
                requestStorageConfiguration_storageConfiguration_OpensearchManagedClusterConfiguration.DomainArn = requestStorageConfiguration_storageConfiguration_OpensearchManagedClusterConfiguration_opensearchManagedClusterConfiguration_DomainArn;
                requestStorageConfiguration_storageConfiguration_OpensearchManagedClusterConfigurationIsNull = false;
            }
            System.String requestStorageConfiguration_storageConfiguration_OpensearchManagedClusterConfiguration_opensearchManagedClusterConfiguration_DomainEndpoint = null;
            if (cmdletContext.OpensearchManagedClusterConfiguration_DomainEndpoint != null)
            {
                requestStorageConfiguration_storageConfiguration_OpensearchManagedClusterConfiguration_opensearchManagedClusterConfiguration_DomainEndpoint = cmdletContext.OpensearchManagedClusterConfiguration_DomainEndpoint;
            }
            if (requestStorageConfiguration_storageConfiguration_OpensearchManagedClusterConfiguration_opensearchManagedClusterConfiguration_DomainEndpoint != null)
            {
                requestStorageConfiguration_storageConfiguration_OpensearchManagedClusterConfiguration.DomainEndpoint = requestStorageConfiguration_storageConfiguration_OpensearchManagedClusterConfiguration_opensearchManagedClusterConfiguration_DomainEndpoint;
                requestStorageConfiguration_storageConfiguration_OpensearchManagedClusterConfigurationIsNull = false;
            }
            System.String requestStorageConfiguration_storageConfiguration_OpensearchManagedClusterConfiguration_opensearchManagedClusterConfiguration_VectorIndexName = null;
            if (cmdletContext.OpensearchManagedClusterConfiguration_VectorIndexName != null)
            {
                requestStorageConfiguration_storageConfiguration_OpensearchManagedClusterConfiguration_opensearchManagedClusterConfiguration_VectorIndexName = cmdletContext.OpensearchManagedClusterConfiguration_VectorIndexName;
            }
            if (requestStorageConfiguration_storageConfiguration_OpensearchManagedClusterConfiguration_opensearchManagedClusterConfiguration_VectorIndexName != null)
            {
                requestStorageConfiguration_storageConfiguration_OpensearchManagedClusterConfiguration.VectorIndexName = requestStorageConfiguration_storageConfiguration_OpensearchManagedClusterConfiguration_opensearchManagedClusterConfiguration_VectorIndexName;
                requestStorageConfiguration_storageConfiguration_OpensearchManagedClusterConfigurationIsNull = false;
            }
            Amazon.BedrockAgent.Model.OpenSearchManagedClusterFieldMapping requestStorageConfiguration_storageConfiguration_OpensearchManagedClusterConfiguration_storageConfiguration_OpensearchManagedClusterConfiguration_FieldMapping = null;
            
             // populate FieldMapping
            var requestStorageConfiguration_storageConfiguration_OpensearchManagedClusterConfiguration_storageConfiguration_OpensearchManagedClusterConfiguration_FieldMappingIsNull = true;
            requestStorageConfiguration_storageConfiguration_OpensearchManagedClusterConfiguration_storageConfiguration_OpensearchManagedClusterConfiguration_FieldMapping = new Amazon.BedrockAgent.Model.OpenSearchManagedClusterFieldMapping();
            System.String requestStorageConfiguration_storageConfiguration_OpensearchManagedClusterConfiguration_storageConfiguration_OpensearchManagedClusterConfiguration_FieldMapping_storageConfiguration_OpensearchManagedClusterConfiguration_FieldMapping_MetadataField = null;
            if (cmdletContext.StorageConfiguration_OpensearchManagedClusterConfiguration_FieldMapping_MetadataField != null)
            {
                requestStorageConfiguration_storageConfiguration_OpensearchManagedClusterConfiguration_storageConfiguration_OpensearchManagedClusterConfiguration_FieldMapping_storageConfiguration_OpensearchManagedClusterConfiguration_FieldMapping_MetadataField = cmdletContext.StorageConfiguration_OpensearchManagedClusterConfiguration_FieldMapping_MetadataField;
            }
            if (requestStorageConfiguration_storageConfiguration_OpensearchManagedClusterConfiguration_storageConfiguration_OpensearchManagedClusterConfiguration_FieldMapping_storageConfiguration_OpensearchManagedClusterConfiguration_FieldMapping_MetadataField != null)
            {
                requestStorageConfiguration_storageConfiguration_OpensearchManagedClusterConfiguration_storageConfiguration_OpensearchManagedClusterConfiguration_FieldMapping.MetadataField = requestStorageConfiguration_storageConfiguration_OpensearchManagedClusterConfiguration_storageConfiguration_OpensearchManagedClusterConfiguration_FieldMapping_storageConfiguration_OpensearchManagedClusterConfiguration_FieldMapping_MetadataField;
                requestStorageConfiguration_storageConfiguration_OpensearchManagedClusterConfiguration_storageConfiguration_OpensearchManagedClusterConfiguration_FieldMappingIsNull = false;
            }
            System.String requestStorageConfiguration_storageConfiguration_OpensearchManagedClusterConfiguration_storageConfiguration_OpensearchManagedClusterConfiguration_FieldMapping_storageConfiguration_OpensearchManagedClusterConfiguration_FieldMapping_TextField = null;
            if (cmdletContext.StorageConfiguration_OpensearchManagedClusterConfiguration_FieldMapping_TextField != null)
            {
                requestStorageConfiguration_storageConfiguration_OpensearchManagedClusterConfiguration_storageConfiguration_OpensearchManagedClusterConfiguration_FieldMapping_storageConfiguration_OpensearchManagedClusterConfiguration_FieldMapping_TextField = cmdletContext.StorageConfiguration_OpensearchManagedClusterConfiguration_FieldMapping_TextField;
            }
            if (requestStorageConfiguration_storageConfiguration_OpensearchManagedClusterConfiguration_storageConfiguration_OpensearchManagedClusterConfiguration_FieldMapping_storageConfiguration_OpensearchManagedClusterConfiguration_FieldMapping_TextField != null)
            {
                requestStorageConfiguration_storageConfiguration_OpensearchManagedClusterConfiguration_storageConfiguration_OpensearchManagedClusterConfiguration_FieldMapping.TextField = requestStorageConfiguration_storageConfiguration_OpensearchManagedClusterConfiguration_storageConfiguration_OpensearchManagedClusterConfiguration_FieldMapping_storageConfiguration_OpensearchManagedClusterConfiguration_FieldMapping_TextField;
                requestStorageConfiguration_storageConfiguration_OpensearchManagedClusterConfiguration_storageConfiguration_OpensearchManagedClusterConfiguration_FieldMappingIsNull = false;
            }
            System.String requestStorageConfiguration_storageConfiguration_OpensearchManagedClusterConfiguration_storageConfiguration_OpensearchManagedClusterConfiguration_FieldMapping_storageConfiguration_OpensearchManagedClusterConfiguration_FieldMapping_VectorField = null;
            if (cmdletContext.StorageConfiguration_OpensearchManagedClusterConfiguration_FieldMapping_VectorField != null)
            {
                requestStorageConfiguration_storageConfiguration_OpensearchManagedClusterConfiguration_storageConfiguration_OpensearchManagedClusterConfiguration_FieldMapping_storageConfiguration_OpensearchManagedClusterConfiguration_FieldMapping_VectorField = cmdletContext.StorageConfiguration_OpensearchManagedClusterConfiguration_FieldMapping_VectorField;
            }
            if (requestStorageConfiguration_storageConfiguration_OpensearchManagedClusterConfiguration_storageConfiguration_OpensearchManagedClusterConfiguration_FieldMapping_storageConfiguration_OpensearchManagedClusterConfiguration_FieldMapping_VectorField != null)
            {
                requestStorageConfiguration_storageConfiguration_OpensearchManagedClusterConfiguration_storageConfiguration_OpensearchManagedClusterConfiguration_FieldMapping.VectorField = requestStorageConfiguration_storageConfiguration_OpensearchManagedClusterConfiguration_storageConfiguration_OpensearchManagedClusterConfiguration_FieldMapping_storageConfiguration_OpensearchManagedClusterConfiguration_FieldMapping_VectorField;
                requestStorageConfiguration_storageConfiguration_OpensearchManagedClusterConfiguration_storageConfiguration_OpensearchManagedClusterConfiguration_FieldMappingIsNull = false;
            }
             // determine if requestStorageConfiguration_storageConfiguration_OpensearchManagedClusterConfiguration_storageConfiguration_OpensearchManagedClusterConfiguration_FieldMapping should be set to null
            if (requestStorageConfiguration_storageConfiguration_OpensearchManagedClusterConfiguration_storageConfiguration_OpensearchManagedClusterConfiguration_FieldMappingIsNull)
            {
                requestStorageConfiguration_storageConfiguration_OpensearchManagedClusterConfiguration_storageConfiguration_OpensearchManagedClusterConfiguration_FieldMapping = null;
            }
            if (requestStorageConfiguration_storageConfiguration_OpensearchManagedClusterConfiguration_storageConfiguration_OpensearchManagedClusterConfiguration_FieldMapping != null)
            {
                requestStorageConfiguration_storageConfiguration_OpensearchManagedClusterConfiguration.FieldMapping = requestStorageConfiguration_storageConfiguration_OpensearchManagedClusterConfiguration_storageConfiguration_OpensearchManagedClusterConfiguration_FieldMapping;
                requestStorageConfiguration_storageConfiguration_OpensearchManagedClusterConfigurationIsNull = false;
            }
             // determine if requestStorageConfiguration_storageConfiguration_OpensearchManagedClusterConfiguration should be set to null
            if (requestStorageConfiguration_storageConfiguration_OpensearchManagedClusterConfigurationIsNull)
            {
                requestStorageConfiguration_storageConfiguration_OpensearchManagedClusterConfiguration = null;
            }
            if (requestStorageConfiguration_storageConfiguration_OpensearchManagedClusterConfiguration != null)
            {
                request.StorageConfiguration.OpensearchManagedClusterConfiguration = requestStorageConfiguration_storageConfiguration_OpensearchManagedClusterConfiguration;
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
            System.String requestStorageConfiguration_storageConfiguration_RdsConfiguration_storageConfiguration_RdsConfiguration_FieldMapping_fieldMapping_CustomMetadataField = null;
            if (cmdletContext.FieldMapping_CustomMetadataField != null)
            {
                requestStorageConfiguration_storageConfiguration_RdsConfiguration_storageConfiguration_RdsConfiguration_FieldMapping_fieldMapping_CustomMetadataField = cmdletContext.FieldMapping_CustomMetadataField;
            }
            if (requestStorageConfiguration_storageConfiguration_RdsConfiguration_storageConfiguration_RdsConfiguration_FieldMapping_fieldMapping_CustomMetadataField != null)
            {
                requestStorageConfiguration_storageConfiguration_RdsConfiguration_storageConfiguration_RdsConfiguration_FieldMapping.CustomMetadataField = requestStorageConfiguration_storageConfiguration_RdsConfiguration_storageConfiguration_RdsConfiguration_FieldMapping_fieldMapping_CustomMetadataField;
                requestStorageConfiguration_storageConfiguration_RdsConfiguration_storageConfiguration_RdsConfiguration_FieldMappingIsNull = false;
            }
            System.String requestStorageConfiguration_storageConfiguration_RdsConfiguration_storageConfiguration_RdsConfiguration_FieldMapping_storageConfiguration_RdsConfiguration_FieldMapping_MetadataField = null;
            if (cmdletContext.StorageConfiguration_RdsConfiguration_FieldMapping_MetadataField != null)
            {
                requestStorageConfiguration_storageConfiguration_RdsConfiguration_storageConfiguration_RdsConfiguration_FieldMapping_storageConfiguration_RdsConfiguration_FieldMapping_MetadataField = cmdletContext.StorageConfiguration_RdsConfiguration_FieldMapping_MetadataField;
            }
            if (requestStorageConfiguration_storageConfiguration_RdsConfiguration_storageConfiguration_RdsConfiguration_FieldMapping_storageConfiguration_RdsConfiguration_FieldMapping_MetadataField != null)
            {
                requestStorageConfiguration_storageConfiguration_RdsConfiguration_storageConfiguration_RdsConfiguration_FieldMapping.MetadataField = requestStorageConfiguration_storageConfiguration_RdsConfiguration_storageConfiguration_RdsConfiguration_FieldMapping_storageConfiguration_RdsConfiguration_FieldMapping_MetadataField;
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
            System.String requestStorageConfiguration_storageConfiguration_RdsConfiguration_storageConfiguration_RdsConfiguration_FieldMapping_storageConfiguration_RdsConfiguration_FieldMapping_TextField = null;
            if (cmdletContext.StorageConfiguration_RdsConfiguration_FieldMapping_TextField != null)
            {
                requestStorageConfiguration_storageConfiguration_RdsConfiguration_storageConfiguration_RdsConfiguration_FieldMapping_storageConfiguration_RdsConfiguration_FieldMapping_TextField = cmdletContext.StorageConfiguration_RdsConfiguration_FieldMapping_TextField;
            }
            if (requestStorageConfiguration_storageConfiguration_RdsConfiguration_storageConfiguration_RdsConfiguration_FieldMapping_storageConfiguration_RdsConfiguration_FieldMapping_TextField != null)
            {
                requestStorageConfiguration_storageConfiguration_RdsConfiguration_storageConfiguration_RdsConfiguration_FieldMapping.TextField = requestStorageConfiguration_storageConfiguration_RdsConfiguration_storageConfiguration_RdsConfiguration_FieldMapping_storageConfiguration_RdsConfiguration_FieldMapping_TextField;
                requestStorageConfiguration_storageConfiguration_RdsConfiguration_storageConfiguration_RdsConfiguration_FieldMappingIsNull = false;
            }
            System.String requestStorageConfiguration_storageConfiguration_RdsConfiguration_storageConfiguration_RdsConfiguration_FieldMapping_storageConfiguration_RdsConfiguration_FieldMapping_VectorField = null;
            if (cmdletContext.StorageConfiguration_RdsConfiguration_FieldMapping_VectorField != null)
            {
                requestStorageConfiguration_storageConfiguration_RdsConfiguration_storageConfiguration_RdsConfiguration_FieldMapping_storageConfiguration_RdsConfiguration_FieldMapping_VectorField = cmdletContext.StorageConfiguration_RdsConfiguration_FieldMapping_VectorField;
            }
            if (requestStorageConfiguration_storageConfiguration_RdsConfiguration_storageConfiguration_RdsConfiguration_FieldMapping_storageConfiguration_RdsConfiguration_FieldMapping_VectorField != null)
            {
                requestStorageConfiguration_storageConfiguration_RdsConfiguration_storageConfiguration_RdsConfiguration_FieldMapping.VectorField = requestStorageConfiguration_storageConfiguration_RdsConfiguration_storageConfiguration_RdsConfiguration_FieldMapping_storageConfiguration_RdsConfiguration_FieldMapping_VectorField;
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
            Amazon.BedrockAgent.Model.MongoDbAtlasConfiguration requestStorageConfiguration_storageConfiguration_MongoDbAtlasConfiguration = null;
            
             // populate MongoDbAtlasConfiguration
            var requestStorageConfiguration_storageConfiguration_MongoDbAtlasConfigurationIsNull = true;
            requestStorageConfiguration_storageConfiguration_MongoDbAtlasConfiguration = new Amazon.BedrockAgent.Model.MongoDbAtlasConfiguration();
            System.String requestStorageConfiguration_storageConfiguration_MongoDbAtlasConfiguration_mongoDbAtlasConfiguration_CollectionName = null;
            if (cmdletContext.MongoDbAtlasConfiguration_CollectionName != null)
            {
                requestStorageConfiguration_storageConfiguration_MongoDbAtlasConfiguration_mongoDbAtlasConfiguration_CollectionName = cmdletContext.MongoDbAtlasConfiguration_CollectionName;
            }
            if (requestStorageConfiguration_storageConfiguration_MongoDbAtlasConfiguration_mongoDbAtlasConfiguration_CollectionName != null)
            {
                requestStorageConfiguration_storageConfiguration_MongoDbAtlasConfiguration.CollectionName = requestStorageConfiguration_storageConfiguration_MongoDbAtlasConfiguration_mongoDbAtlasConfiguration_CollectionName;
                requestStorageConfiguration_storageConfiguration_MongoDbAtlasConfigurationIsNull = false;
            }
            System.String requestStorageConfiguration_storageConfiguration_MongoDbAtlasConfiguration_mongoDbAtlasConfiguration_CredentialsSecretArn = null;
            if (cmdletContext.MongoDbAtlasConfiguration_CredentialsSecretArn != null)
            {
                requestStorageConfiguration_storageConfiguration_MongoDbAtlasConfiguration_mongoDbAtlasConfiguration_CredentialsSecretArn = cmdletContext.MongoDbAtlasConfiguration_CredentialsSecretArn;
            }
            if (requestStorageConfiguration_storageConfiguration_MongoDbAtlasConfiguration_mongoDbAtlasConfiguration_CredentialsSecretArn != null)
            {
                requestStorageConfiguration_storageConfiguration_MongoDbAtlasConfiguration.CredentialsSecretArn = requestStorageConfiguration_storageConfiguration_MongoDbAtlasConfiguration_mongoDbAtlasConfiguration_CredentialsSecretArn;
                requestStorageConfiguration_storageConfiguration_MongoDbAtlasConfigurationIsNull = false;
            }
            System.String requestStorageConfiguration_storageConfiguration_MongoDbAtlasConfiguration_mongoDbAtlasConfiguration_DatabaseName = null;
            if (cmdletContext.MongoDbAtlasConfiguration_DatabaseName != null)
            {
                requestStorageConfiguration_storageConfiguration_MongoDbAtlasConfiguration_mongoDbAtlasConfiguration_DatabaseName = cmdletContext.MongoDbAtlasConfiguration_DatabaseName;
            }
            if (requestStorageConfiguration_storageConfiguration_MongoDbAtlasConfiguration_mongoDbAtlasConfiguration_DatabaseName != null)
            {
                requestStorageConfiguration_storageConfiguration_MongoDbAtlasConfiguration.DatabaseName = requestStorageConfiguration_storageConfiguration_MongoDbAtlasConfiguration_mongoDbAtlasConfiguration_DatabaseName;
                requestStorageConfiguration_storageConfiguration_MongoDbAtlasConfigurationIsNull = false;
            }
            System.String requestStorageConfiguration_storageConfiguration_MongoDbAtlasConfiguration_mongoDbAtlasConfiguration_Endpoint = null;
            if (cmdletContext.MongoDbAtlasConfiguration_Endpoint != null)
            {
                requestStorageConfiguration_storageConfiguration_MongoDbAtlasConfiguration_mongoDbAtlasConfiguration_Endpoint = cmdletContext.MongoDbAtlasConfiguration_Endpoint;
            }
            if (requestStorageConfiguration_storageConfiguration_MongoDbAtlasConfiguration_mongoDbAtlasConfiguration_Endpoint != null)
            {
                requestStorageConfiguration_storageConfiguration_MongoDbAtlasConfiguration.Endpoint = requestStorageConfiguration_storageConfiguration_MongoDbAtlasConfiguration_mongoDbAtlasConfiguration_Endpoint;
                requestStorageConfiguration_storageConfiguration_MongoDbAtlasConfigurationIsNull = false;
            }
            System.String requestStorageConfiguration_storageConfiguration_MongoDbAtlasConfiguration_mongoDbAtlasConfiguration_EndpointServiceName = null;
            if (cmdletContext.MongoDbAtlasConfiguration_EndpointServiceName != null)
            {
                requestStorageConfiguration_storageConfiguration_MongoDbAtlasConfiguration_mongoDbAtlasConfiguration_EndpointServiceName = cmdletContext.MongoDbAtlasConfiguration_EndpointServiceName;
            }
            if (requestStorageConfiguration_storageConfiguration_MongoDbAtlasConfiguration_mongoDbAtlasConfiguration_EndpointServiceName != null)
            {
                requestStorageConfiguration_storageConfiguration_MongoDbAtlasConfiguration.EndpointServiceName = requestStorageConfiguration_storageConfiguration_MongoDbAtlasConfiguration_mongoDbAtlasConfiguration_EndpointServiceName;
                requestStorageConfiguration_storageConfiguration_MongoDbAtlasConfigurationIsNull = false;
            }
            System.String requestStorageConfiguration_storageConfiguration_MongoDbAtlasConfiguration_mongoDbAtlasConfiguration_TextIndexName = null;
            if (cmdletContext.MongoDbAtlasConfiguration_TextIndexName != null)
            {
                requestStorageConfiguration_storageConfiguration_MongoDbAtlasConfiguration_mongoDbAtlasConfiguration_TextIndexName = cmdletContext.MongoDbAtlasConfiguration_TextIndexName;
            }
            if (requestStorageConfiguration_storageConfiguration_MongoDbAtlasConfiguration_mongoDbAtlasConfiguration_TextIndexName != null)
            {
                requestStorageConfiguration_storageConfiguration_MongoDbAtlasConfiguration.TextIndexName = requestStorageConfiguration_storageConfiguration_MongoDbAtlasConfiguration_mongoDbAtlasConfiguration_TextIndexName;
                requestStorageConfiguration_storageConfiguration_MongoDbAtlasConfigurationIsNull = false;
            }
            System.String requestStorageConfiguration_storageConfiguration_MongoDbAtlasConfiguration_mongoDbAtlasConfiguration_VectorIndexName = null;
            if (cmdletContext.MongoDbAtlasConfiguration_VectorIndexName != null)
            {
                requestStorageConfiguration_storageConfiguration_MongoDbAtlasConfiguration_mongoDbAtlasConfiguration_VectorIndexName = cmdletContext.MongoDbAtlasConfiguration_VectorIndexName;
            }
            if (requestStorageConfiguration_storageConfiguration_MongoDbAtlasConfiguration_mongoDbAtlasConfiguration_VectorIndexName != null)
            {
                requestStorageConfiguration_storageConfiguration_MongoDbAtlasConfiguration.VectorIndexName = requestStorageConfiguration_storageConfiguration_MongoDbAtlasConfiguration_mongoDbAtlasConfiguration_VectorIndexName;
                requestStorageConfiguration_storageConfiguration_MongoDbAtlasConfigurationIsNull = false;
            }
            Amazon.BedrockAgent.Model.MongoDbAtlasFieldMapping requestStorageConfiguration_storageConfiguration_MongoDbAtlasConfiguration_storageConfiguration_MongoDbAtlasConfiguration_FieldMapping = null;
            
             // populate FieldMapping
            var requestStorageConfiguration_storageConfiguration_MongoDbAtlasConfiguration_storageConfiguration_MongoDbAtlasConfiguration_FieldMappingIsNull = true;
            requestStorageConfiguration_storageConfiguration_MongoDbAtlasConfiguration_storageConfiguration_MongoDbAtlasConfiguration_FieldMapping = new Amazon.BedrockAgent.Model.MongoDbAtlasFieldMapping();
            System.String requestStorageConfiguration_storageConfiguration_MongoDbAtlasConfiguration_storageConfiguration_MongoDbAtlasConfiguration_FieldMapping_storageConfiguration_MongoDbAtlasConfiguration_FieldMapping_MetadataField = null;
            if (cmdletContext.StorageConfiguration_MongoDbAtlasConfiguration_FieldMapping_MetadataField != null)
            {
                requestStorageConfiguration_storageConfiguration_MongoDbAtlasConfiguration_storageConfiguration_MongoDbAtlasConfiguration_FieldMapping_storageConfiguration_MongoDbAtlasConfiguration_FieldMapping_MetadataField = cmdletContext.StorageConfiguration_MongoDbAtlasConfiguration_FieldMapping_MetadataField;
            }
            if (requestStorageConfiguration_storageConfiguration_MongoDbAtlasConfiguration_storageConfiguration_MongoDbAtlasConfiguration_FieldMapping_storageConfiguration_MongoDbAtlasConfiguration_FieldMapping_MetadataField != null)
            {
                requestStorageConfiguration_storageConfiguration_MongoDbAtlasConfiguration_storageConfiguration_MongoDbAtlasConfiguration_FieldMapping.MetadataField = requestStorageConfiguration_storageConfiguration_MongoDbAtlasConfiguration_storageConfiguration_MongoDbAtlasConfiguration_FieldMapping_storageConfiguration_MongoDbAtlasConfiguration_FieldMapping_MetadataField;
                requestStorageConfiguration_storageConfiguration_MongoDbAtlasConfiguration_storageConfiguration_MongoDbAtlasConfiguration_FieldMappingIsNull = false;
            }
            System.String requestStorageConfiguration_storageConfiguration_MongoDbAtlasConfiguration_storageConfiguration_MongoDbAtlasConfiguration_FieldMapping_storageConfiguration_MongoDbAtlasConfiguration_FieldMapping_TextField = null;
            if (cmdletContext.StorageConfiguration_MongoDbAtlasConfiguration_FieldMapping_TextField != null)
            {
                requestStorageConfiguration_storageConfiguration_MongoDbAtlasConfiguration_storageConfiguration_MongoDbAtlasConfiguration_FieldMapping_storageConfiguration_MongoDbAtlasConfiguration_FieldMapping_TextField = cmdletContext.StorageConfiguration_MongoDbAtlasConfiguration_FieldMapping_TextField;
            }
            if (requestStorageConfiguration_storageConfiguration_MongoDbAtlasConfiguration_storageConfiguration_MongoDbAtlasConfiguration_FieldMapping_storageConfiguration_MongoDbAtlasConfiguration_FieldMapping_TextField != null)
            {
                requestStorageConfiguration_storageConfiguration_MongoDbAtlasConfiguration_storageConfiguration_MongoDbAtlasConfiguration_FieldMapping.TextField = requestStorageConfiguration_storageConfiguration_MongoDbAtlasConfiguration_storageConfiguration_MongoDbAtlasConfiguration_FieldMapping_storageConfiguration_MongoDbAtlasConfiguration_FieldMapping_TextField;
                requestStorageConfiguration_storageConfiguration_MongoDbAtlasConfiguration_storageConfiguration_MongoDbAtlasConfiguration_FieldMappingIsNull = false;
            }
            System.String requestStorageConfiguration_storageConfiguration_MongoDbAtlasConfiguration_storageConfiguration_MongoDbAtlasConfiguration_FieldMapping_storageConfiguration_MongoDbAtlasConfiguration_FieldMapping_VectorField = null;
            if (cmdletContext.StorageConfiguration_MongoDbAtlasConfiguration_FieldMapping_VectorField != null)
            {
                requestStorageConfiguration_storageConfiguration_MongoDbAtlasConfiguration_storageConfiguration_MongoDbAtlasConfiguration_FieldMapping_storageConfiguration_MongoDbAtlasConfiguration_FieldMapping_VectorField = cmdletContext.StorageConfiguration_MongoDbAtlasConfiguration_FieldMapping_VectorField;
            }
            if (requestStorageConfiguration_storageConfiguration_MongoDbAtlasConfiguration_storageConfiguration_MongoDbAtlasConfiguration_FieldMapping_storageConfiguration_MongoDbAtlasConfiguration_FieldMapping_VectorField != null)
            {
                requestStorageConfiguration_storageConfiguration_MongoDbAtlasConfiguration_storageConfiguration_MongoDbAtlasConfiguration_FieldMapping.VectorField = requestStorageConfiguration_storageConfiguration_MongoDbAtlasConfiguration_storageConfiguration_MongoDbAtlasConfiguration_FieldMapping_storageConfiguration_MongoDbAtlasConfiguration_FieldMapping_VectorField;
                requestStorageConfiguration_storageConfiguration_MongoDbAtlasConfiguration_storageConfiguration_MongoDbAtlasConfiguration_FieldMappingIsNull = false;
            }
             // determine if requestStorageConfiguration_storageConfiguration_MongoDbAtlasConfiguration_storageConfiguration_MongoDbAtlasConfiguration_FieldMapping should be set to null
            if (requestStorageConfiguration_storageConfiguration_MongoDbAtlasConfiguration_storageConfiguration_MongoDbAtlasConfiguration_FieldMappingIsNull)
            {
                requestStorageConfiguration_storageConfiguration_MongoDbAtlasConfiguration_storageConfiguration_MongoDbAtlasConfiguration_FieldMapping = null;
            }
            if (requestStorageConfiguration_storageConfiguration_MongoDbAtlasConfiguration_storageConfiguration_MongoDbAtlasConfiguration_FieldMapping != null)
            {
                requestStorageConfiguration_storageConfiguration_MongoDbAtlasConfiguration.FieldMapping = requestStorageConfiguration_storageConfiguration_MongoDbAtlasConfiguration_storageConfiguration_MongoDbAtlasConfiguration_FieldMapping;
                requestStorageConfiguration_storageConfiguration_MongoDbAtlasConfigurationIsNull = false;
            }
             // determine if requestStorageConfiguration_storageConfiguration_MongoDbAtlasConfiguration should be set to null
            if (requestStorageConfiguration_storageConfiguration_MongoDbAtlasConfigurationIsNull)
            {
                requestStorageConfiguration_storageConfiguration_MongoDbAtlasConfiguration = null;
            }
            if (requestStorageConfiguration_storageConfiguration_MongoDbAtlasConfiguration != null)
            {
                request.StorageConfiguration.MongoDbAtlasConfiguration = requestStorageConfiguration_storageConfiguration_MongoDbAtlasConfiguration;
                requestStorageConfigurationIsNull = false;
            }
             // determine if request.StorageConfiguration should be set to null
            if (requestStorageConfigurationIsNull)
            {
                request.StorageConfiguration = null;
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
        
        private Amazon.BedrockAgent.Model.UpdateKnowledgeBaseResponse CallAWSServiceOperation(IAmazonBedrockAgent client, Amazon.BedrockAgent.Model.UpdateKnowledgeBaseRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Agents for Amazon Bedrock", "UpdateKnowledgeBase");
            try
            {
                return client.UpdateKnowledgeBaseAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String KendraKnowledgeBaseConfiguration_KendraIndexArn { get; set; }
            public System.String AuthConfiguration_DatabaseUser { get; set; }
            public Amazon.BedrockAgent.RedshiftProvisionedAuthType KnowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_AuthConfiguration_Type { get; set; }
            public System.String KnowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_AuthConfiguration_UsernamePasswordSecretArn { get; set; }
            public System.String ProvisionedConfiguration_ClusterIdentifier { get; set; }
            public Amazon.BedrockAgent.RedshiftServerlessAuthType AuthConfiguration_Type { get; set; }
            public System.String AuthConfiguration_UsernamePasswordSecretArn { get; set; }
            public System.String ServerlessConfiguration_WorkgroupArn { get; set; }
            public Amazon.BedrockAgent.RedshiftQueryEngineType QueryEngineConfiguration_Type { get; set; }
            public System.Int32? QueryGenerationConfiguration_ExecutionTimeoutSecond { get; set; }
            public List<Amazon.BedrockAgent.Model.CuratedQuery> GenerationContext_CuratedQuery { get; set; }
            public List<Amazon.BedrockAgent.Model.QueryGenerationTable> GenerationContext_Table { get; set; }
            public List<Amazon.BedrockAgent.Model.RedshiftQueryEngineStorageConfiguration> RedshiftConfiguration_StorageConfiguration { get; set; }
            public Amazon.BedrockAgent.QueryEngineType SqlKnowledgeBaseConfiguration_Type { get; set; }
            public Amazon.BedrockAgent.KnowledgeBaseType KnowledgeBaseConfiguration_Type { get; set; }
            public System.String VectorKnowledgeBaseConfiguration_EmbeddingModelArn { get; set; }
            public List<Amazon.BedrockAgent.Model.AudioConfiguration> BedrockEmbeddingModelConfiguration_Audio { get; set; }
            public System.Int32? BedrockEmbeddingModelConfiguration_Dimension { get; set; }
            public Amazon.BedrockAgent.EmbeddingDataType BedrockEmbeddingModelConfiguration_EmbeddingDataType { get; set; }
            public List<Amazon.BedrockAgent.Model.VideoConfiguration> BedrockEmbeddingModelConfiguration_Video { get; set; }
            public List<Amazon.BedrockAgent.Model.SupplementalDataStorageLocation> SupplementalDataStorageConfiguration_StorageLocation { get; set; }
            public System.String KnowledgeBaseId { get; set; }
            public System.String Name { get; set; }
            public System.String RoleArn { get; set; }
            public System.String MongoDbAtlasConfiguration_CollectionName { get; set; }
            public System.String MongoDbAtlasConfiguration_CredentialsSecretArn { get; set; }
            public System.String MongoDbAtlasConfiguration_DatabaseName { get; set; }
            public System.String MongoDbAtlasConfiguration_Endpoint { get; set; }
            public System.String MongoDbAtlasConfiguration_EndpointServiceName { get; set; }
            public System.String StorageConfiguration_MongoDbAtlasConfiguration_FieldMapping_MetadataField { get; set; }
            public System.String StorageConfiguration_MongoDbAtlasConfiguration_FieldMapping_TextField { get; set; }
            public System.String StorageConfiguration_MongoDbAtlasConfiguration_FieldMapping_VectorField { get; set; }
            public System.String MongoDbAtlasConfiguration_TextIndexName { get; set; }
            public System.String MongoDbAtlasConfiguration_VectorIndexName { get; set; }
            public System.String StorageConfiguration_NeptuneAnalyticsConfiguration_FieldMapping_MetadataField { get; set; }
            public System.String StorageConfiguration_NeptuneAnalyticsConfiguration_FieldMapping_TextField { get; set; }
            public System.String NeptuneAnalyticsConfiguration_GraphArn { get; set; }
            public System.String OpensearchManagedClusterConfiguration_DomainArn { get; set; }
            public System.String OpensearchManagedClusterConfiguration_DomainEndpoint { get; set; }
            public System.String StorageConfiguration_OpensearchManagedClusterConfiguration_FieldMapping_MetadataField { get; set; }
            public System.String StorageConfiguration_OpensearchManagedClusterConfiguration_FieldMapping_TextField { get; set; }
            public System.String StorageConfiguration_OpensearchManagedClusterConfiguration_FieldMapping_VectorField { get; set; }
            public System.String OpensearchManagedClusterConfiguration_VectorIndexName { get; set; }
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
            public System.String FieldMapping_CustomMetadataField { get; set; }
            public System.String StorageConfiguration_RdsConfiguration_FieldMapping_MetadataField { get; set; }
            public System.String FieldMapping_PrimaryKeyField { get; set; }
            public System.String StorageConfiguration_RdsConfiguration_FieldMapping_TextField { get; set; }
            public System.String StorageConfiguration_RdsConfiguration_FieldMapping_VectorField { get; set; }
            public System.String RdsConfiguration_ResourceArn { get; set; }
            public System.String RdsConfiguration_TableName { get; set; }
            public System.String RedisEnterpriseCloudConfiguration_CredentialsSecretArn { get; set; }
            public System.String RedisEnterpriseCloudConfiguration_Endpoint { get; set; }
            public System.String StorageConfiguration_RedisEnterpriseCloudConfiguration_FieldMapping_MetadataField { get; set; }
            public System.String StorageConfiguration_RedisEnterpriseCloudConfiguration_FieldMapping_TextField { get; set; }
            public System.String StorageConfiguration_RedisEnterpriseCloudConfiguration_FieldMapping_VectorField { get; set; }
            public System.String RedisEnterpriseCloudConfiguration_VectorIndexName { get; set; }
            public System.String S3VectorsConfiguration_IndexArn { get; set; }
            public System.String S3VectorsConfiguration_IndexName { get; set; }
            public System.String S3VectorsConfiguration_VectorBucketArn { get; set; }
            public Amazon.BedrockAgent.KnowledgeBaseStorageType StorageConfiguration_Type { get; set; }
            public System.Func<Amazon.BedrockAgent.Model.UpdateKnowledgeBaseResponse, UpdateAABKnowledgeBaseCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.KnowledgeBase;
        }
        
    }
}
