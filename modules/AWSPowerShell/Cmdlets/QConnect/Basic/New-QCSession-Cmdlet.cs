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
using Amazon.QConnect;
using Amazon.QConnect.Model;

namespace Amazon.PowerShell.Cmdlets.QC
{
    /// <summary>
    /// Creates a session. A session is a contextual container used for generating recommendations.
    /// Amazon Connect creates a new Amazon Q in Connect session for each contact on which
    /// Amazon Q in Connect is enabled.
    /// </summary>
    [Cmdlet("New", "QCSession", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.QConnect.Model.SessionData")]
    [AWSCmdlet("Calls the Amazon Q Connect CreateSession API operation.", Operation = new[] {"CreateSession"}, SelectReturnType = typeof(Amazon.QConnect.Model.CreateSessionResponse))]
    [AWSCmdletOutput("Amazon.QConnect.Model.SessionData or Amazon.QConnect.Model.CreateSessionResponse",
        "This cmdlet returns an Amazon.QConnect.Model.SessionData object.",
        "The service call response (type Amazon.QConnect.Model.CreateSessionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewQCSessionCmdlet : AmazonQConnectClientCmdlet, IExecutor
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
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
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
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the session.</para>
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
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags used to organize, track, or control access for this resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
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
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request. If not provided, the Amazon Web Services SDK populates this field. For
        /// more information about idempotency, see <a href="https://aws.amazon.com/builders-library/making-retries-safe-with-idempotent-APIs/">Making
        /// retries safe with idempotent APIs</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Session'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QConnect.Model.CreateSessionResponse).
        /// Specifying the name of a property of type Amazon.QConnect.Model.CreateSessionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Session";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AssistantId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AssistantId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AssistantId' instead. This parameter will be removed in a future version.")]
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-QCSession (CreateSession)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QConnect.Model.CreateSessionResponse, NewQCSessionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AssistantId;
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
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.QConnect.Model.CreateSessionRequest();
            
            if (cmdletContext.AiAgentConfiguration != null)
            {
                request.AiAgentConfiguration = cmdletContext.AiAgentConfiguration;
            }
            if (cmdletContext.AssistantId != null)
            {
                request.AssistantId = cmdletContext.AssistantId;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
        
        private Amazon.QConnect.Model.CreateSessionResponse CallAWSServiceOperation(IAmazonQConnect client, Amazon.QConnect.Model.CreateSessionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Q Connect", "CreateSession");
            try
            {
                #if DESKTOP
                return client.CreateSession(request);
                #elif CORECLR
                return client.CreateSessionAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.QConnect.Model.TagCondition> TagFilter_AndCondition { get; set; }
            public List<Amazon.QConnect.Model.OrCondition> TagFilter_OrCondition { get; set; }
            public System.String TagCondition_Key { get; set; }
            public System.String TagCondition_Value { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.QConnect.Model.CreateSessionResponse, NewQCSessionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Session;
        }
        
    }
}
