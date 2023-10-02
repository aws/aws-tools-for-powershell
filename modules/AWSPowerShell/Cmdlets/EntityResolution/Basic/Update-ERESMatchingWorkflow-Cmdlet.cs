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
using Amazon.EntityResolution;
using Amazon.EntityResolution.Model;

namespace Amazon.PowerShell.Cmdlets.ERES
{
    /// <summary>
    /// Updates an existing <code>MatchingWorkflow</code>. This method is identical to <code>CreateMatchingWorkflow</code>,
    /// except it uses an HTTP <code>PUT</code> request instead of a <code>POST</code> request,
    /// and the <code>MatchingWorkflow</code> must already exist for the method to succeed.
    /// </summary>
    [Cmdlet("Update", "ERESMatchingWorkflow", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EntityResolution.Model.UpdateMatchingWorkflowResponse")]
    [AWSCmdlet("Calls the AWS EntityResolution UpdateMatchingWorkflow API operation.", Operation = new[] {"UpdateMatchingWorkflow"}, SelectReturnType = typeof(Amazon.EntityResolution.Model.UpdateMatchingWorkflowResponse))]
    [AWSCmdletOutput("Amazon.EntityResolution.Model.UpdateMatchingWorkflowResponse",
        "This cmdlet returns an Amazon.EntityResolution.Model.UpdateMatchingWorkflowResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateERESMatchingWorkflowCmdlet : AmazonEntityResolutionClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter RuleBasedProperties_AttributeMatchingModel
        /// <summary>
        /// <para>
        /// <para>The comparison type. You can either choose <code>ONE_TO_ONE</code> or <code>MANY_TO_MANY</code>
        /// as the AttributeMatchingModel. When choosing <code>MANY_TO_MANY</code>, the system
        /// can match attributes across the sub-types of an attribute type. For example, if the
        /// value of the <code>Email</code> field of Profile A and the value of <code>BusinessEmail</code>
        /// field of Profile B matches, the two profiles are matched on the <code>Email</code>
        /// type. When choosing <code>ONE_TO_ONE</code> ,the system can only match if the sub-types
        /// are exact matches. For example, only when the value of the <code>Email</code> field
        /// of Profile A and the value of the <code>Email</code> field of Profile B matches, the
        /// two profiles are matched on the <code>Email</code> type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResolutionTechniques_RuleBasedProperties_AttributeMatchingModel")]
        [AWSConstantClassSource("Amazon.EntityResolution.AttributeMatchingModel")]
        public Amazon.EntityResolution.AttributeMatchingModel RuleBasedProperties_AttributeMatchingModel { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the workflow.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter IncrementalRunConfig_IncrementalRunType
        /// <summary>
        /// <para>
        /// <para>The type of incremental run. It takes only one value: <code>IMMEDIATE</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EntityResolution.IncrementalRunType")]
        public Amazon.EntityResolution.IncrementalRunType IncrementalRunConfig_IncrementalRunType { get; set; }
        #endregion
        
        #region Parameter InputSourceConfig
        /// <summary>
        /// <para>
        /// <para>A list of <code>InputSource</code> objects, which have the fields <code>InputSourceARN</code>
        /// and <code>SchemaName</code>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public Amazon.EntityResolution.Model.InputSource[] InputSourceConfig { get; set; }
        #endregion
        
        #region Parameter OutputSourceConfig
        /// <summary>
        /// <para>
        /// <para>A list of <code>OutputSource</code> objects, each of which contains fields <code>OutputS3Path</code>,
        /// <code>ApplyNormalization</code>, and <code>Output</code>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public Amazon.EntityResolution.Model.OutputSource[] OutputSourceConfig { get; set; }
        #endregion
        
        #region Parameter ResolutionTechniques_ResolutionType
        /// <summary>
        /// <para>
        /// <para>The type of matching. There are two types of matching: <code>RULE_MATCHING</code>
        /// and <code>ML_MATCHING</code>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.EntityResolution.ResolutionType")]
        public Amazon.EntityResolution.ResolutionType ResolutionTechniques_ResolutionType { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role. Entity Resolution assumes this role
        /// to create resources on your behalf as part of workflow execution.</para>
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
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter RuleBasedProperties_Rule
        /// <summary>
        /// <para>
        /// <para>A list of <code>Rule</code> objects, each of which have fields <code>RuleName</code>
        /// and <code>MatchingKeys</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResolutionTechniques_RuleBasedProperties_Rules")]
        public Amazon.EntityResolution.Model.Rule[] RuleBasedProperties_Rule { get; set; }
        #endregion
        
        #region Parameter WorkflowName
        /// <summary>
        /// <para>
        /// <para>The name of the workflow to be retrieved.</para>
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
        public System.String WorkflowName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EntityResolution.Model.UpdateMatchingWorkflowResponse).
        /// Specifying the name of a property of type Amazon.EntityResolution.Model.UpdateMatchingWorkflowResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-ERESMatchingWorkflow (UpdateMatchingWorkflow)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EntityResolution.Model.UpdateMatchingWorkflowResponse, UpdateERESMatchingWorkflowCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Description = this.Description;
            context.IncrementalRunConfig_IncrementalRunType = this.IncrementalRunConfig_IncrementalRunType;
            if (this.InputSourceConfig != null)
            {
                context.InputSourceConfig = new List<Amazon.EntityResolution.Model.InputSource>(this.InputSourceConfig);
            }
            #if MODULAR
            if (this.InputSourceConfig == null && ParameterWasBound(nameof(this.InputSourceConfig)))
            {
                WriteWarning("You are passing $null as a value for parameter InputSourceConfig which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.OutputSourceConfig != null)
            {
                context.OutputSourceConfig = new List<Amazon.EntityResolution.Model.OutputSource>(this.OutputSourceConfig);
            }
            #if MODULAR
            if (this.OutputSourceConfig == null && ParameterWasBound(nameof(this.OutputSourceConfig)))
            {
                WriteWarning("You are passing $null as a value for parameter OutputSourceConfig which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ResolutionTechniques_ResolutionType = this.ResolutionTechniques_ResolutionType;
            #if MODULAR
            if (this.ResolutionTechniques_ResolutionType == null && ParameterWasBound(nameof(this.ResolutionTechniques_ResolutionType)))
            {
                WriteWarning("You are passing $null as a value for parameter ResolutionTechniques_ResolutionType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RuleBasedProperties_AttributeMatchingModel = this.RuleBasedProperties_AttributeMatchingModel;
            if (this.RuleBasedProperties_Rule != null)
            {
                context.RuleBasedProperties_Rule = new List<Amazon.EntityResolution.Model.Rule>(this.RuleBasedProperties_Rule);
            }
            context.RoleArn = this.RoleArn;
            #if MODULAR
            if (this.RoleArn == null && ParameterWasBound(nameof(this.RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.WorkflowName = this.WorkflowName;
            #if MODULAR
            if (this.WorkflowName == null && ParameterWasBound(nameof(this.WorkflowName)))
            {
                WriteWarning("You are passing $null as a value for parameter WorkflowName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EntityResolution.Model.UpdateMatchingWorkflowRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            
             // populate IncrementalRunConfig
            var requestIncrementalRunConfigIsNull = true;
            request.IncrementalRunConfig = new Amazon.EntityResolution.Model.IncrementalRunConfig();
            Amazon.EntityResolution.IncrementalRunType requestIncrementalRunConfig_incrementalRunConfig_IncrementalRunType = null;
            if (cmdletContext.IncrementalRunConfig_IncrementalRunType != null)
            {
                requestIncrementalRunConfig_incrementalRunConfig_IncrementalRunType = cmdletContext.IncrementalRunConfig_IncrementalRunType;
            }
            if (requestIncrementalRunConfig_incrementalRunConfig_IncrementalRunType != null)
            {
                request.IncrementalRunConfig.IncrementalRunType = requestIncrementalRunConfig_incrementalRunConfig_IncrementalRunType;
                requestIncrementalRunConfigIsNull = false;
            }
             // determine if request.IncrementalRunConfig should be set to null
            if (requestIncrementalRunConfigIsNull)
            {
                request.IncrementalRunConfig = null;
            }
            if (cmdletContext.InputSourceConfig != null)
            {
                request.InputSourceConfig = cmdletContext.InputSourceConfig;
            }
            if (cmdletContext.OutputSourceConfig != null)
            {
                request.OutputSourceConfig = cmdletContext.OutputSourceConfig;
            }
            
             // populate ResolutionTechniques
            var requestResolutionTechniquesIsNull = true;
            request.ResolutionTechniques = new Amazon.EntityResolution.Model.ResolutionTechniques();
            Amazon.EntityResolution.ResolutionType requestResolutionTechniques_resolutionTechniques_ResolutionType = null;
            if (cmdletContext.ResolutionTechniques_ResolutionType != null)
            {
                requestResolutionTechniques_resolutionTechniques_ResolutionType = cmdletContext.ResolutionTechniques_ResolutionType;
            }
            if (requestResolutionTechniques_resolutionTechniques_ResolutionType != null)
            {
                request.ResolutionTechniques.ResolutionType = requestResolutionTechniques_resolutionTechniques_ResolutionType;
                requestResolutionTechniquesIsNull = false;
            }
            Amazon.EntityResolution.Model.RuleBasedProperties requestResolutionTechniques_resolutionTechniques_RuleBasedProperties = null;
            
             // populate RuleBasedProperties
            var requestResolutionTechniques_resolutionTechniques_RuleBasedPropertiesIsNull = true;
            requestResolutionTechniques_resolutionTechniques_RuleBasedProperties = new Amazon.EntityResolution.Model.RuleBasedProperties();
            Amazon.EntityResolution.AttributeMatchingModel requestResolutionTechniques_resolutionTechniques_RuleBasedProperties_ruleBasedProperties_AttributeMatchingModel = null;
            if (cmdletContext.RuleBasedProperties_AttributeMatchingModel != null)
            {
                requestResolutionTechniques_resolutionTechniques_RuleBasedProperties_ruleBasedProperties_AttributeMatchingModel = cmdletContext.RuleBasedProperties_AttributeMatchingModel;
            }
            if (requestResolutionTechniques_resolutionTechniques_RuleBasedProperties_ruleBasedProperties_AttributeMatchingModel != null)
            {
                requestResolutionTechniques_resolutionTechniques_RuleBasedProperties.AttributeMatchingModel = requestResolutionTechniques_resolutionTechniques_RuleBasedProperties_ruleBasedProperties_AttributeMatchingModel;
                requestResolutionTechniques_resolutionTechniques_RuleBasedPropertiesIsNull = false;
            }
            List<Amazon.EntityResolution.Model.Rule> requestResolutionTechniques_resolutionTechniques_RuleBasedProperties_ruleBasedProperties_Rule = null;
            if (cmdletContext.RuleBasedProperties_Rule != null)
            {
                requestResolutionTechniques_resolutionTechniques_RuleBasedProperties_ruleBasedProperties_Rule = cmdletContext.RuleBasedProperties_Rule;
            }
            if (requestResolutionTechniques_resolutionTechniques_RuleBasedProperties_ruleBasedProperties_Rule != null)
            {
                requestResolutionTechniques_resolutionTechniques_RuleBasedProperties.Rules = requestResolutionTechniques_resolutionTechniques_RuleBasedProperties_ruleBasedProperties_Rule;
                requestResolutionTechniques_resolutionTechniques_RuleBasedPropertiesIsNull = false;
            }
             // determine if requestResolutionTechniques_resolutionTechniques_RuleBasedProperties should be set to null
            if (requestResolutionTechniques_resolutionTechniques_RuleBasedPropertiesIsNull)
            {
                requestResolutionTechniques_resolutionTechniques_RuleBasedProperties = null;
            }
            if (requestResolutionTechniques_resolutionTechniques_RuleBasedProperties != null)
            {
                request.ResolutionTechniques.RuleBasedProperties = requestResolutionTechniques_resolutionTechniques_RuleBasedProperties;
                requestResolutionTechniquesIsNull = false;
            }
             // determine if request.ResolutionTechniques should be set to null
            if (requestResolutionTechniquesIsNull)
            {
                request.ResolutionTechniques = null;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            if (cmdletContext.WorkflowName != null)
            {
                request.WorkflowName = cmdletContext.WorkflowName;
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
        
        private Amazon.EntityResolution.Model.UpdateMatchingWorkflowResponse CallAWSServiceOperation(IAmazonEntityResolution client, Amazon.EntityResolution.Model.UpdateMatchingWorkflowRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS EntityResolution", "UpdateMatchingWorkflow");
            try
            {
                #if DESKTOP
                return client.UpdateMatchingWorkflow(request);
                #elif CORECLR
                return client.UpdateMatchingWorkflowAsync(request).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public Amazon.EntityResolution.IncrementalRunType IncrementalRunConfig_IncrementalRunType { get; set; }
            public List<Amazon.EntityResolution.Model.InputSource> InputSourceConfig { get; set; }
            public List<Amazon.EntityResolution.Model.OutputSource> OutputSourceConfig { get; set; }
            public Amazon.EntityResolution.ResolutionType ResolutionTechniques_ResolutionType { get; set; }
            public Amazon.EntityResolution.AttributeMatchingModel RuleBasedProperties_AttributeMatchingModel { get; set; }
            public List<Amazon.EntityResolution.Model.Rule> RuleBasedProperties_Rule { get; set; }
            public System.String RoleArn { get; set; }
            public System.String WorkflowName { get; set; }
            public System.Func<Amazon.EntityResolution.Model.UpdateMatchingWorkflowResponse, UpdateERESMatchingWorkflowCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
