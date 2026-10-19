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
    /// Creates a new retrieval instruction. The retrieval instruction is usable once its
    /// status becomes ACTIVE. Use GetRetrievalInstruction to check whether it is ready.
    /// </summary>
    [Cmdlet("New", "AABRetrievalInstruction", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BedrockAgent.Model.CreateRetrievalInstructionResponse")]
    [AWSCmdlet("Calls the Agents for Amazon Bedrock CreateRetrievalInstruction API operation.", Operation = new[] {"CreateRetrievalInstruction"}, SelectReturnType = typeof(Amazon.BedrockAgent.Model.CreateRetrievalInstructionResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgent.Model.CreateRetrievalInstructionResponse",
        "This cmdlet returns an Amazon.BedrockAgent.Model.CreateRetrievalInstructionResponse object containing multiple properties."
    )]
    public partial class NewAABRetrievalInstructionCmdlet : AmazonBedrockAgentClientCmdlet, IExecutor
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
        
        #region Parameter CustomerEncryptionKeyArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of a customer managed AWS Key Management Service (AWS
        /// KMS) key used to encrypt the instruction content at rest. If you omit it, the service
        /// uses an AWS owned key. You fix the key at create and cannot change it later.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomerEncryptionKeyArn { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>Specifies a description of the retrieval instruction.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>Specifies the name of the retrieval instruction.</para>
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
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Tags for the retrieval instruction.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A caller-supplied token that makes a retried create return the existing resource rather
        /// than a second one. The window is 8 hours.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgent.Model.CreateRetrievalInstructionResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgent.Model.CreateRetrievalInstructionResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters, new System.Collections.Generic.HashSet<string> { nameof(this.Name) });
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-AABRetrievalInstruction (CreateRetrievalInstruction)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgent.Model.CreateRetrievalInstructionResponse, NewAABRetrievalInstructionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.CustomerEncryptionKeyArn = this.CustomerEncryptionKeyArn;
            context.Description = this.Description;
            context.Instruction_AnswerFormat = this.Instruction_AnswerFormat;
            context.Instruction_AnswerPolicy = this.Instruction_AnswerPolicy;
            context.Instruction_Persona = this.Instruction_Persona;
            context.Instruction_RetrievalGuidance = this.Instruction_RetrievalGuidance;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
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
            var request = new Amazon.BedrockAgent.Model.CreateRetrievalInstructionRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.CustomerEncryptionKeyArn != null)
            {
                request.CustomerEncryptionKeyArn = cmdletContext.CustomerEncryptionKeyArn;
            }
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
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.BedrockAgent.Model.CreateRetrievalInstructionResponse CallAWSServiceOperation(IAmazonBedrockAgent client, Amazon.BedrockAgent.Model.CreateRetrievalInstructionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Agents for Amazon Bedrock", "CreateRetrievalInstruction");
            try
            {
                return client.CreateRetrievalInstructionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String CustomerEncryptionKeyArn { get; set; }
            public System.String Description { get; set; }
            public System.String Instruction_AnswerFormat { get; set; }
            public System.String Instruction_AnswerPolicy { get; set; }
            public System.String Instruction_Persona { get; set; }
            public System.String Instruction_RetrievalGuidance { get; set; }
            public System.String Name { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.BedrockAgent.Model.CreateRetrievalInstructionResponse, NewAABRetrievalInstructionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
