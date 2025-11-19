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
using Amazon.Backup;
using Amazon.Backup.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.BAK
{
    /// <summary>
    /// Returns a list of existing scan jobs for an authenticated account for the last 30
    /// days.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "BAKScanJobList")]
    [OutputType("Amazon.Backup.Model.ScanJob")]
    [AWSCmdlet("Calls the AWS Backup ListScanJobs API operation.", Operation = new[] {"ListScanJobs"}, SelectReturnType = typeof(Amazon.Backup.Model.ListScanJobsResponse))]
    [AWSCmdletOutput("Amazon.Backup.Model.ScanJob or Amazon.Backup.Model.ListScanJobsResponse",
        "This cmdlet returns a collection of Amazon.Backup.Model.ScanJob objects.",
        "The service call response (type Amazon.Backup.Model.ListScanJobsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetBAKScanJobListCmdlet : AmazonBackupClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ByAccountId
        /// <summary>
        /// <para>
        /// <para>The account ID to list the jobs from. Returns only backup jobs associated with the
        /// specified account ID.</para><para>If used from an Amazon Web Services Organizations management account, passing <c>*</c>
        /// returns all jobs across the organization.</para><para>Pattern: <c>^[0-9]{12}$</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ByAccountId { get; set; }
        #endregion
        
        #region Parameter ByBackupVaultName
        /// <summary>
        /// <para>
        /// <para>Returns only scan jobs that will be stored in the specified backup vault. Backup vaults
        /// are identified by names that are unique to the account used to create them and the
        /// Amazon Web Services Region where they are created.</para><para>Pattern: <c>^[a-zA-Z0-9\-\_\.]{2,50}$</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ByBackupVaultName { get; set; }
        #endregion
        
        #region Parameter ByCompleteAfter
        /// <summary>
        /// <para>
        /// <para>Returns only scan jobs completed after a date expressed in Unix format and Coordinated
        /// Universal Time (UTC).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? ByCompleteAfter { get; set; }
        #endregion
        
        #region Parameter ByCompleteBefore
        /// <summary>
        /// <para>
        /// <para>Returns only backup jobs completed before a date expressed in Unix format and Coordinated
        /// Universal Time (UTC).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? ByCompleteBefore { get; set; }
        #endregion
        
        #region Parameter ByMalwareScanner
        /// <summary>
        /// <para>
        /// <para>Returns only the scan jobs for the specified malware scanner. Currently only supports
        /// <c>GUARDDUTY</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Backup.MalwareScanner")]
        public Amazon.Backup.MalwareScanner ByMalwareScanner { get; set; }
        #endregion
        
        #region Parameter ByRecoveryPointArn
        /// <summary>
        /// <para>
        /// <para>Returns only the scan jobs that are ran against the specified recovery point.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ByRecoveryPointArn { get; set; }
        #endregion
        
        #region Parameter ByResourceArn
        /// <summary>
        /// <para>
        /// <para>Returns only scan jobs that match the specified resource Amazon Resource Name (ARN).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ByResourceArn { get; set; }
        #endregion
        
        #region Parameter ByResourceType
        /// <summary>
        /// <para>
        /// <para>Returns restore testing selections by the specified restore testing plan name.</para><ul><li><para><c>EBS</c>for Amazon Elastic Block Store</para></li><li><para><c>EC2</c>for Amazon Elastic Compute Cloud</para></li><li><para><c>S3</c>for Amazon Simple Storage Service (Amazon S3)</para></li></ul><para>Pattern: <c>^[a-zA-Z0-9\-\_\.]{1,50}$</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Backup.ScanResourceType")]
        public Amazon.Backup.ScanResourceType ByResourceType { get; set; }
        #endregion
        
        #region Parameter ByScanResultStatus
        /// <summary>
        /// <para>
        /// <para>Returns only the scan jobs for the specified scan results:</para><ul><li><para><c>THREATS_FOUND</c></para></li><li><para><c>NO_THREATS_FOUND</c></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Backup.ScanResultStatus")]
        public Amazon.Backup.ScanResultStatus ByScanResultStatus { get; set; }
        #endregion
        
        #region Parameter ByState
        /// <summary>
        /// <para>
        /// <para>Returns only the scan jobs for the specified scanning job state.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Backup.ScanState")]
        public Amazon.Backup.ScanState ByState { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of items to be returned.</para><para>Valid Range: Minimum value of 1. Maximum value of 1000.</para>
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
        /// is made to return <c>MaxResults</c> number of items, <c>NextToken</c> allows you to
        /// return more items in your list starting at the location pointed to by the next token.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ScanJobs'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Backup.Model.ListScanJobsResponse).
        /// Specifying the name of a property of type Amazon.Backup.Model.ListScanJobsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ScanJobs";
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
                context.Select = CreateSelectDelegate<Amazon.Backup.Model.ListScanJobsResponse, GetBAKScanJobListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ByAccountId = this.ByAccountId;
            context.ByBackupVaultName = this.ByBackupVaultName;
            context.ByCompleteAfter = this.ByCompleteAfter;
            context.ByCompleteBefore = this.ByCompleteBefore;
            context.ByMalwareScanner = this.ByMalwareScanner;
            context.ByRecoveryPointArn = this.ByRecoveryPointArn;
            context.ByResourceArn = this.ByResourceArn;
            context.ByResourceType = this.ByResourceType;
            context.ByScanResultStatus = this.ByScanResultStatus;
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
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.Backup.Model.ListScanJobsRequest();
            
            if (cmdletContext.ByAccountId != null)
            {
                request.ByAccountId = cmdletContext.ByAccountId;
            }
            if (cmdletContext.ByBackupVaultName != null)
            {
                request.ByBackupVaultName = cmdletContext.ByBackupVaultName;
            }
            if (cmdletContext.ByCompleteAfter != null)
            {
                request.ByCompleteAfter = cmdletContext.ByCompleteAfter.Value;
            }
            if (cmdletContext.ByCompleteBefore != null)
            {
                request.ByCompleteBefore = cmdletContext.ByCompleteBefore.Value;
            }
            if (cmdletContext.ByMalwareScanner != null)
            {
                request.ByMalwareScanner = cmdletContext.ByMalwareScanner;
            }
            if (cmdletContext.ByRecoveryPointArn != null)
            {
                request.ByRecoveryPointArn = cmdletContext.ByRecoveryPointArn;
            }
            if (cmdletContext.ByResourceArn != null)
            {
                request.ByResourceArn = cmdletContext.ByResourceArn;
            }
            if (cmdletContext.ByResourceType != null)
            {
                request.ByResourceType = cmdletContext.ByResourceType;
            }
            if (cmdletContext.ByScanResultStatus != null)
            {
                request.ByScanResultStatus = cmdletContext.ByScanResultStatus;
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
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.Backup.Model.ListScanJobsResponse CallAWSServiceOperation(IAmazonBackup client, Amazon.Backup.Model.ListScanJobsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Backup", "ListScanJobs");
            try
            {
                return client.ListScanJobsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.DateTime? ByCompleteAfter { get; set; }
            public System.DateTime? ByCompleteBefore { get; set; }
            public Amazon.Backup.MalwareScanner ByMalwareScanner { get; set; }
            public System.String ByRecoveryPointArn { get; set; }
            public System.String ByResourceArn { get; set; }
            public Amazon.Backup.ScanResourceType ByResourceType { get; set; }
            public Amazon.Backup.ScanResultStatus ByScanResultStatus { get; set; }
            public Amazon.Backup.ScanState ByState { get; set; }
            public int? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.Backup.Model.ListScanJobsResponse, GetBAKScanJobListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ScanJobs;
        }
        
    }
}
