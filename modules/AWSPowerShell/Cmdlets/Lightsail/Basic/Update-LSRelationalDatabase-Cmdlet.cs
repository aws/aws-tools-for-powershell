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
    /// </para><para>
    /// The <code>update relational database</code> operation supports tag-based access control
    /// via resource tags applied to the resource identified by relationalDatabaseName. For
    /// more information, see the <a href="https://lightsail.aws.amazon.com/ls/docs/en/articles/amazon-lightsail-controlling-access-using-tags">Lightsail
    /// Dev Guide</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "LSRelationalDatabase", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Lightsail.Model.Operation")]
    [AWSCmdlet("Calls the Amazon Lightsail UpdateRelationalDatabase API operation.", Operation = new[] {"UpdateRelationalDatabase"}, SelectReturnType = typeof(Amazon.Lightsail.Model.UpdateRelationalDatabaseResponse))]
    [AWSCmdletOutput("Amazon.Lightsail.Model.Operation or Amazon.Lightsail.Model.UpdateRelationalDatabaseResponse",
        "This cmdlet returns a collection of Amazon.Lightsail.Model.Operation objects.",
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ApplyImmediately { get; set; }
        #endregion
        
        #region Parameter CaCertificateIdentifier
        /// <summary>
        /// <para>
        /// <para>Indicates the certificate that needs to be associated with the database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CaCertificateIdentifier { get; set; }
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DisableBackupRetention { get; set; }
        #endregion
        
        #region Parameter EnableBackupRetention
        /// <summary>
        /// <para>
        /// <para>When <code>true</code>, enables automated backup retention for your database.</para><para>Updates are applied during the next maintenance window because this can result in
        /// an outage.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnableBackupRetention { get; set; }
        #endregion
        
        #region Parameter MasterUserPassword
        /// <summary>
        /// <para>
        /// <para>The password for the master user. The password can include any printable ASCII character
        /// except "/", """, or "@".</para><para>My<b>SQL</b></para><para>Constraints: Must contain from 8 to 41 characters.</para><para><b>PostgreSQL</b></para><para>Constraints: Must contain from 8 to 128 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MasterUserPassword { get; set; }
        #endregion
        
        #region Parameter PreferredBackupWindow
        /// <summary>
        /// <para>
        /// <para>The daily time range during which automated backups are created for your database
        /// if automated backups are enabled.</para><para>Constraints:</para><ul><li><para>Must be in the <code>hh24:mi-hh24:mi</code> format.</para><para>Example: <code>16:00-16:30</code></para></li><li><para>Specified in Coordinated Universal Time (UTC).</para></li><li><para>Must not conflict with the preferred maintenance window.</para></li><li><para>Must be at least 30 minutes.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PreferredBackupWindow { get; set; }
        #endregion
        
        #region Parameter PreferredMaintenanceWindow
        /// <summary>
        /// <para>
        /// <para>The weekly time range during which system maintenance can occur on your database.</para><para>The default is a 30-minute window selected at random from an 8-hour block of time
        /// for each AWS Region, occurring on a random day of the week.</para><para>Constraints:</para><ul><li><para>Must be in the <code>ddd:hh24:mi-ddd:hh24:mi</code> format.</para></li><li><para>Valid days: Mon, Tue, Wed, Thu, Fri, Sat, Sun.</para></li><li><para>Must be at least 30 minutes.</para></li><li><para>Specified in Coordinated Universal Time (UTC).</para></li><li><para>Example: <code>Tue:17:00-Tue:17:30</code></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? PubliclyAccessible { get; set; }
        #endregion
        
        #region Parameter RelationalDatabaseName
        /// <summary>
        /// <para>
        /// <para>The name of your Lightsail database resource to update.</para>
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
        
        #region Parameter RotateMasterUserPassword
        /// <summary>
        /// <para>
        /// <para>When <code>true</code>, the master user password is changed to a new strong password
        /// generated by Lightsail.</para><para>Use the <code>get relational database master user password</code> operation to get
        /// the new password.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? RotateMasterUserPassword { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Operations'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Lightsail.Model.UpdateRelationalDatabaseResponse).
        /// Specifying the name of a property of type Amazon.Lightsail.Model.UpdateRelationalDatabaseResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Operations";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the RelationalDatabaseName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^RelationalDatabaseName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^RelationalDatabaseName' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RelationalDatabaseName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-LSRelationalDatabase (UpdateRelationalDatabase)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Lightsail.Model.UpdateRelationalDatabaseResponse, UpdateLSRelationalDatabaseCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.RelationalDatabaseName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ApplyImmediately = this.ApplyImmediately;
            context.CaCertificateIdentifier = this.CaCertificateIdentifier;
            context.DisableBackupRetention = this.DisableBackupRetention;
            context.EnableBackupRetention = this.EnableBackupRetention;
            context.MasterUserPassword = this.MasterUserPassword;
            context.PreferredBackupWindow = this.PreferredBackupWindow;
            context.PreferredMaintenanceWindow = this.PreferredMaintenanceWindow;
            context.PubliclyAccessible = this.PubliclyAccessible;
            context.RelationalDatabaseName = this.RelationalDatabaseName;
            #if MODULAR
            if (this.RelationalDatabaseName == null && ParameterWasBound(nameof(this.RelationalDatabaseName)))
            {
                WriteWarning("You are passing $null as a value for parameter RelationalDatabaseName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            if (cmdletContext.CaCertificateIdentifier != null)
            {
                request.CaCertificateIdentifier = cmdletContext.CaCertificateIdentifier;
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
        
        private Amazon.Lightsail.Model.UpdateRelationalDatabaseResponse CallAWSServiceOperation(IAmazonLightsail client, Amazon.Lightsail.Model.UpdateRelationalDatabaseRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lightsail", "UpdateRelationalDatabase");
            try
            {
                #if DESKTOP
                return client.UpdateRelationalDatabase(request);
                #elif CORECLR
                return client.UpdateRelationalDatabaseAsync(request).GetAwaiter().GetResult();
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
            public System.String CaCertificateIdentifier { get; set; }
            public System.Boolean? DisableBackupRetention { get; set; }
            public System.Boolean? EnableBackupRetention { get; set; }
            public System.String MasterUserPassword { get; set; }
            public System.String PreferredBackupWindow { get; set; }
            public System.String PreferredMaintenanceWindow { get; set; }
            public System.Boolean? PubliclyAccessible { get; set; }
            public System.String RelationalDatabaseName { get; set; }
            public System.Boolean? RotateMasterUserPassword { get; set; }
            public System.Func<Amazon.Lightsail.Model.UpdateRelationalDatabaseResponse, UpdateLSRelationalDatabaseCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Operations;
        }
        
    }
}
