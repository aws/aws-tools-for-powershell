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
using Amazon.DevOpsAgent;
using Amazon.DevOpsAgent.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.DOPS
{
    /// <summary>
    /// Sends a chat message and streams the response for the specified agent space execution
    /// </summary>
    [Cmdlet("Send", "DOPSMessage", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DevOpsAgent.Model.SendMessageEvents")]
    [AWSCmdlet("Calls the AWS DevOps Agent Service SendMessage API operation.", Operation = new[] {"SendMessage"}, SelectReturnType = typeof(Amazon.DevOpsAgent.Model.SendMessageResponse))]
    [AWSCmdletOutput("Amazon.DevOpsAgent.Model.SendMessageEvents or Amazon.DevOpsAgent.Model.SendMessageResponse",
        "This cmdlet returns an Amazon.DevOpsAgent.Model.SendMessageEvents object.",
        "The service call response (type Amazon.DevOpsAgent.Model.SendMessageResponse) can be returned by specifying '-Select *'."
    )]
    public partial class SendDOPSMessageCmdlet : AmazonDevOpsAgentClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Context_ApprovalAction_Action
        /// <summary>
        /// <para>
        /// <para>The action taken on the approval request — APPROVED or REJECTED.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DevOpsAgent.ApprovalActionType")]
        public Amazon.DevOpsAgent.ApprovalActionType Context_ApprovalAction_Action { get; set; }
        #endregion
        
        #region Parameter AgentSpaceId
        /// <summary>
        /// <para>
        /// <para>The agent space identifier</para>
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
        public System.String AgentSpaceId { get; set; }
        #endregion
        
        #region Parameter Context_ApprovalAction_ApprovalId
        /// <summary>
        /// <para>
        /// <para>Identifier of the approval request being resolved.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Context_ApprovalAction_ApprovalId { get; set; }
        #endregion
        
        #region Parameter AssetId
        /// <summary>
        /// <para>
        /// <para>Optional list of asset identifiers to attach to the message</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AssetIds")]
        public System.String[] AssetId { get; set; }
        #endregion
        
        #region Parameter Context_ApprovalAction_ButtonText
        /// <summary>
        /// <para>
        /// <para>Optional display text of the UI control the user chose (for example, "Approve Exact",
        /// "Approve Broader", or "Reject"), provided as auxiliary decision context.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Context_ApprovalAction_ButtonText { get; set; }
        #endregion
        
        #region Parameter Content
        /// <summary>
        /// <para>
        /// <para>The user message content</para>
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
        public System.String Content { get; set; }
        #endregion
        
        #region Parameter Context_CurrentPage
        /// <summary>
        /// <para>
        /// <para>The current page or view the user is on</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Context_CurrentPage { get; set; }
        #endregion
        
        #region Parameter ExecutionId
        /// <summary>
        /// <para>
        /// <para>The execution identifier for the chat session</para>
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
        public System.String ExecutionId { get; set; }
        #endregion
        
        #region Parameter Context_ApprovalAction_InterruptId
        /// <summary>
        /// <para>
        /// <para>An opaque resume identifier issued by the service when an agent execution pauses for
        /// approval. Provide it when resuming so the service can resume the correct paused execution.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Context_ApprovalAction_InterruptId { get; set; }
        #endregion
        
        #region Parameter Context_LastMessage
        /// <summary>
        /// <para>
        /// <para>The ID of the last message in the conversation</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Context_LastMessage { get; set; }
        #endregion
        
        #region Parameter ModelTier
        /// <summary>
        /// <para>
        /// <para>Optional model tier selection. Valid values: smart, balanced, fast. Absent or unrecognized
        /// values default to balanced.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ModelTier { get; set; }
        #endregion
        
        #region Parameter Context_ApprovalAction_ToolUseId
        /// <summary>
        /// <para>
        /// <para>Identifier of the specific paused tool invocation that requested approval. Correlates
        /// the approval decision back to the paused invocation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Context_ApprovalAction_ToolUseId { get; set; }
        #endregion
        
        #region Parameter Context_UserActionResponse
        /// <summary>
        /// <para>
        /// <para>Response to a UI prompt (not a text conversation message). Set this to the sentinel
        /// value `"APPROVAL_ACTION"` when the request is resuming a paused execution after an
        /// approval decision; in that case the structured decision is provided on the sibling
        /// `approvalAction` member. Preserved as a String for backward compatibility: clients
        /// that predate the typed approval field may still encode UI-prompt responses as JSON
        /// in this field.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Context_UserActionResponse { get; set; }
        #endregion
        
        #region Parameter UserId
        /// <summary>
        /// <para>
        /// <para>User identifier. This field is deprecated and will be ignored — the service resolves
        /// user identity from the authenticated session.</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("userId is managed by the service and should not be provided by the caller")]
        public System.String UserId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Events'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DevOpsAgent.Model.SendMessageResponse).
        /// Specifying the name of a property of type Amazon.DevOpsAgent.Model.SendMessageResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Events";
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
            
            var targetParameterNames = new string[]
            {
                nameof(this.AgentSpaceId),
                nameof(this.ExecutionId),
                nameof(this.UserId)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-DOPSMessage (SendMessage)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DevOpsAgent.Model.SendMessageResponse, SendDOPSMessageCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AgentSpaceId = this.AgentSpaceId;
            #if MODULAR
            if (this.AgentSpaceId == null && ParameterWasBound(nameof(this.AgentSpaceId)))
            {
                WriteWarning("You are passing $null as a value for parameter AgentSpaceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.AssetId != null)
            {
                context.AssetId = new List<System.String>(this.AssetId);
            }
            context.Content = this.Content;
            #if MODULAR
            if (this.Content == null && ParameterWasBound(nameof(this.Content)))
            {
                WriteWarning("You are passing $null as a value for parameter Content which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Context_ApprovalAction_Action = this.Context_ApprovalAction_Action;
            context.Context_ApprovalAction_ApprovalId = this.Context_ApprovalAction_ApprovalId;
            context.Context_ApprovalAction_ButtonText = this.Context_ApprovalAction_ButtonText;
            context.Context_ApprovalAction_InterruptId = this.Context_ApprovalAction_InterruptId;
            context.Context_ApprovalAction_ToolUseId = this.Context_ApprovalAction_ToolUseId;
            context.Context_CurrentPage = this.Context_CurrentPage;
            context.Context_LastMessage = this.Context_LastMessage;
            context.Context_UserActionResponse = this.Context_UserActionResponse;
            context.ExecutionId = this.ExecutionId;
            #if MODULAR
            if (this.ExecutionId == null && ParameterWasBound(nameof(this.ExecutionId)))
            {
                WriteWarning("You are passing $null as a value for parameter ExecutionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ModelTier = this.ModelTier;
            context.UserId = this.UserId;
            
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
            var request = new Amazon.DevOpsAgent.Model.SendMessageRequest();
            
            if (cmdletContext.AgentSpaceId != null)
            {
                request.AgentSpaceId = cmdletContext.AgentSpaceId;
            }
            if (cmdletContext.AssetId != null)
            {
                request.AssetIds = cmdletContext.AssetId;
            }
            if (cmdletContext.Content != null)
            {
                request.Content = cmdletContext.Content;
            }
            
             // populate Context
            var requestContextIsNull = true;
            request.Context = new Amazon.DevOpsAgent.Model.SendMessageContext();
            System.String requestContext_context_CurrentPage = null;
            if (cmdletContext.Context_CurrentPage != null)
            {
                requestContext_context_CurrentPage = cmdletContext.Context_CurrentPage;
            }
            if (requestContext_context_CurrentPage != null)
            {
                request.Context.CurrentPage = requestContext_context_CurrentPage;
                requestContextIsNull = false;
            }
            System.String requestContext_context_LastMessage = null;
            if (cmdletContext.Context_LastMessage != null)
            {
                requestContext_context_LastMessage = cmdletContext.Context_LastMessage;
            }
            if (requestContext_context_LastMessage != null)
            {
                request.Context.LastMessage = requestContext_context_LastMessage;
                requestContextIsNull = false;
            }
            System.String requestContext_context_UserActionResponse = null;
            if (cmdletContext.Context_UserActionResponse != null)
            {
                requestContext_context_UserActionResponse = cmdletContext.Context_UserActionResponse;
            }
            if (requestContext_context_UserActionResponse != null)
            {
                request.Context.UserActionResponse = requestContext_context_UserActionResponse;
                requestContextIsNull = false;
            }
            Amazon.DevOpsAgent.Model.ApprovalAction requestContext_context_ApprovalAction = null;
            
             // populate ApprovalAction
            var requestContext_context_ApprovalActionIsNull = true;
            requestContext_context_ApprovalAction = new Amazon.DevOpsAgent.Model.ApprovalAction();
            Amazon.DevOpsAgent.ApprovalActionType requestContext_context_ApprovalAction_context_ApprovalAction_Action = null;
            if (cmdletContext.Context_ApprovalAction_Action != null)
            {
                requestContext_context_ApprovalAction_context_ApprovalAction_Action = cmdletContext.Context_ApprovalAction_Action;
            }
            if (requestContext_context_ApprovalAction_context_ApprovalAction_Action != null)
            {
                requestContext_context_ApprovalAction.Action = requestContext_context_ApprovalAction_context_ApprovalAction_Action;
                requestContext_context_ApprovalActionIsNull = false;
            }
            System.String requestContext_context_ApprovalAction_context_ApprovalAction_ApprovalId = null;
            if (cmdletContext.Context_ApprovalAction_ApprovalId != null)
            {
                requestContext_context_ApprovalAction_context_ApprovalAction_ApprovalId = cmdletContext.Context_ApprovalAction_ApprovalId;
            }
            if (requestContext_context_ApprovalAction_context_ApprovalAction_ApprovalId != null)
            {
                requestContext_context_ApprovalAction.ApprovalId = requestContext_context_ApprovalAction_context_ApprovalAction_ApprovalId;
                requestContext_context_ApprovalActionIsNull = false;
            }
            System.String requestContext_context_ApprovalAction_context_ApprovalAction_ButtonText = null;
            if (cmdletContext.Context_ApprovalAction_ButtonText != null)
            {
                requestContext_context_ApprovalAction_context_ApprovalAction_ButtonText = cmdletContext.Context_ApprovalAction_ButtonText;
            }
            if (requestContext_context_ApprovalAction_context_ApprovalAction_ButtonText != null)
            {
                requestContext_context_ApprovalAction.ButtonText = requestContext_context_ApprovalAction_context_ApprovalAction_ButtonText;
                requestContext_context_ApprovalActionIsNull = false;
            }
            System.String requestContext_context_ApprovalAction_context_ApprovalAction_InterruptId = null;
            if (cmdletContext.Context_ApprovalAction_InterruptId != null)
            {
                requestContext_context_ApprovalAction_context_ApprovalAction_InterruptId = cmdletContext.Context_ApprovalAction_InterruptId;
            }
            if (requestContext_context_ApprovalAction_context_ApprovalAction_InterruptId != null)
            {
                requestContext_context_ApprovalAction.InterruptId = requestContext_context_ApprovalAction_context_ApprovalAction_InterruptId;
                requestContext_context_ApprovalActionIsNull = false;
            }
            System.String requestContext_context_ApprovalAction_context_ApprovalAction_ToolUseId = null;
            if (cmdletContext.Context_ApprovalAction_ToolUseId != null)
            {
                requestContext_context_ApprovalAction_context_ApprovalAction_ToolUseId = cmdletContext.Context_ApprovalAction_ToolUseId;
            }
            if (requestContext_context_ApprovalAction_context_ApprovalAction_ToolUseId != null)
            {
                requestContext_context_ApprovalAction.ToolUseId = requestContext_context_ApprovalAction_context_ApprovalAction_ToolUseId;
                requestContext_context_ApprovalActionIsNull = false;
            }
             // determine if requestContext_context_ApprovalAction should be set to null
            if (requestContext_context_ApprovalActionIsNull)
            {
                requestContext_context_ApprovalAction = null;
            }
            if (requestContext_context_ApprovalAction != null)
            {
                request.Context.ApprovalAction = requestContext_context_ApprovalAction;
                requestContextIsNull = false;
            }
             // determine if request.Context should be set to null
            if (requestContextIsNull)
            {
                request.Context = null;
            }
            if (cmdletContext.ExecutionId != null)
            {
                request.ExecutionId = cmdletContext.ExecutionId;
            }
            if (cmdletContext.ModelTier != null)
            {
                request.ModelTier = cmdletContext.ModelTier;
            }
            if (cmdletContext.UserId != null)
            {
                request.UserId = cmdletContext.UserId;
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
        
        private Amazon.DevOpsAgent.Model.SendMessageResponse CallAWSServiceOperation(IAmazonDevOpsAgent client, Amazon.DevOpsAgent.Model.SendMessageRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS DevOps Agent Service", "SendMessage");
            try
            {
                return client.SendMessageAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AgentSpaceId { get; set; }
            public List<System.String> AssetId { get; set; }
            public System.String Content { get; set; }
            public Amazon.DevOpsAgent.ApprovalActionType Context_ApprovalAction_Action { get; set; }
            public System.String Context_ApprovalAction_ApprovalId { get; set; }
            public System.String Context_ApprovalAction_ButtonText { get; set; }
            public System.String Context_ApprovalAction_InterruptId { get; set; }
            public System.String Context_ApprovalAction_ToolUseId { get; set; }
            public System.String Context_CurrentPage { get; set; }
            public System.String Context_LastMessage { get; set; }
            public System.String Context_UserActionResponse { get; set; }
            public System.String ExecutionId { get; set; }
            public System.String ModelTier { get; set; }
            [System.ObsoleteAttribute]
            public System.String UserId { get; set; }
            public System.Func<Amazon.DevOpsAgent.Model.SendMessageResponse, SendDOPSMessageCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Events;
        }
        
    }
}
