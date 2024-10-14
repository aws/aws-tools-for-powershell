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
using Amazon.ConfigService;
using Amazon.ConfigService.Model;

namespace Amazon.PowerShell.Cmdlets.CFG
{
    /// <summary>
    /// Runs an on-demand evaluation for the specified resource to determine whether the resource
    /// details will comply with configured Config rules. You can also use it for evaluation
    /// purposes. Config recommends using an evaluation context. It runs an execution against
    /// the resource details with all of the Config rules in your account that match with
    /// the specified proactive mode and resource type.
    /// 
    ///  <note><para>
    /// Ensure you have the <c>cloudformation:DescribeType</c> role setup to validate the
    /// resource type schema.
    /// </para><para>
    /// You can find the <a href="https://docs.aws.amazon.com/cloudformation-cli/latest/userguide/resource-type-schema.html">Resource
    /// type schema</a> in "<i>Amazon Web Services public extensions</i>" within the CloudFormation
    /// registry or with the following CLI commmand: <c>aws cloudformation describe-type --type-name
    /// "AWS::S3::Bucket" --type RESOURCE</c>.
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/registry.html#registry-view">Managing
    /// extensions through the CloudFormation registry</a> and <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/aws-template-resource-type-ref.html">Amazon
    /// Web Services resource and property types reference</a> in the CloudFormation User
    /// Guide.
    /// </para></note>
    /// </summary>
    [Cmdlet("Start", "CFGResourceEvaluation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Config StartResourceEvaluation API operation.", Operation = new[] {"StartResourceEvaluation"}, SelectReturnType = typeof(Amazon.ConfigService.Model.StartResourceEvaluationResponse))]
    [AWSCmdletOutput("System.String or Amazon.ConfigService.Model.StartResourceEvaluationResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.ConfigService.Model.StartResourceEvaluationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartCFGResourceEvaluationCmdlet : AmazonConfigServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter EvaluationContext_EvaluationContextIdentifier
        /// <summary>
        /// <para>
        /// <para>A unique EvaluationContextIdentifier ID for an EvaluationContext.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EvaluationContext_EvaluationContextIdentifier { get; set; }
        #endregion
        
        #region Parameter EvaluationMode
        /// <summary>
        /// <para>
        /// <para>The mode of an evaluation. The valid values for this API are <c>DETECTIVE</c> and
        /// <c>PROACTIVE</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ConfigService.EvaluationMode")]
        public Amazon.ConfigService.EvaluationMode EvaluationMode { get; set; }
        #endregion
        
        #region Parameter EvaluationTimeout
        /// <summary>
        /// <para>
        /// <para>The timeout for an evaluation. The default is 900 seconds. You cannot specify a number
        /// greater than 3600. If you specify 0, Config uses the default.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? EvaluationTimeout { get; set; }
        #endregion
        
        #region Parameter ResourceDetails_ResourceConfiguration
        /// <summary>
        /// <para>
        /// <para>The resource definition to be evaluated as per the resource configuration schema type.</para>
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
        public System.String ResourceDetails_ResourceConfiguration { get; set; }
        #endregion
        
        #region Parameter ResourceDetails_ResourceConfigurationSchemaType
        /// <summary>
        /// <para>
        /// <para>The schema type of the resource configuration.</para><note><para>You can find the <a href="https://docs.aws.amazon.com/cloudformation-cli/latest/userguide/resource-type-schema.html">Resource
        /// type schema</a>, or <c>CFN_RESOURCE_SCHEMA</c>, in "<i>Amazon Web Services public
        /// extensions</i>" within the CloudFormation registry or with the following CLI commmand:
        /// <c>aws cloudformation describe-type --type-name "AWS::S3::Bucket" --type RESOURCE</c>.</para><para>For more information, see <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/registry.html#registry-view">Managing
        /// extensions through the CloudFormation registry</a> and <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/aws-template-resource-type-ref.html">Amazon
        /// Web Services resource and property types reference</a> in the CloudFormation User
        /// Guide.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ConfigService.ResourceConfigurationSchemaType")]
        public Amazon.ConfigService.ResourceConfigurationSchemaType ResourceDetails_ResourceConfigurationSchemaType { get; set; }
        #endregion
        
        #region Parameter ResourceDetails_ResourceId
        /// <summary>
        /// <para>
        /// <para>A unique resource ID for an evaluation.</para>
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
        public System.String ResourceDetails_ResourceId { get; set; }
        #endregion
        
        #region Parameter ResourceDetails_ResourceType
        /// <summary>
        /// <para>
        /// <para>The type of resource being evaluated.</para>
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
        public System.String ResourceDetails_ResourceType { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A client token is a unique, case-sensitive string of up to 64 ASCII characters. To
        /// make an idempotent API request using one of these actions, specify a client token
        /// in the request.</para><note><para>Avoid reusing the same client token for other API requests. If you retry a request
        /// that completed successfully using the same client token and the same parameters, the
        /// retry succeeds without performing any further actions. If you retry a successful request
        /// using the same client token, but one or more of the parameters are different, other
        /// than the Region or Availability Zone, the retry fails with an IdempotentParameterMismatch
        /// error.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ResourceEvaluationId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ConfigService.Model.StartResourceEvaluationResponse).
        /// Specifying the name of a property of type Amazon.ConfigService.Model.StartResourceEvaluationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ResourceEvaluationId";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the EvaluationMode parameter.
        /// The -PassThru parameter is deprecated, use -Select '^EvaluationMode' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^EvaluationMode' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ResourceDetails_ResourceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-CFGResourceEvaluation (StartResourceEvaluation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ConfigService.Model.StartResourceEvaluationResponse, StartCFGResourceEvaluationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.EvaluationMode;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            context.EvaluationContext_EvaluationContextIdentifier = this.EvaluationContext_EvaluationContextIdentifier;
            context.EvaluationMode = this.EvaluationMode;
            #if MODULAR
            if (this.EvaluationMode == null && ParameterWasBound(nameof(this.EvaluationMode)))
            {
                WriteWarning("You are passing $null as a value for parameter EvaluationMode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EvaluationTimeout = this.EvaluationTimeout;
            context.ResourceDetails_ResourceConfiguration = this.ResourceDetails_ResourceConfiguration;
            #if MODULAR
            if (this.ResourceDetails_ResourceConfiguration == null && ParameterWasBound(nameof(this.ResourceDetails_ResourceConfiguration)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceDetails_ResourceConfiguration which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ResourceDetails_ResourceConfigurationSchemaType = this.ResourceDetails_ResourceConfigurationSchemaType;
            context.ResourceDetails_ResourceId = this.ResourceDetails_ResourceId;
            #if MODULAR
            if (this.ResourceDetails_ResourceId == null && ParameterWasBound(nameof(this.ResourceDetails_ResourceId)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceDetails_ResourceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ResourceDetails_ResourceType = this.ResourceDetails_ResourceType;
            #if MODULAR
            if (this.ResourceDetails_ResourceType == null && ParameterWasBound(nameof(this.ResourceDetails_ResourceType)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceDetails_ResourceType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ConfigService.Model.StartResourceEvaluationRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate EvaluationContext
            var requestEvaluationContextIsNull = true;
            request.EvaluationContext = new Amazon.ConfigService.Model.EvaluationContext();
            System.String requestEvaluationContext_evaluationContext_EvaluationContextIdentifier = null;
            if (cmdletContext.EvaluationContext_EvaluationContextIdentifier != null)
            {
                requestEvaluationContext_evaluationContext_EvaluationContextIdentifier = cmdletContext.EvaluationContext_EvaluationContextIdentifier;
            }
            if (requestEvaluationContext_evaluationContext_EvaluationContextIdentifier != null)
            {
                request.EvaluationContext.EvaluationContextIdentifier = requestEvaluationContext_evaluationContext_EvaluationContextIdentifier;
                requestEvaluationContextIsNull = false;
            }
             // determine if request.EvaluationContext should be set to null
            if (requestEvaluationContextIsNull)
            {
                request.EvaluationContext = null;
            }
            if (cmdletContext.EvaluationMode != null)
            {
                request.EvaluationMode = cmdletContext.EvaluationMode;
            }
            if (cmdletContext.EvaluationTimeout != null)
            {
                request.EvaluationTimeout = cmdletContext.EvaluationTimeout.Value;
            }
            
             // populate ResourceDetails
            var requestResourceDetailsIsNull = true;
            request.ResourceDetails = new Amazon.ConfigService.Model.ResourceDetails();
            System.String requestResourceDetails_resourceDetails_ResourceConfiguration = null;
            if (cmdletContext.ResourceDetails_ResourceConfiguration != null)
            {
                requestResourceDetails_resourceDetails_ResourceConfiguration = cmdletContext.ResourceDetails_ResourceConfiguration;
            }
            if (requestResourceDetails_resourceDetails_ResourceConfiguration != null)
            {
                request.ResourceDetails.ResourceConfiguration = requestResourceDetails_resourceDetails_ResourceConfiguration;
                requestResourceDetailsIsNull = false;
            }
            Amazon.ConfigService.ResourceConfigurationSchemaType requestResourceDetails_resourceDetails_ResourceConfigurationSchemaType = null;
            if (cmdletContext.ResourceDetails_ResourceConfigurationSchemaType != null)
            {
                requestResourceDetails_resourceDetails_ResourceConfigurationSchemaType = cmdletContext.ResourceDetails_ResourceConfigurationSchemaType;
            }
            if (requestResourceDetails_resourceDetails_ResourceConfigurationSchemaType != null)
            {
                request.ResourceDetails.ResourceConfigurationSchemaType = requestResourceDetails_resourceDetails_ResourceConfigurationSchemaType;
                requestResourceDetailsIsNull = false;
            }
            System.String requestResourceDetails_resourceDetails_ResourceId = null;
            if (cmdletContext.ResourceDetails_ResourceId != null)
            {
                requestResourceDetails_resourceDetails_ResourceId = cmdletContext.ResourceDetails_ResourceId;
            }
            if (requestResourceDetails_resourceDetails_ResourceId != null)
            {
                request.ResourceDetails.ResourceId = requestResourceDetails_resourceDetails_ResourceId;
                requestResourceDetailsIsNull = false;
            }
            System.String requestResourceDetails_resourceDetails_ResourceType = null;
            if (cmdletContext.ResourceDetails_ResourceType != null)
            {
                requestResourceDetails_resourceDetails_ResourceType = cmdletContext.ResourceDetails_ResourceType;
            }
            if (requestResourceDetails_resourceDetails_ResourceType != null)
            {
                request.ResourceDetails.ResourceType = requestResourceDetails_resourceDetails_ResourceType;
                requestResourceDetailsIsNull = false;
            }
             // determine if request.ResourceDetails should be set to null
            if (requestResourceDetailsIsNull)
            {
                request.ResourceDetails = null;
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
        
        private Amazon.ConfigService.Model.StartResourceEvaluationResponse CallAWSServiceOperation(IAmazonConfigService client, Amazon.ConfigService.Model.StartResourceEvaluationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Config", "StartResourceEvaluation");
            try
            {
                #if DESKTOP
                return client.StartResourceEvaluation(request);
                #elif CORECLR
                return client.StartResourceEvaluationAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String EvaluationContext_EvaluationContextIdentifier { get; set; }
            public Amazon.ConfigService.EvaluationMode EvaluationMode { get; set; }
            public System.Int32? EvaluationTimeout { get; set; }
            public System.String ResourceDetails_ResourceConfiguration { get; set; }
            public Amazon.ConfigService.ResourceConfigurationSchemaType ResourceDetails_ResourceConfigurationSchemaType { get; set; }
            public System.String ResourceDetails_ResourceId { get; set; }
            public System.String ResourceDetails_ResourceType { get; set; }
            public System.Func<Amazon.ConfigService.Model.StartResourceEvaluationResponse, StartCFGResourceEvaluationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ResourceEvaluationId;
        }
        
    }
}
