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

namespace Amazon.PowerShell.Cmdlets.BAK
{
    /// <summary>
    /// Returns details about your report jobs.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "BAKReportJobList")]
    [OutputType("Amazon.Backup.Model.ReportJob")]
    [AWSCmdlet("Calls the AWS Backup ListReportJobs API operation.", Operation = new[] {"ListReportJobs"}, SelectReturnType = typeof(Amazon.Backup.Model.ListReportJobsResponse))]
    [AWSCmdletOutput("Amazon.Backup.Model.ReportJob or Amazon.Backup.Model.ListReportJobsResponse",
        "This cmdlet returns a collection of Amazon.Backup.Model.ReportJob objects.",
        "The service call response (type Amazon.Backup.Model.ListReportJobsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetBAKReportJobListCmdlet : AmazonBackupClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ByCreationAfter
        /// <summary>
        /// <para>
        /// <para>Returns only report jobs that were created after the date and time specified in Unix
        /// format and Coordinated Universal Time (UTC). For example, the value 1516925490 represents
        /// Friday, January 26, 2018 12:11:30 AM.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? ByCreationAfter { get; set; }
        #endregion
        
        #region Parameter ByCreationBefore
        /// <summary>
        /// <para>
        /// <para>Returns only report jobs that were created before the date and time specified in Unix
        /// format and Coordinated Universal Time (UTC). For example, the value 1516925490 represents
        /// Friday, January 26, 2018 12:11:30 AM.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? ByCreationBefore { get; set; }
        #endregion
        
        #region Parameter ByReportPlanName
        /// <summary>
        /// <para>
        /// <para>Returns only report jobs with the specified report plan name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ByReportPlanName { get; set; }
        #endregion
        
        #region Parameter ByStatus
        /// <summary>
        /// <para>
        /// <para>Returns only report jobs that are in the specified status. The statuses are:</para><para><c>CREATED | RUNNING | COMPLETED | FAILED</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ByStatus { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The number of desired results from 1 to 1000. Optional. If unspecified, the query
        /// will return 1 MB of data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>An identifier that was returned from the previous call to this operation, which can
        /// be used to return the next set of items in the list.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ReportJobs'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Backup.Model.ListReportJobsResponse).
        /// Specifying the name of a property of type Amazon.Backup.Model.ListReportJobsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ReportJobs";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Backup.Model.ListReportJobsResponse, GetBAKReportJobListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ByCreationAfter = this.ByCreationAfter;
            context.ByCreationBefore = this.ByCreationBefore;
            context.ByReportPlanName = this.ByReportPlanName;
            context.ByStatus = this.ByStatus;
            context.MaxResult = this.MaxResult;
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
            var request = new Amazon.Backup.Model.ListReportJobsRequest();
            
            if (cmdletContext.ByCreationAfter != null)
            {
                request.ByCreationAfter = cmdletContext.ByCreationAfter.Value;
            }
            if (cmdletContext.ByCreationBefore != null)
            {
                request.ByCreationBefore = cmdletContext.ByCreationBefore.Value;
            }
            if (cmdletContext.ByReportPlanName != null)
            {
                request.ByReportPlanName = cmdletContext.ByReportPlanName;
            }
            if (cmdletContext.ByStatus != null)
            {
                request.ByStatus = cmdletContext.ByStatus;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
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
        
        private Amazon.Backup.Model.ListReportJobsResponse CallAWSServiceOperation(IAmazonBackup client, Amazon.Backup.Model.ListReportJobsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Backup", "ListReportJobs");
            try
            {
                return client.ListReportJobsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.DateTime? ByCreationAfter { get; set; }
            public System.DateTime? ByCreationBefore { get; set; }
            public System.String ByReportPlanName { get; set; }
            public System.String ByStatus { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.Backup.Model.ListReportJobsResponse, GetBAKReportJobListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ReportJobs;
        }
        
    }
}
