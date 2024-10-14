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
using Amazon.RDS;
using Amazon.RDS.Model;

namespace Amazon.PowerShell.Cmdlets.RDS
{
    /// <summary>
    /// Creates a tenant database in a DB instance that uses the multi-tenant configuration.
    /// Only RDS for Oracle container database (CDB) instances are supported.
    /// </summary>
    [Cmdlet("New", "RDSTenantDatabase", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.TenantDatabase")]
    [AWSCmdlet("Calls the Amazon Relational Database Service CreateTenantDatabase API operation.", Operation = new[] {"CreateTenantDatabase"}, SelectReturnType = typeof(Amazon.RDS.Model.CreateTenantDatabaseResponse))]
    [AWSCmdletOutput("Amazon.RDS.Model.TenantDatabase or Amazon.RDS.Model.CreateTenantDatabaseResponse",
        "This cmdlet returns an Amazon.RDS.Model.TenantDatabase object.",
        "The service call response (type Amazon.RDS.Model.CreateTenantDatabaseResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewRDSTenantDatabaseCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CharacterSetName
        /// <summary>
        /// <para>
        /// <para>The character set for your tenant database. If you don't specify a value, the character
        /// set name defaults to <c>AL32UTF8</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CharacterSetName { get; set; }
        #endregion
        
        #region Parameter DBInstanceIdentifier
        /// <summary>
        /// <para>
        /// <para>The user-supplied DB instance identifier. RDS creates your tenant database in this
        /// DB instance. This parameter isn't case-sensitive.</para>
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
        
        #region Parameter MasterUsername
        /// <summary>
        /// <para>
        /// <para>The name for the master user account in your tenant database. RDS creates this user
        /// account in the tenant database and grants privileges to the master user. This parameter
        /// is case-sensitive.</para><para>Constraints:</para><ul><li><para>Must be 1 to 16 letters, numbers, or underscores.</para></li><li><para>First character must be a letter.</para></li><li><para>Can't be a reserved word for the chosen database engine.</para></li></ul>
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
        /// <para>The password for the master user in your tenant database.</para><para>Constraints:</para><ul><li><para>Must be 8 to 30 characters.</para></li><li><para>Can include any printable ASCII character except forward slash (<c>/</c>), double
        /// quote (<c>"</c>), at symbol (<c>@</c>), ampersand (<c>&amp;</c>), or single quote
        /// (<c>'</c>).</para></li></ul>
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
        public System.String MasterUserPassword { get; set; }
        #endregion
        
        #region Parameter NcharCharacterSetName
        /// <summary>
        /// <para>
        /// <para>The <c>NCHAR</c> value for the tenant database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NcharCharacterSetName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.RDS.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TenantDBName
        /// <summary>
        /// <para>
        /// <para>The user-supplied name of the tenant database that you want to create in your DB instance.
        /// This parameter has the same constraints as <c>DBName</c> in <c>CreateDBInstance</c>.</para>
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RDS.Model.CreateTenantDatabaseResponse).
        /// Specifying the name of a property of type Amazon.RDS.Model.CreateTenantDatabaseResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TenantDatabase";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DBInstanceIdentifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DBInstanceIdentifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DBInstanceIdentifier' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DBInstanceIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-RDSTenantDatabase (CreateTenantDatabase)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RDS.Model.CreateTenantDatabaseResponse, NewRDSTenantDatabaseCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DBInstanceIdentifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CharacterSetName = this.CharacterSetName;
            context.DBInstanceIdentifier = this.DBInstanceIdentifier;
            #if MODULAR
            if (this.DBInstanceIdentifier == null && ParameterWasBound(nameof(this.DBInstanceIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter DBInstanceIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            #if MODULAR
            if (this.MasterUserPassword == null && ParameterWasBound(nameof(this.MasterUserPassword)))
            {
                WriteWarning("You are passing $null as a value for parameter MasterUserPassword which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NcharCharacterSetName = this.NcharCharacterSetName;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.RDS.Model.Tag>(this.Tag);
            }
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
            var request = new Amazon.RDS.Model.CreateTenantDatabaseRequest();
            
            if (cmdletContext.CharacterSetName != null)
            {
                request.CharacterSetName = cmdletContext.CharacterSetName;
            }
            if (cmdletContext.DBInstanceIdentifier != null)
            {
                request.DBInstanceIdentifier = cmdletContext.DBInstanceIdentifier;
            }
            if (cmdletContext.MasterUsername != null)
            {
                request.MasterUsername = cmdletContext.MasterUsername;
            }
            if (cmdletContext.MasterUserPassword != null)
            {
                request.MasterUserPassword = cmdletContext.MasterUserPassword;
            }
            if (cmdletContext.NcharCharacterSetName != null)
            {
                request.NcharCharacterSetName = cmdletContext.NcharCharacterSetName;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.RDS.Model.CreateTenantDatabaseResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.CreateTenantDatabaseRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "CreateTenantDatabase");
            try
            {
                #if DESKTOP
                return client.CreateTenantDatabase(request);
                #elif CORECLR
                return client.CreateTenantDatabaseAsync(request).GetAwaiter().GetResult();
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
            public System.String CharacterSetName { get; set; }
            public System.String DBInstanceIdentifier { get; set; }
            public System.String MasterUsername { get; set; }
            public System.String MasterUserPassword { get; set; }
            public System.String NcharCharacterSetName { get; set; }
            public List<Amazon.RDS.Model.Tag> Tag { get; set; }
            public System.String TenantDBName { get; set; }
            public System.Func<Amazon.RDS.Model.CreateTenantDatabaseResponse, NewRDSTenantDatabaseCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TenantDatabase;
        }
        
    }
}
