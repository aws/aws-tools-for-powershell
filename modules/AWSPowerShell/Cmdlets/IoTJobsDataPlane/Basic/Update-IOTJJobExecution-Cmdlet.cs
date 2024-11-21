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
    /// Updates the status of a job execution.
    /// 
    ///  
    /// <para>
    /// Requires permission to access the <a href="https://docs.aws.amazon.com/service-authorization/latest/reference/list_awsiotjobsdataplane.html">UpdateJobExecution</a>
    /// action.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "IOTJJobExecution", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoTJobsDataPlane.Model.UpdateJobExecutionResponse")]
    [AWSCmdlet("Calls the AWS IoT Jobs Data Plane UpdateJobExecution API operation.", Operation = new[] {"UpdateJobExecution"}, SelectReturnType = typeof(Amazon.IoTJobsDataPlane.Model.UpdateJobExecutionResponse))]
    [AWSCmdletOutput("Amazon.IoTJobsDataPlane.Model.UpdateJobExecutionResponse",
        "This cmdlet returns an Amazon.IoTJobsDataPlane.Model.UpdateJobExecutionResponse object containing multiple properties."
    )]
    public partial class UpdateIOTJJobExecutionCmdlet : AmazonIoTJobsDataPlaneClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ExecutionNumber
        /// <summary>
        /// <para>
        /// <para>Optional. A number that identifies a particular job execution on a particular device.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? ExecutionNumber { get; set; }
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? ExpectedVersion { get; set; }
        #endregion
        
        #region Parameter IncludeJobDocument
        /// <summary>
        /// <para>
        /// <para>Optional. When set to true, the response contains the job document. The default is
        /// false.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IncludeJobDocument { get; set; }
        #endregion
        
        #region Parameter IncludeJobExecutionState
        /// <summary>
        /// <para>
        /// <para>Optional. When included and set to true, the response contains the JobExecutionState
        /// data. The default is false.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IncludeJobExecutionState { get; set; }
        #endregion
        
        #region Parameter JobId
        /// <summary>
        /// <para>
        /// <para>The unique identifier assigned to this job when it was created.</para>
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
        public System.String JobId { get; set; }
        #endregion
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>The new status for the job execution (IN_PROGRESS, FAILED, SUCCESS, or REJECTED).
        /// This must be specified on every update.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.IoTJobsDataPlane.JobExecutionStatus")]
        public Amazon.IoTJobsDataPlane.JobExecutionStatus Status { get; set; }
        #endregion
        
        #region Parameter StatusDetail
        /// <summary>
        /// <para>
        /// <para> Optional. A collection of name/value pairs that describe the status of the job execution.
        /// If not specified, the statusDetails are unchanged.</para><para>The maximum length of the value in the name/value pair is 1,024 characters.</para>
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
        /// before the timer is reset (by again calling <c>UpdateJobExecution</c>, setting the
        /// status to <c>IN_PROGRESS</c>, and specifying a new timeout value in this field) the
        /// job execution status will be automatically set to <c>TIMED_OUT</c>. Note that setting
        /// or resetting the step timeout has no effect on the in progress timeout that may have
        /// been specified when the job was created (<c>CreateJob</c> using field <c>timeoutConfig</c>).</para><para>Valid values for this parameter range from 1 to 10080 (1 minute to 7 days). A value
        /// of -1 is also valid and will cancel the current step timer (created by an earlier
        /// use of <c>UpdateJobExecutionRequest</c>).</para>
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ThingName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTJobsDataPlane.Model.UpdateJobExecutionResponse).
        /// Specifying the name of a property of type Amazon.IoTJobsDataPlane.Model.UpdateJobExecutionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the JobId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^JobId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^JobId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.JobId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-IOTJJobExecution (UpdateJobExecution)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTJobsDataPlane.Model.UpdateJobExecutionResponse, UpdateIOTJJobExecutionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.JobId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ExecutionNumber = this.ExecutionNumber;
            context.ExpectedVersion = this.ExpectedVersion;
            context.IncludeJobDocument = this.IncludeJobDocument;
            context.IncludeJobExecutionState = this.IncludeJobExecutionState;
            context.JobId = this.JobId;
            #if MODULAR
            if (this.JobId == null && ParameterWasBound(nameof(this.JobId)))
            {
                WriteWarning("You are passing $null as a value for parameter JobId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Status = this.Status;
            #if MODULAR
            if (this.Status == null && ParameterWasBound(nameof(this.Status)))
            {
                WriteWarning("You are passing $null as a value for parameter Status which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
        
        private Amazon.IoTJobsDataPlane.Model.UpdateJobExecutionResponse CallAWSServiceOperation(IAmazonIoTJobsDataPlane client, Amazon.IoTJobsDataPlane.Model.UpdateJobExecutionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT Jobs Data Plane", "UpdateJobExecution");
            try
            {
                #if DESKTOP
                return client.UpdateJobExecution(request);
                #elif CORECLR
                return client.UpdateJobExecutionAsync(request).GetAwaiter().GetResult();
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
            public Dictionary<System.String, System.String> StatusDetail { get; set; }
            public System.Int64? StepTimeoutInMinute { get; set; }
            public System.String ThingName { get; set; }
            public System.Func<Amazon.IoTJobsDataPlane.Model.UpdateJobExecutionResponse, UpdateIOTJJobExecutionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
