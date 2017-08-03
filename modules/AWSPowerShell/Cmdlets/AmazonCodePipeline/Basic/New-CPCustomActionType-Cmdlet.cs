/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.CodePipeline;
using Amazon.CodePipeline.Model;

namespace Amazon.PowerShell.Cmdlets.CP
{
    /// <summary>
    /// Creates a new custom action that can be used in all pipelines associated with the
    /// AWS account. Only used for custom actions.
    /// </summary>
    [Cmdlet("New", "CPCustomActionType", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CodePipeline.Model.ActionType")]
    [AWSCmdlet("Invokes the CreateCustomActionType operation against AWS CodePipeline.", Operation = new[] {"CreateCustomActionType"})]
    [AWSCmdletOutput("Amazon.CodePipeline.Model.ActionType",
        "This cmdlet returns a ActionType object.",
        "The service call response (type Amazon.CodePipeline.Model.CreateCustomActionTypeResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewCPCustomActionTypeCmdlet : AmazonCodePipelineClientCmdlet, IExecutor
    {
        
        #region Parameter Category
        /// <summary>
        /// <para>
        /// <para>The category of the custom action, such as a build action or a test action.</para><note><para>Although Source and Approval are listed as valid values, they are not currently functional.
        /// These values are reserved for future use.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.CodePipeline.ActionCategory")]
        public Amazon.CodePipeline.ActionCategory Category { get; set; }
        #endregion
        
        #region Parameter ConfigurationProperty
        /// <summary>
        /// <para>
        /// <para>The configuration properties for the custom action.</para><note><para>You can refer to a name in the configuration properties of the custom action within
        /// the URL templates by following the format of {Config:name}, as long as the configuration
        /// property is both required and not secret. For more information, see <a href="http://docs.aws.amazon.com/codepipeline/latest/userguide/how-to-create-custom-action.html">Create
        /// a Custom Action for a Pipeline</a>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ConfigurationProperties")]
        public Amazon.CodePipeline.Model.ActionConfigurationProperty[] ConfigurationProperty { get; set; }
        #endregion
        
        #region Parameter Settings_EntityUrlTemplate
        /// <summary>
        /// <para>
        /// <para>The URL returned to the AWS CodePipeline console that provides a deep link to the
        /// resources of the external system, such as the configuration page for an AWS CodeDeploy
        /// deployment group. This link is provided as part of the action display within the pipeline.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Settings_EntityUrlTemplate { get; set; }
        #endregion
        
        #region Parameter Settings_ExecutionUrlTemplate
        /// <summary>
        /// <para>
        /// <para>The URL returned to the AWS CodePipeline console that contains a link to the top-level
        /// landing page for the external system, such as console page for AWS CodeDeploy. This
        /// link is shown on the pipeline view page in the AWS CodePipeline console and provides
        /// a link to the execution entity of the external action.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Settings_ExecutionUrlTemplate { get; set; }
        #endregion
        
        #region Parameter InputArtifactDetails_MaximumCount
        /// <summary>
        /// <para>
        /// <para>The maximum number of artifacts allowed for the action type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 InputArtifactDetails_MaximumCount { get; set; }
        #endregion
        
        #region Parameter OutputArtifactDetails_MaximumCount
        /// <summary>
        /// <para>
        /// <para>The maximum number of artifacts allowed for the action type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 OutputArtifactDetails_MaximumCount { get; set; }
        #endregion
        
        #region Parameter InputArtifactDetails_MinimumCount
        /// <summary>
        /// <para>
        /// <para>The minimum number of artifacts allowed for the action type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 InputArtifactDetails_MinimumCount { get; set; }
        #endregion
        
        #region Parameter OutputArtifactDetails_MinimumCount
        /// <summary>
        /// <para>
        /// <para>The minimum number of artifacts allowed for the action type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 OutputArtifactDetails_MinimumCount { get; set; }
        #endregion
        
        #region Parameter Provider
        /// <summary>
        /// <para>
        /// <para>The provider of the service used in the custom action, such as AWS CodeDeploy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Provider { get; set; }
        #endregion
        
        #region Parameter Settings_RevisionUrlTemplate
        /// <summary>
        /// <para>
        /// <para>The URL returned to the AWS CodePipeline console that contains a link to the page
        /// where customers can update or change the configuration of the external action.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Settings_RevisionUrlTemplate { get; set; }
        #endregion
        
        #region Parameter Settings_ThirdPartyConfigurationUrl
        /// <summary>
        /// <para>
        /// <para>The URL of a sign-up page where users can sign up for an external service and perform
        /// initial configuration of the action provided by that service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Settings_ThirdPartyConfigurationUrl { get; set; }
        #endregion
        
        #region Parameter Version
        /// <summary>
        /// <para>
        /// <para>The version identifier of the custom action.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Version { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Category", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CPCustomActionType (CreateCustomActionType)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.Category = this.Category;
            if (this.ConfigurationProperty != null)
            {
                context.ConfigurationProperties = new List<Amazon.CodePipeline.Model.ActionConfigurationProperty>(this.ConfigurationProperty);
            }
            if (ParameterWasBound("InputArtifactDetails_MaximumCount"))
                context.InputArtifactDetails_MaximumCount = this.InputArtifactDetails_MaximumCount;
            if (ParameterWasBound("InputArtifactDetails_MinimumCount"))
                context.InputArtifactDetails_MinimumCount = this.InputArtifactDetails_MinimumCount;
            if (ParameterWasBound("OutputArtifactDetails_MaximumCount"))
                context.OutputArtifactDetails_MaximumCount = this.OutputArtifactDetails_MaximumCount;
            if (ParameterWasBound("OutputArtifactDetails_MinimumCount"))
                context.OutputArtifactDetails_MinimumCount = this.OutputArtifactDetails_MinimumCount;
            context.Provider = this.Provider;
            context.Settings_EntityUrlTemplate = this.Settings_EntityUrlTemplate;
            context.Settings_ExecutionUrlTemplate = this.Settings_ExecutionUrlTemplate;
            context.Settings_RevisionUrlTemplate = this.Settings_RevisionUrlTemplate;
            context.Settings_ThirdPartyConfigurationUrl = this.Settings_ThirdPartyConfigurationUrl;
            context.Version = this.Version;
            
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
            var request = new Amazon.CodePipeline.Model.CreateCustomActionTypeRequest();
            
            if (cmdletContext.Category != null)
            {
                request.Category = cmdletContext.Category;
            }
            if (cmdletContext.ConfigurationProperties != null)
            {
                request.ConfigurationProperties = cmdletContext.ConfigurationProperties;
            }
            
             // populate InputArtifactDetails
            bool requestInputArtifactDetailsIsNull = true;
            request.InputArtifactDetails = new Amazon.CodePipeline.Model.ArtifactDetails();
            System.Int32? requestInputArtifactDetails_inputArtifactDetails_MaximumCount = null;
            if (cmdletContext.InputArtifactDetails_MaximumCount != null)
            {
                requestInputArtifactDetails_inputArtifactDetails_MaximumCount = cmdletContext.InputArtifactDetails_MaximumCount.Value;
            }
            if (requestInputArtifactDetails_inputArtifactDetails_MaximumCount != null)
            {
                request.InputArtifactDetails.MaximumCount = requestInputArtifactDetails_inputArtifactDetails_MaximumCount.Value;
                requestInputArtifactDetailsIsNull = false;
            }
            System.Int32? requestInputArtifactDetails_inputArtifactDetails_MinimumCount = null;
            if (cmdletContext.InputArtifactDetails_MinimumCount != null)
            {
                requestInputArtifactDetails_inputArtifactDetails_MinimumCount = cmdletContext.InputArtifactDetails_MinimumCount.Value;
            }
            if (requestInputArtifactDetails_inputArtifactDetails_MinimumCount != null)
            {
                request.InputArtifactDetails.MinimumCount = requestInputArtifactDetails_inputArtifactDetails_MinimumCount.Value;
                requestInputArtifactDetailsIsNull = false;
            }
             // determine if request.InputArtifactDetails should be set to null
            if (requestInputArtifactDetailsIsNull)
            {
                request.InputArtifactDetails = null;
            }
            
             // populate OutputArtifactDetails
            bool requestOutputArtifactDetailsIsNull = true;
            request.OutputArtifactDetails = new Amazon.CodePipeline.Model.ArtifactDetails();
            System.Int32? requestOutputArtifactDetails_outputArtifactDetails_MaximumCount = null;
            if (cmdletContext.OutputArtifactDetails_MaximumCount != null)
            {
                requestOutputArtifactDetails_outputArtifactDetails_MaximumCount = cmdletContext.OutputArtifactDetails_MaximumCount.Value;
            }
            if (requestOutputArtifactDetails_outputArtifactDetails_MaximumCount != null)
            {
                request.OutputArtifactDetails.MaximumCount = requestOutputArtifactDetails_outputArtifactDetails_MaximumCount.Value;
                requestOutputArtifactDetailsIsNull = false;
            }
            System.Int32? requestOutputArtifactDetails_outputArtifactDetails_MinimumCount = null;
            if (cmdletContext.OutputArtifactDetails_MinimumCount != null)
            {
                requestOutputArtifactDetails_outputArtifactDetails_MinimumCount = cmdletContext.OutputArtifactDetails_MinimumCount.Value;
            }
            if (requestOutputArtifactDetails_outputArtifactDetails_MinimumCount != null)
            {
                request.OutputArtifactDetails.MinimumCount = requestOutputArtifactDetails_outputArtifactDetails_MinimumCount.Value;
                requestOutputArtifactDetailsIsNull = false;
            }
             // determine if request.OutputArtifactDetails should be set to null
            if (requestOutputArtifactDetailsIsNull)
            {
                request.OutputArtifactDetails = null;
            }
            if (cmdletContext.Provider != null)
            {
                request.Provider = cmdletContext.Provider;
            }
            
             // populate Settings
            bool requestSettingsIsNull = true;
            request.Settings = new Amazon.CodePipeline.Model.ActionTypeSettings();
            System.String requestSettings_settings_EntityUrlTemplate = null;
            if (cmdletContext.Settings_EntityUrlTemplate != null)
            {
                requestSettings_settings_EntityUrlTemplate = cmdletContext.Settings_EntityUrlTemplate;
            }
            if (requestSettings_settings_EntityUrlTemplate != null)
            {
                request.Settings.EntityUrlTemplate = requestSettings_settings_EntityUrlTemplate;
                requestSettingsIsNull = false;
            }
            System.String requestSettings_settings_ExecutionUrlTemplate = null;
            if (cmdletContext.Settings_ExecutionUrlTemplate != null)
            {
                requestSettings_settings_ExecutionUrlTemplate = cmdletContext.Settings_ExecutionUrlTemplate;
            }
            if (requestSettings_settings_ExecutionUrlTemplate != null)
            {
                request.Settings.ExecutionUrlTemplate = requestSettings_settings_ExecutionUrlTemplate;
                requestSettingsIsNull = false;
            }
            System.String requestSettings_settings_RevisionUrlTemplate = null;
            if (cmdletContext.Settings_RevisionUrlTemplate != null)
            {
                requestSettings_settings_RevisionUrlTemplate = cmdletContext.Settings_RevisionUrlTemplate;
            }
            if (requestSettings_settings_RevisionUrlTemplate != null)
            {
                request.Settings.RevisionUrlTemplate = requestSettings_settings_RevisionUrlTemplate;
                requestSettingsIsNull = false;
            }
            System.String requestSettings_settings_ThirdPartyConfigurationUrl = null;
            if (cmdletContext.Settings_ThirdPartyConfigurationUrl != null)
            {
                requestSettings_settings_ThirdPartyConfigurationUrl = cmdletContext.Settings_ThirdPartyConfigurationUrl;
            }
            if (requestSettings_settings_ThirdPartyConfigurationUrl != null)
            {
                request.Settings.ThirdPartyConfigurationUrl = requestSettings_settings_ThirdPartyConfigurationUrl;
                requestSettingsIsNull = false;
            }
             // determine if request.Settings should be set to null
            if (requestSettingsIsNull)
            {
                request.Settings = null;
            }
            if (cmdletContext.Version != null)
            {
                request.Version = cmdletContext.Version;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ActionType;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        private Amazon.CodePipeline.Model.CreateCustomActionTypeResponse CallAWSServiceOperation(IAmazonCodePipeline client, Amazon.CodePipeline.Model.CreateCustomActionTypeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodePipeline", "CreateCustomActionType");
            #if DESKTOP
            return client.CreateCustomActionType(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.CreateCustomActionTypeAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public Amazon.CodePipeline.ActionCategory Category { get; set; }
            public List<Amazon.CodePipeline.Model.ActionConfigurationProperty> ConfigurationProperties { get; set; }
            public System.Int32? InputArtifactDetails_MaximumCount { get; set; }
            public System.Int32? InputArtifactDetails_MinimumCount { get; set; }
            public System.Int32? OutputArtifactDetails_MaximumCount { get; set; }
            public System.Int32? OutputArtifactDetails_MinimumCount { get; set; }
            public System.String Provider { get; set; }
            public System.String Settings_EntityUrlTemplate { get; set; }
            public System.String Settings_ExecutionUrlTemplate { get; set; }
            public System.String Settings_RevisionUrlTemplate { get; set; }
            public System.String Settings_ThirdPartyConfigurationUrl { get; set; }
            public System.String Version { get; set; }
        }
        
    }
}
