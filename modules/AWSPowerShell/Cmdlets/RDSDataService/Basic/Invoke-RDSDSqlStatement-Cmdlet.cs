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
using Amazon.RDSDataService;
using Amazon.RDSDataService.Model;

namespace Amazon.PowerShell.Cmdlets.RDSD
{
    /// <summary>
    /// Runs one or more SQL statements.
    /// 
    ///  <note><para>
    /// This operation isn't supported for Aurora Serverless v2 and provisioned DB clusters.
    /// For Aurora Serverless v1 DB clusters, the operation is deprecated. Use the <c>BatchExecuteStatement</c>
    /// or <c>ExecuteStatement</c> operation.
    /// </para></note><br/><br/>This operation is deprecated.
    /// </summary>
    [Cmdlet("Invoke", "RDSDSqlStatement", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDSDataService.Model.SqlStatementResult")]
    [AWSCmdlet("Calls the AWS RDS DataService ExecuteSql API operation.", Operation = new[] {"ExecuteSql"}, SelectReturnType = typeof(Amazon.RDSDataService.Model.ExecuteSqlResponse))]
    [AWSCmdletOutput("Amazon.RDSDataService.Model.SqlStatementResult or Amazon.RDSDataService.Model.ExecuteSqlResponse",
        "This cmdlet returns a collection of Amazon.RDSDataService.Model.SqlStatementResult objects.",
        "The service call response (type Amazon.RDSDataService.Model.ExecuteSqlResponse) can be returned by specifying '-Select *'."
    )]
    [System.ObsoleteAttribute("ExecuteSql has been deprecated.  Please use ExecuteStatement or BatchExecuteStatement instead.")]
    public partial class InvokeRDSDSqlStatementCmdlet : AmazonRDSDataServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AwsSecretStoreArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the secret that enables access to the DB cluster.
        /// Enter the database user name and password for the credentials in the secret.</para><para>For information about creating the secret, see <a href="https://docs.aws.amazon.com/secretsmanager/latest/userguide/create_database_secret.html">Create
        /// a database secret</a>.</para>
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
        public System.String AwsSecretStoreArn { get; set; }
        #endregion
        
        #region Parameter Database
        /// <summary>
        /// <para>
        /// <para>The name of the database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Database { get; set; }
        #endregion
        
        #region Parameter DbClusterOrInstanceArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the Aurora Serverless DB cluster.</para>
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
        public System.String DbClusterOrInstanceArn { get; set; }
        #endregion
        
        #region Parameter Schema
        /// <summary>
        /// <para>
        /// <para>The name of the database schema.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Schema { get; set; }
        #endregion
        
        #region Parameter SqlStatement
        /// <summary>
        /// <para>
        /// <para>One or more SQL statements to run on the DB cluster.</para><para>You can separate SQL statements from each other with a semicolon (;). Any valid SQL
        /// statement is permitted, including data definition, data manipulation, and commit statements.
        /// </para>
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
        [Alias("SqlStatements")]
        public System.String SqlStatement { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'SqlStatementResults'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RDSDataService.Model.ExecuteSqlResponse).
        /// Specifying the name of a property of type Amazon.RDSDataService.Model.ExecuteSqlResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "SqlStatementResults";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the SqlStatement parameter.
        /// The -PassThru parameter is deprecated, use -Select '^SqlStatement' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^SqlStatement' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-RDSDSqlStatement (ExecuteSql)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RDSDataService.Model.ExecuteSqlResponse, InvokeRDSDSqlStatementCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.SqlStatement;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AwsSecretStoreArn = this.AwsSecretStoreArn;
            #if MODULAR
            if (this.AwsSecretStoreArn == null && ParameterWasBound(nameof(this.AwsSecretStoreArn)))
            {
                WriteWarning("You are passing $null as a value for parameter AwsSecretStoreArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Database = this.Database;
            context.DbClusterOrInstanceArn = this.DbClusterOrInstanceArn;
            #if MODULAR
            if (this.DbClusterOrInstanceArn == null && ParameterWasBound(nameof(this.DbClusterOrInstanceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter DbClusterOrInstanceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Schema = this.Schema;
            context.SqlStatement = this.SqlStatement;
            #if MODULAR
            if (this.SqlStatement == null && ParameterWasBound(nameof(this.SqlStatement)))
            {
                WriteWarning("You are passing $null as a value for parameter SqlStatement which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.RDSDataService.Model.ExecuteSqlRequest();
            
            if (cmdletContext.AwsSecretStoreArn != null)
            {
                request.AwsSecretStoreArn = cmdletContext.AwsSecretStoreArn;
            }
            if (cmdletContext.Database != null)
            {
                request.Database = cmdletContext.Database;
            }
            if (cmdletContext.DbClusterOrInstanceArn != null)
            {
                request.DbClusterOrInstanceArn = cmdletContext.DbClusterOrInstanceArn;
            }
            if (cmdletContext.Schema != null)
            {
                request.Schema = cmdletContext.Schema;
            }
            if (cmdletContext.SqlStatement != null)
            {
                request.SqlStatements = cmdletContext.SqlStatement;
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
        
        private Amazon.RDSDataService.Model.ExecuteSqlResponse CallAWSServiceOperation(IAmazonRDSDataService client, Amazon.RDSDataService.Model.ExecuteSqlRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS RDS DataService", "ExecuteSql");
            try
            {
                #if DESKTOP
                return client.ExecuteSql(request);
                #elif CORECLR
                return client.ExecuteSqlAsync(request).GetAwaiter().GetResult();
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
            public System.String AwsSecretStoreArn { get; set; }
            public System.String Database { get; set; }
            public System.String DbClusterOrInstanceArn { get; set; }
            public System.String Schema { get; set; }
            public System.String SqlStatement { get; set; }
            public System.Func<Amazon.RDSDataService.Model.ExecuteSqlResponse, InvokeRDSDSqlStatementCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.SqlStatementResults;
        }
        
    }
}
