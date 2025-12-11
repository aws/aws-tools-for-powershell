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
using Amazon.QuickSight;
using Amazon.QuickSight.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.QS
{
    /// <summary>
    /// Describes the result of an existing snapshot job that has finished running.
    /// 
    ///  
    /// <para>
    /// A finished snapshot job will return a <c>COMPLETED</c> or <c>FAILED</c> status when
    /// you poll the job with a <c>DescribeDashboardSnapshotJob</c> API call.
    /// </para><para>
    /// If the job has not finished running, this operation returns a message that says <c>Dashboard
    /// Snapshot Job with id &lt;SnapshotjobId&gt; has not reached a terminal state.</c>.
    /// </para><para><b>Registered user support</b></para><para>
    /// This API can be called as before to get the result of a job started by the same Quick
    /// Sight user. The result for the user will be returned in <c>RegisteredUsers</c> response
    /// attribute. The attribute will contain a list with at most one object in it.
    /// </para><para><b>Possible error scenarios</b></para><para>
    /// The request fails with an Access Denied error in the following scenarios:
    /// </para><ul><li><para>
    /// The credentials have expired.
    /// </para></li><li><para>
    /// The job was started by a different user.
    /// </para></li><li><para>
    /// The registered user doesn't have access to the specified dashboard.
    /// </para></li></ul><para>
    /// The request succeeds but the job fails in the following scenarios:
    /// </para><ul><li><para><c>DASHBOARD_ACCESS_DENIED</c> - The registered user lost access to the dashboard.
    /// </para></li><li><para><c>CAPABILITY_RESTRICTED</c> - The registered user is restricted from exporting data
    /// in <b>all</b> selected formats.
    /// </para></li></ul><para>
    /// The request succeeds but the response contains an error code in the following scenarios:
    /// </para><ul><li><para><c>CAPABILITY_RESTRICTED</c> - The registered user is restricted from exporting data
    /// in <b>some</b> selected formats.
    /// </para></li><li><para><c>RLS_CHANGED</c> - Row-level security settings have changed. Re-run the job with
    /// current settings.
    /// </para></li><li><para><c>CLS_CHANGED</c> - Column-level security settings have changed. Re-run the job
    /// with current settings.
    /// </para></li><li><para><c>DATASET_DELETED</c> - The dataset has been deleted. Verify the dataset exists
    /// before re-running the job.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Get", "QSDashboardSnapshotJobResult")]
    [OutputType("Amazon.QuickSight.Model.DescribeDashboardSnapshotJobResultResponse")]
    [AWSCmdlet("Calls the Amazon QuickSight DescribeDashboardSnapshotJobResult API operation.", Operation = new[] {"DescribeDashboardSnapshotJobResult"}, SelectReturnType = typeof(Amazon.QuickSight.Model.DescribeDashboardSnapshotJobResultResponse))]
    [AWSCmdletOutput("Amazon.QuickSight.Model.DescribeDashboardSnapshotJobResultResponse",
        "This cmdlet returns an Amazon.QuickSight.Model.DescribeDashboardSnapshotJobResultResponse object containing multiple properties."
    )]
    public partial class GetQSDashboardSnapshotJobResultCmdlet : AmazonQuickSightClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AwsAccountId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Web Services account that the dashboard snapshot job is executed
        /// in.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String AwsAccountId { get; set; }
        #endregion
        
        #region Parameter DashboardId
        /// <summary>
        /// <para>
        /// <para>The ID of the dashboard that you have started a snapshot job for.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String DashboardId { get; set; }
        #endregion
        
        #region Parameter SnapshotJobId
        /// <summary>
        /// <para>
        /// <para>The ID of the job to be described. The job ID is set when you start a new job with
        /// a <c>StartDashboardSnapshotJob</c> API call.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String SnapshotJobId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QuickSight.Model.DescribeDashboardSnapshotJobResultResponse).
        /// Specifying the name of a property of type Amazon.QuickSight.Model.DescribeDashboardSnapshotJobResultResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
                context.Select = CreateSelectDelegate<Amazon.QuickSight.Model.DescribeDashboardSnapshotJobResultResponse, GetQSDashboardSnapshotJobResultCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AwsAccountId = this.AwsAccountId;
            #if MODULAR
            if (this.AwsAccountId == null && ParameterWasBound(nameof(this.AwsAccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AwsAccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DashboardId = this.DashboardId;
            #if MODULAR
            if (this.DashboardId == null && ParameterWasBound(nameof(this.DashboardId)))
            {
                WriteWarning("You are passing $null as a value for parameter DashboardId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SnapshotJobId = this.SnapshotJobId;
            #if MODULAR
            if (this.SnapshotJobId == null && ParameterWasBound(nameof(this.SnapshotJobId)))
            {
                WriteWarning("You are passing $null as a value for parameter SnapshotJobId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.QuickSight.Model.DescribeDashboardSnapshotJobResultRequest();
            
            if (cmdletContext.AwsAccountId != null)
            {
                request.AwsAccountId = cmdletContext.AwsAccountId;
            }
            if (cmdletContext.DashboardId != null)
            {
                request.DashboardId = cmdletContext.DashboardId;
            }
            if (cmdletContext.SnapshotJobId != null)
            {
                request.SnapshotJobId = cmdletContext.SnapshotJobId;
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
        
        private Amazon.QuickSight.Model.DescribeDashboardSnapshotJobResultResponse CallAWSServiceOperation(IAmazonQuickSight client, Amazon.QuickSight.Model.DescribeDashboardSnapshotJobResultRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon QuickSight", "DescribeDashboardSnapshotJobResult");
            try
            {
                return client.DescribeDashboardSnapshotJobResultAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AwsAccountId { get; set; }
            public System.String DashboardId { get; set; }
            public System.String SnapshotJobId { get; set; }
            public System.Func<Amazon.QuickSight.Model.DescribeDashboardSnapshotJobResultResponse, GetQSDashboardSnapshotJobResultCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
