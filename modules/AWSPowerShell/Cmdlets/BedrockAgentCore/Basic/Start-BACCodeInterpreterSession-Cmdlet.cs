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
    /// Creates and initializes a code interpreter session in Amazon Bedrock. The session
    /// enables agents to execute code as part of their response generation, supporting programming
    /// languages such as Python for data analysis, visualization, and computation tasks.
    /// 
    ///  
    /// <para>
    /// To create a session, you must specify a code interpreter identifier and a name. The
    /// session remains active until it times out or you explicitly stop it using the <c>StopCodeInterpreterSession</c>
    /// operation.
    /// </para><para>
    /// The following operations are related to <c>StartCodeInterpreterSession</c>:
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/API_InvokeCodeInterpreter.html">InvokeCodeInterpreter</a></para></li><li><para><a href="https://docs.aws.amazon.com/API_GetCodeInterpreterSession.html">GetCodeInterpreterSession</a></para></li><li><para><a href="https://docs.aws.amazon.com/API_StopCodeInterpreterSession.html">StopCodeInterpreterSession</a></para></li></ul>
    /// </summary>
    [Cmdlet("Start", "BACCodeInterpreterSession", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BedrockAgentCore.Model.StartCodeInterpreterSessionResponse")]
    [AWSCmdlet("Calls the Amazon Bedrock AgentCore Data Plane Fronting Layer StartCodeInterpreterSession API operation.", Operation = new[] {"StartCodeInterpreterSession"}, SelectReturnType = typeof(Amazon.BedrockAgentCore.Model.StartCodeInterpreterSessionResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgentCore.Model.StartCodeInterpreterSessionResponse",
        "This cmdlet returns an Amazon.BedrockAgentCore.Model.StartCodeInterpreterSessionResponse object containing multiple properties."
    )]
    public partial class StartBACCodeInterpreterSessionCmdlet : AmazonBedrockAgentCoreClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CodeInterpreterIdentifier
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the code interpreter to use for this session. This identifier
        /// specifies which code interpreter environment to initialize for the session.</para>
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
        public System.String CodeInterpreterIdentifier { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the code interpreter session. This name helps you identify and manage
        /// the session. The name does not need to be unique.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter SessionTimeoutSecond
        /// <summary>
        /// <para>
        /// <para>The time in seconds after which the session automatically terminates if there is no
        /// activity. The default value is 3600 seconds (1 hour). The minimum allowed value is
        /// 60 seconds, and the maximum allowed value is 28800 seconds (8 hours).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SessionTimeoutSeconds")]
        public System.Int32? SessionTimeoutSecond { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier to ensure that the API request completes no more
        /// than one time. If this token matches a previous request, Amazon Bedrock ignores the
        /// request, but does not return an error. This parameter helps prevent the creation of
        /// duplicate sessions if there are temporary network issues.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgentCore.Model.StartCodeInterpreterSessionResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgentCore.Model.StartCodeInterpreterSessionResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-BACCodeInterpreterSession (StartCodeInterpreterSession)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgentCore.Model.StartCodeInterpreterSessionResponse, StartBACCodeInterpreterSessionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.CodeInterpreterIdentifier = this.CodeInterpreterIdentifier;
            #if MODULAR
            if (this.CodeInterpreterIdentifier == null && ParameterWasBound(nameof(this.CodeInterpreterIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter CodeInterpreterIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            context.SessionTimeoutSecond = this.SessionTimeoutSecond;
            
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
            var request = new Amazon.BedrockAgentCore.Model.StartCodeInterpreterSessionRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.CodeInterpreterIdentifier != null)
            {
                request.CodeInterpreterIdentifier = cmdletContext.CodeInterpreterIdentifier;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.SessionTimeoutSecond != null)
            {
                request.SessionTimeoutSeconds = cmdletContext.SessionTimeoutSecond.Value;
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
        
        private Amazon.BedrockAgentCore.Model.StartCodeInterpreterSessionResponse CallAWSServiceOperation(IAmazonBedrockAgentCore client, Amazon.BedrockAgentCore.Model.StartCodeInterpreterSessionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock AgentCore Data Plane Fronting Layer", "StartCodeInterpreterSession");
            try
            {
                return client.StartCodeInterpreterSessionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String CodeInterpreterIdentifier { get; set; }
            public System.String Name { get; set; }
            public System.Int32? SessionTimeoutSecond { get; set; }
            public System.Func<Amazon.BedrockAgentCore.Model.StartCodeInterpreterSessionResponse, StartBACCodeInterpreterSessionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
