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
using Amazon.Backup;
using Amazon.Backup.Model;

namespace Amazon.PowerShell.Cmdlets.BAK
{
    /// <summary>
    /// This is a request for a summary of scan jobs created or running within the most recent
    /// 30 days.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "BAKScanJobSummaryList")]
    [OutputType("Amazon.Backup.Model.ListScanJobSummariesResponse")]
    [AWSCmdlet("Calls the AWS Backup ListScanJobSummaries API operation.", Operation = new[] {"ListScanJobSummaries"}, SelectReturnType = typeof(Amazon.Backup.Model.ListScanJobSummariesResponse))]
    [AWSCmdletOutput("Amazon.Backup.Model.ListScanJobSummariesResponse",
        "This cmdlet returns an Amazon.Backup.Model.ListScanJobSummariesResponse object containing multiple properties."
    )]
    public partial class GetBAKScanJobSummaryListCmdlet : AmazonBackupClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// <para>Returns the job count for the specified account.</para><para>If the request is sent from a member account or an account not part of Amazon Web
        /// Services Organizations, jobs within requestor's account will be returned.</para><para>Root, admin, and delegated administrator accounts can use the value <c>ANY</c> to
        /// return job counts from every account in the organization.</para><para><c>AGGREGATE_ALL</c> aggregates job counts from all accounts within the authenticated
        /// organization, then returns the sum.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AccountId { get; set; }
        #endregion
        
        #region Parameter AggregationPeriod
        /// <summary>
        /// <para>
        /// <para>The period for the returned results.</para><ul><li><para><c>ONE_DAY</c>The daily job count for the prior 1 day.</para></li><li><para><c>SEVEN_DAYS</c>The daily job count for the prior 7 days.</para></li><li><para><c>FOURTEEN_DAYS</c>The daily job count for the prior 14 days.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Backup.AggregationPeriod")]
        public Amazon.Backup.AggregationPeriod AggregationPeriod { get; set; }
        #endregion
        
        #region Parameter MalwareScanner
        /// <summary>
        /// <para>
        /// <para>Returns only the scan jobs for the specified malware scanner. Currently the only MalwareScanner
        /// is <c>GUARDDUTY</c>. But the field also supports <c>ANY</c>, and <c>AGGREGATE_ALL</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Backup.MalwareScanner")]
        public Amazon.Backup.MalwareScanner MalwareScanner { get; set; }
        #endregion
        
        #region Parameter ResourceType
        /// <summary>
        /// <para>
        /// <para>Returns the job count for the specified resource type. Use request <c>GetSupportedResourceTypes</c>
        /// to obtain strings for supported resource types.</para><para>The the value <c>ANY</c> returns count of all resource types.</para><para><c>AGGREGATE_ALL</c> aggregates job counts for all resource types and returns the
        /// sum.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResourceType { get; set; }
        #endregion
        
        #region Parameter ScanResultStatus
        /// <summary>
        /// <para>
        /// <para>Returns only the scan jobs for the specified scan results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Backup.ScanResultStatus")]
        public Amazon.Backup.ScanResultStatus ScanResultStatus { get; set; }
        #endregion
        
        #region Parameter State
        /// <summary>
        /// <para>
        /// <para>Returns only the scan jobs for the specified scanning job state.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Backup.ScanJobStatus")]
        public Amazon.Backup.ScanJobStatus State { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of items to be returned.</para><para>The value is an integer. Range of accepted values is from 1 to 500.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
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
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Backup.Model.ListScanJobSummariesResponse).
        /// Specifying the name of a property of type Amazon.Backup.Model.ListScanJobSummariesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Backup.Model.ListScanJobSummariesResponse, GetBAKScanJobSummaryListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AccountId = this.AccountId;
            context.AggregationPeriod = this.AggregationPeriod;
            context.MalwareScanner = this.MalwareScanner;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.ResourceType = this.ResourceType;
            context.ScanResultStatus = this.ScanResultStatus;
            context.State = this.State;
            
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
            var request = new Amazon.Backup.Model.ListScanJobSummariesRequest();
            
            if (cmdletContext.AccountId != null)
            {
                request.AccountId = cmdletContext.AccountId;
            }
            if (cmdletContext.AggregationPeriod != null)
            {
                request.AggregationPeriod = cmdletContext.AggregationPeriod;
            }
            if (cmdletContext.MalwareScanner != null)
            {
                request.MalwareScanner = cmdletContext.MalwareScanner;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.ResourceType != null)
            {
                request.ResourceType = cmdletContext.ResourceType;
            }
            if (cmdletContext.ScanResultStatus != null)
            {
                request.ScanResultStatus = cmdletContext.ScanResultStatus;
            }
            if (cmdletContext.State != null)
            {
                request.State = cmdletContext.State;
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
        
        private Amazon.Backup.Model.ListScanJobSummariesResponse CallAWSServiceOperation(IAmazonBackup client, Amazon.Backup.Model.ListScanJobSummariesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Backup", "ListScanJobSummaries");
            try
            {
                #if DESKTOP
                return client.ListScanJobSummaries(request);
                #elif CORECLR
                return client.ListScanJobSummariesAsync(request).GetAwaiter().GetResult();
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
            public System.String AccountId { get; set; }
            public Amazon.Backup.AggregationPeriod AggregationPeriod { get; set; }
            public Amazon.Backup.MalwareScanner MalwareScanner { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String ResourceType { get; set; }
            public Amazon.Backup.ScanResultStatus ScanResultStatus { get; set; }
            public Amazon.Backup.ScanJobStatus State { get; set; }
            public System.Func<Amazon.Backup.Model.ListScanJobSummariesResponse, GetBAKScanJobSummaryListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
