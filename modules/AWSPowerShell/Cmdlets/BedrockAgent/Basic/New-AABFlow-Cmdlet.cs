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
    /// Creates a prompt flow that you can use to send an input through various steps to yield
    /// an output. Configure nodes, each of which corresponds to a step of the flow, and create
    /// connections between the nodes to create paths to different outputs. For more information,
    /// see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/flows-how-it-works.html">How
    /// it works</a> and <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/flows-create.html">Create
    /// a flow in Amazon Bedrock</a> in the Amazon Bedrock User Guide.
    /// </summary>
    [Cmdlet("New", "AABFlow", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BedrockAgent.Model.CreateFlowResponse")]
    [AWSCmdlet("Calls the Agents for Amazon Bedrock CreateFlow API operation.", Operation = new[] {"CreateFlow"}, SelectReturnType = typeof(Amazon.BedrockAgent.Model.CreateFlowResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgent.Model.CreateFlowResponse",
        "This cmdlet returns an Amazon.BedrockAgent.Model.CreateFlowResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewAABFlowCmdlet : AmazonBedrockAgentClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Definition_Connection
        /// <summary>
        /// <para>
        /// <para>An array of connection definitions in the flow.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Definition_Connections")]
        public Amazon.BedrockAgent.Model.FlowConnection[] Definition_Connection { get; set; }
        #endregion
        
        #region Parameter CustomerEncryptionKeyArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the KMS key to encrypt the flow.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomerEncryptionKeyArn { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description for the flow.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter ExecutionRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the service role with permissions to create and
        /// manage a flow. For more information, see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/flows-permissions.html">Create
        /// a service role for flows in Amazon Bedrock</a> in the Amazon Bedrock User Guide.</para>
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
        public System.String ExecutionRoleArn { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A name for the flow.</para>
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
        
        #region Parameter Definition_Node
        /// <summary>
        /// <para>
        /// <para>An array of node definitions in the flow.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Definition_Nodes")]
        public Amazon.BedrockAgent.Model.FlowNode[] Definition_Node { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Any tags that you want to attach to the flow. For more information, see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/tagging.html">Tagging
        /// resources in Amazon Bedrock</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier to ensure that the API request completes no more
        /// than one time. If this token matches a previous request, Amazon Bedrock ignores the
        /// request, but does not return an error. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/Run_Instance_Idempotency.html">Ensuring
        /// idempotency</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgent.Model.CreateFlowResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgent.Model.CreateFlowResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-AABFlow (CreateFlow)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgent.Model.CreateFlowResponse, NewAABFlowCmdlet>(Select) ??
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
            context.ClientToken = this.ClientToken;
            context.CustomerEncryptionKeyArn = this.CustomerEncryptionKeyArn;
            if (this.Definition_Connection != null)
            {
                context.Definition_Connection = new List<Amazon.BedrockAgent.Model.FlowConnection>(this.Definition_Connection);
            }
            if (this.Definition_Node != null)
            {
                context.Definition_Node = new List<Amazon.BedrockAgent.Model.FlowNode>(this.Definition_Node);
            }
            context.Description = this.Description;
            context.ExecutionRoleArn = this.ExecutionRoleArn;
            #if MODULAR
            if (this.ExecutionRoleArn == null && ParameterWasBound(nameof(this.ExecutionRoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ExecutionRoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.BedrockAgent.Model.CreateFlowRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.CustomerEncryptionKeyArn != null)
            {
                request.CustomerEncryptionKeyArn = cmdletContext.CustomerEncryptionKeyArn;
            }
            
             // populate Definition
            var requestDefinitionIsNull = true;
            request.Definition = new Amazon.BedrockAgent.Model.FlowDefinition();
            List<Amazon.BedrockAgent.Model.FlowConnection> requestDefinition_definition_Connection = null;
            if (cmdletContext.Definition_Connection != null)
            {
                requestDefinition_definition_Connection = cmdletContext.Definition_Connection;
            }
            if (requestDefinition_definition_Connection != null)
            {
                request.Definition.Connections = requestDefinition_definition_Connection;
                requestDefinitionIsNull = false;
            }
            List<Amazon.BedrockAgent.Model.FlowNode> requestDefinition_definition_Node = null;
            if (cmdletContext.Definition_Node != null)
            {
                requestDefinition_definition_Node = cmdletContext.Definition_Node;
            }
            if (requestDefinition_definition_Node != null)
            {
                request.Definition.Nodes = requestDefinition_definition_Node;
                requestDefinitionIsNull = false;
            }
             // determine if request.Definition should be set to null
            if (requestDefinitionIsNull)
            {
                request.Definition = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.ExecutionRoleArn != null)
            {
                request.ExecutionRoleArn = cmdletContext.ExecutionRoleArn;
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
        
        private Amazon.BedrockAgent.Model.CreateFlowResponse CallAWSServiceOperation(IAmazonBedrockAgent client, Amazon.BedrockAgent.Model.CreateFlowRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Agents for Amazon Bedrock", "CreateFlow");
            try
            {
                #if DESKTOP
                return client.CreateFlow(request);
                #elif CORECLR
                return client.CreateFlowAsync(request).GetAwaiter().GetResult();
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
            public System.String CustomerEncryptionKeyArn { get; set; }
            public List<Amazon.BedrockAgent.Model.FlowConnection> Definition_Connection { get; set; }
            public List<Amazon.BedrockAgent.Model.FlowNode> Definition_Node { get; set; }
            public System.String Description { get; set; }
            public System.String ExecutionRoleArn { get; set; }
            public System.String Name { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.BedrockAgent.Model.CreateFlowResponse, NewAABFlowCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
