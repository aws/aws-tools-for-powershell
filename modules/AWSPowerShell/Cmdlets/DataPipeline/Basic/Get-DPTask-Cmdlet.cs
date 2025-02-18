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

namespace Amazon.PowerShell.Cmdlets.DP
{
    /// <summary>
    /// Task runners call <c>PollForTask</c> to receive a task to perform from AWS Data Pipeline.
    /// The task runner specifies which tasks it can perform by setting a value for the <c>workerGroup</c>
    /// parameter. The task returned can come from any of the pipelines that match the <c>workerGroup</c>
    /// value passed in by the task runner and that was launched using the IAM user credentials
    /// specified by the task runner.
    /// 
    ///  
    /// <para>
    /// If tasks are ready in the work queue, <c>PollForTask</c> returns a response immediately.
    /// If no tasks are available in the queue, <c>PollForTask</c> uses long-polling and holds
    /// on to a poll connection for up to a 90 seconds, during which time the first newly
    /// scheduled task is handed to the task runner. To accomodate this, set the socket timeout
    /// in your task runner to 90 seconds. The task runner should not call <c>PollForTask</c>
    /// again on the same <c>workerGroup</c> until it receives a response, and this can take
    /// up to 90 seconds. 
    /// </para>
    /// </summary>
    [Cmdlet("Get", "DPTask")]
    [OutputType("Amazon.DataPipeline.Model.TaskObject")]
    [AWSCmdlet("Calls the AWS Data Pipeline PollForTask API operation.", Operation = new[] {"PollForTask"}, SelectReturnType = typeof(Amazon.DataPipeline.Model.PollForTaskResponse))]
    [AWSCmdletOutput("Amazon.DataPipeline.Model.TaskObject or Amazon.DataPipeline.Model.PollForTaskResponse",
        "This cmdlet returns an Amazon.DataPipeline.Model.TaskObject object.",
        "The service call response (type Amazon.DataPipeline.Model.PollForTaskResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetDPTaskCmdlet : AmazonDataPipelineClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter InstanceIdentity_Document
        /// <summary>
        /// <para>
        /// <para>A description of an EC2 instance that is generated when the instance is launched and
        /// exposed to the instance via the instance metadata service in the form of a JSON representation
        /// of an object.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InstanceIdentity_Document { get; set; }
        #endregion
        
        #region Parameter Hostname
        /// <summary>
        /// <para>
        /// <para>The public DNS name of the calling task runner.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String Hostname { get; set; }
        #endregion
        
        #region Parameter InstanceIdentity_Signature
        /// <summary>
        /// <para>
        /// <para>A signature which can be used to verify the accuracy and authenticity of the information
        /// provided in the instance identity document.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InstanceIdentity_Signature { get; set; }
        #endregion
        
        #region Parameter WorkerGroup
        /// <summary>
        /// <para>
        /// <para>The type of task the task runner is configured to accept and process. The worker group
        /// is set as a field on objects in the pipeline when they are created. You can only specify
        /// a single value for <c>workerGroup</c> in the call to <c>PollForTask</c>. There are
        /// no wildcard values permitted in <c>workerGroup</c>; the string must be an exact, case-sensitive,
        /// match.</para>
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
        public System.String WorkerGroup { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TaskObject'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DataPipeline.Model.PollForTaskResponse).
        /// Specifying the name of a property of type Amazon.DataPipeline.Model.PollForTaskResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TaskObject";
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
                context.Select = CreateSelectDelegate<Amazon.DataPipeline.Model.PollForTaskResponse, GetDPTaskCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Hostname = this.Hostname;
            context.InstanceIdentity_Document = this.InstanceIdentity_Document;
            context.InstanceIdentity_Signature = this.InstanceIdentity_Signature;
            context.WorkerGroup = this.WorkerGroup;
            #if MODULAR
            if (this.WorkerGroup == null && ParameterWasBound(nameof(this.WorkerGroup)))
            {
                WriteWarning("You are passing $null as a value for parameter WorkerGroup which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.DataPipeline.Model.PollForTaskRequest();
            
            if (cmdletContext.Hostname != null)
            {
                request.Hostname = cmdletContext.Hostname;
            }
            
             // populate InstanceIdentity
            var requestInstanceIdentityIsNull = true;
            request.InstanceIdentity = new Amazon.DataPipeline.Model.InstanceIdentity();
            System.String requestInstanceIdentity_instanceIdentity_Document = null;
            if (cmdletContext.InstanceIdentity_Document != null)
            {
                requestInstanceIdentity_instanceIdentity_Document = cmdletContext.InstanceIdentity_Document;
            }
            if (requestInstanceIdentity_instanceIdentity_Document != null)
            {
                request.InstanceIdentity.Document = requestInstanceIdentity_instanceIdentity_Document;
                requestInstanceIdentityIsNull = false;
            }
            System.String requestInstanceIdentity_instanceIdentity_Signature = null;
            if (cmdletContext.InstanceIdentity_Signature != null)
            {
                requestInstanceIdentity_instanceIdentity_Signature = cmdletContext.InstanceIdentity_Signature;
            }
            if (requestInstanceIdentity_instanceIdentity_Signature != null)
            {
                request.InstanceIdentity.Signature = requestInstanceIdentity_instanceIdentity_Signature;
                requestInstanceIdentityIsNull = false;
            }
             // determine if request.InstanceIdentity should be set to null
            if (requestInstanceIdentityIsNull)
            {
                request.InstanceIdentity = null;
            }
            if (cmdletContext.WorkerGroup != null)
            {
                request.WorkerGroup = cmdletContext.WorkerGroup;
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
        
        private Amazon.DataPipeline.Model.PollForTaskResponse CallAWSServiceOperation(IAmazonDataPipeline client, Amazon.DataPipeline.Model.PollForTaskRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Data Pipeline", "PollForTask");
            try
            {
                return client.PollForTaskAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Hostname { get; set; }
            public System.String InstanceIdentity_Document { get; set; }
            public System.String InstanceIdentity_Signature { get; set; }
            public System.String WorkerGroup { get; set; }
            public System.Func<Amazon.DataPipeline.Model.PollForTaskResponse, GetDPTaskCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TaskObject;
        }
        
    }
}
