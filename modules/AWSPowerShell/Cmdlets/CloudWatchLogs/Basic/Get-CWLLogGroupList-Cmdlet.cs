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
using Amazon.CloudWatchLogs;
using Amazon.CloudWatchLogs.Model;

namespace Amazon.PowerShell.Cmdlets.CWL
{
    /// <summary>
    /// Returns a list of log groups in the Region in your account. If you are performing
    /// this action in a monitoring account, you can choose to also return log groups from
    /// source accounts that are linked to the monitoring account. For more information about
    /// using cross-account observability to set up monitoring accounts and source accounts,
    /// see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/monitoring/CloudWatch-Unified-Cross-Account.html">
    /// CloudWatch cross-account observability</a>.
    /// 
    ///  
    /// <para>
    /// You can optionally filter the list by log group class, by using regular expressions
    /// in your request to match strings in the log group names, by using the fieldIndexes
    /// parameter to filter log groups based on which field indexes are configured, by using
    /// the dataSources parameter to filter log groups by data source types, and by using
    /// the fieldIndexNames parameter to filter by specific field index names.
    /// </para><para>
    /// This operation is paginated. By default, your first use of this operation returns
    /// 50 results, and includes a token to use in a subsequent operation to return more results.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "CWLLogGroupList")]
    [OutputType("Amazon.CloudWatchLogs.Model.LogGroupSummary")]
    [AWSCmdlet("Calls the Amazon CloudWatch Logs ListLogGroups API operation.", Operation = new[] {"ListLogGroups"}, SelectReturnType = typeof(Amazon.CloudWatchLogs.Model.ListLogGroupsResponse))]
    [AWSCmdletOutput("Amazon.CloudWatchLogs.Model.LogGroupSummary or Amazon.CloudWatchLogs.Model.ListLogGroupsResponse",
        "This cmdlet returns a collection of Amazon.CloudWatchLogs.Model.LogGroupSummary objects.",
        "The service call response (type Amazon.CloudWatchLogs.Model.ListLogGroupsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCWLLogGroupListCmdlet : AmazonCloudWatchLogsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AccountIdentifier
        /// <summary>
        /// <para>
        /// <para>When <c>includeLinkedAccounts</c> is set to <c>true</c>, use this parameter to specify
        /// the list of accounts to search. You can specify as many as 20 account IDs in the array.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AccountIdentifiers")]
        public System.String[] AccountIdentifier { get; set; }
        #endregion
        
        #region Parameter DataSource
        /// <summary>
        /// <para>
        /// <para>An array of data source filters to filter log groups by their associated data sources.
        /// You can filter by data source name, type, or both. Multiple filters within the same
        /// dimension are combined with OR logic, while filters across different dimensions are
        /// combined with AND logic.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSources")]
        public Amazon.CloudWatchLogs.Model.DataSourceFilter[] DataSource { get; set; }
        #endregion
        
        #region Parameter FieldIndexName
        /// <summary>
        /// <para>
        /// <para>An array of field index names to filter log groups that have specific field indexes.
        /// Only log groups containing all specified field indexes are returned. You can specify
        /// 1 to 20 field index names, each with 1 to 512 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FieldIndexNames")]
        public System.String[] FieldIndexName { get; set; }
        #endregion
        
        #region Parameter IncludeLinkedAccount
        /// <summary>
        /// <para>
        /// <para>If you are using a monitoring account, set this to <c>true</c> to have the operation
        /// return log groups in the accounts listed in <c>accountIdentifiers</c>.</para><para>If this parameter is set to <c>true</c> and <c>accountIdentifiers</c> contains a null
        /// value, the operation returns all log groups in the monitoring account and all log
        /// groups in all source accounts that are linked to the monitoring account. </para><para>The default for this parameter is <c>false</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IncludeLinkedAccounts")]
        public System.Boolean? IncludeLinkedAccount { get; set; }
        #endregion
        
        #region Parameter LogGroupClass
        /// <summary>
        /// <para>
        /// <para>Use this parameter to limit the results to only those log groups in the specified
        /// log group class. If you omit this parameter, log groups of all classes can be returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudWatchLogs.LogGroupClass")]
        public Amazon.CloudWatchLogs.LogGroupClass LogGroupClass { get; set; }
        #endregion
        
        #region Parameter LogGroupNamePattern
        /// <summary>
        /// <para>
        /// <para>Use this parameter to limit the returned log groups to only those with names that
        /// match the pattern that you specify. This parameter is a regular expression that can
        /// match prefixes and substrings, and supports wildcard matching and matching multiple
        /// patterns, as in the following examples. </para><ul><li><para>Use <c>^</c> to match log group names by prefix.</para></li><li><para>For a substring match, specify the string to match. All matches are case sensitive</para></li><li><para>To match multiple patterns, separate them with a <c>|</c> as in the example <c>^/aws/lambda|discovery</c></para></li></ul><para>You can specify as many as five different regular expression patterns in this field,
        /// each of which must be between 3 and 24 characters. You can include the <c>^</c> symbol
        /// as many as five times, and include the <c>|</c> symbol as many as four times.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LogGroupNamePattern { get; set; }
        #endregion
        
        #region Parameter Limit
        /// <summary>
        /// <para>
        /// <para>The maximum number of log groups to return. If you omit this parameter, the default
        /// is up to 50 log groups.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Limit { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'LogGroups'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatchLogs.Model.ListLogGroupsResponse).
        /// Specifying the name of a property of type Amazon.CloudWatchLogs.Model.ListLogGroupsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "LogGroups";
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
                context.Select = CreateSelectDelegate<Amazon.CloudWatchLogs.Model.ListLogGroupsResponse, GetCWLLogGroupListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AccountIdentifier != null)
            {
                context.AccountIdentifier = new List<System.String>(this.AccountIdentifier);
            }
            if (this.DataSource != null)
            {
                context.DataSource = new List<Amazon.CloudWatchLogs.Model.DataSourceFilter>(this.DataSource);
            }
            if (this.FieldIndexName != null)
            {
                context.FieldIndexName = new List<System.String>(this.FieldIndexName);
            }
            context.IncludeLinkedAccount = this.IncludeLinkedAccount;
            context.Limit = this.Limit;
            context.LogGroupClass = this.LogGroupClass;
            context.LogGroupNamePattern = this.LogGroupNamePattern;
            context.NextToken = this.NextToken;
            
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
            var request = new Amazon.CloudWatchLogs.Model.ListLogGroupsRequest();
            
            if (cmdletContext.AccountIdentifier != null)
            {
                request.AccountIdentifiers = cmdletContext.AccountIdentifier;
            }
            if (cmdletContext.DataSource != null)
            {
                request.DataSources = cmdletContext.DataSource;
            }
            if (cmdletContext.FieldIndexName != null)
            {
                request.FieldIndexNames = cmdletContext.FieldIndexName;
            }
            if (cmdletContext.IncludeLinkedAccount != null)
            {
                request.IncludeLinkedAccounts = cmdletContext.IncludeLinkedAccount.Value;
            }
            if (cmdletContext.Limit != null)
            {
                request.Limit = cmdletContext.Limit.Value;
            }
            if (cmdletContext.LogGroupClass != null)
            {
                request.LogGroupClass = cmdletContext.LogGroupClass;
            }
            if (cmdletContext.LogGroupNamePattern != null)
            {
                request.LogGroupNamePattern = cmdletContext.LogGroupNamePattern;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
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
        
        private Amazon.CloudWatchLogs.Model.ListLogGroupsResponse CallAWSServiceOperation(IAmazonCloudWatchLogs client, Amazon.CloudWatchLogs.Model.ListLogGroupsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Logs", "ListLogGroups");
            try
            {
                #if DESKTOP
                return client.ListLogGroups(request);
                #elif CORECLR
                return client.ListLogGroupsAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> AccountIdentifier { get; set; }
            public List<Amazon.CloudWatchLogs.Model.DataSourceFilter> DataSource { get; set; }
            public List<System.String> FieldIndexName { get; set; }
            public System.Boolean? IncludeLinkedAccount { get; set; }
            public System.Int32? Limit { get; set; }
            public Amazon.CloudWatchLogs.LogGroupClass LogGroupClass { get; set; }
            public System.String LogGroupNamePattern { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.CloudWatchLogs.Model.ListLogGroupsResponse, GetCWLLogGroupListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.LogGroups;
        }
        
    }
}
