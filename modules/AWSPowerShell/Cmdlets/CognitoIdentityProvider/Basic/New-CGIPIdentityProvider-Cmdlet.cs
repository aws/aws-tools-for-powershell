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
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;

namespace Amazon.PowerShell.Cmdlets.CGIP
{
    /// <summary>
    /// Amazon.CognitoIdentityProvider.IAmazonCognitoIdentityProvider.CreateIdentityProvider
    /// </summary>
    [Cmdlet("New", "CGIPIdentityProvider", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CognitoIdentityProvider.Model.IdentityProviderType")]
    [AWSCmdlet("Calls the Amazon Cognito Identity Provider CreateIdentityProvider API operation.", Operation = new[] {"CreateIdentityProvider"}, SelectReturnType = typeof(Amazon.CognitoIdentityProvider.Model.CreateIdentityProviderResponse))]
    [AWSCmdletOutput("Amazon.CognitoIdentityProvider.Model.IdentityProviderType or Amazon.CognitoIdentityProvider.Model.CreateIdentityProviderResponse",
        "This cmdlet returns an Amazon.CognitoIdentityProvider.Model.IdentityProviderType object.",
        "The service call response (type Amazon.CognitoIdentityProvider.Model.CreateIdentityProviderResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewCGIPIdentityProviderCmdlet : AmazonCognitoIdentityProviderClientCmdlet, IExecutor
    {
        
        #region Parameter AttributeMapping
        /// <summary>
        /// <para>
        /// <para>A mapping of IdP attributes to standard and custom user pool attributes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable AttributeMapping { get; set; }
        #endregion
        
        #region Parameter IdpIdentifier
        /// <summary>
        /// <para>
        /// <para>A list of IdP identifiers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IdpIdentifiers")]
        public System.String[] IdpIdentifier { get; set; }
        #endregion
        
        #region Parameter ProviderDetail
        /// <summary>
        /// <para>
        /// <para>The IdP details. The following list describes the provider detail keys for each IdP
        /// type.</para><ul><li><para>For Google and Login with Amazon:</para><ul><li><para>client_id</para></li><li><para>client_secret</para></li><li><para>authorize_scopes</para></li></ul></li><li><para>For Facebook:</para><ul><li><para>client_id</para></li><li><para>client_secret</para></li><li><para>authorize_scopes</para></li><li><para>api_version</para></li></ul></li><li><para>For Sign in with Apple:</para><ul><li><para>client_id</para></li><li><para>team_id</para></li><li><para>key_id</para></li><li><para>private_key</para></li><li><para>authorize_scopes</para></li></ul></li><li><para>For OpenID Connect (OIDC) providers:</para><ul><li><para>client_id</para></li><li><para>client_secret</para></li><li><para>attributes_request_method</para></li><li><para>oidc_issuer</para></li><li><para>authorize_scopes</para></li><li><para>The following keys are only present if Amazon Cognito didn't discover them at the
        /// <code>oidc_issuer</code> URL.</para><ul><li><para>authorize_url </para></li><li><para>token_url </para></li><li><para>attributes_url </para></li><li><para>jwks_uri </para></li></ul></li><li><para>Amazon Cognito sets the value of the following keys automatically. They are read-only.</para><ul><li><para>attributes_url_add_attributes </para></li></ul></li></ul></li><li><para>For SAML providers:</para><ul><li><para>MetadataFile or MetadataURL</para></li><li><para>IDPSignout <i>optional</i></para></li></ul></li></ul>
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
        [Alias("ProviderDetails")]
        public System.Collections.Hashtable ProviderDetail { get; set; }
        #endregion
        
        #region Parameter ProviderName
        /// <summary>
        /// <para>
        /// <para>The IdP name.</para>
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
        public System.String ProviderName { get; set; }
        #endregion
        
        #region Parameter ProviderType
        /// <summary>
        /// <para>
        /// <para>The IdP type.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CognitoIdentityProvider.IdentityProviderTypeType")]
        public Amazon.CognitoIdentityProvider.IdentityProviderTypeType ProviderType { get; set; }
        #endregion
        
        #region Parameter UserPoolId
        /// <summary>
        /// <para>
        /// <para>The user pool ID.</para>
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
        public System.String UserPoolId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'IdentityProvider'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CognitoIdentityProvider.Model.CreateIdentityProviderResponse).
        /// Specifying the name of a property of type Amazon.CognitoIdentityProvider.Model.CreateIdentityProviderResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "IdentityProvider";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ProviderName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ProviderName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ProviderName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ProviderName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CGIPIdentityProvider (CreateIdentityProvider)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CognitoIdentityProvider.Model.CreateIdentityProviderResponse, NewCGIPIdentityProviderCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ProviderName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.AttributeMapping != null)
            {
                context.AttributeMapping = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.AttributeMapping.Keys)
                {
                    context.AttributeMapping.Add((String)hashKey, (String)(this.AttributeMapping[hashKey]));
                }
            }
            if (this.IdpIdentifier != null)
            {
                context.IdpIdentifier = new List<System.String>(this.IdpIdentifier);
            }
            if (this.ProviderDetail != null)
            {
                context.ProviderDetail = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.ProviderDetail.Keys)
                {
                    context.ProviderDetail.Add((String)hashKey, (String)(this.ProviderDetail[hashKey]));
                }
            }
            #if MODULAR
            if (this.ProviderDetail == null && ParameterWasBound(nameof(this.ProviderDetail)))
            {
                WriteWarning("You are passing $null as a value for parameter ProviderDetail which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ProviderName = this.ProviderName;
            #if MODULAR
            if (this.ProviderName == null && ParameterWasBound(nameof(this.ProviderName)))
            {
                WriteWarning("You are passing $null as a value for parameter ProviderName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ProviderType = this.ProviderType;
            #if MODULAR
            if (this.ProviderType == null && ParameterWasBound(nameof(this.ProviderType)))
            {
                WriteWarning("You are passing $null as a value for parameter ProviderType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.UserPoolId = this.UserPoolId;
            #if MODULAR
            if (this.UserPoolId == null && ParameterWasBound(nameof(this.UserPoolId)))
            {
                WriteWarning("You are passing $null as a value for parameter UserPoolId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CognitoIdentityProvider.Model.CreateIdentityProviderRequest();
            
            if (cmdletContext.AttributeMapping != null)
            {
                request.AttributeMapping = cmdletContext.AttributeMapping;
            }
            if (cmdletContext.IdpIdentifier != null)
            {
                request.IdpIdentifiers = cmdletContext.IdpIdentifier;
            }
            if (cmdletContext.ProviderDetail != null)
            {
                request.ProviderDetails = cmdletContext.ProviderDetail;
            }
            if (cmdletContext.ProviderName != null)
            {
                request.ProviderName = cmdletContext.ProviderName;
            }
            if (cmdletContext.ProviderType != null)
            {
                request.ProviderType = cmdletContext.ProviderType;
            }
            if (cmdletContext.UserPoolId != null)
            {
                request.UserPoolId = cmdletContext.UserPoolId;
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
        
        private Amazon.CognitoIdentityProvider.Model.CreateIdentityProviderResponse CallAWSServiceOperation(IAmazonCognitoIdentityProvider client, Amazon.CognitoIdentityProvider.Model.CreateIdentityProviderRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Cognito Identity Provider", "CreateIdentityProvider");
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
            public Dictionary<System.String, System.String> AttributeMapping { get; set; }
            public List<System.String> IdpIdentifier { get; set; }
            public Dictionary<System.String, System.String> ProviderDetail { get; set; }
            public System.String ProviderName { get; set; }
            public Amazon.CognitoIdentityProvider.IdentityProviderTypeType ProviderType { get; set; }
            public System.String UserPoolId { get; set; }
            public System.Func<Amazon.CognitoIdentityProvider.Model.CreateIdentityProviderResponse, NewCGIPIdentityProviderCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.IdentityProvider;
        }
        
    }
}
