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
using Amazon.SSOAdmin;
using Amazon.SSOAdmin.Model;

namespace Amazon.PowerShell.Cmdlets.SSOADMN
{
    /// <summary>
    /// Creates a connection to a trusted token issuer in an instance of IAM Identity Center.
    /// A trusted token issuer enables trusted identity propagation to be used with applications
    /// that authenticate outside of Amazon Web Services.
    /// 
    ///  
    /// <para>
    /// This trusted token issuer describes an external identity provider (IdP) that can generate
    /// claims or assertions in the form of access tokens for a user. Applications enabled
    /// for IAM Identity Center can use these tokens for authentication. 
    /// </para>
    /// </summary>
    [Cmdlet("New", "SSOADMNTrustedTokenIssuer", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SSOAdmin.Model.CreateTrustedTokenIssuerResponse")]
    [AWSCmdlet("Calls the AWS Single Sign-On Admin CreateTrustedTokenIssuer API operation.", Operation = new[] {"CreateTrustedTokenIssuer"}, SelectReturnType = typeof(Amazon.SSOAdmin.Model.CreateTrustedTokenIssuerResponse))]
    [AWSCmdletOutput("Amazon.SSOAdmin.Model.CreateTrustedTokenIssuerResponse",
        "This cmdlet returns an Amazon.SSOAdmin.Model.CreateTrustedTokenIssuerResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewSSOADMNTrustedTokenIssuerCmdlet : AmazonSSOAdminClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter OidcJwtConfiguration_ClaimAttributePath
        /// <summary>
        /// <para>
        /// <para>The path of the source attribute in the JWT from the trusted token issuer. The attribute
        /// mapped by this JMESPath expression is compared against the attribute mapped by <c>IdentityStoreAttributePath</c>
        /// when a trusted token issuer token is exchanged for an IAM Identity Center token.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TrustedTokenIssuerConfiguration_OidcJwtConfiguration_ClaimAttributePath")]
        public System.String OidcJwtConfiguration_ClaimAttributePath { get; set; }
        #endregion
        
        #region Parameter OidcJwtConfiguration_IdentityStoreAttributePath
        /// <summary>
        /// <para>
        /// <para>The path of the destination attribute in a JWT from IAM Identity Center. The attribute
        /// mapped by this JMESPath expression is compared against the attribute mapped by <c>ClaimAttributePath</c>
        /// when a trusted token issuer token is exchanged for an IAM Identity Center token. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TrustedTokenIssuerConfiguration_OidcJwtConfiguration_IdentityStoreAttributePath")]
        public System.String OidcJwtConfiguration_IdentityStoreAttributePath { get; set; }
        #endregion
        
        #region Parameter InstanceArn
        /// <summary>
        /// <para>
        /// <para>Specifies the ARN of the instance of IAM Identity Center to contain the new trusted
        /// token issuer configuration.</para>
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
        public System.String InstanceArn { get; set; }
        #endregion
        
        #region Parameter OidcJwtConfiguration_IssuerUrl
        /// <summary>
        /// <para>
        /// <para>The URL that IAM Identity Center uses for OpenID Discovery. OpenID Discovery is used
        /// to obtain the information required to verify the tokens that the trusted token issuer
        /// generates.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TrustedTokenIssuerConfiguration_OidcJwtConfiguration_IssuerUrl")]
        public System.String OidcJwtConfiguration_IssuerUrl { get; set; }
        #endregion
        
        #region Parameter OidcJwtConfiguration_JwksRetrievalOption
        /// <summary>
        /// <para>
        /// <para>The method that the trusted token issuer can use to retrieve the JSON Web Key Set
        /// used to verify a JWT.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TrustedTokenIssuerConfiguration_OidcJwtConfiguration_JwksRetrievalOption")]
        [AWSConstantClassSource("Amazon.SSOAdmin.JwksRetrievalOption")]
        public Amazon.SSOAdmin.JwksRetrievalOption OidcJwtConfiguration_JwksRetrievalOption { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>Specifies the name of the new trusted token issuer configuration.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Specifies tags to be attached to the new trusted token issuer configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.SSOAdmin.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TrustedTokenIssuerType
        /// <summary>
        /// <para>
        /// <para>Specifies the type of the new trusted token issuer.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.SSOAdmin.TrustedTokenIssuerType")]
        public Amazon.SSOAdmin.TrustedTokenIssuerType TrustedTokenIssuerType { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Specifies a unique, case-sensitive ID that you provide to ensure the idempotency of
        /// the request. This lets you safely retry the request without accidentally performing
        /// the same operation a second time. Passing the same value to a later call to an operation
        /// requires that you also pass the same value for all other parameters. We recommend
        /// that you use a <a href="https://wikipedia.org/wiki/Universally_unique_identifier">UUID
        /// type of value.</a>.</para><para>If you don't provide this value, then Amazon Web Services generates a random one for
        /// you.</para><para>If you retry the operation with the same <c>ClientToken</c>, but with different parameters,
        /// the retry fails with an <c>IdempotentParameterMismatch</c> error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SSOAdmin.Model.CreateTrustedTokenIssuerResponse).
        /// Specifying the name of a property of type Amazon.SSOAdmin.Model.CreateTrustedTokenIssuerResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.InstanceArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SSOADMNTrustedTokenIssuer (CreateTrustedTokenIssuer)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SSOAdmin.Model.CreateTrustedTokenIssuerResponse, NewSSOADMNTrustedTokenIssuerCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.InstanceArn = this.InstanceArn;
            #if MODULAR
            if (this.InstanceArn == null && ParameterWasBound(nameof(this.InstanceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.SSOAdmin.Model.Tag>(this.Tag);
            }
            context.OidcJwtConfiguration_ClaimAttributePath = this.OidcJwtConfiguration_ClaimAttributePath;
            context.OidcJwtConfiguration_IdentityStoreAttributePath = this.OidcJwtConfiguration_IdentityStoreAttributePath;
            context.OidcJwtConfiguration_IssuerUrl = this.OidcJwtConfiguration_IssuerUrl;
            context.OidcJwtConfiguration_JwksRetrievalOption = this.OidcJwtConfiguration_JwksRetrievalOption;
            context.TrustedTokenIssuerType = this.TrustedTokenIssuerType;
            #if MODULAR
            if (this.TrustedTokenIssuerType == null && ParameterWasBound(nameof(this.TrustedTokenIssuerType)))
            {
                WriteWarning("You are passing $null as a value for parameter TrustedTokenIssuerType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SSOAdmin.Model.CreateTrustedTokenIssuerRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.InstanceArn != null)
            {
                request.InstanceArn = cmdletContext.InstanceArn;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
             // populate TrustedTokenIssuerConfiguration
            var requestTrustedTokenIssuerConfigurationIsNull = true;
            request.TrustedTokenIssuerConfiguration = new Amazon.SSOAdmin.Model.TrustedTokenIssuerConfiguration();
            Amazon.SSOAdmin.Model.OidcJwtConfiguration requestTrustedTokenIssuerConfiguration_trustedTokenIssuerConfiguration_OidcJwtConfiguration = null;
            
             // populate OidcJwtConfiguration
            var requestTrustedTokenIssuerConfiguration_trustedTokenIssuerConfiguration_OidcJwtConfigurationIsNull = true;
            requestTrustedTokenIssuerConfiguration_trustedTokenIssuerConfiguration_OidcJwtConfiguration = new Amazon.SSOAdmin.Model.OidcJwtConfiguration();
            System.String requestTrustedTokenIssuerConfiguration_trustedTokenIssuerConfiguration_OidcJwtConfiguration_oidcJwtConfiguration_ClaimAttributePath = null;
            if (cmdletContext.OidcJwtConfiguration_ClaimAttributePath != null)
            {
                requestTrustedTokenIssuerConfiguration_trustedTokenIssuerConfiguration_OidcJwtConfiguration_oidcJwtConfiguration_ClaimAttributePath = cmdletContext.OidcJwtConfiguration_ClaimAttributePath;
            }
            if (requestTrustedTokenIssuerConfiguration_trustedTokenIssuerConfiguration_OidcJwtConfiguration_oidcJwtConfiguration_ClaimAttributePath != null)
            {
                requestTrustedTokenIssuerConfiguration_trustedTokenIssuerConfiguration_OidcJwtConfiguration.ClaimAttributePath = requestTrustedTokenIssuerConfiguration_trustedTokenIssuerConfiguration_OidcJwtConfiguration_oidcJwtConfiguration_ClaimAttributePath;
                requestTrustedTokenIssuerConfiguration_trustedTokenIssuerConfiguration_OidcJwtConfigurationIsNull = false;
            }
            System.String requestTrustedTokenIssuerConfiguration_trustedTokenIssuerConfiguration_OidcJwtConfiguration_oidcJwtConfiguration_IdentityStoreAttributePath = null;
            if (cmdletContext.OidcJwtConfiguration_IdentityStoreAttributePath != null)
            {
                requestTrustedTokenIssuerConfiguration_trustedTokenIssuerConfiguration_OidcJwtConfiguration_oidcJwtConfiguration_IdentityStoreAttributePath = cmdletContext.OidcJwtConfiguration_IdentityStoreAttributePath;
            }
            if (requestTrustedTokenIssuerConfiguration_trustedTokenIssuerConfiguration_OidcJwtConfiguration_oidcJwtConfiguration_IdentityStoreAttributePath != null)
            {
                requestTrustedTokenIssuerConfiguration_trustedTokenIssuerConfiguration_OidcJwtConfiguration.IdentityStoreAttributePath = requestTrustedTokenIssuerConfiguration_trustedTokenIssuerConfiguration_OidcJwtConfiguration_oidcJwtConfiguration_IdentityStoreAttributePath;
                requestTrustedTokenIssuerConfiguration_trustedTokenIssuerConfiguration_OidcJwtConfigurationIsNull = false;
            }
            System.String requestTrustedTokenIssuerConfiguration_trustedTokenIssuerConfiguration_OidcJwtConfiguration_oidcJwtConfiguration_IssuerUrl = null;
            if (cmdletContext.OidcJwtConfiguration_IssuerUrl != null)
            {
                requestTrustedTokenIssuerConfiguration_trustedTokenIssuerConfiguration_OidcJwtConfiguration_oidcJwtConfiguration_IssuerUrl = cmdletContext.OidcJwtConfiguration_IssuerUrl;
            }
            if (requestTrustedTokenIssuerConfiguration_trustedTokenIssuerConfiguration_OidcJwtConfiguration_oidcJwtConfiguration_IssuerUrl != null)
            {
                requestTrustedTokenIssuerConfiguration_trustedTokenIssuerConfiguration_OidcJwtConfiguration.IssuerUrl = requestTrustedTokenIssuerConfiguration_trustedTokenIssuerConfiguration_OidcJwtConfiguration_oidcJwtConfiguration_IssuerUrl;
                requestTrustedTokenIssuerConfiguration_trustedTokenIssuerConfiguration_OidcJwtConfigurationIsNull = false;
            }
            Amazon.SSOAdmin.JwksRetrievalOption requestTrustedTokenIssuerConfiguration_trustedTokenIssuerConfiguration_OidcJwtConfiguration_oidcJwtConfiguration_JwksRetrievalOption = null;
            if (cmdletContext.OidcJwtConfiguration_JwksRetrievalOption != null)
            {
                requestTrustedTokenIssuerConfiguration_trustedTokenIssuerConfiguration_OidcJwtConfiguration_oidcJwtConfiguration_JwksRetrievalOption = cmdletContext.OidcJwtConfiguration_JwksRetrievalOption;
            }
            if (requestTrustedTokenIssuerConfiguration_trustedTokenIssuerConfiguration_OidcJwtConfiguration_oidcJwtConfiguration_JwksRetrievalOption != null)
            {
                requestTrustedTokenIssuerConfiguration_trustedTokenIssuerConfiguration_OidcJwtConfiguration.JwksRetrievalOption = requestTrustedTokenIssuerConfiguration_trustedTokenIssuerConfiguration_OidcJwtConfiguration_oidcJwtConfiguration_JwksRetrievalOption;
                requestTrustedTokenIssuerConfiguration_trustedTokenIssuerConfiguration_OidcJwtConfigurationIsNull = false;
            }
             // determine if requestTrustedTokenIssuerConfiguration_trustedTokenIssuerConfiguration_OidcJwtConfiguration should be set to null
            if (requestTrustedTokenIssuerConfiguration_trustedTokenIssuerConfiguration_OidcJwtConfigurationIsNull)
            {
                requestTrustedTokenIssuerConfiguration_trustedTokenIssuerConfiguration_OidcJwtConfiguration = null;
            }
            if (requestTrustedTokenIssuerConfiguration_trustedTokenIssuerConfiguration_OidcJwtConfiguration != null)
            {
                request.TrustedTokenIssuerConfiguration.OidcJwtConfiguration = requestTrustedTokenIssuerConfiguration_trustedTokenIssuerConfiguration_OidcJwtConfiguration;
                requestTrustedTokenIssuerConfigurationIsNull = false;
            }
             // determine if request.TrustedTokenIssuerConfiguration should be set to null
            if (requestTrustedTokenIssuerConfigurationIsNull)
            {
                request.TrustedTokenIssuerConfiguration = null;
            }
            if (cmdletContext.TrustedTokenIssuerType != null)
            {
                request.TrustedTokenIssuerType = cmdletContext.TrustedTokenIssuerType;
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
        
        private Amazon.SSOAdmin.Model.CreateTrustedTokenIssuerResponse CallAWSServiceOperation(IAmazonSSOAdmin client, Amazon.SSOAdmin.Model.CreateTrustedTokenIssuerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Single Sign-On Admin", "CreateTrustedTokenIssuer");
            try
            {
                #if DESKTOP
                return client.CreateTrustedTokenIssuer(request);
                #elif CORECLR
                return client.CreateTrustedTokenIssuerAsync(request).GetAwaiter().GetResult();
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
            public System.String InstanceArn { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.SSOAdmin.Model.Tag> Tag { get; set; }
            public System.String OidcJwtConfiguration_ClaimAttributePath { get; set; }
            public System.String OidcJwtConfiguration_IdentityStoreAttributePath { get; set; }
            public System.String OidcJwtConfiguration_IssuerUrl { get; set; }
            public Amazon.SSOAdmin.JwksRetrievalOption OidcJwtConfiguration_JwksRetrievalOption { get; set; }
            public Amazon.SSOAdmin.TrustedTokenIssuerType TrustedTokenIssuerType { get; set; }
            public System.Func<Amazon.SSOAdmin.Model.CreateTrustedTokenIssuerResponse, NewSSOADMNTrustedTokenIssuerCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
