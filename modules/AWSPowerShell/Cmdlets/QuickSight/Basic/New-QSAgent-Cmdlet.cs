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
using Amazon.QuickSight;
using Amazon.QuickSight.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.QS
{
    /// <summary>
    /// Creates an agent in Amazon QuickSight.
    /// </summary>
    [Cmdlet("New", "QSAgent", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.QuickSight.Model.CreateAgentResponse")]
    [AWSCmdlet("Calls the Amazon QuickSight CreateAgent API operation.", Operation = new[] {"CreateAgent"}, SelectReturnType = typeof(Amazon.QuickSight.Model.CreateAgentResponse))]
    [AWSCmdletOutput("Amazon.QuickSight.Model.CreateAgentResponse",
        "This cmdlet returns an Amazon.QuickSight.Model.CreateAgentResponse object containing multiple properties."
    )]
    public partial class NewQSAgentCmdlet : AmazonQuickSightClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ActionConnector
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Names (ARNs) of the action connectors to attach to the agent.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ActionConnectors")]
        public System.String[] ActionConnector { get; set; }
        #endregion
        
        #region Parameter AgentId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the agent.</para>
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
        
        #region Parameter AgentLifecycle
        /// <summary>
        /// <para>
        /// <para>The lifecycle state of the agent. Valid values are <c>PREVIEW</c> and <c>PUBLISHED</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.AgentLifecycle")]
        public Amazon.QuickSight.AgentLifecycle AgentLifecycle { get; set; }
        #endregion
        
        #region Parameter AwsAccountId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Web Services account that contains the agent.</para>
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
        public System.String AwsAccountId { get; set; }
        #endregion
        
        #region Parameter CustomPromptInput_NewPrompt_CustomInstruction
        /// <summary>
        /// <para>
        /// <para>Custom instructions for the agent's behavior.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CustomPromptInput_NewPrompt_CustomInstructions")]
        public System.String CustomPromptInput_NewPrompt_CustomInstruction { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the agent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter IconId
        /// <summary>
        /// <para>
        /// <para>The icon identifier for the agent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IconId { get; set; }
        #endregion
        
        #region Parameter CustomPromptInput_NewPrompt_Identity
        /// <summary>
        /// <para>
        /// <para>Instructions that define the agent's identity and persona.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomPromptInput_NewPrompt_Identity { get; set; }
        #endregion
        
        #region Parameter CustomPromptInput_ExistingPrompt_ModelProfileId
        /// <summary>
        /// <para>
        /// <para>The identifier of the model profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomPromptInput_ExistingPrompt_ModelProfileId { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the agent.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter CustomPromptInput_NewPrompt_OutputStyle
        /// <summary>
        /// <para>
        /// <para>Instructions for the desired output style.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomPromptInput_NewPrompt_OutputStyle { get; set; }
        #endregion
        
        #region Parameter CustomPromptInput_ExistingPrompt_QbsAwsAccountId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account ID for the Q Business service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomPromptInput_ExistingPrompt_QbsAwsAccountId { get; set; }
        #endregion
        
        #region Parameter CustomPromptInput_NewPrompt_ResponseLength
        /// <summary>
        /// <para>
        /// <para>Instructions for the desired response length.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomPromptInput_NewPrompt_ResponseLength { get; set; }
        #endregion
        
        #region Parameter Space
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Names (ARNs) of the spaces to attach to the agent.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Spaces")]
        public System.String[] Space { get; set; }
        #endregion
        
        #region Parameter StarterPrompt
        /// <summary>
        /// <para>
        /// <para>A list of starter prompts that are displayed to users when they begin interacting
        /// with the agent.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StarterPrompts")]
        public System.String[] StarterPrompt { get; set; }
        #endregion
        
        #region Parameter CustomPromptInput_ExistingPrompt_SubscriptionId
        /// <summary>
        /// <para>
        /// <para>The subscription identifier.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomPromptInput_ExistingPrompt_SubscriptionId { get; set; }
        #endregion
        
        #region Parameter CustomPromptInput_NewPrompt_Tone
        /// <summary>
        /// <para>
        /// <para>Instructions for the desired tone of responses.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomPromptInput_NewPrompt_Tone { get; set; }
        #endregion
        
        #region Parameter WelcomeMessage
        /// <summary>
        /// <para>
        /// <para>The welcome message that is displayed when a user starts a conversation with the agent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String WelcomeMessage { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QuickSight.Model.CreateAgentResponse).
        /// Specifying the name of a property of type Amazon.QuickSight.Model.CreateAgentResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AgentId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-QSAgent (CreateAgent)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QuickSight.Model.CreateAgentResponse, NewQSAgentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.ActionConnector != null)
            {
                context.ActionConnector = new List<System.String>(this.ActionConnector);
            }
            context.AgentId = this.AgentId;
            #if MODULAR
            if (this.AgentId == null && ParameterWasBound(nameof(this.AgentId)))
            {
                WriteWarning("You are passing $null as a value for parameter AgentId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AgentLifecycle = this.AgentLifecycle;
            context.AwsAccountId = this.AwsAccountId;
            #if MODULAR
            if (this.AwsAccountId == null && ParameterWasBound(nameof(this.AwsAccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AwsAccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CustomPromptInput_ExistingPrompt_ModelProfileId = this.CustomPromptInput_ExistingPrompt_ModelProfileId;
            context.CustomPromptInput_ExistingPrompt_QbsAwsAccountId = this.CustomPromptInput_ExistingPrompt_QbsAwsAccountId;
            context.CustomPromptInput_ExistingPrompt_SubscriptionId = this.CustomPromptInput_ExistingPrompt_SubscriptionId;
            context.CustomPromptInput_NewPrompt_CustomInstruction = this.CustomPromptInput_NewPrompt_CustomInstruction;
            context.CustomPromptInput_NewPrompt_Identity = this.CustomPromptInput_NewPrompt_Identity;
            context.CustomPromptInput_NewPrompt_OutputStyle = this.CustomPromptInput_NewPrompt_OutputStyle;
            context.CustomPromptInput_NewPrompt_ResponseLength = this.CustomPromptInput_NewPrompt_ResponseLength;
            context.CustomPromptInput_NewPrompt_Tone = this.CustomPromptInput_NewPrompt_Tone;
            context.Description = this.Description;
            context.IconId = this.IconId;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Space != null)
            {
                context.Space = new List<System.String>(this.Space);
            }
            if (this.StarterPrompt != null)
            {
                context.StarterPrompt = new List<System.String>(this.StarterPrompt);
            }
            context.WelcomeMessage = this.WelcomeMessage;
            
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
            var request = new Amazon.QuickSight.Model.CreateAgentRequest();
            
            if (cmdletContext.ActionConnector != null)
            {
                request.ActionConnectors = cmdletContext.ActionConnector;
            }
            if (cmdletContext.AgentId != null)
            {
                request.AgentId = cmdletContext.AgentId;
            }
            if (cmdletContext.AgentLifecycle != null)
            {
                request.AgentLifecycle = cmdletContext.AgentLifecycle;
            }
            if (cmdletContext.AwsAccountId != null)
            {
                request.AwsAccountId = cmdletContext.AwsAccountId;
            }
            
             // populate CustomPromptInput
            var requestCustomPromptInputIsNull = true;
            request.CustomPromptInput = new Amazon.QuickSight.Model.CustomPromptInput();
            Amazon.QuickSight.Model.CustomPromptProfile requestCustomPromptInput_customPromptInput_ExistingPrompt = null;
            
             // populate ExistingPrompt
            var requestCustomPromptInput_customPromptInput_ExistingPromptIsNull = true;
            requestCustomPromptInput_customPromptInput_ExistingPrompt = new Amazon.QuickSight.Model.CustomPromptProfile();
            System.String requestCustomPromptInput_customPromptInput_ExistingPrompt_customPromptInput_ExistingPrompt_ModelProfileId = null;
            if (cmdletContext.CustomPromptInput_ExistingPrompt_ModelProfileId != null)
            {
                requestCustomPromptInput_customPromptInput_ExistingPrompt_customPromptInput_ExistingPrompt_ModelProfileId = cmdletContext.CustomPromptInput_ExistingPrompt_ModelProfileId;
            }
            if (requestCustomPromptInput_customPromptInput_ExistingPrompt_customPromptInput_ExistingPrompt_ModelProfileId != null)
            {
                requestCustomPromptInput_customPromptInput_ExistingPrompt.ModelProfileId = requestCustomPromptInput_customPromptInput_ExistingPrompt_customPromptInput_ExistingPrompt_ModelProfileId;
                requestCustomPromptInput_customPromptInput_ExistingPromptIsNull = false;
            }
            System.String requestCustomPromptInput_customPromptInput_ExistingPrompt_customPromptInput_ExistingPrompt_QbsAwsAccountId = null;
            if (cmdletContext.CustomPromptInput_ExistingPrompt_QbsAwsAccountId != null)
            {
                requestCustomPromptInput_customPromptInput_ExistingPrompt_customPromptInput_ExistingPrompt_QbsAwsAccountId = cmdletContext.CustomPromptInput_ExistingPrompt_QbsAwsAccountId;
            }
            if (requestCustomPromptInput_customPromptInput_ExistingPrompt_customPromptInput_ExistingPrompt_QbsAwsAccountId != null)
            {
                requestCustomPromptInput_customPromptInput_ExistingPrompt.QbsAwsAccountId = requestCustomPromptInput_customPromptInput_ExistingPrompt_customPromptInput_ExistingPrompt_QbsAwsAccountId;
                requestCustomPromptInput_customPromptInput_ExistingPromptIsNull = false;
            }
            System.String requestCustomPromptInput_customPromptInput_ExistingPrompt_customPromptInput_ExistingPrompt_SubscriptionId = null;
            if (cmdletContext.CustomPromptInput_ExistingPrompt_SubscriptionId != null)
            {
                requestCustomPromptInput_customPromptInput_ExistingPrompt_customPromptInput_ExistingPrompt_SubscriptionId = cmdletContext.CustomPromptInput_ExistingPrompt_SubscriptionId;
            }
            if (requestCustomPromptInput_customPromptInput_ExistingPrompt_customPromptInput_ExistingPrompt_SubscriptionId != null)
            {
                requestCustomPromptInput_customPromptInput_ExistingPrompt.SubscriptionId = requestCustomPromptInput_customPromptInput_ExistingPrompt_customPromptInput_ExistingPrompt_SubscriptionId;
                requestCustomPromptInput_customPromptInput_ExistingPromptIsNull = false;
            }
             // determine if requestCustomPromptInput_customPromptInput_ExistingPrompt should be set to null
            if (requestCustomPromptInput_customPromptInput_ExistingPromptIsNull)
            {
                requestCustomPromptInput_customPromptInput_ExistingPrompt = null;
            }
            if (requestCustomPromptInput_customPromptInput_ExistingPrompt != null)
            {
                request.CustomPromptInput.ExistingPrompt = requestCustomPromptInput_customPromptInput_ExistingPrompt;
                requestCustomPromptInputIsNull = false;
            }
            Amazon.QuickSight.Model.CustomPromptInputParameters requestCustomPromptInput_customPromptInput_NewPrompt = null;
            
             // populate NewPrompt
            var requestCustomPromptInput_customPromptInput_NewPromptIsNull = true;
            requestCustomPromptInput_customPromptInput_NewPrompt = new Amazon.QuickSight.Model.CustomPromptInputParameters();
            System.String requestCustomPromptInput_customPromptInput_NewPrompt_customPromptInput_NewPrompt_CustomInstruction = null;
            if (cmdletContext.CustomPromptInput_NewPrompt_CustomInstruction != null)
            {
                requestCustomPromptInput_customPromptInput_NewPrompt_customPromptInput_NewPrompt_CustomInstruction = cmdletContext.CustomPromptInput_NewPrompt_CustomInstruction;
            }
            if (requestCustomPromptInput_customPromptInput_NewPrompt_customPromptInput_NewPrompt_CustomInstruction != null)
            {
                requestCustomPromptInput_customPromptInput_NewPrompt.CustomInstructions = requestCustomPromptInput_customPromptInput_NewPrompt_customPromptInput_NewPrompt_CustomInstruction;
                requestCustomPromptInput_customPromptInput_NewPromptIsNull = false;
            }
            System.String requestCustomPromptInput_customPromptInput_NewPrompt_customPromptInput_NewPrompt_Identity = null;
            if (cmdletContext.CustomPromptInput_NewPrompt_Identity != null)
            {
                requestCustomPromptInput_customPromptInput_NewPrompt_customPromptInput_NewPrompt_Identity = cmdletContext.CustomPromptInput_NewPrompt_Identity;
            }
            if (requestCustomPromptInput_customPromptInput_NewPrompt_customPromptInput_NewPrompt_Identity != null)
            {
                requestCustomPromptInput_customPromptInput_NewPrompt.Identity = requestCustomPromptInput_customPromptInput_NewPrompt_customPromptInput_NewPrompt_Identity;
                requestCustomPromptInput_customPromptInput_NewPromptIsNull = false;
            }
            System.String requestCustomPromptInput_customPromptInput_NewPrompt_customPromptInput_NewPrompt_OutputStyle = null;
            if (cmdletContext.CustomPromptInput_NewPrompt_OutputStyle != null)
            {
                requestCustomPromptInput_customPromptInput_NewPrompt_customPromptInput_NewPrompt_OutputStyle = cmdletContext.CustomPromptInput_NewPrompt_OutputStyle;
            }
            if (requestCustomPromptInput_customPromptInput_NewPrompt_customPromptInput_NewPrompt_OutputStyle != null)
            {
                requestCustomPromptInput_customPromptInput_NewPrompt.OutputStyle = requestCustomPromptInput_customPromptInput_NewPrompt_customPromptInput_NewPrompt_OutputStyle;
                requestCustomPromptInput_customPromptInput_NewPromptIsNull = false;
            }
            System.String requestCustomPromptInput_customPromptInput_NewPrompt_customPromptInput_NewPrompt_ResponseLength = null;
            if (cmdletContext.CustomPromptInput_NewPrompt_ResponseLength != null)
            {
                requestCustomPromptInput_customPromptInput_NewPrompt_customPromptInput_NewPrompt_ResponseLength = cmdletContext.CustomPromptInput_NewPrompt_ResponseLength;
            }
            if (requestCustomPromptInput_customPromptInput_NewPrompt_customPromptInput_NewPrompt_ResponseLength != null)
            {
                requestCustomPromptInput_customPromptInput_NewPrompt.ResponseLength = requestCustomPromptInput_customPromptInput_NewPrompt_customPromptInput_NewPrompt_ResponseLength;
                requestCustomPromptInput_customPromptInput_NewPromptIsNull = false;
            }
            System.String requestCustomPromptInput_customPromptInput_NewPrompt_customPromptInput_NewPrompt_Tone = null;
            if (cmdletContext.CustomPromptInput_NewPrompt_Tone != null)
            {
                requestCustomPromptInput_customPromptInput_NewPrompt_customPromptInput_NewPrompt_Tone = cmdletContext.CustomPromptInput_NewPrompt_Tone;
            }
            if (requestCustomPromptInput_customPromptInput_NewPrompt_customPromptInput_NewPrompt_Tone != null)
            {
                requestCustomPromptInput_customPromptInput_NewPrompt.Tone = requestCustomPromptInput_customPromptInput_NewPrompt_customPromptInput_NewPrompt_Tone;
                requestCustomPromptInput_customPromptInput_NewPromptIsNull = false;
            }
             // determine if requestCustomPromptInput_customPromptInput_NewPrompt should be set to null
            if (requestCustomPromptInput_customPromptInput_NewPromptIsNull)
            {
                requestCustomPromptInput_customPromptInput_NewPrompt = null;
            }
            if (requestCustomPromptInput_customPromptInput_NewPrompt != null)
            {
                request.CustomPromptInput.NewPrompt = requestCustomPromptInput_customPromptInput_NewPrompt;
                requestCustomPromptInputIsNull = false;
            }
             // determine if request.CustomPromptInput should be set to null
            if (requestCustomPromptInputIsNull)
            {
                request.CustomPromptInput = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.IconId != null)
            {
                request.IconId = cmdletContext.IconId;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Space != null)
            {
                request.Spaces = cmdletContext.Space;
            }
            if (cmdletContext.StarterPrompt != null)
            {
                request.StarterPrompts = cmdletContext.StarterPrompt;
            }
            if (cmdletContext.WelcomeMessage != null)
            {
                request.WelcomeMessage = cmdletContext.WelcomeMessage;
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
        
        private Amazon.QuickSight.Model.CreateAgentResponse CallAWSServiceOperation(IAmazonQuickSight client, Amazon.QuickSight.Model.CreateAgentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon QuickSight", "CreateAgent");
            try
            {
                return client.CreateAgentAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> ActionConnector { get; set; }
            public System.String AgentId { get; set; }
            public Amazon.QuickSight.AgentLifecycle AgentLifecycle { get; set; }
            public System.String AwsAccountId { get; set; }
            public System.String CustomPromptInput_ExistingPrompt_ModelProfileId { get; set; }
            public System.String CustomPromptInput_ExistingPrompt_QbsAwsAccountId { get; set; }
            public System.String CustomPromptInput_ExistingPrompt_SubscriptionId { get; set; }
            public System.String CustomPromptInput_NewPrompt_CustomInstruction { get; set; }
            public System.String CustomPromptInput_NewPrompt_Identity { get; set; }
            public System.String CustomPromptInput_NewPrompt_OutputStyle { get; set; }
            public System.String CustomPromptInput_NewPrompt_ResponseLength { get; set; }
            public System.String CustomPromptInput_NewPrompt_Tone { get; set; }
            public System.String Description { get; set; }
            public System.String IconId { get; set; }
            public System.String Name { get; set; }
            public List<System.String> Space { get; set; }
            public List<System.String> StarterPrompt { get; set; }
            public System.String WelcomeMessage { get; set; }
            public System.Func<Amazon.QuickSight.Model.CreateAgentResponse, NewQSAgentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
