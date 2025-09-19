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
using Amazon.BedrockAgentCoreControl;
using Amazon.BedrockAgentCoreControl.Model;

namespace Amazon.PowerShell.Cmdlets.BACC
{
    /// <summary>
    /// Update an Amazon Bedrock AgentCore Memory resource memory.
    /// </summary>
    [Cmdlet("Update", "BACCMemory", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BedrockAgentCoreControl.Model.Memory")]
    [AWSCmdlet("Calls the Amazon Bedrock Agent Core Control Plane Fronting Layer UpdateMemory API operation.", Operation = new[] {"UpdateMemory"}, SelectReturnType = typeof(Amazon.BedrockAgentCoreControl.Model.UpdateMemoryResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgentCoreControl.Model.Memory or Amazon.BedrockAgentCoreControl.Model.UpdateMemoryResponse",
        "This cmdlet returns an Amazon.BedrockAgentCoreControl.Model.Memory object.",
        "The service call response (type Amazon.BedrockAgentCoreControl.Model.UpdateMemoryResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateBACCMemoryCmdlet : AmazonBedrockAgentCoreControlClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter MemoryStrategies_AddMemoryStrategy
        /// <summary>
        /// <para>
        /// <para>The list of memory strategies to add.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MemoryStrategies_AddMemoryStrategies")]
        public Amazon.BedrockAgentCoreControl.Model.MemoryStrategyInput[] MemoryStrategies_AddMemoryStrategy { get; set; }
        #endregion
        
        #region Parameter MemoryStrategies_DeleteMemoryStrategy
        /// <summary>
        /// <para>
        /// <para>The list of memory strategies to delete.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MemoryStrategies_DeleteMemoryStrategies")]
        public Amazon.BedrockAgentCoreControl.Model.DeleteMemoryStrategyInput[] MemoryStrategies_DeleteMemoryStrategy { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The updated description of the AgentCore Memory resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter EventExpiryDuration
        /// <summary>
        /// <para>
        /// <para>The number of days after which memory events will expire, between 7 and 365 days.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? EventExpiryDuration { get; set; }
        #endregion
        
        #region Parameter MemoryExecutionRoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role that provides permissions for the AgentCore Memory resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MemoryExecutionRoleArn { get; set; }
        #endregion
        
        #region Parameter MemoryId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the memory to update.</para>
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
        public System.String MemoryId { get; set; }
        #endregion
        
        #region Parameter MemoryStrategies_UpdateMemoryStrategy
        /// <summary>
        /// <para>
        /// <para>The list of memory strategies to modify.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MemoryStrategies_UpdateMemoryStrategies")]
        public Amazon.BedrockAgentCoreControl.Model.ModifyMemoryStrategyInput[] MemoryStrategies_UpdateMemoryStrategy { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A client token is used for keeping track of idempotent requests. It can contain a
        /// session id which can be around 250 chars, combined with a unique AWS identifier.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Memory'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgentCoreControl.Model.UpdateMemoryResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgentCoreControl.Model.UpdateMemoryResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Memory";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the MemoryId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^MemoryId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^MemoryId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.MemoryId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-BACCMemory (UpdateMemory)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgentCoreControl.Model.UpdateMemoryResponse, UpdateBACCMemoryCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.MemoryId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.EventExpiryDuration = this.EventExpiryDuration;
            context.MemoryExecutionRoleArn = this.MemoryExecutionRoleArn;
            context.MemoryId = this.MemoryId;
            #if MODULAR
            if (this.MemoryId == null && ParameterWasBound(nameof(this.MemoryId)))
            {
                WriteWarning("You are passing $null as a value for parameter MemoryId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.MemoryStrategies_AddMemoryStrategy != null)
            {
                context.MemoryStrategies_AddMemoryStrategy = new List<Amazon.BedrockAgentCoreControl.Model.MemoryStrategyInput>(this.MemoryStrategies_AddMemoryStrategy);
            }
            if (this.MemoryStrategies_DeleteMemoryStrategy != null)
            {
                context.MemoryStrategies_DeleteMemoryStrategy = new List<Amazon.BedrockAgentCoreControl.Model.DeleteMemoryStrategyInput>(this.MemoryStrategies_DeleteMemoryStrategy);
            }
            if (this.MemoryStrategies_UpdateMemoryStrategy != null)
            {
                context.MemoryStrategies_UpdateMemoryStrategy = new List<Amazon.BedrockAgentCoreControl.Model.ModifyMemoryStrategyInput>(this.MemoryStrategies_UpdateMemoryStrategy);
            }
            
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
            var request = new Amazon.BedrockAgentCoreControl.Model.UpdateMemoryRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.EventExpiryDuration != null)
            {
                request.EventExpiryDuration = cmdletContext.EventExpiryDuration.Value;
            }
            if (cmdletContext.MemoryExecutionRoleArn != null)
            {
                request.MemoryExecutionRoleArn = cmdletContext.MemoryExecutionRoleArn;
            }
            if (cmdletContext.MemoryId != null)
            {
                request.MemoryId = cmdletContext.MemoryId;
            }
            
             // populate MemoryStrategies
            var requestMemoryStrategiesIsNull = true;
            request.MemoryStrategies = new Amazon.BedrockAgentCoreControl.Model.ModifyMemoryStrategies();
            List<Amazon.BedrockAgentCoreControl.Model.MemoryStrategyInput> requestMemoryStrategies_memoryStrategies_AddMemoryStrategy = null;
            if (cmdletContext.MemoryStrategies_AddMemoryStrategy != null)
            {
                requestMemoryStrategies_memoryStrategies_AddMemoryStrategy = cmdletContext.MemoryStrategies_AddMemoryStrategy;
            }
            if (requestMemoryStrategies_memoryStrategies_AddMemoryStrategy != null)
            {
                request.MemoryStrategies.AddMemoryStrategies = requestMemoryStrategies_memoryStrategies_AddMemoryStrategy;
                requestMemoryStrategiesIsNull = false;
            }
            List<Amazon.BedrockAgentCoreControl.Model.DeleteMemoryStrategyInput> requestMemoryStrategies_memoryStrategies_DeleteMemoryStrategy = null;
            if (cmdletContext.MemoryStrategies_DeleteMemoryStrategy != null)
            {
                requestMemoryStrategies_memoryStrategies_DeleteMemoryStrategy = cmdletContext.MemoryStrategies_DeleteMemoryStrategy;
            }
            if (requestMemoryStrategies_memoryStrategies_DeleteMemoryStrategy != null)
            {
                request.MemoryStrategies.DeleteMemoryStrategies = requestMemoryStrategies_memoryStrategies_DeleteMemoryStrategy;
                requestMemoryStrategiesIsNull = false;
            }
            List<Amazon.BedrockAgentCoreControl.Model.ModifyMemoryStrategyInput> requestMemoryStrategies_memoryStrategies_UpdateMemoryStrategy = null;
            if (cmdletContext.MemoryStrategies_UpdateMemoryStrategy != null)
            {
                requestMemoryStrategies_memoryStrategies_UpdateMemoryStrategy = cmdletContext.MemoryStrategies_UpdateMemoryStrategy;
            }
            if (requestMemoryStrategies_memoryStrategies_UpdateMemoryStrategy != null)
            {
                request.MemoryStrategies.UpdateMemoryStrategies = requestMemoryStrategies_memoryStrategies_UpdateMemoryStrategy;
                requestMemoryStrategiesIsNull = false;
            }
             // determine if request.MemoryStrategies should be set to null
            if (requestMemoryStrategiesIsNull)
            {
                request.MemoryStrategies = null;
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
        
        private Amazon.BedrockAgentCoreControl.Model.UpdateMemoryResponse CallAWSServiceOperation(IAmazonBedrockAgentCoreControl client, Amazon.BedrockAgentCoreControl.Model.UpdateMemoryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock Agent Core Control Plane Fronting Layer", "UpdateMemory");
            try
            {
                #if DESKTOP
                return client.UpdateMemory(request);
                #elif CORECLR
                return client.UpdateMemoryAsync(request).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.Int32? EventExpiryDuration { get; set; }
            public System.String MemoryExecutionRoleArn { get; set; }
            public System.String MemoryId { get; set; }
            public List<Amazon.BedrockAgentCoreControl.Model.MemoryStrategyInput> MemoryStrategies_AddMemoryStrategy { get; set; }
            public List<Amazon.BedrockAgentCoreControl.Model.DeleteMemoryStrategyInput> MemoryStrategies_DeleteMemoryStrategy { get; set; }
            public List<Amazon.BedrockAgentCoreControl.Model.ModifyMemoryStrategyInput> MemoryStrategies_UpdateMemoryStrategy { get; set; }
            public System.Func<Amazon.BedrockAgentCoreControl.Model.UpdateMemoryResponse, UpdateBACCMemoryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Memory;
        }
        
    }
}
