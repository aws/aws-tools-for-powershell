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
using Amazon.WorkSpacesWeb;
using Amazon.WorkSpacesWeb.Model;

namespace Amazon.PowerShell.Cmdlets.WSW
{
    /// <summary>
    /// Creates an identity provider resource that is then associated with a web portal.
    /// </summary>
    [Cmdlet("New", "WSWIdentityProvider", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon WorkSpaces Web CreateIdentityProvider API operation.", Operation = new[] {"CreateIdentityProvider"}, SelectReturnType = typeof(Amazon.WorkSpacesWeb.Model.CreateIdentityProviderResponse))]
    [AWSCmdletOutput("System.String or Amazon.WorkSpacesWeb.Model.CreateIdentityProviderResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.WorkSpacesWeb.Model.CreateIdentityProviderResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewWSWIdentityProviderCmdlet : AmazonWorkSpacesWebClientCmdlet, IExecutor
    {
        
        #region Parameter IdentityProviderDetail
        /// <summary>
        /// <para>
        /// <para>The identity provider details. The following list describes the provider detail keys
        /// for each identity provider type. </para><ul><li><para>For Google and Login with Amazon:</para><ul><li><para><code>client_id</code></para></li><li><para><code>client_secret</code></para></li><li><para><code>authorize_scopes</code></para></li></ul></li><li><para>For Facebook:</para><ul><li><para><code>client_id</code></para></li><li><para><code>client_secret</code></para></li><li><para><code>authorize_scopes</code></para></li><li><para><code>api_version</code></para></li></ul></li><li><para>For Sign in with Apple:</para><ul><li><para><code>client_id</code></para></li><li><para><code>team_id</code></para></li><li><para><code>key_id</code></para></li><li><para><code>private_key</code></para></li><li><para><code>authorize_scopes</code></para></li></ul></li><li><para>For OIDC providers:</para><ul><li><para><code>client_id</code></para></li><li><para><code>client_secret</code></para></li><li><para><code>attributes_request_method</code></para></li><li><para><code>oidc_issuer</code></para></li><li><para><code>authorize_scopes</code></para></li><li><para><code>authorize_url</code><i>if not available from discovery URL specified by <code>oidc_issuer</code>
        /// key</i></para></li><li><para><code>token_url</code><i>if not available from discovery URL specified by <code>oidc_issuer</code>
        /// key</i></para></li><li><para><code>attributes_url</code><i>if not available from discovery URL specified by <code>oidc_issuer</code>
        /// key</i></para></li><li><para><code>jwks_uri</code><i>if not available from discovery URL specified by <code>oidc_issuer</code>
        /// key</i></para></li></ul></li><li><para>For SAML providers:</para><ul><li><para><code>MetadataFile</code> OR <code>MetadataURL</code></para></li><li><para><code>IDPSignout</code> (boolean) <i>optional</i></para></li></ul></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("IdentityProviderDetails")]
        public System.Collections.Hashtable IdentityProviderDetail { get; set; }
        #endregion
        
        #region Parameter IdentityProviderName
        /// <summary>
        /// <para>
        /// <para>The identity provider name.</para>
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
        public System.String IdentityProviderName { get; set; }
        #endregion
        
        #region Parameter IdentityProviderType
        /// <summary>
        /// <para>
        /// <para>The identity provider type.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.WorkSpacesWeb.IdentityProviderType")]
        public Amazon.WorkSpacesWeb.IdentityProviderType IdentityProviderType { get; set; }
        #endregion
        
        #region Parameter PortalArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the web portal.</para>
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
        public System.String PortalArn { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request. Idempotency ensures that an API request completes only once. With an
        /// idempotent request, if the original request completes successfully, subsequent retries
        /// with the same client token returns the result from the original successful request.</para><para>If you do not specify a client token, one is automatically generated by the AWS SDK.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'IdentityProviderArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WorkSpacesWeb.Model.CreateIdentityProviderResponse).
        /// Specifying the name of a property of type Amazon.WorkSpacesWeb.Model.CreateIdentityProviderResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "IdentityProviderArn";
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PortalArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-WSWIdentityProvider (CreateIdentityProvider)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WorkSpacesWeb.Model.CreateIdentityProviderResponse, NewWSWIdentityProviderCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            if (this.IdentityProviderDetail != null)
            {
                context.IdentityProviderDetail = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.IdentityProviderDetail.Keys)
                {
                    context.IdentityProviderDetail.Add((String)hashKey, (String)(this.IdentityProviderDetail[hashKey]));
                }
            }
            #if MODULAR
            if (this.IdentityProviderDetail == null && ParameterWasBound(nameof(this.IdentityProviderDetail)))
            {
                WriteWarning("You are passing $null as a value for parameter IdentityProviderDetail which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IdentityProviderName = this.IdentityProviderName;
            #if MODULAR
            if (this.IdentityProviderName == null && ParameterWasBound(nameof(this.IdentityProviderName)))
            {
                WriteWarning("You are passing $null as a value for parameter IdentityProviderName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IdentityProviderType = this.IdentityProviderType;
            #if MODULAR
            if (this.IdentityProviderType == null && ParameterWasBound(nameof(this.IdentityProviderType)))
            {
                WriteWarning("You are passing $null as a value for parameter IdentityProviderType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PortalArn = this.PortalArn;
            #if MODULAR
            if (this.PortalArn == null && ParameterWasBound(nameof(this.PortalArn)))
            {
                WriteWarning("You are passing $null as a value for parameter PortalArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.WorkSpacesWeb.Model.CreateIdentityProviderRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.IdentityProviderDetail != null)
            {
                request.IdentityProviderDetails = cmdletContext.IdentityProviderDetail;
            }
            if (cmdletContext.IdentityProviderName != null)
            {
                request.IdentityProviderName = cmdletContext.IdentityProviderName;
            }
            if (cmdletContext.IdentityProviderType != null)
            {
                request.IdentityProviderType = cmdletContext.IdentityProviderType;
            }
            if (cmdletContext.PortalArn != null)
            {
                request.PortalArn = cmdletContext.PortalArn;
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
        
        private Amazon.WorkSpacesWeb.Model.CreateIdentityProviderResponse CallAWSServiceOperation(IAmazonWorkSpacesWeb client, Amazon.WorkSpacesWeb.Model.CreateIdentityProviderRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon WorkSpaces Web", "CreateIdentityProvider");
            try
            {
                #if DESKTOP
                return client.CreateIdentityProvider(request);
                #elif CORECLR
                return client.CreateIdentityProviderAsync(request).GetAwaiter().GetResult();
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
            public Dictionary<System.String, System.String> IdentityProviderDetail { get; set; }
            public System.String IdentityProviderName { get; set; }
            public Amazon.WorkSpacesWeb.IdentityProviderType IdentityProviderType { get; set; }
            public System.String PortalArn { get; set; }
            public System.Func<Amazon.WorkSpacesWeb.Model.CreateIdentityProviderResponse, NewWSWIdentityProviderCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.IdentityProviderArn;
        }
        
    }
}
