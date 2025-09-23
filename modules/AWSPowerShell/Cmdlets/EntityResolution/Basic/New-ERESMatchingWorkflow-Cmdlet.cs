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
using Amazon.EntityResolution;
using Amazon.EntityResolution.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.ERES
{
    /// <summary>
    /// Creates a matching workflow that defines the configuration for a data processing job.
    /// The workflow name must be unique. To modify an existing workflow, use <c>UpdateMatchingWorkflow</c>.
    /// 
    /// 
    ///  <important><para>
    /// For workflows where <c>resolutionType</c> is <c>ML_MATCHING</c> or <c>PROVIDER</c>,
    /// incremental processing is not supported. 
    /// </para></important>
    /// </summary>
    [Cmdlet("New", "ERESMatchingWorkflow", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EntityResolution.Model.CreateMatchingWorkflowResponse")]
    [AWSCmdlet("Calls the AWS EntityResolution CreateMatchingWorkflow API operation.", Operation = new[] {"CreateMatchingWorkflow"}, SelectReturnType = typeof(Amazon.EntityResolution.Model.CreateMatchingWorkflowResponse))]
    [AWSCmdletOutput("Amazon.EntityResolution.Model.CreateMatchingWorkflowResponse",
        "This cmdlet returns an Amazon.EntityResolution.Model.CreateMatchingWorkflowResponse object containing multiple properties."
    )]
    public partial class NewERESMatchingWorkflowCmdlet : AmazonEntityResolutionClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter RuleBasedProperties_AttributeMatchingModel
        /// <summary>
        /// <para>
        /// <para>The comparison type. You can choose <c>ONE_TO_ONE</c> or <c>MANY_TO_MANY</c> as the
        /// <c>attributeMatchingModel</c>. </para><para>If you choose <c>ONE_TO_ONE</c>, the system can only match attributes if the sub-types
        /// are an exact match. For example, for the <c>Email</c> attribute type, the system will
        /// only consider it a match if the value of the <c>Email</c> field of Profile A matches
        /// the value of the <c>Email</c> field of Profile B.</para><para>If you choose <c>MANY_TO_MANY</c>, the system can match attributes across the sub-types
        /// of an attribute type. For example, if the value of the <c>Email</c> field of Profile
        /// A and the value of <c>BusinessEmail</c> field of Profile B matches, the two profiles
        /// are matched on the <c>Email</c> attribute type. </para>
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
        /// <para>The type of incremental run. The only valid value is <c>IMMEDIATE</c>. This appears
        /// as "Automatic" in the console.</para><important><para>For workflows where <c>resolutionType</c> is <c>ML_MATCHING</c> or <c>PROVIDER</c>,
        /// incremental processing is not supported. </para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EntityResolution.IncrementalRunType")]
        public Amazon.EntityResolution.IncrementalRunType IncrementalRunConfig_IncrementalRunType { get; set; }
        #endregion
        
        #region Parameter InputSourceConfig
        /// <summary>
        /// <para>
        /// <para>A list of <c>InputSource</c> objects, which have the fields <c>InputSourceARN</c>
        /// and <c>SchemaName</c>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        
        #region Parameter IntermediateSourceConfiguration_IntermediateS3Path
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 location (bucket and prefix). For example: <c>s3://provider_bucket/DOC-EXAMPLE-BUCKET</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResolutionTechniques_ProviderProperties_IntermediateSourceConfiguration_IntermediateS3Path")]
        public System.String IntermediateSourceConfiguration_IntermediateS3Path { get; set; }
        #endregion
        
        #region Parameter RuleBasedProperties_MatchPurpose
        /// <summary>
        /// <para>
        /// <para> An indicator of whether to generate IDs and index the data or not.</para><para>If you choose <c>IDENTIFIER_GENERATION</c>, the process generates IDs and indexes
        /// the data.</para><para>If you choose <c>INDEXING</c>, the process indexes the data without generating IDs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResolutionTechniques_RuleBasedProperties_MatchPurpose")]
        [AWSConstantClassSource("Amazon.EntityResolution.MatchPurpose")]
        public Amazon.EntityResolution.MatchPurpose RuleBasedProperties_MatchPurpose { get; set; }
        #endregion
        
        #region Parameter OutputSourceConfig
        /// <summary>
        /// <para>
        /// <para>A list of <c>OutputSource</c> objects, each of which contains fields <c>outputS3Path</c>,
        /// <c>applyNormalization</c>, <c>KMSArn</c>, and <c>output</c>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        
        #region Parameter ProviderProperties_ProviderConfiguration
        /// <summary>
        /// <para>
        /// <para>The required configuration fields to use with the provider service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResolutionTechniques_ProviderProperties_ProviderConfiguration")]
        public System.Management.Automation.PSObject ProviderProperties_ProviderConfiguration { get; set; }
        #endregion
        
        #region Parameter ProviderProperties_ProviderServiceArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the provider service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResolutionTechniques_ProviderProperties_ProviderServiceArn")]
        public System.String ProviderProperties_ProviderServiceArn { get; set; }
        #endregion
        
        #region Parameter ResolutionTechniques_ResolutionType
        /// <summary>
        /// <para>
        /// <para>The type of matching workflow to create. Specify one of the following types: </para><ul><li><para><c>RULE_MATCHING</c>: Match records using configurable rule-based criteria </para></li><li><para><c>ML_MATCHING</c>: Match records using machine learning models </para></li><li><para><c>PROVIDER</c>: Match records using a third-party matching provider</para></li></ul>
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
        /// <para>A list of <c>Rule</c> objects, each of which have fields <c>RuleName</c> and <c>MatchingKeys</c>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResolutionTechniques_RuleBasedProperties_Rules")]
        public Amazon.EntityResolution.Model.Rule[] RuleBasedProperties_Rule { get; set; }
        #endregion
        
        #region Parameter RuleConditionProperties_Rule
        /// <summary>
        /// <para>
        /// <para> A list of rule objects, each of which have fields <c>ruleName</c> and <c>condition</c>.
        /// </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResolutionTechniques_RuleConditionProperties_Rules")]
        public Amazon.EntityResolution.Model.RuleCondition[] RuleConditionProperties_Rule { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags used to organize, track, or control access for this resource.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter WorkflowName
        /// <summary>
        /// <para>
        /// <para>The name of the workflow. There can't be multiple <c>MatchingWorkflows</c> with the
        /// same name.</para>
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EntityResolution.Model.CreateMatchingWorkflowResponse).
        /// Specifying the name of a property of type Amazon.EntityResolution.Model.CreateMatchingWorkflowResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ERESMatchingWorkflow (CreateMatchingWorkflow)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EntityResolution.Model.CreateMatchingWorkflowResponse, NewERESMatchingWorkflowCmdlet>(Select) ??
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
            context.IntermediateSourceConfiguration_IntermediateS3Path = this.IntermediateSourceConfiguration_IntermediateS3Path;
            context.ProviderProperties_ProviderConfiguration = this.ProviderProperties_ProviderConfiguration;
            context.ProviderProperties_ProviderServiceArn = this.ProviderProperties_ProviderServiceArn;
            context.ResolutionTechniques_ResolutionType = this.ResolutionTechniques_ResolutionType;
            #if MODULAR
            if (this.ResolutionTechniques_ResolutionType == null && ParameterWasBound(nameof(this.ResolutionTechniques_ResolutionType)))
            {
                WriteWarning("You are passing $null as a value for parameter ResolutionTechniques_ResolutionType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RuleBasedProperties_AttributeMatchingModel = this.RuleBasedProperties_AttributeMatchingModel;
            context.RuleBasedProperties_MatchPurpose = this.RuleBasedProperties_MatchPurpose;
            if (this.RuleBasedProperties_Rule != null)
            {
                context.RuleBasedProperties_Rule = new List<Amazon.EntityResolution.Model.Rule>(this.RuleBasedProperties_Rule);
            }
            if (this.RuleConditionProperties_Rule != null)
            {
                context.RuleConditionProperties_Rule = new List<Amazon.EntityResolution.Model.RuleCondition>(this.RuleConditionProperties_Rule);
            }
            context.RoleArn = this.RoleArn;
            #if MODULAR
            if (this.RoleArn == null && ParameterWasBound(nameof(this.RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
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
            var request = new Amazon.EntityResolution.Model.CreateMatchingWorkflowRequest();
            
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
            Amazon.EntityResolution.Model.RuleConditionProperties requestResolutionTechniques_resolutionTechniques_RuleConditionProperties = null;
            
             // populate RuleConditionProperties
            var requestResolutionTechniques_resolutionTechniques_RuleConditionPropertiesIsNull = true;
            requestResolutionTechniques_resolutionTechniques_RuleConditionProperties = new Amazon.EntityResolution.Model.RuleConditionProperties();
            List<Amazon.EntityResolution.Model.RuleCondition> requestResolutionTechniques_resolutionTechniques_RuleConditionProperties_ruleConditionProperties_Rule = null;
            if (cmdletContext.RuleConditionProperties_Rule != null)
            {
                requestResolutionTechniques_resolutionTechniques_RuleConditionProperties_ruleConditionProperties_Rule = cmdletContext.RuleConditionProperties_Rule;
            }
            if (requestResolutionTechniques_resolutionTechniques_RuleConditionProperties_ruleConditionProperties_Rule != null)
            {
                requestResolutionTechniques_resolutionTechniques_RuleConditionProperties.Rules = requestResolutionTechniques_resolutionTechniques_RuleConditionProperties_ruleConditionProperties_Rule;
                requestResolutionTechniques_resolutionTechniques_RuleConditionPropertiesIsNull = false;
            }
             // determine if requestResolutionTechniques_resolutionTechniques_RuleConditionProperties should be set to null
            if (requestResolutionTechniques_resolutionTechniques_RuleConditionPropertiesIsNull)
            {
                requestResolutionTechniques_resolutionTechniques_RuleConditionProperties = null;
            }
            if (requestResolutionTechniques_resolutionTechniques_RuleConditionProperties != null)
            {
                request.ResolutionTechniques.RuleConditionProperties = requestResolutionTechniques_resolutionTechniques_RuleConditionProperties;
                requestResolutionTechniquesIsNull = false;
            }
            Amazon.EntityResolution.Model.ProviderProperties requestResolutionTechniques_resolutionTechniques_ProviderProperties = null;
            
             // populate ProviderProperties
            var requestResolutionTechniques_resolutionTechniques_ProviderPropertiesIsNull = true;
            requestResolutionTechniques_resolutionTechniques_ProviderProperties = new Amazon.EntityResolution.Model.ProviderProperties();
            Amazon.Runtime.Documents.Document? requestResolutionTechniques_resolutionTechniques_ProviderProperties_providerProperties_ProviderConfiguration = null;
            if (cmdletContext.ProviderProperties_ProviderConfiguration != null)
            {
                requestResolutionTechniques_resolutionTechniques_ProviderProperties_providerProperties_ProviderConfiguration = Amazon.PowerShell.Common.DocumentHelper.ToDocument(cmdletContext.ProviderProperties_ProviderConfiguration);
            }
            if (requestResolutionTechniques_resolutionTechniques_ProviderProperties_providerProperties_ProviderConfiguration != null)
            {
                requestResolutionTechniques_resolutionTechniques_ProviderProperties.ProviderConfiguration = requestResolutionTechniques_resolutionTechniques_ProviderProperties_providerProperties_ProviderConfiguration.Value;
                requestResolutionTechniques_resolutionTechniques_ProviderPropertiesIsNull = false;
            }
            System.String requestResolutionTechniques_resolutionTechniques_ProviderProperties_providerProperties_ProviderServiceArn = null;
            if (cmdletContext.ProviderProperties_ProviderServiceArn != null)
            {
                requestResolutionTechniques_resolutionTechniques_ProviderProperties_providerProperties_ProviderServiceArn = cmdletContext.ProviderProperties_ProviderServiceArn;
            }
            if (requestResolutionTechniques_resolutionTechniques_ProviderProperties_providerProperties_ProviderServiceArn != null)
            {
                requestResolutionTechniques_resolutionTechniques_ProviderProperties.ProviderServiceArn = requestResolutionTechniques_resolutionTechniques_ProviderProperties_providerProperties_ProviderServiceArn;
                requestResolutionTechniques_resolutionTechniques_ProviderPropertiesIsNull = false;
            }
            Amazon.EntityResolution.Model.IntermediateSourceConfiguration requestResolutionTechniques_resolutionTechniques_ProviderProperties_resolutionTechniques_ProviderProperties_IntermediateSourceConfiguration = null;
            
             // populate IntermediateSourceConfiguration
            var requestResolutionTechniques_resolutionTechniques_ProviderProperties_resolutionTechniques_ProviderProperties_IntermediateSourceConfigurationIsNull = true;
            requestResolutionTechniques_resolutionTechniques_ProviderProperties_resolutionTechniques_ProviderProperties_IntermediateSourceConfiguration = new Amazon.EntityResolution.Model.IntermediateSourceConfiguration();
            System.String requestResolutionTechniques_resolutionTechniques_ProviderProperties_resolutionTechniques_ProviderProperties_IntermediateSourceConfiguration_intermediateSourceConfiguration_IntermediateS3Path = null;
            if (cmdletContext.IntermediateSourceConfiguration_IntermediateS3Path != null)
            {
                requestResolutionTechniques_resolutionTechniques_ProviderProperties_resolutionTechniques_ProviderProperties_IntermediateSourceConfiguration_intermediateSourceConfiguration_IntermediateS3Path = cmdletContext.IntermediateSourceConfiguration_IntermediateS3Path;
            }
            if (requestResolutionTechniques_resolutionTechniques_ProviderProperties_resolutionTechniques_ProviderProperties_IntermediateSourceConfiguration_intermediateSourceConfiguration_IntermediateS3Path != null)
            {
                requestResolutionTechniques_resolutionTechniques_ProviderProperties_resolutionTechniques_ProviderProperties_IntermediateSourceConfiguration.IntermediateS3Path = requestResolutionTechniques_resolutionTechniques_ProviderProperties_resolutionTechniques_ProviderProperties_IntermediateSourceConfiguration_intermediateSourceConfiguration_IntermediateS3Path;
                requestResolutionTechniques_resolutionTechniques_ProviderProperties_resolutionTechniques_ProviderProperties_IntermediateSourceConfigurationIsNull = false;
            }
             // determine if requestResolutionTechniques_resolutionTechniques_ProviderProperties_resolutionTechniques_ProviderProperties_IntermediateSourceConfiguration should be set to null
            if (requestResolutionTechniques_resolutionTechniques_ProviderProperties_resolutionTechniques_ProviderProperties_IntermediateSourceConfigurationIsNull)
            {
                requestResolutionTechniques_resolutionTechniques_ProviderProperties_resolutionTechniques_ProviderProperties_IntermediateSourceConfiguration = null;
            }
            if (requestResolutionTechniques_resolutionTechniques_ProviderProperties_resolutionTechniques_ProviderProperties_IntermediateSourceConfiguration != null)
            {
                requestResolutionTechniques_resolutionTechniques_ProviderProperties.IntermediateSourceConfiguration = requestResolutionTechniques_resolutionTechniques_ProviderProperties_resolutionTechniques_ProviderProperties_IntermediateSourceConfiguration;
                requestResolutionTechniques_resolutionTechniques_ProviderPropertiesIsNull = false;
            }
             // determine if requestResolutionTechniques_resolutionTechniques_ProviderProperties should be set to null
            if (requestResolutionTechniques_resolutionTechniques_ProviderPropertiesIsNull)
            {
                requestResolutionTechniques_resolutionTechniques_ProviderProperties = null;
            }
            if (requestResolutionTechniques_resolutionTechniques_ProviderProperties != null)
            {
                request.ResolutionTechniques.ProviderProperties = requestResolutionTechniques_resolutionTechniques_ProviderProperties;
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
            Amazon.EntityResolution.MatchPurpose requestResolutionTechniques_resolutionTechniques_RuleBasedProperties_ruleBasedProperties_MatchPurpose = null;
            if (cmdletContext.RuleBasedProperties_MatchPurpose != null)
            {
                requestResolutionTechniques_resolutionTechniques_RuleBasedProperties_ruleBasedProperties_MatchPurpose = cmdletContext.RuleBasedProperties_MatchPurpose;
            }
            if (requestResolutionTechniques_resolutionTechniques_RuleBasedProperties_ruleBasedProperties_MatchPurpose != null)
            {
                requestResolutionTechniques_resolutionTechniques_RuleBasedProperties.MatchPurpose = requestResolutionTechniques_resolutionTechniques_RuleBasedProperties_ruleBasedProperties_MatchPurpose;
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
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.EntityResolution.Model.CreateMatchingWorkflowResponse CallAWSServiceOperation(IAmazonEntityResolution client, Amazon.EntityResolution.Model.CreateMatchingWorkflowRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS EntityResolution", "CreateMatchingWorkflow");
            try
            {
                return client.CreateMatchingWorkflowAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String IntermediateSourceConfiguration_IntermediateS3Path { get; set; }
            public System.Management.Automation.PSObject ProviderProperties_ProviderConfiguration { get; set; }
            public System.String ProviderProperties_ProviderServiceArn { get; set; }
            public Amazon.EntityResolution.ResolutionType ResolutionTechniques_ResolutionType { get; set; }
            public Amazon.EntityResolution.AttributeMatchingModel RuleBasedProperties_AttributeMatchingModel { get; set; }
            public Amazon.EntityResolution.MatchPurpose RuleBasedProperties_MatchPurpose { get; set; }
            public List<Amazon.EntityResolution.Model.Rule> RuleBasedProperties_Rule { get; set; }
            public List<Amazon.EntityResolution.Model.RuleCondition> RuleConditionProperties_Rule { get; set; }
            public System.String RoleArn { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.String WorkflowName { get; set; }
            public System.Func<Amazon.EntityResolution.Model.CreateMatchingWorkflowResponse, NewERESMatchingWorkflowCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
