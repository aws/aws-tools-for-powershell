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
using Amazon.QBusiness;
using Amazon.QBusiness.Model;

namespace Amazon.PowerShell.Cmdlets.QBUS
{
    /// <summary>
    /// Updates a set of chat controls configured for an existing Amazon Q Business application.
    /// </summary>
    [Cmdlet("Update", "QBUSChatControlsConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon QBusiness UpdateChatControlsConfiguration API operation.", Operation = new[] {"UpdateChatControlsConfiguration"}, SelectReturnType = typeof(Amazon.QBusiness.Model.UpdateChatControlsConfigurationResponse))]
    [AWSCmdletOutput("None or Amazon.QBusiness.Model.UpdateChatControlsConfigurationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.QBusiness.Model.UpdateChatControlsConfigurationResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateQBUSChatControlsConfigurationCmdlet : AmazonQBusinessClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ApplicationId
        /// <summary>
        /// <para>
        /// <para>The identifier of the application for which the chat controls are configured.</para>
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
        public System.String ApplicationId { get; set; }
        #endregion
        
        #region Parameter BlockedPhrasesConfigurationUpdate_BlockedPhrasesToCreateOrUpdate
        /// <summary>
        /// <para>
        /// <para>Creates or updates a blocked phrases configuration in your Amazon Q Business application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] BlockedPhrasesConfigurationUpdate_BlockedPhrasesToCreateOrUpdate { get; set; }
        #endregion
        
        #region Parameter BlockedPhrasesConfigurationUpdate_BlockedPhrasesToDelete
        /// <summary>
        /// <para>
        /// <para>Deletes a blocked phrases configuration in your Amazon Q Business application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] BlockedPhrasesConfigurationUpdate_BlockedPhrasesToDelete { get; set; }
        #endregion
        
        #region Parameter OrchestrationConfiguration_Control
        /// <summary>
        /// <para>
        /// <para> Status information about whether chat orchestration is activated or deactivated for
        /// your Amazon Q Business application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QBusiness.OrchestrationControl")]
        public Amazon.QBusiness.OrchestrationControl OrchestrationConfiguration_Control { get; set; }
        #endregion
        
        #region Parameter CreatorModeConfiguration_CreatorModeControl
        /// <summary>
        /// <para>
        /// <para>Status information about whether <c>CREATOR_MODE</c> has been enabled or disabled.
        /// The default status is <c>DISABLED</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QBusiness.CreatorModeControl")]
        public Amazon.QBusiness.CreatorModeControl CreatorModeConfiguration_CreatorModeControl { get; set; }
        #endregion
        
        #region Parameter ResponseScope
        /// <summary>
        /// <para>
        /// <para>The response scope configured for your application. This determines whether your application
        /// uses its retrieval augmented generation (RAG) system to generate answers only from
        /// your enterprise data, or also uses the large language models (LLM) knowledge to respons
        /// to end user questions in chat.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QBusiness.ResponseScope")]
        public Amazon.QBusiness.ResponseScope ResponseScope { get; set; }
        #endregion
        
        #region Parameter BlockedPhrasesConfigurationUpdate_SystemMessageOverride
        /// <summary>
        /// <para>
        /// <para>The configured custom message displayed to your end user when they use blocked phrase
        /// during chat.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BlockedPhrasesConfigurationUpdate_SystemMessageOverride { get; set; }
        #endregion
        
        #region Parameter TopicConfigurationsToCreateOrUpdate
        /// <summary>
        /// <para>
        /// <para>The configured topic specific chat controls you want to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.QBusiness.Model.TopicConfiguration[] TopicConfigurationsToCreateOrUpdate { get; set; }
        #endregion
        
        #region Parameter TopicConfigurationsToDelete
        /// <summary>
        /// <para>
        /// <para>The configured topic specific chat controls you want to delete.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.QBusiness.Model.TopicConfiguration[] TopicConfigurationsToDelete { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A token that you provide to identify the request to update a Amazon Q Business application
        /// chat configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QBusiness.Model.UpdateChatControlsConfigurationResponse).
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ApplicationId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-QBUSChatControlsConfiguration (UpdateChatControlsConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QBusiness.Model.UpdateChatControlsConfigurationResponse, UpdateQBUSChatControlsConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApplicationId = this.ApplicationId;
            #if MODULAR
            if (this.ApplicationId == null && ParameterWasBound(nameof(this.ApplicationId)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplicationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.BlockedPhrasesConfigurationUpdate_BlockedPhrasesToCreateOrUpdate != null)
            {
                context.BlockedPhrasesConfigurationUpdate_BlockedPhrasesToCreateOrUpdate = new List<System.String>(this.BlockedPhrasesConfigurationUpdate_BlockedPhrasesToCreateOrUpdate);
            }
            if (this.BlockedPhrasesConfigurationUpdate_BlockedPhrasesToDelete != null)
            {
                context.BlockedPhrasesConfigurationUpdate_BlockedPhrasesToDelete = new List<System.String>(this.BlockedPhrasesConfigurationUpdate_BlockedPhrasesToDelete);
            }
            context.BlockedPhrasesConfigurationUpdate_SystemMessageOverride = this.BlockedPhrasesConfigurationUpdate_SystemMessageOverride;
            context.ClientToken = this.ClientToken;
            context.CreatorModeConfiguration_CreatorModeControl = this.CreatorModeConfiguration_CreatorModeControl;
            context.OrchestrationConfiguration_Control = this.OrchestrationConfiguration_Control;
            context.ResponseScope = this.ResponseScope;
            if (this.TopicConfigurationsToCreateOrUpdate != null)
            {
                context.TopicConfigurationsToCreateOrUpdate = new List<Amazon.QBusiness.Model.TopicConfiguration>(this.TopicConfigurationsToCreateOrUpdate);
            }
            if (this.TopicConfigurationsToDelete != null)
            {
                context.TopicConfigurationsToDelete = new List<Amazon.QBusiness.Model.TopicConfiguration>(this.TopicConfigurationsToDelete);
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
            var request = new Amazon.QBusiness.Model.UpdateChatControlsConfigurationRequest();
            
            if (cmdletContext.ApplicationId != null)
            {
                request.ApplicationId = cmdletContext.ApplicationId;
            }
            
             // populate BlockedPhrasesConfigurationUpdate
            var requestBlockedPhrasesConfigurationUpdateIsNull = true;
            request.BlockedPhrasesConfigurationUpdate = new Amazon.QBusiness.Model.BlockedPhrasesConfigurationUpdate();
            List<System.String> requestBlockedPhrasesConfigurationUpdate_blockedPhrasesConfigurationUpdate_BlockedPhrasesToCreateOrUpdate = null;
            if (cmdletContext.BlockedPhrasesConfigurationUpdate_BlockedPhrasesToCreateOrUpdate != null)
            {
                requestBlockedPhrasesConfigurationUpdate_blockedPhrasesConfigurationUpdate_BlockedPhrasesToCreateOrUpdate = cmdletContext.BlockedPhrasesConfigurationUpdate_BlockedPhrasesToCreateOrUpdate;
            }
            if (requestBlockedPhrasesConfigurationUpdate_blockedPhrasesConfigurationUpdate_BlockedPhrasesToCreateOrUpdate != null)
            {
                request.BlockedPhrasesConfigurationUpdate.BlockedPhrasesToCreateOrUpdate = requestBlockedPhrasesConfigurationUpdate_blockedPhrasesConfigurationUpdate_BlockedPhrasesToCreateOrUpdate;
                requestBlockedPhrasesConfigurationUpdateIsNull = false;
            }
            List<System.String> requestBlockedPhrasesConfigurationUpdate_blockedPhrasesConfigurationUpdate_BlockedPhrasesToDelete = null;
            if (cmdletContext.BlockedPhrasesConfigurationUpdate_BlockedPhrasesToDelete != null)
            {
                requestBlockedPhrasesConfigurationUpdate_blockedPhrasesConfigurationUpdate_BlockedPhrasesToDelete = cmdletContext.BlockedPhrasesConfigurationUpdate_BlockedPhrasesToDelete;
            }
            if (requestBlockedPhrasesConfigurationUpdate_blockedPhrasesConfigurationUpdate_BlockedPhrasesToDelete != null)
            {
                request.BlockedPhrasesConfigurationUpdate.BlockedPhrasesToDelete = requestBlockedPhrasesConfigurationUpdate_blockedPhrasesConfigurationUpdate_BlockedPhrasesToDelete;
                requestBlockedPhrasesConfigurationUpdateIsNull = false;
            }
            System.String requestBlockedPhrasesConfigurationUpdate_blockedPhrasesConfigurationUpdate_SystemMessageOverride = null;
            if (cmdletContext.BlockedPhrasesConfigurationUpdate_SystemMessageOverride != null)
            {
                requestBlockedPhrasesConfigurationUpdate_blockedPhrasesConfigurationUpdate_SystemMessageOverride = cmdletContext.BlockedPhrasesConfigurationUpdate_SystemMessageOverride;
            }
            if (requestBlockedPhrasesConfigurationUpdate_blockedPhrasesConfigurationUpdate_SystemMessageOverride != null)
            {
                request.BlockedPhrasesConfigurationUpdate.SystemMessageOverride = requestBlockedPhrasesConfigurationUpdate_blockedPhrasesConfigurationUpdate_SystemMessageOverride;
                requestBlockedPhrasesConfigurationUpdateIsNull = false;
            }
             // determine if request.BlockedPhrasesConfigurationUpdate should be set to null
            if (requestBlockedPhrasesConfigurationUpdateIsNull)
            {
                request.BlockedPhrasesConfigurationUpdate = null;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate CreatorModeConfiguration
            var requestCreatorModeConfigurationIsNull = true;
            request.CreatorModeConfiguration = new Amazon.QBusiness.Model.CreatorModeConfiguration();
            Amazon.QBusiness.CreatorModeControl requestCreatorModeConfiguration_creatorModeConfiguration_CreatorModeControl = null;
            if (cmdletContext.CreatorModeConfiguration_CreatorModeControl != null)
            {
                requestCreatorModeConfiguration_creatorModeConfiguration_CreatorModeControl = cmdletContext.CreatorModeConfiguration_CreatorModeControl;
            }
            if (requestCreatorModeConfiguration_creatorModeConfiguration_CreatorModeControl != null)
            {
                request.CreatorModeConfiguration.CreatorModeControl = requestCreatorModeConfiguration_creatorModeConfiguration_CreatorModeControl;
                requestCreatorModeConfigurationIsNull = false;
            }
             // determine if request.CreatorModeConfiguration should be set to null
            if (requestCreatorModeConfigurationIsNull)
            {
                request.CreatorModeConfiguration = null;
            }
            
             // populate OrchestrationConfiguration
            var requestOrchestrationConfigurationIsNull = true;
            request.OrchestrationConfiguration = new Amazon.QBusiness.Model.OrchestrationConfiguration();
            Amazon.QBusiness.OrchestrationControl requestOrchestrationConfiguration_orchestrationConfiguration_Control = null;
            if (cmdletContext.OrchestrationConfiguration_Control != null)
            {
                requestOrchestrationConfiguration_orchestrationConfiguration_Control = cmdletContext.OrchestrationConfiguration_Control;
            }
            if (requestOrchestrationConfiguration_orchestrationConfiguration_Control != null)
            {
                request.OrchestrationConfiguration.Control = requestOrchestrationConfiguration_orchestrationConfiguration_Control;
                requestOrchestrationConfigurationIsNull = false;
            }
             // determine if request.OrchestrationConfiguration should be set to null
            if (requestOrchestrationConfigurationIsNull)
            {
                request.OrchestrationConfiguration = null;
            }
            if (cmdletContext.ResponseScope != null)
            {
                request.ResponseScope = cmdletContext.ResponseScope;
            }
            if (cmdletContext.TopicConfigurationsToCreateOrUpdate != null)
            {
                request.TopicConfigurationsToCreateOrUpdate = cmdletContext.TopicConfigurationsToCreateOrUpdate;
            }
            if (cmdletContext.TopicConfigurationsToDelete != null)
            {
                request.TopicConfigurationsToDelete = cmdletContext.TopicConfigurationsToDelete;
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
        
        private Amazon.QBusiness.Model.UpdateChatControlsConfigurationResponse CallAWSServiceOperation(IAmazonQBusiness client, Amazon.QBusiness.Model.UpdateChatControlsConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon QBusiness", "UpdateChatControlsConfiguration");
            try
            {
                return client.UpdateChatControlsConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ApplicationId { get; set; }
            public List<System.String> BlockedPhrasesConfigurationUpdate_BlockedPhrasesToCreateOrUpdate { get; set; }
            public List<System.String> BlockedPhrasesConfigurationUpdate_BlockedPhrasesToDelete { get; set; }
            public System.String BlockedPhrasesConfigurationUpdate_SystemMessageOverride { get; set; }
            public System.String ClientToken { get; set; }
            public Amazon.QBusiness.CreatorModeControl CreatorModeConfiguration_CreatorModeControl { get; set; }
            public Amazon.QBusiness.OrchestrationControl OrchestrationConfiguration_Control { get; set; }
            public Amazon.QBusiness.ResponseScope ResponseScope { get; set; }
            public List<Amazon.QBusiness.Model.TopicConfiguration> TopicConfigurationsToCreateOrUpdate { get; set; }
            public List<Amazon.QBusiness.Model.TopicConfiguration> TopicConfigurationsToDelete { get; set; }
            public System.Func<Amazon.QBusiness.Model.UpdateChatControlsConfigurationResponse, UpdateQBUSChatControlsConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
