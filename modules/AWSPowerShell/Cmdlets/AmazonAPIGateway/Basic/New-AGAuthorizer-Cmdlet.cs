/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.APIGateway;
using Amazon.APIGateway.Model;

namespace Amazon.PowerShell.Cmdlets.AG
{
    /// <summary>
    /// Adds a new <a>Authorizer</a> resource to an existing <a>RestApi</a> resource.
    /// </summary>
    [Cmdlet("New", "AGAuthorizer", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.APIGateway.Model.CreateAuthorizerResponse")]
    [AWSCmdlet("Invokes the CreateAuthorizer operation against Amazon API Gateway.", Operation = new[] {"CreateAuthorizer"})]
    [AWSCmdletOutput("Amazon.APIGateway.Model.CreateAuthorizerResponse",
        "This cmdlet returns a Amazon.APIGateway.Model.CreateAuthorizerResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewAGAuthorizerCmdlet : AmazonAPIGatewayClientCmdlet, IExecutor
    {
        
        #region Parameter AuthorizerCredential
        /// <summary>
        /// <para>
        /// <para>Specifies the credentials required for the authorizer, if any.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AuthorizerCredentials")]
        public System.String AuthorizerCredential { get; set; }
        #endregion
        
        #region Parameter AuthorizerResultTtlInSecond
        /// <summary>
        /// <para>
        /// <para>The TTL of cached authorizer results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AuthorizerResultTtlInSeconds")]
        public System.Int32 AuthorizerResultTtlInSecond { get; set; }
        #endregion
        
        #region Parameter AuthorizerUri
        /// <summary>
        /// <para>
        /// <para>[Required] Specifies the authorizer's Uniform Resource Identifier (URI).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AuthorizerUri { get; set; }
        #endregion
        
        #region Parameter AuthType
        /// <summary>
        /// <para>
        /// <para>Optional customer-defined field, used in Swagger imports/exports. Has no functional
        /// impact.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AuthType { get; set; }
        #endregion
        
        #region Parameter IdentitySource
        /// <summary>
        /// <para>
        /// <para>[Required] The source of the identity in an incoming request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String IdentitySource { get; set; }
        #endregion
        
        #region Parameter IdentityValidationExpression
        /// <summary>
        /// <para>
        /// <para>A validation expression for the incoming identity.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String IdentityValidationExpression { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>[Required] The name of the authorizer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter RestApiId
        /// <summary>
        /// <para>
        /// <para>The <a>RestApi</a> identifier under which the <a>Authorizer</a> will be created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String RestApiId { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>[Required] The type of the authorizer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.APIGateway.AuthorizerType")]
        public Amazon.APIGateway.AuthorizerType Type { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("RestApiId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-AGAuthorizer (CreateAuthorizer)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.AuthorizerCredentials = this.AuthorizerCredential;
            if (ParameterWasBound("AuthorizerResultTtlInSecond"))
                context.AuthorizerResultTtlInSeconds = this.AuthorizerResultTtlInSecond;
            context.AuthorizerUri = this.AuthorizerUri;
            context.AuthType = this.AuthType;
            context.IdentitySource = this.IdentitySource;
            context.IdentityValidationExpression = this.IdentityValidationExpression;
            context.Name = this.Name;
            context.RestApiId = this.RestApiId;
            context.Type = this.Type;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.APIGateway.Model.CreateAuthorizerRequest();
            
            if (cmdletContext.AuthorizerCredentials != null)
            {
                request.AuthorizerCredentials = cmdletContext.AuthorizerCredentials;
            }
            if (cmdletContext.AuthorizerResultTtlInSeconds != null)
            {
                request.AuthorizerResultTtlInSeconds = cmdletContext.AuthorizerResultTtlInSeconds.Value;
            }
            if (cmdletContext.AuthorizerUri != null)
            {
                request.AuthorizerUri = cmdletContext.AuthorizerUri;
            }
            if (cmdletContext.AuthType != null)
            {
                request.AuthType = cmdletContext.AuthType;
            }
            if (cmdletContext.IdentitySource != null)
            {
                request.IdentitySource = cmdletContext.IdentitySource;
            }
            if (cmdletContext.IdentityValidationExpression != null)
            {
                request.IdentityValidationExpression = cmdletContext.IdentityValidationExpression;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.RestApiId != null)
            {
                request.RestApiId = cmdletContext.RestApiId;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.CreateAuthorizer(request);
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String AuthorizerCredentials { get; set; }
            public System.Int32? AuthorizerResultTtlInSeconds { get; set; }
            public System.String AuthorizerUri { get; set; }
            public System.String AuthType { get; set; }
            public System.String IdentitySource { get; set; }
            public System.String IdentityValidationExpression { get; set; }
            public System.String Name { get; set; }
            public System.String RestApiId { get; set; }
            public Amazon.APIGateway.AuthorizerType Type { get; set; }
        }
        
    }
}
