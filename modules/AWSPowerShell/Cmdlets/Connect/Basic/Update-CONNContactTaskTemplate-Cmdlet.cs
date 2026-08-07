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
using Amazon.Connect;
using Amazon.Connect.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CONN
{
    /// <summary>
    /// Updates the task template association on an existing task contact. You can update
    /// the task template on a contact before assignment to support tasks that are created
    /// without a template (for example <a href="https://docs.aws.amazon.com/connect/latest/adminguide/connect-rules.html">Rules</a>
    /// or <a href="https://docs.aws.amazon.com/connect/latest/adminguide/set-disconnect-flow.html">disconnect
    /// flows</a>) or change the agent interaction form to represent the latest task data
    /// (for example an initial request that was submitted as a refund gets updated to an
    /// account cancellation and requires a new template).
    /// 
    ///  
    /// <para>
    /// This operation can only be used with task contacts that are in progress and not connected
    /// to an agent. A task template can be updated a maximum of 5 times per contact.
    /// </para><para>
    /// The task's references must be compatible with the fields of the target task template.
    /// If the target template has a required field, the task must have a corresponding reference
    /// with a matching name and compatible type. The following task template field types
    /// map to reference types:
    /// </para><ul><li><para><c>TEXT</c>, <c>TEXT_AREA</c>, <c>BOOLEAN</c>, and <c>SINGLE_SELECT</c> map to references
    /// of type <c>STRING</c>.
    /// </para></li><li><para><c>NUMBER</c> maps to references of type <c>NUMBER</c>.
    /// </para></li><li><para><c>DATE_TIME</c> maps to references of type <c>DATE</c>.
    /// </para></li><li><para><c>URL</c> maps to references of type <c>URL</c>.
    /// </para></li><li><para><c>EMAIL</c> maps to references of type <c>EMAIL</c>.
    /// </para></li></ul><para>
    /// References corresponding to <c>TEXT</c> fields must be fewer than 512 characters.
    /// <c>TEXT_AREA</c> fields must be fewer than 4,096 characters. <c>BOOLEAN</c> fields
    /// must have a value of <c>true</c> or <c>false</c>.
    /// </para><para>
    /// An <c>InvalidRequestException</c> occurs when <c>UpdateContactTaskTemplate</c> is
    /// called on a connected or terminated task, when it is called on non-task contacts,
    /// and when the task contact already uses the provided task template. A <c>PropertyValidationException</c>
    /// occurs when the task's references conflict with the task template's fields, for example
    /// if the task is missing a reference that matches a required field, or if the task has
    /// a reference that matches a required field's name but not its datatype.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "CONNContactTaskTemplate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Connect Service UpdateContactTaskTemplate API operation.", Operation = new[] {"UpdateContactTaskTemplate"}, SelectReturnType = typeof(Amazon.Connect.Model.UpdateContactTaskTemplateResponse))]
    [AWSCmdletOutput("None or Amazon.Connect.Model.UpdateContactTaskTemplateResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Connect.Model.UpdateContactTaskTemplateResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateCONNContactTaskTemplateCmdlet : AmazonConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ContactId
        /// <summary>
        /// <para>
        /// <para>The identifier of the contact in this instance of Connect Customer. </para>
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
        public System.String ContactId { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Connect Customer instance. You can <a href="https://docs.aws.amazon.com/connect/latest/adminguide/find-instance-arn.html">find
        /// the instance ID</a> in the Amazon Resource Name (ARN) of the instance.</para>
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
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter TaskTemplateId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the task template. For more information about task templates,
        /// see <a href="https://docs.aws.amazon.com/connect/latest/adminguide/task-templates.html">Task
        /// templates</a> in the <i>Connect Customer Administrator Guide</i>.</para>
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
        public System.String TaskTemplateId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Connect.Model.UpdateContactTaskTemplateResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var targetParameterNames = new string[]
            {
                nameof(this.ContactId),
                nameof(this.InstanceId),
                nameof(this.TaskTemplateId)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CONNContactTaskTemplate (UpdateContactTaskTemplate)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Connect.Model.UpdateContactTaskTemplateResponse, UpdateCONNContactTaskTemplateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ContactId = this.ContactId;
            #if MODULAR
            if (this.ContactId == null && ParameterWasBound(nameof(this.ContactId)))
            {
                WriteWarning("You are passing $null as a value for parameter ContactId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TaskTemplateId = this.TaskTemplateId;
            #if MODULAR
            if (this.TaskTemplateId == null && ParameterWasBound(nameof(this.TaskTemplateId)))
            {
                WriteWarning("You are passing $null as a value for parameter TaskTemplateId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Connect.Model.UpdateContactTaskTemplateRequest();
            
            if (cmdletContext.ContactId != null)
            {
                request.ContactId = cmdletContext.ContactId;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            if (cmdletContext.TaskTemplateId != null)
            {
                request.TaskTemplateId = cmdletContext.TaskTemplateId;
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
        
        private Amazon.Connect.Model.UpdateContactTaskTemplateResponse CallAWSServiceOperation(IAmazonConnect client, Amazon.Connect.Model.UpdateContactTaskTemplateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Service", "UpdateContactTaskTemplate");
            try
            {
                return client.UpdateContactTaskTemplateAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ContactId { get; set; }
            public System.String InstanceId { get; set; }
            public System.String TaskTemplateId { get; set; }
            public System.Func<Amazon.Connect.Model.UpdateContactTaskTemplateResponse, UpdateCONNContactTaskTemplateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
