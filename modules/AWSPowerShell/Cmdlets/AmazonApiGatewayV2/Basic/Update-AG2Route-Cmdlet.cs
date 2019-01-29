/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.ApiGatewayV2;
using Amazon.ApiGatewayV2.Model;

namespace Amazon.PowerShell.Cmdlets.AG2
{
    /// <summary>
    /// Updates a Route.
    /// </summary>
    [Cmdlet("Update", "AG2Route", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ApiGatewayV2.Model.UpdateRouteResponse")]
    [AWSCmdlet("Calls the Amazon API Gateway V2 UpdateRoute API operation.", Operation = new[] {"UpdateRoute"})]
    [AWSCmdletOutput("Amazon.ApiGatewayV2.Model.UpdateRouteResponse",
        "This cmdlet returns a Amazon.ApiGatewayV2.Model.UpdateRouteResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateAG2RouteCmdlet : AmazonApiGatewayV2ClientCmdlet, IExecutor
    {
        
        #region Parameter ApiId
        /// <summary>
        /// <para>
        /// <para>The API identifier.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ApiId { get; set; }
        #endregion
        
        #region Parameter ApiKeyRequired
        /// <summary>
        /// <para>
        /// <para>Specifies whether an API key is required for the route.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean ApiKeyRequired { get; set; }
        #endregion
        
        #region Parameter AuthorizationScope
        /// <summary>
        /// <para>
        /// <para>The authorization scopes supported by this route.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AuthorizationScopes")]
        public System.String[] AuthorizationScope { get; set; }
        #endregion
        
        #region Parameter AuthorizationType
        /// <summary>
        /// <para>
        /// <para>The authorization type for the route. Valid values are NONE for open access, AWS_IAM
        /// for using AWS IAM permissions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.ApiGatewayV2.AuthorizationType")]
        public Amazon.ApiGatewayV2.AuthorizationType AuthorizationType { get; set; }
        #endregion
        
        #region Parameter AuthorizerId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Authorizer resource to be associated with this route.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AuthorizerId { get; set; }
        #endregion
        
        #region Parameter ModelSelectionExpression
        /// <summary>
        /// <para>
        /// <para>The model selection expression for the route.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ModelSelectionExpression { get; set; }
        #endregion
        
        #region Parameter OperationName
        /// <summary>
        /// <para>
        /// <para>The operation name for the route.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String OperationName { get; set; }
        #endregion
        
        #region Parameter RequestModel
        /// <summary>
        /// <para>
        /// <para>The request models for the route.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("RequestModels")]
        public System.Collections.Hashtable RequestModel { get; set; }
        #endregion
        
        #region Parameter RequestParameter
        /// <summary>
        /// <para>
        /// <para>The request parameters for the route.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("RequestParameters")]
        public System.Collections.Hashtable RequestParameter { get; set; }
        #endregion
        
        #region Parameter RouteId
        /// <summary>
        /// <para>
        /// <para>The route ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RouteId { get; set; }
        #endregion
        
        #region Parameter RouteKey
        /// <summary>
        /// <para>
        /// <para>The route key for the route.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RouteKey { get; set; }
        #endregion
        
        #region Parameter RouteResponseSelectionExpression
        /// <summary>
        /// <para>
        /// <para>The route response selection expression for the route.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RouteResponseSelectionExpression { get; set; }
        #endregion
        
        #region Parameter Target
        /// <summary>
        /// <para>
        /// <para>The target for the route.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Target { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("RouteId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-AG2Route (UpdateRoute)"))
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
            
            context.ApiId = this.ApiId;
            if (ParameterWasBound("ApiKeyRequired"))
                context.ApiKeyRequired = this.ApiKeyRequired;
            if (this.AuthorizationScope != null)
            {
                context.AuthorizationScopes = new List<System.String>(this.AuthorizationScope);
            }
            context.AuthorizationType = this.AuthorizationType;
            context.AuthorizerId = this.AuthorizerId;
            context.ModelSelectionExpression = this.ModelSelectionExpression;
            context.OperationName = this.OperationName;
            if (this.RequestModel != null)
            {
                context.RequestModels = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.RequestModel.Keys)
                {
                    context.RequestModels.Add((String)hashKey, (String)(this.RequestModel[hashKey]));
                }
            }
            if (this.RequestParameter != null)
            {
                context.RequestParameters = new Dictionary<System.String, Amazon.ApiGatewayV2.Model.ParameterConstraints>(StringComparer.Ordinal);
                foreach (var hashKey in this.RequestParameter.Keys)
                {
                    context.RequestParameters.Add((String)hashKey, (ParameterConstraints)(this.RequestParameter[hashKey]));
                }
            }
            context.RouteId = this.RouteId;
            context.RouteKey = this.RouteKey;
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
            var request = new Amazon.ApiGatewayV2.Model.UpdateRouteRequest();
            
            if (cmdletContext.ApiId != null)
            {
                request.ApiId = cmdletContext.ApiId;
            }
            if (cmdletContext.ApiKeyRequired != null)
            {
                request.ApiKeyRequired = cmdletContext.ApiKeyRequired.Value;
            }
            if (cmdletContext.AuthorizationScopes != null)
            {
                request.AuthorizationScopes = cmdletContext.AuthorizationScopes;
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
            if (cmdletContext.RequestModels != null)
            {
                request.RequestModels = cmdletContext.RequestModels;
            }
            if (cmdletContext.RequestParameters != null)
            {
                request.RequestParameters = cmdletContext.RequestParameters;
            }
            if (cmdletContext.RouteId != null)
            {
                request.RouteId = cmdletContext.RouteId;
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
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
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
        
        private Amazon.ApiGatewayV2.Model.UpdateRouteResponse CallAWSServiceOperation(IAmazonApiGatewayV2 client, Amazon.ApiGatewayV2.Model.UpdateRouteRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon API Gateway V2", "UpdateRoute");
            try
            {
                #if DESKTOP
                return client.UpdateRoute(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.UpdateRouteAsync(request);
                return task.Result;
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
            public System.String ApiId { get; set; }
            public System.Boolean? ApiKeyRequired { get; set; }
            public List<System.String> AuthorizationScopes { get; set; }
            public Amazon.ApiGatewayV2.AuthorizationType AuthorizationType { get; set; }
            public System.String AuthorizerId { get; set; }
            public System.String ModelSelectionExpression { get; set; }
            public System.String OperationName { get; set; }
            public Dictionary<System.String, System.String> RequestModels { get; set; }
            public Dictionary<System.String, Amazon.ApiGatewayV2.Model.ParameterConstraints> RequestParameters { get; set; }
            public System.String RouteId { get; set; }
            public System.String RouteKey { get; set; }
            public System.String RouteResponseSelectionExpression { get; set; }
            public System.String Target { get; set; }
        }
        
    }
}
