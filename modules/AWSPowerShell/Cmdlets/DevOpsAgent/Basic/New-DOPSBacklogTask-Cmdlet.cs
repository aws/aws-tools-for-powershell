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
using Amazon.DevOpsAgent;
using Amazon.DevOpsAgent.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.DOPS
{
    /// <summary>
    /// Creates a new backlog task in the specified agent space
    /// </summary>
    [Cmdlet("New", "DOPSBacklogTask", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DevOpsAgent.Model.Task")]
    [AWSCmdlet("Calls the AWS DevOps Agent Service CreateBacklogTask API operation.", Operation = new[] {"CreateBacklogTask"}, SelectReturnType = typeof(Amazon.DevOpsAgent.Model.CreateBacklogTaskResponse))]
    [AWSCmdletOutput("Amazon.DevOpsAgent.Model.Task or Amazon.DevOpsAgent.Model.CreateBacklogTaskResponse",
        "This cmdlet returns an Amazon.DevOpsAgent.Model.Task object.",
        "The service call response (type Amazon.DevOpsAgent.Model.CreateBacklogTaskResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewDOPSBacklogTaskCmdlet : AmazonDevOpsAgentClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AgentSpaceId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the agent space where the task will be created</para>
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
        public System.String AgentSpaceId { get; set; }
        #endregion
        
        #region Parameter Reference_AssociationId
        /// <summary>
        /// <para>
        /// <para>Association identifier of the external system</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Reference_AssociationId { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>Optional detailed description of the task</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Priority
        /// <summary>
        /// <para>
        /// <para>The priority level of the task</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.DevOpsAgent.Priority")]
        public Amazon.DevOpsAgent.Priority Priority { get; set; }
        #endregion
        
        #region Parameter Reference_ReferenceId
        /// <summary>
        /// <para>
        /// <para>The unique identifier in the external system</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Reference_ReferenceId { get; set; }
        #endregion
        
        #region Parameter Reference_ReferenceUrl
        /// <summary>
        /// <para>
        /// <para>URL to access the reference in the external system</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Reference_ReferenceUrl { get; set; }
        #endregion
        
        #region Parameter Reference_System
        /// <summary>
        /// <para>
        /// <para>The name of the external system</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Reference_System { get; set; }
        #endregion
        
        #region Parameter TaskType
        /// <summary>
        /// <para>
        /// <para>The type of task being created</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.DevOpsAgent.TaskType")]
        public Amazon.DevOpsAgent.TaskType TaskType { get; set; }
        #endregion
        
        #region Parameter Reference_Title
        /// <summary>
        /// <para>
        /// <para>Optional title for the reference</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Reference_Title { get; set; }
        #endregion
        
        #region Parameter Title
        /// <summary>
        /// <para>
        /// <para>The title of the backlog task</para>
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
        public System.String Title { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Client-provided token for idempotent operations</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Task'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DevOpsAgent.Model.CreateBacklogTaskResponse).
        /// Specifying the name of a property of type Amazon.DevOpsAgent.Model.CreateBacklogTaskResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Task";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AgentSpaceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-DOPSBacklogTask (CreateBacklogTask)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DevOpsAgent.Model.CreateBacklogTaskResponse, NewDOPSBacklogTaskCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AgentSpaceId = this.AgentSpaceId;
            #if MODULAR
            if (this.AgentSpaceId == null && ParameterWasBound(nameof(this.AgentSpaceId)))
            {
                WriteWarning("You are passing $null as a value for parameter AgentSpaceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.Priority = this.Priority;
            #if MODULAR
            if (this.Priority == null && ParameterWasBound(nameof(this.Priority)))
            {
                WriteWarning("You are passing $null as a value for parameter Priority which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Reference_AssociationId = this.Reference_AssociationId;
            context.Reference_ReferenceId = this.Reference_ReferenceId;
            context.Reference_ReferenceUrl = this.Reference_ReferenceUrl;
            context.Reference_System = this.Reference_System;
            context.Reference_Title = this.Reference_Title;
            context.TaskType = this.TaskType;
            #if MODULAR
            if (this.TaskType == null && ParameterWasBound(nameof(this.TaskType)))
            {
                WriteWarning("You are passing $null as a value for parameter TaskType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Title = this.Title;
            #if MODULAR
            if (this.Title == null && ParameterWasBound(nameof(this.Title)))
            {
                WriteWarning("You are passing $null as a value for parameter Title which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.DevOpsAgent.Model.CreateBacklogTaskRequest();
            
            if (cmdletContext.AgentSpaceId != null)
            {
                request.AgentSpaceId = cmdletContext.AgentSpaceId;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Priority != null)
            {
                request.Priority = cmdletContext.Priority;
            }
            
             // populate Reference
            var requestReferenceIsNull = true;
            request.Reference = new Amazon.DevOpsAgent.Model.ReferenceInput();
            System.String requestReference_reference_AssociationId = null;
            if (cmdletContext.Reference_AssociationId != null)
            {
                requestReference_reference_AssociationId = cmdletContext.Reference_AssociationId;
            }
            if (requestReference_reference_AssociationId != null)
            {
                request.Reference.AssociationId = requestReference_reference_AssociationId;
                requestReferenceIsNull = false;
            }
            System.String requestReference_reference_ReferenceId = null;
            if (cmdletContext.Reference_ReferenceId != null)
            {
                requestReference_reference_ReferenceId = cmdletContext.Reference_ReferenceId;
            }
            if (requestReference_reference_ReferenceId != null)
            {
                request.Reference.ReferenceId = requestReference_reference_ReferenceId;
                requestReferenceIsNull = false;
            }
            System.String requestReference_reference_ReferenceUrl = null;
            if (cmdletContext.Reference_ReferenceUrl != null)
            {
                requestReference_reference_ReferenceUrl = cmdletContext.Reference_ReferenceUrl;
            }
            if (requestReference_reference_ReferenceUrl != null)
            {
                request.Reference.ReferenceUrl = requestReference_reference_ReferenceUrl;
                requestReferenceIsNull = false;
            }
            System.String requestReference_reference_System = null;
            if (cmdletContext.Reference_System != null)
            {
                requestReference_reference_System = cmdletContext.Reference_System;
            }
            if (requestReference_reference_System != null)
            {
                request.Reference.System = requestReference_reference_System;
                requestReferenceIsNull = false;
            }
            System.String requestReference_reference_Title = null;
            if (cmdletContext.Reference_Title != null)
            {
                requestReference_reference_Title = cmdletContext.Reference_Title;
            }
            if (requestReference_reference_Title != null)
            {
                request.Reference.Title = requestReference_reference_Title;
                requestReferenceIsNull = false;
            }
             // determine if request.Reference should be set to null
            if (requestReferenceIsNull)
            {
                request.Reference = null;
            }
            if (cmdletContext.TaskType != null)
            {
                request.TaskType = cmdletContext.TaskType;
            }
            if (cmdletContext.Title != null)
            {
                request.Title = cmdletContext.Title;
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
        
        private Amazon.DevOpsAgent.Model.CreateBacklogTaskResponse CallAWSServiceOperation(IAmazonDevOpsAgent client, Amazon.DevOpsAgent.Model.CreateBacklogTaskRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS DevOps Agent Service", "CreateBacklogTask");
            try
            {
                return client.CreateBacklogTaskAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AgentSpaceId { get; set; }
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public Amazon.DevOpsAgent.Priority Priority { get; set; }
            public System.String Reference_AssociationId { get; set; }
            public System.String Reference_ReferenceId { get; set; }
            public System.String Reference_ReferenceUrl { get; set; }
            public System.String Reference_System { get; set; }
            public System.String Reference_Title { get; set; }
            public Amazon.DevOpsAgent.TaskType TaskType { get; set; }
            public System.String Title { get; set; }
            public System.Func<Amazon.DevOpsAgent.Model.CreateBacklogTaskResponse, NewDOPSBacklogTaskCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Task;
        }
        
    }
}
