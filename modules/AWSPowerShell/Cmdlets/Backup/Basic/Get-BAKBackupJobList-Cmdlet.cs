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
using Amazon.Backup;
using Amazon.Backup.Model;

namespace Amazon.PowerShell.Cmdlets.BAK
{
    /// <summary>
    /// Returns a list of existing backup jobs for an authenticated account.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "BAKBackupJobList")]
    [OutputType("Amazon.Backup.Model.BackupJob")]
    [AWSCmdlet("Calls the AWS Backup ListBackupJobs API operation.", Operation = new[] {"ListBackupJobs"}, SelectReturnType = typeof(Amazon.Backup.Model.ListBackupJobsResponse))]
    [AWSCmdletOutput("Amazon.Backup.Model.BackupJob or Amazon.Backup.Model.ListBackupJobsResponse",
        "This cmdlet returns a collection of Amazon.Backup.Model.BackupJob objects.",
        "The service call response (type Amazon.Backup.Model.ListBackupJobsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetBAKBackupJobListCmdlet : AmazonBackupClientCmdlet, IExecutor
    {
        
        #region Parameter ByAccountId
        /// <summary>
        /// <para>
        /// <para>The account ID to list the jobs from. Returns only backup jobs associated with the
        /// specified account ID.</para><para>If used from an AWS Organizations management account, passing <code>*</code> returns
        /// all jobs across the organization.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ByAccountId { get; set; }
        #endregion
        
        #region Parameter ByBackupVaultName
        /// <summary>
        /// <para>
        /// <para>Returns only backup jobs that will be stored in the specified backup vault. Backup
        /// vaults are identified by names that are unique to the account used to create them
        /// and the AWS Region where they are created. They consist of lowercase letters, numbers,
        /// and hyphens.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ByBackupVaultName { get; set; }
        #endregion
        
        #region Parameter ByCreatedAfter
        /// <summary>
        /// <para>
        /// <para>Returns only backup jobs that were created after the specified date.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? ByCreatedAfter { get; set; }
        #endregion
        
        #region Parameter ByCreatedBefore
        /// <summary>
        /// <para>
        /// <para>Returns only backup jobs that were created before the specified date.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? ByCreatedBefore { get; set; }
        #endregion
        
        #region Parameter ByResourceArn
        /// <summary>
        /// <para>
        /// <para>Returns only backup jobs that match the specified resource Amazon Resource Name (ARN).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ByResourceArn { get; set; }
        #endregion
        
        #region Parameter ByResourceType
        /// <summary>
        /// <para>
        /// <para>Returns only backup jobs for the specified resources:</para><ul><li><para><code>DynamoDB</code> for Amazon DynamoDB</para></li><li><para><code>EBS</code> for Amazon Elastic Block Store</para></li><li><para><code>EC2</code> for Amazon Elastic Compute Cloud</para></li><li><para><code>EFS</code> for Amazon Elastic File System</para></li><li><para><code>RDS</code> for Amazon Relational Database Service</para></li><li><para><code>Aurora</code> for Amazon Aurora</para></li><li><para><code>Storage Gateway</code> for AWS Storage Gateway</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ByResourceType { get; set; }
        #endregion
        
        #region Parameter ByState
        /// <summary>
        /// <para>
        /// <para>Returns only backup jobs that are in the specified state.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Backup.BackupJobState")]
        public Amazon.Backup.BackupJobState ByState { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of items to be returned.</para>
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
        /// <para>The next item following a partial list of returned items. For example, if a request
        /// is made to return <code>maxResults</code> number of items, <code>NextToken</code>
        /// allows you to return more items in your list starting at the location pointed to by
        /// the next token.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'BackupJobs'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Backup.Model.ListBackupJobsResponse).
        /// Specifying the name of a property of type Amazon.Backup.Model.ListBackupJobsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "BackupJobs";
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
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Backup.Model.ListBackupJobsResponse, GetBAKBackupJobListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ByAccountId = this.ByAccountId;
            context.ByBackupVaultName = this.ByBackupVaultName;
            context.ByCreatedAfter = this.ByCreatedAfter;
            context.ByCreatedBefore = this.ByCreatedBefore;
            context.ByResourceArn = this.ByResourceArn;
            context.ByResourceType = this.ByResourceType;
            context.ByState = this.ByState;
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
            var request = new Amazon.Backup.Model.ListBackupJobsRequest();
            
            if (cmdletContext.ByAccountId != null)
            {
                request.ByAccountId = cmdletContext.ByAccountId;
            }
            if (cmdletContext.ByBackupVaultName != null)
            {
                request.ByBackupVaultName = cmdletContext.ByBackupVaultName;
            }
            if (cmdletContext.ByCreatedAfter != null)
            {
                request.ByCreatedAfter = cmdletContext.ByCreatedAfter.Value;
            }
            if (cmdletContext.ByCreatedBefore != null)
            {
                request.ByCreatedBefore = cmdletContext.ByCreatedBefore.Value;
            }
            if (cmdletContext.ByResourceArn != null)
            {
                request.ByResourceArn = cmdletContext.ByResourceArn;
            }
            if (cmdletContext.ByResourceType != null)
            {
                request.ByResourceType = cmdletContext.ByResourceType;
            }
            if (cmdletContext.ByState != null)
            {
                request.ByState = cmdletContext.ByState;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
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
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.Backup.Model.ListBackupJobsRequest();
            if (cmdletContext.ByAccountId != null)
            {
                request.ByAccountId = cmdletContext.ByAccountId;
            }
            if (cmdletContext.ByBackupVaultName != null)
            {
                request.ByBackupVaultName = cmdletContext.ByBackupVaultName;
            }
            if (cmdletContext.ByCreatedAfter != null)
            {
                request.ByCreatedAfter = cmdletContext.ByCreatedAfter.Value;
            }
            if (cmdletContext.ByCreatedBefore != null)
            {
                request.ByCreatedBefore = cmdletContext.ByCreatedBefore.Value;
            }
            if (cmdletContext.ByResourceArn != null)
            {
                request.ByResourceArn = cmdletContext.ByResourceArn;
            }
            if (cmdletContext.ByResourceType != null)
            {
                request.ByResourceType = cmdletContext.ByResourceType;
            }
            if (cmdletContext.ByState != null)
            {
                request.ByState = cmdletContext.ByState;
            }
            
            // Initialize loop variants and commence piping
            System.String _nextToken = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.NextToken))
            {
                _nextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.MaxResult.HasValue)
            {
                // The service has a maximum page size of 1000. If the user has
                // asked for more items than page max, and there is no page size
                // configured, we rely on the service ignoring the set maximum
                // and giving us 1000 items back. If a page size is set, that will
                // be used to configure the pagination.
                // We'll make further calls to satisfy the user's request.
                _emitLimit = cmdletContext.MaxResult;
            }
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                if (_emitLimit.HasValue)
                {
                    int correctPageSize = Math.Min(1000, _emitLimit.Value);
                    request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToInt32(correctPageSize);
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
                    int _receivedThisCall = response.BackupJobs.Count;
                    
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
        
        private Amazon.Backup.Model.ListBackupJobsResponse CallAWSServiceOperation(IAmazonBackup client, Amazon.Backup.Model.ListBackupJobsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Backup", "ListBackupJobs");
            try
            {
                #if DESKTOP
                return client.ListBackupJobs(request);
                #elif CORECLR
                return client.ListBackupJobsAsync(request).GetAwaiter().GetResult();
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
            public System.String ByAccountId { get; set; }
            public System.String ByBackupVaultName { get; set; }
            public System.DateTime? ByCreatedAfter { get; set; }
            public System.DateTime? ByCreatedBefore { get; set; }
            public System.String ByResourceArn { get; set; }
            public System.String ByResourceType { get; set; }
            public Amazon.Backup.BackupJobState ByState { get; set; }
            public int? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.Backup.Model.ListBackupJobsResponse, GetBAKBackupJobListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.BackupJobs;
        }
        
    }
}
