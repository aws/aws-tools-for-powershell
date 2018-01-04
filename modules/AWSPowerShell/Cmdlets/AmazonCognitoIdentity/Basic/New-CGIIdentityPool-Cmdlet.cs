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
using Amazon.CognitoIdentity;
using Amazon.CognitoIdentity.Model;

namespace Amazon.PowerShell.Cmdlets.CGI
{
    /// <summary>
    /// Creates a new identity pool. The identity pool is a store of user identity information
    /// that is specific to your AWS account. The limit on identity pools is 60 per account.
    /// The keys for <code>SupportedLoginProviders</code> are as follows:
    /// 
    ///  <ul><li><para>
    /// Facebook: <code>graph.facebook.com</code></para></li><li><para>
    /// Google: <code>accounts.google.com</code></para></li><li><para>
    /// Amazon: <code>www.amazon.com</code></para></li><li><para>
    /// Twitter: <code>api.twitter.com</code></para></li><li><para>
    /// Digits: <code>www.digits.com</code></para></li></ul><para>
    /// You must use AWS Developer credentials to call this API.
    /// </para>
    /// </summary>
    [Cmdlet("New", "CGIIdentityPool", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CognitoIdentity.Model.CreateIdentityPoolResponse")]
    [AWSCmdlet("Calls the Amazon Cognito Identity CreateIdentityPool API operation.", Operation = new[] {"CreateIdentityPool"})]
    [AWSCmdletOutput("Amazon.CognitoIdentity.Model.CreateIdentityPoolResponse",
        "This cmdlet returns a Amazon.CognitoIdentity.Model.CreateIdentityPoolResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewCGIIdentityPoolCmdlet : AmazonCognitoIdentityClientCmdlet, IExecutor
    {
        
        #region Parameter AllowUnauthenticatedIdentity
        /// <summary>
        /// <para>
        /// <para>TRUE if the identity pool supports unauthenticated logins.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AllowUnauthenticatedIdentities")]
        public System.Boolean AllowUnauthenticatedIdentity { get; set; }
        #endregion
        
        #region Parameter CognitoIdentityProvider
        /// <summary>
        /// <para>
        /// <para>An array of Amazon Cognito Identity user pools and their client IDs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("CognitoIdentityProviders")]
        public Amazon.CognitoIdentity.Model.CognitoIdentityProviderInfo[] CognitoIdentityProvider { get; set; }
        #endregion
        
        #region Parameter DeveloperProviderName
        /// <summary>
        /// <para>
        /// <para>The "domain" by which Cognito will refer to your users. This name acts as a placeholder
        /// that allows your backend and the Cognito service to communicate about the developer
        /// provider. For the <code>DeveloperProviderName</code>, you can use letters as well
        /// as period (<code>.</code>), underscore (<code>_</code>), and dash (<code>-</code>).</para><para>Once you have set a developer provider name, you cannot change it. Please take care
        /// in setting this parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DeveloperProviderName { get; set; }
        #endregion
        
        #region Parameter IdentityPoolName
        /// <summary>
        /// <para>
        /// <para>A string that you provide.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String IdentityPoolName { get; set; }
        #endregion
        
        #region Parameter OpenIdConnectProviderARNs
        /// <summary>
        /// <para>
        /// <para>A list of OpendID Connect provider ARNs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String[] OpenIdConnectProviderARNs { get; set; }
        #endregion
        
        #region Parameter SamlProviderARNs
        /// <summary>
        /// <para>
        /// <para>An array of Amazon Resource Names (ARNs) of the SAML provider for your identity pool.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String[] SamlProviderARNs { get; set; }
        #endregion
        
        #region Parameter SupportedLoginProvider
        /// <summary>
        /// <para>
        /// <para>Optional key:value pairs mapping provider names to provider app IDs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("SupportedLoginProviders")]
        public System.Collections.Hashtable SupportedLoginProvider { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("IdentityPoolName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CGIIdentityPool (CreateIdentityPool)"))
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
            
            if (ParameterWasBound("AllowUnauthenticatedIdentity"))
                context.AllowUnauthenticatedIdentities = this.AllowUnauthenticatedIdentity;
            if (this.CognitoIdentityProvider != null)
            {
                context.CognitoIdentityProviders = new List<Amazon.CognitoIdentity.Model.CognitoIdentityProviderInfo>(this.CognitoIdentityProvider);
            }
            context.DeveloperProviderName = this.DeveloperProviderName;
            context.IdentityPoolName = this.IdentityPoolName;
            if (this.OpenIdConnectProviderARNs != null)
            {
                context.OpenIdConnectProviderARNs = new List<System.String>(this.OpenIdConnectProviderARNs);
            }
            if (this.SamlProviderARNs != null)
            {
                context.SamlProviderARNs = new List<System.String>(this.SamlProviderARNs);
            }
            if (this.SupportedLoginProvider != null)
            {
                context.SupportedLoginProviders = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.SupportedLoginProvider.Keys)
                {
                    context.SupportedLoginProviders.Add((String)hashKey, (String)(this.SupportedLoginProvider[hashKey]));
                }
            }
            
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
            var request = new Amazon.CognitoIdentity.Model.CreateIdentityPoolRequest();
            
            if (cmdletContext.AllowUnauthenticatedIdentities != null)
            {
                request.AllowUnauthenticatedIdentities = cmdletContext.AllowUnauthenticatedIdentities.Value;
            }
            if (cmdletContext.CognitoIdentityProviders != null)
            {
                request.CognitoIdentityProviders = cmdletContext.CognitoIdentityProviders;
            }
            if (cmdletContext.DeveloperProviderName != null)
            {
                request.DeveloperProviderName = cmdletContext.DeveloperProviderName;
            }
            if (cmdletContext.IdentityPoolName != null)
            {
                request.IdentityPoolName = cmdletContext.IdentityPoolName;
            }
            if (cmdletContext.OpenIdConnectProviderARNs != null)
            {
                request.OpenIdConnectProviderARNs = cmdletContext.OpenIdConnectProviderARNs;
            }
            if (cmdletContext.SamlProviderARNs != null)
            {
                request.SamlProviderARNs = cmdletContext.SamlProviderARNs;
            }
            if (cmdletContext.SupportedLoginProviders != null)
            {
                request.SupportedLoginProviders = cmdletContext.SupportedLoginProviders;
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
        
        private Amazon.CognitoIdentity.Model.CreateIdentityPoolResponse CallAWSServiceOperation(IAmazonCognitoIdentity client, Amazon.CognitoIdentity.Model.CreateIdentityPoolRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Cognito Identity", "CreateIdentityPool");
            try
            {
                #if DESKTOP
                return client.CreateIdentityPool(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateIdentityPoolAsync(request);
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
            public System.Boolean? AllowUnauthenticatedIdentities { get; set; }
            public List<Amazon.CognitoIdentity.Model.CognitoIdentityProviderInfo> CognitoIdentityProviders { get; set; }
            public System.String DeveloperProviderName { get; set; }
            public System.String IdentityPoolName { get; set; }
            public List<System.String> OpenIdConnectProviderARNs { get; set; }
            public List<System.String> SamlProviderARNs { get; set; }
            public Dictionary<System.String, System.String> SupportedLoginProviders { get; set; }
        }
        
    }
}
