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
using Amazon.CloudWatchLogs;
using Amazon.CloudWatchLogs.Model;

namespace Amazon.PowerShell.Cmdlets.CWL
{
    /// <summary>
    /// Lists the specified log groups. You can list all your log groups or filter the results
    /// by prefix. The results are ASCII-sorted by log group name.
    /// 
    ///  
    /// <para>
    /// CloudWatch Logs doesn’t support IAM policies that control access to the <code>DescribeLogGroups</code>
    /// action by using the <code>aws:ResourceTag/<i>key-name</i></code> condition key. Other
    /// CloudWatch Logs actions do support the use of the <code>aws:ResourceTag/<i>key-name</i></code> condition key to control access. For more information about using tags to
    /// control access, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/access_tags.html">Controlling
    /// access to Amazon Web Services resources using tags</a>.
    /// </para><para>
    /// If you are using CloudWatch cross-account observability, you can use this operation
    /// in a monitoring account and view data from the linked source accounts. For more information,
    /// see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/monitoring/CloudWatch-Unified-Cross-Account.html">CloudWatch
    /// cross-account observability</a>.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "CWLLogGroup")]
    [OutputType("Amazon.CloudWatchLogs.Model.LogGroup")]
    [AWSCmdlet("Calls the Amazon CloudWatch Logs DescribeLogGroups API operation.", Operation = new[] {"DescribeLogGroups"}, SelectReturnType = typeof(Amazon.CloudWatchLogs.Model.DescribeLogGroupsResponse), LegacyAlias="Get-CWLLogGroups")]
    [AWSCmdletOutput("Amazon.CloudWatchLogs.Model.LogGroup or Amazon.CloudWatchLogs.Model.DescribeLogGroupsResponse",
        "This cmdlet returns a collection of Amazon.CloudWatchLogs.Model.LogGroup objects.",
        "The service call response (type Amazon.CloudWatchLogs.Model.DescribeLogGroupsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCWLLogGroupCmdlet : AmazonCloudWatchLogsClientCmdlet, IExecutor
    {
        
        #region Parameter AccountIdentifier
        /// <summary>
        /// <para>
        /// <para>When <code>includeLinkedAccounts</code> is set to <code>True</code>, use this parameter
        /// to specify the list of accounts to search. You can specify as many as 20 account IDs
        /// in the array. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AccountIdentifiers")]
        public System.String[] AccountIdentifier { get; set; }
        #endregion
        
        #region Parameter IncludeLinkedAccount
        /// <summary>
        /// <para>
        /// <para>If you are using a monitoring account, set this to <code>True</code> to have the operation
        /// return log groups in the accounts listed in <code>accountIdentifiers</code>.</para><para>If this parameter is set to <code>true</code> and <code>accountIdentifiers</code>
        /// contains a null value, the operation returns all log groups in the monitoring account
        /// and all log groups in all source accounts that are linked to the monitoring account.
        /// </para><note><para> If you specify <code>includeLinkedAccounts</code> in your request, then <code>metricFilterCount</code>,
        /// <code>retentionInDays</code>, and <code>storedBytes</code> are not included in the
        /// response. </para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IncludeLinkedAccounts")]
        public System.Boolean? IncludeLinkedAccount { get; set; }
        #endregion
        
        #region Parameter LogGroupNamePattern
        /// <summary>
        /// <para>
        /// <para>If you specify a string for this parameter, the operation returns only log groups
        /// that have names that match the string based on a case-sensitive substring search.
        /// For example, if you specify <code>Foo</code>, log groups named <code>FooBar</code>,
        /// <code>aws/Foo</code>, and <code>GroupFoo</code> would match, but <code>foo</code>,
        /// <code>F/o/o</code> and <code>Froo</code> would not match.</para><note><para><code>logGroupNamePattern</code> and <code>logGroupNamePrefix</code> are mutually
        /// exclusive. Only one of these parameters can be passed. </para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LogGroupNamePattern { get; set; }
        #endregion
        
        #region Parameter LogGroupNamePrefix
        /// <summary>
        /// <para>
        /// <para>The prefix to match.</para><note><para><code>logGroupNamePrefix</code> and <code>logGroupNamePattern</code> are mutually
        /// exclusive. Only one of these parameters can be passed. </para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String LogGroupNamePrefix { get; set; }
        #endregion
        
        #region Parameter Limit
        /// <summary>
        /// <para>
        /// <para>The maximum number of items returned. If you don't specify a value, the default is
        /// up to 50 items.</para>
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
        /// <para>The token for the next set of items to return. (You received this token from a previous
        /// call.)</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>In order to manually control output pagination, use '-NextToken $null' for the first call and '-NextToken $AWSHistory.LastServiceResponse.NextToken' for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'LogGroups'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatchLogs.Model.DescribeLogGroupsResponse).
        /// Specifying the name of a property of type Amazon.CloudWatchLogs.Model.DescribeLogGroupsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "LogGroups";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the LogGroupNamePrefix parameter.
        /// The -PassThru parameter is deprecated, use -Select '^LogGroupNamePrefix' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^LogGroupNamePrefix' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatchLogs.Model.DescribeLogGroupsResponse, GetCWLLogGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.LogGroupNamePrefix;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.AccountIdentifier != null)
            {
                context.AccountIdentifier = new List<System.String>(this.AccountIdentifier);
            }
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
            context.LogGroupNamePattern = this.LogGroupNamePattern;
            context.LogGroupNamePrefix = this.LogGroupNamePrefix;
            context.NextToken = this.NextToken;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        #if MODULAR
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
            // create request and set iteration invariants
            var request = new Amazon.CloudWatchLogs.Model.DescribeLogGroupsRequest();
            
            if (cmdletContext.AccountIdentifier != null)
            {
                request.AccountIdentifiers = cmdletContext.AccountIdentifier;
            }
            if (cmdletContext.IncludeLinkedAccount != null)
            {
                request.IncludeLinkedAccounts = cmdletContext.IncludeLinkedAccount.Value;
            }
            if (cmdletContext.Limit != null)
            {
                request.Limit = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.Limit.Value);
            }
            if (cmdletContext.LogGroupNamePattern != null)
            {
                request.LogGroupNamePattern = cmdletContext.LogGroupNamePattern;
            }
            if (cmdletContext.LogGroupNamePrefix != null)
            {
                request.LogGroupNamePrefix = cmdletContext.LogGroupNamePrefix;
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
        #else
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            
            // create request and set iteration invariants
            var request = new Amazon.CloudWatchLogs.Model.DescribeLogGroupsRequest();
            if (cmdletContext.AccountIdentifier != null)
            {
                request.AccountIdentifiers = cmdletContext.AccountIdentifier;
            }
            if (cmdletContext.IncludeLinkedAccount != null)
            {
                request.IncludeLinkedAccounts = cmdletContext.IncludeLinkedAccount.Value;
            }
            if (cmdletContext.LogGroupNamePattern != null)
            {
                request.LogGroupNamePattern = cmdletContext.LogGroupNamePattern;
            }
            if (cmdletContext.LogGroupNamePrefix != null)
            {
                request.LogGroupNamePrefix = cmdletContext.LogGroupNamePrefix;
            }
            
            // Initialize loop variants and commence piping
            System.String _nextToken = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.NextToken))
            {
                _nextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.Limit.HasValue)
            {
                // The service has a maximum page size of 50. If the user has
                // asked for more items than page max, and there is no page size
                // configured, we rely on the service ignoring the set maximum
                // and giving us 50 items back. If a page size is set, that will
                // be used to configure the pagination.
                // We'll make further calls to satisfy the user's request.
                _emitLimit = cmdletContext.Limit;
            }
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                if (_emitLimit.HasValue)
                {
                    int correctPageSize = Math.Min(50, _emitLimit.Value);
                    request.Limit = AutoIterationHelpers.ConvertEmitLimitToInt32(correctPageSize);
                }
                
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
                    int _receivedThisCall = response.LogGroups.Count;
                    
                    _nextToken = response.NextToken;
                    _retrievedSoFar += _receivedThisCall;
                    if (_emitLimit.HasValue)
                    {
                        _emitLimit -= _receivedThisCall;
                    }
                }
                catch (Exception e)
                {
                    if (_retrievedSoFar == 0 || !_emitLimit.HasValue)
                    {
                        output = new CmdletOutput { ErrorResponse = e };
                    }
                    else
                    {
                        break;
                    }
                }
                
                ProcessOutput(output);
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken) && (!_emitLimit.HasValue || _emitLimit.Value >= 1));
            
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        #endif
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.CloudWatchLogs.Model.DescribeLogGroupsResponse CallAWSServiceOperation(IAmazonCloudWatchLogs client, Amazon.CloudWatchLogs.Model.DescribeLogGroupsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Logs", "DescribeLogGroups");
            try
            {
                #if DESKTOP
                return client.DescribeLogGroups(request);
                #elif CORECLR
                return client.DescribeLogGroupsAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? IncludeLinkedAccount { get; set; }
            public int? Limit { get; set; }
            public System.String LogGroupNamePattern { get; set; }
            public System.String LogGroupNamePrefix { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.CloudWatchLogs.Model.DescribeLogGroupsResponse, GetCWLLogGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.LogGroups;
        }
        
    }
}
