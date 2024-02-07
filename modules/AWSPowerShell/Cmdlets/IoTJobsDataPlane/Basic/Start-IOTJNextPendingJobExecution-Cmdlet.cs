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
using Amazon.IoTJobsDataPlane;
using Amazon.IoTJobsDataPlane.Model;

namespace Amazon.PowerShell.Cmdlets.IOTJ
{
    /// <summary>
    /// Gets and starts the next pending (status IN_PROGRESS or QUEUED) job execution for
    /// a thing.
    /// </summary>
    [Cmdlet("Start", "IOTJNextPendingJobExecution", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoTJobsDataPlane.Model.JobExecution")]
    [AWSCmdlet("Calls the AWS IoT Jobs Data Plane StartNextPendingJobExecution API operation.", Operation = new[] {"StartNextPendingJobExecution"}, SelectReturnType = typeof(Amazon.IoTJobsDataPlane.Model.StartNextPendingJobExecutionResponse))]
    [AWSCmdletOutput("Amazon.IoTJobsDataPlane.Model.JobExecution or Amazon.IoTJobsDataPlane.Model.StartNextPendingJobExecutionResponse",
        "This cmdlet returns an Amazon.IoTJobsDataPlane.Model.JobExecution object.",
        "The service call response (type Amazon.IoTJobsDataPlane.Model.StartNextPendingJobExecutionResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartIOTJNextPendingJobExecutionCmdlet : AmazonIoTJobsDataPlaneClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter StatusDetail
        /// <summary>
        /// <para>
        /// <para>A collection of name/value pairs that describe the status of the job execution. If
        /// not specified, the statusDetails are unchanged.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StatusDetails")]
        public System.Collections.Hashtable StatusDetail { get; set; }
        #endregion
        
        #region Parameter StepTimeoutInMinute
        /// <summary>
        /// <para>
        /// <para>Specifies the amount of time this device has to finish execution of this job. If the
        /// job execution status is not set to a terminal state before this timer expires, or
        /// before the timer is reset (by calling <c>UpdateJobExecution</c>, setting the status
        /// to <c>IN_PROGRESS</c> and specifying a new timeout value in field <c>stepTimeoutInMinutes</c>)
        /// the job execution status will be automatically set to <c>TIMED_OUT</c>. Note that
        /// setting this timeout has no effect on that job execution timeout which may have been
        /// specified when the job was created (<c>CreateJob</c> using field <c>timeoutConfig</c>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StepTimeoutInMinutes")]
        public System.Int64? StepTimeoutInMinute { get; set; }
        #endregion
        
        #region Parameter ThingName
        /// <summary>
        /// <para>
        /// <para>The name of the thing associated with the device.</para>
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
        public System.String ThingName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Execution'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTJobsDataPlane.Model.StartNextPendingJobExecutionResponse).
        /// Specifying the name of a property of type Amazon.IoTJobsDataPlane.Model.StartNextPendingJobExecutionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Execution";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ThingName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ThingName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ThingName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ThingName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-IOTJNextPendingJobExecution (StartNextPendingJobExecution)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTJobsDataPlane.Model.StartNextPendingJobExecutionResponse, StartIOTJNextPendingJobExecutionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ThingName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.StatusDetail != null)
            {
                context.StatusDetail = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.StatusDetail.Keys)
                {
                    context.StatusDetail.Add((String)hashKey, (System.String)(this.StatusDetail[hashKey]));
                }
            }
            context.StepTimeoutInMinute = this.StepTimeoutInMinute;
            context.ThingName = this.ThingName;
            #if MODULAR
            if (this.ThingName == null && ParameterWasBound(nameof(this.ThingName)))
            {
                WriteWarning("You are passing $null as a value for parameter ThingName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.IoTJobsDataPlane.Model.StartNextPendingJobExecutionRequest();
            
            if (cmdletContext.StatusDetail != null)
            {
                request.StatusDetails = cmdletContext.StatusDetail;
            }
            if (cmdletContext.StepTimeoutInMinute != null)
            {
                request.StepTimeoutInMinutes = cmdletContext.StepTimeoutInMinute.Value;
            }
            if (cmdletContext.ThingName != null)
            {
                request.ThingName = cmdletContext.ThingName;
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
        
        private Amazon.IoTJobsDataPlane.Model.StartNextPendingJobExecutionResponse CallAWSServiceOperation(IAmazonIoTJobsDataPlane client, Amazon.IoTJobsDataPlane.Model.StartNextPendingJobExecutionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT Jobs Data Plane", "StartNextPendingJobExecution");
            try
            {
                #if DESKTOP
                return client.StartNextPendingJobExecution(request);
                #elif CORECLR
                return client.StartNextPendingJobExecutionAsync(request).GetAwaiter().GetResult();
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
            public Dictionary<System.String, System.String> StatusDetail { get; set; }
            public System.Int64? StepTimeoutInMinute { get; set; }
            public System.String ThingName { get; set; }
            public System.Func<Amazon.IoTJobsDataPlane.Model.StartNextPendingJobExecutionResponse, StartIOTJNextPendingJobExecutionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Execution;
        }
        
    }
}
