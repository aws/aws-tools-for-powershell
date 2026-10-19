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
using Amazon.BedrockAgent;
using Amazon.BedrockAgent.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.AAB
{
    /// <summary>
    /// Updates the content of a retrieval instruction. The update is processed asynchronously;
    /// the stored content is a candidate until content review passes, and the served content
    /// does not change while the update is in flight. The service rejects the request with
    /// ConflictException while lastTransitionStatus is CREATING or UPDATING.
    /// </summary>
    [Cmdlet("Update", "AABRetrievalInstruction", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BedrockAgent.Model.UpdateRetrievalInstructionResponse")]
    [AWSCmdlet("Calls the Agents for Amazon Bedrock UpdateRetrievalInstruction API operation.", Operation = new[] {"UpdateRetrievalInstruction"}, SelectReturnType = typeof(Amazon.BedrockAgent.Model.UpdateRetrievalInstructionResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgent.Model.UpdateRetrievalInstructionResponse",
        "This cmdlet returns an Amazon.BedrockAgent.Model.UpdateRetrievalInstructionResponse object containing multiple properties."
    )]
    public partial class UpdateAABRetrievalInstructionCmdlet : AmazonBedrockAgentClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Instruction_AnswerFormat
        /// <summary>
        /// <para>
        /// <para>How the answer is structured, including how sources are cited.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Instruction_AnswerFormat { get; set; }
        #endregion
        
        #region Parameter Instruction_AnswerPolicy
        /// <summary>
        /// <para>
        /// <para>Whether and how to answer: how strongly an answer must be supported, and what to do
        /// with questions outside scope.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Instruction_AnswerPolicy { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A replacement description; applied together with the content when the review passes.
        /// Omit to clear.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Instruction_Persona
        /// <summary>
        /// <para>
        /// <para>Who the assistant is: identity, tone and language.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Instruction_Persona { get; set; }
        #endregion
        
        #region Parameter Instruction_RetrievalGuidance
        /// <summary>
        /// <para>
        /// <para>How to interpret and decompose the question, and what to prioritise when searching.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Instruction_RetrievalGuidance { get; set; }
        #endregion
        
        #region Parameter RetrievalInstructionId
        /// <summary>
        /// <para>
        /// <para>The identifier of the retrieval instruction to update.</para>
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
        public System.String RetrievalInstructionId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgent.Model.UpdateRetrievalInstructionResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgent.Model.UpdateRetrievalInstructionResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RetrievalInstructionId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-AABRetrievalInstruction (UpdateRetrievalInstruction)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgent.Model.UpdateRetrievalInstructionResponse, UpdateAABRetrievalInstructionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Description = this.Description;
            context.Instruction_AnswerFormat = this.Instruction_AnswerFormat;
            context.Instruction_AnswerPolicy = this.Instruction_AnswerPolicy;
            context.Instruction_Persona = this.Instruction_Persona;
            context.Instruction_RetrievalGuidance = this.Instruction_RetrievalGuidance;
            context.RetrievalInstructionId = this.RetrievalInstructionId;
            #if MODULAR
            if (this.RetrievalInstructionId == null && ParameterWasBound(nameof(this.RetrievalInstructionId)))
            {
                WriteWarning("You are passing $null as a value for parameter RetrievalInstructionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.BedrockAgent.Model.UpdateRetrievalInstructionRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            
             // populate Instruction
            var requestInstructionIsNull = true;
            request.Instruction = new Amazon.BedrockAgent.Model.RetrievalInstructionContent();
            System.String requestInstruction_instruction_AnswerFormat = null;
            if (cmdletContext.Instruction_AnswerFormat != null)
            {
                requestInstruction_instruction_AnswerFormat = cmdletContext.Instruction_AnswerFormat;
            }
            if (requestInstruction_instruction_AnswerFormat != null)
            {
                request.Instruction.AnswerFormat = requestInstruction_instruction_AnswerFormat;
                requestInstructionIsNull = false;
            }
            System.String requestInstruction_instruction_AnswerPolicy = null;
            if (cmdletContext.Instruction_AnswerPolicy != null)
            {
                requestInstruction_instruction_AnswerPolicy = cmdletContext.Instruction_AnswerPolicy;
            }
            if (requestInstruction_instruction_AnswerPolicy != null)
            {
                request.Instruction.AnswerPolicy = requestInstruction_instruction_AnswerPolicy;
                requestInstructionIsNull = false;
            }
            System.String requestInstruction_instruction_Persona = null;
            if (cmdletContext.Instruction_Persona != null)
            {
                requestInstruction_instruction_Persona = cmdletContext.Instruction_Persona;
            }
            if (requestInstruction_instruction_Persona != null)
            {
                request.Instruction.Persona = requestInstruction_instruction_Persona;
                requestInstructionIsNull = false;
            }
            System.String requestInstruction_instruction_RetrievalGuidance = null;
            if (cmdletContext.Instruction_RetrievalGuidance != null)
            {
                requestInstruction_instruction_RetrievalGuidance = cmdletContext.Instruction_RetrievalGuidance;
            }
            if (requestInstruction_instruction_RetrievalGuidance != null)
            {
                request.Instruction.RetrievalGuidance = requestInstruction_instruction_RetrievalGuidance;
                requestInstructionIsNull = false;
            }
             // determine if request.Instruction should be set to null
            if (requestInstructionIsNull)
            {
                request.Instruction = null;
            }
            if (cmdletContext.RetrievalInstructionId != null)
            {
                request.RetrievalInstructionId = cmdletContext.RetrievalInstructionId;
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
        
        private Amazon.BedrockAgent.Model.UpdateRetrievalInstructionResponse CallAWSServiceOperation(IAmazonBedrockAgent client, Amazon.BedrockAgent.Model.UpdateRetrievalInstructionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Agents for Amazon Bedrock", "UpdateRetrievalInstruction");
            try
            {
                return client.UpdateRetrievalInstructionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.String Instruction_AnswerFormat { get; set; }
            public System.String Instruction_AnswerPolicy { get; set; }
            public System.String Instruction_Persona { get; set; }
            public System.String Instruction_RetrievalGuidance { get; set; }
            public System.String RetrievalInstructionId { get; set; }
            public System.Func<Amazon.BedrockAgent.Model.UpdateRetrievalInstructionResponse, UpdateAABRetrievalInstructionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
