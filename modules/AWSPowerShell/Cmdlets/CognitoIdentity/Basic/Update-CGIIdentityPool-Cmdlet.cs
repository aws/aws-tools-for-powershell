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
using Amazon.CognitoIdentity;
using Amazon.CognitoIdentity.Model;

namespace Amazon.PowerShell.Cmdlets.CGI
{
    /// <summary>
    /// Updates an identity pool.
    /// 
    ///  
    /// <para>
    /// You must use AWS Developer credentials to call this API.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "CGIIdentityPool", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CognitoIdentity.Model.UpdateIdentityPoolResponse")]
    [AWSCmdlet("Calls the Amazon Cognito Identity UpdateIdentityPool API operation.", Operation = new[] {"UpdateIdentityPool"}, SelectReturnType = typeof(Amazon.CognitoIdentity.Model.UpdateIdentityPoolResponse))]
    [AWSCmdletOutput("Amazon.CognitoIdentity.Model.UpdateIdentityPoolResponse",
        "This cmdlet returns an Amazon.CognitoIdentity.Model.UpdateIdentityPoolResponse object containing multiple properties."
    )]
    public partial class UpdateCGIIdentityPoolCmdlet : AmazonCognitoIdentityClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AllowClassicFlow
        /// <summary>
        /// <para>
        /// <para>Enables or disables the Basic (Classic) authentication flow. For more information,
        /// see <a href="https://docs.aws.amazon.com/cognito/latest/developerguide/authentication-flow.html">Identity
        /// Pools (Federated Identities) Authentication Flow</a> in the <i>Amazon Cognito Developer
        /// Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AllowClassicFlow { get; set; }
        #endregion
        
        #region Parameter AllowUnauthenticatedIdentity
        /// <summary>
        /// <para>
        /// <para>TRUE if the identity pool supports unauthenticated logins.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("AllowUnauthenticatedIdentities")]
        public System.Boolean? AllowUnauthenticatedIdentity { get; set; }
        #endregion
        
        #region Parameter CognitoIdentityProvider
        /// <summary>
        /// <para>
        /// <para>A list representing an Amazon Cognito user pool and its client ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CognitoIdentityProviders")]
        public Amazon.CognitoIdentity.Model.CognitoIdentityProviderInfo[] CognitoIdentityProvider { get; set; }
        #endregion
        
        #region Parameter DeveloperProviderName
        /// <summary>
        /// <para>
        /// <para>The "domain" by which Cognito will refer to your users.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DeveloperProviderName { get; set; }
        #endregion
        
        #region Parameter IdentityPoolId
        /// <summary>
        /// <para>
        /// <para>An identity pool ID in the format REGION:GUID.</para>
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
        public System.String IdentityPoolId { get; set; }
        #endregion
        
        #region Parameter IdentityPoolName
        /// <summary>
        /// <para>
        /// <para>A string that you provide.</para>
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
        public System.String IdentityPoolName { get; set; }
        #endregion
        
        #region Parameter IdentityPoolTag
        /// <summary>
        /// <para>
        /// <para>The tags that are assigned to the identity pool. A tag is a label that you can apply
        /// to identity pools to categorize and manage them in different ways, such as by purpose,
        /// owner, environment, or other criteria.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IdentityPoolTags")]
        public System.Collections.Hashtable IdentityPoolTag { get; set; }
        #endregion
        
        #region Parameter OpenIdConnectProviderARNs
        /// <summary>
        /// <para>
        /// <para>The ARNs of the OpenID Connect providers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] OpenIdConnectProviderARNs { get; set; }
        #endregion
        
        #region Parameter SamlProviderARNs
        /// <summary>
        /// <para>
        /// <para>An array of Amazon Resource Names (ARNs) of the SAML provider for your identity pool.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] SamlProviderARNs { get; set; }
        #endregion
        
        #region Parameter SupportedLoginProvider
        /// <summary>
        /// <para>
        /// <para>Optional key:value pairs mapping provider names to provider app IDs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SupportedLoginProviders")]
        public System.Collections.Hashtable SupportedLoginProvider { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CognitoIdentity.Model.UpdateIdentityPoolResponse).
        /// Specifying the name of a property of type Amazon.CognitoIdentity.Model.UpdateIdentityPoolResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.IdentityPoolId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CGIIdentityPool (UpdateIdentityPool)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CognitoIdentity.Model.UpdateIdentityPoolResponse, UpdateCGIIdentityPoolCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AllowClassicFlow = this.AllowClassicFlow;
            context.AllowUnauthenticatedIdentity = this.AllowUnauthenticatedIdentity;
            #if MODULAR
            if (this.AllowUnauthenticatedIdentity == null && ParameterWasBound(nameof(this.AllowUnauthenticatedIdentity)))
            {
                WriteWarning("You are passing $null as a value for parameter AllowUnauthenticatedIdentity which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.CognitoIdentityProvider != null)
            {
                context.CognitoIdentityProvider = new List<Amazon.CognitoIdentity.Model.CognitoIdentityProviderInfo>(this.CognitoIdentityProvider);
            }
            context.DeveloperProviderName = this.DeveloperProviderName;
            context.IdentityPoolId = this.IdentityPoolId;
            #if MODULAR
            if (this.IdentityPoolId == null && ParameterWasBound(nameof(this.IdentityPoolId)))
            {
                WriteWarning("You are passing $null as a value for parameter IdentityPoolId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IdentityPoolName = this.IdentityPoolName;
            #if MODULAR
            if (this.IdentityPoolName == null && ParameterWasBound(nameof(this.IdentityPoolName)))
            {
                WriteWarning("You are passing $null as a value for parameter IdentityPoolName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.IdentityPoolTag != null)
            {
                context.IdentityPoolTag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.IdentityPoolTag.Keys)
                {
                    context.IdentityPoolTag.Add((String)hashKey, (System.String)(this.IdentityPoolTag[hashKey]));
                }
            }
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
                context.SupportedLoginProvider = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.SupportedLoginProvider.Keys)
                {
                    context.SupportedLoginProvider.Add((String)hashKey, (System.String)(this.SupportedLoginProvider[hashKey]));
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
            var request = new Amazon.CognitoIdentity.Model.UpdateIdentityPoolRequest();
            
            if (cmdletContext.AllowClassicFlow != null)
            {
                request.AllowClassicFlow = cmdletContext.AllowClassicFlow.Value;
            }
            if (cmdletContext.AllowUnauthenticatedIdentity != null)
            {
                request.AllowUnauthenticatedIdentities = cmdletContext.AllowUnauthenticatedIdentity.Value;
            }
            if (cmdletContext.CognitoIdentityProvider != null)
            {
                request.CognitoIdentityProviders = cmdletContext.CognitoIdentityProvider;
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
            if (cmdletContext.IdentityPoolTag != null)
            {
                request.IdentityPoolTags = cmdletContext.IdentityPoolTag;
            }
            if (cmdletContext.OpenIdConnectProviderARNs != null)
            {
                request.OpenIdConnectProviderARNs = cmdletContext.OpenIdConnectProviderARNs;
            }
            if (cmdletContext.SamlProviderARNs != null)
            {
                request.SamlProviderARNs = cmdletContext.SamlProviderARNs;
            }
            if (cmdletContext.SupportedLoginProvider != null)
            {
                request.SupportedLoginProviders = cmdletContext.SupportedLoginProvider;
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
        
        private Amazon.CognitoIdentity.Model.UpdateIdentityPoolResponse CallAWSServiceOperation(IAmazonCognitoIdentity client, Amazon.CognitoIdentity.Model.UpdateIdentityPoolRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Cognito Identity", "UpdateIdentityPool");
            try
            {
                #if DESKTOP
                return client.UpdateIdentityPool(request);
                #elif CORECLR
                return client.UpdateIdentityPoolAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? AllowClassicFlow { get; set; }
            public System.Boolean? AllowUnauthenticatedIdentity { get; set; }
            public List<Amazon.CognitoIdentity.Model.CognitoIdentityProviderInfo> CognitoIdentityProvider { get; set; }
            public System.String DeveloperProviderName { get; set; }
            public System.String IdentityPoolId { get; set; }
            public System.String IdentityPoolName { get; set; }
            public Dictionary<System.String, System.String> IdentityPoolTag { get; set; }
            public List<System.String> OpenIdConnectProviderARNs { get; set; }
            public List<System.String> SamlProviderARNs { get; set; }
            public Dictionary<System.String, System.String> SupportedLoginProvider { get; set; }
            public System.Func<Amazon.CognitoIdentity.Model.UpdateIdentityPoolResponse, UpdateCGIIdentityPoolCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
