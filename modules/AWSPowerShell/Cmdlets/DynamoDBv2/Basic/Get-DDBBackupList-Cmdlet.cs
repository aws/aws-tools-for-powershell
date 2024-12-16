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
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;

namespace Amazon.PowerShell.Cmdlets.DDB
{
    /// <summary>
    /// List DynamoDB backups that are associated with an Amazon Web Services account and
    /// weren't made with Amazon Web Services Backup. To list these backups for a given table,
    /// specify <c>TableName</c>. <c>ListBackups</c> returns a paginated list of results with
    /// at most 1 MB worth of items in a page. You can also specify a maximum number of entries
    /// to be returned in a page.
    /// 
    ///  
    /// <para>
    /// In the request, start time is inclusive, but end time is exclusive. Note that these
    /// boundaries are for the time at which the original backup was requested.
    /// </para><para>
    /// You can call <c>ListBackups</c> a maximum of five times per second.
    /// </para><para>
    /// If you want to retrieve the complete list of backups made with Amazon Web Services
    /// Backup, use the <a href="https://docs.aws.amazon.com/aws-backup/latest/devguide/API_ListBackupJobs.html">Amazon
    /// Web Services Backup list API.</a></para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "DDBBackupList")]
    [OutputType("Amazon.DynamoDBv2.Model.BackupSummary")]
    [AWSCmdlet("Calls the Amazon DynamoDB ListBackups API operation.", Operation = new[] {"ListBackups"}, SelectReturnType = typeof(Amazon.DynamoDBv2.Model.ListBackupsResponse))]
    [AWSCmdletOutput("Amazon.DynamoDBv2.Model.BackupSummary or Amazon.DynamoDBv2.Model.ListBackupsResponse",
        "This cmdlet returns a collection of Amazon.DynamoDBv2.Model.BackupSummary objects.",
        "The service call response (type Amazon.DynamoDBv2.Model.ListBackupsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetDDBBackupListCmdlet : AmazonDynamoDBClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter BackupType
        /// <summary>
        /// <para>
        /// <para>The backups from the table specified by <c>BackupType</c> are listed.</para><para>Where <c>BackupType</c> can be:</para><ul><li><para><c>USER</c> - On-demand backup created by you. (The default setting if no other backup
        /// types are specified.)</para></li><li><para><c>SYSTEM</c> - On-demand backup automatically created by DynamoDB.</para></li><li><para><c>ALL</c> - All types of on-demand backups (USER and SYSTEM).</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DynamoDBv2.BackupTypeFilter")]
        public Amazon.DynamoDBv2.BackupTypeFilter BackupType { get; set; }
        #endregion
        
        #region Parameter TableName
        /// <summary>
        /// <para>
        /// <para>Lists the backups from the table specified in <c>TableName</c>. You can also provide
        /// the Amazon Resource Name (ARN) of the table in this parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String TableName { get; set; }
        #endregion
        
        #region Parameter TimeRangeLowerBound
        /// <summary>
        /// <para>
        /// <para>Only backups created after this time are listed. <c>TimeRangeLowerBound</c> is inclusive.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? TimeRangeLowerBound { get; set; }
        #endregion
        
        #region Parameter TimeRangeUpperBound
        /// <summary>
        /// <para>
        /// <para>Only backups created before this time are listed. <c>TimeRangeUpperBound</c> is exclusive.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? TimeRangeUpperBound { get; set; }
        #endregion
        
        #region Parameter ExclusiveStartBackupArn
        /// <summary>
        /// <para>
        /// <para><c>LastEvaluatedBackupArn</c> is the Amazon Resource Name (ARN) of the backup last
        /// evaluated when the current page of results was returned, inclusive of the current
        /// page of results. This value may be specified as the <c>ExclusiveStartBackupArn</c>
        /// of a new <c>ListBackups</c> operation in order to fetch the next page of results.
        /// </para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'ExclusiveStartBackupArn' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-ExclusiveStartBackupArn' to null for the first call then set the 'ExclusiveStartBackupArn' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NextToken")]
        public System.String ExclusiveStartBackupArn { get; set; }
        #endregion
        
        #region Parameter Limit
        /// <summary>
        /// <para>
        /// <para>Maximum number of backups to return at once.</para>
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'BackupSummaries'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DynamoDBv2.Model.ListBackupsResponse).
        /// Specifying the name of a property of type Amazon.DynamoDBv2.Model.ListBackupsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "BackupSummaries";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of ExclusiveStartBackupArn
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
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
                context.Select = CreateSelectDelegate<Amazon.DynamoDBv2.Model.ListBackupsResponse, GetDDBBackupListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BackupType = this.BackupType;
            context.ExclusiveStartBackupArn = this.ExclusiveStartBackupArn;
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
            context.TableName = this.TableName;
            context.TimeRangeLowerBound = this.TimeRangeLowerBound;
            context.TimeRangeUpperBound = this.TimeRangeUpperBound;
            
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
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.DynamoDBv2.Model.ListBackupsRequest();
            
            if (cmdletContext.BackupType != null)
            {
                request.BackupType = cmdletContext.BackupType;
            }
            if (cmdletContext.Limit != null)
            {
                request.Limit = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.Limit.Value);
            }
            if (cmdletContext.TableName != null)
            {
                request.TableName = cmdletContext.TableName;
            }
            if (cmdletContext.TimeRangeLowerBound != null)
            {
                request.TimeRangeLowerBound = cmdletContext.TimeRangeLowerBound.Value;
            }
            if (cmdletContext.TimeRangeUpperBound != null)
            {
                request.TimeRangeUpperBound = cmdletContext.TimeRangeUpperBound.Value;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.ExclusiveStartBackupArn;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.ExclusiveStartBackupArn));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.ExclusiveStartBackupArn = _nextToken;
                
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
                    
                    _nextToken = response.LastEvaluatedBackupArn;
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
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.DynamoDBv2.Model.ListBackupsRequest();
            if (cmdletContext.BackupType != null)
            {
                request.BackupType = cmdletContext.BackupType;
            }
            if (cmdletContext.TableName != null)
            {
                request.TableName = cmdletContext.TableName;
            }
            if (cmdletContext.TimeRangeLowerBound != null)
            {
                request.TimeRangeLowerBound = cmdletContext.TimeRangeLowerBound.Value;
            }
            if (cmdletContext.TimeRangeUpperBound != null)
            {
                request.TimeRangeUpperBound = cmdletContext.TimeRangeUpperBound.Value;
            }
            
            // Initialize loop variants and commence piping
            System.String _nextToken = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.ExclusiveStartBackupArn))
            {
                _nextToken = cmdletContext.ExclusiveStartBackupArn;
            }
            if (cmdletContext.Limit.HasValue)
            {
                // The service has a maximum page size of 100. If the user has
                // asked for more items than page max, and there is no page size
                // configured, we rely on the service ignoring the set maximum
                // and giving us 100 items back. If a page size is set, that will
                // be used to configure the pagination.
                // We'll make further calls to satisfy the user's request.
                _emitLimit = cmdletContext.Limit;
            }
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.ExclusiveStartBackupArn));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.ExclusiveStartBackupArn = _nextToken;
                if (_emitLimit.HasValue)
                {
                    int correctPageSize = Math.Min(100, _emitLimit.Value);
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
                    int _receivedThisCall = response.BackupSummaries?.Count ?? 0;
                    
                    _nextToken = response.LastEvaluatedBackupArn;
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
        
        private Amazon.DynamoDBv2.Model.ListBackupsResponse CallAWSServiceOperation(IAmazonDynamoDB client, Amazon.DynamoDBv2.Model.ListBackupsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DynamoDB", "ListBackups");
            try
            {
                #if DESKTOP
                return client.ListBackups(request);
                #elif CORECLR
                return client.ListBackupsAsync(request).GetAwaiter().GetResult();
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
            public Amazon.DynamoDBv2.BackupTypeFilter BackupType { get; set; }
            public System.String ExclusiveStartBackupArn { get; set; }
            public int? Limit { get; set; }
            public System.String TableName { get; set; }
            public System.DateTime? TimeRangeLowerBound { get; set; }
            public System.DateTime? TimeRangeUpperBound { get; set; }
            public System.Func<Amazon.DynamoDBv2.Model.ListBackupsResponse, GetDDBBackupListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.BackupSummaries;
        }
        
    }
}
