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
using Amazon.IoTJobsDataPlane;
using Amazon.IoTJobsDataPlane.Model;

namespace Amazon.PowerShell.Cmdlets.IOTJ
{
    /// <summary>
    /// Updates the status of a job execution.
    /// </summary>
    [Cmdlet("Update", "IOTJJobExecution", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoTJobsDataPlane.Model.UpdateJobExecutionResponse")]
    [AWSCmdlet("Calls the AWS IoT Jobs Data Plane UpdateJobExecution API operation.", Operation = new[] {"UpdateJobExecution"})]
    [AWSCmdletOutput("Amazon.IoTJobsDataPlane.Model.UpdateJobExecutionResponse",
        "This cmdlet returns a Amazon.IoTJobsDataPlane.Model.UpdateJobExecutionResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateIOTJJobExecutionCmdlet : AmazonIoTJobsDataPlaneClientCmdlet, IExecutor
    {
        
        #region Parameter ExecutionNumber
        /// <summary>
        /// <para>
        /// <para>Optional. A number that identifies a particular job execution on a particular device.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int64 ExecutionNumber { get; set; }
        #endregion
        
        #region Parameter ExpectedVersion
        /// <summary>
        /// <para>
        /// <para>Optional. The expected current version of the job execution. Each time you update
        /// the job execution, its version is incremented. If the version of the job execution
        /// stored in Jobs does not match, the update is rejected with a VersionMismatch error,
        /// and an ErrorResponse that contains the current job execution status data is returned.
        /// (This makes it unnecessary to perform a separate DescribeJobExecution request in order
        /// to obtain the job execution status data.)</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int64 ExpectedVersion { get; set; }
        #endregion
        
        #region Parameter IncludeJobDocument
        /// <summary>
        /// <para>
        /// <para>Optional. When set to true, the response contains the job document. The default is
        /// false.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean IncludeJobDocument { get; set; }
        #endregion
        
        #region Parameter IncludeJobExecutionState
        /// <summary>
        /// <para>
        /// <para>Optional. When included and set to true, the response contains the JobExecutionState
        /// data. The default is false.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean IncludeJobExecutionState { get; set; }
        #endregion
        
        #region Parameter JobId
        /// <summary>
        /// <para>
        /// <para>The unique identifier assigned to this job when it was created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String JobId { get; set; }
        #endregion
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>The new status for the job execution (IN_PROGRESS, FAILED, SUCCESS, or REJECTED).
        /// This must be specified on every update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.IoTJobsDataPlane.JobExecutionStatus")]
        public Amazon.IoTJobsDataPlane.JobExecutionStatus Status { get; set; }
        #endregion
        
        #region Parameter StatusDetail
        /// <summary>
        /// <para>
        /// <para> Optional. A collection of name/value pairs that describe the status of the job execution.
        /// If not specified, the statusDetails are unchanged.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("StatusDetails")]
        public System.Collections.Hashtable StatusDetail { get; set; }
        #endregion
        
        #region Parameter StepTimeoutInMinute
        /// <summary>
        /// <para>
        /// <para>Specifies the amount of time this device has to finish execution of this job. If the
        /// job execution status is not set to a terminal state before this timer expires, or
        /// before the timer is reset (by again calling <code>UpdateJobExecution</code>, setting
        /// the status to <code>IN_PROGRESS</code> and specifying a new timeout value in this
        /// field) the job execution status will be automatically set to <code>TIMED_OUT</code>.
        /// Note that setting or resetting this timeout has no effect on that job execution timeout
        /// which may have been specified when the job was created (<code>CreateJob</code> using
        /// field <code>timeoutConfig</code>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("StepTimeoutInMinutes")]
        public System.Int64 StepTimeoutInMinute { get; set; }
        #endregion
        
        #region Parameter ThingName
        /// <summary>
        /// <para>
        /// <para>The name of the thing associated with the device.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ThingName { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("JobId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-IOTJJobExecution (UpdateJobExecution)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound("ExecutionNumber"))
                context.ExecutionNumber = this.ExecutionNumber;
            if (ParameterWasBound("ExpectedVersion"))
                context.ExpectedVersion = this.ExpectedVersion;
            if (ParameterWasBound("IncludeJobDocument"))
                context.IncludeJobDocument = this.IncludeJobDocument;
            if (ParameterWasBound("IncludeJobExecutionState"))
                context.IncludeJobExecutionState = this.IncludeJobExecutionState;
            context.JobId = this.JobId;
            context.Status = this.Status;
            if (this.StatusDetail != null)
            {
                context.StatusDetails = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.StatusDetail.Keys)
                {
                    context.StatusDetails.Add((String)hashKey, (String)(this.StatusDetail[hashKey]));
                }
            }
            if (ParameterWasBound("StepTimeoutInMinute"))
                context.StepTimeoutInMinutes = this.StepTimeoutInMinute;
            context.ThingName = this.ThingName;
            
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
            var request = new Amazon.IoTJobsDataPlane.Model.UpdateJobExecutionRequest();
            
            if (cmdletContext.ExecutionNumber != null)
            {
                request.ExecutionNumber = cmdletContext.ExecutionNumber.Value;
            }
            if (cmdletContext.ExpectedVersion != null)
            {
                request.ExpectedVersion = cmdletContext.ExpectedVersion.Value;
            }
            if (cmdletContext.IncludeJobDocument != null)
            {
                request.IncludeJobDocument = cmdletContext.IncludeJobDocument.Value;
            }
            if (cmdletContext.IncludeJobExecutionState != null)
            {
                request.IncludeJobExecutionState = cmdletContext.IncludeJobExecutionState.Value;
            }
            if (cmdletContext.JobId != null)
            {
                request.JobId = cmdletContext.JobId;
            }
            if (cmdletContext.Status != null)
            {
                request.Status = cmdletContext.Status;
            }
            if (cmdletContext.StatusDetails != null)
            {
                request.StatusDetails = cmdletContext.StatusDetails;
            }
            if (cmdletContext.StepTimeoutInMinutes != null)
            {
                request.StepTimeoutInMinutes = cmdletContext.StepTimeoutInMinutes.Value;
            }
            if (cmdletContext.ThingName != null)
            {
                request.ThingName = cmdletContext.ThingName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        private Amazon.IoTJobsDataPlane.Model.UpdateJobExecutionResponse CallAWSServiceOperation(IAmazonIoTJobsDataPlane client, Amazon.IoTJobsDataPlane.Model.UpdateJobExecutionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT Jobs Data Plane", "UpdateJobExecution");
            try
            {
                #if DESKTOP
                return client.UpdateJobExecution(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.UpdateJobExecutionAsync(request);
                return task.Result;
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
            public System.Int64? ExecutionNumber { get; set; }
            public System.Int64? ExpectedVersion { get; set; }
            public System.Boolean? IncludeJobDocument { get; set; }
            public System.Boolean? IncludeJobExecutionState { get; set; }
            public System.String JobId { get; set; }
            public Amazon.IoTJobsDataPlane.JobExecutionStatus Status { get; set; }
            public Dictionary<System.String, System.String> StatusDetails { get; set; }
            public System.Int64? StepTimeoutInMinutes { get; set; }
            public System.String ThingName { get; set; }
        }
        
    }
}
