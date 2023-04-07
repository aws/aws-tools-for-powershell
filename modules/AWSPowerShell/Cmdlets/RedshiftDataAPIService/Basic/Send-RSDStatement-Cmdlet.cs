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
using Amazon.RedshiftDataAPIService;
using Amazon.RedshiftDataAPIService.Model;

namespace Amazon.PowerShell.Cmdlets.RSD
{
    /// <summary>
    /// Runs an SQL statement, which can be data manipulation language (DML) or data definition
    /// language (DDL). This statement must be a single SQL statement. Depending on the authorization
    /// method, use one of the following combinations of request parameters: 
    /// 
    ///  <ul><li><para>
    /// Secrets Manager - when connecting to a cluster, provide the <code>secret-arn</code>
    /// of a secret stored in Secrets Manager which has <code>username</code> and <code>password</code>.
    /// The specified secret contains credentials to connect to the <code>database</code>
    /// you specify. When you are connecting to a cluster, you also supply the database name,
    /// If you provide a cluster identifier (<code>dbClusterIdentifier</code>), it must match
    /// the cluster identifier stored in the secret. When you are connecting to a serverless
    /// workgroup, you also supply the database name.
    /// </para></li><li><para>
    /// Temporary credentials - when connecting to your data warehouse, choose one of the
    /// following options:
    /// </para><ul><li><para>
    /// When connecting to a serverless workgroup, specify the workgroup name and database
    /// name. The database user name is derived from the IAM identity. For example, <code>arn:iam::123456789012:user:foo</code>
    /// has the database user name <code>IAM:foo</code>. Also, permission to call the <code>redshift-serverless:GetCredentials</code>
    /// operation is required.
    /// </para></li><li><para>
    /// When connecting to a cluster as an IAM identity, specify the cluster identifier and
    /// the database name. The database user name is derived from the IAM identity. For example,
    /// <code>arn:iam::123456789012:user:foo</code> has the database user name <code>IAM:foo</code>.
    /// Also, permission to call the <code>redshift:GetClusterCredentialsWithIAM</code> operation
    /// is required.
    /// </para></li><li><para>
    /// When connecting to a cluster as a database user, specify the cluster identifier, the
    /// database name, and the database user name. Also, permission to call the <code>redshift:GetClusterCredentials</code>
    /// operation is required.
    /// </para></li></ul></li></ul><para>
    /// For more information about the Amazon Redshift Data API and CLI usage examples, see
    /// <a href="https://docs.aws.amazon.com/redshift/latest/mgmt/data-api.html">Using the
    /// Amazon Redshift Data API</a> in the <i>Amazon Redshift Management Guide</i>. 
    /// </para>
    /// </summary>
    [Cmdlet("Send", "RSDStatement", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Redshift Data API Service ExecuteStatement API operation.", Operation = new[] {"ExecuteStatement"}, SelectReturnType = typeof(Amazon.RedshiftDataAPIService.Model.ExecuteStatementResponse))]
    [AWSCmdletOutput("System.String or Amazon.RedshiftDataAPIService.Model.ExecuteStatementResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.RedshiftDataAPIService.Model.ExecuteStatementResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SendRSDStatementCmdlet : AmazonRedshiftDataAPIServiceClientCmdlet, IExecutor
    {
        
        #region Parameter ClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>The cluster identifier. This parameter is required when connecting to a cluster and
        /// authenticating using either Secrets Manager or temporary credentials. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClusterIdentifier { get; set; }
        #endregion
        
        #region Parameter Database
        /// <summary>
        /// <para>
        /// <para>The name of the database. This parameter is required when authenticating using either
        /// Secrets Manager or temporary credentials. </para>
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
        public System.String Database { get; set; }
        #endregion
        
        #region Parameter DbUser
        /// <summary>
        /// <para>
        /// <para>The database user name. This parameter is required when connecting to a cluster as
        /// a database user and authenticating using temporary credentials. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DbUser { get; set; }
        #endregion
        
        #region Parameter Parameter
        /// <summary>
        /// <para>
        /// <para>The parameters for the SQL statement.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters")]
        public Amazon.RedshiftDataAPIService.Model.SqlParameter[] Parameter { get; set; }
        #endregion
        
        #region Parameter SecretArn
        /// <summary>
        /// <para>
        /// <para>The name or ARN of the secret that enables access to the database. This parameter
        /// is required when authenticating using Secrets Manager. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SecretArn { get; set; }
        #endregion
        
        #region Parameter Sql
        /// <summary>
        /// <para>
        /// <para>The SQL statement text to run. </para>
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
        public System.String Sql { get; set; }
        #endregion
        
        #region Parameter StatementName
        /// <summary>
        /// <para>
        /// <para>The name of the SQL statement. You can name the SQL statement when you create it to
        /// identify the query. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StatementName { get; set; }
        #endregion
        
        #region Parameter WithEvent
        /// <summary>
        /// <para>
        /// <para>A value that indicates whether to send an event to the Amazon EventBridge event bus
        /// after the SQL statement runs. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? WithEvent { get; set; }
        #endregion
        
        #region Parameter WorkgroupName
        /// <summary>
        /// <para>
        /// <para>The serverless workgroup name or Amazon Resource Name (ARN). This parameter is required
        /// when connecting to a serverless workgroup and authenticating using either Secrets
        /// Manager or temporary credentials.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String WorkgroupName { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Id'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RedshiftDataAPIService.Model.ExecuteStatementResponse).
        /// Specifying the name of a property of type Amazon.RedshiftDataAPIService.Model.ExecuteStatementResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Id";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ClusterIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-RSDStatement (ExecuteStatement)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RedshiftDataAPIService.Model.ExecuteStatementResponse, SendRSDStatementCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.ClusterIdentifier = this.ClusterIdentifier;
            context.Database = this.Database;
            #if MODULAR
            if (this.Database == null && ParameterWasBound(nameof(this.Database)))
            {
                WriteWarning("You are passing $null as a value for parameter Database which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DbUser = this.DbUser;
            if (this.Parameter != null)
            {
                context.Parameter = new List<Amazon.RedshiftDataAPIService.Model.SqlParameter>(this.Parameter);
            }
            context.SecretArn = this.SecretArn;
            context.Sql = this.Sql;
            #if MODULAR
            if (this.Sql == null && ParameterWasBound(nameof(this.Sql)))
            {
                WriteWarning("You are passing $null as a value for parameter Sql which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StatementName = this.StatementName;
            context.WithEvent = this.WithEvent;
            context.WorkgroupName = this.WorkgroupName;
            
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
            var request = new Amazon.RedshiftDataAPIService.Model.ExecuteStatementRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.ClusterIdentifier != null)
            {
                request.ClusterIdentifier = cmdletContext.ClusterIdentifier;
            }
            if (cmdletContext.Database != null)
            {
                request.Database = cmdletContext.Database;
            }
            if (cmdletContext.DbUser != null)
            {
                request.DbUser = cmdletContext.DbUser;
            }
            if (cmdletContext.Parameter != null)
            {
                request.Parameters = cmdletContext.Parameter;
            }
            if (cmdletContext.SecretArn != null)
            {
                request.SecretArn = cmdletContext.SecretArn;
            }
            if (cmdletContext.Sql != null)
            {
                request.Sql = cmdletContext.Sql;
            }
            if (cmdletContext.StatementName != null)
            {
                request.StatementName = cmdletContext.StatementName;
            }
            if (cmdletContext.WithEvent != null)
            {
                request.WithEvent = cmdletContext.WithEvent.Value;
            }
            if (cmdletContext.WorkgroupName != null)
            {
                request.WorkgroupName = cmdletContext.WorkgroupName;
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
        
        private Amazon.RedshiftDataAPIService.Model.ExecuteStatementResponse CallAWSServiceOperation(IAmazonRedshiftDataAPIService client, Amazon.RedshiftDataAPIService.Model.ExecuteStatementRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Redshift Data API Service", "ExecuteStatement");
            try
            {
                #if DESKTOP
                return client.ExecuteStatement(request);
                #elif CORECLR
                return client.ExecuteStatementAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String ClusterIdentifier { get; set; }
            public System.String Database { get; set; }
            public System.String DbUser { get; set; }
            public List<Amazon.RedshiftDataAPIService.Model.SqlParameter> Parameter { get; set; }
            public System.String SecretArn { get; set; }
            public System.String Sql { get; set; }
            public System.String StatementName { get; set; }
            public System.Boolean? WithEvent { get; set; }
            public System.String WorkgroupName { get; set; }
            public System.Func<Amazon.RedshiftDataAPIService.Model.ExecuteStatementResponse, SendRSDStatementCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Id;
        }
        
    }
}
