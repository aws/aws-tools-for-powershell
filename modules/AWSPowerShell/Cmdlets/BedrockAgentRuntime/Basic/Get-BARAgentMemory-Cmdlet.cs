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
using Amazon.BedrockAgentRuntime;
using Amazon.BedrockAgentRuntime.Model;

namespace Amazon.PowerShell.Cmdlets.BAR
{
    /// <summary>
    /// Gets the sessions stored in the memory of the agent.
    /// </summary>
    [Cmdlet("Get", "BARAgentMemory")]
    [OutputType("Amazon.BedrockAgentRuntime.Model.Memory")]
    [AWSCmdlet("Calls the Amazon Bedrock Agent Runtime GetAgentMemory API operation.", Operation = new[] {"GetAgentMemory"}, SelectReturnType = typeof(Amazon.BedrockAgentRuntime.Model.GetAgentMemoryResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgentRuntime.Model.Memory or Amazon.BedrockAgentRuntime.Model.GetAgentMemoryResponse",
        "This cmdlet returns a collection of Amazon.BedrockAgentRuntime.Model.Memory objects.",
        "The service call response (type Amazon.BedrockAgentRuntime.Model.GetAgentMemoryResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetBARAgentMemoryCmdlet : AmazonBedrockAgentRuntimeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AgentAliasId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of an alias of an agent.</para>
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
        public System.String AgentAliasId { get; set; }
        #endregion
        
        #region Parameter AgentId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the agent to which the alias belongs.</para>
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
        public System.String AgentId { get; set; }
        #endregion
        
        #region Parameter MemoryId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the memory. </para>
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
        public System.String MemoryId { get; set; }
        #endregion
        
        #region Parameter MemoryType
        /// <summary>
        /// <para>
        /// <para>The type of memory.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.BedrockAgentRuntime.MemoryType")]
        public Amazon.BedrockAgentRuntime.MemoryType MemoryType { get; set; }
        #endregion
        
        #region Parameter MaxItem
        /// <summary>
        /// <para>
        /// <para>The maximum number of items to return in the response. If the total number of results
        /// is greater than this value, use the token returned in the response in the <c>nextToken</c>
        /// field when making another request to return the next batch of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems")]
        public System.Int32? MaxItem { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>If the total number of results is greater than the maxItems value provided in the
        /// request, enter the token returned in the <c>nextToken</c> field in the response in
        /// this field to return the next batch of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'MemoryContents'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgentRuntime.Model.GetAgentMemoryResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgentRuntime.Model.GetAgentMemoryResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "MemoryContents";
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
                context.Select = CreateSelectDelegate<Amazon.BedrockAgentRuntime.Model.GetAgentMemoryResponse, GetBARAgentMemoryCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AgentAliasId = this.AgentAliasId;
            #if MODULAR
            if (this.AgentAliasId == null && ParameterWasBound(nameof(this.AgentAliasId)))
            {
                WriteWarning("You are passing $null as a value for parameter AgentAliasId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AgentId = this.AgentId;
            #if MODULAR
            if (this.AgentId == null && ParameterWasBound(nameof(this.AgentId)))
            {
                WriteWarning("You are passing $null as a value for parameter AgentId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxItem = this.MaxItem;
            context.MemoryId = this.MemoryId;
            #if MODULAR
            if (this.MemoryId == null && ParameterWasBound(nameof(this.MemoryId)))
            {
                WriteWarning("You are passing $null as a value for parameter MemoryId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MemoryType = this.MemoryType;
            #if MODULAR
            if (this.MemoryType == null && ParameterWasBound(nameof(this.MemoryType)))
            {
                WriteWarning("You are passing $null as a value for parameter MemoryType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NextToken = this.NextToken;
            
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
            var request = new Amazon.BedrockAgentRuntime.Model.GetAgentMemoryRequest();
            
            if (cmdletContext.AgentAliasId != null)
            {
                request.AgentAliasId = cmdletContext.AgentAliasId;
            }
            if (cmdletContext.AgentId != null)
            {
                request.AgentId = cmdletContext.AgentId;
            }
            if (cmdletContext.MaxItem != null)
            {
                request.MaxItems = cmdletContext.MaxItem.Value;
            }
            if (cmdletContext.MemoryId != null)
            {
                request.MemoryId = cmdletContext.MemoryId;
            }
            if (cmdletContext.MemoryType != null)
            {
                request.MemoryType = cmdletContext.MemoryType;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
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
        
        private Amazon.BedrockAgentRuntime.Model.GetAgentMemoryResponse CallAWSServiceOperation(IAmazonBedrockAgentRuntime client, Amazon.BedrockAgentRuntime.Model.GetAgentMemoryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock Agent Runtime", "GetAgentMemory");
            try
            {
                #if DESKTOP
                return client.GetAgentMemory(request);
                #elif CORECLR
                return client.GetAgentMemoryAsync(request).GetAwaiter().GetResult();
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
            public System.String AgentAliasId { get; set; }
            public System.String AgentId { get; set; }
            public System.Int32? MaxItem { get; set; }
            public System.String MemoryId { get; set; }
            public Amazon.BedrockAgentRuntime.MemoryType MemoryType { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.BedrockAgentRuntime.Model.GetAgentMemoryResponse, GetBARAgentMemoryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MemoryContents;
        }
        
    }
}
