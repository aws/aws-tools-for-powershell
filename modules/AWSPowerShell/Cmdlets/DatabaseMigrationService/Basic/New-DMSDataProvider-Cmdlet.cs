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
using Amazon.DatabaseMigrationService;
using Amazon.DatabaseMigrationService.Model;

namespace Amazon.PowerShell.Cmdlets.DMS
{
    /// <summary>
    /// Creates a data provider using the provided settings. A data provider stores a data
    /// store type and location information about your database.
    /// </summary>
    [Cmdlet("New", "DMSDataProvider", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DatabaseMigrationService.Model.DataProvider")]
    [AWSCmdlet("Calls the AWS Database Migration Service CreateDataProvider API operation.", Operation = new[] {"CreateDataProvider"}, SelectReturnType = typeof(Amazon.DatabaseMigrationService.Model.CreateDataProviderResponse))]
    [AWSCmdletOutput("Amazon.DatabaseMigrationService.Model.DataProvider or Amazon.DatabaseMigrationService.Model.CreateDataProviderResponse",
        "This cmdlet returns an Amazon.DatabaseMigrationService.Model.DataProvider object.",
        "The service call response (type Amazon.DatabaseMigrationService.Model.CreateDataProviderResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewDMSDataProviderCmdlet : AmazonDatabaseMigrationServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter OracleSettings_AsmServer
        /// <summary>
        /// <para>
        /// <para>The address of your Oracle Automatic Storage Management (ASM) server. You can set
        /// this value from the <c>asm_server</c> value. You set <c>asm_server</c> as part of
        /// the extra connection attribute string to access an Oracle server with Binary Reader
        /// that uses ASM. For more information, see <a href="https://docs.aws.amazon.com/dms/latest/userguide/CHAP_Source.Oracle.html#dms/latest/userguide/CHAP_Source.Oracle.html#CHAP_Source.Oracle.CDC.Configuration">Configuration
        /// for change data capture (CDC) on an Oracle source database</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings_OracleSettings_AsmServer")]
        public System.String OracleSettings_AsmServer { get; set; }
        #endregion
        
        #region Parameter MongoDbSettings_AuthMechanism
        /// <summary>
        /// <para>
        /// <para>The authentication method for connecting to the data provider. Valid values are DEFAULT,
        /// MONGODB_CR, or SCRAM_SHA_1.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings_MongoDbSettings_AuthMechanism")]
        [AWSConstantClassSource("Amazon.DatabaseMigrationService.AuthMechanismValue")]
        public Amazon.DatabaseMigrationService.AuthMechanismValue MongoDbSettings_AuthMechanism { get; set; }
        #endregion
        
        #region Parameter MongoDbSettings_AuthSource
        /// <summary>
        /// <para>
        /// <para> The MongoDB database name. This setting isn't used when <c>AuthType</c> is set to
        /// <c>"no"</c>. </para><para>The default is <c>"admin"</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings_MongoDbSettings_AuthSource")]
        public System.String MongoDbSettings_AuthSource { get; set; }
        #endregion
        
        #region Parameter MongoDbSettings_AuthType
        /// <summary>
        /// <para>
        /// <para>The authentication type for the database connection. Valid values are PASSWORD or
        /// NO.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings_MongoDbSettings_AuthType")]
        [AWSConstantClassSource("Amazon.DatabaseMigrationService.AuthTypeValue")]
        public Amazon.DatabaseMigrationService.AuthTypeValue MongoDbSettings_AuthType { get; set; }
        #endregion
        
        #region Parameter DocDbSettings_CertificateArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the certificate used for SSL connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings_DocDbSettings_CertificateArn")]
        public System.String DocDbSettings_CertificateArn { get; set; }
        #endregion
        
        #region Parameter MariaDbSettings_CertificateArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the certificate used for SSL connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings_MariaDbSettings_CertificateArn")]
        public System.String MariaDbSettings_CertificateArn { get; set; }
        #endregion
        
        #region Parameter MicrosoftSqlServerSettings_CertificateArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the certificate used for SSL connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings_MicrosoftSqlServerSettings_CertificateArn")]
        public System.String MicrosoftSqlServerSettings_CertificateArn { get; set; }
        #endregion
        
        #region Parameter MongoDbSettings_CertificateArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the certificate used for SSL connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings_MongoDbSettings_CertificateArn")]
        public System.String MongoDbSettings_CertificateArn { get; set; }
        #endregion
        
        #region Parameter MySqlSettings_CertificateArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the certificate used for SSL connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings_MySqlSettings_CertificateArn")]
        public System.String MySqlSettings_CertificateArn { get; set; }
        #endregion
        
        #region Parameter OracleSettings_CertificateArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the certificate used for SSL connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings_OracleSettings_CertificateArn")]
        public System.String OracleSettings_CertificateArn { get; set; }
        #endregion
        
        #region Parameter PostgreSqlSettings_CertificateArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the certificate used for SSL connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings_PostgreSqlSettings_CertificateArn")]
        public System.String PostgreSqlSettings_CertificateArn { get; set; }
        #endregion
        
        #region Parameter DocDbSettings_DatabaseName
        /// <summary>
        /// <para>
        /// <para>The database name on the DocumentDB data provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings_DocDbSettings_DatabaseName")]
        public System.String DocDbSettings_DatabaseName { get; set; }
        #endregion
        
        #region Parameter MicrosoftSqlServerSettings_DatabaseName
        /// <summary>
        /// <para>
        /// <para>The database name on the Microsoft SQL Server data provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings_MicrosoftSqlServerSettings_DatabaseName")]
        public System.String MicrosoftSqlServerSettings_DatabaseName { get; set; }
        #endregion
        
        #region Parameter MongoDbSettings_DatabaseName
        /// <summary>
        /// <para>
        /// <para>The database name on the MongoDB data provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings_MongoDbSettings_DatabaseName")]
        public System.String MongoDbSettings_DatabaseName { get; set; }
        #endregion
        
        #region Parameter OracleSettings_DatabaseName
        /// <summary>
        /// <para>
        /// <para>The database name on the Oracle data provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings_OracleSettings_DatabaseName")]
        public System.String OracleSettings_DatabaseName { get; set; }
        #endregion
        
        #region Parameter PostgreSqlSettings_DatabaseName
        /// <summary>
        /// <para>
        /// <para>The database name on the PostgreSQL data provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings_PostgreSqlSettings_DatabaseName")]
        public System.String PostgreSqlSettings_DatabaseName { get; set; }
        #endregion
        
        #region Parameter RedshiftSettings_DatabaseName
        /// <summary>
        /// <para>
        /// <para>The database name on the Amazon Redshift data provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings_RedshiftSettings_DatabaseName")]
        public System.String RedshiftSettings_DatabaseName { get; set; }
        #endregion
        
        #region Parameter DataProviderName
        /// <summary>
        /// <para>
        /// <para>A user-friendly name for the data provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DataProviderName { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A user-friendly description of the data provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Engine
        /// <summary>
        /// <para>
        /// <para>The type of database engine for the data provider. Valid values include <c>"aurora"</c>,
        /// <c>"aurora-postgresql"</c>, <c>"mysql"</c>, <c>"oracle"</c>, <c>"postgres"</c>, <c>"sqlserver"</c>,
        /// <c>redshift</c>, <c>mariadb</c>, <c>mongodb</c>, and <c>docdb</c>. A value of <c>"aurora"</c>
        /// represents Amazon Aurora MySQL-Compatible Edition.</para>
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
        public System.String Engine { get; set; }
        #endregion
        
        #region Parameter DocDbSettings_Port
        /// <summary>
        /// <para>
        /// <para>The port value for the DocumentDB data provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings_DocDbSettings_Port")]
        public System.Int32? DocDbSettings_Port { get; set; }
        #endregion
        
        #region Parameter MariaDbSettings_Port
        /// <summary>
        /// <para>
        /// <para>The port value for the MariaDB data provider</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings_MariaDbSettings_Port")]
        public System.Int32? MariaDbSettings_Port { get; set; }
        #endregion
        
        #region Parameter MicrosoftSqlServerSettings_Port
        /// <summary>
        /// <para>
        /// <para>The port value for the Microsoft SQL Server data provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings_MicrosoftSqlServerSettings_Port")]
        public System.Int32? MicrosoftSqlServerSettings_Port { get; set; }
        #endregion
        
        #region Parameter MongoDbSettings_Port
        /// <summary>
        /// <para>
        /// <para>The port value for the MongoDB data provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings_MongoDbSettings_Port")]
        public System.Int32? MongoDbSettings_Port { get; set; }
        #endregion
        
        #region Parameter MySqlSettings_Port
        /// <summary>
        /// <para>
        /// <para>The port value for the MySQL data provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings_MySqlSettings_Port")]
        public System.Int32? MySqlSettings_Port { get; set; }
        #endregion
        
        #region Parameter OracleSettings_Port
        /// <summary>
        /// <para>
        /// <para>The port value for the Oracle data provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings_OracleSettings_Port")]
        public System.Int32? OracleSettings_Port { get; set; }
        #endregion
        
        #region Parameter PostgreSqlSettings_Port
        /// <summary>
        /// <para>
        /// <para>The port value for the PostgreSQL data provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings_PostgreSqlSettings_Port")]
        public System.Int32? PostgreSqlSettings_Port { get; set; }
        #endregion
        
        #region Parameter RedshiftSettings_Port
        /// <summary>
        /// <para>
        /// <para>The port value for the Amazon Redshift data provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings_RedshiftSettings_Port")]
        public System.Int32? RedshiftSettings_Port { get; set; }
        #endregion
        
        #region Parameter OracleSettings_SecretsManagerOracleAsmAccessRoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role that provides access to the secret in Secrets Manager that
        /// contains the Oracle ASM connection details.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings_OracleSettings_SecretsManagerOracleAsmAccessRoleArn")]
        public System.String OracleSettings_SecretsManagerOracleAsmAccessRoleArn { get; set; }
        #endregion
        
        #region Parameter OracleSettings_SecretsManagerOracleAsmSecretId
        /// <summary>
        /// <para>
        /// <para>The identifier of the secret in Secrets Manager that contains the Oracle ASM connection
        /// details.</para><para>Required only if your data provider uses the Oracle ASM server.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings_OracleSettings_SecretsManagerOracleAsmSecretId")]
        public System.String OracleSettings_SecretsManagerOracleAsmSecretId { get; set; }
        #endregion
        
        #region Parameter OracleSettings_SecretsManagerSecurityDbEncryptionAccessRoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role that provides access to the secret in Secrets Manager that
        /// contains the TDE password.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings_OracleSettings_SecretsManagerSecurityDbEncryptionAccessRoleArn")]
        public System.String OracleSettings_SecretsManagerSecurityDbEncryptionAccessRoleArn { get; set; }
        #endregion
        
        #region Parameter OracleSettings_SecretsManagerSecurityDbEncryptionSecretId
        /// <summary>
        /// <para>
        /// <para>The identifier of the secret in Secrets Manager that contains the transparent data
        /// encryption (TDE) password. DMS requires this password to access Oracle redo logs encrypted
        /// by TDE using Binary Reader.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings_OracleSettings_SecretsManagerSecurityDbEncryptionSecretId")]
        public System.String OracleSettings_SecretsManagerSecurityDbEncryptionSecretId { get; set; }
        #endregion
        
        #region Parameter DocDbSettings_ServerName
        /// <summary>
        /// <para>
        /// <para>The name of the source DocumentDB server.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings_DocDbSettings_ServerName")]
        public System.String DocDbSettings_ServerName { get; set; }
        #endregion
        
        #region Parameter MariaDbSettings_ServerName
        /// <summary>
        /// <para>
        /// <para>The name of the MariaDB server.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings_MariaDbSettings_ServerName")]
        public System.String MariaDbSettings_ServerName { get; set; }
        #endregion
        
        #region Parameter MicrosoftSqlServerSettings_ServerName
        /// <summary>
        /// <para>
        /// <para>The name of the Microsoft SQL Server server.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings_MicrosoftSqlServerSettings_ServerName")]
        public System.String MicrosoftSqlServerSettings_ServerName { get; set; }
        #endregion
        
        #region Parameter MongoDbSettings_ServerName
        /// <summary>
        /// <para>
        /// <para>The name of the MongoDB server.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings_MongoDbSettings_ServerName")]
        public System.String MongoDbSettings_ServerName { get; set; }
        #endregion
        
        #region Parameter MySqlSettings_ServerName
        /// <summary>
        /// <para>
        /// <para>The name of the MySQL server.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings_MySqlSettings_ServerName")]
        public System.String MySqlSettings_ServerName { get; set; }
        #endregion
        
        #region Parameter OracleSettings_ServerName
        /// <summary>
        /// <para>
        /// <para>The name of the Oracle server.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings_OracleSettings_ServerName")]
        public System.String OracleSettings_ServerName { get; set; }
        #endregion
        
        #region Parameter PostgreSqlSettings_ServerName
        /// <summary>
        /// <para>
        /// <para>The name of the PostgreSQL server.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings_PostgreSqlSettings_ServerName")]
        public System.String PostgreSqlSettings_ServerName { get; set; }
        #endregion
        
        #region Parameter RedshiftSettings_ServerName
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon Redshift server.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings_RedshiftSettings_ServerName")]
        public System.String RedshiftSettings_ServerName { get; set; }
        #endregion
        
        #region Parameter DocDbSettings_SslMode
        /// <summary>
        /// <para>
        /// <para>The SSL mode used to connect to the DocumentDB data provider. The default value is
        /// <c>none</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings_DocDbSettings_SslMode")]
        [AWSConstantClassSource("Amazon.DatabaseMigrationService.DmsSslModeValue")]
        public Amazon.DatabaseMigrationService.DmsSslModeValue DocDbSettings_SslMode { get; set; }
        #endregion
        
        #region Parameter MariaDbSettings_SslMode
        /// <summary>
        /// <para>
        /// <para>The SSL mode used to connect to the MariaDB data provider. The default value is <c>none</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings_MariaDbSettings_SslMode")]
        [AWSConstantClassSource("Amazon.DatabaseMigrationService.DmsSslModeValue")]
        public Amazon.DatabaseMigrationService.DmsSslModeValue MariaDbSettings_SslMode { get; set; }
        #endregion
        
        #region Parameter MicrosoftSqlServerSettings_SslMode
        /// <summary>
        /// <para>
        /// <para>The SSL mode used to connect to the Microsoft SQL Server data provider. The default
        /// value is <c>none</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings_MicrosoftSqlServerSettings_SslMode")]
        [AWSConstantClassSource("Amazon.DatabaseMigrationService.DmsSslModeValue")]
        public Amazon.DatabaseMigrationService.DmsSslModeValue MicrosoftSqlServerSettings_SslMode { get; set; }
        #endregion
        
        #region Parameter MongoDbSettings_SslMode
        /// <summary>
        /// <para>
        /// <para>The SSL mode used to connect to the MongoDB data provider. The default value is <c>none</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings_MongoDbSettings_SslMode")]
        [AWSConstantClassSource("Amazon.DatabaseMigrationService.DmsSslModeValue")]
        public Amazon.DatabaseMigrationService.DmsSslModeValue MongoDbSettings_SslMode { get; set; }
        #endregion
        
        #region Parameter MySqlSettings_SslMode
        /// <summary>
        /// <para>
        /// <para>The SSL mode used to connect to the MySQL data provider. The default value is <c>none</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings_MySqlSettings_SslMode")]
        [AWSConstantClassSource("Amazon.DatabaseMigrationService.DmsSslModeValue")]
        public Amazon.DatabaseMigrationService.DmsSslModeValue MySqlSettings_SslMode { get; set; }
        #endregion
        
        #region Parameter OracleSettings_SslMode
        /// <summary>
        /// <para>
        /// <para>The SSL mode used to connect to the Oracle data provider. The default value is <c>none</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings_OracleSettings_SslMode")]
        [AWSConstantClassSource("Amazon.DatabaseMigrationService.DmsSslModeValue")]
        public Amazon.DatabaseMigrationService.DmsSslModeValue OracleSettings_SslMode { get; set; }
        #endregion
        
        #region Parameter PostgreSqlSettings_SslMode
        /// <summary>
        /// <para>
        /// <para>The SSL mode used to connect to the PostgreSQL data provider. The default value is
        /// <c>none</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings_PostgreSqlSettings_SslMode")]
        [AWSConstantClassSource("Amazon.DatabaseMigrationService.DmsSslModeValue")]
        public Amazon.DatabaseMigrationService.DmsSslModeValue PostgreSqlSettings_SslMode { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>One or more tags to be assigned to the data provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.DatabaseMigrationService.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DataProvider'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DatabaseMigrationService.Model.CreateDataProviderResponse).
        /// Specifying the name of a property of type Amazon.DatabaseMigrationService.Model.CreateDataProviderResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DataProvider";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Engine parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Engine' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Engine' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DataProviderName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-DMSDataProvider (CreateDataProvider)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DatabaseMigrationService.Model.CreateDataProviderResponse, NewDMSDataProviderCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Engine;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DataProviderName = this.DataProviderName;
            context.Description = this.Description;
            context.Engine = this.Engine;
            #if MODULAR
            if (this.Engine == null && ParameterWasBound(nameof(this.Engine)))
            {
                WriteWarning("You are passing $null as a value for parameter Engine which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DocDbSettings_CertificateArn = this.DocDbSettings_CertificateArn;
            context.DocDbSettings_DatabaseName = this.DocDbSettings_DatabaseName;
            context.DocDbSettings_Port = this.DocDbSettings_Port;
            context.DocDbSettings_ServerName = this.DocDbSettings_ServerName;
            context.DocDbSettings_SslMode = this.DocDbSettings_SslMode;
            context.MariaDbSettings_CertificateArn = this.MariaDbSettings_CertificateArn;
            context.MariaDbSettings_Port = this.MariaDbSettings_Port;
            context.MariaDbSettings_ServerName = this.MariaDbSettings_ServerName;
            context.MariaDbSettings_SslMode = this.MariaDbSettings_SslMode;
            context.MicrosoftSqlServerSettings_CertificateArn = this.MicrosoftSqlServerSettings_CertificateArn;
            context.MicrosoftSqlServerSettings_DatabaseName = this.MicrosoftSqlServerSettings_DatabaseName;
            context.MicrosoftSqlServerSettings_Port = this.MicrosoftSqlServerSettings_Port;
            context.MicrosoftSqlServerSettings_ServerName = this.MicrosoftSqlServerSettings_ServerName;
            context.MicrosoftSqlServerSettings_SslMode = this.MicrosoftSqlServerSettings_SslMode;
            context.MongoDbSettings_AuthMechanism = this.MongoDbSettings_AuthMechanism;
            context.MongoDbSettings_AuthSource = this.MongoDbSettings_AuthSource;
            context.MongoDbSettings_AuthType = this.MongoDbSettings_AuthType;
            context.MongoDbSettings_CertificateArn = this.MongoDbSettings_CertificateArn;
            context.MongoDbSettings_DatabaseName = this.MongoDbSettings_DatabaseName;
            context.MongoDbSettings_Port = this.MongoDbSettings_Port;
            context.MongoDbSettings_ServerName = this.MongoDbSettings_ServerName;
            context.MongoDbSettings_SslMode = this.MongoDbSettings_SslMode;
            context.MySqlSettings_CertificateArn = this.MySqlSettings_CertificateArn;
            context.MySqlSettings_Port = this.MySqlSettings_Port;
            context.MySqlSettings_ServerName = this.MySqlSettings_ServerName;
            context.MySqlSettings_SslMode = this.MySqlSettings_SslMode;
            context.OracleSettings_AsmServer = this.OracleSettings_AsmServer;
            context.OracleSettings_CertificateArn = this.OracleSettings_CertificateArn;
            context.OracleSettings_DatabaseName = this.OracleSettings_DatabaseName;
            context.OracleSettings_Port = this.OracleSettings_Port;
            context.OracleSettings_SecretsManagerOracleAsmAccessRoleArn = this.OracleSettings_SecretsManagerOracleAsmAccessRoleArn;
            context.OracleSettings_SecretsManagerOracleAsmSecretId = this.OracleSettings_SecretsManagerOracleAsmSecretId;
            context.OracleSettings_SecretsManagerSecurityDbEncryptionAccessRoleArn = this.OracleSettings_SecretsManagerSecurityDbEncryptionAccessRoleArn;
            context.OracleSettings_SecretsManagerSecurityDbEncryptionSecretId = this.OracleSettings_SecretsManagerSecurityDbEncryptionSecretId;
            context.OracleSettings_ServerName = this.OracleSettings_ServerName;
            context.OracleSettings_SslMode = this.OracleSettings_SslMode;
            context.PostgreSqlSettings_CertificateArn = this.PostgreSqlSettings_CertificateArn;
            context.PostgreSqlSettings_DatabaseName = this.PostgreSqlSettings_DatabaseName;
            context.PostgreSqlSettings_Port = this.PostgreSqlSettings_Port;
            context.PostgreSqlSettings_ServerName = this.PostgreSqlSettings_ServerName;
            context.PostgreSqlSettings_SslMode = this.PostgreSqlSettings_SslMode;
            context.RedshiftSettings_DatabaseName = this.RedshiftSettings_DatabaseName;
            context.RedshiftSettings_Port = this.RedshiftSettings_Port;
            context.RedshiftSettings_ServerName = this.RedshiftSettings_ServerName;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.DatabaseMigrationService.Model.Tag>(this.Tag);
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
            var request = new Amazon.DatabaseMigrationService.Model.CreateDataProviderRequest();
            
            if (cmdletContext.DataProviderName != null)
            {
                request.DataProviderName = cmdletContext.DataProviderName;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Engine != null)
            {
                request.Engine = cmdletContext.Engine;
            }
            
             // populate Settings
            var requestSettingsIsNull = true;
            request.Settings = new Amazon.DatabaseMigrationService.Model.DataProviderSettings();
            Amazon.DatabaseMigrationService.Model.RedshiftDataProviderSettings requestSettings_settings_RedshiftSettings = null;
            
             // populate RedshiftSettings
            var requestSettings_settings_RedshiftSettingsIsNull = true;
            requestSettings_settings_RedshiftSettings = new Amazon.DatabaseMigrationService.Model.RedshiftDataProviderSettings();
            System.String requestSettings_settings_RedshiftSettings_redshiftSettings_DatabaseName = null;
            if (cmdletContext.RedshiftSettings_DatabaseName != null)
            {
                requestSettings_settings_RedshiftSettings_redshiftSettings_DatabaseName = cmdletContext.RedshiftSettings_DatabaseName;
            }
            if (requestSettings_settings_RedshiftSettings_redshiftSettings_DatabaseName != null)
            {
                requestSettings_settings_RedshiftSettings.DatabaseName = requestSettings_settings_RedshiftSettings_redshiftSettings_DatabaseName;
                requestSettings_settings_RedshiftSettingsIsNull = false;
            }
            System.Int32? requestSettings_settings_RedshiftSettings_redshiftSettings_Port = null;
            if (cmdletContext.RedshiftSettings_Port != null)
            {
                requestSettings_settings_RedshiftSettings_redshiftSettings_Port = cmdletContext.RedshiftSettings_Port.Value;
            }
            if (requestSettings_settings_RedshiftSettings_redshiftSettings_Port != null)
            {
                requestSettings_settings_RedshiftSettings.Port = requestSettings_settings_RedshiftSettings_redshiftSettings_Port.Value;
                requestSettings_settings_RedshiftSettingsIsNull = false;
            }
            System.String requestSettings_settings_RedshiftSettings_redshiftSettings_ServerName = null;
            if (cmdletContext.RedshiftSettings_ServerName != null)
            {
                requestSettings_settings_RedshiftSettings_redshiftSettings_ServerName = cmdletContext.RedshiftSettings_ServerName;
            }
            if (requestSettings_settings_RedshiftSettings_redshiftSettings_ServerName != null)
            {
                requestSettings_settings_RedshiftSettings.ServerName = requestSettings_settings_RedshiftSettings_redshiftSettings_ServerName;
                requestSettings_settings_RedshiftSettingsIsNull = false;
            }
             // determine if requestSettings_settings_RedshiftSettings should be set to null
            if (requestSettings_settings_RedshiftSettingsIsNull)
            {
                requestSettings_settings_RedshiftSettings = null;
            }
            if (requestSettings_settings_RedshiftSettings != null)
            {
                request.Settings.RedshiftSettings = requestSettings_settings_RedshiftSettings;
                requestSettingsIsNull = false;
            }
            Amazon.DatabaseMigrationService.Model.MariaDbDataProviderSettings requestSettings_settings_MariaDbSettings = null;
            
             // populate MariaDbSettings
            var requestSettings_settings_MariaDbSettingsIsNull = true;
            requestSettings_settings_MariaDbSettings = new Amazon.DatabaseMigrationService.Model.MariaDbDataProviderSettings();
            System.String requestSettings_settings_MariaDbSettings_mariaDbSettings_CertificateArn = null;
            if (cmdletContext.MariaDbSettings_CertificateArn != null)
            {
                requestSettings_settings_MariaDbSettings_mariaDbSettings_CertificateArn = cmdletContext.MariaDbSettings_CertificateArn;
            }
            if (requestSettings_settings_MariaDbSettings_mariaDbSettings_CertificateArn != null)
            {
                requestSettings_settings_MariaDbSettings.CertificateArn = requestSettings_settings_MariaDbSettings_mariaDbSettings_CertificateArn;
                requestSettings_settings_MariaDbSettingsIsNull = false;
            }
            System.Int32? requestSettings_settings_MariaDbSettings_mariaDbSettings_Port = null;
            if (cmdletContext.MariaDbSettings_Port != null)
            {
                requestSettings_settings_MariaDbSettings_mariaDbSettings_Port = cmdletContext.MariaDbSettings_Port.Value;
            }
            if (requestSettings_settings_MariaDbSettings_mariaDbSettings_Port != null)
            {
                requestSettings_settings_MariaDbSettings.Port = requestSettings_settings_MariaDbSettings_mariaDbSettings_Port.Value;
                requestSettings_settings_MariaDbSettingsIsNull = false;
            }
            System.String requestSettings_settings_MariaDbSettings_mariaDbSettings_ServerName = null;
            if (cmdletContext.MariaDbSettings_ServerName != null)
            {
                requestSettings_settings_MariaDbSettings_mariaDbSettings_ServerName = cmdletContext.MariaDbSettings_ServerName;
            }
            if (requestSettings_settings_MariaDbSettings_mariaDbSettings_ServerName != null)
            {
                requestSettings_settings_MariaDbSettings.ServerName = requestSettings_settings_MariaDbSettings_mariaDbSettings_ServerName;
                requestSettings_settings_MariaDbSettingsIsNull = false;
            }
            Amazon.DatabaseMigrationService.DmsSslModeValue requestSettings_settings_MariaDbSettings_mariaDbSettings_SslMode = null;
            if (cmdletContext.MariaDbSettings_SslMode != null)
            {
                requestSettings_settings_MariaDbSettings_mariaDbSettings_SslMode = cmdletContext.MariaDbSettings_SslMode;
            }
            if (requestSettings_settings_MariaDbSettings_mariaDbSettings_SslMode != null)
            {
                requestSettings_settings_MariaDbSettings.SslMode = requestSettings_settings_MariaDbSettings_mariaDbSettings_SslMode;
                requestSettings_settings_MariaDbSettingsIsNull = false;
            }
             // determine if requestSettings_settings_MariaDbSettings should be set to null
            if (requestSettings_settings_MariaDbSettingsIsNull)
            {
                requestSettings_settings_MariaDbSettings = null;
            }
            if (requestSettings_settings_MariaDbSettings != null)
            {
                request.Settings.MariaDbSettings = requestSettings_settings_MariaDbSettings;
                requestSettingsIsNull = false;
            }
            Amazon.DatabaseMigrationService.Model.MySqlDataProviderSettings requestSettings_settings_MySqlSettings = null;
            
             // populate MySqlSettings
            var requestSettings_settings_MySqlSettingsIsNull = true;
            requestSettings_settings_MySqlSettings = new Amazon.DatabaseMigrationService.Model.MySqlDataProviderSettings();
            System.String requestSettings_settings_MySqlSettings_mySqlSettings_CertificateArn = null;
            if (cmdletContext.MySqlSettings_CertificateArn != null)
            {
                requestSettings_settings_MySqlSettings_mySqlSettings_CertificateArn = cmdletContext.MySqlSettings_CertificateArn;
            }
            if (requestSettings_settings_MySqlSettings_mySqlSettings_CertificateArn != null)
            {
                requestSettings_settings_MySqlSettings.CertificateArn = requestSettings_settings_MySqlSettings_mySqlSettings_CertificateArn;
                requestSettings_settings_MySqlSettingsIsNull = false;
            }
            System.Int32? requestSettings_settings_MySqlSettings_mySqlSettings_Port = null;
            if (cmdletContext.MySqlSettings_Port != null)
            {
                requestSettings_settings_MySqlSettings_mySqlSettings_Port = cmdletContext.MySqlSettings_Port.Value;
            }
            if (requestSettings_settings_MySqlSettings_mySqlSettings_Port != null)
            {
                requestSettings_settings_MySqlSettings.Port = requestSettings_settings_MySqlSettings_mySqlSettings_Port.Value;
                requestSettings_settings_MySqlSettingsIsNull = false;
            }
            System.String requestSettings_settings_MySqlSettings_mySqlSettings_ServerName = null;
            if (cmdletContext.MySqlSettings_ServerName != null)
            {
                requestSettings_settings_MySqlSettings_mySqlSettings_ServerName = cmdletContext.MySqlSettings_ServerName;
            }
            if (requestSettings_settings_MySqlSettings_mySqlSettings_ServerName != null)
            {
                requestSettings_settings_MySqlSettings.ServerName = requestSettings_settings_MySqlSettings_mySqlSettings_ServerName;
                requestSettings_settings_MySqlSettingsIsNull = false;
            }
            Amazon.DatabaseMigrationService.DmsSslModeValue requestSettings_settings_MySqlSettings_mySqlSettings_SslMode = null;
            if (cmdletContext.MySqlSettings_SslMode != null)
            {
                requestSettings_settings_MySqlSettings_mySqlSettings_SslMode = cmdletContext.MySqlSettings_SslMode;
            }
            if (requestSettings_settings_MySqlSettings_mySqlSettings_SslMode != null)
            {
                requestSettings_settings_MySqlSettings.SslMode = requestSettings_settings_MySqlSettings_mySqlSettings_SslMode;
                requestSettings_settings_MySqlSettingsIsNull = false;
            }
             // determine if requestSettings_settings_MySqlSettings should be set to null
            if (requestSettings_settings_MySqlSettingsIsNull)
            {
                requestSettings_settings_MySqlSettings = null;
            }
            if (requestSettings_settings_MySqlSettings != null)
            {
                request.Settings.MySqlSettings = requestSettings_settings_MySqlSettings;
                requestSettingsIsNull = false;
            }
            Amazon.DatabaseMigrationService.Model.DocDbDataProviderSettings requestSettings_settings_DocDbSettings = null;
            
             // populate DocDbSettings
            var requestSettings_settings_DocDbSettingsIsNull = true;
            requestSettings_settings_DocDbSettings = new Amazon.DatabaseMigrationService.Model.DocDbDataProviderSettings();
            System.String requestSettings_settings_DocDbSettings_docDbSettings_CertificateArn = null;
            if (cmdletContext.DocDbSettings_CertificateArn != null)
            {
                requestSettings_settings_DocDbSettings_docDbSettings_CertificateArn = cmdletContext.DocDbSettings_CertificateArn;
            }
            if (requestSettings_settings_DocDbSettings_docDbSettings_CertificateArn != null)
            {
                requestSettings_settings_DocDbSettings.CertificateArn = requestSettings_settings_DocDbSettings_docDbSettings_CertificateArn;
                requestSettings_settings_DocDbSettingsIsNull = false;
            }
            System.String requestSettings_settings_DocDbSettings_docDbSettings_DatabaseName = null;
            if (cmdletContext.DocDbSettings_DatabaseName != null)
            {
                requestSettings_settings_DocDbSettings_docDbSettings_DatabaseName = cmdletContext.DocDbSettings_DatabaseName;
            }
            if (requestSettings_settings_DocDbSettings_docDbSettings_DatabaseName != null)
            {
                requestSettings_settings_DocDbSettings.DatabaseName = requestSettings_settings_DocDbSettings_docDbSettings_DatabaseName;
                requestSettings_settings_DocDbSettingsIsNull = false;
            }
            System.Int32? requestSettings_settings_DocDbSettings_docDbSettings_Port = null;
            if (cmdletContext.DocDbSettings_Port != null)
            {
                requestSettings_settings_DocDbSettings_docDbSettings_Port = cmdletContext.DocDbSettings_Port.Value;
            }
            if (requestSettings_settings_DocDbSettings_docDbSettings_Port != null)
            {
                requestSettings_settings_DocDbSettings.Port = requestSettings_settings_DocDbSettings_docDbSettings_Port.Value;
                requestSettings_settings_DocDbSettingsIsNull = false;
            }
            System.String requestSettings_settings_DocDbSettings_docDbSettings_ServerName = null;
            if (cmdletContext.DocDbSettings_ServerName != null)
            {
                requestSettings_settings_DocDbSettings_docDbSettings_ServerName = cmdletContext.DocDbSettings_ServerName;
            }
            if (requestSettings_settings_DocDbSettings_docDbSettings_ServerName != null)
            {
                requestSettings_settings_DocDbSettings.ServerName = requestSettings_settings_DocDbSettings_docDbSettings_ServerName;
                requestSettings_settings_DocDbSettingsIsNull = false;
            }
            Amazon.DatabaseMigrationService.DmsSslModeValue requestSettings_settings_DocDbSettings_docDbSettings_SslMode = null;
            if (cmdletContext.DocDbSettings_SslMode != null)
            {
                requestSettings_settings_DocDbSettings_docDbSettings_SslMode = cmdletContext.DocDbSettings_SslMode;
            }
            if (requestSettings_settings_DocDbSettings_docDbSettings_SslMode != null)
            {
                requestSettings_settings_DocDbSettings.SslMode = requestSettings_settings_DocDbSettings_docDbSettings_SslMode;
                requestSettings_settings_DocDbSettingsIsNull = false;
            }
             // determine if requestSettings_settings_DocDbSettings should be set to null
            if (requestSettings_settings_DocDbSettingsIsNull)
            {
                requestSettings_settings_DocDbSettings = null;
            }
            if (requestSettings_settings_DocDbSettings != null)
            {
                request.Settings.DocDbSettings = requestSettings_settings_DocDbSettings;
                requestSettingsIsNull = false;
            }
            Amazon.DatabaseMigrationService.Model.MicrosoftSqlServerDataProviderSettings requestSettings_settings_MicrosoftSqlServerSettings = null;
            
             // populate MicrosoftSqlServerSettings
            var requestSettings_settings_MicrosoftSqlServerSettingsIsNull = true;
            requestSettings_settings_MicrosoftSqlServerSettings = new Amazon.DatabaseMigrationService.Model.MicrosoftSqlServerDataProviderSettings();
            System.String requestSettings_settings_MicrosoftSqlServerSettings_microsoftSqlServerSettings_CertificateArn = null;
            if (cmdletContext.MicrosoftSqlServerSettings_CertificateArn != null)
            {
                requestSettings_settings_MicrosoftSqlServerSettings_microsoftSqlServerSettings_CertificateArn = cmdletContext.MicrosoftSqlServerSettings_CertificateArn;
            }
            if (requestSettings_settings_MicrosoftSqlServerSettings_microsoftSqlServerSettings_CertificateArn != null)
            {
                requestSettings_settings_MicrosoftSqlServerSettings.CertificateArn = requestSettings_settings_MicrosoftSqlServerSettings_microsoftSqlServerSettings_CertificateArn;
                requestSettings_settings_MicrosoftSqlServerSettingsIsNull = false;
            }
            System.String requestSettings_settings_MicrosoftSqlServerSettings_microsoftSqlServerSettings_DatabaseName = null;
            if (cmdletContext.MicrosoftSqlServerSettings_DatabaseName != null)
            {
                requestSettings_settings_MicrosoftSqlServerSettings_microsoftSqlServerSettings_DatabaseName = cmdletContext.MicrosoftSqlServerSettings_DatabaseName;
            }
            if (requestSettings_settings_MicrosoftSqlServerSettings_microsoftSqlServerSettings_DatabaseName != null)
            {
                requestSettings_settings_MicrosoftSqlServerSettings.DatabaseName = requestSettings_settings_MicrosoftSqlServerSettings_microsoftSqlServerSettings_DatabaseName;
                requestSettings_settings_MicrosoftSqlServerSettingsIsNull = false;
            }
            System.Int32? requestSettings_settings_MicrosoftSqlServerSettings_microsoftSqlServerSettings_Port = null;
            if (cmdletContext.MicrosoftSqlServerSettings_Port != null)
            {
                requestSettings_settings_MicrosoftSqlServerSettings_microsoftSqlServerSettings_Port = cmdletContext.MicrosoftSqlServerSettings_Port.Value;
            }
            if (requestSettings_settings_MicrosoftSqlServerSettings_microsoftSqlServerSettings_Port != null)
            {
                requestSettings_settings_MicrosoftSqlServerSettings.Port = requestSettings_settings_MicrosoftSqlServerSettings_microsoftSqlServerSettings_Port.Value;
                requestSettings_settings_MicrosoftSqlServerSettingsIsNull = false;
            }
            System.String requestSettings_settings_MicrosoftSqlServerSettings_microsoftSqlServerSettings_ServerName = null;
            if (cmdletContext.MicrosoftSqlServerSettings_ServerName != null)
            {
                requestSettings_settings_MicrosoftSqlServerSettings_microsoftSqlServerSettings_ServerName = cmdletContext.MicrosoftSqlServerSettings_ServerName;
            }
            if (requestSettings_settings_MicrosoftSqlServerSettings_microsoftSqlServerSettings_ServerName != null)
            {
                requestSettings_settings_MicrosoftSqlServerSettings.ServerName = requestSettings_settings_MicrosoftSqlServerSettings_microsoftSqlServerSettings_ServerName;
                requestSettings_settings_MicrosoftSqlServerSettingsIsNull = false;
            }
            Amazon.DatabaseMigrationService.DmsSslModeValue requestSettings_settings_MicrosoftSqlServerSettings_microsoftSqlServerSettings_SslMode = null;
            if (cmdletContext.MicrosoftSqlServerSettings_SslMode != null)
            {
                requestSettings_settings_MicrosoftSqlServerSettings_microsoftSqlServerSettings_SslMode = cmdletContext.MicrosoftSqlServerSettings_SslMode;
            }
            if (requestSettings_settings_MicrosoftSqlServerSettings_microsoftSqlServerSettings_SslMode != null)
            {
                requestSettings_settings_MicrosoftSqlServerSettings.SslMode = requestSettings_settings_MicrosoftSqlServerSettings_microsoftSqlServerSettings_SslMode;
                requestSettings_settings_MicrosoftSqlServerSettingsIsNull = false;
            }
             // determine if requestSettings_settings_MicrosoftSqlServerSettings should be set to null
            if (requestSettings_settings_MicrosoftSqlServerSettingsIsNull)
            {
                requestSettings_settings_MicrosoftSqlServerSettings = null;
            }
            if (requestSettings_settings_MicrosoftSqlServerSettings != null)
            {
                request.Settings.MicrosoftSqlServerSettings = requestSettings_settings_MicrosoftSqlServerSettings;
                requestSettingsIsNull = false;
            }
            Amazon.DatabaseMigrationService.Model.PostgreSqlDataProviderSettings requestSettings_settings_PostgreSqlSettings = null;
            
             // populate PostgreSqlSettings
            var requestSettings_settings_PostgreSqlSettingsIsNull = true;
            requestSettings_settings_PostgreSqlSettings = new Amazon.DatabaseMigrationService.Model.PostgreSqlDataProviderSettings();
            System.String requestSettings_settings_PostgreSqlSettings_postgreSqlSettings_CertificateArn = null;
            if (cmdletContext.PostgreSqlSettings_CertificateArn != null)
            {
                requestSettings_settings_PostgreSqlSettings_postgreSqlSettings_CertificateArn = cmdletContext.PostgreSqlSettings_CertificateArn;
            }
            if (requestSettings_settings_PostgreSqlSettings_postgreSqlSettings_CertificateArn != null)
            {
                requestSettings_settings_PostgreSqlSettings.CertificateArn = requestSettings_settings_PostgreSqlSettings_postgreSqlSettings_CertificateArn;
                requestSettings_settings_PostgreSqlSettingsIsNull = false;
            }
            System.String requestSettings_settings_PostgreSqlSettings_postgreSqlSettings_DatabaseName = null;
            if (cmdletContext.PostgreSqlSettings_DatabaseName != null)
            {
                requestSettings_settings_PostgreSqlSettings_postgreSqlSettings_DatabaseName = cmdletContext.PostgreSqlSettings_DatabaseName;
            }
            if (requestSettings_settings_PostgreSqlSettings_postgreSqlSettings_DatabaseName != null)
            {
                requestSettings_settings_PostgreSqlSettings.DatabaseName = requestSettings_settings_PostgreSqlSettings_postgreSqlSettings_DatabaseName;
                requestSettings_settings_PostgreSqlSettingsIsNull = false;
            }
            System.Int32? requestSettings_settings_PostgreSqlSettings_postgreSqlSettings_Port = null;
            if (cmdletContext.PostgreSqlSettings_Port != null)
            {
                requestSettings_settings_PostgreSqlSettings_postgreSqlSettings_Port = cmdletContext.PostgreSqlSettings_Port.Value;
            }
            if (requestSettings_settings_PostgreSqlSettings_postgreSqlSettings_Port != null)
            {
                requestSettings_settings_PostgreSqlSettings.Port = requestSettings_settings_PostgreSqlSettings_postgreSqlSettings_Port.Value;
                requestSettings_settings_PostgreSqlSettingsIsNull = false;
            }
            System.String requestSettings_settings_PostgreSqlSettings_postgreSqlSettings_ServerName = null;
            if (cmdletContext.PostgreSqlSettings_ServerName != null)
            {
                requestSettings_settings_PostgreSqlSettings_postgreSqlSettings_ServerName = cmdletContext.PostgreSqlSettings_ServerName;
            }
            if (requestSettings_settings_PostgreSqlSettings_postgreSqlSettings_ServerName != null)
            {
                requestSettings_settings_PostgreSqlSettings.ServerName = requestSettings_settings_PostgreSqlSettings_postgreSqlSettings_ServerName;
                requestSettings_settings_PostgreSqlSettingsIsNull = false;
            }
            Amazon.DatabaseMigrationService.DmsSslModeValue requestSettings_settings_PostgreSqlSettings_postgreSqlSettings_SslMode = null;
            if (cmdletContext.PostgreSqlSettings_SslMode != null)
            {
                requestSettings_settings_PostgreSqlSettings_postgreSqlSettings_SslMode = cmdletContext.PostgreSqlSettings_SslMode;
            }
            if (requestSettings_settings_PostgreSqlSettings_postgreSqlSettings_SslMode != null)
            {
                requestSettings_settings_PostgreSqlSettings.SslMode = requestSettings_settings_PostgreSqlSettings_postgreSqlSettings_SslMode;
                requestSettings_settings_PostgreSqlSettingsIsNull = false;
            }
             // determine if requestSettings_settings_PostgreSqlSettings should be set to null
            if (requestSettings_settings_PostgreSqlSettingsIsNull)
            {
                requestSettings_settings_PostgreSqlSettings = null;
            }
            if (requestSettings_settings_PostgreSqlSettings != null)
            {
                request.Settings.PostgreSqlSettings = requestSettings_settings_PostgreSqlSettings;
                requestSettingsIsNull = false;
            }
            Amazon.DatabaseMigrationService.Model.MongoDbDataProviderSettings requestSettings_settings_MongoDbSettings = null;
            
             // populate MongoDbSettings
            var requestSettings_settings_MongoDbSettingsIsNull = true;
            requestSettings_settings_MongoDbSettings = new Amazon.DatabaseMigrationService.Model.MongoDbDataProviderSettings();
            Amazon.DatabaseMigrationService.AuthMechanismValue requestSettings_settings_MongoDbSettings_mongoDbSettings_AuthMechanism = null;
            if (cmdletContext.MongoDbSettings_AuthMechanism != null)
            {
                requestSettings_settings_MongoDbSettings_mongoDbSettings_AuthMechanism = cmdletContext.MongoDbSettings_AuthMechanism;
            }
            if (requestSettings_settings_MongoDbSettings_mongoDbSettings_AuthMechanism != null)
            {
                requestSettings_settings_MongoDbSettings.AuthMechanism = requestSettings_settings_MongoDbSettings_mongoDbSettings_AuthMechanism;
                requestSettings_settings_MongoDbSettingsIsNull = false;
            }
            System.String requestSettings_settings_MongoDbSettings_mongoDbSettings_AuthSource = null;
            if (cmdletContext.MongoDbSettings_AuthSource != null)
            {
                requestSettings_settings_MongoDbSettings_mongoDbSettings_AuthSource = cmdletContext.MongoDbSettings_AuthSource;
            }
            if (requestSettings_settings_MongoDbSettings_mongoDbSettings_AuthSource != null)
            {
                requestSettings_settings_MongoDbSettings.AuthSource = requestSettings_settings_MongoDbSettings_mongoDbSettings_AuthSource;
                requestSettings_settings_MongoDbSettingsIsNull = false;
            }
            Amazon.DatabaseMigrationService.AuthTypeValue requestSettings_settings_MongoDbSettings_mongoDbSettings_AuthType = null;
            if (cmdletContext.MongoDbSettings_AuthType != null)
            {
                requestSettings_settings_MongoDbSettings_mongoDbSettings_AuthType = cmdletContext.MongoDbSettings_AuthType;
            }
            if (requestSettings_settings_MongoDbSettings_mongoDbSettings_AuthType != null)
            {
                requestSettings_settings_MongoDbSettings.AuthType = requestSettings_settings_MongoDbSettings_mongoDbSettings_AuthType;
                requestSettings_settings_MongoDbSettingsIsNull = false;
            }
            System.String requestSettings_settings_MongoDbSettings_mongoDbSettings_CertificateArn = null;
            if (cmdletContext.MongoDbSettings_CertificateArn != null)
            {
                requestSettings_settings_MongoDbSettings_mongoDbSettings_CertificateArn = cmdletContext.MongoDbSettings_CertificateArn;
            }
            if (requestSettings_settings_MongoDbSettings_mongoDbSettings_CertificateArn != null)
            {
                requestSettings_settings_MongoDbSettings.CertificateArn = requestSettings_settings_MongoDbSettings_mongoDbSettings_CertificateArn;
                requestSettings_settings_MongoDbSettingsIsNull = false;
            }
            System.String requestSettings_settings_MongoDbSettings_mongoDbSettings_DatabaseName = null;
            if (cmdletContext.MongoDbSettings_DatabaseName != null)
            {
                requestSettings_settings_MongoDbSettings_mongoDbSettings_DatabaseName = cmdletContext.MongoDbSettings_DatabaseName;
            }
            if (requestSettings_settings_MongoDbSettings_mongoDbSettings_DatabaseName != null)
            {
                requestSettings_settings_MongoDbSettings.DatabaseName = requestSettings_settings_MongoDbSettings_mongoDbSettings_DatabaseName;
                requestSettings_settings_MongoDbSettingsIsNull = false;
            }
            System.Int32? requestSettings_settings_MongoDbSettings_mongoDbSettings_Port = null;
            if (cmdletContext.MongoDbSettings_Port != null)
            {
                requestSettings_settings_MongoDbSettings_mongoDbSettings_Port = cmdletContext.MongoDbSettings_Port.Value;
            }
            if (requestSettings_settings_MongoDbSettings_mongoDbSettings_Port != null)
            {
                requestSettings_settings_MongoDbSettings.Port = requestSettings_settings_MongoDbSettings_mongoDbSettings_Port.Value;
                requestSettings_settings_MongoDbSettingsIsNull = false;
            }
            System.String requestSettings_settings_MongoDbSettings_mongoDbSettings_ServerName = null;
            if (cmdletContext.MongoDbSettings_ServerName != null)
            {
                requestSettings_settings_MongoDbSettings_mongoDbSettings_ServerName = cmdletContext.MongoDbSettings_ServerName;
            }
            if (requestSettings_settings_MongoDbSettings_mongoDbSettings_ServerName != null)
            {
                requestSettings_settings_MongoDbSettings.ServerName = requestSettings_settings_MongoDbSettings_mongoDbSettings_ServerName;
                requestSettings_settings_MongoDbSettingsIsNull = false;
            }
            Amazon.DatabaseMigrationService.DmsSslModeValue requestSettings_settings_MongoDbSettings_mongoDbSettings_SslMode = null;
            if (cmdletContext.MongoDbSettings_SslMode != null)
            {
                requestSettings_settings_MongoDbSettings_mongoDbSettings_SslMode = cmdletContext.MongoDbSettings_SslMode;
            }
            if (requestSettings_settings_MongoDbSettings_mongoDbSettings_SslMode != null)
            {
                requestSettings_settings_MongoDbSettings.SslMode = requestSettings_settings_MongoDbSettings_mongoDbSettings_SslMode;
                requestSettings_settings_MongoDbSettingsIsNull = false;
            }
             // determine if requestSettings_settings_MongoDbSettings should be set to null
            if (requestSettings_settings_MongoDbSettingsIsNull)
            {
                requestSettings_settings_MongoDbSettings = null;
            }
            if (requestSettings_settings_MongoDbSettings != null)
            {
                request.Settings.MongoDbSettings = requestSettings_settings_MongoDbSettings;
                requestSettingsIsNull = false;
            }
            Amazon.DatabaseMigrationService.Model.OracleDataProviderSettings requestSettings_settings_OracleSettings = null;
            
             // populate OracleSettings
            var requestSettings_settings_OracleSettingsIsNull = true;
            requestSettings_settings_OracleSettings = new Amazon.DatabaseMigrationService.Model.OracleDataProviderSettings();
            System.String requestSettings_settings_OracleSettings_oracleSettings_AsmServer = null;
            if (cmdletContext.OracleSettings_AsmServer != null)
            {
                requestSettings_settings_OracleSettings_oracleSettings_AsmServer = cmdletContext.OracleSettings_AsmServer;
            }
            if (requestSettings_settings_OracleSettings_oracleSettings_AsmServer != null)
            {
                requestSettings_settings_OracleSettings.AsmServer = requestSettings_settings_OracleSettings_oracleSettings_AsmServer;
                requestSettings_settings_OracleSettingsIsNull = false;
            }
            System.String requestSettings_settings_OracleSettings_oracleSettings_CertificateArn = null;
            if (cmdletContext.OracleSettings_CertificateArn != null)
            {
                requestSettings_settings_OracleSettings_oracleSettings_CertificateArn = cmdletContext.OracleSettings_CertificateArn;
            }
            if (requestSettings_settings_OracleSettings_oracleSettings_CertificateArn != null)
            {
                requestSettings_settings_OracleSettings.CertificateArn = requestSettings_settings_OracleSettings_oracleSettings_CertificateArn;
                requestSettings_settings_OracleSettingsIsNull = false;
            }
            System.String requestSettings_settings_OracleSettings_oracleSettings_DatabaseName = null;
            if (cmdletContext.OracleSettings_DatabaseName != null)
            {
                requestSettings_settings_OracleSettings_oracleSettings_DatabaseName = cmdletContext.OracleSettings_DatabaseName;
            }
            if (requestSettings_settings_OracleSettings_oracleSettings_DatabaseName != null)
            {
                requestSettings_settings_OracleSettings.DatabaseName = requestSettings_settings_OracleSettings_oracleSettings_DatabaseName;
                requestSettings_settings_OracleSettingsIsNull = false;
            }
            System.Int32? requestSettings_settings_OracleSettings_oracleSettings_Port = null;
            if (cmdletContext.OracleSettings_Port != null)
            {
                requestSettings_settings_OracleSettings_oracleSettings_Port = cmdletContext.OracleSettings_Port.Value;
            }
            if (requestSettings_settings_OracleSettings_oracleSettings_Port != null)
            {
                requestSettings_settings_OracleSettings.Port = requestSettings_settings_OracleSettings_oracleSettings_Port.Value;
                requestSettings_settings_OracleSettingsIsNull = false;
            }
            System.String requestSettings_settings_OracleSettings_oracleSettings_SecretsManagerOracleAsmAccessRoleArn = null;
            if (cmdletContext.OracleSettings_SecretsManagerOracleAsmAccessRoleArn != null)
            {
                requestSettings_settings_OracleSettings_oracleSettings_SecretsManagerOracleAsmAccessRoleArn = cmdletContext.OracleSettings_SecretsManagerOracleAsmAccessRoleArn;
            }
            if (requestSettings_settings_OracleSettings_oracleSettings_SecretsManagerOracleAsmAccessRoleArn != null)
            {
                requestSettings_settings_OracleSettings.SecretsManagerOracleAsmAccessRoleArn = requestSettings_settings_OracleSettings_oracleSettings_SecretsManagerOracleAsmAccessRoleArn;
                requestSettings_settings_OracleSettingsIsNull = false;
            }
            System.String requestSettings_settings_OracleSettings_oracleSettings_SecretsManagerOracleAsmSecretId = null;
            if (cmdletContext.OracleSettings_SecretsManagerOracleAsmSecretId != null)
            {
                requestSettings_settings_OracleSettings_oracleSettings_SecretsManagerOracleAsmSecretId = cmdletContext.OracleSettings_SecretsManagerOracleAsmSecretId;
            }
            if (requestSettings_settings_OracleSettings_oracleSettings_SecretsManagerOracleAsmSecretId != null)
            {
                requestSettings_settings_OracleSettings.SecretsManagerOracleAsmSecretId = requestSettings_settings_OracleSettings_oracleSettings_SecretsManagerOracleAsmSecretId;
                requestSettings_settings_OracleSettingsIsNull = false;
            }
            System.String requestSettings_settings_OracleSettings_oracleSettings_SecretsManagerSecurityDbEncryptionAccessRoleArn = null;
            if (cmdletContext.OracleSettings_SecretsManagerSecurityDbEncryptionAccessRoleArn != null)
            {
                requestSettings_settings_OracleSettings_oracleSettings_SecretsManagerSecurityDbEncryptionAccessRoleArn = cmdletContext.OracleSettings_SecretsManagerSecurityDbEncryptionAccessRoleArn;
            }
            if (requestSettings_settings_OracleSettings_oracleSettings_SecretsManagerSecurityDbEncryptionAccessRoleArn != null)
            {
                requestSettings_settings_OracleSettings.SecretsManagerSecurityDbEncryptionAccessRoleArn = requestSettings_settings_OracleSettings_oracleSettings_SecretsManagerSecurityDbEncryptionAccessRoleArn;
                requestSettings_settings_OracleSettingsIsNull = false;
            }
            System.String requestSettings_settings_OracleSettings_oracleSettings_SecretsManagerSecurityDbEncryptionSecretId = null;
            if (cmdletContext.OracleSettings_SecretsManagerSecurityDbEncryptionSecretId != null)
            {
                requestSettings_settings_OracleSettings_oracleSettings_SecretsManagerSecurityDbEncryptionSecretId = cmdletContext.OracleSettings_SecretsManagerSecurityDbEncryptionSecretId;
            }
            if (requestSettings_settings_OracleSettings_oracleSettings_SecretsManagerSecurityDbEncryptionSecretId != null)
            {
                requestSettings_settings_OracleSettings.SecretsManagerSecurityDbEncryptionSecretId = requestSettings_settings_OracleSettings_oracleSettings_SecretsManagerSecurityDbEncryptionSecretId;
                requestSettings_settings_OracleSettingsIsNull = false;
            }
            System.String requestSettings_settings_OracleSettings_oracleSettings_ServerName = null;
            if (cmdletContext.OracleSettings_ServerName != null)
            {
                requestSettings_settings_OracleSettings_oracleSettings_ServerName = cmdletContext.OracleSettings_ServerName;
            }
            if (requestSettings_settings_OracleSettings_oracleSettings_ServerName != null)
            {
                requestSettings_settings_OracleSettings.ServerName = requestSettings_settings_OracleSettings_oracleSettings_ServerName;
                requestSettings_settings_OracleSettingsIsNull = false;
            }
            Amazon.DatabaseMigrationService.DmsSslModeValue requestSettings_settings_OracleSettings_oracleSettings_SslMode = null;
            if (cmdletContext.OracleSettings_SslMode != null)
            {
                requestSettings_settings_OracleSettings_oracleSettings_SslMode = cmdletContext.OracleSettings_SslMode;
            }
            if (requestSettings_settings_OracleSettings_oracleSettings_SslMode != null)
            {
                requestSettings_settings_OracleSettings.SslMode = requestSettings_settings_OracleSettings_oracleSettings_SslMode;
                requestSettings_settings_OracleSettingsIsNull = false;
            }
             // determine if requestSettings_settings_OracleSettings should be set to null
            if (requestSettings_settings_OracleSettingsIsNull)
            {
                requestSettings_settings_OracleSettings = null;
            }
            if (requestSettings_settings_OracleSettings != null)
            {
                request.Settings.OracleSettings = requestSettings_settings_OracleSettings;
                requestSettingsIsNull = false;
            }
             // determine if request.Settings should be set to null
            if (requestSettingsIsNull)
            {
                request.Settings = null;
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
        
        private Amazon.DatabaseMigrationService.Model.CreateDataProviderResponse CallAWSServiceOperation(IAmazonDatabaseMigrationService client, Amazon.DatabaseMigrationService.Model.CreateDataProviderRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Database Migration Service", "CreateDataProvider");
            try
            {
                #if DESKTOP
                return client.CreateDataProvider(request);
                #elif CORECLR
                return client.CreateDataProviderAsync(request).GetAwaiter().GetResult();
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
            public System.String DataProviderName { get; set; }
            public System.String Description { get; set; }
            public System.String Engine { get; set; }
            public System.String DocDbSettings_CertificateArn { get; set; }
            public System.String DocDbSettings_DatabaseName { get; set; }
            public System.Int32? DocDbSettings_Port { get; set; }
            public System.String DocDbSettings_ServerName { get; set; }
            public Amazon.DatabaseMigrationService.DmsSslModeValue DocDbSettings_SslMode { get; set; }
            public System.String MariaDbSettings_CertificateArn { get; set; }
            public System.Int32? MariaDbSettings_Port { get; set; }
            public System.String MariaDbSettings_ServerName { get; set; }
            public Amazon.DatabaseMigrationService.DmsSslModeValue MariaDbSettings_SslMode { get; set; }
            public System.String MicrosoftSqlServerSettings_CertificateArn { get; set; }
            public System.String MicrosoftSqlServerSettings_DatabaseName { get; set; }
            public System.Int32? MicrosoftSqlServerSettings_Port { get; set; }
            public System.String MicrosoftSqlServerSettings_ServerName { get; set; }
            public Amazon.DatabaseMigrationService.DmsSslModeValue MicrosoftSqlServerSettings_SslMode { get; set; }
            public Amazon.DatabaseMigrationService.AuthMechanismValue MongoDbSettings_AuthMechanism { get; set; }
            public System.String MongoDbSettings_AuthSource { get; set; }
            public Amazon.DatabaseMigrationService.AuthTypeValue MongoDbSettings_AuthType { get; set; }
            public System.String MongoDbSettings_CertificateArn { get; set; }
            public System.String MongoDbSettings_DatabaseName { get; set; }
            public System.Int32? MongoDbSettings_Port { get; set; }
            public System.String MongoDbSettings_ServerName { get; set; }
            public Amazon.DatabaseMigrationService.DmsSslModeValue MongoDbSettings_SslMode { get; set; }
            public System.String MySqlSettings_CertificateArn { get; set; }
            public System.Int32? MySqlSettings_Port { get; set; }
            public System.String MySqlSettings_ServerName { get; set; }
            public Amazon.DatabaseMigrationService.DmsSslModeValue MySqlSettings_SslMode { get; set; }
            public System.String OracleSettings_AsmServer { get; set; }
            public System.String OracleSettings_CertificateArn { get; set; }
            public System.String OracleSettings_DatabaseName { get; set; }
            public System.Int32? OracleSettings_Port { get; set; }
            public System.String OracleSettings_SecretsManagerOracleAsmAccessRoleArn { get; set; }
            public System.String OracleSettings_SecretsManagerOracleAsmSecretId { get; set; }
            public System.String OracleSettings_SecretsManagerSecurityDbEncryptionAccessRoleArn { get; set; }
            public System.String OracleSettings_SecretsManagerSecurityDbEncryptionSecretId { get; set; }
            public System.String OracleSettings_ServerName { get; set; }
            public Amazon.DatabaseMigrationService.DmsSslModeValue OracleSettings_SslMode { get; set; }
            public System.String PostgreSqlSettings_CertificateArn { get; set; }
            public System.String PostgreSqlSettings_DatabaseName { get; set; }
            public System.Int32? PostgreSqlSettings_Port { get; set; }
            public System.String PostgreSqlSettings_ServerName { get; set; }
            public Amazon.DatabaseMigrationService.DmsSslModeValue PostgreSqlSettings_SslMode { get; set; }
            public System.String RedshiftSettings_DatabaseName { get; set; }
            public System.Int32? RedshiftSettings_Port { get; set; }
            public System.String RedshiftSettings_ServerName { get; set; }
            public List<Amazon.DatabaseMigrationService.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.DatabaseMigrationService.Model.CreateDataProviderResponse, NewDMSDataProviderCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DataProvider;
        }
        
    }
}
