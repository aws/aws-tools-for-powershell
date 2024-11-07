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
using Amazon.QuickSight;
using Amazon.QuickSight.Model;

namespace Amazon.PowerShell.Cmdlets.QS
{
    /// <summary>
    /// Creates a data source.
    /// </summary>
    [Cmdlet("New", "QSDataSource", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.QuickSight.Model.CreateDataSourceResponse")]
    [AWSCmdlet("Calls the Amazon QuickSight CreateDataSource API operation.", Operation = new[] {"CreateDataSource"}, SelectReturnType = typeof(Amazon.QuickSight.Model.CreateDataSourceResponse))]
    [AWSCmdletOutput("Amazon.QuickSight.Model.CreateDataSourceResponse",
        "This cmdlet returns an Amazon.QuickSight.Model.CreateDataSourceResponse object containing multiple properties."
    )]
    public partial class NewQSDataSourceCmdlet : AmazonQuickSightClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CredentialPair_AlternateDataSourceParameter
        /// <summary>
        /// <para>
        /// <para>A set of alternate data source parameters that you want to share for these credentials.
        /// The credentials are applied in tandem with the data source parameters when you copy
        /// a data source by using a create or update request. The API operation compares the
        /// <c>DataSourceParameters</c> structure that's in the request with the structures in
        /// the <c>AlternateDataSourceParameters</c> allow list. If the structures are an exact
        /// match, the request is allowed to use the new data source with the existing credentials.
        /// If the <c>AlternateDataSourceParameters</c> list is null, the <c>DataSourceParameters</c>
        /// originally used with these <c>Credentials</c> is automatically allowed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Credentials_CredentialPair_AlternateDataSourceParameters")]
        public Amazon.QuickSight.Model.DataSourceParameters[] CredentialPair_AlternateDataSourceParameter { get; set; }
        #endregion
        
        #region Parameter SnowflakeParameters_AuthenticationType
        /// <summary>
        /// <para>
        /// <para>The authentication type that you want to use for your connection. This parameter accepts
        /// OAuth and non-OAuth authentication types.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceParameters_SnowflakeParameters_AuthenticationType")]
        [AWSConstantClassSource("Amazon.QuickSight.AuthenticationType")]
        public Amazon.QuickSight.AuthenticationType SnowflakeParameters_AuthenticationType { get; set; }
        #endregion
        
        #region Parameter StarburstParameters_AuthenticationType
        /// <summary>
        /// <para>
        /// <para>The authentication type that you want to use for your connection. This parameter accepts
        /// OAuth and non-OAuth authentication types.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceParameters_StarburstParameters_AuthenticationType")]
        [AWSConstantClassSource("Amazon.QuickSight.AuthenticationType")]
        public Amazon.QuickSight.AuthenticationType StarburstParameters_AuthenticationType { get; set; }
        #endregion
        
        #region Parameter IAMParameters_AutoCreateDatabaseUser
        /// <summary>
        /// <para>
        /// <para>Automatically creates a database user. If your database doesn't have a <c>DatabaseUser</c>,
        /// set this parameter to <c>True</c>. If there is no <c>DatabaseUser</c>, Amazon QuickSight
        /// can't connect to your cluster. The <c>RoleArn</c> that you use for this operation
        /// must grant access to <c>redshift:CreateClusterUser</c> to successfully create the
        /// user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceParameters_RedshiftParameters_IAMParameters_AutoCreateDatabaseUser")]
        public System.Boolean? IAMParameters_AutoCreateDatabaseUser { get; set; }
        #endregion
        
        #region Parameter AwsAccountId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account ID.</para>
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
        public System.String AwsAccountId { get; set; }
        #endregion
        
        #region Parameter ManifestFileLocation_Bucket
        /// <summary>
        /// <para>
        /// <para>Amazon S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceParameters_S3Parameters_ManifestFileLocation_Bucket")]
        public System.String ManifestFileLocation_Bucket { get; set; }
        #endregion
        
        #region Parameter PrestoParameters_Catalog
        /// <summary>
        /// <para>
        /// <para>Catalog.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceParameters_PrestoParameters_Catalog")]
        public System.String PrestoParameters_Catalog { get; set; }
        #endregion
        
        #region Parameter StarburstParameters_Catalog
        /// <summary>
        /// <para>
        /// <para>The catalog name for the Starburst data source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceParameters_StarburstParameters_Catalog")]
        public System.String StarburstParameters_Catalog { get; set; }
        #endregion
        
        #region Parameter TrinoParameters_Catalog
        /// <summary>
        /// <para>
        /// <para>The catalog name for the Trino data source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceParameters_TrinoParameters_Catalog")]
        public System.String TrinoParameters_Catalog { get; set; }
        #endregion
        
        #region Parameter RedshiftParameters_ClusterId
        /// <summary>
        /// <para>
        /// <para>Cluster ID. This field can be blank if the <c>Host</c> and <c>Port</c> are provided.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceParameters_RedshiftParameters_ClusterId")]
        public System.String RedshiftParameters_ClusterId { get; set; }
        #endregion
        
        #region Parameter Credentials_CopySourceArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of a data source that has the credential pair that
        /// you want to use. When <c>CopySourceArn</c> is not null, the credential pair from the
        /// data source in the ARN is used as the credentials for the <c>DataSourceCredentials</c>
        /// structure.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Credentials_CopySourceArn { get; set; }
        #endregion
        
        #region Parameter AuroraParameters_Database
        /// <summary>
        /// <para>
        /// <para>Database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceParameters_AuroraParameters_Database")]
        public System.String AuroraParameters_Database { get; set; }
        #endregion
        
        #region Parameter AuroraPostgreSqlParameters_Database
        /// <summary>
        /// <para>
        /// <para>The Amazon Aurora PostgreSQL database to connect to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceParameters_AuroraPostgreSqlParameters_Database")]
        public System.String AuroraPostgreSqlParameters_Database { get; set; }
        #endregion
        
        #region Parameter MariaDbParameters_Database
        /// <summary>
        /// <para>
        /// <para>Database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceParameters_MariaDbParameters_Database")]
        public System.String MariaDbParameters_Database { get; set; }
        #endregion
        
        #region Parameter MySqlParameters_Database
        /// <summary>
        /// <para>
        /// <para>Database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceParameters_MySqlParameters_Database")]
        public System.String MySqlParameters_Database { get; set; }
        #endregion
        
        #region Parameter OracleParameters_Database
        /// <summary>
        /// <para>
        /// <para>The database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceParameters_OracleParameters_Database")]
        public System.String OracleParameters_Database { get; set; }
        #endregion
        
        #region Parameter PostgreSqlParameters_Database
        /// <summary>
        /// <para>
        /// <para>Database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceParameters_PostgreSqlParameters_Database")]
        public System.String PostgreSqlParameters_Database { get; set; }
        #endregion
        
        #region Parameter RdsParameters_Database
        /// <summary>
        /// <para>
        /// <para>Database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceParameters_RdsParameters_Database")]
        public System.String RdsParameters_Database { get; set; }
        #endregion
        
        #region Parameter RedshiftParameters_Database
        /// <summary>
        /// <para>
        /// <para>Database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceParameters_RedshiftParameters_Database")]
        public System.String RedshiftParameters_Database { get; set; }
        #endregion
        
        #region Parameter SnowflakeParameters_Database
        /// <summary>
        /// <para>
        /// <para>Database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceParameters_SnowflakeParameters_Database")]
        public System.String SnowflakeParameters_Database { get; set; }
        #endregion
        
        #region Parameter SqlServerParameters_Database
        /// <summary>
        /// <para>
        /// <para>Database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceParameters_SqlServerParameters_Database")]
        public System.String SqlServerParameters_Database { get; set; }
        #endregion
        
        #region Parameter TeradataParameters_Database
        /// <summary>
        /// <para>
        /// <para>Database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceParameters_TeradataParameters_Database")]
        public System.String TeradataParameters_Database { get; set; }
        #endregion
        
        #region Parameter SnowflakeParameters_DatabaseAccessControlRole
        /// <summary>
        /// <para>
        /// <para>The database access control role.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceParameters_SnowflakeParameters_DatabaseAccessControlRole")]
        public System.String SnowflakeParameters_DatabaseAccessControlRole { get; set; }
        #endregion
        
        #region Parameter StarburstParameters_DatabaseAccessControlRole
        /// <summary>
        /// <para>
        /// <para>The database access control role.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceParameters_StarburstParameters_DatabaseAccessControlRole")]
        public System.String StarburstParameters_DatabaseAccessControlRole { get; set; }
        #endregion
        
        #region Parameter IAMParameters_DatabaseGroup
        /// <summary>
        /// <para>
        /// <para>A list of groups whose permissions will be granted to Amazon QuickSight to access
        /// the cluster. These permissions are combined with the permissions granted to Amazon
        /// QuickSight by the <c>DatabaseUser</c>. If you choose to include this parameter, the
        /// <c>RoleArn</c> must grant access to <c>redshift:JoinGroup</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceParameters_RedshiftParameters_IAMParameters_DatabaseGroups")]
        public System.String[] IAMParameters_DatabaseGroup { get; set; }
        #endregion
        
        #region Parameter IAMParameters_DatabaseUser
        /// <summary>
        /// <para>
        /// <para>The user whose permissions and group memberships will be used by Amazon QuickSight
        /// to access the cluster. If this user already exists in your database, Amazon QuickSight
        /// is granted the same permissions that the user has. If the user doesn't exist, set
        /// the value of <c>AutoCreateDatabaseUser</c> to <c>True</c> to create a new user with
        /// PUBLIC permissions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceParameters_RedshiftParameters_IAMParameters_DatabaseUser")]
        public System.String IAMParameters_DatabaseUser { get; set; }
        #endregion
        
        #region Parameter AwsIotAnalyticsParameters_DataSetName
        /// <summary>
        /// <para>
        /// <para>Dataset name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceParameters_AwsIotAnalyticsParameters_DataSetName")]
        public System.String AwsIotAnalyticsParameters_DataSetName { get; set; }
        #endregion
        
        #region Parameter BigQueryParameters_DataSetRegion
        /// <summary>
        /// <para>
        /// <para>The storage location where you create a Google BigQuery data source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceParameters_BigQueryParameters_DataSetRegion")]
        public System.String BigQueryParameters_DataSetRegion { get; set; }
        #endregion
        
        #region Parameter DataSourceId
        /// <summary>
        /// <para>
        /// <para>An ID for the data source. This ID is unique per Amazon Web Services Region for each
        /// Amazon Web Services account. </para>
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
        public System.String DataSourceId { get; set; }
        #endregion
        
        #region Parameter SslProperties_DisableSsl
        /// <summary>
        /// <para>
        /// <para>A Boolean option to control whether SSL should be disabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SslProperties_DisableSsl { get; set; }
        #endregion
        
        #region Parameter AmazonElasticsearchParameters_Domain
        /// <summary>
        /// <para>
        /// <para>The OpenSearch domain.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceParameters_AmazonElasticsearchParameters_Domain")]
        public System.String AmazonElasticsearchParameters_Domain { get; set; }
        #endregion
        
        #region Parameter AmazonOpenSearchParameters_Domain
        /// <summary>
        /// <para>
        /// <para>The OpenSearch domain.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceParameters_AmazonOpenSearchParameters_Domain")]
        public System.String AmazonOpenSearchParameters_Domain { get; set; }
        #endregion
        
        #region Parameter IdentityCenterConfiguration_EnableIdentityPropagation
        /// <summary>
        /// <para>
        /// <para>A Boolean option that controls whether Trusted Identity Propagation should be used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceParameters_RedshiftParameters_IdentityCenterConfiguration_EnableIdentityPropagation")]
        public System.Boolean? IdentityCenterConfiguration_EnableIdentityPropagation { get; set; }
        #endregion
        
        #region Parameter FolderArn
        /// <summary>
        /// <para>
        /// <para>When you create the data source, Amazon QuickSight adds the data source to these folders.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FolderArns")]
        public System.String[] FolderArn { get; set; }
        #endregion
        
        #region Parameter AuroraParameters_Host
        /// <summary>
        /// <para>
        /// <para>Host.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceParameters_AuroraParameters_Host")]
        public System.String AuroraParameters_Host { get; set; }
        #endregion
        
        #region Parameter AuroraPostgreSqlParameters_Host
        /// <summary>
        /// <para>
        /// <para>The Amazon Aurora PostgreSQL-Compatible host to connect to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceParameters_AuroraPostgreSqlParameters_Host")]
        public System.String AuroraPostgreSqlParameters_Host { get; set; }
        #endregion
        
        #region Parameter DatabricksParameters_Host
        /// <summary>
        /// <para>
        /// <para>The host name of the Databricks data source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceParameters_DatabricksParameters_Host")]
        public System.String DatabricksParameters_Host { get; set; }
        #endregion
        
        #region Parameter ExasolParameters_Host
        /// <summary>
        /// <para>
        /// <para>The hostname or IP address of the Exasol data source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceParameters_ExasolParameters_Host")]
        public System.String ExasolParameters_Host { get; set; }
        #endregion
        
        #region Parameter MariaDbParameters_Host
        /// <summary>
        /// <para>
        /// <para>Host.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceParameters_MariaDbParameters_Host")]
        public System.String MariaDbParameters_Host { get; set; }
        #endregion
        
        #region Parameter MySqlParameters_Host
        /// <summary>
        /// <para>
        /// <para>Host.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceParameters_MySqlParameters_Host")]
        public System.String MySqlParameters_Host { get; set; }
        #endregion
        
        #region Parameter OracleParameters_Host
        /// <summary>
        /// <para>
        /// <para>An Oracle host.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceParameters_OracleParameters_Host")]
        public System.String OracleParameters_Host { get; set; }
        #endregion
        
        #region Parameter PostgreSqlParameters_Host
        /// <summary>
        /// <para>
        /// <para>Host.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceParameters_PostgreSqlParameters_Host")]
        public System.String PostgreSqlParameters_Host { get; set; }
        #endregion
        
        #region Parameter PrestoParameters_Host
        /// <summary>
        /// <para>
        /// <para>Host.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceParameters_PrestoParameters_Host")]
        public System.String PrestoParameters_Host { get; set; }
        #endregion
        
        #region Parameter RedshiftParameters_Host
        /// <summary>
        /// <para>
        /// <para>Host. This field can be blank if <c>ClusterId</c> is provided.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceParameters_RedshiftParameters_Host")]
        public System.String RedshiftParameters_Host { get; set; }
        #endregion
        
        #region Parameter SnowflakeParameters_Host
        /// <summary>
        /// <para>
        /// <para>Host.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceParameters_SnowflakeParameters_Host")]
        public System.String SnowflakeParameters_Host { get; set; }
        #endregion
        
        #region Parameter SparkParameters_Host
        /// <summary>
        /// <para>
        /// <para>Host.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceParameters_SparkParameters_Host")]
        public System.String SparkParameters_Host { get; set; }
        #endregion
        
        #region Parameter SqlServerParameters_Host
        /// <summary>
        /// <para>
        /// <para>Host.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceParameters_SqlServerParameters_Host")]
        public System.String SqlServerParameters_Host { get; set; }
        #endregion
        
        #region Parameter StarburstParameters_Host
        /// <summary>
        /// <para>
        /// <para>The host name of the Starburst data source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceParameters_StarburstParameters_Host")]
        public System.String StarburstParameters_Host { get; set; }
        #endregion
        
        #region Parameter TeradataParameters_Host
        /// <summary>
        /// <para>
        /// <para>Host.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceParameters_TeradataParameters_Host")]
        public System.String TeradataParameters_Host { get; set; }
        #endregion
        
        #region Parameter TrinoParameters_Host
        /// <summary>
        /// <para>
        /// <para>The host name of the Trino data source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceParameters_TrinoParameters_Host")]
        public System.String TrinoParameters_Host { get; set; }
        #endregion
        
        #region Parameter DataSourceParameters_SnowflakeParameters_OAuthParameters_IdentityProviderResourceUri
        /// <summary>
        /// <para>
        /// <para>The resource uri of the identity provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DataSourceParameters_SnowflakeParameters_OAuthParameters_IdentityProviderResourceUri { get; set; }
        #endregion
        
        #region Parameter DataSourceParameters_StarburstParameters_OAuthParameters_IdentityProviderResourceUri
        /// <summary>
        /// <para>
        /// <para>The resource uri of the identity provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DataSourceParameters_StarburstParameters_OAuthParameters_IdentityProviderResourceUri { get; set; }
        #endregion
        
        #region Parameter RdsParameters_InstanceId
        /// <summary>
        /// <para>
        /// <para>Instance ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceParameters_RdsParameters_InstanceId")]
        public System.String RdsParameters_InstanceId { get; set; }
        #endregion
        
        #region Parameter ManifestFileLocation_Key
        /// <summary>
        /// <para>
        /// <para>Amazon S3 key that identifies an object.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceParameters_S3Parameters_ManifestFileLocation_Key")]
        public System.String ManifestFileLocation_Key { get; set; }
        #endregion
        
        #region Parameter TwitterParameters_MaxRow
        /// <summary>
        /// <para>
        /// <para>Maximum number of rows to query Twitter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceParameters_TwitterParameters_MaxRows")]
        public System.Int32? TwitterParameters_MaxRow { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A display name for the data source.</para>
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
        
        #region Parameter DataSourceParameters_SnowflakeParameters_OAuthParameters_OAuthScope
        /// <summary>
        /// <para>
        /// <para>The OAuth scope.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DataSourceParameters_SnowflakeParameters_OAuthParameters_OAuthScope { get; set; }
        #endregion
        
        #region Parameter DataSourceParameters_StarburstParameters_OAuthParameters_OAuthScope
        /// <summary>
        /// <para>
        /// <para>The OAuth scope.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DataSourceParameters_StarburstParameters_OAuthParameters_OAuthScope { get; set; }
        #endregion
        
        #region Parameter CredentialPair_Password
        /// <summary>
        /// <para>
        /// <para>Password.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Credentials_CredentialPair_Password")]
        public System.String CredentialPair_Password { get; set; }
        #endregion
        
        #region Parameter Permission
        /// <summary>
        /// <para>
        /// <para>A list of resource permissions on the data source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Permissions")]
        public Amazon.QuickSight.Model.ResourcePermission[] Permission { get; set; }
        #endregion
        
        #region Parameter AuroraParameters_Port
        /// <summary>
        /// <para>
        /// <para>Port.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceParameters_AuroraParameters_Port")]
        public System.Int32? AuroraParameters_Port { get; set; }
        #endregion
        
        #region Parameter AuroraPostgreSqlParameters_Port
        /// <summary>
        /// <para>
        /// <para>The port that Amazon Aurora PostgreSQL is listening on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceParameters_AuroraPostgreSqlParameters_Port")]
        public System.Int32? AuroraPostgreSqlParameters_Port { get; set; }
        #endregion
        
        #region Parameter DatabricksParameters_Port
        /// <summary>
        /// <para>
        /// <para>The port for the Databricks data source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceParameters_DatabricksParameters_Port")]
        public System.Int32? DatabricksParameters_Port { get; set; }
        #endregion
        
        #region Parameter ExasolParameters_Port
        /// <summary>
        /// <para>
        /// <para>The port for the Exasol data source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceParameters_ExasolParameters_Port")]
        public System.Int32? ExasolParameters_Port { get; set; }
        #endregion
        
        #region Parameter MariaDbParameters_Port
        /// <summary>
        /// <para>
        /// <para>Port.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceParameters_MariaDbParameters_Port")]
        public System.Int32? MariaDbParameters_Port { get; set; }
        #endregion
        
        #region Parameter MySqlParameters_Port
        /// <summary>
        /// <para>
        /// <para>Port.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceParameters_MySqlParameters_Port")]
        public System.Int32? MySqlParameters_Port { get; set; }
        #endregion
        
        #region Parameter OracleParameters_Port
        /// <summary>
        /// <para>
        /// <para>The port.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceParameters_OracleParameters_Port")]
        public System.Int32? OracleParameters_Port { get; set; }
        #endregion
        
        #region Parameter PostgreSqlParameters_Port
        /// <summary>
        /// <para>
        /// <para>Port.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceParameters_PostgreSqlParameters_Port")]
        public System.Int32? PostgreSqlParameters_Port { get; set; }
        #endregion
        
        #region Parameter PrestoParameters_Port
        /// <summary>
        /// <para>
        /// <para>Port.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceParameters_PrestoParameters_Port")]
        public System.Int32? PrestoParameters_Port { get; set; }
        #endregion
        
        #region Parameter RedshiftParameters_Port
        /// <summary>
        /// <para>
        /// <para>Port. This field can be blank if the <c>ClusterId</c> is provided.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceParameters_RedshiftParameters_Port")]
        public System.Int32? RedshiftParameters_Port { get; set; }
        #endregion
        
        #region Parameter SparkParameters_Port
        /// <summary>
        /// <para>
        /// <para>Port.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceParameters_SparkParameters_Port")]
        public System.Int32? SparkParameters_Port { get; set; }
        #endregion
        
        #region Parameter SqlServerParameters_Port
        /// <summary>
        /// <para>
        /// <para>Port.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceParameters_SqlServerParameters_Port")]
        public System.Int32? SqlServerParameters_Port { get; set; }
        #endregion
        
        #region Parameter StarburstParameters_Port
        /// <summary>
        /// <para>
        /// <para>The port for the Starburst data source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceParameters_StarburstParameters_Port")]
        public System.Int32? StarburstParameters_Port { get; set; }
        #endregion
        
        #region Parameter TeradataParameters_Port
        /// <summary>
        /// <para>
        /// <para>Port.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceParameters_TeradataParameters_Port")]
        public System.Int32? TeradataParameters_Port { get; set; }
        #endregion
        
        #region Parameter TrinoParameters_Port
        /// <summary>
        /// <para>
        /// <para>The port for the Trino data source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceParameters_TrinoParameters_Port")]
        public System.Int32? TrinoParameters_Port { get; set; }
        #endregion
        
        #region Parameter StarburstParameters_ProductType
        /// <summary>
        /// <para>
        /// <para>The product type for the Starburst data source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceParameters_StarburstParameters_ProductType")]
        [AWSConstantClassSource("Amazon.QuickSight.StarburstProductType")]
        public Amazon.QuickSight.StarburstProductType StarburstParameters_ProductType { get; set; }
        #endregion
        
        #region Parameter BigQueryParameters_ProjectId
        /// <summary>
        /// <para>
        /// <para>The Google Cloud Platform project ID where your datasource was created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceParameters_BigQueryParameters_ProjectId")]
        public System.String BigQueryParameters_ProjectId { get; set; }
        #endregion
        
        #region Parameter TwitterParameters_Query
        /// <summary>
        /// <para>
        /// <para>Twitter query string.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceParameters_TwitterParameters_Query")]
        public System.String TwitterParameters_Query { get; set; }
        #endregion
        
        #region Parameter AthenaParameters_RoleArn
        /// <summary>
        /// <para>
        /// <para>Use the <c>RoleArn</c> structure to override an account-wide role for a specific Athena
        /// data source. For example, say an account administrator has turned off all Athena access
        /// with an account-wide role. The administrator can then use <c>RoleArn</c> to bypass
        /// the account-wide role and allow Athena access for the single Athena data source that
        /// is specified in the structure, even if the account-wide role forbidding Athena access
        /// is still active.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceParameters_AthenaParameters_RoleArn")]
        public System.String AthenaParameters_RoleArn { get; set; }
        #endregion
        
        #region Parameter IAMParameters_RoleArn
        /// <summary>
        /// <para>
        /// <para>Use the <c>RoleArn</c> structure to allow Amazon QuickSight to call <c>redshift:GetClusterCredentials</c>
        /// on your cluster. The calling principal must have <c>iam:PassRole</c> access to pass
        /// the role to Amazon QuickSight. The role's trust policy must allow the Amazon QuickSight
        /// service principal to assume the role.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceParameters_RedshiftParameters_IAMParameters_RoleArn")]
        public System.String IAMParameters_RoleArn { get; set; }
        #endregion
        
        #region Parameter S3Parameters_RoleArn
        /// <summary>
        /// <para>
        /// <para>Use the <c>RoleArn</c> structure to override an account-wide role for a specific S3
        /// data source. For example, say an account administrator has turned off all S3 access
        /// with an account-wide role. The administrator can then use <c>RoleArn</c> to bypass
        /// the account-wide role and allow S3 access for the single S3 data source that is specified
        /// in the structure, even if the account-wide role forbidding S3 access is still active.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceParameters_S3Parameters_RoleArn")]
        public System.String S3Parameters_RoleArn { get; set; }
        #endregion
        
        #region Parameter Credentials_SecretArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the secret associated with the data source in Amazon
        /// Secrets Manager.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Credentials_SecretArn { get; set; }
        #endregion
        
        #region Parameter JiraParameters_SiteBaseUrl
        /// <summary>
        /// <para>
        /// <para>The base URL of the Jira site.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceParameters_JiraParameters_SiteBaseUrl")]
        public System.String JiraParameters_SiteBaseUrl { get; set; }
        #endregion
        
        #region Parameter ServiceNowParameters_SiteBaseUrl
        /// <summary>
        /// <para>
        /// <para>URL of the base site.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceParameters_ServiceNowParameters_SiteBaseUrl")]
        public System.String ServiceNowParameters_SiteBaseUrl { get; set; }
        #endregion
        
        #region Parameter DatabricksParameters_SqlEndpointPath
        /// <summary>
        /// <para>
        /// <para>The HTTP path of the Databricks data source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceParameters_DatabricksParameters_SqlEndpointPath")]
        public System.String DatabricksParameters_SqlEndpointPath { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Contains a map of the key-value pairs for the resource tag or tags assigned to the
        /// data source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.QuickSight.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter DataSourceParameters_SnowflakeParameters_OAuthParameters_TokenProviderUrl
        /// <summary>
        /// <para>
        /// <para>The token endpoint URL of the identity provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DataSourceParameters_SnowflakeParameters_OAuthParameters_TokenProviderUrl { get; set; }
        #endregion
        
        #region Parameter DataSourceParameters_StarburstParameters_OAuthParameters_TokenProviderUrl
        /// <summary>
        /// <para>
        /// <para>The token endpoint URL of the identity provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DataSourceParameters_StarburstParameters_OAuthParameters_TokenProviderUrl { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The type of the data source. To return a list of all data sources, use <c>ListDataSources</c>.</para><para>Use <c>AMAZON_ELASTICSEARCH</c> for Amazon OpenSearch Service.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.QuickSight.DataSourceType")]
        public Amazon.QuickSight.DataSourceType Type { get; set; }
        #endregion
        
        #region Parameter CredentialPair_Username
        /// <summary>
        /// <para>
        /// <para>User name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Credentials_CredentialPair_Username")]
        public System.String CredentialPair_Username { get; set; }
        #endregion
        
        #region Parameter DataSourceParameters_SnowflakeParameters_OAuthParameters_IdentityProviderVpcConnectionProperties_VpcConnectionArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) for the VPC connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DataSourceParameters_SnowflakeParameters_OAuthParameters_IdentityProviderVpcConnectionProperties_VpcConnectionArn { get; set; }
        #endregion
        
        #region Parameter DataSourceParameters_StarburstParameters_OAuthParameters_IdentityProviderVpcConnectionProperties_VpcConnectionArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) for the VPC connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DataSourceParameters_StarburstParameters_OAuthParameters_IdentityProviderVpcConnectionProperties_VpcConnectionArn { get; set; }
        #endregion
        
        #region Parameter VpcConnectionProperties_VpcConnectionArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) for the VPC connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VpcConnectionProperties_VpcConnectionArn { get; set; }
        #endregion
        
        #region Parameter SnowflakeParameters_Warehouse
        /// <summary>
        /// <para>
        /// <para>Warehouse.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceParameters_SnowflakeParameters_Warehouse")]
        public System.String SnowflakeParameters_Warehouse { get; set; }
        #endregion
        
        #region Parameter AthenaParameters_WorkGroup
        /// <summary>
        /// <para>
        /// <para>The workgroup that Amazon Athena uses.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceParameters_AthenaParameters_WorkGroup")]
        public System.String AthenaParameters_WorkGroup { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QuickSight.Model.CreateDataSourceResponse).
        /// Specifying the name of a property of type Amazon.QuickSight.Model.CreateDataSourceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DataSourceId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DataSourceId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DataSourceId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DataSourceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-QSDataSource (CreateDataSource)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QuickSight.Model.CreateDataSourceResponse, NewQSDataSourceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DataSourceId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AwsAccountId = this.AwsAccountId;
            #if MODULAR
            if (this.AwsAccountId == null && ParameterWasBound(nameof(this.AwsAccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AwsAccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Credentials_CopySourceArn = this.Credentials_CopySourceArn;
            if (this.CredentialPair_AlternateDataSourceParameter != null)
            {
                context.CredentialPair_AlternateDataSourceParameter = new List<Amazon.QuickSight.Model.DataSourceParameters>(this.CredentialPair_AlternateDataSourceParameter);
            }
            context.CredentialPair_Password = this.CredentialPair_Password;
            context.CredentialPair_Username = this.CredentialPair_Username;
            context.Credentials_SecretArn = this.Credentials_SecretArn;
            context.DataSourceId = this.DataSourceId;
            #if MODULAR
            if (this.DataSourceId == null && ParameterWasBound(nameof(this.DataSourceId)))
            {
                WriteWarning("You are passing $null as a value for parameter DataSourceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AmazonElasticsearchParameters_Domain = this.AmazonElasticsearchParameters_Domain;
            context.AmazonOpenSearchParameters_Domain = this.AmazonOpenSearchParameters_Domain;
            context.AthenaParameters_RoleArn = this.AthenaParameters_RoleArn;
            context.AthenaParameters_WorkGroup = this.AthenaParameters_WorkGroup;
            context.AuroraParameters_Database = this.AuroraParameters_Database;
            context.AuroraParameters_Host = this.AuroraParameters_Host;
            context.AuroraParameters_Port = this.AuroraParameters_Port;
            context.AuroraPostgreSqlParameters_Database = this.AuroraPostgreSqlParameters_Database;
            context.AuroraPostgreSqlParameters_Host = this.AuroraPostgreSqlParameters_Host;
            context.AuroraPostgreSqlParameters_Port = this.AuroraPostgreSqlParameters_Port;
            context.AwsIotAnalyticsParameters_DataSetName = this.AwsIotAnalyticsParameters_DataSetName;
            context.BigQueryParameters_DataSetRegion = this.BigQueryParameters_DataSetRegion;
            context.BigQueryParameters_ProjectId = this.BigQueryParameters_ProjectId;
            context.DatabricksParameters_Host = this.DatabricksParameters_Host;
            context.DatabricksParameters_Port = this.DatabricksParameters_Port;
            context.DatabricksParameters_SqlEndpointPath = this.DatabricksParameters_SqlEndpointPath;
            context.ExasolParameters_Host = this.ExasolParameters_Host;
            context.ExasolParameters_Port = this.ExasolParameters_Port;
            context.JiraParameters_SiteBaseUrl = this.JiraParameters_SiteBaseUrl;
            context.MariaDbParameters_Database = this.MariaDbParameters_Database;
            context.MariaDbParameters_Host = this.MariaDbParameters_Host;
            context.MariaDbParameters_Port = this.MariaDbParameters_Port;
            context.MySqlParameters_Database = this.MySqlParameters_Database;
            context.MySqlParameters_Host = this.MySqlParameters_Host;
            context.MySqlParameters_Port = this.MySqlParameters_Port;
            context.OracleParameters_Database = this.OracleParameters_Database;
            context.OracleParameters_Host = this.OracleParameters_Host;
            context.OracleParameters_Port = this.OracleParameters_Port;
            context.PostgreSqlParameters_Database = this.PostgreSqlParameters_Database;
            context.PostgreSqlParameters_Host = this.PostgreSqlParameters_Host;
            context.PostgreSqlParameters_Port = this.PostgreSqlParameters_Port;
            context.PrestoParameters_Catalog = this.PrestoParameters_Catalog;
            context.PrestoParameters_Host = this.PrestoParameters_Host;
            context.PrestoParameters_Port = this.PrestoParameters_Port;
            context.RdsParameters_Database = this.RdsParameters_Database;
            context.RdsParameters_InstanceId = this.RdsParameters_InstanceId;
            context.RedshiftParameters_ClusterId = this.RedshiftParameters_ClusterId;
            context.RedshiftParameters_Database = this.RedshiftParameters_Database;
            context.RedshiftParameters_Host = this.RedshiftParameters_Host;
            context.IAMParameters_AutoCreateDatabaseUser = this.IAMParameters_AutoCreateDatabaseUser;
            if (this.IAMParameters_DatabaseGroup != null)
            {
                context.IAMParameters_DatabaseGroup = new List<System.String>(this.IAMParameters_DatabaseGroup);
            }
            context.IAMParameters_DatabaseUser = this.IAMParameters_DatabaseUser;
            context.IAMParameters_RoleArn = this.IAMParameters_RoleArn;
            context.IdentityCenterConfiguration_EnableIdentityPropagation = this.IdentityCenterConfiguration_EnableIdentityPropagation;
            context.RedshiftParameters_Port = this.RedshiftParameters_Port;
            context.ManifestFileLocation_Bucket = this.ManifestFileLocation_Bucket;
            context.ManifestFileLocation_Key = this.ManifestFileLocation_Key;
            context.S3Parameters_RoleArn = this.S3Parameters_RoleArn;
            context.ServiceNowParameters_SiteBaseUrl = this.ServiceNowParameters_SiteBaseUrl;
            context.SnowflakeParameters_AuthenticationType = this.SnowflakeParameters_AuthenticationType;
            context.SnowflakeParameters_Database = this.SnowflakeParameters_Database;
            context.SnowflakeParameters_DatabaseAccessControlRole = this.SnowflakeParameters_DatabaseAccessControlRole;
            context.SnowflakeParameters_Host = this.SnowflakeParameters_Host;
            context.DataSourceParameters_SnowflakeParameters_OAuthParameters_IdentityProviderResourceUri = this.DataSourceParameters_SnowflakeParameters_OAuthParameters_IdentityProviderResourceUri;
            context.DataSourceParameters_SnowflakeParameters_OAuthParameters_IdentityProviderVpcConnectionProperties_VpcConnectionArn = this.DataSourceParameters_SnowflakeParameters_OAuthParameters_IdentityProviderVpcConnectionProperties_VpcConnectionArn;
            context.DataSourceParameters_SnowflakeParameters_OAuthParameters_OAuthScope = this.DataSourceParameters_SnowflakeParameters_OAuthParameters_OAuthScope;
            context.DataSourceParameters_SnowflakeParameters_OAuthParameters_TokenProviderUrl = this.DataSourceParameters_SnowflakeParameters_OAuthParameters_TokenProviderUrl;
            context.SnowflakeParameters_Warehouse = this.SnowflakeParameters_Warehouse;
            context.SparkParameters_Host = this.SparkParameters_Host;
            context.SparkParameters_Port = this.SparkParameters_Port;
            context.SqlServerParameters_Database = this.SqlServerParameters_Database;
            context.SqlServerParameters_Host = this.SqlServerParameters_Host;
            context.SqlServerParameters_Port = this.SqlServerParameters_Port;
            context.StarburstParameters_AuthenticationType = this.StarburstParameters_AuthenticationType;
            context.StarburstParameters_Catalog = this.StarburstParameters_Catalog;
            context.StarburstParameters_DatabaseAccessControlRole = this.StarburstParameters_DatabaseAccessControlRole;
            context.StarburstParameters_Host = this.StarburstParameters_Host;
            context.DataSourceParameters_StarburstParameters_OAuthParameters_IdentityProviderResourceUri = this.DataSourceParameters_StarburstParameters_OAuthParameters_IdentityProviderResourceUri;
            context.DataSourceParameters_StarburstParameters_OAuthParameters_IdentityProviderVpcConnectionProperties_VpcConnectionArn = this.DataSourceParameters_StarburstParameters_OAuthParameters_IdentityProviderVpcConnectionProperties_VpcConnectionArn;
            context.DataSourceParameters_StarburstParameters_OAuthParameters_OAuthScope = this.DataSourceParameters_StarburstParameters_OAuthParameters_OAuthScope;
            context.DataSourceParameters_StarburstParameters_OAuthParameters_TokenProviderUrl = this.DataSourceParameters_StarburstParameters_OAuthParameters_TokenProviderUrl;
            context.StarburstParameters_Port = this.StarburstParameters_Port;
            context.StarburstParameters_ProductType = this.StarburstParameters_ProductType;
            context.TeradataParameters_Database = this.TeradataParameters_Database;
            context.TeradataParameters_Host = this.TeradataParameters_Host;
            context.TeradataParameters_Port = this.TeradataParameters_Port;
            context.TrinoParameters_Catalog = this.TrinoParameters_Catalog;
            context.TrinoParameters_Host = this.TrinoParameters_Host;
            context.TrinoParameters_Port = this.TrinoParameters_Port;
            context.TwitterParameters_MaxRow = this.TwitterParameters_MaxRow;
            context.TwitterParameters_Query = this.TwitterParameters_Query;
            if (this.FolderArn != null)
            {
                context.FolderArn = new List<System.String>(this.FolderArn);
            }
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Permission != null)
            {
                context.Permission = new List<Amazon.QuickSight.Model.ResourcePermission>(this.Permission);
            }
            context.SslProperties_DisableSsl = this.SslProperties_DisableSsl;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.QuickSight.Model.Tag>(this.Tag);
            }
            context.Type = this.Type;
            #if MODULAR
            if (this.Type == null && ParameterWasBound(nameof(this.Type)))
            {
                WriteWarning("You are passing $null as a value for parameter Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VpcConnectionProperties_VpcConnectionArn = this.VpcConnectionProperties_VpcConnectionArn;
            
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
            var request = new Amazon.QuickSight.Model.CreateDataSourceRequest();
            
            if (cmdletContext.AwsAccountId != null)
            {
                request.AwsAccountId = cmdletContext.AwsAccountId;
            }
            
             // populate Credentials
            var requestCredentialsIsNull = true;
            request.Credentials = new Amazon.QuickSight.Model.DataSourceCredentials();
            System.String requestCredentials_credentials_CopySourceArn = null;
            if (cmdletContext.Credentials_CopySourceArn != null)
            {
                requestCredentials_credentials_CopySourceArn = cmdletContext.Credentials_CopySourceArn;
            }
            if (requestCredentials_credentials_CopySourceArn != null)
            {
                request.Credentials.CopySourceArn = requestCredentials_credentials_CopySourceArn;
                requestCredentialsIsNull = false;
            }
            System.String requestCredentials_credentials_SecretArn = null;
            if (cmdletContext.Credentials_SecretArn != null)
            {
                requestCredentials_credentials_SecretArn = cmdletContext.Credentials_SecretArn;
            }
            if (requestCredentials_credentials_SecretArn != null)
            {
                request.Credentials.SecretArn = requestCredentials_credentials_SecretArn;
                requestCredentialsIsNull = false;
            }
            Amazon.QuickSight.Model.CredentialPair requestCredentials_credentials_CredentialPair = null;
            
             // populate CredentialPair
            var requestCredentials_credentials_CredentialPairIsNull = true;
            requestCredentials_credentials_CredentialPair = new Amazon.QuickSight.Model.CredentialPair();
            List<Amazon.QuickSight.Model.DataSourceParameters> requestCredentials_credentials_CredentialPair_credentialPair_AlternateDataSourceParameter = null;
            if (cmdletContext.CredentialPair_AlternateDataSourceParameter != null)
            {
                requestCredentials_credentials_CredentialPair_credentialPair_AlternateDataSourceParameter = cmdletContext.CredentialPair_AlternateDataSourceParameter;
            }
            if (requestCredentials_credentials_CredentialPair_credentialPair_AlternateDataSourceParameter != null)
            {
                requestCredentials_credentials_CredentialPair.AlternateDataSourceParameters = requestCredentials_credentials_CredentialPair_credentialPair_AlternateDataSourceParameter;
                requestCredentials_credentials_CredentialPairIsNull = false;
            }
            System.String requestCredentials_credentials_CredentialPair_credentialPair_Password = null;
            if (cmdletContext.CredentialPair_Password != null)
            {
                requestCredentials_credentials_CredentialPair_credentialPair_Password = cmdletContext.CredentialPair_Password;
            }
            if (requestCredentials_credentials_CredentialPair_credentialPair_Password != null)
            {
                requestCredentials_credentials_CredentialPair.Password = requestCredentials_credentials_CredentialPair_credentialPair_Password;
                requestCredentials_credentials_CredentialPairIsNull = false;
            }
            System.String requestCredentials_credentials_CredentialPair_credentialPair_Username = null;
            if (cmdletContext.CredentialPair_Username != null)
            {
                requestCredentials_credentials_CredentialPair_credentialPair_Username = cmdletContext.CredentialPair_Username;
            }
            if (requestCredentials_credentials_CredentialPair_credentialPair_Username != null)
            {
                requestCredentials_credentials_CredentialPair.Username = requestCredentials_credentials_CredentialPair_credentialPair_Username;
                requestCredentials_credentials_CredentialPairIsNull = false;
            }
             // determine if requestCredentials_credentials_CredentialPair should be set to null
            if (requestCredentials_credentials_CredentialPairIsNull)
            {
                requestCredentials_credentials_CredentialPair = null;
            }
            if (requestCredentials_credentials_CredentialPair != null)
            {
                request.Credentials.CredentialPair = requestCredentials_credentials_CredentialPair;
                requestCredentialsIsNull = false;
            }
             // determine if request.Credentials should be set to null
            if (requestCredentialsIsNull)
            {
                request.Credentials = null;
            }
            if (cmdletContext.DataSourceId != null)
            {
                request.DataSourceId = cmdletContext.DataSourceId;
            }
            
             // populate DataSourceParameters
            var requestDataSourceParametersIsNull = true;
            request.DataSourceParameters = new Amazon.QuickSight.Model.DataSourceParameters();
            Amazon.QuickSight.Model.AmazonElasticsearchParameters requestDataSourceParameters_dataSourceParameters_AmazonElasticsearchParameters = null;
            
             // populate AmazonElasticsearchParameters
            var requestDataSourceParameters_dataSourceParameters_AmazonElasticsearchParametersIsNull = true;
            requestDataSourceParameters_dataSourceParameters_AmazonElasticsearchParameters = new Amazon.QuickSight.Model.AmazonElasticsearchParameters();
            System.String requestDataSourceParameters_dataSourceParameters_AmazonElasticsearchParameters_amazonElasticsearchParameters_Domain = null;
            if (cmdletContext.AmazonElasticsearchParameters_Domain != null)
            {
                requestDataSourceParameters_dataSourceParameters_AmazonElasticsearchParameters_amazonElasticsearchParameters_Domain = cmdletContext.AmazonElasticsearchParameters_Domain;
            }
            if (requestDataSourceParameters_dataSourceParameters_AmazonElasticsearchParameters_amazonElasticsearchParameters_Domain != null)
            {
                requestDataSourceParameters_dataSourceParameters_AmazonElasticsearchParameters.Domain = requestDataSourceParameters_dataSourceParameters_AmazonElasticsearchParameters_amazonElasticsearchParameters_Domain;
                requestDataSourceParameters_dataSourceParameters_AmazonElasticsearchParametersIsNull = false;
            }
             // determine if requestDataSourceParameters_dataSourceParameters_AmazonElasticsearchParameters should be set to null
            if (requestDataSourceParameters_dataSourceParameters_AmazonElasticsearchParametersIsNull)
            {
                requestDataSourceParameters_dataSourceParameters_AmazonElasticsearchParameters = null;
            }
            if (requestDataSourceParameters_dataSourceParameters_AmazonElasticsearchParameters != null)
            {
                request.DataSourceParameters.AmazonElasticsearchParameters = requestDataSourceParameters_dataSourceParameters_AmazonElasticsearchParameters;
                requestDataSourceParametersIsNull = false;
            }
            Amazon.QuickSight.Model.AmazonOpenSearchParameters requestDataSourceParameters_dataSourceParameters_AmazonOpenSearchParameters = null;
            
             // populate AmazonOpenSearchParameters
            var requestDataSourceParameters_dataSourceParameters_AmazonOpenSearchParametersIsNull = true;
            requestDataSourceParameters_dataSourceParameters_AmazonOpenSearchParameters = new Amazon.QuickSight.Model.AmazonOpenSearchParameters();
            System.String requestDataSourceParameters_dataSourceParameters_AmazonOpenSearchParameters_amazonOpenSearchParameters_Domain = null;
            if (cmdletContext.AmazonOpenSearchParameters_Domain != null)
            {
                requestDataSourceParameters_dataSourceParameters_AmazonOpenSearchParameters_amazonOpenSearchParameters_Domain = cmdletContext.AmazonOpenSearchParameters_Domain;
            }
            if (requestDataSourceParameters_dataSourceParameters_AmazonOpenSearchParameters_amazonOpenSearchParameters_Domain != null)
            {
                requestDataSourceParameters_dataSourceParameters_AmazonOpenSearchParameters.Domain = requestDataSourceParameters_dataSourceParameters_AmazonOpenSearchParameters_amazonOpenSearchParameters_Domain;
                requestDataSourceParameters_dataSourceParameters_AmazonOpenSearchParametersIsNull = false;
            }
             // determine if requestDataSourceParameters_dataSourceParameters_AmazonOpenSearchParameters should be set to null
            if (requestDataSourceParameters_dataSourceParameters_AmazonOpenSearchParametersIsNull)
            {
                requestDataSourceParameters_dataSourceParameters_AmazonOpenSearchParameters = null;
            }
            if (requestDataSourceParameters_dataSourceParameters_AmazonOpenSearchParameters != null)
            {
                request.DataSourceParameters.AmazonOpenSearchParameters = requestDataSourceParameters_dataSourceParameters_AmazonOpenSearchParameters;
                requestDataSourceParametersIsNull = false;
            }
            Amazon.QuickSight.Model.AwsIotAnalyticsParameters requestDataSourceParameters_dataSourceParameters_AwsIotAnalyticsParameters = null;
            
             // populate AwsIotAnalyticsParameters
            var requestDataSourceParameters_dataSourceParameters_AwsIotAnalyticsParametersIsNull = true;
            requestDataSourceParameters_dataSourceParameters_AwsIotAnalyticsParameters = new Amazon.QuickSight.Model.AwsIotAnalyticsParameters();
            System.String requestDataSourceParameters_dataSourceParameters_AwsIotAnalyticsParameters_awsIotAnalyticsParameters_DataSetName = null;
            if (cmdletContext.AwsIotAnalyticsParameters_DataSetName != null)
            {
                requestDataSourceParameters_dataSourceParameters_AwsIotAnalyticsParameters_awsIotAnalyticsParameters_DataSetName = cmdletContext.AwsIotAnalyticsParameters_DataSetName;
            }
            if (requestDataSourceParameters_dataSourceParameters_AwsIotAnalyticsParameters_awsIotAnalyticsParameters_DataSetName != null)
            {
                requestDataSourceParameters_dataSourceParameters_AwsIotAnalyticsParameters.DataSetName = requestDataSourceParameters_dataSourceParameters_AwsIotAnalyticsParameters_awsIotAnalyticsParameters_DataSetName;
                requestDataSourceParameters_dataSourceParameters_AwsIotAnalyticsParametersIsNull = false;
            }
             // determine if requestDataSourceParameters_dataSourceParameters_AwsIotAnalyticsParameters should be set to null
            if (requestDataSourceParameters_dataSourceParameters_AwsIotAnalyticsParametersIsNull)
            {
                requestDataSourceParameters_dataSourceParameters_AwsIotAnalyticsParameters = null;
            }
            if (requestDataSourceParameters_dataSourceParameters_AwsIotAnalyticsParameters != null)
            {
                request.DataSourceParameters.AwsIotAnalyticsParameters = requestDataSourceParameters_dataSourceParameters_AwsIotAnalyticsParameters;
                requestDataSourceParametersIsNull = false;
            }
            Amazon.QuickSight.Model.JiraParameters requestDataSourceParameters_dataSourceParameters_JiraParameters = null;
            
             // populate JiraParameters
            var requestDataSourceParameters_dataSourceParameters_JiraParametersIsNull = true;
            requestDataSourceParameters_dataSourceParameters_JiraParameters = new Amazon.QuickSight.Model.JiraParameters();
            System.String requestDataSourceParameters_dataSourceParameters_JiraParameters_jiraParameters_SiteBaseUrl = null;
            if (cmdletContext.JiraParameters_SiteBaseUrl != null)
            {
                requestDataSourceParameters_dataSourceParameters_JiraParameters_jiraParameters_SiteBaseUrl = cmdletContext.JiraParameters_SiteBaseUrl;
            }
            if (requestDataSourceParameters_dataSourceParameters_JiraParameters_jiraParameters_SiteBaseUrl != null)
            {
                requestDataSourceParameters_dataSourceParameters_JiraParameters.SiteBaseUrl = requestDataSourceParameters_dataSourceParameters_JiraParameters_jiraParameters_SiteBaseUrl;
                requestDataSourceParameters_dataSourceParameters_JiraParametersIsNull = false;
            }
             // determine if requestDataSourceParameters_dataSourceParameters_JiraParameters should be set to null
            if (requestDataSourceParameters_dataSourceParameters_JiraParametersIsNull)
            {
                requestDataSourceParameters_dataSourceParameters_JiraParameters = null;
            }
            if (requestDataSourceParameters_dataSourceParameters_JiraParameters != null)
            {
                request.DataSourceParameters.JiraParameters = requestDataSourceParameters_dataSourceParameters_JiraParameters;
                requestDataSourceParametersIsNull = false;
            }
            Amazon.QuickSight.Model.ServiceNowParameters requestDataSourceParameters_dataSourceParameters_ServiceNowParameters = null;
            
             // populate ServiceNowParameters
            var requestDataSourceParameters_dataSourceParameters_ServiceNowParametersIsNull = true;
            requestDataSourceParameters_dataSourceParameters_ServiceNowParameters = new Amazon.QuickSight.Model.ServiceNowParameters();
            System.String requestDataSourceParameters_dataSourceParameters_ServiceNowParameters_serviceNowParameters_SiteBaseUrl = null;
            if (cmdletContext.ServiceNowParameters_SiteBaseUrl != null)
            {
                requestDataSourceParameters_dataSourceParameters_ServiceNowParameters_serviceNowParameters_SiteBaseUrl = cmdletContext.ServiceNowParameters_SiteBaseUrl;
            }
            if (requestDataSourceParameters_dataSourceParameters_ServiceNowParameters_serviceNowParameters_SiteBaseUrl != null)
            {
                requestDataSourceParameters_dataSourceParameters_ServiceNowParameters.SiteBaseUrl = requestDataSourceParameters_dataSourceParameters_ServiceNowParameters_serviceNowParameters_SiteBaseUrl;
                requestDataSourceParameters_dataSourceParameters_ServiceNowParametersIsNull = false;
            }
             // determine if requestDataSourceParameters_dataSourceParameters_ServiceNowParameters should be set to null
            if (requestDataSourceParameters_dataSourceParameters_ServiceNowParametersIsNull)
            {
                requestDataSourceParameters_dataSourceParameters_ServiceNowParameters = null;
            }
            if (requestDataSourceParameters_dataSourceParameters_ServiceNowParameters != null)
            {
                request.DataSourceParameters.ServiceNowParameters = requestDataSourceParameters_dataSourceParameters_ServiceNowParameters;
                requestDataSourceParametersIsNull = false;
            }
            Amazon.QuickSight.Model.AthenaParameters requestDataSourceParameters_dataSourceParameters_AthenaParameters = null;
            
             // populate AthenaParameters
            var requestDataSourceParameters_dataSourceParameters_AthenaParametersIsNull = true;
            requestDataSourceParameters_dataSourceParameters_AthenaParameters = new Amazon.QuickSight.Model.AthenaParameters();
            System.String requestDataSourceParameters_dataSourceParameters_AthenaParameters_athenaParameters_RoleArn = null;
            if (cmdletContext.AthenaParameters_RoleArn != null)
            {
                requestDataSourceParameters_dataSourceParameters_AthenaParameters_athenaParameters_RoleArn = cmdletContext.AthenaParameters_RoleArn;
            }
            if (requestDataSourceParameters_dataSourceParameters_AthenaParameters_athenaParameters_RoleArn != null)
            {
                requestDataSourceParameters_dataSourceParameters_AthenaParameters.RoleArn = requestDataSourceParameters_dataSourceParameters_AthenaParameters_athenaParameters_RoleArn;
                requestDataSourceParameters_dataSourceParameters_AthenaParametersIsNull = false;
            }
            System.String requestDataSourceParameters_dataSourceParameters_AthenaParameters_athenaParameters_WorkGroup = null;
            if (cmdletContext.AthenaParameters_WorkGroup != null)
            {
                requestDataSourceParameters_dataSourceParameters_AthenaParameters_athenaParameters_WorkGroup = cmdletContext.AthenaParameters_WorkGroup;
            }
            if (requestDataSourceParameters_dataSourceParameters_AthenaParameters_athenaParameters_WorkGroup != null)
            {
                requestDataSourceParameters_dataSourceParameters_AthenaParameters.WorkGroup = requestDataSourceParameters_dataSourceParameters_AthenaParameters_athenaParameters_WorkGroup;
                requestDataSourceParameters_dataSourceParameters_AthenaParametersIsNull = false;
            }
             // determine if requestDataSourceParameters_dataSourceParameters_AthenaParameters should be set to null
            if (requestDataSourceParameters_dataSourceParameters_AthenaParametersIsNull)
            {
                requestDataSourceParameters_dataSourceParameters_AthenaParameters = null;
            }
            if (requestDataSourceParameters_dataSourceParameters_AthenaParameters != null)
            {
                request.DataSourceParameters.AthenaParameters = requestDataSourceParameters_dataSourceParameters_AthenaParameters;
                requestDataSourceParametersIsNull = false;
            }
            Amazon.QuickSight.Model.BigQueryParameters requestDataSourceParameters_dataSourceParameters_BigQueryParameters = null;
            
             // populate BigQueryParameters
            var requestDataSourceParameters_dataSourceParameters_BigQueryParametersIsNull = true;
            requestDataSourceParameters_dataSourceParameters_BigQueryParameters = new Amazon.QuickSight.Model.BigQueryParameters();
            System.String requestDataSourceParameters_dataSourceParameters_BigQueryParameters_bigQueryParameters_DataSetRegion = null;
            if (cmdletContext.BigQueryParameters_DataSetRegion != null)
            {
                requestDataSourceParameters_dataSourceParameters_BigQueryParameters_bigQueryParameters_DataSetRegion = cmdletContext.BigQueryParameters_DataSetRegion;
            }
            if (requestDataSourceParameters_dataSourceParameters_BigQueryParameters_bigQueryParameters_DataSetRegion != null)
            {
                requestDataSourceParameters_dataSourceParameters_BigQueryParameters.DataSetRegion = requestDataSourceParameters_dataSourceParameters_BigQueryParameters_bigQueryParameters_DataSetRegion;
                requestDataSourceParameters_dataSourceParameters_BigQueryParametersIsNull = false;
            }
            System.String requestDataSourceParameters_dataSourceParameters_BigQueryParameters_bigQueryParameters_ProjectId = null;
            if (cmdletContext.BigQueryParameters_ProjectId != null)
            {
                requestDataSourceParameters_dataSourceParameters_BigQueryParameters_bigQueryParameters_ProjectId = cmdletContext.BigQueryParameters_ProjectId;
            }
            if (requestDataSourceParameters_dataSourceParameters_BigQueryParameters_bigQueryParameters_ProjectId != null)
            {
                requestDataSourceParameters_dataSourceParameters_BigQueryParameters.ProjectId = requestDataSourceParameters_dataSourceParameters_BigQueryParameters_bigQueryParameters_ProjectId;
                requestDataSourceParameters_dataSourceParameters_BigQueryParametersIsNull = false;
            }
             // determine if requestDataSourceParameters_dataSourceParameters_BigQueryParameters should be set to null
            if (requestDataSourceParameters_dataSourceParameters_BigQueryParametersIsNull)
            {
                requestDataSourceParameters_dataSourceParameters_BigQueryParameters = null;
            }
            if (requestDataSourceParameters_dataSourceParameters_BigQueryParameters != null)
            {
                request.DataSourceParameters.BigQueryParameters = requestDataSourceParameters_dataSourceParameters_BigQueryParameters;
                requestDataSourceParametersIsNull = false;
            }
            Amazon.QuickSight.Model.ExasolParameters requestDataSourceParameters_dataSourceParameters_ExasolParameters = null;
            
             // populate ExasolParameters
            var requestDataSourceParameters_dataSourceParameters_ExasolParametersIsNull = true;
            requestDataSourceParameters_dataSourceParameters_ExasolParameters = new Amazon.QuickSight.Model.ExasolParameters();
            System.String requestDataSourceParameters_dataSourceParameters_ExasolParameters_exasolParameters_Host = null;
            if (cmdletContext.ExasolParameters_Host != null)
            {
                requestDataSourceParameters_dataSourceParameters_ExasolParameters_exasolParameters_Host = cmdletContext.ExasolParameters_Host;
            }
            if (requestDataSourceParameters_dataSourceParameters_ExasolParameters_exasolParameters_Host != null)
            {
                requestDataSourceParameters_dataSourceParameters_ExasolParameters.Host = requestDataSourceParameters_dataSourceParameters_ExasolParameters_exasolParameters_Host;
                requestDataSourceParameters_dataSourceParameters_ExasolParametersIsNull = false;
            }
            System.Int32? requestDataSourceParameters_dataSourceParameters_ExasolParameters_exasolParameters_Port = null;
            if (cmdletContext.ExasolParameters_Port != null)
            {
                requestDataSourceParameters_dataSourceParameters_ExasolParameters_exasolParameters_Port = cmdletContext.ExasolParameters_Port.Value;
            }
            if (requestDataSourceParameters_dataSourceParameters_ExasolParameters_exasolParameters_Port != null)
            {
                requestDataSourceParameters_dataSourceParameters_ExasolParameters.Port = requestDataSourceParameters_dataSourceParameters_ExasolParameters_exasolParameters_Port.Value;
                requestDataSourceParameters_dataSourceParameters_ExasolParametersIsNull = false;
            }
             // determine if requestDataSourceParameters_dataSourceParameters_ExasolParameters should be set to null
            if (requestDataSourceParameters_dataSourceParameters_ExasolParametersIsNull)
            {
                requestDataSourceParameters_dataSourceParameters_ExasolParameters = null;
            }
            if (requestDataSourceParameters_dataSourceParameters_ExasolParameters != null)
            {
                request.DataSourceParameters.ExasolParameters = requestDataSourceParameters_dataSourceParameters_ExasolParameters;
                requestDataSourceParametersIsNull = false;
            }
            Amazon.QuickSight.Model.RdsParameters requestDataSourceParameters_dataSourceParameters_RdsParameters = null;
            
             // populate RdsParameters
            var requestDataSourceParameters_dataSourceParameters_RdsParametersIsNull = true;
            requestDataSourceParameters_dataSourceParameters_RdsParameters = new Amazon.QuickSight.Model.RdsParameters();
            System.String requestDataSourceParameters_dataSourceParameters_RdsParameters_rdsParameters_Database = null;
            if (cmdletContext.RdsParameters_Database != null)
            {
                requestDataSourceParameters_dataSourceParameters_RdsParameters_rdsParameters_Database = cmdletContext.RdsParameters_Database;
            }
            if (requestDataSourceParameters_dataSourceParameters_RdsParameters_rdsParameters_Database != null)
            {
                requestDataSourceParameters_dataSourceParameters_RdsParameters.Database = requestDataSourceParameters_dataSourceParameters_RdsParameters_rdsParameters_Database;
                requestDataSourceParameters_dataSourceParameters_RdsParametersIsNull = false;
            }
            System.String requestDataSourceParameters_dataSourceParameters_RdsParameters_rdsParameters_InstanceId = null;
            if (cmdletContext.RdsParameters_InstanceId != null)
            {
                requestDataSourceParameters_dataSourceParameters_RdsParameters_rdsParameters_InstanceId = cmdletContext.RdsParameters_InstanceId;
            }
            if (requestDataSourceParameters_dataSourceParameters_RdsParameters_rdsParameters_InstanceId != null)
            {
                requestDataSourceParameters_dataSourceParameters_RdsParameters.InstanceId = requestDataSourceParameters_dataSourceParameters_RdsParameters_rdsParameters_InstanceId;
                requestDataSourceParameters_dataSourceParameters_RdsParametersIsNull = false;
            }
             // determine if requestDataSourceParameters_dataSourceParameters_RdsParameters should be set to null
            if (requestDataSourceParameters_dataSourceParameters_RdsParametersIsNull)
            {
                requestDataSourceParameters_dataSourceParameters_RdsParameters = null;
            }
            if (requestDataSourceParameters_dataSourceParameters_RdsParameters != null)
            {
                request.DataSourceParameters.RdsParameters = requestDataSourceParameters_dataSourceParameters_RdsParameters;
                requestDataSourceParametersIsNull = false;
            }
            Amazon.QuickSight.Model.S3Parameters requestDataSourceParameters_dataSourceParameters_S3Parameters = null;
            
             // populate S3Parameters
            var requestDataSourceParameters_dataSourceParameters_S3ParametersIsNull = true;
            requestDataSourceParameters_dataSourceParameters_S3Parameters = new Amazon.QuickSight.Model.S3Parameters();
            System.String requestDataSourceParameters_dataSourceParameters_S3Parameters_s3Parameters_RoleArn = null;
            if (cmdletContext.S3Parameters_RoleArn != null)
            {
                requestDataSourceParameters_dataSourceParameters_S3Parameters_s3Parameters_RoleArn = cmdletContext.S3Parameters_RoleArn;
            }
            if (requestDataSourceParameters_dataSourceParameters_S3Parameters_s3Parameters_RoleArn != null)
            {
                requestDataSourceParameters_dataSourceParameters_S3Parameters.RoleArn = requestDataSourceParameters_dataSourceParameters_S3Parameters_s3Parameters_RoleArn;
                requestDataSourceParameters_dataSourceParameters_S3ParametersIsNull = false;
            }
            Amazon.QuickSight.Model.ManifestFileLocation requestDataSourceParameters_dataSourceParameters_S3Parameters_dataSourceParameters_S3Parameters_ManifestFileLocation = null;
            
             // populate ManifestFileLocation
            var requestDataSourceParameters_dataSourceParameters_S3Parameters_dataSourceParameters_S3Parameters_ManifestFileLocationIsNull = true;
            requestDataSourceParameters_dataSourceParameters_S3Parameters_dataSourceParameters_S3Parameters_ManifestFileLocation = new Amazon.QuickSight.Model.ManifestFileLocation();
            System.String requestDataSourceParameters_dataSourceParameters_S3Parameters_dataSourceParameters_S3Parameters_ManifestFileLocation_manifestFileLocation_Bucket = null;
            if (cmdletContext.ManifestFileLocation_Bucket != null)
            {
                requestDataSourceParameters_dataSourceParameters_S3Parameters_dataSourceParameters_S3Parameters_ManifestFileLocation_manifestFileLocation_Bucket = cmdletContext.ManifestFileLocation_Bucket;
            }
            if (requestDataSourceParameters_dataSourceParameters_S3Parameters_dataSourceParameters_S3Parameters_ManifestFileLocation_manifestFileLocation_Bucket != null)
            {
                requestDataSourceParameters_dataSourceParameters_S3Parameters_dataSourceParameters_S3Parameters_ManifestFileLocation.Bucket = requestDataSourceParameters_dataSourceParameters_S3Parameters_dataSourceParameters_S3Parameters_ManifestFileLocation_manifestFileLocation_Bucket;
                requestDataSourceParameters_dataSourceParameters_S3Parameters_dataSourceParameters_S3Parameters_ManifestFileLocationIsNull = false;
            }
            System.String requestDataSourceParameters_dataSourceParameters_S3Parameters_dataSourceParameters_S3Parameters_ManifestFileLocation_manifestFileLocation_Key = null;
            if (cmdletContext.ManifestFileLocation_Key != null)
            {
                requestDataSourceParameters_dataSourceParameters_S3Parameters_dataSourceParameters_S3Parameters_ManifestFileLocation_manifestFileLocation_Key = cmdletContext.ManifestFileLocation_Key;
            }
            if (requestDataSourceParameters_dataSourceParameters_S3Parameters_dataSourceParameters_S3Parameters_ManifestFileLocation_manifestFileLocation_Key != null)
            {
                requestDataSourceParameters_dataSourceParameters_S3Parameters_dataSourceParameters_S3Parameters_ManifestFileLocation.Key = requestDataSourceParameters_dataSourceParameters_S3Parameters_dataSourceParameters_S3Parameters_ManifestFileLocation_manifestFileLocation_Key;
                requestDataSourceParameters_dataSourceParameters_S3Parameters_dataSourceParameters_S3Parameters_ManifestFileLocationIsNull = false;
            }
             // determine if requestDataSourceParameters_dataSourceParameters_S3Parameters_dataSourceParameters_S3Parameters_ManifestFileLocation should be set to null
            if (requestDataSourceParameters_dataSourceParameters_S3Parameters_dataSourceParameters_S3Parameters_ManifestFileLocationIsNull)
            {
                requestDataSourceParameters_dataSourceParameters_S3Parameters_dataSourceParameters_S3Parameters_ManifestFileLocation = null;
            }
            if (requestDataSourceParameters_dataSourceParameters_S3Parameters_dataSourceParameters_S3Parameters_ManifestFileLocation != null)
            {
                requestDataSourceParameters_dataSourceParameters_S3Parameters.ManifestFileLocation = requestDataSourceParameters_dataSourceParameters_S3Parameters_dataSourceParameters_S3Parameters_ManifestFileLocation;
                requestDataSourceParameters_dataSourceParameters_S3ParametersIsNull = false;
            }
             // determine if requestDataSourceParameters_dataSourceParameters_S3Parameters should be set to null
            if (requestDataSourceParameters_dataSourceParameters_S3ParametersIsNull)
            {
                requestDataSourceParameters_dataSourceParameters_S3Parameters = null;
            }
            if (requestDataSourceParameters_dataSourceParameters_S3Parameters != null)
            {
                request.DataSourceParameters.S3Parameters = requestDataSourceParameters_dataSourceParameters_S3Parameters;
                requestDataSourceParametersIsNull = false;
            }
            Amazon.QuickSight.Model.SparkParameters requestDataSourceParameters_dataSourceParameters_SparkParameters = null;
            
             // populate SparkParameters
            var requestDataSourceParameters_dataSourceParameters_SparkParametersIsNull = true;
            requestDataSourceParameters_dataSourceParameters_SparkParameters = new Amazon.QuickSight.Model.SparkParameters();
            System.String requestDataSourceParameters_dataSourceParameters_SparkParameters_sparkParameters_Host = null;
            if (cmdletContext.SparkParameters_Host != null)
            {
                requestDataSourceParameters_dataSourceParameters_SparkParameters_sparkParameters_Host = cmdletContext.SparkParameters_Host;
            }
            if (requestDataSourceParameters_dataSourceParameters_SparkParameters_sparkParameters_Host != null)
            {
                requestDataSourceParameters_dataSourceParameters_SparkParameters.Host = requestDataSourceParameters_dataSourceParameters_SparkParameters_sparkParameters_Host;
                requestDataSourceParameters_dataSourceParameters_SparkParametersIsNull = false;
            }
            System.Int32? requestDataSourceParameters_dataSourceParameters_SparkParameters_sparkParameters_Port = null;
            if (cmdletContext.SparkParameters_Port != null)
            {
                requestDataSourceParameters_dataSourceParameters_SparkParameters_sparkParameters_Port = cmdletContext.SparkParameters_Port.Value;
            }
            if (requestDataSourceParameters_dataSourceParameters_SparkParameters_sparkParameters_Port != null)
            {
                requestDataSourceParameters_dataSourceParameters_SparkParameters.Port = requestDataSourceParameters_dataSourceParameters_SparkParameters_sparkParameters_Port.Value;
                requestDataSourceParameters_dataSourceParameters_SparkParametersIsNull = false;
            }
             // determine if requestDataSourceParameters_dataSourceParameters_SparkParameters should be set to null
            if (requestDataSourceParameters_dataSourceParameters_SparkParametersIsNull)
            {
                requestDataSourceParameters_dataSourceParameters_SparkParameters = null;
            }
            if (requestDataSourceParameters_dataSourceParameters_SparkParameters != null)
            {
                request.DataSourceParameters.SparkParameters = requestDataSourceParameters_dataSourceParameters_SparkParameters;
                requestDataSourceParametersIsNull = false;
            }
            Amazon.QuickSight.Model.TwitterParameters requestDataSourceParameters_dataSourceParameters_TwitterParameters = null;
            
             // populate TwitterParameters
            var requestDataSourceParameters_dataSourceParameters_TwitterParametersIsNull = true;
            requestDataSourceParameters_dataSourceParameters_TwitterParameters = new Amazon.QuickSight.Model.TwitterParameters();
            System.Int32? requestDataSourceParameters_dataSourceParameters_TwitterParameters_twitterParameters_MaxRow = null;
            if (cmdletContext.TwitterParameters_MaxRow != null)
            {
                requestDataSourceParameters_dataSourceParameters_TwitterParameters_twitterParameters_MaxRow = cmdletContext.TwitterParameters_MaxRow.Value;
            }
            if (requestDataSourceParameters_dataSourceParameters_TwitterParameters_twitterParameters_MaxRow != null)
            {
                requestDataSourceParameters_dataSourceParameters_TwitterParameters.MaxRows = requestDataSourceParameters_dataSourceParameters_TwitterParameters_twitterParameters_MaxRow.Value;
                requestDataSourceParameters_dataSourceParameters_TwitterParametersIsNull = false;
            }
            System.String requestDataSourceParameters_dataSourceParameters_TwitterParameters_twitterParameters_Query = null;
            if (cmdletContext.TwitterParameters_Query != null)
            {
                requestDataSourceParameters_dataSourceParameters_TwitterParameters_twitterParameters_Query = cmdletContext.TwitterParameters_Query;
            }
            if (requestDataSourceParameters_dataSourceParameters_TwitterParameters_twitterParameters_Query != null)
            {
                requestDataSourceParameters_dataSourceParameters_TwitterParameters.Query = requestDataSourceParameters_dataSourceParameters_TwitterParameters_twitterParameters_Query;
                requestDataSourceParameters_dataSourceParameters_TwitterParametersIsNull = false;
            }
             // determine if requestDataSourceParameters_dataSourceParameters_TwitterParameters should be set to null
            if (requestDataSourceParameters_dataSourceParameters_TwitterParametersIsNull)
            {
                requestDataSourceParameters_dataSourceParameters_TwitterParameters = null;
            }
            if (requestDataSourceParameters_dataSourceParameters_TwitterParameters != null)
            {
                request.DataSourceParameters.TwitterParameters = requestDataSourceParameters_dataSourceParameters_TwitterParameters;
                requestDataSourceParametersIsNull = false;
            }
            Amazon.QuickSight.Model.AuroraParameters requestDataSourceParameters_dataSourceParameters_AuroraParameters = null;
            
             // populate AuroraParameters
            var requestDataSourceParameters_dataSourceParameters_AuroraParametersIsNull = true;
            requestDataSourceParameters_dataSourceParameters_AuroraParameters = new Amazon.QuickSight.Model.AuroraParameters();
            System.String requestDataSourceParameters_dataSourceParameters_AuroraParameters_auroraParameters_Database = null;
            if (cmdletContext.AuroraParameters_Database != null)
            {
                requestDataSourceParameters_dataSourceParameters_AuroraParameters_auroraParameters_Database = cmdletContext.AuroraParameters_Database;
            }
            if (requestDataSourceParameters_dataSourceParameters_AuroraParameters_auroraParameters_Database != null)
            {
                requestDataSourceParameters_dataSourceParameters_AuroraParameters.Database = requestDataSourceParameters_dataSourceParameters_AuroraParameters_auroraParameters_Database;
                requestDataSourceParameters_dataSourceParameters_AuroraParametersIsNull = false;
            }
            System.String requestDataSourceParameters_dataSourceParameters_AuroraParameters_auroraParameters_Host = null;
            if (cmdletContext.AuroraParameters_Host != null)
            {
                requestDataSourceParameters_dataSourceParameters_AuroraParameters_auroraParameters_Host = cmdletContext.AuroraParameters_Host;
            }
            if (requestDataSourceParameters_dataSourceParameters_AuroraParameters_auroraParameters_Host != null)
            {
                requestDataSourceParameters_dataSourceParameters_AuroraParameters.Host = requestDataSourceParameters_dataSourceParameters_AuroraParameters_auroraParameters_Host;
                requestDataSourceParameters_dataSourceParameters_AuroraParametersIsNull = false;
            }
            System.Int32? requestDataSourceParameters_dataSourceParameters_AuroraParameters_auroraParameters_Port = null;
            if (cmdletContext.AuroraParameters_Port != null)
            {
                requestDataSourceParameters_dataSourceParameters_AuroraParameters_auroraParameters_Port = cmdletContext.AuroraParameters_Port.Value;
            }
            if (requestDataSourceParameters_dataSourceParameters_AuroraParameters_auroraParameters_Port != null)
            {
                requestDataSourceParameters_dataSourceParameters_AuroraParameters.Port = requestDataSourceParameters_dataSourceParameters_AuroraParameters_auroraParameters_Port.Value;
                requestDataSourceParameters_dataSourceParameters_AuroraParametersIsNull = false;
            }
             // determine if requestDataSourceParameters_dataSourceParameters_AuroraParameters should be set to null
            if (requestDataSourceParameters_dataSourceParameters_AuroraParametersIsNull)
            {
                requestDataSourceParameters_dataSourceParameters_AuroraParameters = null;
            }
            if (requestDataSourceParameters_dataSourceParameters_AuroraParameters != null)
            {
                request.DataSourceParameters.AuroraParameters = requestDataSourceParameters_dataSourceParameters_AuroraParameters;
                requestDataSourceParametersIsNull = false;
            }
            Amazon.QuickSight.Model.AuroraPostgreSqlParameters requestDataSourceParameters_dataSourceParameters_AuroraPostgreSqlParameters = null;
            
             // populate AuroraPostgreSqlParameters
            var requestDataSourceParameters_dataSourceParameters_AuroraPostgreSqlParametersIsNull = true;
            requestDataSourceParameters_dataSourceParameters_AuroraPostgreSqlParameters = new Amazon.QuickSight.Model.AuroraPostgreSqlParameters();
            System.String requestDataSourceParameters_dataSourceParameters_AuroraPostgreSqlParameters_auroraPostgreSqlParameters_Database = null;
            if (cmdletContext.AuroraPostgreSqlParameters_Database != null)
            {
                requestDataSourceParameters_dataSourceParameters_AuroraPostgreSqlParameters_auroraPostgreSqlParameters_Database = cmdletContext.AuroraPostgreSqlParameters_Database;
            }
            if (requestDataSourceParameters_dataSourceParameters_AuroraPostgreSqlParameters_auroraPostgreSqlParameters_Database != null)
            {
                requestDataSourceParameters_dataSourceParameters_AuroraPostgreSqlParameters.Database = requestDataSourceParameters_dataSourceParameters_AuroraPostgreSqlParameters_auroraPostgreSqlParameters_Database;
                requestDataSourceParameters_dataSourceParameters_AuroraPostgreSqlParametersIsNull = false;
            }
            System.String requestDataSourceParameters_dataSourceParameters_AuroraPostgreSqlParameters_auroraPostgreSqlParameters_Host = null;
            if (cmdletContext.AuroraPostgreSqlParameters_Host != null)
            {
                requestDataSourceParameters_dataSourceParameters_AuroraPostgreSqlParameters_auroraPostgreSqlParameters_Host = cmdletContext.AuroraPostgreSqlParameters_Host;
            }
            if (requestDataSourceParameters_dataSourceParameters_AuroraPostgreSqlParameters_auroraPostgreSqlParameters_Host != null)
            {
                requestDataSourceParameters_dataSourceParameters_AuroraPostgreSqlParameters.Host = requestDataSourceParameters_dataSourceParameters_AuroraPostgreSqlParameters_auroraPostgreSqlParameters_Host;
                requestDataSourceParameters_dataSourceParameters_AuroraPostgreSqlParametersIsNull = false;
            }
            System.Int32? requestDataSourceParameters_dataSourceParameters_AuroraPostgreSqlParameters_auroraPostgreSqlParameters_Port = null;
            if (cmdletContext.AuroraPostgreSqlParameters_Port != null)
            {
                requestDataSourceParameters_dataSourceParameters_AuroraPostgreSqlParameters_auroraPostgreSqlParameters_Port = cmdletContext.AuroraPostgreSqlParameters_Port.Value;
            }
            if (requestDataSourceParameters_dataSourceParameters_AuroraPostgreSqlParameters_auroraPostgreSqlParameters_Port != null)
            {
                requestDataSourceParameters_dataSourceParameters_AuroraPostgreSqlParameters.Port = requestDataSourceParameters_dataSourceParameters_AuroraPostgreSqlParameters_auroraPostgreSqlParameters_Port.Value;
                requestDataSourceParameters_dataSourceParameters_AuroraPostgreSqlParametersIsNull = false;
            }
             // determine if requestDataSourceParameters_dataSourceParameters_AuroraPostgreSqlParameters should be set to null
            if (requestDataSourceParameters_dataSourceParameters_AuroraPostgreSqlParametersIsNull)
            {
                requestDataSourceParameters_dataSourceParameters_AuroraPostgreSqlParameters = null;
            }
            if (requestDataSourceParameters_dataSourceParameters_AuroraPostgreSqlParameters != null)
            {
                request.DataSourceParameters.AuroraPostgreSqlParameters = requestDataSourceParameters_dataSourceParameters_AuroraPostgreSqlParameters;
                requestDataSourceParametersIsNull = false;
            }
            Amazon.QuickSight.Model.DatabricksParameters requestDataSourceParameters_dataSourceParameters_DatabricksParameters = null;
            
             // populate DatabricksParameters
            var requestDataSourceParameters_dataSourceParameters_DatabricksParametersIsNull = true;
            requestDataSourceParameters_dataSourceParameters_DatabricksParameters = new Amazon.QuickSight.Model.DatabricksParameters();
            System.String requestDataSourceParameters_dataSourceParameters_DatabricksParameters_databricksParameters_Host = null;
            if (cmdletContext.DatabricksParameters_Host != null)
            {
                requestDataSourceParameters_dataSourceParameters_DatabricksParameters_databricksParameters_Host = cmdletContext.DatabricksParameters_Host;
            }
            if (requestDataSourceParameters_dataSourceParameters_DatabricksParameters_databricksParameters_Host != null)
            {
                requestDataSourceParameters_dataSourceParameters_DatabricksParameters.Host = requestDataSourceParameters_dataSourceParameters_DatabricksParameters_databricksParameters_Host;
                requestDataSourceParameters_dataSourceParameters_DatabricksParametersIsNull = false;
            }
            System.Int32? requestDataSourceParameters_dataSourceParameters_DatabricksParameters_databricksParameters_Port = null;
            if (cmdletContext.DatabricksParameters_Port != null)
            {
                requestDataSourceParameters_dataSourceParameters_DatabricksParameters_databricksParameters_Port = cmdletContext.DatabricksParameters_Port.Value;
            }
            if (requestDataSourceParameters_dataSourceParameters_DatabricksParameters_databricksParameters_Port != null)
            {
                requestDataSourceParameters_dataSourceParameters_DatabricksParameters.Port = requestDataSourceParameters_dataSourceParameters_DatabricksParameters_databricksParameters_Port.Value;
                requestDataSourceParameters_dataSourceParameters_DatabricksParametersIsNull = false;
            }
            System.String requestDataSourceParameters_dataSourceParameters_DatabricksParameters_databricksParameters_SqlEndpointPath = null;
            if (cmdletContext.DatabricksParameters_SqlEndpointPath != null)
            {
                requestDataSourceParameters_dataSourceParameters_DatabricksParameters_databricksParameters_SqlEndpointPath = cmdletContext.DatabricksParameters_SqlEndpointPath;
            }
            if (requestDataSourceParameters_dataSourceParameters_DatabricksParameters_databricksParameters_SqlEndpointPath != null)
            {
                requestDataSourceParameters_dataSourceParameters_DatabricksParameters.SqlEndpointPath = requestDataSourceParameters_dataSourceParameters_DatabricksParameters_databricksParameters_SqlEndpointPath;
                requestDataSourceParameters_dataSourceParameters_DatabricksParametersIsNull = false;
            }
             // determine if requestDataSourceParameters_dataSourceParameters_DatabricksParameters should be set to null
            if (requestDataSourceParameters_dataSourceParameters_DatabricksParametersIsNull)
            {
                requestDataSourceParameters_dataSourceParameters_DatabricksParameters = null;
            }
            if (requestDataSourceParameters_dataSourceParameters_DatabricksParameters != null)
            {
                request.DataSourceParameters.DatabricksParameters = requestDataSourceParameters_dataSourceParameters_DatabricksParameters;
                requestDataSourceParametersIsNull = false;
            }
            Amazon.QuickSight.Model.MariaDbParameters requestDataSourceParameters_dataSourceParameters_MariaDbParameters = null;
            
             // populate MariaDbParameters
            var requestDataSourceParameters_dataSourceParameters_MariaDbParametersIsNull = true;
            requestDataSourceParameters_dataSourceParameters_MariaDbParameters = new Amazon.QuickSight.Model.MariaDbParameters();
            System.String requestDataSourceParameters_dataSourceParameters_MariaDbParameters_mariaDbParameters_Database = null;
            if (cmdletContext.MariaDbParameters_Database != null)
            {
                requestDataSourceParameters_dataSourceParameters_MariaDbParameters_mariaDbParameters_Database = cmdletContext.MariaDbParameters_Database;
            }
            if (requestDataSourceParameters_dataSourceParameters_MariaDbParameters_mariaDbParameters_Database != null)
            {
                requestDataSourceParameters_dataSourceParameters_MariaDbParameters.Database = requestDataSourceParameters_dataSourceParameters_MariaDbParameters_mariaDbParameters_Database;
                requestDataSourceParameters_dataSourceParameters_MariaDbParametersIsNull = false;
            }
            System.String requestDataSourceParameters_dataSourceParameters_MariaDbParameters_mariaDbParameters_Host = null;
            if (cmdletContext.MariaDbParameters_Host != null)
            {
                requestDataSourceParameters_dataSourceParameters_MariaDbParameters_mariaDbParameters_Host = cmdletContext.MariaDbParameters_Host;
            }
            if (requestDataSourceParameters_dataSourceParameters_MariaDbParameters_mariaDbParameters_Host != null)
            {
                requestDataSourceParameters_dataSourceParameters_MariaDbParameters.Host = requestDataSourceParameters_dataSourceParameters_MariaDbParameters_mariaDbParameters_Host;
                requestDataSourceParameters_dataSourceParameters_MariaDbParametersIsNull = false;
            }
            System.Int32? requestDataSourceParameters_dataSourceParameters_MariaDbParameters_mariaDbParameters_Port = null;
            if (cmdletContext.MariaDbParameters_Port != null)
            {
                requestDataSourceParameters_dataSourceParameters_MariaDbParameters_mariaDbParameters_Port = cmdletContext.MariaDbParameters_Port.Value;
            }
            if (requestDataSourceParameters_dataSourceParameters_MariaDbParameters_mariaDbParameters_Port != null)
            {
                requestDataSourceParameters_dataSourceParameters_MariaDbParameters.Port = requestDataSourceParameters_dataSourceParameters_MariaDbParameters_mariaDbParameters_Port.Value;
                requestDataSourceParameters_dataSourceParameters_MariaDbParametersIsNull = false;
            }
             // determine if requestDataSourceParameters_dataSourceParameters_MariaDbParameters should be set to null
            if (requestDataSourceParameters_dataSourceParameters_MariaDbParametersIsNull)
            {
                requestDataSourceParameters_dataSourceParameters_MariaDbParameters = null;
            }
            if (requestDataSourceParameters_dataSourceParameters_MariaDbParameters != null)
            {
                request.DataSourceParameters.MariaDbParameters = requestDataSourceParameters_dataSourceParameters_MariaDbParameters;
                requestDataSourceParametersIsNull = false;
            }
            Amazon.QuickSight.Model.MySqlParameters requestDataSourceParameters_dataSourceParameters_MySqlParameters = null;
            
             // populate MySqlParameters
            var requestDataSourceParameters_dataSourceParameters_MySqlParametersIsNull = true;
            requestDataSourceParameters_dataSourceParameters_MySqlParameters = new Amazon.QuickSight.Model.MySqlParameters();
            System.String requestDataSourceParameters_dataSourceParameters_MySqlParameters_mySqlParameters_Database = null;
            if (cmdletContext.MySqlParameters_Database != null)
            {
                requestDataSourceParameters_dataSourceParameters_MySqlParameters_mySqlParameters_Database = cmdletContext.MySqlParameters_Database;
            }
            if (requestDataSourceParameters_dataSourceParameters_MySqlParameters_mySqlParameters_Database != null)
            {
                requestDataSourceParameters_dataSourceParameters_MySqlParameters.Database = requestDataSourceParameters_dataSourceParameters_MySqlParameters_mySqlParameters_Database;
                requestDataSourceParameters_dataSourceParameters_MySqlParametersIsNull = false;
            }
            System.String requestDataSourceParameters_dataSourceParameters_MySqlParameters_mySqlParameters_Host = null;
            if (cmdletContext.MySqlParameters_Host != null)
            {
                requestDataSourceParameters_dataSourceParameters_MySqlParameters_mySqlParameters_Host = cmdletContext.MySqlParameters_Host;
            }
            if (requestDataSourceParameters_dataSourceParameters_MySqlParameters_mySqlParameters_Host != null)
            {
                requestDataSourceParameters_dataSourceParameters_MySqlParameters.Host = requestDataSourceParameters_dataSourceParameters_MySqlParameters_mySqlParameters_Host;
                requestDataSourceParameters_dataSourceParameters_MySqlParametersIsNull = false;
            }
            System.Int32? requestDataSourceParameters_dataSourceParameters_MySqlParameters_mySqlParameters_Port = null;
            if (cmdletContext.MySqlParameters_Port != null)
            {
                requestDataSourceParameters_dataSourceParameters_MySqlParameters_mySqlParameters_Port = cmdletContext.MySqlParameters_Port.Value;
            }
            if (requestDataSourceParameters_dataSourceParameters_MySqlParameters_mySqlParameters_Port != null)
            {
                requestDataSourceParameters_dataSourceParameters_MySqlParameters.Port = requestDataSourceParameters_dataSourceParameters_MySqlParameters_mySqlParameters_Port.Value;
                requestDataSourceParameters_dataSourceParameters_MySqlParametersIsNull = false;
            }
             // determine if requestDataSourceParameters_dataSourceParameters_MySqlParameters should be set to null
            if (requestDataSourceParameters_dataSourceParameters_MySqlParametersIsNull)
            {
                requestDataSourceParameters_dataSourceParameters_MySqlParameters = null;
            }
            if (requestDataSourceParameters_dataSourceParameters_MySqlParameters != null)
            {
                request.DataSourceParameters.MySqlParameters = requestDataSourceParameters_dataSourceParameters_MySqlParameters;
                requestDataSourceParametersIsNull = false;
            }
            Amazon.QuickSight.Model.OracleParameters requestDataSourceParameters_dataSourceParameters_OracleParameters = null;
            
             // populate OracleParameters
            var requestDataSourceParameters_dataSourceParameters_OracleParametersIsNull = true;
            requestDataSourceParameters_dataSourceParameters_OracleParameters = new Amazon.QuickSight.Model.OracleParameters();
            System.String requestDataSourceParameters_dataSourceParameters_OracleParameters_oracleParameters_Database = null;
            if (cmdletContext.OracleParameters_Database != null)
            {
                requestDataSourceParameters_dataSourceParameters_OracleParameters_oracleParameters_Database = cmdletContext.OracleParameters_Database;
            }
            if (requestDataSourceParameters_dataSourceParameters_OracleParameters_oracleParameters_Database != null)
            {
                requestDataSourceParameters_dataSourceParameters_OracleParameters.Database = requestDataSourceParameters_dataSourceParameters_OracleParameters_oracleParameters_Database;
                requestDataSourceParameters_dataSourceParameters_OracleParametersIsNull = false;
            }
            System.String requestDataSourceParameters_dataSourceParameters_OracleParameters_oracleParameters_Host = null;
            if (cmdletContext.OracleParameters_Host != null)
            {
                requestDataSourceParameters_dataSourceParameters_OracleParameters_oracleParameters_Host = cmdletContext.OracleParameters_Host;
            }
            if (requestDataSourceParameters_dataSourceParameters_OracleParameters_oracleParameters_Host != null)
            {
                requestDataSourceParameters_dataSourceParameters_OracleParameters.Host = requestDataSourceParameters_dataSourceParameters_OracleParameters_oracleParameters_Host;
                requestDataSourceParameters_dataSourceParameters_OracleParametersIsNull = false;
            }
            System.Int32? requestDataSourceParameters_dataSourceParameters_OracleParameters_oracleParameters_Port = null;
            if (cmdletContext.OracleParameters_Port != null)
            {
                requestDataSourceParameters_dataSourceParameters_OracleParameters_oracleParameters_Port = cmdletContext.OracleParameters_Port.Value;
            }
            if (requestDataSourceParameters_dataSourceParameters_OracleParameters_oracleParameters_Port != null)
            {
                requestDataSourceParameters_dataSourceParameters_OracleParameters.Port = requestDataSourceParameters_dataSourceParameters_OracleParameters_oracleParameters_Port.Value;
                requestDataSourceParameters_dataSourceParameters_OracleParametersIsNull = false;
            }
             // determine if requestDataSourceParameters_dataSourceParameters_OracleParameters should be set to null
            if (requestDataSourceParameters_dataSourceParameters_OracleParametersIsNull)
            {
                requestDataSourceParameters_dataSourceParameters_OracleParameters = null;
            }
            if (requestDataSourceParameters_dataSourceParameters_OracleParameters != null)
            {
                request.DataSourceParameters.OracleParameters = requestDataSourceParameters_dataSourceParameters_OracleParameters;
                requestDataSourceParametersIsNull = false;
            }
            Amazon.QuickSight.Model.PostgreSqlParameters requestDataSourceParameters_dataSourceParameters_PostgreSqlParameters = null;
            
             // populate PostgreSqlParameters
            var requestDataSourceParameters_dataSourceParameters_PostgreSqlParametersIsNull = true;
            requestDataSourceParameters_dataSourceParameters_PostgreSqlParameters = new Amazon.QuickSight.Model.PostgreSqlParameters();
            System.String requestDataSourceParameters_dataSourceParameters_PostgreSqlParameters_postgreSqlParameters_Database = null;
            if (cmdletContext.PostgreSqlParameters_Database != null)
            {
                requestDataSourceParameters_dataSourceParameters_PostgreSqlParameters_postgreSqlParameters_Database = cmdletContext.PostgreSqlParameters_Database;
            }
            if (requestDataSourceParameters_dataSourceParameters_PostgreSqlParameters_postgreSqlParameters_Database != null)
            {
                requestDataSourceParameters_dataSourceParameters_PostgreSqlParameters.Database = requestDataSourceParameters_dataSourceParameters_PostgreSqlParameters_postgreSqlParameters_Database;
                requestDataSourceParameters_dataSourceParameters_PostgreSqlParametersIsNull = false;
            }
            System.String requestDataSourceParameters_dataSourceParameters_PostgreSqlParameters_postgreSqlParameters_Host = null;
            if (cmdletContext.PostgreSqlParameters_Host != null)
            {
                requestDataSourceParameters_dataSourceParameters_PostgreSqlParameters_postgreSqlParameters_Host = cmdletContext.PostgreSqlParameters_Host;
            }
            if (requestDataSourceParameters_dataSourceParameters_PostgreSqlParameters_postgreSqlParameters_Host != null)
            {
                requestDataSourceParameters_dataSourceParameters_PostgreSqlParameters.Host = requestDataSourceParameters_dataSourceParameters_PostgreSqlParameters_postgreSqlParameters_Host;
                requestDataSourceParameters_dataSourceParameters_PostgreSqlParametersIsNull = false;
            }
            System.Int32? requestDataSourceParameters_dataSourceParameters_PostgreSqlParameters_postgreSqlParameters_Port = null;
            if (cmdletContext.PostgreSqlParameters_Port != null)
            {
                requestDataSourceParameters_dataSourceParameters_PostgreSqlParameters_postgreSqlParameters_Port = cmdletContext.PostgreSqlParameters_Port.Value;
            }
            if (requestDataSourceParameters_dataSourceParameters_PostgreSqlParameters_postgreSqlParameters_Port != null)
            {
                requestDataSourceParameters_dataSourceParameters_PostgreSqlParameters.Port = requestDataSourceParameters_dataSourceParameters_PostgreSqlParameters_postgreSqlParameters_Port.Value;
                requestDataSourceParameters_dataSourceParameters_PostgreSqlParametersIsNull = false;
            }
             // determine if requestDataSourceParameters_dataSourceParameters_PostgreSqlParameters should be set to null
            if (requestDataSourceParameters_dataSourceParameters_PostgreSqlParametersIsNull)
            {
                requestDataSourceParameters_dataSourceParameters_PostgreSqlParameters = null;
            }
            if (requestDataSourceParameters_dataSourceParameters_PostgreSqlParameters != null)
            {
                request.DataSourceParameters.PostgreSqlParameters = requestDataSourceParameters_dataSourceParameters_PostgreSqlParameters;
                requestDataSourceParametersIsNull = false;
            }
            Amazon.QuickSight.Model.PrestoParameters requestDataSourceParameters_dataSourceParameters_PrestoParameters = null;
            
             // populate PrestoParameters
            var requestDataSourceParameters_dataSourceParameters_PrestoParametersIsNull = true;
            requestDataSourceParameters_dataSourceParameters_PrestoParameters = new Amazon.QuickSight.Model.PrestoParameters();
            System.String requestDataSourceParameters_dataSourceParameters_PrestoParameters_prestoParameters_Catalog = null;
            if (cmdletContext.PrestoParameters_Catalog != null)
            {
                requestDataSourceParameters_dataSourceParameters_PrestoParameters_prestoParameters_Catalog = cmdletContext.PrestoParameters_Catalog;
            }
            if (requestDataSourceParameters_dataSourceParameters_PrestoParameters_prestoParameters_Catalog != null)
            {
                requestDataSourceParameters_dataSourceParameters_PrestoParameters.Catalog = requestDataSourceParameters_dataSourceParameters_PrestoParameters_prestoParameters_Catalog;
                requestDataSourceParameters_dataSourceParameters_PrestoParametersIsNull = false;
            }
            System.String requestDataSourceParameters_dataSourceParameters_PrestoParameters_prestoParameters_Host = null;
            if (cmdletContext.PrestoParameters_Host != null)
            {
                requestDataSourceParameters_dataSourceParameters_PrestoParameters_prestoParameters_Host = cmdletContext.PrestoParameters_Host;
            }
            if (requestDataSourceParameters_dataSourceParameters_PrestoParameters_prestoParameters_Host != null)
            {
                requestDataSourceParameters_dataSourceParameters_PrestoParameters.Host = requestDataSourceParameters_dataSourceParameters_PrestoParameters_prestoParameters_Host;
                requestDataSourceParameters_dataSourceParameters_PrestoParametersIsNull = false;
            }
            System.Int32? requestDataSourceParameters_dataSourceParameters_PrestoParameters_prestoParameters_Port = null;
            if (cmdletContext.PrestoParameters_Port != null)
            {
                requestDataSourceParameters_dataSourceParameters_PrestoParameters_prestoParameters_Port = cmdletContext.PrestoParameters_Port.Value;
            }
            if (requestDataSourceParameters_dataSourceParameters_PrestoParameters_prestoParameters_Port != null)
            {
                requestDataSourceParameters_dataSourceParameters_PrestoParameters.Port = requestDataSourceParameters_dataSourceParameters_PrestoParameters_prestoParameters_Port.Value;
                requestDataSourceParameters_dataSourceParameters_PrestoParametersIsNull = false;
            }
             // determine if requestDataSourceParameters_dataSourceParameters_PrestoParameters should be set to null
            if (requestDataSourceParameters_dataSourceParameters_PrestoParametersIsNull)
            {
                requestDataSourceParameters_dataSourceParameters_PrestoParameters = null;
            }
            if (requestDataSourceParameters_dataSourceParameters_PrestoParameters != null)
            {
                request.DataSourceParameters.PrestoParameters = requestDataSourceParameters_dataSourceParameters_PrestoParameters;
                requestDataSourceParametersIsNull = false;
            }
            Amazon.QuickSight.Model.SqlServerParameters requestDataSourceParameters_dataSourceParameters_SqlServerParameters = null;
            
             // populate SqlServerParameters
            var requestDataSourceParameters_dataSourceParameters_SqlServerParametersIsNull = true;
            requestDataSourceParameters_dataSourceParameters_SqlServerParameters = new Amazon.QuickSight.Model.SqlServerParameters();
            System.String requestDataSourceParameters_dataSourceParameters_SqlServerParameters_sqlServerParameters_Database = null;
            if (cmdletContext.SqlServerParameters_Database != null)
            {
                requestDataSourceParameters_dataSourceParameters_SqlServerParameters_sqlServerParameters_Database = cmdletContext.SqlServerParameters_Database;
            }
            if (requestDataSourceParameters_dataSourceParameters_SqlServerParameters_sqlServerParameters_Database != null)
            {
                requestDataSourceParameters_dataSourceParameters_SqlServerParameters.Database = requestDataSourceParameters_dataSourceParameters_SqlServerParameters_sqlServerParameters_Database;
                requestDataSourceParameters_dataSourceParameters_SqlServerParametersIsNull = false;
            }
            System.String requestDataSourceParameters_dataSourceParameters_SqlServerParameters_sqlServerParameters_Host = null;
            if (cmdletContext.SqlServerParameters_Host != null)
            {
                requestDataSourceParameters_dataSourceParameters_SqlServerParameters_sqlServerParameters_Host = cmdletContext.SqlServerParameters_Host;
            }
            if (requestDataSourceParameters_dataSourceParameters_SqlServerParameters_sqlServerParameters_Host != null)
            {
                requestDataSourceParameters_dataSourceParameters_SqlServerParameters.Host = requestDataSourceParameters_dataSourceParameters_SqlServerParameters_sqlServerParameters_Host;
                requestDataSourceParameters_dataSourceParameters_SqlServerParametersIsNull = false;
            }
            System.Int32? requestDataSourceParameters_dataSourceParameters_SqlServerParameters_sqlServerParameters_Port = null;
            if (cmdletContext.SqlServerParameters_Port != null)
            {
                requestDataSourceParameters_dataSourceParameters_SqlServerParameters_sqlServerParameters_Port = cmdletContext.SqlServerParameters_Port.Value;
            }
            if (requestDataSourceParameters_dataSourceParameters_SqlServerParameters_sqlServerParameters_Port != null)
            {
                requestDataSourceParameters_dataSourceParameters_SqlServerParameters.Port = requestDataSourceParameters_dataSourceParameters_SqlServerParameters_sqlServerParameters_Port.Value;
                requestDataSourceParameters_dataSourceParameters_SqlServerParametersIsNull = false;
            }
             // determine if requestDataSourceParameters_dataSourceParameters_SqlServerParameters should be set to null
            if (requestDataSourceParameters_dataSourceParameters_SqlServerParametersIsNull)
            {
                requestDataSourceParameters_dataSourceParameters_SqlServerParameters = null;
            }
            if (requestDataSourceParameters_dataSourceParameters_SqlServerParameters != null)
            {
                request.DataSourceParameters.SqlServerParameters = requestDataSourceParameters_dataSourceParameters_SqlServerParameters;
                requestDataSourceParametersIsNull = false;
            }
            Amazon.QuickSight.Model.TeradataParameters requestDataSourceParameters_dataSourceParameters_TeradataParameters = null;
            
             // populate TeradataParameters
            var requestDataSourceParameters_dataSourceParameters_TeradataParametersIsNull = true;
            requestDataSourceParameters_dataSourceParameters_TeradataParameters = new Amazon.QuickSight.Model.TeradataParameters();
            System.String requestDataSourceParameters_dataSourceParameters_TeradataParameters_teradataParameters_Database = null;
            if (cmdletContext.TeradataParameters_Database != null)
            {
                requestDataSourceParameters_dataSourceParameters_TeradataParameters_teradataParameters_Database = cmdletContext.TeradataParameters_Database;
            }
            if (requestDataSourceParameters_dataSourceParameters_TeradataParameters_teradataParameters_Database != null)
            {
                requestDataSourceParameters_dataSourceParameters_TeradataParameters.Database = requestDataSourceParameters_dataSourceParameters_TeradataParameters_teradataParameters_Database;
                requestDataSourceParameters_dataSourceParameters_TeradataParametersIsNull = false;
            }
            System.String requestDataSourceParameters_dataSourceParameters_TeradataParameters_teradataParameters_Host = null;
            if (cmdletContext.TeradataParameters_Host != null)
            {
                requestDataSourceParameters_dataSourceParameters_TeradataParameters_teradataParameters_Host = cmdletContext.TeradataParameters_Host;
            }
            if (requestDataSourceParameters_dataSourceParameters_TeradataParameters_teradataParameters_Host != null)
            {
                requestDataSourceParameters_dataSourceParameters_TeradataParameters.Host = requestDataSourceParameters_dataSourceParameters_TeradataParameters_teradataParameters_Host;
                requestDataSourceParameters_dataSourceParameters_TeradataParametersIsNull = false;
            }
            System.Int32? requestDataSourceParameters_dataSourceParameters_TeradataParameters_teradataParameters_Port = null;
            if (cmdletContext.TeradataParameters_Port != null)
            {
                requestDataSourceParameters_dataSourceParameters_TeradataParameters_teradataParameters_Port = cmdletContext.TeradataParameters_Port.Value;
            }
            if (requestDataSourceParameters_dataSourceParameters_TeradataParameters_teradataParameters_Port != null)
            {
                requestDataSourceParameters_dataSourceParameters_TeradataParameters.Port = requestDataSourceParameters_dataSourceParameters_TeradataParameters_teradataParameters_Port.Value;
                requestDataSourceParameters_dataSourceParameters_TeradataParametersIsNull = false;
            }
             // determine if requestDataSourceParameters_dataSourceParameters_TeradataParameters should be set to null
            if (requestDataSourceParameters_dataSourceParameters_TeradataParametersIsNull)
            {
                requestDataSourceParameters_dataSourceParameters_TeradataParameters = null;
            }
            if (requestDataSourceParameters_dataSourceParameters_TeradataParameters != null)
            {
                request.DataSourceParameters.TeradataParameters = requestDataSourceParameters_dataSourceParameters_TeradataParameters;
                requestDataSourceParametersIsNull = false;
            }
            Amazon.QuickSight.Model.TrinoParameters requestDataSourceParameters_dataSourceParameters_TrinoParameters = null;
            
             // populate TrinoParameters
            var requestDataSourceParameters_dataSourceParameters_TrinoParametersIsNull = true;
            requestDataSourceParameters_dataSourceParameters_TrinoParameters = new Amazon.QuickSight.Model.TrinoParameters();
            System.String requestDataSourceParameters_dataSourceParameters_TrinoParameters_trinoParameters_Catalog = null;
            if (cmdletContext.TrinoParameters_Catalog != null)
            {
                requestDataSourceParameters_dataSourceParameters_TrinoParameters_trinoParameters_Catalog = cmdletContext.TrinoParameters_Catalog;
            }
            if (requestDataSourceParameters_dataSourceParameters_TrinoParameters_trinoParameters_Catalog != null)
            {
                requestDataSourceParameters_dataSourceParameters_TrinoParameters.Catalog = requestDataSourceParameters_dataSourceParameters_TrinoParameters_trinoParameters_Catalog;
                requestDataSourceParameters_dataSourceParameters_TrinoParametersIsNull = false;
            }
            System.String requestDataSourceParameters_dataSourceParameters_TrinoParameters_trinoParameters_Host = null;
            if (cmdletContext.TrinoParameters_Host != null)
            {
                requestDataSourceParameters_dataSourceParameters_TrinoParameters_trinoParameters_Host = cmdletContext.TrinoParameters_Host;
            }
            if (requestDataSourceParameters_dataSourceParameters_TrinoParameters_trinoParameters_Host != null)
            {
                requestDataSourceParameters_dataSourceParameters_TrinoParameters.Host = requestDataSourceParameters_dataSourceParameters_TrinoParameters_trinoParameters_Host;
                requestDataSourceParameters_dataSourceParameters_TrinoParametersIsNull = false;
            }
            System.Int32? requestDataSourceParameters_dataSourceParameters_TrinoParameters_trinoParameters_Port = null;
            if (cmdletContext.TrinoParameters_Port != null)
            {
                requestDataSourceParameters_dataSourceParameters_TrinoParameters_trinoParameters_Port = cmdletContext.TrinoParameters_Port.Value;
            }
            if (requestDataSourceParameters_dataSourceParameters_TrinoParameters_trinoParameters_Port != null)
            {
                requestDataSourceParameters_dataSourceParameters_TrinoParameters.Port = requestDataSourceParameters_dataSourceParameters_TrinoParameters_trinoParameters_Port.Value;
                requestDataSourceParameters_dataSourceParameters_TrinoParametersIsNull = false;
            }
             // determine if requestDataSourceParameters_dataSourceParameters_TrinoParameters should be set to null
            if (requestDataSourceParameters_dataSourceParameters_TrinoParametersIsNull)
            {
                requestDataSourceParameters_dataSourceParameters_TrinoParameters = null;
            }
            if (requestDataSourceParameters_dataSourceParameters_TrinoParameters != null)
            {
                request.DataSourceParameters.TrinoParameters = requestDataSourceParameters_dataSourceParameters_TrinoParameters;
                requestDataSourceParametersIsNull = false;
            }
            Amazon.QuickSight.Model.RedshiftParameters requestDataSourceParameters_dataSourceParameters_RedshiftParameters = null;
            
             // populate RedshiftParameters
            var requestDataSourceParameters_dataSourceParameters_RedshiftParametersIsNull = true;
            requestDataSourceParameters_dataSourceParameters_RedshiftParameters = new Amazon.QuickSight.Model.RedshiftParameters();
            System.String requestDataSourceParameters_dataSourceParameters_RedshiftParameters_redshiftParameters_ClusterId = null;
            if (cmdletContext.RedshiftParameters_ClusterId != null)
            {
                requestDataSourceParameters_dataSourceParameters_RedshiftParameters_redshiftParameters_ClusterId = cmdletContext.RedshiftParameters_ClusterId;
            }
            if (requestDataSourceParameters_dataSourceParameters_RedshiftParameters_redshiftParameters_ClusterId != null)
            {
                requestDataSourceParameters_dataSourceParameters_RedshiftParameters.ClusterId = requestDataSourceParameters_dataSourceParameters_RedshiftParameters_redshiftParameters_ClusterId;
                requestDataSourceParameters_dataSourceParameters_RedshiftParametersIsNull = false;
            }
            System.String requestDataSourceParameters_dataSourceParameters_RedshiftParameters_redshiftParameters_Database = null;
            if (cmdletContext.RedshiftParameters_Database != null)
            {
                requestDataSourceParameters_dataSourceParameters_RedshiftParameters_redshiftParameters_Database = cmdletContext.RedshiftParameters_Database;
            }
            if (requestDataSourceParameters_dataSourceParameters_RedshiftParameters_redshiftParameters_Database != null)
            {
                requestDataSourceParameters_dataSourceParameters_RedshiftParameters.Database = requestDataSourceParameters_dataSourceParameters_RedshiftParameters_redshiftParameters_Database;
                requestDataSourceParameters_dataSourceParameters_RedshiftParametersIsNull = false;
            }
            System.String requestDataSourceParameters_dataSourceParameters_RedshiftParameters_redshiftParameters_Host = null;
            if (cmdletContext.RedshiftParameters_Host != null)
            {
                requestDataSourceParameters_dataSourceParameters_RedshiftParameters_redshiftParameters_Host = cmdletContext.RedshiftParameters_Host;
            }
            if (requestDataSourceParameters_dataSourceParameters_RedshiftParameters_redshiftParameters_Host != null)
            {
                requestDataSourceParameters_dataSourceParameters_RedshiftParameters.Host = requestDataSourceParameters_dataSourceParameters_RedshiftParameters_redshiftParameters_Host;
                requestDataSourceParameters_dataSourceParameters_RedshiftParametersIsNull = false;
            }
            System.Int32? requestDataSourceParameters_dataSourceParameters_RedshiftParameters_redshiftParameters_Port = null;
            if (cmdletContext.RedshiftParameters_Port != null)
            {
                requestDataSourceParameters_dataSourceParameters_RedshiftParameters_redshiftParameters_Port = cmdletContext.RedshiftParameters_Port.Value;
            }
            if (requestDataSourceParameters_dataSourceParameters_RedshiftParameters_redshiftParameters_Port != null)
            {
                requestDataSourceParameters_dataSourceParameters_RedshiftParameters.Port = requestDataSourceParameters_dataSourceParameters_RedshiftParameters_redshiftParameters_Port.Value;
                requestDataSourceParameters_dataSourceParameters_RedshiftParametersIsNull = false;
            }
            Amazon.QuickSight.Model.IdentityCenterConfiguration requestDataSourceParameters_dataSourceParameters_RedshiftParameters_dataSourceParameters_RedshiftParameters_IdentityCenterConfiguration = null;
            
             // populate IdentityCenterConfiguration
            var requestDataSourceParameters_dataSourceParameters_RedshiftParameters_dataSourceParameters_RedshiftParameters_IdentityCenterConfigurationIsNull = true;
            requestDataSourceParameters_dataSourceParameters_RedshiftParameters_dataSourceParameters_RedshiftParameters_IdentityCenterConfiguration = new Amazon.QuickSight.Model.IdentityCenterConfiguration();
            System.Boolean? requestDataSourceParameters_dataSourceParameters_RedshiftParameters_dataSourceParameters_RedshiftParameters_IdentityCenterConfiguration_identityCenterConfiguration_EnableIdentityPropagation = null;
            if (cmdletContext.IdentityCenterConfiguration_EnableIdentityPropagation != null)
            {
                requestDataSourceParameters_dataSourceParameters_RedshiftParameters_dataSourceParameters_RedshiftParameters_IdentityCenterConfiguration_identityCenterConfiguration_EnableIdentityPropagation = cmdletContext.IdentityCenterConfiguration_EnableIdentityPropagation.Value;
            }
            if (requestDataSourceParameters_dataSourceParameters_RedshiftParameters_dataSourceParameters_RedshiftParameters_IdentityCenterConfiguration_identityCenterConfiguration_EnableIdentityPropagation != null)
            {
                requestDataSourceParameters_dataSourceParameters_RedshiftParameters_dataSourceParameters_RedshiftParameters_IdentityCenterConfiguration.EnableIdentityPropagation = requestDataSourceParameters_dataSourceParameters_RedshiftParameters_dataSourceParameters_RedshiftParameters_IdentityCenterConfiguration_identityCenterConfiguration_EnableIdentityPropagation.Value;
                requestDataSourceParameters_dataSourceParameters_RedshiftParameters_dataSourceParameters_RedshiftParameters_IdentityCenterConfigurationIsNull = false;
            }
             // determine if requestDataSourceParameters_dataSourceParameters_RedshiftParameters_dataSourceParameters_RedshiftParameters_IdentityCenterConfiguration should be set to null
            if (requestDataSourceParameters_dataSourceParameters_RedshiftParameters_dataSourceParameters_RedshiftParameters_IdentityCenterConfigurationIsNull)
            {
                requestDataSourceParameters_dataSourceParameters_RedshiftParameters_dataSourceParameters_RedshiftParameters_IdentityCenterConfiguration = null;
            }
            if (requestDataSourceParameters_dataSourceParameters_RedshiftParameters_dataSourceParameters_RedshiftParameters_IdentityCenterConfiguration != null)
            {
                requestDataSourceParameters_dataSourceParameters_RedshiftParameters.IdentityCenterConfiguration = requestDataSourceParameters_dataSourceParameters_RedshiftParameters_dataSourceParameters_RedshiftParameters_IdentityCenterConfiguration;
                requestDataSourceParameters_dataSourceParameters_RedshiftParametersIsNull = false;
            }
            Amazon.QuickSight.Model.RedshiftIAMParameters requestDataSourceParameters_dataSourceParameters_RedshiftParameters_dataSourceParameters_RedshiftParameters_IAMParameters = null;
            
             // populate IAMParameters
            var requestDataSourceParameters_dataSourceParameters_RedshiftParameters_dataSourceParameters_RedshiftParameters_IAMParametersIsNull = true;
            requestDataSourceParameters_dataSourceParameters_RedshiftParameters_dataSourceParameters_RedshiftParameters_IAMParameters = new Amazon.QuickSight.Model.RedshiftIAMParameters();
            System.Boolean? requestDataSourceParameters_dataSourceParameters_RedshiftParameters_dataSourceParameters_RedshiftParameters_IAMParameters_iAMParameters_AutoCreateDatabaseUser = null;
            if (cmdletContext.IAMParameters_AutoCreateDatabaseUser != null)
            {
                requestDataSourceParameters_dataSourceParameters_RedshiftParameters_dataSourceParameters_RedshiftParameters_IAMParameters_iAMParameters_AutoCreateDatabaseUser = cmdletContext.IAMParameters_AutoCreateDatabaseUser.Value;
            }
            if (requestDataSourceParameters_dataSourceParameters_RedshiftParameters_dataSourceParameters_RedshiftParameters_IAMParameters_iAMParameters_AutoCreateDatabaseUser != null)
            {
                requestDataSourceParameters_dataSourceParameters_RedshiftParameters_dataSourceParameters_RedshiftParameters_IAMParameters.AutoCreateDatabaseUser = requestDataSourceParameters_dataSourceParameters_RedshiftParameters_dataSourceParameters_RedshiftParameters_IAMParameters_iAMParameters_AutoCreateDatabaseUser.Value;
                requestDataSourceParameters_dataSourceParameters_RedshiftParameters_dataSourceParameters_RedshiftParameters_IAMParametersIsNull = false;
            }
            List<System.String> requestDataSourceParameters_dataSourceParameters_RedshiftParameters_dataSourceParameters_RedshiftParameters_IAMParameters_iAMParameters_DatabaseGroup = null;
            if (cmdletContext.IAMParameters_DatabaseGroup != null)
            {
                requestDataSourceParameters_dataSourceParameters_RedshiftParameters_dataSourceParameters_RedshiftParameters_IAMParameters_iAMParameters_DatabaseGroup = cmdletContext.IAMParameters_DatabaseGroup;
            }
            if (requestDataSourceParameters_dataSourceParameters_RedshiftParameters_dataSourceParameters_RedshiftParameters_IAMParameters_iAMParameters_DatabaseGroup != null)
            {
                requestDataSourceParameters_dataSourceParameters_RedshiftParameters_dataSourceParameters_RedshiftParameters_IAMParameters.DatabaseGroups = requestDataSourceParameters_dataSourceParameters_RedshiftParameters_dataSourceParameters_RedshiftParameters_IAMParameters_iAMParameters_DatabaseGroup;
                requestDataSourceParameters_dataSourceParameters_RedshiftParameters_dataSourceParameters_RedshiftParameters_IAMParametersIsNull = false;
            }
            System.String requestDataSourceParameters_dataSourceParameters_RedshiftParameters_dataSourceParameters_RedshiftParameters_IAMParameters_iAMParameters_DatabaseUser = null;
            if (cmdletContext.IAMParameters_DatabaseUser != null)
            {
                requestDataSourceParameters_dataSourceParameters_RedshiftParameters_dataSourceParameters_RedshiftParameters_IAMParameters_iAMParameters_DatabaseUser = cmdletContext.IAMParameters_DatabaseUser;
            }
            if (requestDataSourceParameters_dataSourceParameters_RedshiftParameters_dataSourceParameters_RedshiftParameters_IAMParameters_iAMParameters_DatabaseUser != null)
            {
                requestDataSourceParameters_dataSourceParameters_RedshiftParameters_dataSourceParameters_RedshiftParameters_IAMParameters.DatabaseUser = requestDataSourceParameters_dataSourceParameters_RedshiftParameters_dataSourceParameters_RedshiftParameters_IAMParameters_iAMParameters_DatabaseUser;
                requestDataSourceParameters_dataSourceParameters_RedshiftParameters_dataSourceParameters_RedshiftParameters_IAMParametersIsNull = false;
            }
            System.String requestDataSourceParameters_dataSourceParameters_RedshiftParameters_dataSourceParameters_RedshiftParameters_IAMParameters_iAMParameters_RoleArn = null;
            if (cmdletContext.IAMParameters_RoleArn != null)
            {
                requestDataSourceParameters_dataSourceParameters_RedshiftParameters_dataSourceParameters_RedshiftParameters_IAMParameters_iAMParameters_RoleArn = cmdletContext.IAMParameters_RoleArn;
            }
            if (requestDataSourceParameters_dataSourceParameters_RedshiftParameters_dataSourceParameters_RedshiftParameters_IAMParameters_iAMParameters_RoleArn != null)
            {
                requestDataSourceParameters_dataSourceParameters_RedshiftParameters_dataSourceParameters_RedshiftParameters_IAMParameters.RoleArn = requestDataSourceParameters_dataSourceParameters_RedshiftParameters_dataSourceParameters_RedshiftParameters_IAMParameters_iAMParameters_RoleArn;
                requestDataSourceParameters_dataSourceParameters_RedshiftParameters_dataSourceParameters_RedshiftParameters_IAMParametersIsNull = false;
            }
             // determine if requestDataSourceParameters_dataSourceParameters_RedshiftParameters_dataSourceParameters_RedshiftParameters_IAMParameters should be set to null
            if (requestDataSourceParameters_dataSourceParameters_RedshiftParameters_dataSourceParameters_RedshiftParameters_IAMParametersIsNull)
            {
                requestDataSourceParameters_dataSourceParameters_RedshiftParameters_dataSourceParameters_RedshiftParameters_IAMParameters = null;
            }
            if (requestDataSourceParameters_dataSourceParameters_RedshiftParameters_dataSourceParameters_RedshiftParameters_IAMParameters != null)
            {
                requestDataSourceParameters_dataSourceParameters_RedshiftParameters.IAMParameters = requestDataSourceParameters_dataSourceParameters_RedshiftParameters_dataSourceParameters_RedshiftParameters_IAMParameters;
                requestDataSourceParameters_dataSourceParameters_RedshiftParametersIsNull = false;
            }
             // determine if requestDataSourceParameters_dataSourceParameters_RedshiftParameters should be set to null
            if (requestDataSourceParameters_dataSourceParameters_RedshiftParametersIsNull)
            {
                requestDataSourceParameters_dataSourceParameters_RedshiftParameters = null;
            }
            if (requestDataSourceParameters_dataSourceParameters_RedshiftParameters != null)
            {
                request.DataSourceParameters.RedshiftParameters = requestDataSourceParameters_dataSourceParameters_RedshiftParameters;
                requestDataSourceParametersIsNull = false;
            }
            Amazon.QuickSight.Model.SnowflakeParameters requestDataSourceParameters_dataSourceParameters_SnowflakeParameters = null;
            
             // populate SnowflakeParameters
            var requestDataSourceParameters_dataSourceParameters_SnowflakeParametersIsNull = true;
            requestDataSourceParameters_dataSourceParameters_SnowflakeParameters = new Amazon.QuickSight.Model.SnowflakeParameters();
            Amazon.QuickSight.AuthenticationType requestDataSourceParameters_dataSourceParameters_SnowflakeParameters_snowflakeParameters_AuthenticationType = null;
            if (cmdletContext.SnowflakeParameters_AuthenticationType != null)
            {
                requestDataSourceParameters_dataSourceParameters_SnowflakeParameters_snowflakeParameters_AuthenticationType = cmdletContext.SnowflakeParameters_AuthenticationType;
            }
            if (requestDataSourceParameters_dataSourceParameters_SnowflakeParameters_snowflakeParameters_AuthenticationType != null)
            {
                requestDataSourceParameters_dataSourceParameters_SnowflakeParameters.AuthenticationType = requestDataSourceParameters_dataSourceParameters_SnowflakeParameters_snowflakeParameters_AuthenticationType;
                requestDataSourceParameters_dataSourceParameters_SnowflakeParametersIsNull = false;
            }
            System.String requestDataSourceParameters_dataSourceParameters_SnowflakeParameters_snowflakeParameters_Database = null;
            if (cmdletContext.SnowflakeParameters_Database != null)
            {
                requestDataSourceParameters_dataSourceParameters_SnowflakeParameters_snowflakeParameters_Database = cmdletContext.SnowflakeParameters_Database;
            }
            if (requestDataSourceParameters_dataSourceParameters_SnowflakeParameters_snowflakeParameters_Database != null)
            {
                requestDataSourceParameters_dataSourceParameters_SnowflakeParameters.Database = requestDataSourceParameters_dataSourceParameters_SnowflakeParameters_snowflakeParameters_Database;
                requestDataSourceParameters_dataSourceParameters_SnowflakeParametersIsNull = false;
            }
            System.String requestDataSourceParameters_dataSourceParameters_SnowflakeParameters_snowflakeParameters_DatabaseAccessControlRole = null;
            if (cmdletContext.SnowflakeParameters_DatabaseAccessControlRole != null)
            {
                requestDataSourceParameters_dataSourceParameters_SnowflakeParameters_snowflakeParameters_DatabaseAccessControlRole = cmdletContext.SnowflakeParameters_DatabaseAccessControlRole;
            }
            if (requestDataSourceParameters_dataSourceParameters_SnowflakeParameters_snowflakeParameters_DatabaseAccessControlRole != null)
            {
                requestDataSourceParameters_dataSourceParameters_SnowflakeParameters.DatabaseAccessControlRole = requestDataSourceParameters_dataSourceParameters_SnowflakeParameters_snowflakeParameters_DatabaseAccessControlRole;
                requestDataSourceParameters_dataSourceParameters_SnowflakeParametersIsNull = false;
            }
            System.String requestDataSourceParameters_dataSourceParameters_SnowflakeParameters_snowflakeParameters_Host = null;
            if (cmdletContext.SnowflakeParameters_Host != null)
            {
                requestDataSourceParameters_dataSourceParameters_SnowflakeParameters_snowflakeParameters_Host = cmdletContext.SnowflakeParameters_Host;
            }
            if (requestDataSourceParameters_dataSourceParameters_SnowflakeParameters_snowflakeParameters_Host != null)
            {
                requestDataSourceParameters_dataSourceParameters_SnowflakeParameters.Host = requestDataSourceParameters_dataSourceParameters_SnowflakeParameters_snowflakeParameters_Host;
                requestDataSourceParameters_dataSourceParameters_SnowflakeParametersIsNull = false;
            }
            System.String requestDataSourceParameters_dataSourceParameters_SnowflakeParameters_snowflakeParameters_Warehouse = null;
            if (cmdletContext.SnowflakeParameters_Warehouse != null)
            {
                requestDataSourceParameters_dataSourceParameters_SnowflakeParameters_snowflakeParameters_Warehouse = cmdletContext.SnowflakeParameters_Warehouse;
            }
            if (requestDataSourceParameters_dataSourceParameters_SnowflakeParameters_snowflakeParameters_Warehouse != null)
            {
                requestDataSourceParameters_dataSourceParameters_SnowflakeParameters.Warehouse = requestDataSourceParameters_dataSourceParameters_SnowflakeParameters_snowflakeParameters_Warehouse;
                requestDataSourceParameters_dataSourceParameters_SnowflakeParametersIsNull = false;
            }
            Amazon.QuickSight.Model.OAuthParameters requestDataSourceParameters_dataSourceParameters_SnowflakeParameters_dataSourceParameters_SnowflakeParameters_OAuthParameters = null;
            
             // populate OAuthParameters
            var requestDataSourceParameters_dataSourceParameters_SnowflakeParameters_dataSourceParameters_SnowflakeParameters_OAuthParametersIsNull = true;
            requestDataSourceParameters_dataSourceParameters_SnowflakeParameters_dataSourceParameters_SnowflakeParameters_OAuthParameters = new Amazon.QuickSight.Model.OAuthParameters();
            System.String requestDataSourceParameters_dataSourceParameters_SnowflakeParameters_dataSourceParameters_SnowflakeParameters_OAuthParameters_dataSourceParameters_SnowflakeParameters_OAuthParameters_IdentityProviderResourceUri = null;
            if (cmdletContext.DataSourceParameters_SnowflakeParameters_OAuthParameters_IdentityProviderResourceUri != null)
            {
                requestDataSourceParameters_dataSourceParameters_SnowflakeParameters_dataSourceParameters_SnowflakeParameters_OAuthParameters_dataSourceParameters_SnowflakeParameters_OAuthParameters_IdentityProviderResourceUri = cmdletContext.DataSourceParameters_SnowflakeParameters_OAuthParameters_IdentityProviderResourceUri;
            }
            if (requestDataSourceParameters_dataSourceParameters_SnowflakeParameters_dataSourceParameters_SnowflakeParameters_OAuthParameters_dataSourceParameters_SnowflakeParameters_OAuthParameters_IdentityProviderResourceUri != null)
            {
                requestDataSourceParameters_dataSourceParameters_SnowflakeParameters_dataSourceParameters_SnowflakeParameters_OAuthParameters.IdentityProviderResourceUri = requestDataSourceParameters_dataSourceParameters_SnowflakeParameters_dataSourceParameters_SnowflakeParameters_OAuthParameters_dataSourceParameters_SnowflakeParameters_OAuthParameters_IdentityProviderResourceUri;
                requestDataSourceParameters_dataSourceParameters_SnowflakeParameters_dataSourceParameters_SnowflakeParameters_OAuthParametersIsNull = false;
            }
            System.String requestDataSourceParameters_dataSourceParameters_SnowflakeParameters_dataSourceParameters_SnowflakeParameters_OAuthParameters_dataSourceParameters_SnowflakeParameters_OAuthParameters_OAuthScope = null;
            if (cmdletContext.DataSourceParameters_SnowflakeParameters_OAuthParameters_OAuthScope != null)
            {
                requestDataSourceParameters_dataSourceParameters_SnowflakeParameters_dataSourceParameters_SnowflakeParameters_OAuthParameters_dataSourceParameters_SnowflakeParameters_OAuthParameters_OAuthScope = cmdletContext.DataSourceParameters_SnowflakeParameters_OAuthParameters_OAuthScope;
            }
            if (requestDataSourceParameters_dataSourceParameters_SnowflakeParameters_dataSourceParameters_SnowflakeParameters_OAuthParameters_dataSourceParameters_SnowflakeParameters_OAuthParameters_OAuthScope != null)
            {
                requestDataSourceParameters_dataSourceParameters_SnowflakeParameters_dataSourceParameters_SnowflakeParameters_OAuthParameters.OAuthScope = requestDataSourceParameters_dataSourceParameters_SnowflakeParameters_dataSourceParameters_SnowflakeParameters_OAuthParameters_dataSourceParameters_SnowflakeParameters_OAuthParameters_OAuthScope;
                requestDataSourceParameters_dataSourceParameters_SnowflakeParameters_dataSourceParameters_SnowflakeParameters_OAuthParametersIsNull = false;
            }
            System.String requestDataSourceParameters_dataSourceParameters_SnowflakeParameters_dataSourceParameters_SnowflakeParameters_OAuthParameters_dataSourceParameters_SnowflakeParameters_OAuthParameters_TokenProviderUrl = null;
            if (cmdletContext.DataSourceParameters_SnowflakeParameters_OAuthParameters_TokenProviderUrl != null)
            {
                requestDataSourceParameters_dataSourceParameters_SnowflakeParameters_dataSourceParameters_SnowflakeParameters_OAuthParameters_dataSourceParameters_SnowflakeParameters_OAuthParameters_TokenProviderUrl = cmdletContext.DataSourceParameters_SnowflakeParameters_OAuthParameters_TokenProviderUrl;
            }
            if (requestDataSourceParameters_dataSourceParameters_SnowflakeParameters_dataSourceParameters_SnowflakeParameters_OAuthParameters_dataSourceParameters_SnowflakeParameters_OAuthParameters_TokenProviderUrl != null)
            {
                requestDataSourceParameters_dataSourceParameters_SnowflakeParameters_dataSourceParameters_SnowflakeParameters_OAuthParameters.TokenProviderUrl = requestDataSourceParameters_dataSourceParameters_SnowflakeParameters_dataSourceParameters_SnowflakeParameters_OAuthParameters_dataSourceParameters_SnowflakeParameters_OAuthParameters_TokenProviderUrl;
                requestDataSourceParameters_dataSourceParameters_SnowflakeParameters_dataSourceParameters_SnowflakeParameters_OAuthParametersIsNull = false;
            }
            Amazon.QuickSight.Model.VpcConnectionProperties requestDataSourceParameters_dataSourceParameters_SnowflakeParameters_dataSourceParameters_SnowflakeParameters_OAuthParameters_dataSourceParameters_SnowflakeParameters_OAuthParameters_IdentityProviderVpcConnectionProperties = null;
            
             // populate IdentityProviderVpcConnectionProperties
            var requestDataSourceParameters_dataSourceParameters_SnowflakeParameters_dataSourceParameters_SnowflakeParameters_OAuthParameters_dataSourceParameters_SnowflakeParameters_OAuthParameters_IdentityProviderVpcConnectionPropertiesIsNull = true;
            requestDataSourceParameters_dataSourceParameters_SnowflakeParameters_dataSourceParameters_SnowflakeParameters_OAuthParameters_dataSourceParameters_SnowflakeParameters_OAuthParameters_IdentityProviderVpcConnectionProperties = new Amazon.QuickSight.Model.VpcConnectionProperties();
            System.String requestDataSourceParameters_dataSourceParameters_SnowflakeParameters_dataSourceParameters_SnowflakeParameters_OAuthParameters_dataSourceParameters_SnowflakeParameters_OAuthParameters_IdentityProviderVpcConnectionProperties_dataSourceParameters_SnowflakeParameters_OAuthParameters_IdentityProviderVpcConnectionProperties_VpcConnectionArn = null;
            if (cmdletContext.DataSourceParameters_SnowflakeParameters_OAuthParameters_IdentityProviderVpcConnectionProperties_VpcConnectionArn != null)
            {
                requestDataSourceParameters_dataSourceParameters_SnowflakeParameters_dataSourceParameters_SnowflakeParameters_OAuthParameters_dataSourceParameters_SnowflakeParameters_OAuthParameters_IdentityProviderVpcConnectionProperties_dataSourceParameters_SnowflakeParameters_OAuthParameters_IdentityProviderVpcConnectionProperties_VpcConnectionArn = cmdletContext.DataSourceParameters_SnowflakeParameters_OAuthParameters_IdentityProviderVpcConnectionProperties_VpcConnectionArn;
            }
            if (requestDataSourceParameters_dataSourceParameters_SnowflakeParameters_dataSourceParameters_SnowflakeParameters_OAuthParameters_dataSourceParameters_SnowflakeParameters_OAuthParameters_IdentityProviderVpcConnectionProperties_dataSourceParameters_SnowflakeParameters_OAuthParameters_IdentityProviderVpcConnectionProperties_VpcConnectionArn != null)
            {
                requestDataSourceParameters_dataSourceParameters_SnowflakeParameters_dataSourceParameters_SnowflakeParameters_OAuthParameters_dataSourceParameters_SnowflakeParameters_OAuthParameters_IdentityProviderVpcConnectionProperties.VpcConnectionArn = requestDataSourceParameters_dataSourceParameters_SnowflakeParameters_dataSourceParameters_SnowflakeParameters_OAuthParameters_dataSourceParameters_SnowflakeParameters_OAuthParameters_IdentityProviderVpcConnectionProperties_dataSourceParameters_SnowflakeParameters_OAuthParameters_IdentityProviderVpcConnectionProperties_VpcConnectionArn;
                requestDataSourceParameters_dataSourceParameters_SnowflakeParameters_dataSourceParameters_SnowflakeParameters_OAuthParameters_dataSourceParameters_SnowflakeParameters_OAuthParameters_IdentityProviderVpcConnectionPropertiesIsNull = false;
            }
             // determine if requestDataSourceParameters_dataSourceParameters_SnowflakeParameters_dataSourceParameters_SnowflakeParameters_OAuthParameters_dataSourceParameters_SnowflakeParameters_OAuthParameters_IdentityProviderVpcConnectionProperties should be set to null
            if (requestDataSourceParameters_dataSourceParameters_SnowflakeParameters_dataSourceParameters_SnowflakeParameters_OAuthParameters_dataSourceParameters_SnowflakeParameters_OAuthParameters_IdentityProviderVpcConnectionPropertiesIsNull)
            {
                requestDataSourceParameters_dataSourceParameters_SnowflakeParameters_dataSourceParameters_SnowflakeParameters_OAuthParameters_dataSourceParameters_SnowflakeParameters_OAuthParameters_IdentityProviderVpcConnectionProperties = null;
            }
            if (requestDataSourceParameters_dataSourceParameters_SnowflakeParameters_dataSourceParameters_SnowflakeParameters_OAuthParameters_dataSourceParameters_SnowflakeParameters_OAuthParameters_IdentityProviderVpcConnectionProperties != null)
            {
                requestDataSourceParameters_dataSourceParameters_SnowflakeParameters_dataSourceParameters_SnowflakeParameters_OAuthParameters.IdentityProviderVpcConnectionProperties = requestDataSourceParameters_dataSourceParameters_SnowflakeParameters_dataSourceParameters_SnowflakeParameters_OAuthParameters_dataSourceParameters_SnowflakeParameters_OAuthParameters_IdentityProviderVpcConnectionProperties;
                requestDataSourceParameters_dataSourceParameters_SnowflakeParameters_dataSourceParameters_SnowflakeParameters_OAuthParametersIsNull = false;
            }
             // determine if requestDataSourceParameters_dataSourceParameters_SnowflakeParameters_dataSourceParameters_SnowflakeParameters_OAuthParameters should be set to null
            if (requestDataSourceParameters_dataSourceParameters_SnowflakeParameters_dataSourceParameters_SnowflakeParameters_OAuthParametersIsNull)
            {
                requestDataSourceParameters_dataSourceParameters_SnowflakeParameters_dataSourceParameters_SnowflakeParameters_OAuthParameters = null;
            }
            if (requestDataSourceParameters_dataSourceParameters_SnowflakeParameters_dataSourceParameters_SnowflakeParameters_OAuthParameters != null)
            {
                requestDataSourceParameters_dataSourceParameters_SnowflakeParameters.OAuthParameters = requestDataSourceParameters_dataSourceParameters_SnowflakeParameters_dataSourceParameters_SnowflakeParameters_OAuthParameters;
                requestDataSourceParameters_dataSourceParameters_SnowflakeParametersIsNull = false;
            }
             // determine if requestDataSourceParameters_dataSourceParameters_SnowflakeParameters should be set to null
            if (requestDataSourceParameters_dataSourceParameters_SnowflakeParametersIsNull)
            {
                requestDataSourceParameters_dataSourceParameters_SnowflakeParameters = null;
            }
            if (requestDataSourceParameters_dataSourceParameters_SnowflakeParameters != null)
            {
                request.DataSourceParameters.SnowflakeParameters = requestDataSourceParameters_dataSourceParameters_SnowflakeParameters;
                requestDataSourceParametersIsNull = false;
            }
            Amazon.QuickSight.Model.StarburstParameters requestDataSourceParameters_dataSourceParameters_StarburstParameters = null;
            
             // populate StarburstParameters
            var requestDataSourceParameters_dataSourceParameters_StarburstParametersIsNull = true;
            requestDataSourceParameters_dataSourceParameters_StarburstParameters = new Amazon.QuickSight.Model.StarburstParameters();
            Amazon.QuickSight.AuthenticationType requestDataSourceParameters_dataSourceParameters_StarburstParameters_starburstParameters_AuthenticationType = null;
            if (cmdletContext.StarburstParameters_AuthenticationType != null)
            {
                requestDataSourceParameters_dataSourceParameters_StarburstParameters_starburstParameters_AuthenticationType = cmdletContext.StarburstParameters_AuthenticationType;
            }
            if (requestDataSourceParameters_dataSourceParameters_StarburstParameters_starburstParameters_AuthenticationType != null)
            {
                requestDataSourceParameters_dataSourceParameters_StarburstParameters.AuthenticationType = requestDataSourceParameters_dataSourceParameters_StarburstParameters_starburstParameters_AuthenticationType;
                requestDataSourceParameters_dataSourceParameters_StarburstParametersIsNull = false;
            }
            System.String requestDataSourceParameters_dataSourceParameters_StarburstParameters_starburstParameters_Catalog = null;
            if (cmdletContext.StarburstParameters_Catalog != null)
            {
                requestDataSourceParameters_dataSourceParameters_StarburstParameters_starburstParameters_Catalog = cmdletContext.StarburstParameters_Catalog;
            }
            if (requestDataSourceParameters_dataSourceParameters_StarburstParameters_starburstParameters_Catalog != null)
            {
                requestDataSourceParameters_dataSourceParameters_StarburstParameters.Catalog = requestDataSourceParameters_dataSourceParameters_StarburstParameters_starburstParameters_Catalog;
                requestDataSourceParameters_dataSourceParameters_StarburstParametersIsNull = false;
            }
            System.String requestDataSourceParameters_dataSourceParameters_StarburstParameters_starburstParameters_DatabaseAccessControlRole = null;
            if (cmdletContext.StarburstParameters_DatabaseAccessControlRole != null)
            {
                requestDataSourceParameters_dataSourceParameters_StarburstParameters_starburstParameters_DatabaseAccessControlRole = cmdletContext.StarburstParameters_DatabaseAccessControlRole;
            }
            if (requestDataSourceParameters_dataSourceParameters_StarburstParameters_starburstParameters_DatabaseAccessControlRole != null)
            {
                requestDataSourceParameters_dataSourceParameters_StarburstParameters.DatabaseAccessControlRole = requestDataSourceParameters_dataSourceParameters_StarburstParameters_starburstParameters_DatabaseAccessControlRole;
                requestDataSourceParameters_dataSourceParameters_StarburstParametersIsNull = false;
            }
            System.String requestDataSourceParameters_dataSourceParameters_StarburstParameters_starburstParameters_Host = null;
            if (cmdletContext.StarburstParameters_Host != null)
            {
                requestDataSourceParameters_dataSourceParameters_StarburstParameters_starburstParameters_Host = cmdletContext.StarburstParameters_Host;
            }
            if (requestDataSourceParameters_dataSourceParameters_StarburstParameters_starburstParameters_Host != null)
            {
                requestDataSourceParameters_dataSourceParameters_StarburstParameters.Host = requestDataSourceParameters_dataSourceParameters_StarburstParameters_starburstParameters_Host;
                requestDataSourceParameters_dataSourceParameters_StarburstParametersIsNull = false;
            }
            System.Int32? requestDataSourceParameters_dataSourceParameters_StarburstParameters_starburstParameters_Port = null;
            if (cmdletContext.StarburstParameters_Port != null)
            {
                requestDataSourceParameters_dataSourceParameters_StarburstParameters_starburstParameters_Port = cmdletContext.StarburstParameters_Port.Value;
            }
            if (requestDataSourceParameters_dataSourceParameters_StarburstParameters_starburstParameters_Port != null)
            {
                requestDataSourceParameters_dataSourceParameters_StarburstParameters.Port = requestDataSourceParameters_dataSourceParameters_StarburstParameters_starburstParameters_Port.Value;
                requestDataSourceParameters_dataSourceParameters_StarburstParametersIsNull = false;
            }
            Amazon.QuickSight.StarburstProductType requestDataSourceParameters_dataSourceParameters_StarburstParameters_starburstParameters_ProductType = null;
            if (cmdletContext.StarburstParameters_ProductType != null)
            {
                requestDataSourceParameters_dataSourceParameters_StarburstParameters_starburstParameters_ProductType = cmdletContext.StarburstParameters_ProductType;
            }
            if (requestDataSourceParameters_dataSourceParameters_StarburstParameters_starburstParameters_ProductType != null)
            {
                requestDataSourceParameters_dataSourceParameters_StarburstParameters.ProductType = requestDataSourceParameters_dataSourceParameters_StarburstParameters_starburstParameters_ProductType;
                requestDataSourceParameters_dataSourceParameters_StarburstParametersIsNull = false;
            }
            Amazon.QuickSight.Model.OAuthParameters requestDataSourceParameters_dataSourceParameters_StarburstParameters_dataSourceParameters_StarburstParameters_OAuthParameters = null;
            
             // populate OAuthParameters
            var requestDataSourceParameters_dataSourceParameters_StarburstParameters_dataSourceParameters_StarburstParameters_OAuthParametersIsNull = true;
            requestDataSourceParameters_dataSourceParameters_StarburstParameters_dataSourceParameters_StarburstParameters_OAuthParameters = new Amazon.QuickSight.Model.OAuthParameters();
            System.String requestDataSourceParameters_dataSourceParameters_StarburstParameters_dataSourceParameters_StarburstParameters_OAuthParameters_dataSourceParameters_StarburstParameters_OAuthParameters_IdentityProviderResourceUri = null;
            if (cmdletContext.DataSourceParameters_StarburstParameters_OAuthParameters_IdentityProviderResourceUri != null)
            {
                requestDataSourceParameters_dataSourceParameters_StarburstParameters_dataSourceParameters_StarburstParameters_OAuthParameters_dataSourceParameters_StarburstParameters_OAuthParameters_IdentityProviderResourceUri = cmdletContext.DataSourceParameters_StarburstParameters_OAuthParameters_IdentityProviderResourceUri;
            }
            if (requestDataSourceParameters_dataSourceParameters_StarburstParameters_dataSourceParameters_StarburstParameters_OAuthParameters_dataSourceParameters_StarburstParameters_OAuthParameters_IdentityProviderResourceUri != null)
            {
                requestDataSourceParameters_dataSourceParameters_StarburstParameters_dataSourceParameters_StarburstParameters_OAuthParameters.IdentityProviderResourceUri = requestDataSourceParameters_dataSourceParameters_StarburstParameters_dataSourceParameters_StarburstParameters_OAuthParameters_dataSourceParameters_StarburstParameters_OAuthParameters_IdentityProviderResourceUri;
                requestDataSourceParameters_dataSourceParameters_StarburstParameters_dataSourceParameters_StarburstParameters_OAuthParametersIsNull = false;
            }
            System.String requestDataSourceParameters_dataSourceParameters_StarburstParameters_dataSourceParameters_StarburstParameters_OAuthParameters_dataSourceParameters_StarburstParameters_OAuthParameters_OAuthScope = null;
            if (cmdletContext.DataSourceParameters_StarburstParameters_OAuthParameters_OAuthScope != null)
            {
                requestDataSourceParameters_dataSourceParameters_StarburstParameters_dataSourceParameters_StarburstParameters_OAuthParameters_dataSourceParameters_StarburstParameters_OAuthParameters_OAuthScope = cmdletContext.DataSourceParameters_StarburstParameters_OAuthParameters_OAuthScope;
            }
            if (requestDataSourceParameters_dataSourceParameters_StarburstParameters_dataSourceParameters_StarburstParameters_OAuthParameters_dataSourceParameters_StarburstParameters_OAuthParameters_OAuthScope != null)
            {
                requestDataSourceParameters_dataSourceParameters_StarburstParameters_dataSourceParameters_StarburstParameters_OAuthParameters.OAuthScope = requestDataSourceParameters_dataSourceParameters_StarburstParameters_dataSourceParameters_StarburstParameters_OAuthParameters_dataSourceParameters_StarburstParameters_OAuthParameters_OAuthScope;
                requestDataSourceParameters_dataSourceParameters_StarburstParameters_dataSourceParameters_StarburstParameters_OAuthParametersIsNull = false;
            }
            System.String requestDataSourceParameters_dataSourceParameters_StarburstParameters_dataSourceParameters_StarburstParameters_OAuthParameters_dataSourceParameters_StarburstParameters_OAuthParameters_TokenProviderUrl = null;
            if (cmdletContext.DataSourceParameters_StarburstParameters_OAuthParameters_TokenProviderUrl != null)
            {
                requestDataSourceParameters_dataSourceParameters_StarburstParameters_dataSourceParameters_StarburstParameters_OAuthParameters_dataSourceParameters_StarburstParameters_OAuthParameters_TokenProviderUrl = cmdletContext.DataSourceParameters_StarburstParameters_OAuthParameters_TokenProviderUrl;
            }
            if (requestDataSourceParameters_dataSourceParameters_StarburstParameters_dataSourceParameters_StarburstParameters_OAuthParameters_dataSourceParameters_StarburstParameters_OAuthParameters_TokenProviderUrl != null)
            {
                requestDataSourceParameters_dataSourceParameters_StarburstParameters_dataSourceParameters_StarburstParameters_OAuthParameters.TokenProviderUrl = requestDataSourceParameters_dataSourceParameters_StarburstParameters_dataSourceParameters_StarburstParameters_OAuthParameters_dataSourceParameters_StarburstParameters_OAuthParameters_TokenProviderUrl;
                requestDataSourceParameters_dataSourceParameters_StarburstParameters_dataSourceParameters_StarburstParameters_OAuthParametersIsNull = false;
            }
            Amazon.QuickSight.Model.VpcConnectionProperties requestDataSourceParameters_dataSourceParameters_StarburstParameters_dataSourceParameters_StarburstParameters_OAuthParameters_dataSourceParameters_StarburstParameters_OAuthParameters_IdentityProviderVpcConnectionProperties = null;
            
             // populate IdentityProviderVpcConnectionProperties
            var requestDataSourceParameters_dataSourceParameters_StarburstParameters_dataSourceParameters_StarburstParameters_OAuthParameters_dataSourceParameters_StarburstParameters_OAuthParameters_IdentityProviderVpcConnectionPropertiesIsNull = true;
            requestDataSourceParameters_dataSourceParameters_StarburstParameters_dataSourceParameters_StarburstParameters_OAuthParameters_dataSourceParameters_StarburstParameters_OAuthParameters_IdentityProviderVpcConnectionProperties = new Amazon.QuickSight.Model.VpcConnectionProperties();
            System.String requestDataSourceParameters_dataSourceParameters_StarburstParameters_dataSourceParameters_StarburstParameters_OAuthParameters_dataSourceParameters_StarburstParameters_OAuthParameters_IdentityProviderVpcConnectionProperties_dataSourceParameters_StarburstParameters_OAuthParameters_IdentityProviderVpcConnectionProperties_VpcConnectionArn = null;
            if (cmdletContext.DataSourceParameters_StarburstParameters_OAuthParameters_IdentityProviderVpcConnectionProperties_VpcConnectionArn != null)
            {
                requestDataSourceParameters_dataSourceParameters_StarburstParameters_dataSourceParameters_StarburstParameters_OAuthParameters_dataSourceParameters_StarburstParameters_OAuthParameters_IdentityProviderVpcConnectionProperties_dataSourceParameters_StarburstParameters_OAuthParameters_IdentityProviderVpcConnectionProperties_VpcConnectionArn = cmdletContext.DataSourceParameters_StarburstParameters_OAuthParameters_IdentityProviderVpcConnectionProperties_VpcConnectionArn;
            }
            if (requestDataSourceParameters_dataSourceParameters_StarburstParameters_dataSourceParameters_StarburstParameters_OAuthParameters_dataSourceParameters_StarburstParameters_OAuthParameters_IdentityProviderVpcConnectionProperties_dataSourceParameters_StarburstParameters_OAuthParameters_IdentityProviderVpcConnectionProperties_VpcConnectionArn != null)
            {
                requestDataSourceParameters_dataSourceParameters_StarburstParameters_dataSourceParameters_StarburstParameters_OAuthParameters_dataSourceParameters_StarburstParameters_OAuthParameters_IdentityProviderVpcConnectionProperties.VpcConnectionArn = requestDataSourceParameters_dataSourceParameters_StarburstParameters_dataSourceParameters_StarburstParameters_OAuthParameters_dataSourceParameters_StarburstParameters_OAuthParameters_IdentityProviderVpcConnectionProperties_dataSourceParameters_StarburstParameters_OAuthParameters_IdentityProviderVpcConnectionProperties_VpcConnectionArn;
                requestDataSourceParameters_dataSourceParameters_StarburstParameters_dataSourceParameters_StarburstParameters_OAuthParameters_dataSourceParameters_StarburstParameters_OAuthParameters_IdentityProviderVpcConnectionPropertiesIsNull = false;
            }
             // determine if requestDataSourceParameters_dataSourceParameters_StarburstParameters_dataSourceParameters_StarburstParameters_OAuthParameters_dataSourceParameters_StarburstParameters_OAuthParameters_IdentityProviderVpcConnectionProperties should be set to null
            if (requestDataSourceParameters_dataSourceParameters_StarburstParameters_dataSourceParameters_StarburstParameters_OAuthParameters_dataSourceParameters_StarburstParameters_OAuthParameters_IdentityProviderVpcConnectionPropertiesIsNull)
            {
                requestDataSourceParameters_dataSourceParameters_StarburstParameters_dataSourceParameters_StarburstParameters_OAuthParameters_dataSourceParameters_StarburstParameters_OAuthParameters_IdentityProviderVpcConnectionProperties = null;
            }
            if (requestDataSourceParameters_dataSourceParameters_StarburstParameters_dataSourceParameters_StarburstParameters_OAuthParameters_dataSourceParameters_StarburstParameters_OAuthParameters_IdentityProviderVpcConnectionProperties != null)
            {
                requestDataSourceParameters_dataSourceParameters_StarburstParameters_dataSourceParameters_StarburstParameters_OAuthParameters.IdentityProviderVpcConnectionProperties = requestDataSourceParameters_dataSourceParameters_StarburstParameters_dataSourceParameters_StarburstParameters_OAuthParameters_dataSourceParameters_StarburstParameters_OAuthParameters_IdentityProviderVpcConnectionProperties;
                requestDataSourceParameters_dataSourceParameters_StarburstParameters_dataSourceParameters_StarburstParameters_OAuthParametersIsNull = false;
            }
             // determine if requestDataSourceParameters_dataSourceParameters_StarburstParameters_dataSourceParameters_StarburstParameters_OAuthParameters should be set to null
            if (requestDataSourceParameters_dataSourceParameters_StarburstParameters_dataSourceParameters_StarburstParameters_OAuthParametersIsNull)
            {
                requestDataSourceParameters_dataSourceParameters_StarburstParameters_dataSourceParameters_StarburstParameters_OAuthParameters = null;
            }
            if (requestDataSourceParameters_dataSourceParameters_StarburstParameters_dataSourceParameters_StarburstParameters_OAuthParameters != null)
            {
                requestDataSourceParameters_dataSourceParameters_StarburstParameters.OAuthParameters = requestDataSourceParameters_dataSourceParameters_StarburstParameters_dataSourceParameters_StarburstParameters_OAuthParameters;
                requestDataSourceParameters_dataSourceParameters_StarburstParametersIsNull = false;
            }
             // determine if requestDataSourceParameters_dataSourceParameters_StarburstParameters should be set to null
            if (requestDataSourceParameters_dataSourceParameters_StarburstParametersIsNull)
            {
                requestDataSourceParameters_dataSourceParameters_StarburstParameters = null;
            }
            if (requestDataSourceParameters_dataSourceParameters_StarburstParameters != null)
            {
                request.DataSourceParameters.StarburstParameters = requestDataSourceParameters_dataSourceParameters_StarburstParameters;
                requestDataSourceParametersIsNull = false;
            }
             // determine if request.DataSourceParameters should be set to null
            if (requestDataSourceParametersIsNull)
            {
                request.DataSourceParameters = null;
            }
            if (cmdletContext.FolderArn != null)
            {
                request.FolderArns = cmdletContext.FolderArn;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Permission != null)
            {
                request.Permissions = cmdletContext.Permission;
            }
            
             // populate SslProperties
            var requestSslPropertiesIsNull = true;
            request.SslProperties = new Amazon.QuickSight.Model.SslProperties();
            System.Boolean? requestSslProperties_sslProperties_DisableSsl = null;
            if (cmdletContext.SslProperties_DisableSsl != null)
            {
                requestSslProperties_sslProperties_DisableSsl = cmdletContext.SslProperties_DisableSsl.Value;
            }
            if (requestSslProperties_sslProperties_DisableSsl != null)
            {
                request.SslProperties.DisableSsl = requestSslProperties_sslProperties_DisableSsl.Value;
                requestSslPropertiesIsNull = false;
            }
             // determine if request.SslProperties should be set to null
            if (requestSslPropertiesIsNull)
            {
                request.SslProperties = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
            }
            
             // populate VpcConnectionProperties
            var requestVpcConnectionPropertiesIsNull = true;
            request.VpcConnectionProperties = new Amazon.QuickSight.Model.VpcConnectionProperties();
            System.String requestVpcConnectionProperties_vpcConnectionProperties_VpcConnectionArn = null;
            if (cmdletContext.VpcConnectionProperties_VpcConnectionArn != null)
            {
                requestVpcConnectionProperties_vpcConnectionProperties_VpcConnectionArn = cmdletContext.VpcConnectionProperties_VpcConnectionArn;
            }
            if (requestVpcConnectionProperties_vpcConnectionProperties_VpcConnectionArn != null)
            {
                request.VpcConnectionProperties.VpcConnectionArn = requestVpcConnectionProperties_vpcConnectionProperties_VpcConnectionArn;
                requestVpcConnectionPropertiesIsNull = false;
            }
             // determine if request.VpcConnectionProperties should be set to null
            if (requestVpcConnectionPropertiesIsNull)
            {
                request.VpcConnectionProperties = null;
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
        
        private Amazon.QuickSight.Model.CreateDataSourceResponse CallAWSServiceOperation(IAmazonQuickSight client, Amazon.QuickSight.Model.CreateDataSourceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon QuickSight", "CreateDataSource");
            try
            {
                #if DESKTOP
                return client.CreateDataSource(request);
                #elif CORECLR
                return client.CreateDataSourceAsync(request).GetAwaiter().GetResult();
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
            public System.String AwsAccountId { get; set; }
            public System.String Credentials_CopySourceArn { get; set; }
            public List<Amazon.QuickSight.Model.DataSourceParameters> CredentialPair_AlternateDataSourceParameter { get; set; }
            public System.String CredentialPair_Password { get; set; }
            public System.String CredentialPair_Username { get; set; }
            public System.String Credentials_SecretArn { get; set; }
            public System.String DataSourceId { get; set; }
            public System.String AmazonElasticsearchParameters_Domain { get; set; }
            public System.String AmazonOpenSearchParameters_Domain { get; set; }
            public System.String AthenaParameters_RoleArn { get; set; }
            public System.String AthenaParameters_WorkGroup { get; set; }
            public System.String AuroraParameters_Database { get; set; }
            public System.String AuroraParameters_Host { get; set; }
            public System.Int32? AuroraParameters_Port { get; set; }
            public System.String AuroraPostgreSqlParameters_Database { get; set; }
            public System.String AuroraPostgreSqlParameters_Host { get; set; }
            public System.Int32? AuroraPostgreSqlParameters_Port { get; set; }
            public System.String AwsIotAnalyticsParameters_DataSetName { get; set; }
            public System.String BigQueryParameters_DataSetRegion { get; set; }
            public System.String BigQueryParameters_ProjectId { get; set; }
            public System.String DatabricksParameters_Host { get; set; }
            public System.Int32? DatabricksParameters_Port { get; set; }
            public System.String DatabricksParameters_SqlEndpointPath { get; set; }
            public System.String ExasolParameters_Host { get; set; }
            public System.Int32? ExasolParameters_Port { get; set; }
            public System.String JiraParameters_SiteBaseUrl { get; set; }
            public System.String MariaDbParameters_Database { get; set; }
            public System.String MariaDbParameters_Host { get; set; }
            public System.Int32? MariaDbParameters_Port { get; set; }
            public System.String MySqlParameters_Database { get; set; }
            public System.String MySqlParameters_Host { get; set; }
            public System.Int32? MySqlParameters_Port { get; set; }
            public System.String OracleParameters_Database { get; set; }
            public System.String OracleParameters_Host { get; set; }
            public System.Int32? OracleParameters_Port { get; set; }
            public System.String PostgreSqlParameters_Database { get; set; }
            public System.String PostgreSqlParameters_Host { get; set; }
            public System.Int32? PostgreSqlParameters_Port { get; set; }
            public System.String PrestoParameters_Catalog { get; set; }
            public System.String PrestoParameters_Host { get; set; }
            public System.Int32? PrestoParameters_Port { get; set; }
            public System.String RdsParameters_Database { get; set; }
            public System.String RdsParameters_InstanceId { get; set; }
            public System.String RedshiftParameters_ClusterId { get; set; }
            public System.String RedshiftParameters_Database { get; set; }
            public System.String RedshiftParameters_Host { get; set; }
            public System.Boolean? IAMParameters_AutoCreateDatabaseUser { get; set; }
            public List<System.String> IAMParameters_DatabaseGroup { get; set; }
            public System.String IAMParameters_DatabaseUser { get; set; }
            public System.String IAMParameters_RoleArn { get; set; }
            public System.Boolean? IdentityCenterConfiguration_EnableIdentityPropagation { get; set; }
            public System.Int32? RedshiftParameters_Port { get; set; }
            public System.String ManifestFileLocation_Bucket { get; set; }
            public System.String ManifestFileLocation_Key { get; set; }
            public System.String S3Parameters_RoleArn { get; set; }
            public System.String ServiceNowParameters_SiteBaseUrl { get; set; }
            public Amazon.QuickSight.AuthenticationType SnowflakeParameters_AuthenticationType { get; set; }
            public System.String SnowflakeParameters_Database { get; set; }
            public System.String SnowflakeParameters_DatabaseAccessControlRole { get; set; }
            public System.String SnowflakeParameters_Host { get; set; }
            public System.String DataSourceParameters_SnowflakeParameters_OAuthParameters_IdentityProviderResourceUri { get; set; }
            public System.String DataSourceParameters_SnowflakeParameters_OAuthParameters_IdentityProviderVpcConnectionProperties_VpcConnectionArn { get; set; }
            public System.String DataSourceParameters_SnowflakeParameters_OAuthParameters_OAuthScope { get; set; }
            public System.String DataSourceParameters_SnowflakeParameters_OAuthParameters_TokenProviderUrl { get; set; }
            public System.String SnowflakeParameters_Warehouse { get; set; }
            public System.String SparkParameters_Host { get; set; }
            public System.Int32? SparkParameters_Port { get; set; }
            public System.String SqlServerParameters_Database { get; set; }
            public System.String SqlServerParameters_Host { get; set; }
            public System.Int32? SqlServerParameters_Port { get; set; }
            public Amazon.QuickSight.AuthenticationType StarburstParameters_AuthenticationType { get; set; }
            public System.String StarburstParameters_Catalog { get; set; }
            public System.String StarburstParameters_DatabaseAccessControlRole { get; set; }
            public System.String StarburstParameters_Host { get; set; }
            public System.String DataSourceParameters_StarburstParameters_OAuthParameters_IdentityProviderResourceUri { get; set; }
            public System.String DataSourceParameters_StarburstParameters_OAuthParameters_IdentityProviderVpcConnectionProperties_VpcConnectionArn { get; set; }
            public System.String DataSourceParameters_StarburstParameters_OAuthParameters_OAuthScope { get; set; }
            public System.String DataSourceParameters_StarburstParameters_OAuthParameters_TokenProviderUrl { get; set; }
            public System.Int32? StarburstParameters_Port { get; set; }
            public Amazon.QuickSight.StarburstProductType StarburstParameters_ProductType { get; set; }
            public System.String TeradataParameters_Database { get; set; }
            public System.String TeradataParameters_Host { get; set; }
            public System.Int32? TeradataParameters_Port { get; set; }
            public System.String TrinoParameters_Catalog { get; set; }
            public System.String TrinoParameters_Host { get; set; }
            public System.Int32? TrinoParameters_Port { get; set; }
            public System.Int32? TwitterParameters_MaxRow { get; set; }
            public System.String TwitterParameters_Query { get; set; }
            public List<System.String> FolderArn { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.QuickSight.Model.ResourcePermission> Permission { get; set; }
            public System.Boolean? SslProperties_DisableSsl { get; set; }
            public List<Amazon.QuickSight.Model.Tag> Tag { get; set; }
            public Amazon.QuickSight.DataSourceType Type { get; set; }
            public System.String VpcConnectionProperties_VpcConnectionArn { get; set; }
            public System.Func<Amazon.QuickSight.Model.CreateDataSourceResponse, NewQSDataSourceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
