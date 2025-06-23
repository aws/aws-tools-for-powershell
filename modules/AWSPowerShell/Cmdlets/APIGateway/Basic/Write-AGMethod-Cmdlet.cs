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
using Amazon.APIGateway;
using Amazon.APIGateway.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.AG
{
    /// <summary>
    /// Add a method to an existing Resource resource.
    /// </summary>
    [Cmdlet("Write", "AGMethod", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.APIGateway.Model.PutMethodResponse")]
    [AWSCmdlet("Calls the Amazon API Gateway PutMethod API operation.", Operation = new[] {"PutMethod"}, SelectReturnType = typeof(Amazon.APIGateway.Model.PutMethodResponse))]
    [AWSCmdletOutput("Amazon.APIGateway.Model.PutMethodResponse",
        "This cmdlet returns an Amazon.APIGateway.Model.PutMethodResponse object containing multiple properties."
    )]
    public partial class WriteAGMethodCmdlet : AmazonAPIGatewayClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ApiKeyRequired
        /// <summary>
        /// <para>
        /// <para>Specifies whether the method required a valid ApiKey.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ApiKeyRequired { get; set; }
        #endregion
        
        #region Parameter AuthorizationScope
        /// <summary>
        /// <para>
        /// <para>A list of authorization scopes configured on the method. The scopes are used with
        /// a <c>COGNITO_USER_POOLS</c> authorizer to authorize the method invocation. The authorization
        /// works by matching the method scopes against the scopes parsed from the access token
        /// in the incoming request. The method invocation is authorized if any method scopes
        /// matches a claimed scope in the access token. Otherwise, the invocation is not authorized.
        /// When the method scope is configured, the client must provide an access token instead
        /// of an identity token for authorization purposes.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthorizationScopes")]
        public System.String[] AuthorizationScope { get; set; }
        #endregion
        
        #region Parameter AuthorizationType
        /// <summary>
        /// <para>
        /// <para>The method's authorization type. Valid values are <c>NONE</c> for open access, <c>AWS_IAM</c>
        /// for using AWS IAM permissions, <c>CUSTOM</c> for using a custom authorizer, or <c>COGNITO_USER_POOLS</c>
        /// for using a Cognito user pool.</para>
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
        public System.String AuthorizationType { get; set; }
        #endregion
        
        #region Parameter AuthorizerId
        /// <summary>
        /// <para>
        /// <para>Specifies the identifier of an Authorizer to use on this Method, if the type is CUSTOM
        /// or COGNITO_USER_POOLS. The authorizer identifier is generated by API Gateway when
        /// you created the authorizer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AuthorizerId { get; set; }
        #endregion
        
        #region Parameter HttpMethod
        /// <summary>
        /// <para>
        /// <para>Specifies the method request's HTTP method type.</para>
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
        public System.String HttpMethod { get; set; }
        #endregion
        
        #region Parameter OperationName
        /// <summary>
        /// <para>
        /// <para>A human-friendly operation identifier for the method. For example, you can assign
        /// the <c>operationName</c> of <c>ListPets</c> for the <c>GET /pets</c> method in the
        /// <c>PetStore</c> example.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OperationName { get; set; }
        #endregion
        
        #region Parameter RequestModel
        /// <summary>
        /// <para>
        /// <para>Specifies the Model resources used for the request's content type. Request models
        /// are represented as a key/value map, with a content type as the key and a Model name
        /// as the value.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RequestModels")]
        public System.Collections.Hashtable RequestModel { get; set; }
        #endregion
        
        #region Parameter RequestParameter
        /// <summary>
        /// <para>
        /// <para>A key-value map defining required or optional method request parameters that can be
        /// accepted by API Gateway. A key defines a method request parameter name matching the
        /// pattern of <c>method.request.{location}.{name}</c>, where <c>location</c> is <c>querystring</c>,
        /// <c>path</c>, or <c>header</c> and <c>name</c> is a valid and unique parameter name.
        /// The value associated with the key is a Boolean flag indicating whether the parameter
        /// is required (<c>true</c>) or optional (<c>false</c>). The method request parameter
        /// names defined here are available in Integration to be mapped to integration request
        /// parameters or body-mapping templates.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RequestParameters")]
        public System.Collections.Hashtable RequestParameter { get; set; }
        #endregion
        
        #region Parameter RequestValidatorId
        /// <summary>
        /// <para>
        /// <para>The identifier of a RequestValidator for validating the method request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RequestValidatorId { get; set; }
        #endregion
        
        #region Parameter ResourceId
        /// <summary>
        /// <para>
        /// <para>The Resource identifier for the new Method resource.</para>
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
        public System.String ResourceId { get; set; }
        #endregion
        
        #region Parameter RestApiId
        /// <summary>
        /// <para>
        /// <para>The string identifier of the associated RestApi.</para>
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
        public System.String RestApiId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.APIGateway.Model.PutMethodResponse).
        /// Specifying the name of a property of type Amazon.APIGateway.Model.PutMethodResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ResourceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-AGMethod (PutMethod)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.APIGateway.Model.PutMethodResponse, WriteAGMethodCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApiKeyRequired = this.ApiKeyRequired;
            if (this.AuthorizationScope != null)
            {
                context.AuthorizationScope = new List<System.String>(this.AuthorizationScope);
            }
            context.AuthorizationType = this.AuthorizationType;
            #if MODULAR
            if (this.AuthorizationType == null && ParameterWasBound(nameof(this.AuthorizationType)))
            {
                WriteWarning("You are passing $null as a value for parameter AuthorizationType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AuthorizerId = this.AuthorizerId;
            context.HttpMethod = this.HttpMethod;
            #if MODULAR
            if (this.HttpMethod == null && ParameterWasBound(nameof(this.HttpMethod)))
            {
                WriteWarning("You are passing $null as a value for parameter HttpMethod which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OperationName = this.OperationName;
            if (this.RequestModel != null)
            {
                context.RequestModel = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.RequestModel.Keys)
                {
                    context.RequestModel.Add((String)hashKey, (System.String)(this.RequestModel[hashKey]));
                }
            }
            if (this.RequestParameter != null)
            {
                context.RequestParameter = new Dictionary<System.String, System.Boolean>(StringComparer.Ordinal);
                foreach (var hashKey in this.RequestParameter.Keys)
                {
                    context.RequestParameter.Add((String)hashKey, (System.Boolean)(this.RequestParameter[hashKey]));
                }
            }
            context.RequestValidatorId = this.RequestValidatorId;
            context.ResourceId = this.ResourceId;
            #if MODULAR
            if (this.ResourceId == null && ParameterWasBound(nameof(this.ResourceId)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RestApiId = this.RestApiId;
            #if MODULAR
            if (this.RestApiId == null && ParameterWasBound(nameof(this.RestApiId)))
            {
                WriteWarning("You are passing $null as a value for parameter RestApiId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.APIGateway.Model.PutMethodRequest();
            
            if (cmdletContext.ApiKeyRequired != null)
            {
                request.ApiKeyRequired = cmdletContext.ApiKeyRequired.Value;
            }
            if (cmdletContext.AuthorizationScope != null)
            {
                request.AuthorizationScopes = cmdletContext.AuthorizationScope;
            }
            if (cmdletContext.AuthorizationType != null)
            {
                request.AuthorizationType = cmdletContext.AuthorizationType;
            }
            if (cmdletContext.AuthorizerId != null)
            {
                request.AuthorizerId = cmdletContext.AuthorizerId;
            }
            if (cmdletContext.HttpMethod != null)
            {
                request.HttpMethod = cmdletContext.HttpMethod;
            }
            if (cmdletContext.OperationName != null)
            {
                request.OperationName = cmdletContext.OperationName;
            }
            if (cmdletContext.RequestModel != null)
            {
                request.RequestModels = cmdletContext.RequestModel;
            }
            if (cmdletContext.RequestParameter != null)
            {
                request.RequestParameters = cmdletContext.RequestParameter;
            }
            if (cmdletContext.RequestValidatorId != null)
            {
                request.RequestValidatorId = cmdletContext.RequestValidatorId;
            }
            if (cmdletContext.ResourceId != null)
            {
                request.ResourceId = cmdletContext.ResourceId;
            }
            if (cmdletContext.RestApiId != null)
            {
                request.RestApiId = cmdletContext.RestApiId;
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
        
        private Amazon.APIGateway.Model.PutMethodResponse CallAWSServiceOperation(IAmazonAPIGateway client, Amazon.APIGateway.Model.PutMethodRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon API Gateway", "PutMethod");
            try
            {
                return client.PutMethodAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? ApiKeyRequired { get; set; }
            public List<System.String> AuthorizationScope { get; set; }
            public System.String AuthorizationType { get; set; }
            public System.String AuthorizerId { get; set; }
            public System.String HttpMethod { get; set; }
            public System.String OperationName { get; set; }
            public Dictionary<System.String, System.String> RequestModel { get; set; }
            public Dictionary<System.String, System.Boolean> RequestParameter { get; set; }
            public System.String RequestValidatorId { get; set; }
            public System.String ResourceId { get; set; }
            public System.String RestApiId { get; set; }
            public System.Func<Amazon.APIGateway.Model.PutMethodResponse, WriteAGMethodCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
