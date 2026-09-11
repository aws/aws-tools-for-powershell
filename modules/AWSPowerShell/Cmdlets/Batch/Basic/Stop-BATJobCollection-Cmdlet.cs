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
using Amazon.Batch;
using Amazon.Batch.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.BAT
{
    /// <summary>
    /// Cancels up to 50 jobs in an Batch job queue. This is a bulk version of <a>CancelJob</a>.
    /// Jobs that are in a <c>SUBMITTED</c>, <c>PENDING</c>, or <c>RUNNABLE</c> state are
    /// cancelled and the job status is updated to <c>FAILED</c>.
    /// 
    ///  <note><para>
    /// A <c>PENDING</c> job is cancelled after all dependency jobs are completed. Therefore,
    /// it might take longer than expected to cancel a job in <c>PENDING</c> status.
    /// </para><para>
    /// When you try to cancel an array parent job in <c>PENDING</c>, Batch attempts to cancel
    /// all child jobs. The array parent job is cancelled when all child jobs are completed.
    /// </para></note><para>
    /// Jobs that progressed to the <c>STARTING</c> or <c>RUNNING</c> state aren't cancelled.
    /// These jobs must be terminated with the <a>TerminateJob</a> or <a>TerminateJobs</a>
    /// operation.
    /// </para><para>
    /// Batch reports the result for each job individually in the response. Jobs that were
    /// processed successfully are reported in the <c>successful</c> list. Jobs that encountered
    /// errors are reported in the <c>errors</c> list. The response returns an HTTP status
    /// code of <c>200</c> even when some jobs encountered errors, so check the <c>errors</c>
    /// list. Jobs that can't be found are treated as successfully processed.
    /// </para>
    /// </summary>
    [Cmdlet("Stop", "BATJobCollection", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Batch.Model.CancelJobsResponse")]
    [AWSCmdlet("Calls the AWS Batch CancelJobs API operation.", Operation = new[] {"CancelJobs"}, SelectReturnType = typeof(Amazon.Batch.Model.CancelJobsResponse))]
    [AWSCmdletOutput("Amazon.Batch.Model.CancelJobsResponse",
        "This cmdlet returns an Amazon.Batch.Model.CancelJobsResponse object containing multiple properties."
    )]
    public partial class StopBATJobCollectionCmdlet : AmazonBatchClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Job
        /// <summary>
        /// <para>
        /// <para>An array of up to 50 Batch job IDs of the jobs to cancel.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Jobs")]
        public System.String[] Job { get; set; }
        #endregion
        
        #region Parameter Reason
        /// <summary>
        /// <para>
        /// <para>A message to attach to the job that explains the reason for cancelling it. This message
        /// is returned by future <a>DescribeJobs</a> operations on the job. It is also recorded
        /// in the Batch activity logs.</para><para>This parameter has a limit of 1024 characters.</para>
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
        public System.String Reason { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Batch.Model.CancelJobsResponse).
        /// Specifying the name of a property of type Amazon.Batch.Model.CancelJobsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Job), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Stop-BATJobCollection (CancelJobs)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Batch.Model.CancelJobsResponse, StopBATJobCollectionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Job != null)
            {
                context.Job = new List<System.String>(this.Job);
            }
            #if MODULAR
            if (this.Job == null && ParameterWasBound(nameof(this.Job)))
            {
                WriteWarning("You are passing $null as a value for parameter Job which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Reason = this.Reason;
            #if MODULAR
            if (this.Reason == null && ParameterWasBound(nameof(this.Reason)))
            {
                WriteWarning("You are passing $null as a value for parameter Reason which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Batch.Model.CancelJobsRequest();
            
            if (cmdletContext.Job != null)
            {
                request.Jobs = cmdletContext.Job;
            }
            if (cmdletContext.Reason != null)
            {
                request.Reason = cmdletContext.Reason;
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
        
        private Amazon.Batch.Model.CancelJobsResponse CallAWSServiceOperation(IAmazonBatch client, Amazon.Batch.Model.CancelJobsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Batch", "CancelJobs");
            try
            {
                return client.CancelJobsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> Job { get; set; }
            public System.String Reason { get; set; }
            public System.Func<Amazon.Batch.Model.CancelJobsResponse, StopBATJobCollectionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
