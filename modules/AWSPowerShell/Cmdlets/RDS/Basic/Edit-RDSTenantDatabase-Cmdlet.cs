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
using Amazon.RDS;
using Amazon.RDS.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.RDS
{
    /// <summary>
    /// Modifies an existing tenant database in a DB instance. You can change the tenant database
    /// name or the master user password. This operation is supported only for RDS for Oracle
    /// CDB instances using the multi-tenant configuration.
    /// </summary>
    [Cmdlet("Edit", "RDSTenantDatabase", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.TenantDatabase")]
    [AWSCmdlet("Calls the Amazon Relational Database Service ModifyTenantDatabase API operation.", Operation = new[] {"ModifyTenantDatabase"}, SelectReturnType = typeof(Amazon.RDS.Model.ModifyTenantDatabaseResponse))]
    [AWSCmdletOutput("Amazon.RDS.Model.TenantDatabase or Amazon.RDS.Model.ModifyTenantDatabaseResponse",
        "This cmdlet returns an Amazon.RDS.Model.TenantDatabase object.",
        "The service call response (type Amazon.RDS.Model.ModifyTenantDatabaseResponse) can be returned by specifying '-Select *'."
    )]
    public partial class EditRDSTenantDatabaseCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DBInstanceIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the DB instance that contains the tenant database that you are modifying.
        /// This parameter isn't case-sensitive.</para><para>Constraints:</para><ul><li><para>Must match the identifier of an existing DB instance.</para></li></ul>
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
        public System.String DBInstanceIdentifier { get; set; }
        #endregion
        
        #region Parameter ManageMasterUserPassword
        /// <summary>
        /// <para>
        /// <para>Specifies whether to manage the master user password with Amazon Web Services Secrets
        /// Manager.</para><para>If the tenant database doesn't manage the master user password with Amazon Web Services
        /// Secrets Manager, you can turn on this management. In this case, you can't specify
        /// <c>MasterUserPassword</c>.</para><para>If the tenant database already manages the master user password with Amazon Web Services
        /// Secrets Manager, and you specify that the master user password is not managed with
        /// Amazon Web Services Secrets Manager, then you must specify <c>MasterUserPassword</c>.
        /// In this case, Amazon RDS deletes the secret and uses the new password for the master
        /// user specified by <c>MasterUserPassword</c>.</para><para>For more information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/rds-secrets-manager.html">Password
        /// management with Amazon Web Services Secrets Manager</a> in the <i>Amazon RDS User
        /// Guide.</i></para><para>Constraints:</para><ul><li><para>Can't manage the master user password with Amazon Web Services Secrets Manager if
        /// <c>MasterUserPassword</c> is specified.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ManageMasterUserPassword { get; set; }
        #endregion
        
        #region Parameter MasterUserPassword
        /// <summary>
        /// <para>
        /// <para>The new password for the master user of the specified tenant database in your DB instance.</para><note><para>Amazon RDS operations never return the password, so this action provides a way to
        /// regain access to a tenant database user if the password is lost. This includes restoring
        /// privileges that might have been accidentally revoked.</para></note><para>Constraints:</para><ul><li><para>Can include any printable ASCII character except <c>/</c>, <c>"</c> (double quote),
        /// <c>@</c>, <c>&amp;</c> (ampersand), and <c>'</c> (single quote).</para></li></ul><para>Length constraints:</para><ul><li><para>Must contain between 8 and 30 characters. </para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MasterUserPassword { get; set; }
        #endregion
        
        #region Parameter MasterUserSecretKmsKeyId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services KMS key identifier to encrypt a secret that is automatically
        /// generated and managed in Amazon Web Services Secrets Manager.</para><para>This setting is valid only if both of the following conditions are met:</para><ul><li><para>The tenant database doesn't manage the master user password in Amazon Web Services
        /// Secrets Manager.</para><para>If the tenant database already manages the master user password in Amazon Web Services
        /// Secrets Manager, you can't change the KMS key used to encrypt the secret.</para></li><li><para>You're turning on <c>ManageMasterUserPassword</c> to manage the master user password
        /// in Amazon Web Services Secrets Manager.</para><para>If you're turning on <c>ManageMasterUserPassword</c> and don't specify <c>MasterUserSecretKmsKeyId</c>,
        /// then the <c>aws/secretsmanager</c> KMS key is used to encrypt the secret. If the secret
        /// is in a different Amazon Web Services account, then you can't use the <c>aws/secretsmanager</c>
        /// KMS key to encrypt the secret, and you must use a self-managed KMS key.</para></li></ul><para>The Amazon Web Services KMS key identifier is any of the following:</para><ul><li><para>Key ARN</para></li><li><para>Key ID</para></li><li><para>Alias ARN</para></li><li><para>Alias name for the KMS key</para></li></ul><para>To use a KMS key in a different Amazon Web Services account, specify the key ARN or
        /// alias ARN.</para><para>A default KMS key exists for your Amazon Web Services account. Your Amazon Web Services
        /// account has a different default KMS key for each Amazon Web Services Region.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MasterUserSecretKmsKeyId { get; set; }
        #endregion
        
        #region Parameter NewTenantDBName
        /// <summary>
        /// <para>
        /// <para>The new name of the tenant database when renaming a tenant database. This parameter
        /// isn’t case-sensitive.</para><para>Constraints:</para><ul><li><para>Can't be the string null or any other reserved word.</para></li><li><para>Can't be longer than 8 characters.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NewTenantDBName { get; set; }
        #endregion
        
        #region Parameter RotateMasterUserPassword
        /// <summary>
        /// <para>
        /// <para>Specifies whether to rotate the secret managed by Amazon Web Services Secrets Manager
        /// for the master user password.</para><para>This setting is valid only if the master user password is managed by RDS in Amazon
        /// Web Services Secrets Manager for the DB instance. The secret value contains the updated
        /// password.</para><para>For more information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/rds-secrets-manager.html">Password
        /// management with Amazon Web Services Secrets Manager</a> in the <i>Amazon RDS User
        /// Guide.</i></para><para>Constraints:</para><ul><li><para>You must apply the change immediately when rotating the master user password.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? RotateMasterUserPassword { get; set; }
        #endregion
        
        #region Parameter TenantDBName
        /// <summary>
        /// <para>
        /// <para>The user-supplied name of the tenant database that you want to modify. This parameter
        /// isn’t case-sensitive.</para><para>Constraints:</para><ul><li><para>Must match the identifier of an existing tenant database.</para></li></ul>
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
        public System.String TenantDBName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TenantDatabase'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RDS.Model.ModifyTenantDatabaseResponse).
        /// Specifying the name of a property of type Amazon.RDS.Model.ModifyTenantDatabaseResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TenantDatabase";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DBInstanceIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-RDSTenantDatabase (ModifyTenantDatabase)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RDS.Model.ModifyTenantDatabaseResponse, EditRDSTenantDatabaseCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DBInstanceIdentifier = this.DBInstanceIdentifier;
            #if MODULAR
            if (this.DBInstanceIdentifier == null && ParameterWasBound(nameof(this.DBInstanceIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter DBInstanceIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ManageMasterUserPassword = this.ManageMasterUserPassword;
            context.MasterUserPassword = this.MasterUserPassword;
            context.MasterUserSecretKmsKeyId = this.MasterUserSecretKmsKeyId;
            context.NewTenantDBName = this.NewTenantDBName;
            context.RotateMasterUserPassword = this.RotateMasterUserPassword;
            context.TenantDBName = this.TenantDBName;
            #if MODULAR
            if (this.TenantDBName == null && ParameterWasBound(nameof(this.TenantDBName)))
            {
                WriteWarning("You are passing $null as a value for parameter TenantDBName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.RDS.Model.ModifyTenantDatabaseRequest();
            
            if (cmdletContext.DBInstanceIdentifier != null)
            {
                request.DBInstanceIdentifier = cmdletContext.DBInstanceIdentifier;
            }
            if (cmdletContext.ManageMasterUserPassword != null)
            {
                request.ManageMasterUserPassword = cmdletContext.ManageMasterUserPassword.Value;
            }
            if (cmdletContext.MasterUserPassword != null)
            {
                request.MasterUserPassword = cmdletContext.MasterUserPassword;
            }
            if (cmdletContext.MasterUserSecretKmsKeyId != null)
            {
                request.MasterUserSecretKmsKeyId = cmdletContext.MasterUserSecretKmsKeyId;
            }
            if (cmdletContext.NewTenantDBName != null)
            {
                request.NewTenantDBName = cmdletContext.NewTenantDBName;
            }
            if (cmdletContext.RotateMasterUserPassword != null)
            {
                request.RotateMasterUserPassword = cmdletContext.RotateMasterUserPassword.Value;
            }
            if (cmdletContext.TenantDBName != null)
            {
                request.TenantDBName = cmdletContext.TenantDBName;
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
        
        private Amazon.RDS.Model.ModifyTenantDatabaseResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.ModifyTenantDatabaseRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "ModifyTenantDatabase");
            try
            {
                return client.ModifyTenantDatabaseAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DBInstanceIdentifier { get; set; }
            public System.Boolean? ManageMasterUserPassword { get; set; }
            public System.String MasterUserPassword { get; set; }
            public System.String MasterUserSecretKmsKeyId { get; set; }
            public System.String NewTenantDBName { get; set; }
            public System.Boolean? RotateMasterUserPassword { get; set; }
            public System.String TenantDBName { get; set; }
            public System.Func<Amazon.RDS.Model.ModifyTenantDatabaseResponse, EditRDSTenantDatabaseCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TenantDatabase;
        }
        
    }
}
