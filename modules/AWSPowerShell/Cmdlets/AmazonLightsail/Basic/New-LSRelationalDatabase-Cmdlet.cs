/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.Lightsail;
using Amazon.Lightsail.Model;

namespace Amazon.PowerShell.Cmdlets.LS
{
    /// <summary>
    /// Creates a new database in Amazon Lightsail.
    /// </summary>
    [Cmdlet("New", "LSRelationalDatabase", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Lightsail.Model.Operation")]
    [AWSCmdlet("Calls the Amazon Lightsail CreateRelationalDatabase API operation.", Operation = new[] {"CreateRelationalDatabase"})]
    [AWSCmdletOutput("Amazon.Lightsail.Model.Operation",
        "This cmdlet returns a collection of Operation objects.",
        "The service call response (type Amazon.Lightsail.Model.CreateRelationalDatabaseResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewLSRelationalDatabaseCmdlet : AmazonLightsailClientCmdlet, IExecutor
    {
        
        #region Parameter AvailabilityZone
        /// <summary>
        /// <para>
        /// <para>The Availability Zone in which to create your new database. Use the <code>us-east-2a</code>
        /// case-sensitive format.</para><para>You can get a list of Availability Zones by using the <code>get regions</code> operation.
        /// Be sure to add the <code>include relational database Availability Zones</code> parameter
        /// to your request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AvailabilityZone { get; set; }
        #endregion
        
        #region Parameter MasterDatabaseName
        /// <summary>
        /// <para>
        /// <para>The name of the master database created when the Lightsail database resource is created.</para><para>Constraints:</para><ul><li><para>Must contain from 1 to 64 alphanumeric characters.</para></li><li><para>Cannot be a word reserved by the specified database engine</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String MasterDatabaseName { get; set; }
        #endregion
        
        #region Parameter MasterUsername
        /// <summary>
        /// <para>
        /// <para>The master user name for your new database.</para><para>Constraints:</para><ul><li><para>Master user name is required.</para></li><li><para>Must contain from 1 to 16 alphanumeric characters.</para></li><li><para>The first character must be a letter.</para></li><li><para>Cannot be a reserved word for the database engine you choose.</para><para>For more information about reserved words in MySQL 5.6 or 5.7, see the Keywords and
        /// Reserved Words articles for <a href="https://dev.mysql.com/doc/refman/5.6/en/keywords.html">MySQL
        /// 5.6</a> or <a href="https://dev.mysql.com/doc/refman/5.7/en/keywords.html">MySQL 5.7</a>
        /// respectively.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String MasterUsername { get; set; }
        #endregion
        
        #region Parameter MasterUserPassword
        /// <summary>
        /// <para>
        /// <para>The password for the master user of your new database. The password can include any
        /// printable ASCII character except "/", """, or "@".</para><para>Constraints: Must contain 8 to 41 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String MasterUserPassword { get; set; }
        #endregion
        
        #region Parameter PreferredBackupWindow
        /// <summary>
        /// <para>
        /// <para>The daily time range during which automated backups are created for your new database
        /// if automated backups are enabled.</para><para>The default is a 30-minute window selected at random from an 8-hour block of time
        /// for each AWS Region. For more information about the preferred backup window time blocks
        /// for each region, see the <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/USER_WorkingWithAutomatedBackups.html#USER_WorkingWithAutomatedBackups.BackupWindow">Working
        /// With Backups</a> guide in the Amazon Relational Database Service (Amazon RDS) documentation.</para><para>Constraints:</para><ul><li><para>Must be in the <code>hh24:mi-hh24:mi</code> format.</para><para>Example: <code>16:00-16:30</code></para></li><li><para>Specified in Universal Coordinated Time (UTC).</para></li><li><para>Must not conflict with the preferred maintenance window.</para></li><li><para>Must be at least 30 minutes.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String PreferredBackupWindow { get; set; }
        #endregion
        
        #region Parameter PreferredMaintenanceWindow
        /// <summary>
        /// <para>
        /// <para>The weekly time range during which system maintenance can occur on your new database.</para><para>The default is a 30-minute window selected at random from an 8-hour block of time
        /// for each AWS Region, occurring on a random day of the week.</para><para>Constraints:</para><ul><li><para>Must be in the <code>ddd:hh24:mi-ddd:hh24:mi</code> format.</para></li><li><para>Valid days: Mon, Tue, Wed, Thu, Fri, Sat, Sun.</para></li><li><para>Must be at least 30 minutes.</para></li><li><para>Specified in Universal Coordinated Time (UTC).</para></li><li><para>Example: <code>Tue:17:00-Tue:17:30</code></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String PreferredMaintenanceWindow { get; set; }
        #endregion
        
        #region Parameter PubliclyAccessible
        /// <summary>
        /// <para>
        /// <para>Specifies the accessibility options for your new database. A value of <code>true</code>
        /// specifies a database that is available to resources outside of your Lightsail account.
        /// A value of <code>false</code> specifies a database that is available only to your
        /// Lightsail resources in the same region as your database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean PubliclyAccessible { get; set; }
        #endregion
        
        #region Parameter RelationalDatabaseBlueprintId
        /// <summary>
        /// <para>
        /// <para>The blueprint ID for your new database. A blueprint describes the major engine version
        /// of a database.</para><para>You can get a list of database blueprints IDs by using the <code>get relational database
        /// blueprints</code> operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RelationalDatabaseBlueprintId { get; set; }
        #endregion
        
        #region Parameter RelationalDatabaseBundleId
        /// <summary>
        /// <para>
        /// <para>The bundle ID for your new database. A bundle describes the performance specifications
        /// for your database.</para><para>You can get a list of database bundle IDs by using the <code>get relational database
        /// bundles</code> operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RelationalDatabaseBundleId { get; set; }
        #endregion
        
        #region Parameter RelationalDatabaseName
        /// <summary>
        /// <para>
        /// <para>The name to use for your new database.</para><para>Constraints:</para><ul><li><para>Must contain from 2 to 255 alphanumeric characters, or hyphens.</para></li><li><para>The first and last character must be a letter or number.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String RelationalDatabaseName { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("RelationalDatabaseName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-LSRelationalDatabase (CreateRelationalDatabase)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.AvailabilityZone = this.AvailabilityZone;
            context.MasterDatabaseName = this.MasterDatabaseName;
            context.MasterUsername = this.MasterUsername;
            context.MasterUserPassword = this.MasterUserPassword;
            context.PreferredBackupWindow = this.PreferredBackupWindow;
            context.PreferredMaintenanceWindow = this.PreferredMaintenanceWindow;
            if (ParameterWasBound("PubliclyAccessible"))
                context.PubliclyAccessible = this.PubliclyAccessible;
            context.RelationalDatabaseBlueprintId = this.RelationalDatabaseBlueprintId;
            context.RelationalDatabaseBundleId = this.RelationalDatabaseBundleId;
            context.RelationalDatabaseName = this.RelationalDatabaseName;
            
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
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Operations;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
                #if DESKTOP
                return client.CreateRelationalDatabase(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateRelationalDatabaseAsync(request);
                return task.Result;
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
        }
        
    }
}
