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
using Amazon.ApiGatewayV2;
using Amazon.ApiGatewayV2.Model;

namespace Amazon.PowerShell.Cmdlets.AG2
{
    /// <summary>
    /// Creates a Route for an API.
    /// </summary>
    [Cmdlet("New", "AG2Route", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ApiGatewayV2.Model.CreateRouteResponse")]
    [AWSCmdlet("Calls the Amazon API Gateway V2 CreateRoute API operation.", Operation = new[] {"CreateRoute"}, SelectReturnType = typeof(Amazon.ApiGatewayV2.Model.CreateRouteResponse))]
    [AWSCmdletOutput("Amazon.ApiGatewayV2.Model.CreateRouteResponse",
        "This cmdlet returns an Amazon.ApiGatewayV2.Model.CreateRouteResponse object containing multiple properties."
    )]
    public partial class NewAG2RouteCmdlet : AmazonApiGatewayV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ApiId
        /// <summary>
        /// <para>
        /// <para>The API identifier.</para>
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
        public System.String ApiId { get; set; }
        #endregion
        
        #region Parameter ApiKeyRequired
        /// <summary>
        /// <para>
        /// <para>Specifies whether an API key is required for the route. Supported only for WebSocket
        /// APIs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ApiKeyRequired { get; set; }
        #endregion
        
        #region Parameter AuthorizationScope
        /// <summary>
        /// <para>
        /// <para>The authorization scopes supported by this route.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthorizationScopes")]
        public System.String[] AuthorizationScope { get; set; }
        #endregion
        
        #region Parameter AuthorizationType
        /// <summary>
        /// <para>
        /// <para>The authorization type for the route. For WebSocket APIs, valid values are NONE for
        /// open access, AWS_IAM for using AWS IAM permissions, and CUSTOM for using a Lambda
        /// authorizer For HTTP APIs, valid values are NONE for open access, JWT for using JSON
        /// Web Tokens, AWS_IAM for using AWS IAM permissions, and CUSTOM for using a Lambda authorizer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ApiGatewayV2.AuthorizationType")]
        public Amazon.ApiGatewayV2.AuthorizationType AuthorizationType { get; set; }
        #endregion
        
        #region Parameter AuthorizerId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Authorizer resource to be associated with this route. The authorizer
        /// identifier is generated by API Gateway when you created the authorizer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AuthorizerId { get; set; }
        #endregion
        
        #region Parameter ModelSelectionExpression
        /// <summary>
        /// <para>
        /// <para>The model selection expression for the route. Supported only for WebSocket APIs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ModelSelectionExpression { get; set; }
        #endregion
        
        #region Parameter OperationName
        /// <summary>
        /// <para>
        /// <para>The operation name for the route.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OperationName { get; set; }
        #endregion
        
        #region Parameter RequestModel
        /// <summary>
        /// <para>
        /// <para>The request models for the route. Supported only for WebSocket APIs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RequestModels")]
        public System.Collections.Hashtable RequestModel { get; set; }
        #endregion
        
        #region Parameter RequestParameter
        /// <summary>
        /// <para>
        /// <para>The request parameters for the route. Supported only for WebSocket APIs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RequestParameters")]
        public System.Collections.Hashtable RequestParameter { get; set; }
        #endregion
        
        #region Parameter RouteKey
        /// <summary>
        /// <para>
        /// <para>The route key for the route.</para>
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
        public System.String RouteKey { get; set; }
        #endregion
        
        #region Parameter RouteResponseSelectionExpression
        /// <summary>
        /// <para>
        /// <para>The route response selection expression for the route. Supported only for WebSocket
        /// APIs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RouteResponseSelectionExpression { get; set; }
        #endregion
        
        #region Parameter Target
        /// <summary>
        /// <para>
        /// <para>The target for the route.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Target { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ApiGatewayV2.Model.CreateRouteResponse).
        /// Specifying the name of a property of type Amazon.ApiGatewayV2.Model.CreateRouteResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ApiId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-AG2Route (CreateRoute)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ApiGatewayV2.Model.CreateRouteResponse, NewAG2RouteCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApiId = this.ApiId;
            #if MODULAR
            if (this.ApiId == null && ParameterWasBound(nameof(this.ApiId)))
            {
                WriteWarning("You are passing $null as a value for parameter ApiId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ApiKeyRequired = this.ApiKeyRequired;
            if (this.AuthorizationScope != null)
            {
                context.AuthorizationScope = new List<System.String>(this.AuthorizationScope);
            }
            context.AuthorizationType = this.AuthorizationType;
            context.AuthorizerId = this.AuthorizerId;
            context.ModelSelectionExpression = this.ModelSelectionExpression;
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
                context.RequestParameter = new Dictionary<System.String, Amazon.ApiGatewayV2.Model.ParameterConstraints>(StringComparer.Ordinal);
                foreach (var hashKey in this.RequestParameter.Keys)
                {
                    context.RequestParameter.Add((String)hashKey, (Amazon.ApiGatewayV2.Model.ParameterConstraints)(this.RequestParameter[hashKey]));
                }
            }
            context.RouteKey = this.RouteKey;
            #if MODULAR
            if (this.RouteKey == null && ParameterWasBound(nameof(this.RouteKey)))
            {
                WriteWarning("You are passing $null as a value for parameter RouteKey which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RouteResponseSelectionExpression = this.RouteResponseSelectionExpression;
            context.Target = this.Target;
            
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
            var request = new Amazon.ApiGatewayV2.Model.CreateRouteRequest();
            
            if (cmdletContext.ApiId != null)
            {
                request.ApiId = cmdletContext.ApiId;
            }
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
            if (cmdletContext.ModelSelectionExpression != null)
            {
                request.ModelSelectionExpression = cmdletContext.ModelSelectionExpression;
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
            if (cmdletContext.RouteKey != null)
            {
                request.RouteKey = cmdletContext.RouteKey;
            }
            if (cmdletContext.RouteResponseSelectionExpression != null)
            {
                request.RouteResponseSelectionExpression = cmdletContext.RouteResponseSelectionExpression;
            }
            if (cmdletContext.Target != null)
            {
                request.Target = cmdletContext.Target;
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
        
        private Amazon.ApiGatewayV2.Model.CreateRouteResponse CallAWSServiceOperation(IAmazonApiGatewayV2 client, Amazon.ApiGatewayV2.Model.CreateRouteRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon API Gateway V2", "CreateRoute");
            try
            {
                return client.CreateRouteAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ApiId { get; set; }
            public System.Boolean? ApiKeyRequired { get; set; }
            public List<System.String> AuthorizationScope { get; set; }
            public Amazon.ApiGatewayV2.AuthorizationType AuthorizationType { get; set; }
            public System.String AuthorizerId { get; set; }
            public System.String ModelSelectionExpression { get; set; }
            public System.String OperationName { get; set; }
            public Dictionary<System.String, System.String> RequestModel { get; set; }
            public Dictionary<System.String, Amazon.ApiGatewayV2.Model.ParameterConstraints> RequestParameter { get; set; }
            public System.String RouteKey { get; set; }
            public System.String RouteResponseSelectionExpression { get; set; }
            public System.String Target { get; set; }
            public System.Func<Amazon.ApiGatewayV2.Model.CreateRouteResponse, NewAG2RouteCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
