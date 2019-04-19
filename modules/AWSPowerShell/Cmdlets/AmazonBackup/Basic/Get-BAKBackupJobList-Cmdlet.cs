/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Returns metadata about your backup jobs.<br/><br/>This operation automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output.
    /// </summary>
    [Cmdlet("Get", "BAKBackupJobList")]
    [OutputType("Amazon.Backup.Model.BackupJob")]
    [AWSCmdlet("Calls the Amazon Backup ListBackupJobs API operation.", Operation = new[] {"ListBackupJobs"})]
    [AWSCmdletOutput("Amazon.Backup.Model.BackupJob",
        "This cmdlet returns a collection of BackupJob objects.",
        "The service call response (type Amazon.Backup.Model.ListBackupJobsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String)"
    )]
    public partial class GetBAKBackupJobListCmdlet : AmazonBackupClientCmdlet, IExecutor
    {
        
        #region Parameter ByBackupVaultName
        /// <summary>
        /// <para>
        /// <para>Returns only backup jobs that will be stored in the specified backup vault. Backup
        /// vaults are identified by names that are unique to the account used to create them
        /// and the AWS Region where they are created. They consist of lowercase letters, numbers,
        /// and hyphens.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ByBackupVaultName { get; set; }
        #endregion
        
        #region Parameter ByCreatedAfter
        /// <summary>
        /// <para>
        /// <para>Returns only backup jobs that were created after the specified date.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime ByCreatedAfter { get; set; }
        #endregion
        
        #region Parameter ByCreatedBefore
        /// <summary>
        /// <para>
        /// <para>Returns only backup jobs that were created before the specified date.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime ByCreatedBefore { get; set; }
        #endregion
        
        #region Parameter ByResourceArn
        /// <summary>
        /// <para>
        /// <para>Returns only backup jobs that match the specified resource Amazon Resource Name (ARN).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ByResourceArn { get; set; }
        #endregion
        
        #region Parameter ByResourceType
        /// <summary>
        /// <para>
        /// <para>Returns only backup jobs for the specified resources:</para><ul><li><para><code>EBS</code> for Amazon Elastic Block Store</para></li><li><para><code>SGW</code> for AWS Storage Gateway</para></li><li><para><code>RDS</code> for Amazon Relational Database Service</para></li><li><para><code>DDB</code> for Amazon DynamoDB</para></li><li><para><code>EFS</code> for Amazon Elastic File System</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ByResourceType { get; set; }
        #endregion
        
        #region Parameter ByState
        /// <summary>
        /// <para>
        /// <para>Returns only backup jobs that are in the specified state.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Backup.BackupJobState")]
        public Amazon.Backup.BackupJobState ByState { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of items to be returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems","MaxResults")]
        public int MaxResult { get; set; }
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
        /// <br/>In order to manually control output pagination, assign $null, for the first call, and the value of $AWSHistory.LastServiceResponse.NextToken, for subsequent calls, to this parameter.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NextToken { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.ByBackupVaultName = this.ByBackupVaultName;
            if (ParameterWasBound("ByCreatedAfter"))
                context.ByCreatedAfter = this.ByCreatedAfter;
            if (ParameterWasBound("ByCreatedBefore"))
                context.ByCreatedBefore = this.ByCreatedBefore;
            context.ByResourceArn = this.ByResourceArn;
            context.ByResourceType = this.ByResourceType;
            context.ByState = this.ByState;
            if (ParameterWasBound("MaxResult"))
                context.MaxResults = this.MaxResult;
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
            
            // create request and set iteration invariants
            var request = new Amazon.Backup.Model.ListBackupJobsRequest();
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
            System.String _nextMarker = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.NextToken))
            {
                _nextMarker = cmdletContext.NextToken;
            }
            if (AutoIterationHelpers.HasValue(cmdletContext.MaxResults))
            {
                // The service has a maximum page size of 1000. If the user has
                // asked for more items than page max, and there is no page size
                // configured, we rely on the service ignoring the set maximum
                // and giving us 1000 items back. If a page size is set, that will
                // be used to configure the pagination.
                // We'll make further calls to satisfy the user's request.
                _emitLimit = cmdletContext.MaxResults;
            }
            bool _userControllingPaging = ParameterWasBound("NextToken");
            
            try
            {
                do
                {
                    request.NextToken = _nextMarker;
                    int correctPageSize = 1000;
                    if (_emitLimit.HasValue)
                    {
                        correctPageSize = AutoIterationHelpers.Min(1000, _emitLimit.Value);
                    }
                    request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToInt32(correctPageSize);
                    
                    var client = Client ?? CreateClient(context.Credentials, context.Region);
                    CmdletOutput output;
                    
                    try
                    {
                        
                        var response = CallAWSServiceOperation(client, request);
                        Dictionary<string, object> notes = null;
                        object pipelineOutput = response.BackupJobs;
                        notes = new Dictionary<string, object>();
                        notes["NextToken"] = response.NextToken;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        int _receivedThisCall = response.BackupJobs.Count;
                        if (_userControllingPaging)
                        {
                            WriteProgressRecord("Retrieving", string.Format("Retrieved {0} records starting from marker '{1}'", _receivedThisCall, request.NextToken));
                        }
                        
                        _nextMarker = response.NextToken;
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
                } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextMarker) && (!_emitLimit.HasValue || _emitLimit.Value >= 1));
                
            }
            finally
            {
            }
            
            return null;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.Backup.Model.ListBackupJobsResponse CallAWSServiceOperation(IAmazonBackup client, Amazon.Backup.Model.ListBackupJobsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Backup", "ListBackupJobs");
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
            public System.String ByBackupVaultName { get; set; }
            public System.DateTime? ByCreatedAfter { get; set; }
            public System.DateTime? ByCreatedBefore { get; set; }
            public System.String ByResourceArn { get; set; }
            public System.String ByResourceType { get; set; }
            public Amazon.Backup.BackupJobState ByState { get; set; }
            public int? MaxResults { get; set; }
            public System.String NextToken { get; set; }
        }
        
    }
}
