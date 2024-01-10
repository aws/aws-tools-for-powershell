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
using Amazon.DataPipeline;
using Amazon.DataPipeline.Model;

namespace Amazon.PowerShell.Cmdlets.DP
{
    /// <summary>
    /// Task runners call <c>ReportTaskRunnerHeartbeat</c> every 15 minutes to indicate that
    /// they are operational. If the AWS Data Pipeline Task Runner is launched on a resource
    /// managed by AWS Data Pipeline, the web service can use this call to detect when the
    /// task runner application has failed and restart a new instance.
    /// </summary>
    [Cmdlet("Update", "DPTaskRunnerHeartbeat", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.Boolean")]
    [AWSCmdlet("Calls the AWS Data Pipeline ReportTaskRunnerHeartbeat API operation.", Operation = new[] {"ReportTaskRunnerHeartbeat"}, SelectReturnType = typeof(Amazon.DataPipeline.Model.ReportTaskRunnerHeartbeatResponse))]
    [AWSCmdletOutput("System.Boolean or Amazon.DataPipeline.Model.ReportTaskRunnerHeartbeatResponse",
        "This cmdlet returns a System.Boolean object.",
        "The service call response (type Amazon.DataPipeline.Model.ReportTaskRunnerHeartbeatResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateDPTaskRunnerHeartbeatCmdlet : AmazonDataPipelineClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Hostname
        /// <summary>
        /// <para>
        /// <para>The public DNS name of the task runner.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        public System.String Hostname { get; set; }
        #endregion
        
        #region Parameter TaskrunnerId
        /// <summary>
        /// <para>
        /// <para>The ID of the task runner. This value should be unique across your AWS account. In
        /// the case of AWS Data Pipeline Task Runner launched on a resource managed by AWS Data
        /// Pipeline, the web service provides a unique identifier when it launches the application.
        /// If you have written a custom task runner, you should assign a unique identifier for
        /// the task runner.</para>
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
        public System.String TaskrunnerId { get; set; }
        #endregion
        
        #region Parameter WorkerGroup
        /// <summary>
        /// <para>
        /// <para>The type of task the task runner is configured to accept and process. The worker group
        /// is set as a field on objects in the pipeline when they are created. You can only specify
        /// a single value for <c>workerGroup</c>. There are no wildcard values permitted in <c>workerGroup</c>;
        /// the string must be an exact, case-sensitive, match.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String WorkerGroup { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Terminate'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DataPipeline.Model.ReportTaskRunnerHeartbeatResponse).
        /// Specifying the name of a property of type Amazon.DataPipeline.Model.ReportTaskRunnerHeartbeatResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Terminate";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the TaskrunnerId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^TaskrunnerId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^TaskrunnerId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TaskrunnerId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-DPTaskRunnerHeartbeat (ReportTaskRunnerHeartbeat)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DataPipeline.Model.ReportTaskRunnerHeartbeatResponse, UpdateDPTaskRunnerHeartbeatCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.TaskrunnerId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Hostname = this.Hostname;
            context.TaskrunnerId = this.TaskrunnerId;
            #if MODULAR
            if (this.TaskrunnerId == null && ParameterWasBound(nameof(this.TaskrunnerId)))
            {
                WriteWarning("You are passing $null as a value for parameter TaskrunnerId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.WorkerGroup = this.WorkerGroup;
            
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
            var request = new Amazon.DataPipeline.Model.ReportTaskRunnerHeartbeatRequest();
            
            if (cmdletContext.Hostname != null)
            {
                request.Hostname = cmdletContext.Hostname;
            }
            if (cmdletContext.TaskrunnerId != null)
            {
                request.TaskrunnerId = cmdletContext.TaskrunnerId;
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
        
        private Amazon.DataPipeline.Model.ReportTaskRunnerHeartbeatResponse CallAWSServiceOperation(IAmazonDataPipeline client, Amazon.DataPipeline.Model.ReportTaskRunnerHeartbeatRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Data Pipeline", "ReportTaskRunnerHeartbeat");
            try
            {
                #if DESKTOP
                return client.ReportTaskRunnerHeartbeat(request);
                #elif CORECLR
                return client.ReportTaskRunnerHeartbeatAsync(request).GetAwaiter().GetResult();
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
            public System.String Hostname { get; set; }
            public System.String TaskrunnerId { get; set; }
            public System.String WorkerGroup { get; set; }
            public System.Func<Amazon.DataPipeline.Model.ReportTaskRunnerHeartbeatResponse, UpdateDPTaskRunnerHeartbeatCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Terminate;
        }
        
    }
}
