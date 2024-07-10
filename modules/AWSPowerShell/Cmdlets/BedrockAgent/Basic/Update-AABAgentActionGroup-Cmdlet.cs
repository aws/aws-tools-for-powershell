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
using Amazon.BedrockAgent;
using Amazon.BedrockAgent.Model;

namespace Amazon.PowerShell.Cmdlets.AAB
{
    /// <summary>
    /// Updates the configuration for an action group for an agent.
    /// </summary>
    [Cmdlet("Update", "AABAgentActionGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BedrockAgent.Model.AgentActionGroup")]
    [AWSCmdlet("Calls the Agents for Amazon Bedrock UpdateAgentActionGroup API operation.", Operation = new[] {"UpdateAgentActionGroup"}, SelectReturnType = typeof(Amazon.BedrockAgent.Model.UpdateAgentActionGroupResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgent.Model.AgentActionGroup or Amazon.BedrockAgent.Model.UpdateAgentActionGroupResponse",
        "This cmdlet returns an Amazon.BedrockAgent.Model.AgentActionGroup object.",
        "The service call response (type Amazon.BedrockAgent.Model.UpdateAgentActionGroupResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateAABAgentActionGroupCmdlet : AmazonBedrockAgentClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ActionGroupId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the action group.</para>
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
        public System.String ActionGroupId { get; set; }
        #endregion
        
        #region Parameter ActionGroupName
        /// <summary>
        /// <para>
        /// <para>Specifies a new name for the action group.</para>
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
        public System.String ActionGroupName { get; set; }
        #endregion
        
        #region Parameter ActionGroupState
        /// <summary>
        /// <para>
        /// <para>Specifies whether the action group is available for the agent to invoke or not when
        /// sending an <a href="https://docs.aws.amazon.com/bedrock/latest/APIReference/API_agent-runtime_InvokeAgent.html">InvokeAgent</a>
        /// request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockAgent.ActionGroupState")]
        public Amazon.BedrockAgent.ActionGroupState ActionGroupState { get; set; }
        #endregion
        
        #region Parameter AgentId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the agent for which to update the action group.</para>
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
        public System.String AgentId { get; set; }
        #endregion
        
        #region Parameter AgentVersion
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the agent version for which to update the action group.</para>
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
        public System.String AgentVersion { get; set; }
        #endregion
        
        #region Parameter ActionGroupExecutor_CustomControl
        /// <summary>
        /// <para>
        /// <para>To return the action group invocation results directly in the <c>InvokeAgent</c> response,
        /// specify <c>RETURN_CONTROL</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockAgent.CustomControlMethod")]
        public Amazon.BedrockAgent.CustomControlMethod ActionGroupExecutor_CustomControl { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>Specifies a new name for the action group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter FunctionSchema_Function
        /// <summary>
        /// <para>
        /// <para>A list of functions that each define an action in the action group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FunctionSchema_Functions")]
        public Amazon.BedrockAgent.Model.Function[] FunctionSchema_Function { get; set; }
        #endregion
        
        #region Parameter ActionGroupExecutor_Lambda
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Lambda function containing the business logic
        /// that is carried out upon invoking the action.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ActionGroupExecutor_Lambda { get; set; }
        #endregion
        
        #region Parameter ParentActionGroupSignature
        /// <summary>
        /// <para>
        /// <para>To allow your agent to request the user for additional information when trying to
        /// complete a task, set this field to <c>AMAZON.UserInput</c>. You must leave the <c>description</c>,
        /// <c>apiSchema</c>, and <c>actionGroupExecutor</c> fields blank for this action group.</para><para>During orchestration, if your agent determines that it needs to invoke an API in an
        /// action group, but doesn't have enough information to complete the API request, it
        /// will invoke this action group instead and return an <a href="https://docs.aws.amazon.com/bedrock/latest/APIReference/API_agent-runtime_Observation.html">Observation</a>
        /// reprompting the user for more information.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockAgent.ActionGroupSignature")]
        public Amazon.BedrockAgent.ActionGroupSignature ParentActionGroupSignature { get; set; }
        #endregion
        
        #region Parameter ApiSchema_Payload
        /// <summary>
        /// <para>
        /// <para>The JSON or YAML-formatted payload defining the OpenAPI schema for the action group.
        /// For more information, see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/agents-api-schema.html">Action
        /// group OpenAPI schemas</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ApiSchema_Payload { get; set; }
        #endregion
        
        #region Parameter S3_S3BucketName
        /// <summary>
        /// <para>
        /// <para>The name of the S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ApiSchema_S3_S3BucketName")]
        public System.String S3_S3BucketName { get; set; }
        #endregion
        
        #region Parameter S3_S3ObjectKey
        /// <summary>
        /// <para>
        /// <para>The S3 object key for the S3 resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ApiSchema_S3_S3ObjectKey")]
        public System.String S3_S3ObjectKey { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AgentActionGroup'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgent.Model.UpdateAgentActionGroupResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgent.Model.UpdateAgentActionGroupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AgentActionGroup";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AgentId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AgentId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AgentId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AgentId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-AABAgentActionGroup (UpdateAgentActionGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgent.Model.UpdateAgentActionGroupResponse, UpdateAABAgentActionGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AgentId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ActionGroupExecutor_CustomControl = this.ActionGroupExecutor_CustomControl;
            context.ActionGroupExecutor_Lambda = this.ActionGroupExecutor_Lambda;
            context.ActionGroupId = this.ActionGroupId;
            #if MODULAR
            if (this.ActionGroupId == null && ParameterWasBound(nameof(this.ActionGroupId)))
            {
                WriteWarning("You are passing $null as a value for parameter ActionGroupId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ActionGroupName = this.ActionGroupName;
            #if MODULAR
            if (this.ActionGroupName == null && ParameterWasBound(nameof(this.ActionGroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter ActionGroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ActionGroupState = this.ActionGroupState;
            context.AgentId = this.AgentId;
            #if MODULAR
            if (this.AgentId == null && ParameterWasBound(nameof(this.AgentId)))
            {
                WriteWarning("You are passing $null as a value for parameter AgentId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AgentVersion = this.AgentVersion;
            #if MODULAR
            if (this.AgentVersion == null && ParameterWasBound(nameof(this.AgentVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter AgentVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ApiSchema_Payload = this.ApiSchema_Payload;
            context.S3_S3BucketName = this.S3_S3BucketName;
            context.S3_S3ObjectKey = this.S3_S3ObjectKey;
            context.Description = this.Description;
            if (this.FunctionSchema_Function != null)
            {
                context.FunctionSchema_Function = new List<Amazon.BedrockAgent.Model.Function>(this.FunctionSchema_Function);
            }
            context.ParentActionGroupSignature = this.ParentActionGroupSignature;
            
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
            var request = new Amazon.BedrockAgent.Model.UpdateAgentActionGroupRequest();
            
            
             // populate ActionGroupExecutor
            var requestActionGroupExecutorIsNull = true;
            request.ActionGroupExecutor = new Amazon.BedrockAgent.Model.ActionGroupExecutor();
            Amazon.BedrockAgent.CustomControlMethod requestActionGroupExecutor_actionGroupExecutor_CustomControl = null;
            if (cmdletContext.ActionGroupExecutor_CustomControl != null)
            {
                requestActionGroupExecutor_actionGroupExecutor_CustomControl = cmdletContext.ActionGroupExecutor_CustomControl;
            }
            if (requestActionGroupExecutor_actionGroupExecutor_CustomControl != null)
            {
                request.ActionGroupExecutor.CustomControl = requestActionGroupExecutor_actionGroupExecutor_CustomControl;
                requestActionGroupExecutorIsNull = false;
            }
            System.String requestActionGroupExecutor_actionGroupExecutor_Lambda = null;
            if (cmdletContext.ActionGroupExecutor_Lambda != null)
            {
                requestActionGroupExecutor_actionGroupExecutor_Lambda = cmdletContext.ActionGroupExecutor_Lambda;
            }
            if (requestActionGroupExecutor_actionGroupExecutor_Lambda != null)
            {
                request.ActionGroupExecutor.Lambda = requestActionGroupExecutor_actionGroupExecutor_Lambda;
                requestActionGroupExecutorIsNull = false;
            }
             // determine if request.ActionGroupExecutor should be set to null
            if (requestActionGroupExecutorIsNull)
            {
                request.ActionGroupExecutor = null;
            }
            if (cmdletContext.ActionGroupId != null)
            {
                request.ActionGroupId = cmdletContext.ActionGroupId;
            }
            if (cmdletContext.ActionGroupName != null)
            {
                request.ActionGroupName = cmdletContext.ActionGroupName;
            }
            if (cmdletContext.ActionGroupState != null)
            {
                request.ActionGroupState = cmdletContext.ActionGroupState;
            }
            if (cmdletContext.AgentId != null)
            {
                request.AgentId = cmdletContext.AgentId;
            }
            if (cmdletContext.AgentVersion != null)
            {
                request.AgentVersion = cmdletContext.AgentVersion;
            }
            
             // populate ApiSchema
            var requestApiSchemaIsNull = true;
            request.ApiSchema = new Amazon.BedrockAgent.Model.APISchema();
            System.String requestApiSchema_apiSchema_Payload = null;
            if (cmdletContext.ApiSchema_Payload != null)
            {
                requestApiSchema_apiSchema_Payload = cmdletContext.ApiSchema_Payload;
            }
            if (requestApiSchema_apiSchema_Payload != null)
            {
                request.ApiSchema.Payload = requestApiSchema_apiSchema_Payload;
                requestApiSchemaIsNull = false;
            }
            Amazon.BedrockAgent.Model.S3Identifier requestApiSchema_apiSchema_S3 = null;
            
             // populate S3
            var requestApiSchema_apiSchema_S3IsNull = true;
            requestApiSchema_apiSchema_S3 = new Amazon.BedrockAgent.Model.S3Identifier();
            System.String requestApiSchema_apiSchema_S3_s3_S3BucketName = null;
            if (cmdletContext.S3_S3BucketName != null)
            {
                requestApiSchema_apiSchema_S3_s3_S3BucketName = cmdletContext.S3_S3BucketName;
            }
            if (requestApiSchema_apiSchema_S3_s3_S3BucketName != null)
            {
                requestApiSchema_apiSchema_S3.S3BucketName = requestApiSchema_apiSchema_S3_s3_S3BucketName;
                requestApiSchema_apiSchema_S3IsNull = false;
            }
            System.String requestApiSchema_apiSchema_S3_s3_S3ObjectKey = null;
            if (cmdletContext.S3_S3ObjectKey != null)
            {
                requestApiSchema_apiSchema_S3_s3_S3ObjectKey = cmdletContext.S3_S3ObjectKey;
            }
            if (requestApiSchema_apiSchema_S3_s3_S3ObjectKey != null)
            {
                requestApiSchema_apiSchema_S3.S3ObjectKey = requestApiSchema_apiSchema_S3_s3_S3ObjectKey;
                requestApiSchema_apiSchema_S3IsNull = false;
            }
             // determine if requestApiSchema_apiSchema_S3 should be set to null
            if (requestApiSchema_apiSchema_S3IsNull)
            {
                requestApiSchema_apiSchema_S3 = null;
            }
            if (requestApiSchema_apiSchema_S3 != null)
            {
                request.ApiSchema.S3 = requestApiSchema_apiSchema_S3;
                requestApiSchemaIsNull = false;
            }
             // determine if request.ApiSchema should be set to null
            if (requestApiSchemaIsNull)
            {
                request.ApiSchema = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            
             // populate FunctionSchema
            var requestFunctionSchemaIsNull = true;
            request.FunctionSchema = new Amazon.BedrockAgent.Model.FunctionSchema();
            List<Amazon.BedrockAgent.Model.Function> requestFunctionSchema_functionSchema_Function = null;
            if (cmdletContext.FunctionSchema_Function != null)
            {
                requestFunctionSchema_functionSchema_Function = cmdletContext.FunctionSchema_Function;
            }
            if (requestFunctionSchema_functionSchema_Function != null)
            {
                request.FunctionSchema.Functions = requestFunctionSchema_functionSchema_Function;
                requestFunctionSchemaIsNull = false;
            }
             // determine if request.FunctionSchema should be set to null
            if (requestFunctionSchemaIsNull)
            {
                request.FunctionSchema = null;
            }
            if (cmdletContext.ParentActionGroupSignature != null)
            {
                request.ParentActionGroupSignature = cmdletContext.ParentActionGroupSignature;
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
        
        private Amazon.BedrockAgent.Model.UpdateAgentActionGroupResponse CallAWSServiceOperation(IAmazonBedrockAgent client, Amazon.BedrockAgent.Model.UpdateAgentActionGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Agents for Amazon Bedrock", "UpdateAgentActionGroup");
            try
            {
                #if DESKTOP
                return client.UpdateAgentActionGroup(request);
                #elif CORECLR
                return client.UpdateAgentActionGroupAsync(request).GetAwaiter().GetResult();
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
            public Amazon.BedrockAgent.CustomControlMethod ActionGroupExecutor_CustomControl { get; set; }
            public System.String ActionGroupExecutor_Lambda { get; set; }
            public System.String ActionGroupId { get; set; }
            public System.String ActionGroupName { get; set; }
            public Amazon.BedrockAgent.ActionGroupState ActionGroupState { get; set; }
            public System.String AgentId { get; set; }
            public System.String AgentVersion { get; set; }
            public System.String ApiSchema_Payload { get; set; }
            public System.String S3_S3BucketName { get; set; }
            public System.String S3_S3ObjectKey { get; set; }
            public System.String Description { get; set; }
            public List<Amazon.BedrockAgent.Model.Function> FunctionSchema_Function { get; set; }
            public Amazon.BedrockAgent.ActionGroupSignature ParentActionGroupSignature { get; set; }
            public System.Func<Amazon.BedrockAgent.Model.UpdateAgentActionGroupResponse, UpdateAABAgentActionGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AgentActionGroup;
        }
        
    }
}
