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
using Amazon.BedrockAgentRuntime;
using Amazon.BedrockAgentRuntime.Model;

namespace Amazon.PowerShell.Cmdlets.BAR
{
    /// <summary>
    /// Creates a session to temporarily store conversations for generative AI (GenAI) applications
    /// built with open-source frameworks such as LangGraph and LlamaIndex. Sessions enable
    /// you to save the state of conversations at checkpoints, with the added security and
    /// infrastructure of Amazon Web Services. For more information, see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/sessions.html">Store
    /// and retrieve conversation history and context with Amazon Bedrock sessions</a>.
    /// 
    ///  
    /// <para>
    /// By default, Amazon Bedrock uses Amazon Web Services-managed keys for session encryption,
    /// including session metadata, or you can use your own KMS key. For more information,
    /// see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/session-encryption.html">Amazon
    /// Bedrock session encryption</a>.
    /// </para><note><para>
    ///  You use a session to store state and conversation history for generative AI applications
    /// built with open-source frameworks. For Amazon Bedrock Agents, the service automatically
    /// manages conversation context and associates them with the agent-specific sessionId
    /// you specify in the <a href="https://docs.aws.amazon.com/bedrock/latest/APIReference/API_agent-runtime_InvokeAgent.html">InvokeAgent</a>
    /// API operation. 
    /// </para></note><para>
    /// Related APIs:
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/bedrock/latest/APIReference/API_agent-runtime_ListSessions.html">ListSessions</a></para></li><li><para><a href="https://docs.aws.amazon.com/bedrock/latest/APIReference/API_agent-runtime_GetSession.html">GetSession</a></para></li><li><para><a href="https://docs.aws.amazon.com/bedrock/latest/APIReference/API_agent-runtime_EndSession.html">EndSession</a></para></li><li><para><a href="https://docs.aws.amazon.com/bedrock/latest/APIReference/API_agent-runtime_DeleteSession.html">DeleteSession</a></para></li></ul>
    /// </summary>
    [Cmdlet("New", "BARSession", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BedrockAgentRuntime.Model.CreateSessionResponse")]
    [AWSCmdlet("Calls the Amazon Bedrock Agent Runtime CreateSession API operation.", Operation = new[] {"CreateSession"}, SelectReturnType = typeof(Amazon.BedrockAgentRuntime.Model.CreateSessionResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgentRuntime.Model.CreateSessionResponse",
        "This cmdlet returns an Amazon.BedrockAgentRuntime.Model.CreateSessionResponse object containing multiple properties."
    )]
    public partial class NewBARSessionCmdlet : AmazonBedrockAgentRuntimeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter EncryptionKeyArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the KMS key to use to encrypt the session data.
        /// The user or role creating the session must have permission to use the key. For more
        /// information, see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/session-encryption.html">Amazon
        /// Bedrock session encryption</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String EncryptionKeyArn { get; set; }
        #endregion
        
        #region Parameter SessionMetadata
        /// <summary>
        /// <para>
        /// <para>A map of key-value pairs containing attributes to be persisted across the session.
        /// For example, the user's ID, their language preference, and the type of device they
        /// are using.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable SessionMetadata { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Specify the key-value pairs for the tags that you want to attach to the session.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgentRuntime.Model.CreateSessionResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgentRuntime.Model.CreateSessionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the EncryptionKeyArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^EncryptionKeyArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^EncryptionKeyArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.EncryptionKeyArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-BARSession (CreateSession)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgentRuntime.Model.CreateSessionResponse, NewBARSessionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.EncryptionKeyArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.EncryptionKeyArn = this.EncryptionKeyArn;
            if (this.SessionMetadata != null)
            {
                context.SessionMetadata = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.SessionMetadata.Keys)
                {
                    context.SessionMetadata.Add((String)hashKey, (System.String)(this.SessionMetadata[hashKey]));
                }
            }
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
            var request = new Amazon.BedrockAgentRuntime.Model.CreateSessionRequest();
            
            if (cmdletContext.EncryptionKeyArn != null)
            {
                request.EncryptionKeyArn = cmdletContext.EncryptionKeyArn;
            }
            if (cmdletContext.SessionMetadata != null)
            {
                request.SessionMetadata = cmdletContext.SessionMetadata;
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
        
        private Amazon.BedrockAgentRuntime.Model.CreateSessionResponse CallAWSServiceOperation(IAmazonBedrockAgentRuntime client, Amazon.BedrockAgentRuntime.Model.CreateSessionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock Agent Runtime", "CreateSession");
            try
            {
                #if DESKTOP
                return client.CreateSession(request);
                #elif CORECLR
                return client.CreateSessionAsync(request).GetAwaiter().GetResult();
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
            public System.String EncryptionKeyArn { get; set; }
            public Dictionary<System.String, System.String> SessionMetadata { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.BedrockAgentRuntime.Model.CreateSessionResponse, NewBARSessionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
