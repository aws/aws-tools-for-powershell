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
using Amazon.AmplifyUIBuilder;
using Amazon.AmplifyUIBuilder.Model;

namespace Amazon.PowerShell.Cmdlets.AMPUI
{
    /// <summary>
    /// Starts a code generation job for a specified Amplify app and backend environment.
    /// </summary>
    [Cmdlet("New", "AMPUICodegenJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AmplifyUIBuilder.Model.CodegenJob")]
    [AWSCmdlet("Calls the AWS Amplify UI Builder StartCodegenJob API operation.", Operation = new[] {"StartCodegenJob"}, SelectReturnType = typeof(Amazon.AmplifyUIBuilder.Model.StartCodegenJobResponse))]
    [AWSCmdletOutput("Amazon.AmplifyUIBuilder.Model.CodegenJob or Amazon.AmplifyUIBuilder.Model.StartCodegenJobResponse",
        "This cmdlet returns an Amazon.AmplifyUIBuilder.Model.CodegenJob object.",
        "The service call response (type Amazon.AmplifyUIBuilder.Model.StartCodegenJobResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewAMPUICodegenJobCmdlet : AmazonAmplifyUIBuilderClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AppId
        /// <summary>
        /// <para>
        /// <para>The unique ID for the Amplify app.</para>
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
        public System.String AppId { get; set; }
        #endregion
        
        #region Parameter CodegenJobToCreate_AutoGenerateForm
        /// <summary>
        /// <para>
        /// <para>Specifies whether to autogenerate forms in the code generation job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CodegenJobToCreate_AutoGenerateForms")]
        public System.Boolean? CodegenJobToCreate_AutoGenerateForm { get; set; }
        #endregion
        
        #region Parameter GenericDataSchema_DataSourceType
        /// <summary>
        /// <para>
        /// <para>The type of the data source for the schema. Currently, the only valid value is an
        /// Amplify <c>DataStore</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CodegenJobToCreate_GenericDataSchema_DataSourceType")]
        [AWSConstantClassSource("Amazon.AmplifyUIBuilder.CodegenJobGenericDataSourceType")]
        public Amazon.AmplifyUIBuilder.CodegenJobGenericDataSourceType GenericDataSchema_DataSourceType { get; set; }
        #endregion
        
        #region Parameter ApiConfiguration_DataStoreConfig
        /// <summary>
        /// <para>
        /// <para>The configuration for an application using DataStore APIs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CodegenJobToCreate_RenderConfig_React_ApiConfiguration_DataStoreConfig")]
        public Amazon.AmplifyUIBuilder.Model.DataStoreRenderConfig ApiConfiguration_DataStoreConfig { get; set; }
        #endregion
        
        #region Parameter React_Dependency
        /// <summary>
        /// <para>
        /// <para>Lists the dependency packages that may be required for the project code to run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CodegenJobToCreate_RenderConfig_React_Dependencies")]
        public System.Collections.Hashtable React_Dependency { get; set; }
        #endregion
        
        #region Parameter GenericDataSchema_Enum
        /// <summary>
        /// <para>
        /// <para>The name of a <c>CodegenGenericDataEnum</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CodegenJobToCreate_GenericDataSchema_Enums")]
        public System.Collections.Hashtable GenericDataSchema_Enum { get; set; }
        #endregion
        
        #region Parameter EnvironmentName
        /// <summary>
        /// <para>
        /// <para>The name of the backend environment that is a part of the Amplify app.</para>
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
        public System.String EnvironmentName { get; set; }
        #endregion
        
        #region Parameter GraphQLConfig_FragmentsFilePath
        /// <summary>
        /// <para>
        /// <para>The path to the GraphQL fragments file, relative to the component output directory.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CodegenJobToCreate_RenderConfig_React_ApiConfiguration_GraphQLConfig_FragmentsFilePath")]
        public System.String GraphQLConfig_FragmentsFilePath { get; set; }
        #endregion
        
        #region Parameter React_InlineSourceMap
        /// <summary>
        /// <para>
        /// <para>Specifies whether the code generation job should render inline source maps.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CodegenJobToCreate_RenderConfig_React_InlineSourceMap")]
        public System.Boolean? React_InlineSourceMap { get; set; }
        #endregion
        
        #region Parameter Features_IsNonModelSupported
        /// <summary>
        /// <para>
        /// <para>Specifies whether a code generation job supports non models.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CodegenJobToCreate_Features_IsNonModelSupported")]
        public System.Boolean? Features_IsNonModelSupported { get; set; }
        #endregion
        
        #region Parameter Features_IsRelationshipSupported
        /// <summary>
        /// <para>
        /// <para>Specifes whether a code generation job supports data relationships.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CodegenJobToCreate_Features_IsRelationshipSupported")]
        public System.Boolean? Features_IsRelationshipSupported { get; set; }
        #endregion
        
        #region Parameter GenericDataSchema_Model
        /// <summary>
        /// <para>
        /// <para>The name of a <c>CodegenGenericDataModel</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CodegenJobToCreate_GenericDataSchema_Models")]
        public System.Collections.Hashtable GenericDataSchema_Model { get; set; }
        #endregion
        
        #region Parameter React_Module
        /// <summary>
        /// <para>
        /// <para>The JavaScript module type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CodegenJobToCreate_RenderConfig_React_Module")]
        [AWSConstantClassSource("Amazon.AmplifyUIBuilder.JSModule")]
        public Amazon.AmplifyUIBuilder.JSModule React_Module { get; set; }
        #endregion
        
        #region Parameter GraphQLConfig_MutationsFilePath
        /// <summary>
        /// <para>
        /// <para>The path to the GraphQL mutations file, relative to the component output directory.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CodegenJobToCreate_RenderConfig_React_ApiConfiguration_GraphQLConfig_MutationsFilePath")]
        public System.String GraphQLConfig_MutationsFilePath { get; set; }
        #endregion
        
        #region Parameter ApiConfiguration_NoApiConfig
        /// <summary>
        /// <para>
        /// <para>The configuration for an application with no API being used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CodegenJobToCreate_RenderConfig_React_ApiConfiguration_NoApiConfig")]
        public Amazon.AmplifyUIBuilder.Model.NoApiRenderConfig ApiConfiguration_NoApiConfig { get; set; }
        #endregion
        
        #region Parameter GenericDataSchema_NonModel
        /// <summary>
        /// <para>
        /// <para>The name of a <c>CodegenGenericDataNonModel</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CodegenJobToCreate_GenericDataSchema_NonModels")]
        public System.Collections.Hashtable GenericDataSchema_NonModel { get; set; }
        #endregion
        
        #region Parameter GraphQLConfig_QueriesFilePath
        /// <summary>
        /// <para>
        /// <para>The path to the GraphQL queries file, relative to the component output directory.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CodegenJobToCreate_RenderConfig_React_ApiConfiguration_GraphQLConfig_QueriesFilePath")]
        public System.String GraphQLConfig_QueriesFilePath { get; set; }
        #endregion
        
        #region Parameter React_RenderTypeDeclaration
        /// <summary>
        /// <para>
        /// <para>Specifies whether the code generation job should render type declaration files.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CodegenJobToCreate_RenderConfig_React_RenderTypeDeclarations")]
        public System.Boolean? React_RenderTypeDeclaration { get; set; }
        #endregion
        
        #region Parameter React_Script
        /// <summary>
        /// <para>
        /// <para>The file type to use for a JavaScript project.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CodegenJobToCreate_RenderConfig_React_Script")]
        [AWSConstantClassSource("Amazon.AmplifyUIBuilder.JSScript")]
        public Amazon.AmplifyUIBuilder.JSScript React_Script { get; set; }
        #endregion
        
        #region Parameter GraphQLConfig_SubscriptionsFilePath
        /// <summary>
        /// <para>
        /// <para>The path to the GraphQL subscriptions file, relative to the component output directory.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CodegenJobToCreate_RenderConfig_React_ApiConfiguration_GraphQLConfig_SubscriptionsFilePath")]
        public System.String GraphQLConfig_SubscriptionsFilePath { get; set; }
        #endregion
        
        #region Parameter CodegenJobToCreate_Tag
        /// <summary>
        /// <para>
        /// <para>One or more key-value pairs to use when tagging the code generation job data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CodegenJobToCreate_Tags")]
        public System.Collections.Hashtable CodegenJobToCreate_Tag { get; set; }
        #endregion
        
        #region Parameter React_Target
        /// <summary>
        /// <para>
        /// <para>The ECMAScript specification to use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CodegenJobToCreate_RenderConfig_React_Target")]
        [AWSConstantClassSource("Amazon.AmplifyUIBuilder.JSTarget")]
        public Amazon.AmplifyUIBuilder.JSTarget React_Target { get; set; }
        #endregion
        
        #region Parameter GraphQLConfig_TypesFilePath
        /// <summary>
        /// <para>
        /// <para>The path to the GraphQL types file, relative to the component output directory.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CodegenJobToCreate_RenderConfig_React_ApiConfiguration_GraphQLConfig_TypesFilePath")]
        public System.String GraphQLConfig_TypesFilePath { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>The idempotency token used to ensure that the code generation job request completes
        /// only once.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Entity'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AmplifyUIBuilder.Model.StartCodegenJobResponse).
        /// Specifying the name of a property of type Amazon.AmplifyUIBuilder.Model.StartCodegenJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Entity";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-AMPUICodegenJob (StartCodegenJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AmplifyUIBuilder.Model.StartCodegenJobResponse, NewAMPUICodegenJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AppId = this.AppId;
            #if MODULAR
            if (this.AppId == null && ParameterWasBound(nameof(this.AppId)))
            {
                WriteWarning("You are passing $null as a value for parameter AppId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.CodegenJobToCreate_AutoGenerateForm = this.CodegenJobToCreate_AutoGenerateForm;
            context.Features_IsNonModelSupported = this.Features_IsNonModelSupported;
            context.Features_IsRelationshipSupported = this.Features_IsRelationshipSupported;
            context.GenericDataSchema_DataSourceType = this.GenericDataSchema_DataSourceType;
            if (this.GenericDataSchema_Enum != null)
            {
                context.GenericDataSchema_Enum = new Dictionary<System.String, Amazon.AmplifyUIBuilder.Model.CodegenGenericDataEnum>(StringComparer.Ordinal);
                foreach (var hashKey in this.GenericDataSchema_Enum.Keys)
                {
                    context.GenericDataSchema_Enum.Add((String)hashKey, (Amazon.AmplifyUIBuilder.Model.CodegenGenericDataEnum)(this.GenericDataSchema_Enum[hashKey]));
                }
            }
            if (this.GenericDataSchema_Model != null)
            {
                context.GenericDataSchema_Model = new Dictionary<System.String, Amazon.AmplifyUIBuilder.Model.CodegenGenericDataModel>(StringComparer.Ordinal);
                foreach (var hashKey in this.GenericDataSchema_Model.Keys)
                {
                    context.GenericDataSchema_Model.Add((String)hashKey, (Amazon.AmplifyUIBuilder.Model.CodegenGenericDataModel)(this.GenericDataSchema_Model[hashKey]));
                }
            }
            if (this.GenericDataSchema_NonModel != null)
            {
                context.GenericDataSchema_NonModel = new Dictionary<System.String, Amazon.AmplifyUIBuilder.Model.CodegenGenericDataNonModel>(StringComparer.Ordinal);
                foreach (var hashKey in this.GenericDataSchema_NonModel.Keys)
                {
                    context.GenericDataSchema_NonModel.Add((String)hashKey, (Amazon.AmplifyUIBuilder.Model.CodegenGenericDataNonModel)(this.GenericDataSchema_NonModel[hashKey]));
                }
            }
            context.ApiConfiguration_DataStoreConfig = this.ApiConfiguration_DataStoreConfig;
            context.GraphQLConfig_FragmentsFilePath = this.GraphQLConfig_FragmentsFilePath;
            context.GraphQLConfig_MutationsFilePath = this.GraphQLConfig_MutationsFilePath;
            context.GraphQLConfig_QueriesFilePath = this.GraphQLConfig_QueriesFilePath;
            context.GraphQLConfig_SubscriptionsFilePath = this.GraphQLConfig_SubscriptionsFilePath;
            context.GraphQLConfig_TypesFilePath = this.GraphQLConfig_TypesFilePath;
            context.ApiConfiguration_NoApiConfig = this.ApiConfiguration_NoApiConfig;
            if (this.React_Dependency != null)
            {
                context.React_Dependency = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.React_Dependency.Keys)
                {
                    context.React_Dependency.Add((String)hashKey, (System.String)(this.React_Dependency[hashKey]));
                }
            }
            context.React_InlineSourceMap = this.React_InlineSourceMap;
            context.React_Module = this.React_Module;
            context.React_RenderTypeDeclaration = this.React_RenderTypeDeclaration;
            context.React_Script = this.React_Script;
            context.React_Target = this.React_Target;
            if (this.CodegenJobToCreate_Tag != null)
            {
                context.CodegenJobToCreate_Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.CodegenJobToCreate_Tag.Keys)
                {
                    context.CodegenJobToCreate_Tag.Add((String)hashKey, (System.String)(this.CodegenJobToCreate_Tag[hashKey]));
                }
            }
            context.EnvironmentName = this.EnvironmentName;
            #if MODULAR
            if (this.EnvironmentName == null && ParameterWasBound(nameof(this.EnvironmentName)))
            {
                WriteWarning("You are passing $null as a value for parameter EnvironmentName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.AmplifyUIBuilder.Model.StartCodegenJobRequest();
            
            if (cmdletContext.AppId != null)
            {
                request.AppId = cmdletContext.AppId;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate CodegenJobToCreate
            var requestCodegenJobToCreateIsNull = true;
            request.CodegenJobToCreate = new Amazon.AmplifyUIBuilder.Model.StartCodegenJobData();
            System.Boolean? requestCodegenJobToCreate_codegenJobToCreate_AutoGenerateForm = null;
            if (cmdletContext.CodegenJobToCreate_AutoGenerateForm != null)
            {
                requestCodegenJobToCreate_codegenJobToCreate_AutoGenerateForm = cmdletContext.CodegenJobToCreate_AutoGenerateForm.Value;
            }
            if (requestCodegenJobToCreate_codegenJobToCreate_AutoGenerateForm != null)
            {
                request.CodegenJobToCreate.AutoGenerateForms = requestCodegenJobToCreate_codegenJobToCreate_AutoGenerateForm.Value;
                requestCodegenJobToCreateIsNull = false;
            }
            Dictionary<System.String, System.String> requestCodegenJobToCreate_codegenJobToCreate_Tag = null;
            if (cmdletContext.CodegenJobToCreate_Tag != null)
            {
                requestCodegenJobToCreate_codegenJobToCreate_Tag = cmdletContext.CodegenJobToCreate_Tag;
            }
            if (requestCodegenJobToCreate_codegenJobToCreate_Tag != null)
            {
                request.CodegenJobToCreate.Tags = requestCodegenJobToCreate_codegenJobToCreate_Tag;
                requestCodegenJobToCreateIsNull = false;
            }
            Amazon.AmplifyUIBuilder.Model.CodegenJobRenderConfig requestCodegenJobToCreate_codegenJobToCreate_RenderConfig = null;
            
             // populate RenderConfig
            var requestCodegenJobToCreate_codegenJobToCreate_RenderConfigIsNull = true;
            requestCodegenJobToCreate_codegenJobToCreate_RenderConfig = new Amazon.AmplifyUIBuilder.Model.CodegenJobRenderConfig();
            Amazon.AmplifyUIBuilder.Model.ReactStartCodegenJobData requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React = null;
            
             // populate React
            var requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_ReactIsNull = true;
            requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React = new Amazon.AmplifyUIBuilder.Model.ReactStartCodegenJobData();
            Dictionary<System.String, System.String> requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_react_Dependency = null;
            if (cmdletContext.React_Dependency != null)
            {
                requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_react_Dependency = cmdletContext.React_Dependency;
            }
            if (requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_react_Dependency != null)
            {
                requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React.Dependencies = requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_react_Dependency;
                requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_ReactIsNull = false;
            }
            System.Boolean? requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_react_InlineSourceMap = null;
            if (cmdletContext.React_InlineSourceMap != null)
            {
                requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_react_InlineSourceMap = cmdletContext.React_InlineSourceMap.Value;
            }
            if (requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_react_InlineSourceMap != null)
            {
                requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React.InlineSourceMap = requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_react_InlineSourceMap.Value;
                requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_ReactIsNull = false;
            }
            Amazon.AmplifyUIBuilder.JSModule requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_react_Module = null;
            if (cmdletContext.React_Module != null)
            {
                requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_react_Module = cmdletContext.React_Module;
            }
            if (requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_react_Module != null)
            {
                requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React.Module = requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_react_Module;
                requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_ReactIsNull = false;
            }
            System.Boolean? requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_react_RenderTypeDeclaration = null;
            if (cmdletContext.React_RenderTypeDeclaration != null)
            {
                requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_react_RenderTypeDeclaration = cmdletContext.React_RenderTypeDeclaration.Value;
            }
            if (requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_react_RenderTypeDeclaration != null)
            {
                requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React.RenderTypeDeclarations = requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_react_RenderTypeDeclaration.Value;
                requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_ReactIsNull = false;
            }
            Amazon.AmplifyUIBuilder.JSScript requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_react_Script = null;
            if (cmdletContext.React_Script != null)
            {
                requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_react_Script = cmdletContext.React_Script;
            }
            if (requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_react_Script != null)
            {
                requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React.Script = requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_react_Script;
                requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_ReactIsNull = false;
            }
            Amazon.AmplifyUIBuilder.JSTarget requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_react_Target = null;
            if (cmdletContext.React_Target != null)
            {
                requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_react_Target = cmdletContext.React_Target;
            }
            if (requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_react_Target != null)
            {
                requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React.Target = requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_react_Target;
                requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_ReactIsNull = false;
            }
            Amazon.AmplifyUIBuilder.Model.ApiConfiguration requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_codegenJobToCreate_RenderConfig_React_ApiConfiguration = null;
            
             // populate ApiConfiguration
            var requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_codegenJobToCreate_RenderConfig_React_ApiConfigurationIsNull = true;
            requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_codegenJobToCreate_RenderConfig_React_ApiConfiguration = new Amazon.AmplifyUIBuilder.Model.ApiConfiguration();
            Amazon.AmplifyUIBuilder.Model.DataStoreRenderConfig requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_codegenJobToCreate_RenderConfig_React_ApiConfiguration_apiConfiguration_DataStoreConfig = null;
            if (cmdletContext.ApiConfiguration_DataStoreConfig != null)
            {
                requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_codegenJobToCreate_RenderConfig_React_ApiConfiguration_apiConfiguration_DataStoreConfig = cmdletContext.ApiConfiguration_DataStoreConfig;
            }
            if (requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_codegenJobToCreate_RenderConfig_React_ApiConfiguration_apiConfiguration_DataStoreConfig != null)
            {
                requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_codegenJobToCreate_RenderConfig_React_ApiConfiguration.DataStoreConfig = requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_codegenJobToCreate_RenderConfig_React_ApiConfiguration_apiConfiguration_DataStoreConfig;
                requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_codegenJobToCreate_RenderConfig_React_ApiConfigurationIsNull = false;
            }
            Amazon.AmplifyUIBuilder.Model.NoApiRenderConfig requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_codegenJobToCreate_RenderConfig_React_ApiConfiguration_apiConfiguration_NoApiConfig = null;
            if (cmdletContext.ApiConfiguration_NoApiConfig != null)
            {
                requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_codegenJobToCreate_RenderConfig_React_ApiConfiguration_apiConfiguration_NoApiConfig = cmdletContext.ApiConfiguration_NoApiConfig;
            }
            if (requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_codegenJobToCreate_RenderConfig_React_ApiConfiguration_apiConfiguration_NoApiConfig != null)
            {
                requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_codegenJobToCreate_RenderConfig_React_ApiConfiguration.NoApiConfig = requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_codegenJobToCreate_RenderConfig_React_ApiConfiguration_apiConfiguration_NoApiConfig;
                requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_codegenJobToCreate_RenderConfig_React_ApiConfigurationIsNull = false;
            }
            Amazon.AmplifyUIBuilder.Model.GraphQLRenderConfig requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_codegenJobToCreate_RenderConfig_React_ApiConfiguration_codegenJobToCreate_RenderConfig_React_ApiConfiguration_GraphQLConfig = null;
            
             // populate GraphQLConfig
            var requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_codegenJobToCreate_RenderConfig_React_ApiConfiguration_codegenJobToCreate_RenderConfig_React_ApiConfiguration_GraphQLConfigIsNull = true;
            requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_codegenJobToCreate_RenderConfig_React_ApiConfiguration_codegenJobToCreate_RenderConfig_React_ApiConfiguration_GraphQLConfig = new Amazon.AmplifyUIBuilder.Model.GraphQLRenderConfig();
            System.String requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_codegenJobToCreate_RenderConfig_React_ApiConfiguration_codegenJobToCreate_RenderConfig_React_ApiConfiguration_GraphQLConfig_graphQLConfig_FragmentsFilePath = null;
            if (cmdletContext.GraphQLConfig_FragmentsFilePath != null)
            {
                requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_codegenJobToCreate_RenderConfig_React_ApiConfiguration_codegenJobToCreate_RenderConfig_React_ApiConfiguration_GraphQLConfig_graphQLConfig_FragmentsFilePath = cmdletContext.GraphQLConfig_FragmentsFilePath;
            }
            if (requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_codegenJobToCreate_RenderConfig_React_ApiConfiguration_codegenJobToCreate_RenderConfig_React_ApiConfiguration_GraphQLConfig_graphQLConfig_FragmentsFilePath != null)
            {
                requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_codegenJobToCreate_RenderConfig_React_ApiConfiguration_codegenJobToCreate_RenderConfig_React_ApiConfiguration_GraphQLConfig.FragmentsFilePath = requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_codegenJobToCreate_RenderConfig_React_ApiConfiguration_codegenJobToCreate_RenderConfig_React_ApiConfiguration_GraphQLConfig_graphQLConfig_FragmentsFilePath;
                requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_codegenJobToCreate_RenderConfig_React_ApiConfiguration_codegenJobToCreate_RenderConfig_React_ApiConfiguration_GraphQLConfigIsNull = false;
            }
            System.String requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_codegenJobToCreate_RenderConfig_React_ApiConfiguration_codegenJobToCreate_RenderConfig_React_ApiConfiguration_GraphQLConfig_graphQLConfig_MutationsFilePath = null;
            if (cmdletContext.GraphQLConfig_MutationsFilePath != null)
            {
                requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_codegenJobToCreate_RenderConfig_React_ApiConfiguration_codegenJobToCreate_RenderConfig_React_ApiConfiguration_GraphQLConfig_graphQLConfig_MutationsFilePath = cmdletContext.GraphQLConfig_MutationsFilePath;
            }
            if (requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_codegenJobToCreate_RenderConfig_React_ApiConfiguration_codegenJobToCreate_RenderConfig_React_ApiConfiguration_GraphQLConfig_graphQLConfig_MutationsFilePath != null)
            {
                requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_codegenJobToCreate_RenderConfig_React_ApiConfiguration_codegenJobToCreate_RenderConfig_React_ApiConfiguration_GraphQLConfig.MutationsFilePath = requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_codegenJobToCreate_RenderConfig_React_ApiConfiguration_codegenJobToCreate_RenderConfig_React_ApiConfiguration_GraphQLConfig_graphQLConfig_MutationsFilePath;
                requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_codegenJobToCreate_RenderConfig_React_ApiConfiguration_codegenJobToCreate_RenderConfig_React_ApiConfiguration_GraphQLConfigIsNull = false;
            }
            System.String requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_codegenJobToCreate_RenderConfig_React_ApiConfiguration_codegenJobToCreate_RenderConfig_React_ApiConfiguration_GraphQLConfig_graphQLConfig_QueriesFilePath = null;
            if (cmdletContext.GraphQLConfig_QueriesFilePath != null)
            {
                requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_codegenJobToCreate_RenderConfig_React_ApiConfiguration_codegenJobToCreate_RenderConfig_React_ApiConfiguration_GraphQLConfig_graphQLConfig_QueriesFilePath = cmdletContext.GraphQLConfig_QueriesFilePath;
            }
            if (requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_codegenJobToCreate_RenderConfig_React_ApiConfiguration_codegenJobToCreate_RenderConfig_React_ApiConfiguration_GraphQLConfig_graphQLConfig_QueriesFilePath != null)
            {
                requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_codegenJobToCreate_RenderConfig_React_ApiConfiguration_codegenJobToCreate_RenderConfig_React_ApiConfiguration_GraphQLConfig.QueriesFilePath = requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_codegenJobToCreate_RenderConfig_React_ApiConfiguration_codegenJobToCreate_RenderConfig_React_ApiConfiguration_GraphQLConfig_graphQLConfig_QueriesFilePath;
                requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_codegenJobToCreate_RenderConfig_React_ApiConfiguration_codegenJobToCreate_RenderConfig_React_ApiConfiguration_GraphQLConfigIsNull = false;
            }
            System.String requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_codegenJobToCreate_RenderConfig_React_ApiConfiguration_codegenJobToCreate_RenderConfig_React_ApiConfiguration_GraphQLConfig_graphQLConfig_SubscriptionsFilePath = null;
            if (cmdletContext.GraphQLConfig_SubscriptionsFilePath != null)
            {
                requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_codegenJobToCreate_RenderConfig_React_ApiConfiguration_codegenJobToCreate_RenderConfig_React_ApiConfiguration_GraphQLConfig_graphQLConfig_SubscriptionsFilePath = cmdletContext.GraphQLConfig_SubscriptionsFilePath;
            }
            if (requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_codegenJobToCreate_RenderConfig_React_ApiConfiguration_codegenJobToCreate_RenderConfig_React_ApiConfiguration_GraphQLConfig_graphQLConfig_SubscriptionsFilePath != null)
            {
                requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_codegenJobToCreate_RenderConfig_React_ApiConfiguration_codegenJobToCreate_RenderConfig_React_ApiConfiguration_GraphQLConfig.SubscriptionsFilePath = requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_codegenJobToCreate_RenderConfig_React_ApiConfiguration_codegenJobToCreate_RenderConfig_React_ApiConfiguration_GraphQLConfig_graphQLConfig_SubscriptionsFilePath;
                requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_codegenJobToCreate_RenderConfig_React_ApiConfiguration_codegenJobToCreate_RenderConfig_React_ApiConfiguration_GraphQLConfigIsNull = false;
            }
            System.String requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_codegenJobToCreate_RenderConfig_React_ApiConfiguration_codegenJobToCreate_RenderConfig_React_ApiConfiguration_GraphQLConfig_graphQLConfig_TypesFilePath = null;
            if (cmdletContext.GraphQLConfig_TypesFilePath != null)
            {
                requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_codegenJobToCreate_RenderConfig_React_ApiConfiguration_codegenJobToCreate_RenderConfig_React_ApiConfiguration_GraphQLConfig_graphQLConfig_TypesFilePath = cmdletContext.GraphQLConfig_TypesFilePath;
            }
            if (requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_codegenJobToCreate_RenderConfig_React_ApiConfiguration_codegenJobToCreate_RenderConfig_React_ApiConfiguration_GraphQLConfig_graphQLConfig_TypesFilePath != null)
            {
                requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_codegenJobToCreate_RenderConfig_React_ApiConfiguration_codegenJobToCreate_RenderConfig_React_ApiConfiguration_GraphQLConfig.TypesFilePath = requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_codegenJobToCreate_RenderConfig_React_ApiConfiguration_codegenJobToCreate_RenderConfig_React_ApiConfiguration_GraphQLConfig_graphQLConfig_TypesFilePath;
                requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_codegenJobToCreate_RenderConfig_React_ApiConfiguration_codegenJobToCreate_RenderConfig_React_ApiConfiguration_GraphQLConfigIsNull = false;
            }
             // determine if requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_codegenJobToCreate_RenderConfig_React_ApiConfiguration_codegenJobToCreate_RenderConfig_React_ApiConfiguration_GraphQLConfig should be set to null
            if (requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_codegenJobToCreate_RenderConfig_React_ApiConfiguration_codegenJobToCreate_RenderConfig_React_ApiConfiguration_GraphQLConfigIsNull)
            {
                requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_codegenJobToCreate_RenderConfig_React_ApiConfiguration_codegenJobToCreate_RenderConfig_React_ApiConfiguration_GraphQLConfig = null;
            }
            if (requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_codegenJobToCreate_RenderConfig_React_ApiConfiguration_codegenJobToCreate_RenderConfig_React_ApiConfiguration_GraphQLConfig != null)
            {
                requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_codegenJobToCreate_RenderConfig_React_ApiConfiguration.GraphQLConfig = requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_codegenJobToCreate_RenderConfig_React_ApiConfiguration_codegenJobToCreate_RenderConfig_React_ApiConfiguration_GraphQLConfig;
                requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_codegenJobToCreate_RenderConfig_React_ApiConfigurationIsNull = false;
            }
             // determine if requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_codegenJobToCreate_RenderConfig_React_ApiConfiguration should be set to null
            if (requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_codegenJobToCreate_RenderConfig_React_ApiConfigurationIsNull)
            {
                requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_codegenJobToCreate_RenderConfig_React_ApiConfiguration = null;
            }
            if (requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_codegenJobToCreate_RenderConfig_React_ApiConfiguration != null)
            {
                requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React.ApiConfiguration = requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React_codegenJobToCreate_RenderConfig_React_ApiConfiguration;
                requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_ReactIsNull = false;
            }
             // determine if requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React should be set to null
            if (requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_ReactIsNull)
            {
                requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React = null;
            }
            if (requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React != null)
            {
                requestCodegenJobToCreate_codegenJobToCreate_RenderConfig.React = requestCodegenJobToCreate_codegenJobToCreate_RenderConfig_codegenJobToCreate_RenderConfig_React;
                requestCodegenJobToCreate_codegenJobToCreate_RenderConfigIsNull = false;
            }
             // determine if requestCodegenJobToCreate_codegenJobToCreate_RenderConfig should be set to null
            if (requestCodegenJobToCreate_codegenJobToCreate_RenderConfigIsNull)
            {
                requestCodegenJobToCreate_codegenJobToCreate_RenderConfig = null;
            }
            if (requestCodegenJobToCreate_codegenJobToCreate_RenderConfig != null)
            {
                request.CodegenJobToCreate.RenderConfig = requestCodegenJobToCreate_codegenJobToCreate_RenderConfig;
                requestCodegenJobToCreateIsNull = false;
            }
            Amazon.AmplifyUIBuilder.Model.CodegenFeatureFlags requestCodegenJobToCreate_codegenJobToCreate_Features = null;
            
             // populate Features
            var requestCodegenJobToCreate_codegenJobToCreate_FeaturesIsNull = true;
            requestCodegenJobToCreate_codegenJobToCreate_Features = new Amazon.AmplifyUIBuilder.Model.CodegenFeatureFlags();
            System.Boolean? requestCodegenJobToCreate_codegenJobToCreate_Features_features_IsNonModelSupported = null;
            if (cmdletContext.Features_IsNonModelSupported != null)
            {
                requestCodegenJobToCreate_codegenJobToCreate_Features_features_IsNonModelSupported = cmdletContext.Features_IsNonModelSupported.Value;
            }
            if (requestCodegenJobToCreate_codegenJobToCreate_Features_features_IsNonModelSupported != null)
            {
                requestCodegenJobToCreate_codegenJobToCreate_Features.IsNonModelSupported = requestCodegenJobToCreate_codegenJobToCreate_Features_features_IsNonModelSupported.Value;
                requestCodegenJobToCreate_codegenJobToCreate_FeaturesIsNull = false;
            }
            System.Boolean? requestCodegenJobToCreate_codegenJobToCreate_Features_features_IsRelationshipSupported = null;
            if (cmdletContext.Features_IsRelationshipSupported != null)
            {
                requestCodegenJobToCreate_codegenJobToCreate_Features_features_IsRelationshipSupported = cmdletContext.Features_IsRelationshipSupported.Value;
            }
            if (requestCodegenJobToCreate_codegenJobToCreate_Features_features_IsRelationshipSupported != null)
            {
                requestCodegenJobToCreate_codegenJobToCreate_Features.IsRelationshipSupported = requestCodegenJobToCreate_codegenJobToCreate_Features_features_IsRelationshipSupported.Value;
                requestCodegenJobToCreate_codegenJobToCreate_FeaturesIsNull = false;
            }
             // determine if requestCodegenJobToCreate_codegenJobToCreate_Features should be set to null
            if (requestCodegenJobToCreate_codegenJobToCreate_FeaturesIsNull)
            {
                requestCodegenJobToCreate_codegenJobToCreate_Features = null;
            }
            if (requestCodegenJobToCreate_codegenJobToCreate_Features != null)
            {
                request.CodegenJobToCreate.Features = requestCodegenJobToCreate_codegenJobToCreate_Features;
                requestCodegenJobToCreateIsNull = false;
            }
            Amazon.AmplifyUIBuilder.Model.CodegenJobGenericDataSchema requestCodegenJobToCreate_codegenJobToCreate_GenericDataSchema = null;
            
             // populate GenericDataSchema
            var requestCodegenJobToCreate_codegenJobToCreate_GenericDataSchemaIsNull = true;
            requestCodegenJobToCreate_codegenJobToCreate_GenericDataSchema = new Amazon.AmplifyUIBuilder.Model.CodegenJobGenericDataSchema();
            Amazon.AmplifyUIBuilder.CodegenJobGenericDataSourceType requestCodegenJobToCreate_codegenJobToCreate_GenericDataSchema_genericDataSchema_DataSourceType = null;
            if (cmdletContext.GenericDataSchema_DataSourceType != null)
            {
                requestCodegenJobToCreate_codegenJobToCreate_GenericDataSchema_genericDataSchema_DataSourceType = cmdletContext.GenericDataSchema_DataSourceType;
            }
            if (requestCodegenJobToCreate_codegenJobToCreate_GenericDataSchema_genericDataSchema_DataSourceType != null)
            {
                requestCodegenJobToCreate_codegenJobToCreate_GenericDataSchema.DataSourceType = requestCodegenJobToCreate_codegenJobToCreate_GenericDataSchema_genericDataSchema_DataSourceType;
                requestCodegenJobToCreate_codegenJobToCreate_GenericDataSchemaIsNull = false;
            }
            Dictionary<System.String, Amazon.AmplifyUIBuilder.Model.CodegenGenericDataEnum> requestCodegenJobToCreate_codegenJobToCreate_GenericDataSchema_genericDataSchema_Enum = null;
            if (cmdletContext.GenericDataSchema_Enum != null)
            {
                requestCodegenJobToCreate_codegenJobToCreate_GenericDataSchema_genericDataSchema_Enum = cmdletContext.GenericDataSchema_Enum;
            }
            if (requestCodegenJobToCreate_codegenJobToCreate_GenericDataSchema_genericDataSchema_Enum != null)
            {
                requestCodegenJobToCreate_codegenJobToCreate_GenericDataSchema.Enums = requestCodegenJobToCreate_codegenJobToCreate_GenericDataSchema_genericDataSchema_Enum;
                requestCodegenJobToCreate_codegenJobToCreate_GenericDataSchemaIsNull = false;
            }
            Dictionary<System.String, Amazon.AmplifyUIBuilder.Model.CodegenGenericDataModel> requestCodegenJobToCreate_codegenJobToCreate_GenericDataSchema_genericDataSchema_Model = null;
            if (cmdletContext.GenericDataSchema_Model != null)
            {
                requestCodegenJobToCreate_codegenJobToCreate_GenericDataSchema_genericDataSchema_Model = cmdletContext.GenericDataSchema_Model;
            }
            if (requestCodegenJobToCreate_codegenJobToCreate_GenericDataSchema_genericDataSchema_Model != null)
            {
                requestCodegenJobToCreate_codegenJobToCreate_GenericDataSchema.Models = requestCodegenJobToCreate_codegenJobToCreate_GenericDataSchema_genericDataSchema_Model;
                requestCodegenJobToCreate_codegenJobToCreate_GenericDataSchemaIsNull = false;
            }
            Dictionary<System.String, Amazon.AmplifyUIBuilder.Model.CodegenGenericDataNonModel> requestCodegenJobToCreate_codegenJobToCreate_GenericDataSchema_genericDataSchema_NonModel = null;
            if (cmdletContext.GenericDataSchema_NonModel != null)
            {
                requestCodegenJobToCreate_codegenJobToCreate_GenericDataSchema_genericDataSchema_NonModel = cmdletContext.GenericDataSchema_NonModel;
            }
            if (requestCodegenJobToCreate_codegenJobToCreate_GenericDataSchema_genericDataSchema_NonModel != null)
            {
                requestCodegenJobToCreate_codegenJobToCreate_GenericDataSchema.NonModels = requestCodegenJobToCreate_codegenJobToCreate_GenericDataSchema_genericDataSchema_NonModel;
                requestCodegenJobToCreate_codegenJobToCreate_GenericDataSchemaIsNull = false;
            }
             // determine if requestCodegenJobToCreate_codegenJobToCreate_GenericDataSchema should be set to null
            if (requestCodegenJobToCreate_codegenJobToCreate_GenericDataSchemaIsNull)
            {
                requestCodegenJobToCreate_codegenJobToCreate_GenericDataSchema = null;
            }
            if (requestCodegenJobToCreate_codegenJobToCreate_GenericDataSchema != null)
            {
                request.CodegenJobToCreate.GenericDataSchema = requestCodegenJobToCreate_codegenJobToCreate_GenericDataSchema;
                requestCodegenJobToCreateIsNull = false;
            }
             // determine if request.CodegenJobToCreate should be set to null
            if (requestCodegenJobToCreateIsNull)
            {
                request.CodegenJobToCreate = null;
            }
            if (cmdletContext.EnvironmentName != null)
            {
                request.EnvironmentName = cmdletContext.EnvironmentName;
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
        
        private Amazon.AmplifyUIBuilder.Model.StartCodegenJobResponse CallAWSServiceOperation(IAmazonAmplifyUIBuilder client, Amazon.AmplifyUIBuilder.Model.StartCodegenJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Amplify UI Builder", "StartCodegenJob");
            try
            {
                #if DESKTOP
                return client.StartCodegenJob(request);
                #elif CORECLR
                return client.StartCodegenJobAsync(request).GetAwaiter().GetResult();
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
            public System.String AppId { get; set; }
            public System.String ClientToken { get; set; }
            public System.Boolean? CodegenJobToCreate_AutoGenerateForm { get; set; }
            public System.Boolean? Features_IsNonModelSupported { get; set; }
            public System.Boolean? Features_IsRelationshipSupported { get; set; }
            public Amazon.AmplifyUIBuilder.CodegenJobGenericDataSourceType GenericDataSchema_DataSourceType { get; set; }
            public Dictionary<System.String, Amazon.AmplifyUIBuilder.Model.CodegenGenericDataEnum> GenericDataSchema_Enum { get; set; }
            public Dictionary<System.String, Amazon.AmplifyUIBuilder.Model.CodegenGenericDataModel> GenericDataSchema_Model { get; set; }
            public Dictionary<System.String, Amazon.AmplifyUIBuilder.Model.CodegenGenericDataNonModel> GenericDataSchema_NonModel { get; set; }
            public Amazon.AmplifyUIBuilder.Model.DataStoreRenderConfig ApiConfiguration_DataStoreConfig { get; set; }
            public System.String GraphQLConfig_FragmentsFilePath { get; set; }
            public System.String GraphQLConfig_MutationsFilePath { get; set; }
            public System.String GraphQLConfig_QueriesFilePath { get; set; }
            public System.String GraphQLConfig_SubscriptionsFilePath { get; set; }
            public System.String GraphQLConfig_TypesFilePath { get; set; }
            public Amazon.AmplifyUIBuilder.Model.NoApiRenderConfig ApiConfiguration_NoApiConfig { get; set; }
            public Dictionary<System.String, System.String> React_Dependency { get; set; }
            public System.Boolean? React_InlineSourceMap { get; set; }
            public Amazon.AmplifyUIBuilder.JSModule React_Module { get; set; }
            public System.Boolean? React_RenderTypeDeclaration { get; set; }
            public Amazon.AmplifyUIBuilder.JSScript React_Script { get; set; }
            public Amazon.AmplifyUIBuilder.JSTarget React_Target { get; set; }
            public Dictionary<System.String, System.String> CodegenJobToCreate_Tag { get; set; }
            public System.String EnvironmentName { get; set; }
            public System.Func<Amazon.AmplifyUIBuilder.Model.StartCodegenJobResponse, NewAMPUICodegenJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Entity;
        }
        
    }
}
