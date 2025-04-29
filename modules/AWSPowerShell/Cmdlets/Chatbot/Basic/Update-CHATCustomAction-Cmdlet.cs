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
using Amazon.Chatbot;
using Amazon.Chatbot.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CHAT
{
    /// <summary>
    /// Updates a custom action.
    /// </summary>
    [Cmdlet("Update", "CHATCustomAction", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Chatbot UpdateCustomAction API operation.", Operation = new[] {"UpdateCustomAction"}, SelectReturnType = typeof(Amazon.Chatbot.Model.UpdateCustomActionResponse))]
    [AWSCmdletOutput("System.String or Amazon.Chatbot.Model.UpdateCustomActionResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Chatbot.Model.UpdateCustomActionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateCHATCustomActionCmdlet : AmazonChatbotClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AliasName
        /// <summary>
        /// <para>
        /// <para>The name used to invoke this action in the chat channel. For example, <c>@aws run
        /// my-alias</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AliasName { get; set; }
        #endregion
        
        #region Parameter Attachment
        /// <summary>
        /// <para>
        /// <para>Defines when this custom action button should be attached to a notification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attachments")]
        public Amazon.Chatbot.Model.CustomActionAttachment[] Attachment { get; set; }
        #endregion
        
        #region Parameter Definition_CommandText
        /// <summary>
        /// <para>
        /// <para>The command string to run which may include variables by prefixing with a dollar sign
        /// ($).</para>
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
        public System.String Definition_CommandText { get; set; }
        #endregion
        
        #region Parameter CustomActionArn
        /// <summary>
        /// <para>
        /// <para>The fully defined Amazon Resource Name (ARN) of the custom action.</para>
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
        public System.String CustomActionArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CustomActionArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Chatbot.Model.UpdateCustomActionResponse).
        /// Specifying the name of a property of type Amazon.Chatbot.Model.UpdateCustomActionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CustomActionArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CustomActionArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CHATCustomAction (UpdateCustomAction)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Chatbot.Model.UpdateCustomActionResponse, UpdateCHATCustomActionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AliasName = this.AliasName;
            if (this.Attachment != null)
            {
                context.Attachment = new List<Amazon.Chatbot.Model.CustomActionAttachment>(this.Attachment);
            }
            context.CustomActionArn = this.CustomActionArn;
            #if MODULAR
            if (this.CustomActionArn == null && ParameterWasBound(nameof(this.CustomActionArn)))
            {
                WriteWarning("You are passing $null as a value for parameter CustomActionArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Definition_CommandText = this.Definition_CommandText;
            #if MODULAR
            if (this.Definition_CommandText == null && ParameterWasBound(nameof(this.Definition_CommandText)))
            {
                WriteWarning("You are passing $null as a value for parameter Definition_CommandText which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Chatbot.Model.UpdateCustomActionRequest();
            
            if (cmdletContext.AliasName != null)
            {
                request.AliasName = cmdletContext.AliasName;
            }
            if (cmdletContext.Attachment != null)
            {
                request.Attachments = cmdletContext.Attachment;
            }
            if (cmdletContext.CustomActionArn != null)
            {
                request.CustomActionArn = cmdletContext.CustomActionArn;
            }
            
             // populate Definition
            var requestDefinitionIsNull = true;
            request.Definition = new Amazon.Chatbot.Model.CustomActionDefinition();
            System.String requestDefinition_definition_CommandText = null;
            if (cmdletContext.Definition_CommandText != null)
            {
                requestDefinition_definition_CommandText = cmdletContext.Definition_CommandText;
            }
            if (requestDefinition_definition_CommandText != null)
            {
                request.Definition.CommandText = requestDefinition_definition_CommandText;
                requestDefinitionIsNull = false;
            }
             // determine if request.Definition should be set to null
            if (requestDefinitionIsNull)
            {
                request.Definition = null;
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
        
        private Amazon.Chatbot.Model.UpdateCustomActionResponse CallAWSServiceOperation(IAmazonChatbot client, Amazon.Chatbot.Model.UpdateCustomActionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Chatbot", "UpdateCustomAction");
            try
            {
                return client.UpdateCustomActionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AliasName { get; set; }
            public List<Amazon.Chatbot.Model.CustomActionAttachment> Attachment { get; set; }
            public System.String CustomActionArn { get; set; }
            public System.String Definition_CommandText { get; set; }
            public System.Func<Amazon.Chatbot.Model.UpdateCustomActionResponse, UpdateCHATCustomActionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CustomActionArn;
        }
        
    }
}
