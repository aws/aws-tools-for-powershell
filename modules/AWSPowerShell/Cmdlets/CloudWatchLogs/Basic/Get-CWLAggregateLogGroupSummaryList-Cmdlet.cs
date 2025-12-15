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
using Amazon.CloudWatchLogs;
using Amazon.CloudWatchLogs.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CWL
{
    /// <summary>
    /// Returns an aggregate summary of all log groups in the Region grouped by specified
    /// data source characteristics. Supports optional filtering by log group class, name
    /// patterns, and data sources. If you perform this action in a monitoring account, you
    /// can also return aggregated summaries of log groups from source accounts that are linked
    /// to the monitoring account. For more information about using cross-account observability
    /// to set up monitoring accounts and source accounts, see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/monitoring/CloudWatch-Unified-Cross-Account.html">CloudWatch
    /// cross-account observability</a>.
    /// 
    ///  
    /// <para>
    /// The operation aggregates log groups by data source name and type and optionally format,
    /// providing counts of log groups that share these characteristics. The operation paginates
    /// results. By default, it returns up to 50 results and includes a token to retrieve
    /// more results.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "CWLAggregateLogGroupSummaryList")]
    [OutputType("Amazon.CloudWatchLogs.Model.AggregateLogGroupSummary")]
    [AWSCmdlet("Calls the Amazon CloudWatch Logs ListAggregateLogGroupSummaries API operation.", Operation = new[] {"ListAggregateLogGroupSummaries"}, SelectReturnType = typeof(Amazon.CloudWatchLogs.Model.ListAggregateLogGroupSummariesResponse))]
    [AWSCmdletOutput("Amazon.CloudWatchLogs.Model.AggregateLogGroupSummary or Amazon.CloudWatchLogs.Model.ListAggregateLogGroupSummariesResponse",
        "This cmdlet returns a collection of Amazon.CloudWatchLogs.Model.AggregateLogGroupSummary objects.",
        "The service call response (type Amazon.CloudWatchLogs.Model.ListAggregateLogGroupSummariesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCWLAggregateLogGroupSummaryListCmdlet : AmazonCloudWatchLogsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AccountIdentifier
        /// <summary>
        /// <para>
        /// <para>When <c>includeLinkedAccounts</c> is set to <c>true</c>, use this parameter to specify
        /// the list of accounts to search. You can specify as many as 20 account IDs in the array.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AccountIdentifiers")]
        public System.String[] AccountIdentifier { get; set; }
        #endregion
        
        #region Parameter DataSource
        /// <summary>
        /// <para>
        /// <para>Filters the results by data source characteristics to include only log groups associated
        /// with the specified data sources.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSources")]
        public Amazon.CloudWatchLogs.Model.DataSourceFilter[] DataSource { get; set; }
        #endregion
        
        #region Parameter GroupBy
        /// <summary>
        /// <para>
        /// <para>Specifies how to group the log groups in the summary.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CloudWatchLogs.ListAggregateLogGroupSummariesGroupBy")]
        public Amazon.CloudWatchLogs.ListAggregateLogGroupSummariesGroupBy GroupBy { get; set; }
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
        /// <para>Filters the results by log group class to include only log groups of the specified
        /// class.</para>
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
        /// <para>The maximum number of aggregated summaries to return. If you omit this parameter,
        /// the default is up to 50 aggregated summaries.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In AWSPowerShell and AWSPowerShell.NetCore this parameter is used to limit the total number of items returned by the cmdlet.
        /// <br/>In AWS.Tools this parameter is simply passed to the service to specify how many items should be returned by each service call.
        /// <br/>Pipe the output of this cmdlet into Select-Object -First to terminate retrieving data pages early and control the number of items returned.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems")]
        public int? Limit { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AggregateLogGroupSummaries'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatchLogs.Model.ListAggregateLogGroupSummariesResponse).
        /// Specifying the name of a property of type Amazon.CloudWatchLogs.Model.ListAggregateLogGroupSummariesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AggregateLogGroupSummaries";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
        /// as the start point.
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
                context.Select = CreateSelectDelegate<Amazon.CloudWatchLogs.Model.ListAggregateLogGroupSummariesResponse, GetCWLAggregateLogGroupSummaryListCmdlet>(Select) ??
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
            context.GroupBy = this.GroupBy;
            #if MODULAR
            if (this.GroupBy == null && ParameterWasBound(nameof(this.GroupBy)))
            {
                WriteWarning("You are passing $null as a value for parameter GroupBy which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IncludeLinkedAccount = this.IncludeLinkedAccount;
            context.Limit = this.Limit;
            #if !MODULAR
            if (ParameterWasBound(nameof(this.Limit)) && this.Limit.HasValue)
            {
                WriteWarning("AWSPowerShell and AWSPowerShell.NetCore use the Limit parameter to limit the total number of items returned by the cmdlet." +
                    " This behavior is obsolete and will be removed in a future version of these modules. Pipe the output of this cmdlet into Select-Object -First to terminate" +
                    " retrieving data pages early and control the number of items returned. AWS.Tools already implements the new behavior of simply passing Limit" +
                    " to the service to specify how many items should be returned by each service call.");
            }
            #endif
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
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.CloudWatchLogs.Model.ListAggregateLogGroupSummariesRequest();
            
            if (cmdletContext.AccountIdentifier != null)
            {
                request.AccountIdentifiers = cmdletContext.AccountIdentifier;
            }
            if (cmdletContext.DataSource != null)
            {
                request.DataSources = cmdletContext.DataSource;
            }
            if (cmdletContext.GroupBy != null)
            {
                request.GroupBy = cmdletContext.GroupBy;
            }
            if (cmdletContext.IncludeLinkedAccount != null)
            {
                request.IncludeLinkedAccounts = cmdletContext.IncludeLinkedAccount.Value;
            }
            if (cmdletContext.Limit != null)
            {
                request.Limit = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.Limit.Value);
            }
            if (cmdletContext.LogGroupClass != null)
            {
                request.LogGroupClass = cmdletContext.LogGroupClass;
            }
            if (cmdletContext.LogGroupNamePattern != null)
            {
                request.LogGroupNamePattern = cmdletContext.LogGroupNamePattern;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
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
                
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken));
            
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
        
        private Amazon.CloudWatchLogs.Model.ListAggregateLogGroupSummariesResponse CallAWSServiceOperation(IAmazonCloudWatchLogs client, Amazon.CloudWatchLogs.Model.ListAggregateLogGroupSummariesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Logs", "ListAggregateLogGroupSummaries");
            try
            {
                return client.ListAggregateLogGroupSummariesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.CloudWatchLogs.ListAggregateLogGroupSummariesGroupBy GroupBy { get; set; }
            public System.Boolean? IncludeLinkedAccount { get; set; }
            public int? Limit { get; set; }
            public Amazon.CloudWatchLogs.LogGroupClass LogGroupClass { get; set; }
            public System.String LogGroupNamePattern { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.CloudWatchLogs.Model.ListAggregateLogGroupSummariesResponse, GetCWLAggregateLogGroupSummaryListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AggregateLogGroupSummaries;
        }
        
    }
}
