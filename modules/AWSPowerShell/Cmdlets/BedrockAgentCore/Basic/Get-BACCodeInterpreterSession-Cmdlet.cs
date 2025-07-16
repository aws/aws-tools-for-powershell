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
using Amazon.BedrockAgentCore;
using Amazon.BedrockAgentCore.Model;

namespace Amazon.PowerShell.Cmdlets.BAC
{
    /// <summary>
    /// Retrieves detailed information about a specific code interpreter session in Amazon
    /// Bedrock. This operation returns the session's configuration, current status, and metadata.
    /// 
    ///  
    /// <para>
    /// To get a code interpreter session, you must specify both the code interpreter identifier
    /// and the session ID. The response includes information about the session's timeout
    /// settings and current status.
    /// </para><para>
    /// The following operations are related to <c>GetCodeInterpreterSession</c>:
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/API_StartCodeInterpreterSession.html">StartCodeInterpreterSession</a></para></li><li><para><a href="https://docs.aws.amazon.com/API_ListCodeInterpreterSessions.html">ListCodeInterpreterSessions</a></para></li><li><para><a href="https://docs.aws.amazon.com/API_StopCodeInterpreterSession.html">StopCodeInterpreterSession</a></para></li></ul>
    /// </summary>
    [Cmdlet("Get", "BACCodeInterpreterSession")]
    [OutputType("Amazon.BedrockAgentCore.Model.GetCodeInterpreterSessionResponse")]
    [AWSCmdlet("Calls the Amazon Bedrock AgentCore Data Plane Fronting Layer GetCodeInterpreterSession API operation.", Operation = new[] {"GetCodeInterpreterSession"}, SelectReturnType = typeof(Amazon.BedrockAgentCore.Model.GetCodeInterpreterSessionResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgentCore.Model.GetCodeInterpreterSessionResponse",
        "This cmdlet returns an Amazon.BedrockAgentCore.Model.GetCodeInterpreterSessionResponse object containing multiple properties."
    )]
    public partial class GetBACCodeInterpreterSessionCmdlet : AmazonBedrockAgentCoreClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CodeInterpreterIdentifier
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the code interpreter associated with the session.</para>
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
        
        #region Parameter SessionId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the code interpreter session to retrieve.</para>
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
        public System.String SessionId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgentCore.Model.GetCodeInterpreterSessionResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgentCore.Model.GetCodeInterpreterSessionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgentCore.Model.GetCodeInterpreterSessionResponse, GetBACCodeInterpreterSessionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CodeInterpreterIdentifier = this.CodeInterpreterIdentifier;
            #if MODULAR
            if (this.CodeInterpreterIdentifier == null && ParameterWasBound(nameof(this.CodeInterpreterIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter CodeInterpreterIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SessionId = this.SessionId;
            #if MODULAR
            if (this.SessionId == null && ParameterWasBound(nameof(this.SessionId)))
            {
                WriteWarning("You are passing $null as a value for parameter SessionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.BedrockAgentCore.Model.GetCodeInterpreterSessionRequest();
            
            if (cmdletContext.CodeInterpreterIdentifier != null)
            {
                request.CodeInterpreterIdentifier = cmdletContext.CodeInterpreterIdentifier;
            }
            if (cmdletContext.SessionId != null)
            {
                request.SessionId = cmdletContext.SessionId;
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
        
        private Amazon.BedrockAgentCore.Model.GetCodeInterpreterSessionResponse CallAWSServiceOperation(IAmazonBedrockAgentCore client, Amazon.BedrockAgentCore.Model.GetCodeInterpreterSessionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock AgentCore Data Plane Fronting Layer", "GetCodeInterpreterSession");
            try
            {
                #if DESKTOP
                return client.GetCodeInterpreterSession(request);
                #elif CORECLR
                return client.GetCodeInterpreterSessionAsync(request).GetAwaiter().GetResult();
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
            public System.String CodeInterpreterIdentifier { get; set; }
            public System.String SessionId { get; set; }
            public System.Func<Amazon.BedrockAgentCore.Model.GetCodeInterpreterSessionResponse, GetBACCodeInterpreterSessionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
