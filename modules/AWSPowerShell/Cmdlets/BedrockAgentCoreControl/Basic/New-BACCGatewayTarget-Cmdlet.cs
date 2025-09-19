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
    /// Creates a target for a gateway. A target defines an endpoint that the gateway can
    /// connect to.
    /// </summary>
    [Cmdlet("New", "BACCGatewayTarget", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BedrockAgentCoreControl.Model.CreateGatewayTargetResponse")]
    [AWSCmdlet("Calls the Amazon Bedrock Agent Core Control Plane Fronting Layer CreateGatewayTarget API operation.", Operation = new[] {"CreateGatewayTarget"}, SelectReturnType = typeof(Amazon.BedrockAgentCoreControl.Model.CreateGatewayTargetResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgentCoreControl.Model.CreateGatewayTargetResponse",
        "This cmdlet returns an Amazon.BedrockAgentCoreControl.Model.CreateGatewayTargetResponse object containing multiple properties."
    )]
    public partial class NewBACCGatewayTargetCmdlet : AmazonBedrockAgentCoreControlClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
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
        /// <para>The credential provider configurations for the target. These configurations specify
        /// how the gateway authenticates with the target endpoint.</para><para />
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
        [Alias("CredentialProviderConfigurations")]
        public Amazon.BedrockAgentCoreControl.Model.CredentialProviderConfiguration[] CredentialProviderConfiguration { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the gateway target.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter GatewayIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the gateway to create a target for.</para>
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
        /// <para>The name of the gateway target. The name must be unique within the gateway.</para>
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
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier to ensure that the API request completes no more
        /// than one time. If this token matches a previous request, the service ignores the request,
        /// but does not return an error. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/Run_Instance_Idempotency.html">Ensuring
        /// idempotency</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgentCoreControl.Model.CreateGatewayTargetResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgentCoreControl.Model.CreateGatewayTargetResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-BACCGatewayTarget (CreateGatewayTarget)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgentCoreControl.Model.CreateGatewayTargetResponse, NewBACCGatewayTargetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            if (this.CredentialProviderConfiguration != null)
            {
                context.CredentialProviderConfiguration = new List<Amazon.BedrockAgentCoreControl.Model.CredentialProviderConfiguration>(this.CredentialProviderConfiguration);
            }
            #if MODULAR
            if (this.CredentialProviderConfiguration == null && ParameterWasBound(nameof(this.CredentialProviderConfiguration)))
            {
                WriteWarning("You are passing $null as a value for parameter CredentialProviderConfiguration which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            context.GatewayIdentifier = this.GatewayIdentifier;
            #if MODULAR
            if (this.GatewayIdentifier == null && ParameterWasBound(nameof(this.GatewayIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter GatewayIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Lambda_LambdaArn = this.Lambda_LambdaArn;
            if (this.ToolSchema_InlinePayload != null)
            {
                context.ToolSchema_InlinePayload = new List<Amazon.BedrockAgentCoreControl.Model.ToolDefinition>(this.ToolSchema_InlinePayload);
            }
            context.Lambda_ToolSchema_S3_BucketOwnerAccountId = this.Lambda_ToolSchema_S3_BucketOwnerAccountId;
            context.Lambda_ToolSchema_S3_Uri = this.Lambda_ToolSchema_S3_Uri;
            context.OpenApiSchema_InlinePayload = this.OpenApiSchema_InlinePayload;
            context.OpenApiSchema_S3_BucketOwnerAccountId = this.OpenApiSchema_S3_BucketOwnerAccountId;
            context.OpenApiSchema_S3_Uri = this.OpenApiSchema_S3_Uri;
            context.SmithyModel_InlinePayload = this.SmithyModel_InlinePayload;
            context.SmithyModel_S3_BucketOwnerAccountId = this.SmithyModel_S3_BucketOwnerAccountId;
            context.SmithyModel_S3_Uri = this.SmithyModel_S3_Uri;
            
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
            var request = new Amazon.BedrockAgentCoreControl.Model.CreateGatewayTargetRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
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
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate TargetConfiguration
            request.TargetConfiguration = new Amazon.BedrockAgentCoreControl.Model.TargetConfiguration();
            Amazon.BedrockAgentCoreControl.Model.McpTargetConfiguration requestTargetConfiguration_targetConfiguration_Mcp = null;
            
             // populate Mcp
            var requestTargetConfiguration_targetConfiguration_McpIsNull = true;
            requestTargetConfiguration_targetConfiguration_Mcp = new Amazon.BedrockAgentCoreControl.Model.McpTargetConfiguration();
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
            requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_Lambda_targetConfiguration_Mcp_Lambda_ToolSchema = new Amazon.BedrockAgentCoreControl.Model.ToolSchema();
            List<Amazon.BedrockAgentCoreControl.Model.ToolDefinition> requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_Lambda_targetConfiguration_Mcp_Lambda_ToolSchema_toolSchema_InlinePayload = null;
            if (cmdletContext.ToolSchema_InlinePayload != null)
            {
                requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_Lambda_targetConfiguration_Mcp_Lambda_ToolSchema_toolSchema_InlinePayload = cmdletContext.ToolSchema_InlinePayload;
            }
            if (requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_Lambda_targetConfiguration_Mcp_Lambda_ToolSchema_toolSchema_InlinePayload != null)
            {
                requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_Lambda_targetConfiguration_Mcp_Lambda_ToolSchema.InlinePayload = requestTargetConfiguration_targetConfiguration_Mcp_targetConfiguration_Mcp_Lambda_targetConfiguration_Mcp_Lambda_ToolSchema_toolSchema_InlinePayload;
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
             // determine if requestTargetConfiguration_targetConfiguration_Mcp should be set to null
            if (requestTargetConfiguration_targetConfiguration_McpIsNull)
            {
                requestTargetConfiguration_targetConfiguration_Mcp = null;
            }
            if (requestTargetConfiguration_targetConfiguration_Mcp != null)
            {
                request.TargetConfiguration.Mcp = requestTargetConfiguration_targetConfiguration_Mcp;
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
        
        private Amazon.BedrockAgentCoreControl.Model.CreateGatewayTargetResponse CallAWSServiceOperation(IAmazonBedrockAgentCoreControl client, Amazon.BedrockAgentCoreControl.Model.CreateGatewayTargetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock Agent Core Control Plane Fronting Layer", "CreateGatewayTarget");
            try
            {
                return client.CreateGatewayTargetAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public List<Amazon.BedrockAgentCoreControl.Model.CredentialProviderConfiguration> CredentialProviderConfiguration { get; set; }
            public System.String Description { get; set; }
            public System.String GatewayIdentifier { get; set; }
            public System.String Name { get; set; }
            public System.String Lambda_LambdaArn { get; set; }
            public List<Amazon.BedrockAgentCoreControl.Model.ToolDefinition> ToolSchema_InlinePayload { get; set; }
            public System.String Lambda_ToolSchema_S3_BucketOwnerAccountId { get; set; }
            public System.String Lambda_ToolSchema_S3_Uri { get; set; }
            public System.String OpenApiSchema_InlinePayload { get; set; }
            public System.String OpenApiSchema_S3_BucketOwnerAccountId { get; set; }
            public System.String OpenApiSchema_S3_Uri { get; set; }
            public System.String SmithyModel_InlinePayload { get; set; }
            public System.String SmithyModel_S3_BucketOwnerAccountId { get; set; }
            public System.String SmithyModel_S3_Uri { get; set; }
            public System.Func<Amazon.BedrockAgentCoreControl.Model.CreateGatewayTargetResponse, NewBACCGatewayTargetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
