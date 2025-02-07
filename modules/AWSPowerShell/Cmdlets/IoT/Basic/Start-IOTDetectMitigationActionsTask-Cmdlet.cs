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
using Amazon.IoT;
using Amazon.IoT.Model;

namespace Amazon.PowerShell.Cmdlets.IOT
{
    /// <summary>
    /// Starts a Device Defender ML Detect mitigation actions task. 
    /// 
    ///  
    /// <para>
    /// Requires permission to access the <a href="https://docs.aws.amazon.com/service-authorization/latest/reference/list_awsiot.html#awsiot-actions-as-permissions">StartDetectMitigationActionsTask</a>
    /// action.
    /// </para>
    /// </summary>
    [Cmdlet("Start", "IOTDetectMitigationActionsTask", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS IoT StartDetectMitigationActionsTask API operation.", Operation = new[] {"StartDetectMitigationActionsTask"}, SelectReturnType = typeof(Amazon.IoT.Model.StartDetectMitigationActionsTaskResponse))]
    [AWSCmdletOutput("System.String or Amazon.IoT.Model.StartDetectMitigationActionsTaskResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.IoT.Model.StartDetectMitigationActionsTaskResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartIOTDetectMitigationActionsTaskCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Action
        /// <summary>
        /// <para>
        /// <para> The actions to be performed when a device has unexpected behavior. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Actions")]
        public System.String[] Action { get; set; }
        #endregion
        
        #region Parameter Target_BehaviorName
        /// <summary>
        /// <para>
        /// <para> The name of the behavior. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Target_BehaviorName { get; set; }
        #endregion
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para> Each mitigation action task must have a unique client request token. If you try to
        /// create a new task with the same token as a task that already exists, an exception
        /// occurs. If you omit this value, Amazon Web Services SDKs will automatically generate
        /// a unique client request. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter ViolationEventOccurrenceRange_EndTime
        /// <summary>
        /// <para>
        /// <para> The end date and time of a time period in which violation events occurred. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? ViolationEventOccurrenceRange_EndTime { get; set; }
        #endregion
        
        #region Parameter IncludeOnlyActiveViolation
        /// <summary>
        /// <para>
        /// <para> Specifies to list only active violations. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IncludeOnlyActiveViolations")]
        public System.Boolean? IncludeOnlyActiveViolation { get; set; }
        #endregion
        
        #region Parameter IncludeSuppressedAlert
        /// <summary>
        /// <para>
        /// <para> Specifies to include suppressed alerts. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IncludeSuppressedAlerts")]
        public System.Boolean? IncludeSuppressedAlert { get; set; }
        #endregion
        
        #region Parameter Target_SecurityProfileName
        /// <summary>
        /// <para>
        /// <para> The name of the security profile. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Target_SecurityProfileName { get; set; }
        #endregion
        
        #region Parameter ViolationEventOccurrenceRange_StartTime
        /// <summary>
        /// <para>
        /// <para> The start date and time of a time period in which violation events occurred. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? ViolationEventOccurrenceRange_StartTime { get; set; }
        #endregion
        
        #region Parameter TaskId
        /// <summary>
        /// <para>
        /// <para> The unique identifier of the task. </para>
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
        
        #region Parameter Target_ViolationId
        /// <summary>
        /// <para>
        /// <para> The unique identifiers of the violations. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Target_ViolationIds")]
        public System.String[] Target_ViolationId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TaskId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoT.Model.StartDetectMitigationActionsTaskResponse).
        /// Specifying the name of a property of type Amazon.IoT.Model.StartDetectMitigationActionsTaskResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TaskId";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TaskId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-IOTDetectMitigationActionsTask (StartDetectMitigationActionsTask)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoT.Model.StartDetectMitigationActionsTaskResponse, StartIOTDetectMitigationActionsTaskCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Action != null)
            {
                context.Action = new List<System.String>(this.Action);
            }
            #if MODULAR
            if (this.Action == null && ParameterWasBound(nameof(this.Action)))
            {
                WriteWarning("You are passing $null as a value for parameter Action which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientRequestToken = this.ClientRequestToken;
            context.IncludeOnlyActiveViolation = this.IncludeOnlyActiveViolation;
            context.IncludeSuppressedAlert = this.IncludeSuppressedAlert;
            context.Target_BehaviorName = this.Target_BehaviorName;
            context.Target_SecurityProfileName = this.Target_SecurityProfileName;
            if (this.Target_ViolationId != null)
            {
                context.Target_ViolationId = new List<System.String>(this.Target_ViolationId);
            }
            context.TaskId = this.TaskId;
            #if MODULAR
            if (this.TaskId == null && ParameterWasBound(nameof(this.TaskId)))
            {
                WriteWarning("You are passing $null as a value for parameter TaskId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ViolationEventOccurrenceRange_EndTime = this.ViolationEventOccurrenceRange_EndTime;
            context.ViolationEventOccurrenceRange_StartTime = this.ViolationEventOccurrenceRange_StartTime;
            
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
            var request = new Amazon.IoT.Model.StartDetectMitigationActionsTaskRequest();
            
            if (cmdletContext.Action != null)
            {
                request.Actions = cmdletContext.Action;
            }
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.IncludeOnlyActiveViolation != null)
            {
                request.IncludeOnlyActiveViolations = cmdletContext.IncludeOnlyActiveViolation.Value;
            }
            if (cmdletContext.IncludeSuppressedAlert != null)
            {
                request.IncludeSuppressedAlerts = cmdletContext.IncludeSuppressedAlert.Value;
            }
            
             // populate Target
            var requestTargetIsNull = true;
            request.Target = new Amazon.IoT.Model.DetectMitigationActionsTaskTarget();
            System.String requestTarget_target_BehaviorName = null;
            if (cmdletContext.Target_BehaviorName != null)
            {
                requestTarget_target_BehaviorName = cmdletContext.Target_BehaviorName;
            }
            if (requestTarget_target_BehaviorName != null)
            {
                request.Target.BehaviorName = requestTarget_target_BehaviorName;
                requestTargetIsNull = false;
            }
            System.String requestTarget_target_SecurityProfileName = null;
            if (cmdletContext.Target_SecurityProfileName != null)
            {
                requestTarget_target_SecurityProfileName = cmdletContext.Target_SecurityProfileName;
            }
            if (requestTarget_target_SecurityProfileName != null)
            {
                request.Target.SecurityProfileName = requestTarget_target_SecurityProfileName;
                requestTargetIsNull = false;
            }
            List<System.String> requestTarget_target_ViolationId = null;
            if (cmdletContext.Target_ViolationId != null)
            {
                requestTarget_target_ViolationId = cmdletContext.Target_ViolationId;
            }
            if (requestTarget_target_ViolationId != null)
            {
                request.Target.ViolationIds = requestTarget_target_ViolationId;
                requestTargetIsNull = false;
            }
             // determine if request.Target should be set to null
            if (requestTargetIsNull)
            {
                request.Target = null;
            }
            if (cmdletContext.TaskId != null)
            {
                request.TaskId = cmdletContext.TaskId;
            }
            
             // populate ViolationEventOccurrenceRange
            var requestViolationEventOccurrenceRangeIsNull = true;
            request.ViolationEventOccurrenceRange = new Amazon.IoT.Model.ViolationEventOccurrenceRange();
            System.DateTime? requestViolationEventOccurrenceRange_violationEventOccurrenceRange_EndTime = null;
            if (cmdletContext.ViolationEventOccurrenceRange_EndTime != null)
            {
                requestViolationEventOccurrenceRange_violationEventOccurrenceRange_EndTime = cmdletContext.ViolationEventOccurrenceRange_EndTime.Value;
            }
            if (requestViolationEventOccurrenceRange_violationEventOccurrenceRange_EndTime != null)
            {
                request.ViolationEventOccurrenceRange.EndTime = requestViolationEventOccurrenceRange_violationEventOccurrenceRange_EndTime.Value;
                requestViolationEventOccurrenceRangeIsNull = false;
            }
            System.DateTime? requestViolationEventOccurrenceRange_violationEventOccurrenceRange_StartTime = null;
            if (cmdletContext.ViolationEventOccurrenceRange_StartTime != null)
            {
                requestViolationEventOccurrenceRange_violationEventOccurrenceRange_StartTime = cmdletContext.ViolationEventOccurrenceRange_StartTime.Value;
            }
            if (requestViolationEventOccurrenceRange_violationEventOccurrenceRange_StartTime != null)
            {
                request.ViolationEventOccurrenceRange.StartTime = requestViolationEventOccurrenceRange_violationEventOccurrenceRange_StartTime.Value;
                requestViolationEventOccurrenceRangeIsNull = false;
            }
             // determine if request.ViolationEventOccurrenceRange should be set to null
            if (requestViolationEventOccurrenceRangeIsNull)
            {
                request.ViolationEventOccurrenceRange = null;
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
        
        private Amazon.IoT.Model.StartDetectMitigationActionsTaskResponse CallAWSServiceOperation(IAmazonIoT client, Amazon.IoT.Model.StartDetectMitigationActionsTaskRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT", "StartDetectMitigationActionsTask");
            try
            {
                #if DESKTOP
                return client.StartDetectMitigationActionsTask(request);
                #elif CORECLR
                return client.StartDetectMitigationActionsTaskAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> Action { get; set; }
            public System.String ClientRequestToken { get; set; }
            public System.Boolean? IncludeOnlyActiveViolation { get; set; }
            public System.Boolean? IncludeSuppressedAlert { get; set; }
            public System.String Target_BehaviorName { get; set; }
            public System.String Target_SecurityProfileName { get; set; }
            public List<System.String> Target_ViolationId { get; set; }
            public System.String TaskId { get; set; }
            public System.DateTime? ViolationEventOccurrenceRange_EndTime { get; set; }
            public System.DateTime? ViolationEventOccurrenceRange_StartTime { get; set; }
            public System.Func<Amazon.IoT.Model.StartDetectMitigationActionsTaskResponse, StartIOTDetectMitigationActionsTaskCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TaskId;
        }
        
    }
}
