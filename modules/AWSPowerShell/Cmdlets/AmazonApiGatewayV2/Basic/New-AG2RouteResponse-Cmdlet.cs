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
    /// Creates a RouteResponse for a Route.
    /// </summary>
    [Cmdlet("New", "AG2RouteResponse", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ApiGatewayV2.Model.CreateRouteResponseResponse")]
    [AWSCmdlet("Calls the Amazon API Gateway V2 CreateRouteResponse API operation.", Operation = new[] {"CreateRouteResponse"})]
    [AWSCmdletOutput("Amazon.ApiGatewayV2.Model.CreateRouteResponseResponse",
        "This cmdlet returns a Amazon.ApiGatewayV2.Model.CreateRouteResponseResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewAG2RouteResponseCmdlet : AmazonApiGatewayV2ClientCmdlet, IExecutor
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
        
        #region Parameter ModelSelectionExpression
        /// <summary>
        /// <para>
        /// <para>The model selection expression for the route response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ModelSelectionExpression { get; set; }
        #endregion
        
        #region Parameter ResponseModel
        /// <summary>
        /// <para>
        /// <para>The response models for the route response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ResponseModels")]
        public System.Collections.Hashtable ResponseModel { get; set; }
        #endregion
        
        #region Parameter ResponseParameter
        /// <summary>
        /// <para>
        /// <para>The route response parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ResponseParameters")]
        public System.Collections.Hashtable ResponseParameter { get; set; }
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
        
        #region Parameter RouteResponseKey
        /// <summary>
        /// <para>
        /// <para>The route response key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RouteResponseKey { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-AG2RouteResponse (CreateRouteResponse)"))
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
            context.ModelSelectionExpression = this.ModelSelectionExpression;
            if (this.ResponseModel != null)
            {
                context.ResponseModels = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.ResponseModel.Keys)
                {
                    context.ResponseModels.Add((String)hashKey, (String)(this.ResponseModel[hashKey]));
                }
            }
            if (this.ResponseParameter != null)
            {
                context.ResponseParameters = new Dictionary<System.String, Amazon.ApiGatewayV2.Model.ParameterConstraints>(StringComparer.Ordinal);
                foreach (var hashKey in this.ResponseParameter.Keys)
                {
                    context.ResponseParameters.Add((String)hashKey, (ParameterConstraints)(this.ResponseParameter[hashKey]));
                }
            }
            context.RouteId = this.RouteId;
            context.RouteResponseKey = this.RouteResponseKey;
            
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
            var request = new Amazon.ApiGatewayV2.Model.CreateRouteResponseRequest();
            
            if (cmdletContext.ApiId != null)
            {
                request.ApiId = cmdletContext.ApiId;
            }
            if (cmdletContext.ModelSelectionExpression != null)
            {
                request.ModelSelectionExpression = cmdletContext.ModelSelectionExpression;
            }
            if (cmdletContext.ResponseModels != null)
            {
                request.ResponseModels = cmdletContext.ResponseModels;
            }
            if (cmdletContext.ResponseParameters != null)
            {
                request.ResponseParameters = cmdletContext.ResponseParameters;
            }
            if (cmdletContext.RouteId != null)
            {
                request.RouteId = cmdletContext.RouteId;
            }
            if (cmdletContext.RouteResponseKey != null)
            {
                request.RouteResponseKey = cmdletContext.RouteResponseKey;
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
        
        private Amazon.ApiGatewayV2.Model.CreateRouteResponseResponse CallAWSServiceOperation(IAmazonApiGatewayV2 client, Amazon.ApiGatewayV2.Model.CreateRouteResponseRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon API Gateway V2", "CreateRouteResponse");
            try
            {
                #if DESKTOP
                return client.CreateRouteResponse(request);
                #elif CORECLR
                return client.CreateRouteResponseAsync(request).GetAwaiter().GetResult();
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
            public System.String ModelSelectionExpression { get; set; }
            public Dictionary<System.String, System.String> ResponseModels { get; set; }
            public Dictionary<System.String, Amazon.ApiGatewayV2.Model.ParameterConstraints> ResponseParameters { get; set; }
            public System.String RouteId { get; set; }
            public System.String RouteResponseKey { get; set; }
        }
        
    }
}
