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
using Amazon.BedrockAgentCoreControl;
using Amazon.BedrockAgentCoreControl.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.BACC
{
    /// <summary>
    /// Updates an existing gateway target.
    /// </summary>
    [Cmdlet("Update", "BACCGatewayTarget", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BedrockAgentCoreControl.Model.UpdateGatewayTargetResponse")]
    [AWSCmdlet("Calls the Amazon Bedrock Agent Core Control Plane Fronting Layer UpdateGatewayTarget API operation.", Operation = new[] {"UpdateGatewayTarget"}, SelectReturnType = typeof(Amazon.BedrockAgentCoreControl.Model.UpdateGatewayTargetResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgentCoreControl.Model.UpdateGatewayTargetResponse",
        "This cmdlet returns an Amazon.BedrockAgentCoreControl.Model.UpdateGatewayTargetResponse object containing multiple properties."
    )]
    public partial class UpdateBACCGatewayTargetCmdlet : AmazonBedrockAgentCoreControlClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter MetadataConfiguration_AllowedQueryParameter
        /// <summary>
        /// <para>
        /// <para>A list of URL query parameters that are allowed to be propagated from incoming gateway
        /// URL to the target.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MetadataConfiguration_AllowedQueryParameters")]
        public System.String[] MetadataConfiguration_AllowedQueryParameter { get; set; }
        #endregion
        
        #region Parameter MetadataConfiguration_AllowedRequestHeader
        /// <summary>
        /// <para>
        /// <para>A list of HTTP headers that are allowed to be propagated from incoming client requests
        /// to the target.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MetadataConfiguration_AllowedRequestHeaders")]
        public System.String[] MetadataConfiguration_AllowedRequestHeader { get; set; }
        #endregion
        
        #region Parameter MetadataConfiguration_AllowedResponseHeader
        /// <summary>
        /// <para>
        /// <para>A list of HTTP headers that are allowed to be propagated from the target response
        /// back to the client.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MetadataConfiguration_AllowedResponseHeaders")]
        public System.String[] MetadataConfiguration_AllowedResponseHeader { get; set; }
        #endregion
        
        #region Parameter Lambda_ToolSchema_S3_BucketOwnerAccountId
        /// <summary>
        /// <para>
        /// <para>The account ID of the Amazon S3 bucket owner. This ID is used for cross-account access
        /// to the bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetConfiguration_Mcp_Lambda_ToolSchema_S3_BucketOwnerAccountId")]
        public System.String Lambda_ToolSchema_S3_BucketOwnerAccountId { get; set; }
        #endregion
        
        #region Parameter OpenApiSchema_S3_BucketOwnerAccountId
        /// <summary>
        /// <para>
        /// <para>The account ID of the Amazon S3 bucket owner. This ID is used for cross-account access
        /// to the bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetConfiguration_Mcp_OpenApiSchema_S3_BucketOwnerAccountId")]
        public System.String OpenApiSchema_S3_BucketOwnerAccountId { get; set; }
        #endregion
        
        #region Parameter SmithyModel_S3_BucketOwnerAccountId
        /// <summary>
        /// <para>
        /// <para>The account ID of the Amazon S3 bucket owner. This ID is used for cross-account access
        /// to the bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetConfiguration_Mcp_SmithyModel_S3_BucketOwnerAccountId")]
        public System.String SmithyModel_S3_BucketOwnerAccountId { get; set; }
        #endregion
        
        #region Parameter CredentialProviderConfiguration
        /// <summary>
        /// <para>
        /// <para>The updated credential provider configurations for the gateway target.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CredentialProviderConfigurations")]
        public Amazon.BedrockAgentCoreControl.Model.CredentialProviderConfiguration[] CredentialProviderConfiguration { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The updated description for the gateway target.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter McpServer_Endpoint
        /// <summary>
        /// <para>
        /// <para>The endpoint for the MCP server target configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetConfiguration_Mcp_McpServer_Endpoint")]
        public System.String McpServer_Endpoint { get; set; }
        #endregion
        
        #region Parameter GatewayIdentifier
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the gateway associated with the target.</para>
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
        public System.String GatewayIdentifier { get; set; }
        #endregion
        
        #region Parameter ToolSchema_InlinePayload
        /// <summary>
        /// <para>
        /// <para>The inline payload of the tool schema. This payload contains the schema definition
        /// directly in the request.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetConfiguration_Mcp_Lambda_ToolSchema_InlinePayload")]
        public Amazon.BedrockAgentCoreControl.Model.ToolDefinition[] ToolSchema_InlinePayload { get; set; }
        #endregion
        
        #region Parameter OpenApiSchema_InlinePayload
        /// <summary>
        /// <para>
        /// <para>The inline payload containing the API schema definition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetConfiguration_Mcp_OpenApiSchema_InlinePayload")]
        public System.String OpenApiSchema_InlinePayload { get; set; }
        #endregion
        
        #region Parameter SmithyModel_InlinePayload
        /// <summary>
        /// <para>
        /// <para>The inline payload containing the API schema definition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetConfiguration_Mcp_SmithyModel_InlinePayload")]
        public System.String SmithyModel_InlinePayload { get; set; }
        #endregion
        
        #region Parameter Lambda_LambdaArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Lambda function. This function is invoked by
        /// the gateway to communicate with the target.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetConfiguration_Mcp_Lambda_LambdaArn")]
        public System.String Lambda_LambdaArn { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The updated name for the gateway target.</para>
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
        
        #region Parameter ApiGateway_RestApiId
        /// <summary>
        /// <para>
        /// <para>The ID of the API Gateway REST API.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetConfiguration_Mcp_ApiGateway_RestApiId")]
        public System.String ApiGateway_RestApiId { get; set; }
        #endregion
        
        #region Parameter ApiGateway_Stage
        /// <summary>
        /// <para>
        /// <para>The ID of the stage of the REST API to add as a target.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetConfiguration_Mcp_ApiGateway_Stage")]
        public System.String ApiGateway_Stage { get; set; }
        #endregion
        
        #region Parameter TargetId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the gateway target to update.</para>
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
        public System.String TargetId { get; set; }
        #endregion
        
        #region Parameter ApiGatewayToolConfiguration_ToolFilter
        /// <summary>
        /// <para>
        /// <para>A list of path and method patterns to expose as tools using metadata from the REST
        /// API's OpenAPI specification.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetConfiguration_Mcp_ApiGateway_ApiGatewayToolConfiguration_ToolFilters")]
        public Amazon.BedrockAgentCoreControl.Model.ApiGatewayToolFilter[] ApiGatewayToolConfiguration_ToolFilter { get; set; }
        #endregion
        
        #region Parameter ApiGatewayToolConfiguration_ToolOverride
        /// <summary>
        /// <para>
        /// <para>A list of explicit tool definitions with optional custom names and descriptions.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetConfiguration_Mcp_ApiGateway_ApiGatewayToolConfiguration_ToolOverrides")]
        public Amazon.BedrockAgentCoreControl.Model.ApiGatewayToolOverride[] ApiGatewayToolConfiguration_ToolOverride { get; set; }
        #endregion
        
        #region Parameter Lambda_ToolSchema_S3_Uri
        /// <summary>
        /// <para>
        /// <para>The URI of the Amazon S3 object. This URI specifies the location of the object in
        /// Amazon S3.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetConfiguration_Mcp_Lambda_ToolSchema_S3_Uri")]
        public System.String Lambda_ToolSchema_S3_Uri { get; set; }
        #endregion
        
        #region Parameter OpenApiSchema_S3_Uri
        /// <summary>
        /// <para>
        /// <para>The URI of the Amazon S3 object. This URI specifies the location of the object in
        /// Amazon S3.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetConfiguration_Mcp_OpenApiSchema_S3_Uri")]
        public System.String OpenApiSchema_S3_Uri { get; set; }
        #endregion
        
        #region Parameter SmithyModel_S3_Uri
        /// <summary>
        /// <para>
        /// <para>The URI of the Amazon S3 object. This URI specifies the location of the object in
        /// Amazon S3.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetConfiguration_Mcp_SmithyModel_S3_Uri")]
        public System.String SmithyModel_S3_Uri { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgentCoreControl.Model.UpdateGatewayTargetResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgentCoreControl.Model.UpdateGatewayTargetResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TargetId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-BACCGatewayTarget (UpdateGatewayTarget)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgentCoreControl.Model.UpdateGatewayTargetResponse, UpdateBACCGatewayTargetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.CredentialProviderConfiguration != null)
            {
                context.CredentialProviderConfiguration = new List<Amazon.BedrockAgentCoreControl.Model.CredentialProviderConfiguration>(this.CredentialProviderConfiguration);
            }
            context.Description = this.Description;
            context.GatewayIdentifier = this.GatewayIdentifier;
            #if MODULAR
            if (this.GatewayIdentifier == null && ParameterWasBound(nameof(this.GatewayIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter GatewayIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.MetadataConfiguration_AllowedQueryParameter != null)
            {
                context.MetadataConfiguration_AllowedQueryParameter = new List<System.String>(this.MetadataConfiguration_AllowedQueryParameter);
            }
            if (this.MetadataConfiguration_AllowedRequestHeader != null)
            {
                context.MetadataConfiguration_AllowedRequestHeader = new List<System.String>(this.MetadataConfiguration_AllowedRequestHeader);
            }
            if (this.MetadataConfiguration_AllowedResponseHeader != null)
            {
                context.MetadataConfiguration_AllowedResponseHeader = new List<System.String>(this.MetadataConfiguration_AllowedResponseHeader);
            }
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ApiGatewayToolConfiguration_ToolFilter != null)
            {
                context.ApiGatewayToolConfiguration_ToolFilter = new List<Amazon.BedrockAgentCoreControl.Model.ApiGatewayToolFilter>(this.ApiGatewayToolConfiguration_ToolFilter);
            }
            if (this.ApiGatewayToolConfiguration_ToolOverride != null)
            {
                context.ApiGatewayToolConfiguration_ToolOverride = new List<Amazon.BedrockAgentCoreControl.Model.ApiGatewayToolOverride>(this.ApiGatewayToolConfiguration_ToolOverride);
            }
            context.ApiGateway_RestApiId = this.ApiGateway_RestApiId;
            context.ApiGateway_Stage = this.ApiGateway_Stage;
            context.Lambda_LambdaArn = this.Lambda_LambdaArn;
            if (this.ToolSchema_InlinePayload != null)
            {
                context.ToolSchema_InlinePayload = new List<Amazon.BedrockAgentCoreControl.Model.ToolDefinition>(this.ToolSchema_InlinePayload);
            }
            context.Lambda_ToolSchema_S3_BucketOwnerAccountId = this.Lambda_ToolSchema_S3_BucketOwnerAccountId;
            context.Lambda_ToolSchema_S3_Uri = this.Lambda_ToolSchema_S3_Uri;
            context.McpServer_Endpoint = this.McpServer_Endpoint;
            context.OpenApiSchema_InlinePayload = this.OpenApiSchema_InlinePayload;
            context.OpenApiSchema_S3_BucketOwnerAccountId = this.OpenApiSchema_S3_BucketOwnerAccountId;
            context.OpenApiSchema_S3_Uri = this.OpenApiSchema_S3_Uri;
            context.SmithyModel_InlinePayload = this.SmithyModel_InlinePayload;
            context.SmithyModel_S3_BucketOwnerAccountId = this.SmithyModel_S3_BucketOwnerAccountId;
            context.SmithyModel_S3_Uri = this.SmithyModel_S3_Uri;
            context.TargetId = this.TargetId;
            #if MODULAR
            if (this.TargetId == null && ParameterWasBound(nameof(this.TargetId)))
            {
                WriteWarning("You are passing $null as a value for parameter TargetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.BedrockAgentCoreControl.Model.UpdateGatewayTargetRequest();
            
            if (cmdletContext.CredentialProviderConfiguration != null)
            {
                request.CredentialProviderConfigurations = cmdletContext.CredentialProviderConfiguration;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.GatewayIdentifier != null)
            {
                request.GatewayIdentifier = cmdletContext.GatewayIdentifier;
            }
            
             // populate MetadataConfiguration
            var requestMetadataConfigurationIsNull = true;
            request.MetadataConfiguration = new Amazon.BedrockAgentCoreControl.Model.MetadataConfiguration();
            List<System.String> requestMetadataConfiguration_metadataConfiguration_AllowedQueryParameter = null;
            if (cmdletContext.MetadataConfiguration_AllowedQueryParameter != null)
            {
                requestMetadataConfiguration_metadataConfiguration_AllowedQueryParameter = cmdletContext.MetadataConfiguration_AllowedQueryParameter;
            }
            if (requestMetadataConfiguration_metadataConfiguration_AllowedQueryParameter != null)
            {
                request.MetadataConfiguration.AllowedQueryParameters = requestMetadataConfiguration_metadataConfiguration_AllowedQueryParameter;
                requestMetadataConfigurationIsNull = false;
            }
            List<System.String> requestMetadataConfiguration_metadataConfiguration_AllowedRequestHeader = null;
            if (cmdletContext.MetadataConfiguration_AllowedRequestHeader != null)
            {
                requestMetadataConfiguration_metadataConfiguration_AllowedRequestHeader = cmdletContext.MetadataConfiguration_AllowedRequestHeader;
            }
            if (requestMetadataConfiguration_metadataConfiguration_AllowedRequestHeader != null)
            {
                request.MetadataConfiguration.AllowedRequestHeaders = requestMetadataConfiguration_metadataConfiguration_AllowedRequestHeader;
                requestMetadataConfigurationIsNull = false;
            }
            List<System.String> requestMetadataConfiguration_metadataConfiguration_AllowedResponseHeader = null;
            if (cmdletContext.MetadataConfiguration_AllowedResponseHeader != null)
            {
                requestMetadataConfiguration_metadataConfiguration_AllowedResponseHeader = cmdletContext.MetadataConfiguration_AllowedResponseHeader;
            }
            if (requestMetadataConfiguration_metadataConfiguration_AllowedResponseHeader != null)
            {
                request.MetadataConfiguration.AllowedResponseHeaders = requestMetadataConfiguration_metadataConfiguration_AllowedResponseHeader;
                requestMetadataConfigurationIsNull = false;
            }
             // determine if request.MetadataConfiguration should be set to null
            if (requestMetadataConfigurationIsNull)
            {
                request.MetadataConfiguration = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate TargetConfiguration
            var requestTargetConfigurationIsNull = true;
            request.TargetConfiguration = new Amazon.BedrockAgentCoreControl.Model.TargetConfiguration();
            Amazon.BedrockAgentCoreControl.Model.McpTargetConfiguration requestTargetConfiguration_targetConfiguration_Mcp = null;
            
             // populate Mcp
            var requestTargetConfiguration_targetConfiguration_McpIsNull = true;
            requestTargetConfiguration_targetConfiguration_Mcp = new Amazon.BedrockAgentCoreControl.Model.McpTargetConfiguration();
            Amazon.BedrockAgentCoreControl.Model.McpServerTargetConfiguration requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_McpServer = null;
            
             // populate McpServer
            var requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_McpServerIsNull = true;
            requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_McpServer = new Amazon.BedrockAgentCoreControl.Model.McpServerTargetConfiguration();
            System.String requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_McpServer_mcpServer_Endpoint = null;
            if (cmdletContext.McpServer_Endpoint != null)
            {
                requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_McpServer_mcpServer_Endpoint = cmdletContext.McpServer_Endpoint;
            }
            if (requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_McpServer_mcpServer_Endpoint != null)
            {
                requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_McpServer.Endpoint = requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_McpServer_mcpServer_Endpoint;
                requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_McpServerIsNull = false;
            }
             // determine if requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_McpServer should be set to null
            if (requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_McpServerIsNull)
            {
                requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_McpServer = null;
            }
            if (requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_McpServer != null)
            {
                requestTargetConfiguration_targetConfiguration_Mcp.McpServer = requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_McpServer;
                requestTargetConfiguration_targetConfiguration_McpIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.Model.McpLambdaTargetConfiguration requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_Lambda = null;
            
             // populate Lambda
            var requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_LambdaIsNull = true;
            requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_Lambda = new Amazon.BedrockAgentCoreControl.Model.McpLambdaTargetConfiguration();
            System.String requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_Lambda_lambda_LambdaArn = null;
            if (cmdletContext.Lambda_LambdaArn != null)
            {
                requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_Lambda_lambda_LambdaArn = cmdletContext.Lambda_LambdaArn;
            }
            if (requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_Lambda_lambda_LambdaArn != null)
            {
                requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_Lambda.LambdaArn = requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_Lambda_lambda_LambdaArn;
                requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_LambdaIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.Model.ToolSchema requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_Lambda_targetConfiguration_Mcp_Lambda_ToolSchema = null;
            
             // populate ToolSchema
            var requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_Lambda_targetConfiguration_Mcp_Lambda_ToolSchemaIsNull = true;
            requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_Lambda_targetConfiguration_Mcp_Lambda_ToolSchema = new Amazon.BedrockAgentCoreControl.Model.ToolSchema();
            List<Amazon.BedrockAgentCoreControl.Model.ToolDefinition> requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_Lambda_targetConfiguration_Mcp_Lambda_ToolSchema_toolSchema_InlinePayload = null;
            if (cmdletContext.ToolSchema_InlinePayload != null)
            {
                requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_Lambda_targetConfiguration_Mcp_Lambda_ToolSchema_toolSchema_InlinePayload = cmdletContext.ToolSchema_InlinePayload;
            }
            if (requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_Lambda_targetConfiguration_Mcp_Lambda_ToolSchema_toolSchema_InlinePayload != null)
            {
                requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_Lambda_targetConfiguration_Mcp_Lambda_ToolSchema.InlinePayload = requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_Lambda_targetConfiguration_Mcp_Lambda_ToolSchema_toolSchema_InlinePayload;
                requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_Lambda_targetConfiguration_Mcp_Lambda_ToolSchemaIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.Model.S3Configuration requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_Lambda_targetConfiguration_Mcp_Lambda_ToolSchema_targetConfiguration_Mcp_Lambda_ToolSchema_S3 = null;
            
             // populate S3
            var requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_Lambda_targetConfiguration_Mcp_Lambda_ToolSchema_targetConfiguration_Mcp_Lambda_ToolSchema_S3IsNull = true;
            requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_Lambda_targetConfiguration_Mcp_Lambda_ToolSchema_targetConfiguration_Mcp_Lambda_ToolSchema_S3 = new Amazon.BedrockAgentCoreControl.Model.S3Configuration();
            System.String requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_Lambda_targetConfiguration_Mcp_Lambda_ToolSchema_targetConfiguration_Mcp_Lambda_ToolSchema_S3_lambda_ToolSchema_S3_BucketOwnerAccountId = null;
            if (cmdletContext.Lambda_ToolSchema_S3_BucketOwnerAccountId != null)
            {
                requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_Lambda_targetConfiguration_Mcp_Lambda_ToolSchema_targetConfiguration_Mcp_Lambda_ToolSchema_S3_lambda_ToolSchema_S3_BucketOwnerAccountId = cmdletContext.Lambda_ToolSchema_S3_BucketOwnerAccountId;
            }
            if (requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_Lambda_targetConfiguration_Mcp_Lambda_ToolSchema_targetConfiguration_Mcp_Lambda_ToolSchema_S3_lambda_ToolSchema_S3_BucketOwnerAccountId != null)
            {
                requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_Lambda_targetConfiguration_Mcp_Lambda_ToolSchema_targetConfiguration_Mcp_Lambda_ToolSchema_S3.BucketOwnerAccountId = requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_Lambda_targetConfiguration_Mcp_Lambda_ToolSchema_targetConfiguration_Mcp_Lambda_ToolSchema_S3_lambda_ToolSchema_S3_BucketOwnerAccountId;
                requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_Lambda_targetConfiguration_Mcp_Lambda_ToolSchema_targetConfiguration_Mcp_Lambda_ToolSchema_S3IsNull = false;
            }
            System.String requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_Lambda_targetConfiguration_Mcp_Lambda_ToolSchema_targetConfiguration_Mcp_Lambda_ToolSchema_S3_lambda_ToolSchema_S3_Uri = null;
            if (cmdletContext.Lambda_ToolSchema_S3_Uri != null)
            {
                requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_Lambda_targetConfiguration_Mcp_Lambda_ToolSchema_targetConfiguration_Mcp_Lambda_ToolSchema_S3_lambda_ToolSchema_S3_Uri = cmdletContext.Lambda_ToolSchema_S3_Uri;
            }
            if (requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_Lambda_targetConfiguration_Mcp_Lambda_ToolSchema_targetConfiguration_Mcp_Lambda_ToolSchema_S3_lambda_ToolSchema_S3_Uri != null)
            {
                requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_Lambda_targetConfiguration_Mcp_Lambda_ToolSchema_targetConfiguration_Mcp_Lambda_ToolSchema_S3.Uri = requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_Lambda_targetConfiguration_Mcp_Lambda_ToolSchema_targetConfiguration_Mcp_Lambda_ToolSchema_S3_lambda_ToolSchema_S3_Uri;
                requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_Lambda_targetConfiguration_Mcp_Lambda_ToolSchema_targetConfiguration_Mcp_Lambda_ToolSchema_S3IsNull = false;
            }
             // determine if requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_Lambda_targetConfiguration_Mcp_Lambda_ToolSchema_targetConfiguration_Mcp_Lambda_ToolSchema_S3 should be set to null
            if (requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_Lambda_targetConfiguration_Mcp_Lambda_ToolSchema_targetConfiguration_Mcp_Lambda_ToolSchema_S3IsNull)
            {
                requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_Lambda_targetConfiguration_Mcp_Lambda_ToolSchema_targetConfiguration_Mcp_Lambda_ToolSchema_S3 = null;
            }
            if (requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_Lambda_targetConfiguration_Mcp_Lambda_ToolSchema_targetConfiguration_Mcp_Lambda_ToolSchema_S3 != null)
            {
                requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_Lambda_targetConfiguration_Mcp_Lambda_ToolSchema.S3 = requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_Lambda_targetConfiguration_Mcp_Lambda_ToolSchema_targetConfiguration_Mcp_Lambda_ToolSchema_S3;
                requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_Lambda_targetConfiguration_Mcp_Lambda_ToolSchemaIsNull = false;
            }
             // determine if requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_Lambda_targetConfiguration_Mcp_Lambda_ToolSchema should be set to null
            if (requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_Lambda_targetConfiguration_Mcp_Lambda_ToolSchemaIsNull)
            {
                requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_Lambda_targetConfiguration_Mcp_Lambda_ToolSchema = null;
            }
            if (requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_Lambda_targetConfiguration_Mcp_Lambda_ToolSchema != null)
            {
                requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_Lambda.ToolSchema = requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_Lambda_targetConfiguration_Mcp_Lambda_ToolSchema;
                requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_LambdaIsNull = false;
            }
             // determine if requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_Lambda should be set to null
            if (requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_LambdaIsNull)
            {
                requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_Lambda = null;
            }
            if (requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_Lambda != null)
            {
                requestTargetConfiguration_targetConfiguration_Mcp.Lambda = requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_Lambda;
                requestTargetConfiguration_targetConfiguration_McpIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.Model.ApiSchemaConfiguration requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_OpenApiSchema = null;
            
             // populate OpenApiSchema
            var requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_OpenApiSchemaIsNull = true;
            requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_OpenApiSchema = new Amazon.BedrockAgentCoreControl.Model.ApiSchemaConfiguration();
            System.String requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_OpenApiSchema_openApiSchema_InlinePayload = null;
            if (cmdletContext.OpenApiSchema_InlinePayload != null)
            {
                requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_OpenApiSchema_openApiSchema_InlinePayload = cmdletContext.OpenApiSchema_InlinePayload;
            }
            if (requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_OpenApiSchema_openApiSchema_InlinePayload != null)
            {
                requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_OpenApiSchema.InlinePayload = requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_OpenApiSchema_openApiSchema_InlinePayload;
                requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_OpenApiSchemaIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.Model.S3Configuration requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_OpenApiSchema_targetConfiguration_Mcp_OpenApiSchema_S3 = null;
            
             // populate S3
            var requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_OpenApiSchema_targetConfiguration_Mcp_OpenApiSchema_S3IsNull = true;
            requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_OpenApiSchema_targetConfiguration_Mcp_OpenApiSchema_S3 = new Amazon.BedrockAgentCoreControl.Model.S3Configuration();
            System.String requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_OpenApiSchema_targetConfiguration_Mcp_OpenApiSchema_S3_openApiSchema_S3_BucketOwnerAccountId = null;
            if (cmdletContext.OpenApiSchema_S3_BucketOwnerAccountId != null)
            {
                requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_OpenApiSchema_targetConfiguration_Mcp_OpenApiSchema_S3_openApiSchema_S3_BucketOwnerAccountId = cmdletContext.OpenApiSchema_S3_BucketOwnerAccountId;
            }
            if (requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_OpenApiSchema_targetConfiguration_Mcp_OpenApiSchema_S3_openApiSchema_S3_BucketOwnerAccountId != null)
            {
                requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_OpenApiSchema_targetConfiguration_Mcp_OpenApiSchema_S3.BucketOwnerAccountId = requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_OpenApiSchema_targetConfiguration_Mcp_OpenApiSchema_S3_openApiSchema_S3_BucketOwnerAccountId;
                requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_OpenApiSchema_targetConfiguration_Mcp_OpenApiSchema_S3IsNull = false;
            }
            System.String requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_OpenApiSchema_targetConfiguration_Mcp_OpenApiSchema_S3_openApiSchema_S3_Uri = null;
            if (cmdletContext.OpenApiSchema_S3_Uri != null)
            {
                requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_OpenApiSchema_targetConfiguration_Mcp_OpenApiSchema_S3_openApiSchema_S3_Uri = cmdletContext.OpenApiSchema_S3_Uri;
            }
            if (requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_OpenApiSchema_targetConfiguration_Mcp_OpenApiSchema_S3_openApiSchema_S3_Uri != null)
            {
                requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_OpenApiSchema_targetConfiguration_Mcp_OpenApiSchema_S3.Uri = requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_OpenApiSchema_targetConfiguration_Mcp_OpenApiSchema_S3_openApiSchema_S3_Uri;
                requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_OpenApiSchema_targetConfiguration_Mcp_OpenApiSchema_S3IsNull = false;
            }
             // determine if requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_OpenApiSchema_targetConfiguration_Mcp_OpenApiSchema_S3 should be set to null
            if (requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_OpenApiSchema_targetConfiguration_Mcp_OpenApiSchema_S3IsNull)
            {
                requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_OpenApiSchema_targetConfiguration_Mcp_OpenApiSchema_S3 = null;
            }
            if (requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_OpenApiSchema_targetConfiguration_Mcp_OpenApiSchema_S3 != null)
            {
                requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_OpenApiSchema.S3 = requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_OpenApiSchema_targetConfiguration_Mcp_OpenApiSchema_S3;
                requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_OpenApiSchemaIsNull = false;
            }
             // determine if requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_OpenApiSchema should be set to null
            if (requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_OpenApiSchemaIsNull)
            {
                requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_OpenApiSchema = null;
            }
            if (requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_OpenApiSchema != null)
            {
                requestTargetConfiguration_targetConfiguration_Mcp.OpenApiSchema = requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_OpenApiSchema;
                requestTargetConfiguration_targetConfiguration_McpIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.Model.ApiSchemaConfiguration requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_SmithyModel = null;
            
             // populate SmithyModel
            var requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_SmithyModelIsNull = true;
            requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_SmithyModel = new Amazon.BedrockAgentCoreControl.Model.ApiSchemaConfiguration();
            System.String requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_SmithyModel_smithyModel_InlinePayload = null;
            if (cmdletContext.SmithyModel_InlinePayload != null)
            {
                requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_SmithyModel_smithyModel_InlinePayload = cmdletContext.SmithyModel_InlinePayload;
            }
            if (requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_SmithyModel_smithyModel_InlinePayload != null)
            {
                requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_SmithyModel.InlinePayload = requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_SmithyModel_smithyModel_InlinePayload;
                requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_SmithyModelIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.Model.S3Configuration requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_SmithyModel_targetConfiguration_Mcp_SmithyModel_S3 = null;
            
             // populate S3
            var requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_SmithyModel_targetConfiguration_Mcp_SmithyModel_S3IsNull = true;
            requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_SmithyModel_targetConfiguration_Mcp_SmithyModel_S3 = new Amazon.BedrockAgentCoreControl.Model.S3Configuration();
            System.String requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_SmithyModel_targetConfiguration_Mcp_SmithyModel_S3_smithyModel_S3_BucketOwnerAccountId = null;
            if (cmdletContext.SmithyModel_S3_BucketOwnerAccountId != null)
            {
                requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_SmithyModel_targetConfiguration_Mcp_SmithyModel_S3_smithyModel_S3_BucketOwnerAccountId = cmdletContext.SmithyModel_S3_BucketOwnerAccountId;
            }
            if (requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_SmithyModel_targetConfiguration_Mcp_SmithyModel_S3_smithyModel_S3_BucketOwnerAccountId != null)
            {
                requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_SmithyModel_targetConfiguration_Mcp_SmithyModel_S3.BucketOwnerAccountId = requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_SmithyModel_targetConfiguration_Mcp_SmithyModel_S3_smithyModel_S3_BucketOwnerAccountId;
                requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_SmithyModel_targetConfiguration_Mcp_SmithyModel_S3IsNull = false;
            }
            System.String requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_SmithyModel_targetConfiguration_Mcp_SmithyModel_S3_smithyModel_S3_Uri = null;
            if (cmdletContext.SmithyModel_S3_Uri != null)
            {
                requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_SmithyModel_targetConfiguration_Mcp_SmithyModel_S3_smithyModel_S3_Uri = cmdletContext.SmithyModel_S3_Uri;
            }
            if (requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_SmithyModel_targetConfiguration_Mcp_SmithyModel_S3_smithyModel_S3_Uri != null)
            {
                requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_SmithyModel_targetConfiguration_Mcp_SmithyModel_S3.Uri = requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_SmithyModel_targetConfiguration_Mcp_SmithyModel_S3_smithyModel_S3_Uri;
                requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_SmithyModel_targetConfiguration_Mcp_SmithyModel_S3IsNull = false;
            }
             // determine if requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_SmithyModel_targetConfiguration_Mcp_SmithyModel_S3 should be set to null
            if (requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_SmithyModel_targetConfiguration_Mcp_SmithyModel_S3IsNull)
            {
                requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_SmithyModel_targetConfiguration_Mcp_SmithyModel_S3 = null;
            }
            if (requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_SmithyModel_targetConfiguration_Mcp_SmithyModel_S3 != null)
            {
                requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_SmithyModel.S3 = requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_SmithyModel_targetConfiguration_Mcp_SmithyModel_S3;
                requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_SmithyModelIsNull = false;
            }
             // determine if requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_SmithyModel should be set to null
            if (requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_SmithyModelIsNull)
            {
                requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_SmithyModel = null;
            }
            if (requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_SmithyModel != null)
            {
                requestTargetConfiguration_targetConfiguration_Mcp.SmithyModel = requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_SmithyModel;
                requestTargetConfiguration_targetConfiguration_McpIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.Model.ApiGatewayTargetConfiguration requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_ApiGateway = null;
            
             // populate ApiGateway
            var requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_ApiGatewayIsNull = true;
            requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_ApiGateway = new Amazon.BedrockAgentCoreControl.Model.ApiGatewayTargetConfiguration();
            System.String requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_ApiGateway_apiGateway_RestApiId = null;
            if (cmdletContext.ApiGateway_RestApiId != null)
            {
                requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_ApiGateway_apiGateway_RestApiId = cmdletContext.ApiGateway_RestApiId;
            }
            if (requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_ApiGateway_apiGateway_RestApiId != null)
            {
                requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_ApiGateway.RestApiId = requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_ApiGateway_apiGateway_RestApiId;
                requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_ApiGatewayIsNull = false;
            }
            System.String requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_ApiGateway_apiGateway_Stage = null;
            if (cmdletContext.ApiGateway_Stage != null)
            {
                requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_ApiGateway_apiGateway_Stage = cmdletContext.ApiGateway_Stage;
            }
            if (requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_ApiGateway_apiGateway_Stage != null)
            {
                requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_ApiGateway.Stage = requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_ApiGateway_apiGateway_Stage;
                requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_ApiGatewayIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.Model.ApiGatewayToolConfiguration requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_ApiGateway_targetConfiguration_Mcp_ApiGateway_ApiGatewayToolConfiguration = null;
            
             // populate ApiGatewayToolConfiguration
            var requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_ApiGateway_targetConfiguration_Mcp_ApiGateway_ApiGatewayToolConfigurationIsNull = true;
            requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_ApiGateway_targetConfiguration_Mcp_ApiGateway_ApiGatewayToolConfiguration = new Amazon.BedrockAgentCoreControl.Model.ApiGatewayToolConfiguration();
            List<Amazon.BedrockAgentCoreControl.Model.ApiGatewayToolFilter> requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_ApiGateway_targetConfiguration_Mcp_ApiGateway_ApiGatewayToolConfiguration_apiGatewayToolConfiguration_ToolFilter = null;
            if (cmdletContext.ApiGatewayToolConfiguration_ToolFilter != null)
            {
                requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_ApiGateway_targetConfiguration_Mcp_ApiGateway_ApiGatewayToolConfiguration_apiGatewayToolConfiguration_ToolFilter = cmdletContext.ApiGatewayToolConfiguration_ToolFilter;
            }
            if (requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_ApiGateway_targetConfiguration_Mcp_ApiGateway_ApiGatewayToolConfiguration_apiGatewayToolConfiguration_ToolFilter != null)
            {
                requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_ApiGateway_targetConfiguration_Mcp_ApiGateway_ApiGatewayToolConfiguration.ToolFilters = requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_ApiGateway_targetConfiguration_Mcp_ApiGateway_ApiGatewayToolConfiguration_apiGatewayToolConfiguration_ToolFilter;
                requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_ApiGateway_targetConfiguration_Mcp_ApiGateway_ApiGatewayToolConfigurationIsNull = false;
            }
            List<Amazon.BedrockAgentCoreControl.Model.ApiGatewayToolOverride> requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_ApiGateway_targetConfiguration_Mcp_ApiGateway_ApiGatewayToolConfiguration_apiGatewayToolConfiguration_ToolOverride = null;
            if (cmdletContext.ApiGatewayToolConfiguration_ToolOverride != null)
            {
                requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_ApiGateway_targetConfiguration_Mcp_ApiGateway_ApiGatewayToolConfiguration_apiGatewayToolConfiguration_ToolOverride = cmdletContext.ApiGatewayToolConfiguration_ToolOverride;
            }
            if (requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_ApiGateway_targetConfiguration_Mcp_ApiGateway_ApiGatewayToolConfiguration_apiGatewayToolConfiguration_ToolOverride != null)
            {
                requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_ApiGateway_targetConfiguration_Mcp_ApiGateway_ApiGatewayToolConfiguration.ToolOverrides = requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_ApiGateway_targetConfiguration_Mcp_ApiGateway_ApiGatewayToolConfiguration_apiGatewayToolConfiguration_ToolOverride;
                requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_ApiGateway_targetConfiguration_Mcp_ApiGateway_ApiGatewayToolConfigurationIsNull = false;
            }
             // determine if requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_ApiGateway_targetConfiguration_Mcp_ApiGateway_ApiGatewayToolConfiguration should be set to null
            if (requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_ApiGateway_targetConfiguration_Mcp_ApiGateway_ApiGatewayToolConfigurationIsNull)
            {
                requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_ApiGateway_targetConfiguration_Mcp_ApiGateway_ApiGatewayToolConfiguration = null;
            }
            if (requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_ApiGateway_targetConfiguration_Mcp_ApiGateway_ApiGatewayToolConfiguration != null)
            {
                requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_ApiGateway.ApiGatewayToolConfiguration = requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_ApiGateway_targetConfiguration_Mcp_ApiGateway_ApiGatewayToolConfiguration;
                requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_ApiGatewayIsNull = false;
            }
             // determine if requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_ApiGateway should be set to null
            if (requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_ApiGatewayIsNull)
            {
                requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_ApiGateway = null;
            }
            if (requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_ApiGateway != null)
            {
                requestTargetConfiguration_targetConfiguration_Mcp.ApiGateway = requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_ApiGateway;
                requestTargetConfiguration_targetConfiguration_McpIsNull = false;
            }
             // determine if requestTargetConfiguration_targetConfiguration_Mcp should be set to null
            if (requestTargetConfiguration_targetConfiguration_McpIsNull)
            {
                requestTargetConfiguration_targetConfiguration_Mcp = null;
            }
            if (requestTargetConfiguration_targetConfiguration_Mcp != null)
            {
                request.TargetConfiguration.Mcp = requestTargetConfiguration_targetConfiguration_Mcp;
                requestTargetConfigurationIsNull = false;
            }
             // determine if request.TargetConfiguration should be set to null
            if (requestTargetConfigurationIsNull)
            {
                request.TargetConfiguration = null;
            }
            if (cmdletContext.TargetId != null)
            {
                request.TargetId = cmdletContext.TargetId;
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
        
        private Amazon.BedrockAgentCoreControl.Model.UpdateGatewayTargetResponse CallAWSServiceOperation(IAmazonBedrockAgentCoreControl client, Amazon.BedrockAgentCoreControl.Model.UpdateGatewayTargetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock Agent Core Control Plane Fronting Layer", "UpdateGatewayTarget");
            try
            {
                return client.UpdateGatewayTargetAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.BedrockAgentCoreControl.Model.CredentialProviderConfiguration> CredentialProviderConfiguration { get; set; }
            public System.String Description { get; set; }
            public System.String GatewayIdentifier { get; set; }
            public List<System.String> MetadataConfiguration_AllowedQueryParameter { get; set; }
            public List<System.String> MetadataConfiguration_AllowedRequestHeader { get; set; }
            public List<System.String> MetadataConfiguration_AllowedResponseHeader { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.BedrockAgentCoreControl.Model.ApiGatewayToolFilter> ApiGatewayToolConfiguration_ToolFilter { get; set; }
            public List<Amazon.BedrockAgentCoreControl.Model.ApiGatewayToolOverride> ApiGatewayToolConfiguration_ToolOverride { get; set; }
            public System.String ApiGateway_RestApiId { get; set; }
            public System.String ApiGateway_Stage { get; set; }
            public System.String Lambda_LambdaArn { get; set; }
            public List<Amazon.BedrockAgentCoreControl.Model.ToolDefinition> ToolSchema_InlinePayload { get; set; }
            public System.String Lambda_ToolSchema_S3_BucketOwnerAccountId { get; set; }
            public System.String Lambda_ToolSchema_S3_Uri { get; set; }
            public System.String McpServer_Endpoint { get; set; }
            public System.String OpenApiSchema_InlinePayload { get; set; }
            public System.String OpenApiSchema_S3_BucketOwnerAccountId { get; set; }
            public System.String OpenApiSchema_S3_Uri { get; set; }
            public System.String SmithyModel_InlinePayload { get; set; }
            public System.String SmithyModel_S3_BucketOwnerAccountId { get; set; }
            public System.String SmithyModel_S3_Uri { get; set; }
            public System.String TargetId { get; set; }
            public System.Func<Amazon.BedrockAgentCoreControl.Model.UpdateGatewayTargetResponse, UpdateBACCGatewayTargetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
