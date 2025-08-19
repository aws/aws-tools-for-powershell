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
    /// Updates a browser stream. To use this operation, you must have permissions to perform
    /// the bedrock:UpdateBrowserStream action.
    /// </summary>
    [Cmdlet("Update", "BACBrowserStream", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BedrockAgentCore.Model.UpdateBrowserStreamResponse")]
    [AWSCmdlet("Calls the Amazon Bedrock AgentCore Data Plane Fronting Layer UpdateBrowserStream API operation.", Operation = new[] {"UpdateBrowserStream"}, SelectReturnType = typeof(Amazon.BedrockAgentCore.Model.UpdateBrowserStreamResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgentCore.Model.UpdateBrowserStreamResponse",
        "This cmdlet returns an Amazon.BedrockAgentCore.Model.UpdateBrowserStreamResponse object containing multiple properties."
    )]
    public partial class UpdateBACBrowserStreamCmdlet : AmazonBedrockAgentCoreClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter BrowserIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the browser.</para>
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
        public System.String BrowserIdentifier { get; set; }
        #endregion
        
        #region Parameter SessionId
        /// <summary>
        /// <para>
        /// <para>The identifier of the browser session.</para>
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
        
        #region Parameter AutomationStreamUpdate_StreamStatus
        /// <summary>
        /// <para>
        /// <para>The status of the automation stream.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StreamUpdate_AutomationStreamUpdate_StreamStatus")]
        [AWSConstantClassSource("Amazon.BedrockAgentCore.AutomationStreamStatus")]
        public Amazon.BedrockAgentCore.AutomationStreamStatus AutomationStreamUpdate_StreamStatus { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier to ensure that the operation completes no more
        /// than one time. If this token matches a previous request, Amazon Bedrock ignores the
        /// request, but does not return an error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgentCore.Model.UpdateBrowserStreamResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgentCore.Model.UpdateBrowserStreamResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SessionId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-BACBrowserStream (UpdateBrowserStream)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgentCore.Model.UpdateBrowserStreamResponse, UpdateBACBrowserStreamCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BrowserIdentifier = this.BrowserIdentifier;
            #if MODULAR
            if (this.BrowserIdentifier == null && ParameterWasBound(nameof(this.BrowserIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter BrowserIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.SessionId = this.SessionId;
            #if MODULAR
            if (this.SessionId == null && ParameterWasBound(nameof(this.SessionId)))
            {
                WriteWarning("You are passing $null as a value for parameter SessionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AutomationStreamUpdate_StreamStatus = this.AutomationStreamUpdate_StreamStatus;
            
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
            var request = new Amazon.BedrockAgentCore.Model.UpdateBrowserStreamRequest();
            
            if (cmdletContext.BrowserIdentifier != null)
            {
                request.BrowserIdentifier = cmdletContext.BrowserIdentifier;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.SessionId != null)
            {
                request.SessionId = cmdletContext.SessionId;
            }
            
             // populate StreamUpdate
            request.StreamUpdate = new Amazon.BedrockAgentCore.Model.StreamUpdate();
            Amazon.BedrockAgentCore.Model.AutomationStreamUpdate requestStreamUpdate_streamUpdate_AutomationStreamUpdate = null;
            
             // populate AutomationStreamUpdate
            var requestStreamUpdate_streamUpdate_AutomationStreamUpdateIsNull = true;
            requestStreamUpdate_streamUpdate_AutomationStreamUpdate = new Amazon.BedrockAgentCore.Model.AutomationStreamUpdate();
            Amazon.BedrockAgentCore.AutomationStreamStatus requestStreamUpdate_streamUpdate_AutomationStreamUpdate_automationStreamUpdate_StreamStatus = null;
            if (cmdletContext.AutomationStreamUpdate_StreamStatus != null)
            {
                requestStreamUpdate_streamUpdate_AutomationStreamUpdate_automationStreamUpdate_StreamStatus = cmdletContext.AutomationStreamUpdate_StreamStatus;
            }
            if (requestStreamUpdate_streamUpdate_AutomationStreamUpdate_automationStreamUpdate_StreamStatus != null)
            {
                requestStreamUpdate_streamUpdate_AutomationStreamUpdate.StreamStatus = requestStreamUpdate_streamUpdate_AutomationStreamUpdate_automationStreamUpdate_StreamStatus;
                requestStreamUpdate_streamUpdate_AutomationStreamUpdateIsNull = false;
            }
             // determine if requestStreamUpdate_streamUpdate_AutomationStreamUpdate should be set to null
            if (requestStreamUpdate_streamUpdate_AutomationStreamUpdateIsNull)
            {
                requestStreamUpdate_streamUpdate_AutomationStreamUpdate = null;
            }
            if (requestStreamUpdate_streamUpdate_AutomationStreamUpdate != null)
            {
                request.StreamUpdate.AutomationStreamUpdate = requestStreamUpdate_streamUpdate_AutomationStreamUpdate;
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
        
        private Amazon.BedrockAgentCore.Model.UpdateBrowserStreamResponse CallAWSServiceOperation(IAmazonBedrockAgentCore client, Amazon.BedrockAgentCore.Model.UpdateBrowserStreamRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock AgentCore Data Plane Fronting Layer", "UpdateBrowserStream");
            try
            {
                return client.UpdateBrowserStreamAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String BrowserIdentifier { get; set; }
            public System.String ClientToken { get; set; }
            public System.String SessionId { get; set; }
            public Amazon.BedrockAgentCore.AutomationStreamStatus AutomationStreamUpdate_StreamStatus { get; set; }
            public System.Func<Amazon.BedrockAgentCore.Model.UpdateBrowserStreamResponse, UpdateBACBrowserStreamCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
