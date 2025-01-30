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
using Amazon.RedshiftDataAPIService;
using Amazon.RedshiftDataAPIService.Model;

namespace Amazon.PowerShell.Cmdlets.RSD
{
    /// <summary>
    /// Describes the detailed information about a table from metadata in the cluster. The
    /// information includes its columns. A token is returned to page through the column list.
    /// Depending on the authorization method, use one of the following combinations of request
    /// parameters: 
    /// 
    ///  <ul><li><para>
    /// Secrets Manager - when connecting to a cluster, provide the <c>secret-arn</c> of a
    /// secret stored in Secrets Manager which has <c>username</c> and <c>password</c>. The
    /// specified secret contains credentials to connect to the <c>database</c> you specify.
    /// When you are connecting to a cluster, you also supply the database name, If you provide
    /// a cluster identifier (<c>dbClusterIdentifier</c>), it must match the cluster identifier
    /// stored in the secret. When you are connecting to a serverless workgroup, you also
    /// supply the database name.
    /// </para></li><li><para>
    /// Temporary credentials - when connecting to your data warehouse, choose one of the
    /// following options:
    /// </para><ul><li><para>
    /// When connecting to a serverless workgroup, specify the workgroup name and database
    /// name. The database user name is derived from the IAM identity. For example, <c>arn:iam::123456789012:user:foo</c>
    /// has the database user name <c>IAM:foo</c>. Also, permission to call the <c>redshift-serverless:GetCredentials</c>
    /// operation is required.
    /// </para></li><li><para>
    /// When connecting to a cluster as an IAM identity, specify the cluster identifier and
    /// the database name. The database user name is derived from the IAM identity. For example,
    /// <c>arn:iam::123456789012:user:foo</c> has the database user name <c>IAM:foo</c>. Also,
    /// permission to call the <c>redshift:GetClusterCredentialsWithIAM</c> operation is required.
    /// </para></li><li><para>
    /// When connecting to a cluster as a database user, specify the cluster identifier, the
    /// database name, and the database user name. Also, permission to call the <c>redshift:GetClusterCredentials</c>
    /// operation is required.
    /// </para></li></ul></li></ul><para>
    /// For more information about the Amazon Redshift Data API and CLI usage examples, see
    /// <a href="https://docs.aws.amazon.com/redshift/latest/mgmt/data-api.html">Using the
    /// Amazon Redshift Data API</a> in the <i>Amazon Redshift Management Guide</i>. 
    /// </para>
    /// </summary>
    [Cmdlet("Get", "RSDTable")]
    [OutputType("Amazon.RedshiftDataAPIService.Model.DescribeTableResponse")]
    [AWSCmdlet("Calls the Redshift Data API Service DescribeTable API operation.", Operation = new[] {"DescribeTable"}, SelectReturnType = typeof(Amazon.RedshiftDataAPIService.Model.DescribeTableResponse))]
    [AWSCmdletOutput("Amazon.RedshiftDataAPIService.Model.DescribeTableResponse",
        "This cmdlet returns an Amazon.RedshiftDataAPIService.Model.DescribeTableResponse object containing multiple properties."
    )]
    public partial class GetRSDTableCmdlet : AmazonRedshiftDataAPIServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>The cluster identifier. This parameter is required when connecting to a cluster and
        /// authenticating using either Secrets Manager or temporary credentials. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ClusterIdentifier { get; set; }
        #endregion
        
        #region Parameter ConnectedDatabase
        /// <summary>
        /// <para>
        /// <para>A database name. The connected database is specified when you connect with your authentication
        /// credentials. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectedDatabase { get; set; }
        #endregion
        
        #region Parameter Database
        /// <summary>
        /// <para>
        /// <para>The name of the database that contains the tables to be described. If <c>ConnectedDatabase</c>
        /// is not specified, this is also the database to connect to with your authentication
        /// credentials.</para>
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
        
        #region Parameter Schema
        /// <summary>
        /// <para>
        /// <para>The schema that contains the table. If no schema is specified, then matching tables
        /// for all schemas are returned. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Schema { get; set; }
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
        
        #region Parameter Table
        /// <summary>
        /// <para>
        /// <para>The table name. If no table is specified, then all tables for all matching schemas
        /// are returned. If no table and no schema is specified, then all tables for all schemas
        /// in the database are returned</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Table { get; set; }
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
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of tables to return in the response. If more tables exist than
        /// fit in one response, then <c>NextToken</c> is returned to page through the results.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>A value that indicates the starting point for the next set of response records in
        /// a subsequent request. If a value is returned in a response, you can retrieve the next
        /// set of records by providing this returned NextToken value in the next NextToken parameter
        /// and retrying the command. If the NextToken field is empty, all response records have
        /// been retrieved for the request. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RedshiftDataAPIService.Model.DescribeTableResponse).
        /// Specifying the name of a property of type Amazon.RedshiftDataAPIService.Model.DescribeTableResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ClusterIdentifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ClusterIdentifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ClusterIdentifier' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RedshiftDataAPIService.Model.DescribeTableResponse, GetRSDTableCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ClusterIdentifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClusterIdentifier = this.ClusterIdentifier;
            context.ConnectedDatabase = this.ConnectedDatabase;
            context.Database = this.Database;
            #if MODULAR
            if (this.Database == null && ParameterWasBound(nameof(this.Database)))
            {
                WriteWarning("You are passing $null as a value for parameter Database which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DbUser = this.DbUser;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.Schema = this.Schema;
            context.SecretArn = this.SecretArn;
            context.Table = this.Table;
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
            var request = new Amazon.RedshiftDataAPIService.Model.DescribeTableRequest();
            
            if (cmdletContext.ClusterIdentifier != null)
            {
                request.ClusterIdentifier = cmdletContext.ClusterIdentifier;
            }
            if (cmdletContext.ConnectedDatabase != null)
            {
                request.ConnectedDatabase = cmdletContext.ConnectedDatabase;
            }
            if (cmdletContext.Database != null)
            {
                request.Database = cmdletContext.Database;
            }
            if (cmdletContext.DbUser != null)
            {
                request.DbUser = cmdletContext.DbUser;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.Schema != null)
            {
                request.Schema = cmdletContext.Schema;
            }
            if (cmdletContext.SecretArn != null)
            {
                request.SecretArn = cmdletContext.SecretArn;
            }
            if (cmdletContext.Table != null)
            {
                request.Table = cmdletContext.Table;
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
        
        private Amazon.RedshiftDataAPIService.Model.DescribeTableResponse CallAWSServiceOperation(IAmazonRedshiftDataAPIService client, Amazon.RedshiftDataAPIService.Model.DescribeTableRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Redshift Data API Service", "DescribeTable");
            try
            {
                #if DESKTOP
                return client.DescribeTable(request);
                #elif CORECLR
                return client.DescribeTableAsync(request).GetAwaiter().GetResult();
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
            public System.String ClusterIdentifier { get; set; }
            public System.String ConnectedDatabase { get; set; }
            public System.String Database { get; set; }
            public System.String DbUser { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String Schema { get; set; }
            public System.String SecretArn { get; set; }
            public System.String Table { get; set; }
            public System.String WorkgroupName { get; set; }
            public System.Func<Amazon.RedshiftDataAPIService.Model.DescribeTableResponse, GetRSDTableCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
