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
using Amazon.Connect;
using Amazon.Connect.Model;

namespace Amazon.PowerShell.Cmdlets.CONN
{
    /// <summary>
    /// Creates a new task template in the specified Amazon Connect instance.
    /// </summary>
    [Cmdlet("New", "CONNTaskTemplate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Connect.Model.CreateTaskTemplateResponse")]
    [AWSCmdlet("Calls the Amazon Connect Service CreateTaskTemplate API operation.", Operation = new[] {"CreateTaskTemplate"}, SelectReturnType = typeof(Amazon.Connect.Model.CreateTaskTemplateResponse))]
    [AWSCmdletOutput("Amazon.Connect.Model.CreateTaskTemplateResponse",
        "This cmdlet returns an Amazon.Connect.Model.CreateTaskTemplateResponse object containing multiple properties."
    )]
    public partial class NewCONNTaskTemplateCmdlet : AmazonConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ContactFlowId
        /// <summary>
        /// <para>
        /// <para>The identifier of the flow that runs by default when a task is created by referencing
        /// this template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ContactFlowId { get; set; }
        #endregion
        
        #region Parameter Defaults_DefaultFieldValue
        /// <summary>
        /// <para>
        /// <para>Default value for the field.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Defaults_DefaultFieldValues")]
        public Amazon.Connect.Model.TaskTemplateDefaultFieldValue[] Defaults_DefaultFieldValue { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the task template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Field
        /// <summary>
        /// <para>
        /// <para>Fields that are part of the template.</para>
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
        [Alias("Fields")]
        public Amazon.Connect.Model.TaskTemplateField[] Field { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon Connect instance. You can <a href="https://docs.aws.amazon.com/connect/latest/adminguide/find-instance-arn.html">find
        /// the instance ID</a> in the Amazon Resource Name (ARN) of the instance.</para>
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
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter Constraints_InvisibleField
        /// <summary>
        /// <para>
        /// <para>Lists the fields that are invisible to agents.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Constraints_InvisibleFields")]
        public Amazon.Connect.Model.InvisibleFieldInfo[] Constraints_InvisibleField { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the task template.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Constraints_ReadOnlyField
        /// <summary>
        /// <para>
        /// <para>Lists the fields that are read-only to agents, and cannot be edited.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Constraints_ReadOnlyFields")]
        public Amazon.Connect.Model.ReadOnlyFieldInfo[] Constraints_ReadOnlyField { get; set; }
        #endregion
        
        #region Parameter Constraints_RequiredField
        /// <summary>
        /// <para>
        /// <para>Lists the fields that are required to be filled by agents.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Constraints_RequiredFields")]
        public Amazon.Connect.Model.RequiredFieldInfo[] Constraints_RequiredField { get; set; }
        #endregion
        
        #region Parameter SelfAssignFlowId
        /// <summary>
        /// <para>
        /// <para>The ContactFlowId for the flow that will be run if this template is used to create
        /// a self-assigned task.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SelfAssignFlowId { get; set; }
        #endregion
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>Marks a template as <c>ACTIVE</c> or <c>INACTIVE</c> for a task to refer to it. Tasks
        /// can only be created from <c>ACTIVE</c> templates. If a template is marked as <c>INACTIVE</c>,
        /// then a task that refers to this template cannot be created. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Connect.TaskTemplateStatus")]
        public Amazon.Connect.TaskTemplateStatus Status { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request. If not provided, the Amazon Web Services SDK populates this field. For
        /// more information about idempotency, see <a href="https://aws.amazon.com/builders-library/making-retries-safe-with-idempotent-APIs/">Making
        /// retries safe with idempotent APIs</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Connect.Model.CreateTaskTemplateResponse).
        /// Specifying the name of a property of type Amazon.Connect.Model.CreateTaskTemplateResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the InstanceId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^InstanceId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^InstanceId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.InstanceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CONNTaskTemplate (CreateTaskTemplate)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Connect.Model.CreateTaskTemplateResponse, NewCONNTaskTemplateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.InstanceId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            if (this.Constraints_InvisibleField != null)
            {
                context.Constraints_InvisibleField = new List<Amazon.Connect.Model.InvisibleFieldInfo>(this.Constraints_InvisibleField);
            }
            if (this.Constraints_ReadOnlyField != null)
            {
                context.Constraints_ReadOnlyField = new List<Amazon.Connect.Model.ReadOnlyFieldInfo>(this.Constraints_ReadOnlyField);
            }
            if (this.Constraints_RequiredField != null)
            {
                context.Constraints_RequiredField = new List<Amazon.Connect.Model.RequiredFieldInfo>(this.Constraints_RequiredField);
            }
            context.ContactFlowId = this.ContactFlowId;
            if (this.Defaults_DefaultFieldValue != null)
            {
                context.Defaults_DefaultFieldValue = new List<Amazon.Connect.Model.TaskTemplateDefaultFieldValue>(this.Defaults_DefaultFieldValue);
            }
            context.Description = this.Description;
            if (this.Field != null)
            {
                context.Field = new List<Amazon.Connect.Model.TaskTemplateField>(this.Field);
            }
            #if MODULAR
            if (this.Field == null && ParameterWasBound(nameof(this.Field)))
            {
                WriteWarning("You are passing $null as a value for parameter Field which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SelfAssignFlowId = this.SelfAssignFlowId;
            context.Status = this.Status;
            
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
            var request = new Amazon.Connect.Model.CreateTaskTemplateRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate Constraints
            var requestConstraintsIsNull = true;
            request.Constraints = new Amazon.Connect.Model.TaskTemplateConstraints();
            List<Amazon.Connect.Model.InvisibleFieldInfo> requestConstraints_constraints_InvisibleField = null;
            if (cmdletContext.Constraints_InvisibleField != null)
            {
                requestConstraints_constraints_InvisibleField = cmdletContext.Constraints_InvisibleField;
            }
            if (requestConstraints_constraints_InvisibleField != null)
            {
                request.Constraints.InvisibleFields = requestConstraints_constraints_InvisibleField;
                requestConstraintsIsNull = false;
            }
            List<Amazon.Connect.Model.ReadOnlyFieldInfo> requestConstraints_constraints_ReadOnlyField = null;
            if (cmdletContext.Constraints_ReadOnlyField != null)
            {
                requestConstraints_constraints_ReadOnlyField = cmdletContext.Constraints_ReadOnlyField;
            }
            if (requestConstraints_constraints_ReadOnlyField != null)
            {
                request.Constraints.ReadOnlyFields = requestConstraints_constraints_ReadOnlyField;
                requestConstraintsIsNull = false;
            }
            List<Amazon.Connect.Model.RequiredFieldInfo> requestConstraints_constraints_RequiredField = null;
            if (cmdletContext.Constraints_RequiredField != null)
            {
                requestConstraints_constraints_RequiredField = cmdletContext.Constraints_RequiredField;
            }
            if (requestConstraints_constraints_RequiredField != null)
            {
                request.Constraints.RequiredFields = requestConstraints_constraints_RequiredField;
                requestConstraintsIsNull = false;
            }
             // determine if request.Constraints should be set to null
            if (requestConstraintsIsNull)
            {
                request.Constraints = null;
            }
            if (cmdletContext.ContactFlowId != null)
            {
                request.ContactFlowId = cmdletContext.ContactFlowId;
            }
            
             // populate Defaults
            var requestDefaultsIsNull = true;
            request.Defaults = new Amazon.Connect.Model.TaskTemplateDefaults();
            List<Amazon.Connect.Model.TaskTemplateDefaultFieldValue> requestDefaults_defaults_DefaultFieldValue = null;
            if (cmdletContext.Defaults_DefaultFieldValue != null)
            {
                requestDefaults_defaults_DefaultFieldValue = cmdletContext.Defaults_DefaultFieldValue;
            }
            if (requestDefaults_defaults_DefaultFieldValue != null)
            {
                request.Defaults.DefaultFieldValues = requestDefaults_defaults_DefaultFieldValue;
                requestDefaultsIsNull = false;
            }
             // determine if request.Defaults should be set to null
            if (requestDefaultsIsNull)
            {
                request.Defaults = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Field != null)
            {
                request.Fields = cmdletContext.Field;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.SelfAssignFlowId != null)
            {
                request.SelfAssignFlowId = cmdletContext.SelfAssignFlowId;
            }
            if (cmdletContext.Status != null)
            {
                request.Status = cmdletContext.Status;
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
        
        private Amazon.Connect.Model.CreateTaskTemplateResponse CallAWSServiceOperation(IAmazonConnect client, Amazon.Connect.Model.CreateTaskTemplateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Service", "CreateTaskTemplate");
            try
            {
                #if DESKTOP
                return client.CreateTaskTemplate(request);
                #elif CORECLR
                return client.CreateTaskTemplateAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public List<Amazon.Connect.Model.InvisibleFieldInfo> Constraints_InvisibleField { get; set; }
            public List<Amazon.Connect.Model.ReadOnlyFieldInfo> Constraints_ReadOnlyField { get; set; }
            public List<Amazon.Connect.Model.RequiredFieldInfo> Constraints_RequiredField { get; set; }
            public System.String ContactFlowId { get; set; }
            public List<Amazon.Connect.Model.TaskTemplateDefaultFieldValue> Defaults_DefaultFieldValue { get; set; }
            public System.String Description { get; set; }
            public List<Amazon.Connect.Model.TaskTemplateField> Field { get; set; }
            public System.String InstanceId { get; set; }
            public System.String Name { get; set; }
            public System.String SelfAssignFlowId { get; set; }
            public Amazon.Connect.TaskTemplateStatus Status { get; set; }
            public System.Func<Amazon.Connect.Model.CreateTaskTemplateResponse, NewCONNTaskTemplateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
