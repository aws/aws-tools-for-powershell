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
using Amazon.DataPipeline;
using Amazon.DataPipeline.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.DP
{
    /// <summary>
    /// Task runners call <c>SetTaskStatus</c> to notify AWS Data Pipeline that a task is
    /// completed and provide information about the final status. A task runner makes this
    /// call regardless of whether the task was sucessful. A task runner does not need to
    /// call <c>SetTaskStatus</c> for tasks that are canceled by the web service during a
    /// call to <a>ReportTaskProgress</a>.
    /// </summary>
    [Cmdlet("Set", "DPTaskStatus", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Data Pipeline SetTaskStatus API operation.", Operation = new[] {"SetTaskStatus"}, SelectReturnType = typeof(Amazon.DataPipeline.Model.SetTaskStatusResponse))]
    [AWSCmdletOutput("None or Amazon.DataPipeline.Model.SetTaskStatusResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.DataPipeline.Model.SetTaskStatusResponse) be returned by specifying '-Select *'."
    )]
    public partial class SetDPTaskStatusCmdlet : AmazonDataPipelineClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ErrorId
        /// <summary>
        /// <para>
        /// <para>If an error occurred during the task, this value specifies the error code. This value
        /// is set on the physical attempt object. It is used to display error information to
        /// the user. It should not start with string "Service_" which is reserved by the system.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        public System.String ErrorId { get; set; }
        #endregion
        
        #region Parameter ErrorMessage
        /// <summary>
        /// <para>
        /// <para>If an error occurred during the task, this value specifies a text description of the
        /// error. This value is set on the physical attempt object. It is used to display error
        /// information to the user. The web service does not parse this value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3, ValueFromPipelineByPropertyName = true)]
        public System.String ErrorMessage { get; set; }
        #endregion
        
        #region Parameter ErrorStackTrace
        /// <summary>
        /// <para>
        /// <para>If an error occurred during the task, this value specifies the stack trace associated
        /// with the error. This value is set on the physical attempt object. It is used to display
        /// error information to the user. The web service does not parse this value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 4, ValueFromPipelineByPropertyName = true)]
        public System.String ErrorStackTrace { get; set; }
        #endregion
        
        #region Parameter TaskId
        /// <summary>
        /// <para>
        /// <para>The ID of the task assigned to the task runner. This value is provided in the response
        /// for <a>PollForTask</a>.</para>
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
        public System.String TaskId { get; set; }
        #endregion
        
        #region Parameter TaskStatus
        /// <summary>
        /// <para>
        /// <para>If <c>FINISHED</c>, the task successfully completed. If <c>FAILED</c>, the task ended
        /// unsuccessfully. Preconditions use false.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.DataPipeline.TaskStatus")]
        public Amazon.DataPipeline.TaskStatus TaskStatus { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DataPipeline.Model.SetTaskStatusResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TaskId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-DPTaskStatus (SetTaskStatus)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DataPipeline.Model.SetTaskStatusResponse, SetDPTaskStatusCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ErrorId = this.ErrorId;
            context.ErrorMessage = this.ErrorMessage;
            context.ErrorStackTrace = this.ErrorStackTrace;
            context.TaskId = this.TaskId;
            #if MODULAR
            if (this.TaskId == null && ParameterWasBound(nameof(this.TaskId)))
            {
                WriteWarning("You are passing $null as a value for parameter TaskId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TaskStatus = this.TaskStatus;
            #if MODULAR
            if (this.TaskStatus == null && ParameterWasBound(nameof(this.TaskStatus)))
            {
                WriteWarning("You are passing $null as a value for parameter TaskStatus which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.DataPipeline.Model.SetTaskStatusRequest();
            
            if (cmdletContext.ErrorId != null)
            {
                request.ErrorId = cmdletContext.ErrorId;
            }
            if (cmdletContext.ErrorMessage != null)
            {
                request.ErrorMessage = cmdletContext.ErrorMessage;
            }
            if (cmdletContext.ErrorStackTrace != null)
            {
                request.ErrorStackTrace = cmdletContext.ErrorStackTrace;
            }
            if (cmdletContext.TaskId != null)
            {
                request.TaskId = cmdletContext.TaskId;
            }
            if (cmdletContext.TaskStatus != null)
            {
                request.TaskStatus = cmdletContext.TaskStatus;
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
        
        private Amazon.DataPipeline.Model.SetTaskStatusResponse CallAWSServiceOperation(IAmazonDataPipeline client, Amazon.DataPipeline.Model.SetTaskStatusRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Data Pipeline", "SetTaskStatus");
            try
            {
                return client.SetTaskStatusAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ErrorId { get; set; }
            public System.String ErrorMessage { get; set; }
            public System.String ErrorStackTrace { get; set; }
            public System.String TaskId { get; set; }
            public Amazon.DataPipeline.TaskStatus TaskStatus { get; set; }
            public System.Func<Amazon.DataPipeline.Model.SetTaskStatusResponse, SetDPTaskStatusCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
