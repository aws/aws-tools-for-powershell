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
using Amazon.SimpleWorkflow;
using Amazon.SimpleWorkflow.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SWF
{
    /// <summary>
    /// Starts an execution of the workflow type in the specified domain using the provided
    /// <c>workflowId</c> and input data.
    /// 
    ///  
    /// <para>
    /// This action returns the newly started workflow execution.
    /// </para><para><b>Access Control</b></para><para>
    /// You can use IAM policies to control this action's access to Amazon SWF resources as
    /// follows:
    /// </para><ul><li><para>
    /// Use a <c>Resource</c> element with the domain name to limit the action to only specified
    /// domains.
    /// </para></li><li><para>
    /// Use an <c>Action</c> element to allow or deny permission to call this action.
    /// </para></li><li><para>
    /// Constrain the following parameters by using a <c>Condition</c> element with the appropriate
    /// keys.
    /// </para><ul><li><para><c>tagList.member.0</c>: The key is <c>swf:tagList.member.0</c>.
    /// </para></li><li><para><c>tagList.member.1</c>: The key is <c>swf:tagList.member.1</c>.
    /// </para></li><li><para><c>tagList.member.2</c>: The key is <c>swf:tagList.member.2</c>.
    /// </para></li><li><para><c>tagList.member.3</c>: The key is <c>swf:tagList.member.3</c>.
    /// </para></li><li><para><c>tagList.member.4</c>: The key is <c>swf:tagList.member.4</c>.
    /// </para></li><li><para><c>taskList</c>: String constraint. The key is <c>swf:taskList.name</c>.
    /// </para></li><li><para><c>workflowType.name</c>: String constraint. The key is <c>swf:workflowType.name</c>.
    /// </para></li><li><para><c>workflowType.version</c>: String constraint. The key is <c>swf:workflowType.version</c>.
    /// </para></li></ul></li></ul><para>
    /// If the caller doesn't have sufficient permissions to invoke the action, or the parameter
    /// values fall outside the specified constraints, the action fails. The associated event
    /// attribute's <c>cause</c> parameter is set to <c>OPERATION_NOT_PERMITTED</c>. For details
    /// and example IAM policies, see <a href="https://docs.aws.amazon.com/amazonswf/latest/developerguide/swf-dev-iam.html">Using
    /// IAM to Manage Access to Amazon SWF Workflows</a> in the <i>Amazon SWF Developer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Start", "SWFWorkflowExecution", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Simple Workflow Service (SWF) StartWorkflowExecution API operation.", Operation = new[] {"StartWorkflowExecution"}, SelectReturnType = typeof(Amazon.SimpleWorkflow.Model.StartWorkflowExecutionResponse))]
    [AWSCmdletOutput("System.String or Amazon.SimpleWorkflow.Model.StartWorkflowExecutionResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SimpleWorkflow.Model.StartWorkflowExecutionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartSWFWorkflowExecutionCmdlet : AmazonSimpleWorkflowClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ChildPolicy
        /// <summary>
        /// <para>
        /// <para>If set, specifies the policy to use for the child workflow executions of this workflow
        /// execution if it is terminated, by calling the <a>TerminateWorkflowExecution</a> action
        /// explicitly or due to an expired timeout. This policy overrides the default child policy
        /// specified when registering the workflow type using <a>RegisterWorkflowType</a>.</para><para>The supported child policies are:</para><ul><li><para><c>TERMINATE</c> – The child executions are terminated.</para></li><li><para><c>REQUEST_CANCEL</c> – A request to cancel is attempted for each child execution
        /// by recording a <c>WorkflowExecutionCancelRequested</c> event in its history. It is
        /// up to the decider to take appropriate actions when it receives an execution history
        /// with this event.</para></li><li><para><c>ABANDON</c> – No action is taken. The child executions continue to run.</para></li></ul><note><para>A child policy for this workflow execution must be specified either as a default for
        /// the workflow type or through this parameter. If neither this parameter is set nor
        /// a default child policy was specified at registration time then a fault is returned.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SimpleWorkflow.ChildPolicy")]
        public Amazon.SimpleWorkflow.ChildPolicy ChildPolicy { get; set; }
        #endregion
        
        #region Parameter Domain
        /// <summary>
        /// <para>
        /// <para>The name of the domain in which the workflow execution is created.</para><para>The specified string must not contain a <c>:</c> (colon), <c>/</c> (slash), <c>|</c>
        /// (vertical bar), or any control characters (<c>\u0000-\u001f</c> | <c>\u007f-\u009f</c>).
        /// Also, it must <i>not</i> be the literal string <c>arn</c>.</para>
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
        public System.String Domain { get; set; }
        #endregion
        
        #region Parameter ExecutionStartToCloseTimeout
        /// <summary>
        /// <para>
        /// <para>The total duration for this workflow execution. This overrides the defaultExecutionStartToCloseTimeout
        /// specified when registering the workflow type.</para><para>The duration is specified in seconds; an integer greater than or equal to <c>0</c>.
        /// Exceeding this limit causes the workflow execution to time out. Unlike some of the
        /// other timeout parameters in Amazon SWF, you cannot specify a value of "NONE" for this
        /// timeout; there is a one-year max limit on the time that a workflow execution can run.</para><note><para>An execution start-to-close timeout must be specified either through this parameter
        /// or as a default when the workflow type is registered. If neither this parameter nor
        /// a default execution start-to-close timeout is specified, a fault is returned.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExecutionStartToCloseTimeout { get; set; }
        #endregion
        
        #region Parameter Input
        /// <summary>
        /// <para>
        /// <para>The input for the workflow execution. This is a free form string which should be meaningful
        /// to the workflow you are starting. This <c>input</c> is made available to the new workflow
        /// execution in the <c>WorkflowExecutionStarted</c> history event.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Input { get; set; }
        #endregion
        
        #region Parameter LambdaRole
        /// <summary>
        /// <para>
        /// <para>The IAM role to attach to this workflow execution.</para><note><para>Executions of this workflow type need IAM roles to invoke Lambda functions. If you
        /// don't attach an IAM role, any attempt to schedule a Lambda task fails. This results
        /// in a <c>ScheduleLambdaFunctionFailed</c> history event. For more information, see
        /// <a href="https://docs.aws.amazon.com/amazonswf/latest/developerguide/lambda-task.html">https://docs.aws.amazon.com/amazonswf/latest/developerguide/lambda-task.html</a>
        /// in the <i>Amazon SWF Developer Guide</i>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LambdaRole { get; set; }
        #endregion
        
        #region Parameter TaskList_Name
        /// <summary>
        /// <para>
        /// <para>The name of the task list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TaskList_Name { get; set; }
        #endregion
        
        #region Parameter WorkflowType_Name
        /// <summary>
        /// <para>
        /// <para> The name of the workflow type.</para><note><para>The combination of workflow type name and version must be unique with in a domain.</para></note>
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
        public System.String WorkflowType_Name { get; set; }
        #endregion
        
        #region Parameter TagList
        /// <summary>
        /// <para>
        /// <para>The list of tags to associate with the workflow execution. You can specify a maximum
        /// of 5 tags. You can list workflow executions with a specific tag by calling <a>ListOpenWorkflowExecutions</a>
        /// or <a>ListClosedWorkflowExecutions</a> and specifying a <a>TagFilter</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] TagList { get; set; }
        #endregion
        
        #region Parameter TaskPriority
        /// <summary>
        /// <para>
        /// <para>The task priority to use for this workflow execution. This overrides any default priority
        /// that was assigned when the workflow type was registered. If not set, then the default
        /// task priority for the workflow type is used. Valid values are integers that range
        /// from Java's <c>Integer.MIN_VALUE</c> (-2147483648) to <c>Integer.MAX_VALUE</c> (2147483647).
        /// Higher numbers indicate higher priority.</para><para>For more information about setting task priority, see <a href="https://docs.aws.amazon.com/amazonswf/latest/developerguide/programming-priority.html">Setting
        /// Task Priority</a> in the <i>Amazon SWF Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TaskPriority { get; set; }
        #endregion
        
        #region Parameter TaskStartToCloseTimeout
        /// <summary>
        /// <para>
        /// <para>Specifies the maximum duration of decision tasks for this workflow execution. This
        /// parameter overrides the <c>defaultTaskStartToCloseTimout</c> specified when registering
        /// the workflow type using <a>RegisterWorkflowType</a>.</para><para>The duration is specified in seconds, an integer greater than or equal to <c>0</c>.
        /// You can use <c>NONE</c> to specify unlimited duration.</para><note><para>A task start-to-close timeout for this workflow execution must be specified either
        /// as a default for the workflow type or through this parameter. If neither this parameter
        /// is set nor a default task start-to-close timeout was specified at registration time
        /// then a fault is returned.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TaskStartToCloseTimeout { get; set; }
        #endregion
        
        #region Parameter WorkflowType_Version
        /// <summary>
        /// <para>
        /// <para> The version of the workflow type.</para><note><para>The combination of workflow type name and version must be unique with in a domain.</para></note>
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
        public System.String WorkflowType_Version { get; set; }
        #endregion
        
        #region Parameter WorkflowId
        /// <summary>
        /// <para>
        /// <para>The user defined identifier associated with the workflow execution. You can use this
        /// to associate a custom identifier with the workflow execution. You may specify the
        /// same identifier if a workflow execution is logically a <i>restart</i> of a previous
        /// execution. You cannot have two open workflow executions with the same <c>workflowId</c>
        /// at the same time within the same domain.</para><para>The specified string must not contain a <c>:</c> (colon), <c>/</c> (slash), <c>|</c>
        /// (vertical bar), or any control characters (<c>\u0000-\u001f</c> | <c>\u007f-\u009f</c>).
        /// Also, it must <i>not</i> be the literal string <c>arn</c>.</para>
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
        public System.String WorkflowId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Run.RunId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleWorkflow.Model.StartWorkflowExecutionResponse).
        /// Specifying the name of a property of type Amazon.SimpleWorkflow.Model.StartWorkflowExecutionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Run.RunId";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.WorkflowType_Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-SWFWorkflowExecution (StartWorkflowExecution)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleWorkflow.Model.StartWorkflowExecutionResponse, StartSWFWorkflowExecutionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ChildPolicy = this.ChildPolicy;
            context.Domain = this.Domain;
            #if MODULAR
            if (this.Domain == null && ParameterWasBound(nameof(this.Domain)))
            {
                WriteWarning("You are passing $null as a value for parameter Domain which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ExecutionStartToCloseTimeout = this.ExecutionStartToCloseTimeout;
            context.Input = this.Input;
            context.LambdaRole = this.LambdaRole;
            if (this.TagList != null)
            {
                context.TagList = new List<System.String>(this.TagList);
            }
            context.TaskList_Name = this.TaskList_Name;
            context.TaskPriority = this.TaskPriority;
            context.TaskStartToCloseTimeout = this.TaskStartToCloseTimeout;
            context.WorkflowId = this.WorkflowId;
            #if MODULAR
            if (this.WorkflowId == null && ParameterWasBound(nameof(this.WorkflowId)))
            {
                WriteWarning("You are passing $null as a value for parameter WorkflowId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.WorkflowType_Name = this.WorkflowType_Name;
            #if MODULAR
            if (this.WorkflowType_Name == null && ParameterWasBound(nameof(this.WorkflowType_Name)))
            {
                WriteWarning("You are passing $null as a value for parameter WorkflowType_Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.WorkflowType_Version = this.WorkflowType_Version;
            #if MODULAR
            if (this.WorkflowType_Version == null && ParameterWasBound(nameof(this.WorkflowType_Version)))
            {
                WriteWarning("You are passing $null as a value for parameter WorkflowType_Version which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SimpleWorkflow.Model.StartWorkflowExecutionRequest();
            
            if (cmdletContext.ChildPolicy != null)
            {
                request.ChildPolicy = cmdletContext.ChildPolicy;
            }
            if (cmdletContext.Domain != null)
            {
                request.Domain = cmdletContext.Domain;
            }
            if (cmdletContext.ExecutionStartToCloseTimeout != null)
            {
                request.ExecutionStartToCloseTimeout = cmdletContext.ExecutionStartToCloseTimeout;
            }
            if (cmdletContext.Input != null)
            {
                request.Input = cmdletContext.Input;
            }
            if (cmdletContext.LambdaRole != null)
            {
                request.LambdaRole = cmdletContext.LambdaRole;
            }
            if (cmdletContext.TagList != null)
            {
                request.TagList = cmdletContext.TagList;
            }
            
             // populate TaskList
            var requestTaskListIsNull = true;
            request.TaskList = new Amazon.SimpleWorkflow.Model.TaskList();
            System.String requestTaskList_taskList_Name = null;
            if (cmdletContext.TaskList_Name != null)
            {
                requestTaskList_taskList_Name = cmdletContext.TaskList_Name;
            }
            if (requestTaskList_taskList_Name != null)
            {
                request.TaskList.Name = requestTaskList_taskList_Name;
                requestTaskListIsNull = false;
            }
             // determine if request.TaskList should be set to null
            if (requestTaskListIsNull)
            {
                request.TaskList = null;
            }
            if (cmdletContext.TaskPriority != null)
            {
                request.TaskPriority = cmdletContext.TaskPriority;
            }
            if (cmdletContext.TaskStartToCloseTimeout != null)
            {
                request.TaskStartToCloseTimeout = cmdletContext.TaskStartToCloseTimeout;
            }
            if (cmdletContext.WorkflowId != null)
            {
                request.WorkflowId = cmdletContext.WorkflowId;
            }
            
             // populate WorkflowType
            var requestWorkflowTypeIsNull = true;
            request.WorkflowType = new Amazon.SimpleWorkflow.Model.WorkflowType();
            System.String requestWorkflowType_workflowType_Name = null;
            if (cmdletContext.WorkflowType_Name != null)
            {
                requestWorkflowType_workflowType_Name = cmdletContext.WorkflowType_Name;
            }
            if (requestWorkflowType_workflowType_Name != null)
            {
                request.WorkflowType.Name = requestWorkflowType_workflowType_Name;
                requestWorkflowTypeIsNull = false;
            }
            System.String requestWorkflowType_workflowType_Version = null;
            if (cmdletContext.WorkflowType_Version != null)
            {
                requestWorkflowType_workflowType_Version = cmdletContext.WorkflowType_Version;
            }
            if (requestWorkflowType_workflowType_Version != null)
            {
                request.WorkflowType.Version = requestWorkflowType_workflowType_Version;
                requestWorkflowTypeIsNull = false;
            }
             // determine if request.WorkflowType should be set to null
            if (requestWorkflowTypeIsNull)
            {
                request.WorkflowType = null;
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
        
        private Amazon.SimpleWorkflow.Model.StartWorkflowExecutionResponse CallAWSServiceOperation(IAmazonSimpleWorkflow client, Amazon.SimpleWorkflow.Model.StartWorkflowExecutionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Simple Workflow Service (SWF)", "StartWorkflowExecution");
            try
            {
                return client.StartWorkflowExecutionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.SimpleWorkflow.ChildPolicy ChildPolicy { get; set; }
            public System.String Domain { get; set; }
            public System.String ExecutionStartToCloseTimeout { get; set; }
            public System.String Input { get; set; }
            public System.String LambdaRole { get; set; }
            public List<System.String> TagList { get; set; }
            public System.String TaskList_Name { get; set; }
            public System.String TaskPriority { get; set; }
            public System.String TaskStartToCloseTimeout { get; set; }
            public System.String WorkflowId { get; set; }
            public System.String WorkflowType_Name { get; set; }
            public System.String WorkflowType_Version { get; set; }
            public System.Func<Amazon.SimpleWorkflow.Model.StartWorkflowExecutionResponse, StartSWFWorkflowExecutionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Run.RunId;
        }
        
    }
}
