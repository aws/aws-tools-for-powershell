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
    /// Allows the update of one or more attributes of a database in Amazon Lightsail.
    /// 
    ///  
    /// <para>
    /// Updates are applied immediately, or in cases where the updates could result in an
    /// outage, are applied during the database's predefined maintenance window.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "LSRelationalDatabase", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Lightsail.Model.Operation")]
    [AWSCmdlet("Calls the Amazon Lightsail UpdateRelationalDatabase API operation.", Operation = new[] {"UpdateRelationalDatabase"})]
    [AWSCmdletOutput("Amazon.Lightsail.Model.Operation",
        "This cmdlet returns a collection of Operation objects.",
        "The service call response (type Amazon.Lightsail.Model.UpdateRelationalDatabaseResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateLSRelationalDatabaseCmdlet : AmazonLightsailClientCmdlet, IExecutor
    {
        
        #region Parameter ApplyImmediately
        /// <summary>
        /// <para>
        /// <para>When <code>true</code>, applies changes immediately. When <code>false</code>, applies
        /// changes during the preferred maintenance window. Some changes may cause an outage.</para><para>Default: <code>false</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean ApplyImmediately { get; set; }
        #endregion
        
        #region Parameter DisableBackupRetention
        /// <summary>
        /// <para>
        /// <para>When <code>true</code>, disables automated backup retention for your database.</para><para>Disabling backup retention deletes all automated database backups. Before disabling
        /// this, you may want to create a snapshot of your database using the <code>create relational
        /// database snapshot</code> operation.</para><para>Updates are applied during the next maintenance window because this can result in
        /// an outage.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean DisableBackupRetention { get; set; }
        #endregion
        
        #region Parameter EnableBackupRetention
        /// <summary>
        /// <para>
        /// <para>When <code>true</code>, enables automated backup retention for your database.</para><para>Updates are applied during the next maintenance window because this can result in
        /// an outage.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean EnableBackupRetention { get; set; }
        #endregion
        
        #region Parameter MasterUserPassword
        /// <summary>
        /// <para>
        /// <para>The password for the master user of your database. The password can include any printable
        /// ASCII character except "/", """, or "@".</para><para>Constraints: Must contain 8 to 41 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String MasterUserPassword { get; set; }
        #endregion
        
        #region Parameter PreferredBackupWindow
        /// <summary>
        /// <para>
        /// <para>The daily time range during which automated backups are created for your database
        /// if automated backups are enabled.</para><para>Constraints:</para><ul><li><para>Must be in the <code>hh24:mi-hh24:mi</code> format.</para><para>Example: <code>16:00-16:30</code></para></li><li><para>Specified in Universal Coordinated Time (UTC).</para></li><li><para>Must not conflict with the preferred maintenance window.</para></li><li><para>Must be at least 30 minutes.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String PreferredBackupWindow { get; set; }
        #endregion
        
        #region Parameter PreferredMaintenanceWindow
        /// <summary>
        /// <para>
        /// <para>The weekly time range during which system maintenance can occur on your database.</para><para>The default is a 30-minute window selected at random from an 8-hour block of time
        /// for each AWS Region, occurring on a random day of the week.</para><para>Constraints:</para><ul><li><para>Must be in the <code>ddd:hh24:mi-ddd:hh24:mi</code> format.</para></li><li><para>Valid days: Mon, Tue, Wed, Thu, Fri, Sat, Sun.</para></li><li><para>Must be at least 30 minutes.</para></li><li><para>Specified in Universal Coordinated Time (UTC).</para></li><li><para>Example: <code>Tue:17:00-Tue:17:30</code></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String PreferredMaintenanceWindow { get; set; }
        #endregion
        
        #region Parameter PubliclyAccessible
        /// <summary>
        /// <para>
        /// <para>Specifies the accessibility options for your database. A value of <code>true</code>
        /// specifies a database that is available to resources outside of your Lightsail account.
        /// A value of <code>false</code> specifies a database that is available only to your
        /// Lightsail resources in the same region as your database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean PubliclyAccessible { get; set; }
        #endregion
        
        #region Parameter RelationalDatabaseName
        /// <summary>
        /// <para>
        /// <para>The name of your database to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String RelationalDatabaseName { get; set; }
        #endregion
        
        #region Parameter RotateMasterUserPassword
        /// <summary>
        /// <para>
        /// <para>When <code>true</code>, the master user password is changed to a new strong password
        /// generated by Lightsail.</para><para>Use the <code>get relational database master user password</code> operation to get
        /// the new password.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean RotateMasterUserPassword { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-LSRelationalDatabase (UpdateRelationalDatabase)"))
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
            
            if (ParameterWasBound("ApplyImmediately"))
                context.ApplyImmediately = this.ApplyImmediately;
            if (ParameterWasBound("DisableBackupRetention"))
                context.DisableBackupRetention = this.DisableBackupRetention;
            if (ParameterWasBound("EnableBackupRetention"))
                context.EnableBackupRetention = this.EnableBackupRetention;
            context.MasterUserPassword = this.MasterUserPassword;
            context.PreferredBackupWindow = this.PreferredBackupWindow;
            context.PreferredMaintenanceWindow = this.PreferredMaintenanceWindow;
            if (ParameterWasBound("PubliclyAccessible"))
                context.PubliclyAccessible = this.PubliclyAccessible;
            context.RelationalDatabaseName = this.RelationalDatabaseName;
            if (ParameterWasBound("RotateMasterUserPassword"))
                context.RotateMasterUserPassword = this.RotateMasterUserPassword;
            
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
            var request = new Amazon.Lightsail.Model.UpdateRelationalDatabaseRequest();
            
            if (cmdletContext.ApplyImmediately != null)
            {
                request.ApplyImmediately = cmdletContext.ApplyImmediately.Value;
            }
            if (cmdletContext.DisableBackupRetention != null)
            {
                request.DisableBackupRetention = cmdletContext.DisableBackupRetention.Value;
            }
            if (cmdletContext.EnableBackupRetention != null)
            {
                request.EnableBackupRetention = cmdletContext.EnableBackupRetention.Value;
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
            if (cmdletContext.RelationalDatabaseName != null)
            {
                request.RelationalDatabaseName = cmdletContext.RelationalDatabaseName;
            }
            if (cmdletContext.RotateMasterUserPassword != null)
            {
                request.RotateMasterUserPassword = cmdletContext.RotateMasterUserPassword.Value;
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
        
        private Amazon.Lightsail.Model.UpdateRelationalDatabaseResponse CallAWSServiceOperation(IAmazonLightsail client, Amazon.Lightsail.Model.UpdateRelationalDatabaseRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lightsail", "UpdateRelationalDatabase");
            try
            {
                #if DESKTOP
                return client.UpdateRelationalDatabase(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.UpdateRelationalDatabaseAsync(request);
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
            public System.Boolean? ApplyImmediately { get; set; }
            public System.Boolean? DisableBackupRetention { get; set; }
            public System.Boolean? EnableBackupRetention { get; set; }
            public System.String MasterUserPassword { get; set; }
            public System.String PreferredBackupWindow { get; set; }
            public System.String PreferredMaintenanceWindow { get; set; }
            public System.Boolean? PubliclyAccessible { get; set; }
            public System.String RelationalDatabaseName { get; set; }
            public System.Boolean? RotateMasterUserPassword { get; set; }
        }
        
    }
}
