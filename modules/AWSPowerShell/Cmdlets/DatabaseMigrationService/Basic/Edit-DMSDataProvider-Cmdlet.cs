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
    /// Modifies the specified data provider using the provided settings.
    /// 
    ///  <note><para>
    /// You must remove the data provider from all migration projects before you can modify
    /// it.
    /// </para></note>
    /// </summary>
    [Cmdlet("Edit", "DMSDataProvider", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DatabaseMigrationService.Model.DataProvider")]
    [AWSCmdlet("Calls the AWS Database Migration Service ModifyDataProvider API operation.", Operation = new[] {"ModifyDataProvider"}, SelectReturnType = typeof(Amazon.DatabaseMigrationService.Model.ModifyDataProviderResponse))]
    [AWSCmdletOutput("Amazon.DatabaseMigrationService.Model.DataProvider or Amazon.DatabaseMigrationService.Model.ModifyDataProviderResponse",
        "This cmdlet returns an Amazon.DatabaseMigrationService.Model.DataProvider object.",
        "The service call response (type Amazon.DatabaseMigrationService.Model.ModifyDataProviderResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EditDMSDataProviderCmdlet : AmazonDatabaseMigrationServiceClientCmdlet, IExecutor
    {
        
        #region Parameter OracleSettings_AsmServer
        /// <summary>
        /// <para>
        /// <para>The address of your Oracle Automatic Storage Management (ASM) server. You can set
        /// this value from the <code>asm_server</code> value. You set <code>asm_server</code>
        /// as part of the extra connection attribute string to access an Oracle server with Binary
        /// Reader that uses ASM. For more information, see <a href="https://docs.aws.amazon.com/dms/latest/userguide/CHAP_Source.Oracle.html#dms/latest/userguide/CHAP_Source.Oracle.html#CHAP_Source.Oracle.CDC.Configuration">Configuration
        /// for change data capture (CDC) on an Oracle source database</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings_OracleSettings_AsmServer")]
        public System.String OracleSettings_AsmServer { get; set; }
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
        
        #region Parameter DataProviderIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the data provider. Identifiers must begin with a letter and must
        /// contain only ASCII letters, digits, and hyphens. They can't end with a hyphen, or
        /// contain two consecutive hyphens.</para>
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
        public System.String DataProviderIdentifier { get; set; }
        #endregion
        
        #region Parameter DataProviderName
        /// <summary>
        /// <para>
        /// <para>The name of the data provider.</para>
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
        /// <para>The type of database engine for the data provider. Valid values include <code>"aurora"</code>,
        /// <code>"aurora_postgresql"</code>, <code>"mysql"</code>, <code>"oracle"</code>, <code>"postgres"</code>,
        /// and <code>"sqlserver"</code>. A value of <code>"aurora"</code> represents Amazon Aurora
        /// MySQL-Compatible Edition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Engine { get; set; }
        #endregion
        
        #region Parameter ExactSetting
        /// <summary>
        /// <para>
        /// <para>If this attribute is Y, the current call to <code>ModifyDataProvider</code> replaces
        /// all existing data provider settings with the exact settings that you specify in this
        /// call. If this attribute is N, the current call to <code>ModifyDataProvider</code>
        /// does two things: </para><ul><li><para>It replaces any data provider settings that already exist with new values, for settings
        /// with the same names.</para></li><li><para>It creates new data provider settings that you specify in the call, for settings with
        /// different names. </para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExactSettings")]
        public System.Boolean? ExactSetting { get; set; }
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
        
        #region Parameter MicrosoftSqlServerSettings_SslMode
        /// <summary>
        /// <para>
        /// <para>The SSL mode used to connect to the Microsoft SQL Server data provider. The default
        /// value is <code>none</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings_MicrosoftSqlServerSettings_SslMode")]
        [AWSConstantClassSource("Amazon.DatabaseMigrationService.DmsSslModeValue")]
        public Amazon.DatabaseMigrationService.DmsSslModeValue MicrosoftSqlServerSettings_SslMode { get; set; }
        #endregion
        
        #region Parameter MySqlSettings_SslMode
        /// <summary>
        /// <para>
        /// <para>The SSL mode used to connect to the MySQL data provider. The default value is <code>none</code>.</para>
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
        /// <para>The SSL mode used to connect to the Oracle data provider. The default value is <code>none</code>.</para>
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
        /// <code>none</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings_PostgreSqlSettings_SslMode")]
        [AWSConstantClassSource("Amazon.DatabaseMigrationService.DmsSslModeValue")]
        public Amazon.DatabaseMigrationService.DmsSslModeValue PostgreSqlSettings_SslMode { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DataProvider'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DatabaseMigrationService.Model.ModifyDataProviderResponse).
        /// Specifying the name of a property of type Amazon.DatabaseMigrationService.Model.ModifyDataProviderResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DataProvider";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DataProviderIdentifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DataProviderIdentifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DataProviderIdentifier' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DataProviderIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-DMSDataProvider (ModifyDataProvider)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DatabaseMigrationService.Model.ModifyDataProviderResponse, EditDMSDataProviderCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DataProviderIdentifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DataProviderIdentifier = this.DataProviderIdentifier;
            #if MODULAR
            if (this.DataProviderIdentifier == null && ParameterWasBound(nameof(this.DataProviderIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter DataProviderIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DataProviderName = this.DataProviderName;
            context.Description = this.Description;
            context.Engine = this.Engine;
            context.ExactSetting = this.ExactSetting;
            context.MicrosoftSqlServerSettings_CertificateArn = this.MicrosoftSqlServerSettings_CertificateArn;
            context.MicrosoftSqlServerSettings_DatabaseName = this.MicrosoftSqlServerSettings_DatabaseName;
            context.MicrosoftSqlServerSettings_Port = this.MicrosoftSqlServerSettings_Port;
            context.MicrosoftSqlServerSettings_ServerName = this.MicrosoftSqlServerSettings_ServerName;
            context.MicrosoftSqlServerSettings_SslMode = this.MicrosoftSqlServerSettings_SslMode;
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
            var request = new Amazon.DatabaseMigrationService.Model.ModifyDataProviderRequest();
            
            if (cmdletContext.DataProviderIdentifier != null)
            {
                request.DataProviderIdentifier = cmdletContext.DataProviderIdentifier;
            }
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
            if (cmdletContext.ExactSetting != null)
            {
                request.ExactSettings = cmdletContext.ExactSetting.Value;
            }
            
             // populate Settings
            var requestSettingsIsNull = true;
            request.Settings = new Amazon.DatabaseMigrationService.Model.DataProviderSettings();
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
        
        private Amazon.DatabaseMigrationService.Model.ModifyDataProviderResponse CallAWSServiceOperation(IAmazonDatabaseMigrationService client, Amazon.DatabaseMigrationService.Model.ModifyDataProviderRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Database Migration Service", "ModifyDataProvider");
            try
            {
                #if DESKTOP
                return client.ModifyDataProvider(request);
                #elif CORECLR
                return client.ModifyDataProviderAsync(request).GetAwaiter().GetResult();
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
            public System.String DataProviderIdentifier { get; set; }
            public System.String DataProviderName { get; set; }
            public System.String Description { get; set; }
            public System.String Engine { get; set; }
            public System.Boolean? ExactSetting { get; set; }
            public System.String MicrosoftSqlServerSettings_CertificateArn { get; set; }
            public System.String MicrosoftSqlServerSettings_DatabaseName { get; set; }
            public System.Int32? MicrosoftSqlServerSettings_Port { get; set; }
            public System.String MicrosoftSqlServerSettings_ServerName { get; set; }
            public Amazon.DatabaseMigrationService.DmsSslModeValue MicrosoftSqlServerSettings_SslMode { get; set; }
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
            public System.Func<Amazon.DatabaseMigrationService.Model.ModifyDataProviderResponse, EditDMSDataProviderCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DataProvider;
        }
        
    }
}
