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
    /// List the tables in a database. If neither <code>SchemaPattern</code> nor <code>TablePattern</code>
    /// are specified, then all tables in the database are returned. A token is returned to
    /// page through the table list. Depending on the authorization method, use one of the
    /// following combinations of request parameters: 
    /// 
    ///  <ul><li><para>
    /// Secrets Manager - when connecting to a cluster, specify the Amazon Resource Name (ARN)
    /// of the secret, the database name, and the cluster identifier that matches the cluster
    /// in the secret. When connecting to a serverless workgroup, specify the Amazon Resource
    /// Name (ARN) of the secret and the database name. 
    /// </para></li><li><para>
    /// Temporary credentials - when connecting to a cluster, specify the cluster identifier,
    /// the database name, and the database user name. Also, permission to call the <code>redshift:GetClusterCredentials</code>
    /// operation is required. When connecting to a serverless workgroup, specify the workgroup
    /// name and database name. Also, permission to call the <code>redshift-serverless:GetCredentials</code>
    /// operation is required. 
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Get", "RSDTableList")]
    [OutputType("Amazon.RedshiftDataAPIService.Model.TableMember")]
    [AWSCmdlet("Calls the Redshift Data API Service ListTables API operation.", Operation = new[] {"ListTables"}, SelectReturnType = typeof(Amazon.RedshiftDataAPIService.Model.ListTablesResponse))]
    [AWSCmdletOutput("Amazon.RedshiftDataAPIService.Model.TableMember or Amazon.RedshiftDataAPIService.Model.ListTablesResponse",
        "This cmdlet returns a collection of Amazon.RedshiftDataAPIService.Model.TableMember objects.",
        "The service call response (type Amazon.RedshiftDataAPIService.Model.ListTablesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetRSDTableListCmdlet : AmazonRedshiftDataAPIServiceClientCmdlet, IExecutor
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
        /// <para>The name of the database that contains the tables to list. If <code>ConnectedDatabase</code>
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
        /// <para>The database user name. This parameter is required when connecting to a cluster and
        /// authenticating using temporary credentials. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DbUser { get; set; }
        #endregion
        
        #region Parameter SchemaPattern
        /// <summary>
        /// <para>
        /// <para>A pattern to filter results by schema name. Within a schema pattern, "%" means match
        /// any substring of 0 or more characters and "_" means match any one character. Only
        /// schema name entries matching the search pattern are returned. If <code>SchemaPattern</code>
        /// is not specified, then all tables that match <code>TablePattern</code> are returned.
        /// If neither <code>SchemaPattern</code> or <code>TablePattern</code> are specified,
        /// then all tables are returned. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SchemaPattern { get; set; }
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
        
        #region Parameter TablePattern
        /// <summary>
        /// <para>
        /// <para>A pattern to filter results by table name. Within a table pattern, "%" means match
        /// any substring of 0 or more characters and "_" means match any one character. Only
        /// table name entries matching the search pattern are returned. If <code>TablePattern</code>
        /// is not specified, then all tables that match <code>SchemaPattern</code>are returned.
        /// If neither <code>SchemaPattern</code> or <code>TablePattern</code> are specified,
        /// then all tables are returned. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TablePattern { get; set; }
        #endregion
        
        #region Parameter WorkgroupName
        /// <summary>
        /// <para>
        /// <para>The serverless workgroup name. This parameter is required when connecting to a serverless
        /// workgroup and authenticating using either Secrets Manager or temporary credentials.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String WorkgroupName { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of tables to return in the response. If more tables exist than
        /// fit in one response, then <code>NextToken</code> is returned to page through the results.
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Tables'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RedshiftDataAPIService.Model.ListTablesResponse).
        /// Specifying the name of a property of type Amazon.RedshiftDataAPIService.Model.ListTablesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Tables";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RedshiftDataAPIService.Model.ListTablesResponse, GetRSDTableListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
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
            context.SchemaPattern = this.SchemaPattern;
            context.SecretArn = this.SecretArn;
            context.TablePattern = this.TablePattern;
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
            var request = new Amazon.RedshiftDataAPIService.Model.ListTablesRequest();
            
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
            if (cmdletContext.SchemaPattern != null)
            {
                request.SchemaPattern = cmdletContext.SchemaPattern;
            }
            if (cmdletContext.SecretArn != null)
            {
                request.SecretArn = cmdletContext.SecretArn;
            }
            if (cmdletContext.TablePattern != null)
            {
                request.TablePattern = cmdletContext.TablePattern;
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
        
        private Amazon.RedshiftDataAPIService.Model.ListTablesResponse CallAWSServiceOperation(IAmazonRedshiftDataAPIService client, Amazon.RedshiftDataAPIService.Model.ListTablesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Redshift Data API Service", "ListTables");
            try
            {
                #if DESKTOP
                return client.ListTables(request);
                #elif CORECLR
                return client.ListTablesAsync(request).GetAwaiter().GetResult();
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
            public System.String SchemaPattern { get; set; }
            public System.String SecretArn { get; set; }
            public System.String TablePattern { get; set; }
            public System.String WorkgroupName { get; set; }
            public System.Func<Amazon.RedshiftDataAPIService.Model.ListTablesResponse, GetRSDTableListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Tables;
        }
        
    }
}
