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
using Amazon.QConnect;
using Amazon.QConnect.Model;

namespace Amazon.PowerShell.Cmdlets.QC
{
    /// <summary>
    /// Updates a session. A session is a contextual container used for generating recommendations.
    /// Amazon Connect updates the existing Amazon Q in Connect session for each contact on
    /// which Amazon Q in Connect is enabled.
    /// </summary>
    [Cmdlet("Update", "QCSession", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.QConnect.Model.SessionData")]
    [AWSCmdlet("Calls the Amazon Q Connect UpdateSession API operation.", Operation = new[] {"UpdateSession"}, SelectReturnType = typeof(Amazon.QConnect.Model.UpdateSessionResponse))]
    [AWSCmdletOutput("Amazon.QConnect.Model.SessionData or Amazon.QConnect.Model.UpdateSessionResponse",
        "This cmdlet returns an Amazon.QConnect.Model.SessionData object.",
        "The service call response (type Amazon.QConnect.Model.UpdateSessionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateQCSessionCmdlet : AmazonQConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AiAgentConfiguration
        /// <summary>
        /// <para>
        /// <para>The configuration of the AI Agents (mapped by AI Agent Type to AI Agent version) that
        /// should be used by Amazon Q in Connect for this Session.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable AiAgentConfiguration { get; set; }
        #endregion
        
        #region Parameter TagFilter_AndCondition
        /// <summary>
        /// <para>
        /// <para>A list of conditions which would be applied together with an <c>AND</c> condition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TagFilter_AndConditions")]
        public Amazon.QConnect.Model.TagCondition[] TagFilter_AndCondition { get; set; }
        #endregion
        
        #region Parameter AssistantId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon Q in Connect assistant. Can be either the ID or the ARN.
        /// URLs cannot contain the ARN.</para>
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
        public System.String AssistantId { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter TagCondition_Key
        /// <summary>
        /// <para>
        /// <para>The tag key in the tag condition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TagFilter_TagCondition_Key")]
        public System.String TagCondition_Key { get; set; }
        #endregion
        
        #region Parameter OrchestratorConfigurationList
        /// <summary>
        /// <para>
        /// <para>The updated list of orchestrator configurations for the session.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.QConnect.Model.OrchestratorConfigurationEntry[] OrchestratorConfigurationList { get; set; }
        #endregion
        
        #region Parameter TagFilter_OrCondition
        /// <summary>
        /// <para>
        /// <para>A list of conditions which would be applied together with an <c>OR</c> condition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TagFilter_OrConditions")]
        public Amazon.QConnect.Model.OrCondition[] TagFilter_OrCondition { get; set; }
        #endregion
        
        #region Parameter RemoveOrchestratorConfigurationList
        /// <summary>
        /// <para>
        /// <para>The list of orchestrator configurations to remove from the session.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? RemoveOrchestratorConfigurationList { get; set; }
        #endregion
        
        #region Parameter SessionId
        /// <summary>
        /// <para>
        /// <para>The identifier of the session. Can be either the ID or the ARN. URLs cannot contain
        /// the ARN.</para>
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
        public System.String SessionId { get; set; }
        #endregion
        
        #region Parameter TagCondition_Value
        /// <summary>
        /// <para>
        /// <para>The tag value in the tag condition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TagFilter_TagCondition_Value")]
        public System.String TagCondition_Value { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Session'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QConnect.Model.UpdateSessionResponse).
        /// Specifying the name of a property of type Amazon.QConnect.Model.UpdateSessionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Session";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the SessionId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^SessionId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^SessionId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SessionId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-QCSession (UpdateSession)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QConnect.Model.UpdateSessionResponse, UpdateQCSessionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.SessionId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.AiAgentConfiguration != null)
            {
                context.AiAgentConfiguration = new Dictionary<System.String, Amazon.QConnect.Model.AIAgentConfigurationData>(StringComparer.Ordinal);
                foreach (var hashKey in this.AiAgentConfiguration.Keys)
                {
                    context.AiAgentConfiguration.Add((String)hashKey, (Amazon.QConnect.Model.AIAgentConfigurationData)(this.AiAgentConfiguration[hashKey]));
                }
            }
            context.AssistantId = this.AssistantId;
            #if MODULAR
            if (this.AssistantId == null && ParameterWasBound(nameof(this.AssistantId)))
            {
                WriteWarning("You are passing $null as a value for parameter AssistantId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            if (this.OrchestratorConfigurationList != null)
            {
                context.OrchestratorConfigurationList = new List<Amazon.QConnect.Model.OrchestratorConfigurationEntry>(this.OrchestratorConfigurationList);
            }
            context.RemoveOrchestratorConfigurationList = this.RemoveOrchestratorConfigurationList;
            context.SessionId = this.SessionId;
            #if MODULAR
            if (this.SessionId == null && ParameterWasBound(nameof(this.SessionId)))
            {
                WriteWarning("You are passing $null as a value for parameter SessionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.TagFilter_AndCondition != null)
            {
                context.TagFilter_AndCondition = new List<Amazon.QConnect.Model.TagCondition>(this.TagFilter_AndCondition);
            }
            if (this.TagFilter_OrCondition != null)
            {
                context.TagFilter_OrCondition = new List<Amazon.QConnect.Model.OrCondition>(this.TagFilter_OrCondition);
            }
            context.TagCondition_Key = this.TagCondition_Key;
            context.TagCondition_Value = this.TagCondition_Value;
            
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
            var request = new Amazon.QConnect.Model.UpdateSessionRequest();
            
            if (cmdletContext.AiAgentConfiguration != null)
            {
                request.AiAgentConfiguration = cmdletContext.AiAgentConfiguration;
            }
            if (cmdletContext.AssistantId != null)
            {
                request.AssistantId = cmdletContext.AssistantId;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.OrchestratorConfigurationList != null)
            {
                request.OrchestratorConfigurationList = cmdletContext.OrchestratorConfigurationList;
            }
            if (cmdletContext.RemoveOrchestratorConfigurationList != null)
            {
                request.RemoveOrchestratorConfigurationList = cmdletContext.RemoveOrchestratorConfigurationList.Value;
            }
            if (cmdletContext.SessionId != null)
            {
                request.SessionId = cmdletContext.SessionId;
            }
            
             // populate TagFilter
            var requestTagFilterIsNull = true;
            request.TagFilter = new Amazon.QConnect.Model.TagFilter();
            List<Amazon.QConnect.Model.TagCondition> requestTagFilter_tagFilter_AndCondition = null;
            if (cmdletContext.TagFilter_AndCondition != null)
            {
                requestTagFilter_tagFilter_AndCondition = cmdletContext.TagFilter_AndCondition;
            }
            if (requestTagFilter_tagFilter_AndCondition != null)
            {
                request.TagFilter.AndConditions = requestTagFilter_tagFilter_AndCondition;
                requestTagFilterIsNull = false;
            }
            List<Amazon.QConnect.Model.OrCondition> requestTagFilter_tagFilter_OrCondition = null;
            if (cmdletContext.TagFilter_OrCondition != null)
            {
                requestTagFilter_tagFilter_OrCondition = cmdletContext.TagFilter_OrCondition;
            }
            if (requestTagFilter_tagFilter_OrCondition != null)
            {
                request.TagFilter.OrConditions = requestTagFilter_tagFilter_OrCondition;
                requestTagFilterIsNull = false;
            }
            Amazon.QConnect.Model.TagCondition requestTagFilter_tagFilter_TagCondition = null;
            
             // populate TagCondition
            var requestTagFilter_tagFilter_TagConditionIsNull = true;
            requestTagFilter_tagFilter_TagCondition = new Amazon.QConnect.Model.TagCondition();
            System.String requestTagFilter_tagFilter_TagCondition_tagCondition_Key = null;
            if (cmdletContext.TagCondition_Key != null)
            {
                requestTagFilter_tagFilter_TagCondition_tagCondition_Key = cmdletContext.TagCondition_Key;
            }
            if (requestTagFilter_tagFilter_TagCondition_tagCondition_Key != null)
            {
                requestTagFilter_tagFilter_TagCondition.Key = requestTagFilter_tagFilter_TagCondition_tagCondition_Key;
                requestTagFilter_tagFilter_TagConditionIsNull = false;
            }
            System.String requestTagFilter_tagFilter_TagCondition_tagCondition_Value = null;
            if (cmdletContext.TagCondition_Value != null)
            {
                requestTagFilter_tagFilter_TagCondition_tagCondition_Value = cmdletContext.TagCondition_Value;
            }
            if (requestTagFilter_tagFilter_TagCondition_tagCondition_Value != null)
            {
                requestTagFilter_tagFilter_TagCondition.Value = requestTagFilter_tagFilter_TagCondition_tagCondition_Value;
                requestTagFilter_tagFilter_TagConditionIsNull = false;
            }
             // determine if requestTagFilter_tagFilter_TagCondition should be set to null
            if (requestTagFilter_tagFilter_TagConditionIsNull)
            {
                requestTagFilter_tagFilter_TagCondition = null;
            }
            if (requestTagFilter_tagFilter_TagCondition != null)
            {
                request.TagFilter.TagCondition = requestTagFilter_tagFilter_TagCondition;
                requestTagFilterIsNull = false;
            }
             // determine if request.TagFilter should be set to null
            if (requestTagFilterIsNull)
            {
                request.TagFilter = null;
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
        
        private Amazon.QConnect.Model.UpdateSessionResponse CallAWSServiceOperation(IAmazonQConnect client, Amazon.QConnect.Model.UpdateSessionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Q Connect", "UpdateSession");
            try
            {
                #if DESKTOP
                return client.UpdateSession(request);
                #elif CORECLR
                return client.UpdateSessionAsync(request).GetAwaiter().GetResult();
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
            public Dictionary<System.String, Amazon.QConnect.Model.AIAgentConfigurationData> AiAgentConfiguration { get; set; }
            public System.String AssistantId { get; set; }
            public System.String Description { get; set; }
            public List<Amazon.QConnect.Model.OrchestratorConfigurationEntry> OrchestratorConfigurationList { get; set; }
            public System.Boolean? RemoveOrchestratorConfigurationList { get; set; }
            public System.String SessionId { get; set; }
            public List<Amazon.QConnect.Model.TagCondition> TagFilter_AndCondition { get; set; }
            public List<Amazon.QConnect.Model.OrCondition> TagFilter_OrCondition { get; set; }
            public System.String TagCondition_Key { get; set; }
            public System.String TagCondition_Value { get; set; }
            public System.Func<Amazon.QConnect.Model.UpdateSessionResponse, UpdateQCSessionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Session;
        }
        
    }
}
