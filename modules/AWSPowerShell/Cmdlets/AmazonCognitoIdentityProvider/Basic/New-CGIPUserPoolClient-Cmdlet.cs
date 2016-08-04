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
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;

namespace Amazon.PowerShell.Cmdlets.CGIP
{
    /// <summary>
    /// Creates the user pool client.
    /// </summary>
    [Cmdlet("New", "CGIPUserPoolClient", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CognitoIdentityProvider.Model.UserPoolClientType")]
    [AWSCmdlet("Invokes the CreateUserPoolClient operation against Amazon Cognito Identity Provider.", Operation = new[] {"CreateUserPoolClient"})]
    [AWSCmdletOutput("Amazon.CognitoIdentityProvider.Model.UserPoolClientType",
        "This cmdlet returns a UserPoolClientType object.",
        "The service call response (type Amazon.CognitoIdentityProvider.Model.CreateUserPoolClientResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewCGIPUserPoolClientCmdlet : AmazonCognitoIdentityProviderClientCmdlet, IExecutor
    {
        
        #region Parameter ClientName
        /// <summary>
        /// <para>
        /// <para>The client name for the user pool client you would like to create.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientName { get; set; }
        #endregion
        
        #region Parameter ExplicitAuthFlow
        /// <summary>
        /// <para>
        /// <para>The explicit authentication flows.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ExplicitAuthFlows")]
        public System.String[] ExplicitAuthFlow { get; set; }
        #endregion
        
        #region Parameter GenerateSecret
        /// <summary>
        /// <para>
        /// <para> Boolean to specify whether you want to generate a secret for the user pool client
        /// being created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean GenerateSecret { get; set; }
        #endregion
        
        #region Parameter ReadAttribute
        /// <summary>
        /// <para>
        /// <para>The read attributes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ReadAttributes")]
        public System.String[] ReadAttribute { get; set; }
        #endregion
        
        #region Parameter RefreshTokenValidity
        /// <summary>
        /// <para>
        /// <para>Refreshes the token validity.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 RefreshTokenValidity { get; set; }
        #endregion
        
        #region Parameter UserPoolId
        /// <summary>
        /// <para>
        /// <para>The user pool ID for the user pool where you want to create a user pool client.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String UserPoolId { get; set; }
        #endregion
        
        #region Parameter WriteAttribute
        /// <summary>
        /// <para>
        /// <para>The write attributes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WriteAttributes")]
        public System.String[] WriteAttribute { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("UserPoolId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CGIPUserPoolClient (CreateUserPoolClient)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.ClientName = this.ClientName;
            if (this.ExplicitAuthFlow != null)
            {
                context.ExplicitAuthFlows = new List<System.String>(this.ExplicitAuthFlow);
            }
            if (ParameterWasBound("GenerateSecret"))
                context.GenerateSecret = this.GenerateSecret;
            if (this.ReadAttribute != null)
            {
                context.ReadAttributes = new List<System.String>(this.ReadAttribute);
            }
            if (ParameterWasBound("RefreshTokenValidity"))
                context.RefreshTokenValidity = this.RefreshTokenValidity;
            context.UserPoolId = this.UserPoolId;
            if (this.WriteAttribute != null)
            {
                context.WriteAttributes = new List<System.String>(this.WriteAttribute);
            }
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.CognitoIdentityProvider.Model.CreateUserPoolClientRequest();
            
            if (cmdletContext.ClientName != null)
            {
                request.ClientName = cmdletContext.ClientName;
            }
            if (cmdletContext.ExplicitAuthFlows != null)
            {
                request.ExplicitAuthFlows = cmdletContext.ExplicitAuthFlows;
            }
            if (cmdletContext.GenerateSecret != null)
            {
                request.GenerateSecret = cmdletContext.GenerateSecret.Value;
            }
            if (cmdletContext.ReadAttributes != null)
            {
                request.ReadAttributes = cmdletContext.ReadAttributes;
            }
            if (cmdletContext.RefreshTokenValidity != null)
            {
                request.RefreshTokenValidity = cmdletContext.RefreshTokenValidity.Value;
            }
            if (cmdletContext.UserPoolId != null)
            {
                request.UserPoolId = cmdletContext.UserPoolId;
            }
            if (cmdletContext.WriteAttributes != null)
            {
                request.WriteAttributes = cmdletContext.WriteAttributes;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.UserPoolClient;
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
        
        private static Amazon.CognitoIdentityProvider.Model.CreateUserPoolClientResponse CallAWSServiceOperation(IAmazonCognitoIdentityProvider client, Amazon.CognitoIdentityProvider.Model.CreateUserPoolClientRequest request)
        {
            return client.CreateUserPoolClient(request);
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String ClientName { get; set; }
            public List<System.String> ExplicitAuthFlows { get; set; }
            public System.Boolean? GenerateSecret { get; set; }
            public List<System.String> ReadAttributes { get; set; }
            public System.Int32? RefreshTokenValidity { get; set; }
            public System.String UserPoolId { get; set; }
            public List<System.String> WriteAttributes { get; set; }
        }
        
    }
}
