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
using Amazon.CognitoIdentity;
using Amazon.CognitoIdentity.Model;

namespace Amazon.PowerShell.Cmdlets.CGI
{
    /// <summary>
    /// Updates a user pool.
    /// 
    ///  
    /// <para>
    /// You must use AWS Developer credentials to call this API.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "CGIIdentityPool", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CognitoIdentity.Model.UpdateIdentityPoolResponse")]
    [AWSCmdlet("Invokes the UpdateIdentityPool operation against Amazon Cognito Identity.", Operation = new[] {"UpdateIdentityPool"})]
    [AWSCmdletOutput("Amazon.CognitoIdentity.Model.UpdateIdentityPoolResponse",
        "This cmdlet returns a UpdateIdentityPoolResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class UpdateCGIIdentityPoolCmdlet : AmazonCognitoIdentityClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// TRUE if the identity pool
        /// supports unauthenticated logins.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Boolean AllowUnauthenticatedIdentities { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The "domain" by which Cognito will refer to your users.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String DeveloperProviderName { get; set; }
        
        /// <summary>
        /// <para>
        /// An identity pool ID in the format REGION:GUID.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public String IdentityPoolId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A string that you provide.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String IdentityPoolName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A list of OpendID Connect provider ARNs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String[] OpenIdConnectProviderARNs { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Optional key:value pairs mapping provider names to provider app IDs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("SupportedLoginProviders")]
        public System.Collections.Hashtable SupportedLoginProvider { get; set; }
        
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("IdentityPoolId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CGIIdentityPool (UpdateIdentityPool)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (ParameterWasBound("AllowUnauthenticatedIdentities"))
                context.AllowUnauthenticatedIdentities = this.AllowUnauthenticatedIdentities;
            context.DeveloperProviderName = this.DeveloperProviderName;
            context.IdentityPoolId = this.IdentityPoolId;
            context.IdentityPoolName = this.IdentityPoolName;
            if (this.OpenIdConnectProviderARNs != null)
            {
                context.OpenIdConnectProviderARNs = new List<String>(this.OpenIdConnectProviderARNs);
            }
            if (this.SupportedLoginProvider != null)
            {
                context.SupportedLoginProviders = new Dictionary<String, String>(StringComparer.Ordinal);
                foreach (var hashKey in this.SupportedLoginProvider.Keys)
                {
                    context.SupportedLoginProviders.Add((String)hashKey, (String)(this.SupportedLoginProvider[hashKey]));
                }
            }
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new UpdateIdentityPoolRequest();
            
            if (cmdletContext.AllowUnauthenticatedIdentities != null)
            {
                request.AllowUnauthenticatedIdentities = cmdletContext.AllowUnauthenticatedIdentities.Value;
            }
            if (cmdletContext.DeveloperProviderName != null)
            {
                request.DeveloperProviderName = cmdletContext.DeveloperProviderName;
            }
            if (cmdletContext.IdentityPoolId != null)
            {
                request.IdentityPoolId = cmdletContext.IdentityPoolId;
            }
            if (cmdletContext.IdentityPoolName != null)
            {
                request.IdentityPoolName = cmdletContext.IdentityPoolName;
            }
            if (cmdletContext.OpenIdConnectProviderARNs != null)
            {
                request.OpenIdConnectProviderARNs = cmdletContext.OpenIdConnectProviderARNs;
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
                var response = client.UpdateIdentityPool(request);
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
            public Boolean? AllowUnauthenticatedIdentities { get; set; }
            public String DeveloperProviderName { get; set; }
            public String IdentityPoolId { get; set; }
            public String IdentityPoolName { get; set; }
            public List<String> OpenIdConnectProviderARNs { get; set; }
            public Dictionary<String, String> SupportedLoginProviders { get; set; }
        }
        
    }
}
