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
using Amazon.SimpleWorkflow;
using Amazon.SimpleWorkflow.Model;

namespace Amazon.PowerShell.Cmdlets.SWF
{
    /// <summary>
    /// Registers a new <i>workflow type</i> and its configuration settings in the specified
    /// domain.
    /// 
    ///  
    /// <para>
    /// The retention period for the workflow history is set by the <a>RegisterDomain</a>
    /// action.
    /// </para><important><para>
    /// If the type already exists, then a <code>TypeAlreadyExists</code> fault is returned.
    /// You cannot change the configuration settings of a workflow type once it is registered
    /// and it must be registered as a new version.
    /// </para></important><para><b>Access Control</b></para><para>
    /// You can use IAM policies to control this action's access to Amazon SWF resources as
    /// follows:
    /// </para><ul><li><para>
    /// Use a <code>Resource</code> element with the domain name to limit the action to only
    /// specified domains.
    /// </para></li><li><para>
    /// Use an <code>Action</code> element to allow or deny permission to call this action.
    /// </para></li><li><para>
    /// Constrain the following parameters by using a <code>Condition</code> element with
    /// the appropriate keys.
    /// </para><ul><li><para><code>defaultTaskList.name</code>: String constraint. The key is <code>swf:defaultTaskList.name</code>.
    /// </para></li><li><para><code>name</code>: String constraint. The key is <code>swf:name</code>.
    /// </para></li><li><para><code>version</code>: String constraint. The key is <code>swf:version</code>.
    /// </para></li></ul></li></ul><para>
    /// If the caller doesn't have sufficient permissions to invoke the action, or the parameter
    /// values fall outside the specified constraints, the action fails. The associated event
    /// attribute's <code>cause</code> parameter is set to <code>OPERATION_NOT_PERMITTED</code>.
    /// For details and example IAM policies, see <a href="https://docs.aws.amazon.com/amazonswf/latest/developerguide/swf-dev-iam.html">Using
    /// IAM to Manage Access to Amazon SWF Workflows</a> in the <i>Amazon SWF Developer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "SWFWorkflowType", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Simple Workflow Service (SWF) RegisterWorkflowType API operation.", Operation = new[] {"RegisterWorkflowType"}, SelectReturnType = typeof(Amazon.SimpleWorkflow.Model.RegisterWorkflowTypeResponse))]
    [AWSCmdletOutput("None or Amazon.SimpleWorkflow.Model.RegisterWorkflowTypeResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SimpleWorkflow.Model.RegisterWorkflowTypeResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewSWFWorkflowTypeCmdlet : AmazonSimpleWorkflowClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DefaultChildPolicy
        /// <summary>
        /// <para>
        /// <para>If set, specifies the default policy to use for the child workflow executions when
        /// a workflow execution of this type is terminated, by calling the <a>TerminateWorkflowExecution</a>
        /// action explicitly or due to an expired timeout. This default can be overridden when
        /// starting a workflow execution using the <a>StartWorkflowExecution</a> action or the
        /// <code>StartChildWorkflowExecution</code><a>Decision</a>.</para><para>The supported child policies are:</para><ul><li><para><code>TERMINATE</code> – The child executions are terminated.</para></li><li><para><code>REQUEST_CANCEL</code> – A request to cancel is attempted for each child execution
        /// by recording a <code>WorkflowExecutionCancelRequested</code> event in its history.
        /// It is up to the decider to take appropriate actions when it receives an execution
        /// history with this event.</para></li><li><para><code>ABANDON</code> – No action is taken. The child executions continue to run.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SimpleWorkflow.ChildPolicy")]
        public Amazon.SimpleWorkflow.ChildPolicy DefaultChildPolicy { get; set; }
        #endregion
        
        #region Parameter DefaultExecutionStartToCloseTimeout
        /// <summary>
        /// <para>
        /// <para>If set, specifies the default maximum duration for executions of this workflow type.
        /// You can override this default when starting an execution through the <a>StartWorkflowExecution</a>
        /// Action or <code>StartChildWorkflowExecution</code><a>Decision</a>.</para><para>The duration is specified in seconds; an integer greater than or equal to 0. Unlike
        /// some of the other timeout parameters in Amazon SWF, you cannot specify a value of
        /// "NONE" for <code>defaultExecutionStartToCloseTimeout</code>; there is a one-year max
        /// limit on the time that a workflow execution can run. Exceeding this limit always causes
        /// the workflow execution to time out.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DefaultExecutionStartToCloseTimeout { get; set; }
        #endregion
        
        #region Parameter DefaultLambdaRole
        /// <summary>
        /// <para>
        /// <para>The default IAM role attached to this workflow type.</para><note><para>Executions of this workflow type need IAM roles to invoke Lambda functions. If you
        /// don't specify an IAM role when you start this workflow type, the default Lambda role
        /// is attached to the execution. For more information, see <a href="https://docs.aws.amazon.com/amazonswf/latest/developerguide/lambda-task.html">https://docs.aws.amazon.com/amazonswf/latest/developerguide/lambda-task.html</a>
        /// in the <i>Amazon SWF Developer Guide</i>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DefaultLambdaRole { get; set; }
        #endregion
        
        #region Parameter DefaultTaskPriority
        /// <summary>
        /// <para>
        /// <para>The default task priority to assign to the workflow type. If not assigned, then <code>0</code>
        /// is used. Valid values are integers that range from Java's <code>Integer.MIN_VALUE</code>
        /// (-2147483648) to <code>Integer.MAX_VALUE</code> (2147483647). Higher numbers indicate
        /// higher priority.</para><para>For more information about setting task priority, see <a href="https://docs.aws.amazon.com/amazonswf/latest/developerguide/programming-priority.html">Setting
        /// Task Priority</a> in the <i>Amazon SWF Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DefaultTaskPriority { get; set; }
        #endregion
        
        #region Parameter DefaultTaskStartToCloseTimeout
        /// <summary>
        /// <para>
        /// <para>If set, specifies the default maximum duration of decision tasks for this workflow
        /// type. This default can be overridden when starting a workflow execution using the
        /// <a>StartWorkflowExecution</a> action or the <code>StartChildWorkflowExecution</code><a>Decision</a>.</para><para>The duration is specified in seconds, an integer greater than or equal to <code>0</code>.
        /// You can use <code>NONE</code> to specify unlimited duration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DefaultTaskStartToCloseTimeout { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>Textual description of the workflow type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Domain
        /// <summary>
        /// <para>
        /// <para>The name of the domain in which to register the workflow type.</para>
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
        
        #region Parameter DefaultTaskList_Name
        /// <summary>
        /// <para>
        /// <para>The name of the task list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DefaultTaskList_Name { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the workflow type.</para><para>The specified string must not contain a <code>:</code> (colon), <code>/</code> (slash),
        /// <code>|</code> (vertical bar), or any control characters (<code>\u0000-\u001f</code>
        /// | <code>\u007f-\u009f</code>). Also, it must <i>not</i> be the literal string <code>arn</code>.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Version
        /// <summary>
        /// <para>
        /// <para>The version of the workflow type.</para><note><para>The workflow type consists of the name and version, the combination of which must
        /// be unique within the domain. To get a list of all currently registered workflow types,
        /// use the <a>ListWorkflowTypes</a> action.</para></note><para>The specified string must not contain a <code>:</code> (colon), <code>/</code> (slash),
        /// <code>|</code> (vertical bar), or any control characters (<code>\u0000-\u001f</code>
        /// | <code>\u007f-\u009f</code>). Also, it must <i>not</i> be the literal string <code>arn</code>.</para>
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
        public System.String Version { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleWorkflow.Model.RegisterWorkflowTypeResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SWFWorkflowType (RegisterWorkflowType)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleWorkflow.Model.RegisterWorkflowTypeResponse, NewSWFWorkflowTypeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DefaultChildPolicy = this.DefaultChildPolicy;
            context.DefaultExecutionStartToCloseTimeout = this.DefaultExecutionStartToCloseTimeout;
            context.DefaultLambdaRole = this.DefaultLambdaRole;
            context.DefaultTaskList_Name = this.DefaultTaskList_Name;
            context.DefaultTaskPriority = this.DefaultTaskPriority;
            context.DefaultTaskStartToCloseTimeout = this.DefaultTaskStartToCloseTimeout;
            context.Description = this.Description;
            context.Domain = this.Domain;
            #if MODULAR
            if (this.Domain == null && ParameterWasBound(nameof(this.Domain)))
            {
                WriteWarning("You are passing $null as a value for parameter Domain which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Version = this.Version;
            #if MODULAR
            if (this.Version == null && ParameterWasBound(nameof(this.Version)))
            {
                WriteWarning("You are passing $null as a value for parameter Version which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SimpleWorkflow.Model.RegisterWorkflowTypeRequest();
            
            if (cmdletContext.DefaultChildPolicy != null)
            {
                request.DefaultChildPolicy = cmdletContext.DefaultChildPolicy;
            }
            if (cmdletContext.DefaultExecutionStartToCloseTimeout != null)
            {
                request.DefaultExecutionStartToCloseTimeout = cmdletContext.DefaultExecutionStartToCloseTimeout;
            }
            if (cmdletContext.DefaultLambdaRole != null)
            {
                request.DefaultLambdaRole = cmdletContext.DefaultLambdaRole;
            }
            
             // populate DefaultTaskList
            var requestDefaultTaskListIsNull = true;
            request.DefaultTaskList = new Amazon.SimpleWorkflow.Model.TaskList();
            System.String requestDefaultTaskList_defaultTaskList_Name = null;
            if (cmdletContext.DefaultTaskList_Name != null)
            {
                requestDefaultTaskList_defaultTaskList_Name = cmdletContext.DefaultTaskList_Name;
            }
            if (requestDefaultTaskList_defaultTaskList_Name != null)
            {
                request.DefaultTaskList.Name = requestDefaultTaskList_defaultTaskList_Name;
                requestDefaultTaskListIsNull = false;
            }
             // determine if request.DefaultTaskList should be set to null
            if (requestDefaultTaskListIsNull)
            {
                request.DefaultTaskList = null;
            }
            if (cmdletContext.DefaultTaskPriority != null)
            {
                request.DefaultTaskPriority = cmdletContext.DefaultTaskPriority;
            }
            if (cmdletContext.DefaultTaskStartToCloseTimeout != null)
            {
                request.DefaultTaskStartToCloseTimeout = cmdletContext.DefaultTaskStartToCloseTimeout;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Domain != null)
            {
                request.Domain = cmdletContext.Domain;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Version != null)
            {
                request.Version = cmdletContext.Version;
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
        
        private Amazon.SimpleWorkflow.Model.RegisterWorkflowTypeResponse CallAWSServiceOperation(IAmazonSimpleWorkflow client, Amazon.SimpleWorkflow.Model.RegisterWorkflowTypeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Simple Workflow Service (SWF)", "RegisterWorkflowType");
            try
            {
                #if DESKTOP
                return client.RegisterWorkflowType(request);
                #elif CORECLR
                return client.RegisterWorkflowTypeAsync(request).GetAwaiter().GetResult();
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
            public Amazon.SimpleWorkflow.ChildPolicy DefaultChildPolicy { get; set; }
            public System.String DefaultExecutionStartToCloseTimeout { get; set; }
            public System.String DefaultLambdaRole { get; set; }
            public System.String DefaultTaskList_Name { get; set; }
            public System.String DefaultTaskPriority { get; set; }
            public System.String DefaultTaskStartToCloseTimeout { get; set; }
            public System.String Description { get; set; }
            public System.String Domain { get; set; }
            public System.String Name { get; set; }
            public System.String Version { get; set; }
            public System.Func<Amazon.SimpleWorkflow.Model.RegisterWorkflowTypeResponse, NewSWFWorkflowTypeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
