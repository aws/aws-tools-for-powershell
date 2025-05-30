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
using Amazon.RedshiftDataAPIService;
using Amazon.RedshiftDataAPIService.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.RSD
{
    /// <summary>
    /// List of SQL statements. By default, only finished statements are shown. A token is
    /// returned to page through the statement list. 
    /// 
    ///  
    /// <para>
    /// When you use identity-enhanced role sessions to list statements, you must provide
    /// either the <c>cluster-identifier</c> or <c>workgroup-name</c> parameter. This ensures
    /// that the IdC user can only access the Amazon Redshift IdC applications they are assigned.
    /// For more information, see <a href="https://docs.aws.amazon.com/singlesignon/latest/userguide/trustedidentitypropagation-overview.html">
    /// Trusted identity propagation overview</a>.
    /// </para><para>
    /// For more information about the Amazon Redshift Data API and CLI usage examples, see
    /// <a href="https://docs.aws.amazon.com/redshift/latest/mgmt/data-api.html">Using the
    /// Amazon Redshift Data API</a> in the <i>Amazon Redshift Management Guide</i>. 
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration. This cmdlet didn't autopaginate in V4, auto-pagination support was added in V5.
    /// </summary>
    [Cmdlet("Get", "RSDStatementList")]
    [OutputType("Amazon.RedshiftDataAPIService.Model.StatementData")]
    [AWSCmdlet("Calls the Redshift Data API Service ListStatements API operation.", Operation = new[] {"ListStatements"}, SelectReturnType = typeof(Amazon.RedshiftDataAPIService.Model.ListStatementsResponse))]
    [AWSCmdletOutput("Amazon.RedshiftDataAPIService.Model.StatementData or Amazon.RedshiftDataAPIService.Model.ListStatementsResponse",
        "This cmdlet returns a collection of Amazon.RedshiftDataAPIService.Model.StatementData objects.",
        "The service call response (type Amazon.RedshiftDataAPIService.Model.ListStatementsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetRSDStatementListCmdlet : AmazonRedshiftDataAPIServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>The cluster identifier. Only statements that ran on this cluster are returned. When
        /// providing <c>ClusterIdentifier</c>, then <c>WorkgroupName</c> can't be specified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClusterIdentifier { get; set; }
        #endregion
        
        #region Parameter Database
        /// <summary>
        /// <para>
        /// <para>The name of the database when listing statements run against a <c>ClusterIdentifier</c>
        /// or <c>WorkgroupName</c>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Database { get; set; }
        #endregion
        
        #region Parameter RoleLevel
        /// <summary>
        /// <para>
        /// <para>A value that filters which statements to return in the response. If true, all statements
        /// run by the caller's IAM role are returned. If false, only statements run by the caller's
        /// IAM role in the current IAM session are returned. The default is true. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? RoleLevel { get; set; }
        #endregion
        
        #region Parameter StatementName
        /// <summary>
        /// <para>
        /// <para>The name of the SQL statement specified as input to <c>BatchExecuteStatement</c> or
        /// <c>ExecuteStatement</c> to identify the query. You can list multiple statements by
        /// providing a prefix that matches the beginning of the statement name. For example,
        /// to list myStatement1, myStatement2, myStatement3, and so on, then provide the a value
        /// of <c>myStatement</c>. Data API does a case-sensitive match of SQL statement names
        /// to the prefix value you provide. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StatementName { get; set; }
        #endregion
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>The status of the SQL statement to list. Status values are defined as follows: </para><ul><li><para>ABORTED - The query run was stopped by the user. </para></li><li><para>ALL - A status value that includes all query statuses. This value can be used to filter
        /// results. </para></li><li><para>FAILED - The query run failed. </para></li><li><para>FINISHED - The query has finished running. </para></li><li><para>PICKED - The query has been chosen to be run. </para></li><li><para>STARTED - The query run has started. </para></li><li><para>SUBMITTED - The query was submitted, but not yet processed. </para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.RedshiftDataAPIService.StatusString")]
        public Amazon.RedshiftDataAPIService.StatusString Status { get; set; }
        #endregion
        
        #region Parameter WorkgroupName
        /// <summary>
        /// <para>
        /// <para>The serverless workgroup name or Amazon Resource Name (ARN). Only statements that
        /// ran on this workgroup are returned. When providing <c>WorkgroupName</c>, then <c>ClusterIdentifier</c>
        /// can't be specified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String WorkgroupName { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of SQL statements to return in the response. If more SQL statements
        /// exist than fit in one response, then <c>NextToken</c> is returned to page through
        /// the results. </para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In AWSPowerShell and AWSPowerShell.NetCore this parameter is used to limit the total number of items returned by the cmdlet.
        /// <br/>In AWS.Tools this parameter is simply passed to the service to specify how many items should be returned by each service call.
        /// <br/>Pipe the output of this cmdlet into Select-Object -First to terminate retrieving data pages early and control the number of items returned.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems","MaxResults")]
        public int? MaxResult { get; set; }
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
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'NextToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-NextToken' to null for the first call then set the 'NextToken' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Statements'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RedshiftDataAPIService.Model.ListStatementsResponse).
        /// Specifying the name of a property of type Amazon.RedshiftDataAPIService.Model.ListStatementsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Statements";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
        /// as the start point.
        /// This cmdlet didn't autopaginate in V4. To preserve the V4 autopagination behavior for all cmdlets, run Set-AWSAutoIterationMode -IterationMode v4.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RedshiftDataAPIService.Model.ListStatementsResponse, GetRSDStatementListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClusterIdentifier = this.ClusterIdentifier;
            context.Database = this.Database;
            context.MaxResult = this.MaxResult;
            #if !MODULAR
            if (ParameterWasBound(nameof(this.MaxResult)) && this.MaxResult.HasValue)
            {
                WriteWarning("AWSPowerShell and AWSPowerShell.NetCore use the MaxResult parameter to limit the total number of items returned by the cmdlet." +
                    " This behavior is obsolete and will be removed in a future version of these modules. Pipe the output of this cmdlet into Select-Object -First to terminate" +
                    " retrieving data pages early and control the number of items returned. AWS.Tools already implements the new behavior of simply passing MaxResult" +
                    " to the service to specify how many items should be returned by each service call.");
            }
            #endif
            context.NextToken = this.NextToken;
            context.RoleLevel = this.RoleLevel;
            context.StatementName = this.StatementName;
            context.Status = this.Status;
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
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.RedshiftDataAPIService.Model.ListStatementsRequest();
            
            if (cmdletContext.ClusterIdentifier != null)
            {
                request.ClusterIdentifier = cmdletContext.ClusterIdentifier;
            }
            if (cmdletContext.Database != null)
            {
                request.Database = cmdletContext.Database;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
            }
            if (cmdletContext.RoleLevel != null)
            {
                request.RoleLevel = cmdletContext.RoleLevel.Value;
            }
            if (cmdletContext.StatementName != null)
            {
                request.StatementName = cmdletContext.StatementName;
            }
            if (cmdletContext.Status != null)
            {
                request.Status = cmdletContext.Status;
            }
            if (cmdletContext.WorkgroupName != null)
            {
                request.WorkgroupName = cmdletContext.WorkgroupName;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            var _shouldAutoIterate = !(SessionState.PSVariable.GetValue("AWSPowerShell_AutoIteration_Mode")?.ToString() == "v4");
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                
                CmdletOutput output;
                
                try
                {
                    
                    var response = CallAWSServiceOperation(client, request);
                    
                    object pipelineOutput = null;
                    if (!useParameterSelect)
                    {
                        pipelineOutput = cmdletContext.Select(response, this);
                    }
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
                    };
                    
                    _nextToken = response.NextToken;
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                }
                
                ProcessOutput(output);
                
            } while (!_userControllingPaging && _shouldAutoIterate && AutoIterationHelpers.HasValue(_nextToken));
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.RedshiftDataAPIService.Model.ListStatementsResponse CallAWSServiceOperation(IAmazonRedshiftDataAPIService client, Amazon.RedshiftDataAPIService.Model.ListStatementsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Redshift Data API Service", "ListStatements");
            try
            {
                return client.ListStatementsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Database { get; set; }
            public int? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Boolean? RoleLevel { get; set; }
            public System.String StatementName { get; set; }
            public Amazon.RedshiftDataAPIService.StatusString Status { get; set; }
            public System.String WorkgroupName { get; set; }
            public System.Func<Amazon.RedshiftDataAPIService.Model.ListStatementsResponse, GetRSDStatementListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Statements;
        }
        
    }
}
