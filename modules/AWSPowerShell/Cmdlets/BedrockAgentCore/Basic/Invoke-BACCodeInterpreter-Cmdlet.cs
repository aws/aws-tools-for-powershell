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
using Amazon.BedrockAgentCore;
using Amazon.BedrockAgentCore.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.BAC
{
    /// <summary>
    /// Executes code within an active code interpreter session in Amazon Bedrock AgentCore.
    /// This operation processes the provided code, runs it in a secure environment, and returns
    /// the execution results including output, errors, and generated visualizations.
    /// 
    ///  
    /// <para>
    /// To execute code, you must specify the code interpreter identifier, session ID, and
    /// the code to run in the arguments parameter. The operation returns a stream containing
    /// the execution results, which can include text output, error messages, and data visualizations.
    /// </para><para>
    /// This operation is subject to request rate limiting based on your account's service
    /// quotas.
    /// </para><para>
    /// The following operations are related to <c>InvokeCodeInterpreter</c>:
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/bedrock-agentcore/latest/APIReference/API_StartCodeInterpreterSession.html">StartCodeInterpreterSession</a></para></li><li><para><a href="https://docs.aws.amazon.com/bedrock-agentcore/latest/APIReference/API_GetCodeInterpreterSession.html">GetCodeInterpreterSession</a></para></li></ul>
    /// </summary>
    [Cmdlet("Invoke", "BACCodeInterpreter", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BedrockAgentCore.Model.InvokeCodeInterpreterResponse")]
    [AWSCmdlet("Calls the Amazon Bedrock AgentCore Data Plane Fronting Layer InvokeCodeInterpreter API operation.", Operation = new[] {"InvokeCodeInterpreter"}, SelectReturnType = typeof(Amazon.BedrockAgentCore.Model.InvokeCodeInterpreterResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgentCore.Model.InvokeCodeInterpreterResponse",
        "This cmdlet returns an Amazon.BedrockAgentCore.Model.InvokeCodeInterpreterResponse object containing multiple properties."
    )]
    public partial class InvokeBACCodeInterpreterCmdlet : AmazonBedrockAgentCoreClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Arguments_ClearContext
        /// <summary>
        /// <para>
        /// <para>Whether to clear the context for the tool.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Arguments_ClearContext { get; set; }
        #endregion
        
        #region Parameter Arguments_Code
        /// <summary>
        /// <para>
        /// <para>The code to execute in a code interpreter session. This is the source code in the
        /// specified programming language that will be executed by the code interpreter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Arguments_Code { get; set; }
        #endregion
        
        #region Parameter CodeInterpreterIdentifier
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the code interpreter associated with the session. This must
        /// match the identifier used when creating the session with <c>StartCodeInterpreterSession</c>.</para>
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
        public System.String CodeInterpreterIdentifier { get; set; }
        #endregion
        
        #region Parameter Arguments_Command
        /// <summary>
        /// <para>
        /// <para>The command to execute with the tool.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Arguments_Command { get; set; }
        #endregion
        
        #region Parameter Arguments_Content
        /// <summary>
        /// <para>
        /// <para>The content for the tool operation.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.BedrockAgentCore.Model.InputContentBlock[] Arguments_Content { get; set; }
        #endregion
        
        #region Parameter Arguments_DirectoryPath
        /// <summary>
        /// <para>
        /// <para>The directory path for the tool operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Arguments_DirectoryPath { get; set; }
        #endregion
        
        #region Parameter Arguments_Language
        /// <summary>
        /// <para>
        /// <para>The programming language of the code to execute. This tells the code interpreter which
        /// language runtime to use for execution. Common values include 'python', 'javascript',
        /// and 'r'.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockAgentCore.ProgrammingLanguage")]
        public Amazon.BedrockAgentCore.ProgrammingLanguage Arguments_Language { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the code interpreter to invoke.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.BedrockAgentCore.ToolName")]
        public Amazon.BedrockAgentCore.ToolName Name { get; set; }
        #endregion
        
        #region Parameter Arguments_Path
        /// <summary>
        /// <para>
        /// <para>The path for the tool operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Arguments_Path { get; set; }
        #endregion
        
        #region Parameter Arguments_Paths
        /// <summary>
        /// <para>
        /// <para>The paths for the tool operation.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] Arguments_Paths { get; set; }
        #endregion
        
        #region Parameter SessionId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the code interpreter session to use. This must be an active
        /// session created with <c>StartCodeInterpreterSession</c>. If the session has expired
        /// or been stopped, the request will fail.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SessionId { get; set; }
        #endregion
        
        #region Parameter Arguments_TaskId
        /// <summary>
        /// <para>
        /// <para>The identifier of the task for the tool operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Arguments_TaskId { get; set; }
        #endregion
        
        #region Parameter TraceId
        /// <summary>
        /// <para>
        /// <para>The trace identifier for request tracking.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TraceId { get; set; }
        #endregion
        
        #region Parameter TraceParent
        /// <summary>
        /// <para>
        /// <para>The parent trace information for distributed tracing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TraceParent { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgentCore.Model.InvokeCodeInterpreterResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgentCore.Model.InvokeCodeInterpreterResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CodeInterpreterIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-BACCodeInterpreter (InvokeCodeInterpreter)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgentCore.Model.InvokeCodeInterpreterResponse, InvokeBACCodeInterpreterCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Arguments_ClearContext = this.Arguments_ClearContext;
            context.Arguments_Code = this.Arguments_Code;
            context.Arguments_Command = this.Arguments_Command;
            if (this.Arguments_Content != null)
            {
                context.Arguments_Content = new List<Amazon.BedrockAgentCore.Model.InputContentBlock>(this.Arguments_Content);
            }
            context.Arguments_DirectoryPath = this.Arguments_DirectoryPath;
            context.Arguments_Language = this.Arguments_Language;
            context.Arguments_Path = this.Arguments_Path;
            if (this.Arguments_Paths != null)
            {
                context.Arguments_Paths = new List<System.String>(this.Arguments_Paths);
            }
            context.Arguments_TaskId = this.Arguments_TaskId;
            context.CodeInterpreterIdentifier = this.CodeInterpreterIdentifier;
            #if MODULAR
            if (this.CodeInterpreterIdentifier == null && ParameterWasBound(nameof(this.CodeInterpreterIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter CodeInterpreterIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SessionId = this.SessionId;
            context.TraceId = this.TraceId;
            context.TraceParent = this.TraceParent;
            
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
            var request = new Amazon.BedrockAgentCore.Model.InvokeCodeInterpreterRequest();
            
            
             // populate Arguments
            var requestArgumentsIsNull = true;
            request.Arguments = new Amazon.BedrockAgentCore.Model.ToolArguments();
            System.Boolean? requestArguments_arguments_ClearContext = null;
            if (cmdletContext.Arguments_ClearContext != null)
            {
                requestArguments_arguments_ClearContext = cmdletContext.Arguments_ClearContext.Value;
            }
            if (requestArguments_arguments_ClearContext != null)
            {
                request.Arguments.ClearContext = requestArguments_arguments_ClearContext.Value;
                requestArgumentsIsNull = false;
            }
            System.String requestArguments_arguments_Code = null;
            if (cmdletContext.Arguments_Code != null)
            {
                requestArguments_arguments_Code = cmdletContext.Arguments_Code;
            }
            if (requestArguments_arguments_Code != null)
            {
                request.Arguments.Code = requestArguments_arguments_Code;
                requestArgumentsIsNull = false;
            }
            System.String requestArguments_arguments_Command = null;
            if (cmdletContext.Arguments_Command != null)
            {
                requestArguments_arguments_Command = cmdletContext.Arguments_Command;
            }
            if (requestArguments_arguments_Command != null)
            {
                request.Arguments.Command = requestArguments_arguments_Command;
                requestArgumentsIsNull = false;
            }
            List<Amazon.BedrockAgentCore.Model.InputContentBlock> requestArguments_arguments_Content = null;
            if (cmdletContext.Arguments_Content != null)
            {
                requestArguments_arguments_Content = cmdletContext.Arguments_Content;
            }
            if (requestArguments_arguments_Content != null)
            {
                request.Arguments.Content = requestArguments_arguments_Content;
                requestArgumentsIsNull = false;
            }
            System.String requestArguments_arguments_DirectoryPath = null;
            if (cmdletContext.Arguments_DirectoryPath != null)
            {
                requestArguments_arguments_DirectoryPath = cmdletContext.Arguments_DirectoryPath;
            }
            if (requestArguments_arguments_DirectoryPath != null)
            {
                request.Arguments.DirectoryPath = requestArguments_arguments_DirectoryPath;
                requestArgumentsIsNull = false;
            }
            Amazon.BedrockAgentCore.ProgrammingLanguage requestArguments_arguments_Language = null;
            if (cmdletContext.Arguments_Language != null)
            {
                requestArguments_arguments_Language = cmdletContext.Arguments_Language;
            }
            if (requestArguments_arguments_Language != null)
            {
                request.Arguments.Language = requestArguments_arguments_Language;
                requestArgumentsIsNull = false;
            }
            System.String requestArguments_arguments_Path = null;
            if (cmdletContext.Arguments_Path != null)
            {
                requestArguments_arguments_Path = cmdletContext.Arguments_Path;
            }
            if (requestArguments_arguments_Path != null)
            {
                request.Arguments.Path = requestArguments_arguments_Path;
                requestArgumentsIsNull = false;
            }
            List<System.String> requestArguments_arguments_Paths = null;
            if (cmdletContext.Arguments_Paths != null)
            {
                requestArguments_arguments_Paths = cmdletContext.Arguments_Paths;
            }
            if (requestArguments_arguments_Paths != null)
            {
                request.Arguments.Paths = requestArguments_arguments_Paths;
                requestArgumentsIsNull = false;
            }
            System.String requestArguments_arguments_TaskId = null;
            if (cmdletContext.Arguments_TaskId != null)
            {
                requestArguments_arguments_TaskId = cmdletContext.Arguments_TaskId;
            }
            if (requestArguments_arguments_TaskId != null)
            {
                request.Arguments.TaskId = requestArguments_arguments_TaskId;
                requestArgumentsIsNull = false;
            }
             // determine if request.Arguments should be set to null
            if (requestArgumentsIsNull)
            {
                request.Arguments = null;
            }
            if (cmdletContext.CodeInterpreterIdentifier != null)
            {
                request.CodeInterpreterIdentifier = cmdletContext.CodeInterpreterIdentifier;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.SessionId != null)
            {
                request.SessionId = cmdletContext.SessionId;
            }
            if (cmdletContext.TraceId != null)
            {
                request.TraceId = cmdletContext.TraceId;
            }
            if (cmdletContext.TraceParent != null)
            {
                request.TraceParent = cmdletContext.TraceParent;
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
        
        private Amazon.BedrockAgentCore.Model.InvokeCodeInterpreterResponse CallAWSServiceOperation(IAmazonBedrockAgentCore client, Amazon.BedrockAgentCore.Model.InvokeCodeInterpreterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock AgentCore Data Plane Fronting Layer", "InvokeCodeInterpreter");
            try
            {
                return client.InvokeCodeInterpreterAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? Arguments_ClearContext { get; set; }
            public System.String Arguments_Code { get; set; }
            public System.String Arguments_Command { get; set; }
            public List<Amazon.BedrockAgentCore.Model.InputContentBlock> Arguments_Content { get; set; }
            public System.String Arguments_DirectoryPath { get; set; }
            public Amazon.BedrockAgentCore.ProgrammingLanguage Arguments_Language { get; set; }
            public System.String Arguments_Path { get; set; }
            public List<System.String> Arguments_Paths { get; set; }
            public System.String Arguments_TaskId { get; set; }
            public System.String CodeInterpreterIdentifier { get; set; }
            public Amazon.BedrockAgentCore.ToolName Name { get; set; }
            public System.String SessionId { get; set; }
            public System.String TraceId { get; set; }
            public System.String TraceParent { get; set; }
            public System.Func<Amazon.BedrockAgentCore.Model.InvokeCodeInterpreterResponse, InvokeBACCodeInterpreterCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
