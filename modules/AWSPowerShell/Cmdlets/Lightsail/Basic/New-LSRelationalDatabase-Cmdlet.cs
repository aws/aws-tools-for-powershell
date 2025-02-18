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
using Amazon.Lightsail;
using Amazon.Lightsail.Model;

namespace Amazon.PowerShell.Cmdlets.LS
{
    /// <summary>
    /// Creates a new database in Amazon Lightsail.
    /// 
    ///  
    /// <para>
    /// The <c>create relational database</c> operation supports tag-based access control
    /// via request tags. For more information, see the <a href="https://lightsail.aws.amazon.com/ls/docs/en_us/articles/amazon-lightsail-controlling-access-using-tags">Amazon
    /// Lightsail Developer Guide</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "LSRelationalDatabase", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Lightsail.Model.Operation")]
    [AWSCmdlet("Calls the Amazon Lightsail CreateRelationalDatabase API operation.", Operation = new[] {"CreateRelationalDatabase"}, SelectReturnType = typeof(Amazon.Lightsail.Model.CreateRelationalDatabaseResponse))]
    [AWSCmdletOutput("Amazon.Lightsail.Model.Operation or Amazon.Lightsail.Model.CreateRelationalDatabaseResponse",
        "This cmdlet returns a collection of Amazon.Lightsail.Model.Operation objects.",
        "The service call response (type Amazon.Lightsail.Model.CreateRelationalDatabaseResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewLSRelationalDatabaseCmdlet : AmazonLightsailClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AvailabilityZone
        /// <summary>
        /// <para>
        /// <para>The Availability Zone in which to create your new database. Use the <c>us-east-2a</c>
        /// case-sensitive format.</para><para>You can get a list of Availability Zones by using the <c>get regions</c> operation.
        /// Be sure to add the <c>include relational database Availability Zones</c> parameter
        /// to your request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AvailabilityZone { get; set; }
        #endregion
        
        #region Parameter MasterDatabaseName
        /// <summary>
        /// <para>
        /// <para>The meaning of this parameter differs according to the database engine you use.</para><para><b>MySQL</b></para><para>The name of the database to create when the Lightsail database resource is created.
        /// If this parameter isn't specified, no database is created in the database resource.</para><para>Constraints:</para><ul><li><para>Must contain 1 to 64 letters or numbers.</para></li><li><para>Must begin with a letter. Subsequent characters can be letters, underscores, or digits
        /// (0- 9).</para></li><li><para>Can't be a word reserved by the specified database engine.</para><para>For more information about reserved words in MySQL, see the Keywords and Reserved
        /// Words articles for <a href="https://dev.mysql.com/doc/refman/5.6/en/keywords.html">MySQL
        /// 5.6</a>, <a href="https://dev.mysql.com/doc/refman/5.7/en/keywords.html">MySQL 5.7</a>,
        /// and <a href="https://dev.mysql.com/doc/refman/8.0/en/keywords.html">MySQL 8.0</a>.</para></li></ul><para><b>PostgreSQL</b></para><para>The name of the database to create when the Lightsail database resource is created.
        /// If this parameter isn't specified, a database named <c>postgres</c> is created in
        /// the database resource.</para><para>Constraints:</para><ul><li><para>Must contain 1 to 63 letters or numbers.</para></li><li><para>Must begin with a letter. Subsequent characters can be letters, underscores, or digits
        /// (0- 9).</para></li><li><para>Can't be a word reserved by the specified database engine.</para><para>For more information about reserved words in PostgreSQL, see the SQL Key Words articles
        /// for <a href="https://www.postgresql.org/docs/9.6/sql-keywords-appendix.html">PostgreSQL
        /// 9.6</a>, <a href="https://www.postgresql.org/docs/10/sql-keywords-appendix.html">PostgreSQL
        /// 10</a>, <a href="https://www.postgresql.org/docs/11/sql-keywords-appendix.html">PostgreSQL
        /// 11</a>, and <a href="https://www.postgresql.org/docs/12/sql-keywords-appendix.html">PostgreSQL
        /// 12</a>.</para></li></ul>
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
        public System.String MasterDatabaseName { get; set; }
        #endregion
        
        #region Parameter MasterUsername
        /// <summary>
        /// <para>
        /// <para>The name for the master user.</para><para><b>MySQL</b></para><para>Constraints:</para><ul><li><para>Required for MySQL.</para></li><li><para>Must be 1 to 16 letters or numbers. Can contain underscores.</para></li><li><para>First character must be a letter.</para></li><li><para>Can't be a reserved word for the chosen database engine.</para><para>For more information about reserved words in MySQL 5.6 or 5.7, see the Keywords and
        /// Reserved Words articles for <a href="https://dev.mysql.com/doc/refman/5.6/en/keywords.html">MySQL
        /// 5.6</a>, <a href="https://dev.mysql.com/doc/refman/5.7/en/keywords.html">MySQL 5.7</a>,
        /// or <a href="https://dev.mysql.com/doc/refman/8.0/en/keywords.html">MySQL 8.0</a>.</para></li></ul><para><b>PostgreSQL</b></para><para>Constraints:</para><ul><li><para>Required for PostgreSQL.</para></li><li><para>Must be 1 to 63 letters or numbers. Can contain underscores.</para></li><li><para>First character must be a letter.</para></li><li><para>Can't be a reserved word for the chosen database engine.</para><para>For more information about reserved words in MySQL 5.6 or 5.7, see the Keywords and
        /// Reserved Words articles for <a href="https://www.postgresql.org/docs/9.6/sql-keywords-appendix.html">PostgreSQL
        /// 9.6</a>, <a href="https://www.postgresql.org/docs/10/sql-keywords-appendix.html">PostgreSQL
        /// 10</a>, <a href="https://www.postgresql.org/docs/11/sql-keywords-appendix.html">PostgreSQL
        /// 11</a>, and <a href="https://www.postgresql.org/docs/12/sql-keywords-appendix.html">PostgreSQL
        /// 12</a>.</para></li></ul>
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
        public System.String MasterUsername { get; set; }
        #endregion
        
        #region Parameter MasterUserPassword
        /// <summary>
        /// <para>
        /// <para>The password for the master user. The password can include any printable ASCII character
        /// except "/", """, or "@". It cannot contain spaces.</para><para><b>MySQL</b></para><para>Constraints: Must contain from 8 to 41 characters.</para><para><b>PostgreSQL</b></para><para>Constraints: Must contain from 8 to 128 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MasterUserPassword { get; set; }
        #endregion
        
        #region Parameter PreferredBackupWindow
        /// <summary>
        /// <para>
        /// <para>The daily time range during which automated backups are created for your new database
        /// if automated backups are enabled.</para><para>The default is a 30-minute window selected at random from an 8-hour block of time
        /// for each AWS Region. For more information about the preferred backup window time blocks
        /// for each region, see the <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/USER_WorkingWithAutomatedBackups.html#USER_WorkingWithAutomatedBackups.BackupWindow">Working
        /// With Backups</a> guide in the Amazon Relational Database Service documentation.</para><para>Constraints:</para><ul><li><para>Must be in the <c>hh24:mi-hh24:mi</c> format.</para><para>Example: <c>16:00-16:30</c></para></li><li><para>Specified in Coordinated Universal Time (UTC).</para></li><li><para>Must not conflict with the preferred maintenance window.</para></li><li><para>Must be at least 30 minutes.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PreferredBackupWindow { get; set; }
        #endregion
        
        #region Parameter PreferredMaintenanceWindow
        /// <summary>
        /// <para>
        /// <para>The weekly time range during which system maintenance can occur on your new database.</para><para>The default is a 30-minute window selected at random from an 8-hour block of time
        /// for each AWS Region, occurring on a random day of the week.</para><para>Constraints:</para><ul><li><para>Must be in the <c>ddd:hh24:mi-ddd:hh24:mi</c> format.</para></li><li><para>Valid days: Mon, Tue, Wed, Thu, Fri, Sat, Sun.</para></li><li><para>Must be at least 30 minutes.</para></li><li><para>Specified in Coordinated Universal Time (UTC).</para></li><li><para>Example: <c>Tue:17:00-Tue:17:30</c></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PreferredMaintenanceWindow { get; set; }
        #endregion
        
        #region Parameter PubliclyAccessible
        /// <summary>
        /// <para>
        /// <para>Specifies the accessibility options for your new database. A value of <c>true</c>
        /// specifies a database that is available to resources outside of your Lightsail account.
        /// A value of <c>false</c> specifies a database that is available only to your Lightsail
        /// resources in the same region as your database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? PubliclyAccessible { get; set; }
        #endregion
        
        #region Parameter RelationalDatabaseBlueprintId
        /// <summary>
        /// <para>
        /// <para>The blueprint ID for your new database. A blueprint describes the major engine version
        /// of a database.</para><para>You can get a list of database blueprints IDs by using the <c>get relational database
        /// blueprints</c> operation.</para>
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
        public System.String RelationalDatabaseBlueprintId { get; set; }
        #endregion
        
        #region Parameter RelationalDatabaseBundleId
        /// <summary>
        /// <para>
        /// <para>The bundle ID for your new database. A bundle describes the performance specifications
        /// for your database.</para><para>You can get a list of database bundle IDs by using the <c>get relational database
        /// bundles</c> operation.</para>
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
        public System.String RelationalDatabaseBundleId { get; set; }
        #endregion
        
        #region Parameter RelationalDatabaseName
        /// <summary>
        /// <para>
        /// <para>The name to use for your new Lightsail database resource.</para><para>Constraints:</para><ul><li><para>Must contain from 2 to 255 alphanumeric characters, or hyphens.</para></li><li><para>The first and last character must be a letter or number.</para></li></ul>
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
        public System.String RelationalDatabaseName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tag keys and optional values to add to the resource during create.</para><para>Use the <c>TagResource</c> action to tag a resource after it's created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.Lightsail.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Operations'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Lightsail.Model.CreateRelationalDatabaseResponse).
        /// Specifying the name of a property of type Amazon.Lightsail.Model.CreateRelationalDatabaseResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Operations";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RelationalDatabaseName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-LSRelationalDatabase (CreateRelationalDatabase)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Lightsail.Model.CreateRelationalDatabaseResponse, NewLSRelationalDatabaseCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AvailabilityZone = this.AvailabilityZone;
            context.MasterDatabaseName = this.MasterDatabaseName;
            #if MODULAR
            if (this.MasterDatabaseName == null && ParameterWasBound(nameof(this.MasterDatabaseName)))
            {
                WriteWarning("You are passing $null as a value for parameter MasterDatabaseName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MasterUsername = this.MasterUsername;
            #if MODULAR
            if (this.MasterUsername == null && ParameterWasBound(nameof(this.MasterUsername)))
            {
                WriteWarning("You are passing $null as a value for parameter MasterUsername which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MasterUserPassword = this.MasterUserPassword;
            context.PreferredBackupWindow = this.PreferredBackupWindow;
            context.PreferredMaintenanceWindow = this.PreferredMaintenanceWindow;
            context.PubliclyAccessible = this.PubliclyAccessible;
            context.RelationalDatabaseBlueprintId = this.RelationalDatabaseBlueprintId;
            #if MODULAR
            if (this.RelationalDatabaseBlueprintId == null && ParameterWasBound(nameof(this.RelationalDatabaseBlueprintId)))
            {
                WriteWarning("You are passing $null as a value for parameter RelationalDatabaseBlueprintId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RelationalDatabaseBundleId = this.RelationalDatabaseBundleId;
            #if MODULAR
            if (this.RelationalDatabaseBundleId == null && ParameterWasBound(nameof(this.RelationalDatabaseBundleId)))
            {
                WriteWarning("You are passing $null as a value for parameter RelationalDatabaseBundleId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RelationalDatabaseName = this.RelationalDatabaseName;
            #if MODULAR
            if (this.RelationalDatabaseName == null && ParameterWasBound(nameof(this.RelationalDatabaseName)))
            {
                WriteWarning("You are passing $null as a value for parameter RelationalDatabaseName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.Lightsail.Model.Tag>(this.Tag);
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
            var request = new Amazon.Lightsail.Model.CreateRelationalDatabaseRequest();
            
            if (cmdletContext.AvailabilityZone != null)
            {
                request.AvailabilityZone = cmdletContext.AvailabilityZone;
            }
            if (cmdletContext.MasterDatabaseName != null)
            {
                request.MasterDatabaseName = cmdletContext.MasterDatabaseName;
            }
            if (cmdletContext.MasterUsername != null)
            {
                request.MasterUsername = cmdletContext.MasterUsername;
            }
            if (cmdletContext.MasterUserPassword != null)
            {
                request.MasterUserPassword = cmdletContext.MasterUserPassword;
            }
            if (cmdletContext.PreferredBackupWindow != null)
            {
                request.PreferredBackupWindow = cmdletContext.PreferredBackupWindow;
            }
            if (cmdletContext.PreferredMaintenanceWindow != null)
            {
                request.PreferredMaintenanceWindow = cmdletContext.PreferredMaintenanceWindow;
            }
            if (cmdletContext.PubliclyAccessible != null)
            {
                request.PubliclyAccessible = cmdletContext.PubliclyAccessible.Value;
            }
            if (cmdletContext.RelationalDatabaseBlueprintId != null)
            {
                request.RelationalDatabaseBlueprintId = cmdletContext.RelationalDatabaseBlueprintId;
            }
            if (cmdletContext.RelationalDatabaseBundleId != null)
            {
                request.RelationalDatabaseBundleId = cmdletContext.RelationalDatabaseBundleId;
            }
            if (cmdletContext.RelationalDatabaseName != null)
            {
                request.RelationalDatabaseName = cmdletContext.RelationalDatabaseName;
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
        
        private Amazon.Lightsail.Model.CreateRelationalDatabaseResponse CallAWSServiceOperation(IAmazonLightsail client, Amazon.Lightsail.Model.CreateRelationalDatabaseRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lightsail", "CreateRelationalDatabase");
            try
            {
                return client.CreateRelationalDatabaseAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AvailabilityZone { get; set; }
            public System.String MasterDatabaseName { get; set; }
            public System.String MasterUsername { get; set; }
            public System.String MasterUserPassword { get; set; }
            public System.String PreferredBackupWindow { get; set; }
            public System.String PreferredMaintenanceWindow { get; set; }
            public System.Boolean? PubliclyAccessible { get; set; }
            public System.String RelationalDatabaseBlueprintId { get; set; }
            public System.String RelationalDatabaseBundleId { get; set; }
            public System.String RelationalDatabaseName { get; set; }
            public List<Amazon.Lightsail.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.Lightsail.Model.CreateRelationalDatabaseResponse, NewLSRelationalDatabaseCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Operations;
        }
        
    }
}
