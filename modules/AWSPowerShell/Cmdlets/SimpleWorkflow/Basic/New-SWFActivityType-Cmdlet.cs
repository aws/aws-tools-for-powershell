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
    /// Registers a new <i>activity type</i> along with its configuration settings in the
    /// specified domain.
    /// 
    ///  <important><para>
    /// A <code>TypeAlreadyExists</code> fault is returned if the type already exists in the
    /// domain. You cannot change any configuration settings of the type after its registration,
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
    [Cmdlet("New", "SWFActivityType", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Simple Workflow Service (SWF) RegisterActivityType API operation.", Operation = new[] {"RegisterActivityType"}, SelectReturnType = typeof(Amazon.SimpleWorkflow.Model.RegisterActivityTypeResponse))]
    [AWSCmdletOutput("None or Amazon.SimpleWorkflow.Model.RegisterActivityTypeResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SimpleWorkflow.Model.RegisterActivityTypeResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewSWFActivityTypeCmdlet : AmazonSimpleWorkflowClientCmdlet, IExecutor
    {
        
        #region Parameter DefaultTaskHeartbeatTimeout
        /// <summary>
        /// <para>
        /// <para>If set, specifies the default maximum time before which a worker processing a task
        /// of this type must report progress by calling <a>RecordActivityTaskHeartbeat</a>. If
        /// the timeout is exceeded, the activity task is automatically timed out. This default
        /// can be overridden when scheduling an activity task using the <code>ScheduleActivityTask</code><a>Decision</a>. If the activity worker subsequently attempts to record a heartbeat
        /// or returns a result, the activity worker receives an <code>UnknownResource</code>
        /// fault. In this case, Amazon SWF no longer considers the activity task to be valid;
        /// the activity worker should clean up the activity task.</para><para>The duration is specified in seconds, an integer greater than or equal to <code>0</code>.
        /// You can use <code>NONE</code> to specify unlimited duration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DefaultTaskHeartbeatTimeout { get; set; }
        #endregion
        
        #region Parameter DefaultTaskPriority
        /// <summary>
        /// <para>
        /// <para>The default task priority to assign to the activity type. If not assigned, then <code>0</code>
        /// is used. Valid values are integers that range from Java's <code>Integer.MIN_VALUE</code>
        /// (-2147483648) to <code>Integer.MAX_VALUE</code> (2147483647). Higher numbers indicate
        /// higher priority.</para><para>For more information about setting task priority, see <a href="https://docs.aws.amazon.com/amazonswf/latest/developerguide/programming-priority.html">Setting
        /// Task Priority</a> in the <i>in the <i>Amazon SWF Developer Guide</i>.</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DefaultTaskPriority { get; set; }
        #endregion
        
        #region Parameter DefaultTaskScheduleToCloseTimeout
        /// <summary>
        /// <para>
        /// <para>If set, specifies the default maximum duration for a task of this activity type. This
        /// default can be overridden when scheduling an activity task using the <code>ScheduleActivityTask</code><a>Decision</a>.</para><para>The duration is specified in seconds, an integer greater than or equal to <code>0</code>.
        /// You can use <code>NONE</code> to specify unlimited duration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DefaultTaskScheduleToCloseTimeout { get; set; }
        #endregion
        
        #region Parameter DefaultTaskScheduleToStartTimeout
        /// <summary>
        /// <para>
        /// <para>If set, specifies the default maximum duration that a task of this activity type can
        /// wait before being assigned to a worker. This default can be overridden when scheduling
        /// an activity task using the <code>ScheduleActivityTask</code><a>Decision</a>.</para><para>The duration is specified in seconds, an integer greater than or equal to <code>0</code>.
        /// You can use <code>NONE</code> to specify unlimited duration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DefaultTaskScheduleToStartTimeout { get; set; }
        #endregion
        
        #region Parameter DefaultTaskStartToCloseTimeout
        /// <summary>
        /// <para>
        /// <para>If set, specifies the default maximum duration that a worker can take to process tasks
        /// of this activity type. This default can be overridden when scheduling an activity
        /// task using the <code>ScheduleActivityTask</code><a>Decision</a>.</para><para>The duration is specified in seconds, an integer greater than or equal to <code>0</code>.
        /// You can use <code>NONE</code> to specify unlimited duration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DefaultTaskStartToCloseTimeout { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A textual description of the activity type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Domain
        /// <summary>
        /// <para>
        /// <para>The name of the domain in which this activity is to be registered.</para>
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
        /// <para>The name of the activity type within the domain.</para><para>The specified string must not start or end with whitespace. It must not contain a
        /// <code>:</code> (colon), <code>/</code> (slash), <code>|</code> (vertical bar), or
        /// any control characters (<code>\u0000-\u001f</code> | <code>\u007f-\u009f</code>).
        /// Also, it must not <i>be</i> the literal string <code>arn</code>.</para>
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
        /// <para>The version of the activity type.</para><note><para>The activity type consists of the name and version, the combination of which must
        /// be unique within the domain.</para></note><para>The specified string must not start or end with whitespace. It must not contain a
        /// <code>:</code> (colon), <code>/</code> (slash), <code>|</code> (vertical bar), or
        /// any control characters (<code>\u0000-\u001f</code> | <code>\u007f-\u009f</code>).
        /// Also, it must not <i>be</i> the literal string <code>arn</code>.</para>
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleWorkflow.Model.RegisterActivityTypeResponse).
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SWFActivityType (RegisterActivityType)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleWorkflow.Model.RegisterActivityTypeResponse, NewSWFActivityTypeCmdlet>(Select) ??
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
            context.DefaultTaskHeartbeatTimeout = this.DefaultTaskHeartbeatTimeout;
            context.DefaultTaskList_Name = this.DefaultTaskList_Name;
            context.DefaultTaskPriority = this.DefaultTaskPriority;
            context.DefaultTaskScheduleToCloseTimeout = this.DefaultTaskScheduleToCloseTimeout;
            context.DefaultTaskScheduleToStartTimeout = this.DefaultTaskScheduleToStartTimeout;
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
            var request = new Amazon.SimpleWorkflow.Model.RegisterActivityTypeRequest();
            
            if (cmdletContext.DefaultTaskHeartbeatTimeout != null)
            {
                request.DefaultTaskHeartbeatTimeout = cmdletContext.DefaultTaskHeartbeatTimeout;
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
            if (cmdletContext.DefaultTaskScheduleToCloseTimeout != null)
            {
                request.DefaultTaskScheduleToCloseTimeout = cmdletContext.DefaultTaskScheduleToCloseTimeout;
            }
            if (cmdletContext.DefaultTaskScheduleToStartTimeout != null)
            {
                request.DefaultTaskScheduleToStartTimeout = cmdletContext.DefaultTaskScheduleToStartTimeout;
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
        
        private Amazon.SimpleWorkflow.Model.RegisterActivityTypeResponse CallAWSServiceOperation(IAmazonSimpleWorkflow client, Amazon.SimpleWorkflow.Model.RegisterActivityTypeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Simple Workflow Service (SWF)", "RegisterActivityType");
            try
            {
                #if DESKTOP
                return client.RegisterActivityType(request);
                #elif CORECLR
                return client.RegisterActivityTypeAsync(request).GetAwaiter().GetResult();
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
            public System.String DefaultTaskHeartbeatTimeout { get; set; }
            public System.String DefaultTaskList_Name { get; set; }
            public System.String DefaultTaskPriority { get; set; }
            public System.String DefaultTaskScheduleToCloseTimeout { get; set; }
            public System.String DefaultTaskScheduleToStartTimeout { get; set; }
            public System.String DefaultTaskStartToCloseTimeout { get; set; }
            public System.String Description { get; set; }
            public System.String Domain { get; set; }
            public System.String Name { get; set; }
            public System.String Version { get; set; }
            public System.Func<Amazon.SimpleWorkflow.Model.RegisterActivityTypeResponse, NewSWFActivityTypeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
