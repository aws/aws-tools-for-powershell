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
    /// Updates the name of the trusted token issuer, or the path of a source attribute or
    /// destination attribute for a trusted token issuer configuration.
    /// 
    ///  <note><para>
    /// Updating this trusted token issuer configuration might cause users to lose access
    /// to any applications that are configured to use the trusted token issuer.
    /// </para></note>
    /// </summary>
    [Cmdlet("Update", "SSOADMNTrustedTokenIssuer", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Single Sign-On Admin UpdateTrustedTokenIssuer API operation.", Operation = new[] {"UpdateTrustedTokenIssuer"}, SelectReturnType = typeof(Amazon.SSOAdmin.Model.UpdateTrustedTokenIssuerResponse))]
    [AWSCmdletOutput("None or Amazon.SSOAdmin.Model.UpdateTrustedTokenIssuerResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SSOAdmin.Model.UpdateTrustedTokenIssuerResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateSSOADMNTrustedTokenIssuerCmdlet : AmazonSSOAdminClientCmdlet, IExecutor
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
        /// when a trusted token issuer token is exchanged for an IAM Identity Center token.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TrustedTokenIssuerConfiguration_OidcJwtConfiguration_IdentityStoreAttributePath")]
        public System.String OidcJwtConfiguration_IdentityStoreAttributePath { get; set; }
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
        /// <para>Specifies the updated name to be applied to the trusted token issuer configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter TrustedTokenIssuerArn
        /// <summary>
        /// <para>
        /// <para>Specifies the ARN of the trusted token issuer configuration that you want to update.</para>
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
        public System.String TrustedTokenIssuerArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SSOAdmin.Model.UpdateTrustedTokenIssuerResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TrustedTokenIssuerArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SSOADMNTrustedTokenIssuer (UpdateTrustedTokenIssuer)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SSOAdmin.Model.UpdateTrustedTokenIssuerResponse, UpdateSSOADMNTrustedTokenIssuerCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Name = this.Name;
            context.TrustedTokenIssuerArn = this.TrustedTokenIssuerArn;
            #if MODULAR
            if (this.TrustedTokenIssuerArn == null && ParameterWasBound(nameof(this.TrustedTokenIssuerArn)))
            {
                WriteWarning("You are passing $null as a value for parameter TrustedTokenIssuerArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OidcJwtConfiguration_ClaimAttributePath = this.OidcJwtConfiguration_ClaimAttributePath;
            context.OidcJwtConfiguration_IdentityStoreAttributePath = this.OidcJwtConfiguration_IdentityStoreAttributePath;
            context.OidcJwtConfiguration_JwksRetrievalOption = this.OidcJwtConfiguration_JwksRetrievalOption;
            
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
            var request = new Amazon.SSOAdmin.Model.UpdateTrustedTokenIssuerRequest();
            
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.TrustedTokenIssuerArn != null)
            {
                request.TrustedTokenIssuerArn = cmdletContext.TrustedTokenIssuerArn;
            }
            
             // populate TrustedTokenIssuerConfiguration
            var requestTrustedTokenIssuerConfigurationIsNull = true;
            request.TrustedTokenIssuerConfiguration = new Amazon.SSOAdmin.Model.TrustedTokenIssuerUpdateConfiguration();
            Amazon.SSOAdmin.Model.OidcJwtUpdateConfiguration requestTrustedTokenIssuerConfiguration_trustedTokenIssuerConfiguration_OidcJwtConfiguration = null;
            
             // populate OidcJwtConfiguration
            var requestTrustedTokenIssuerConfiguration_trustedTokenIssuerConfiguration_OidcJwtConfigurationIsNull = true;
            requestTrustedTokenIssuerConfiguration_trustedTokenIssuerConfiguration_OidcJwtConfiguration = new Amazon.SSOAdmin.Model.OidcJwtUpdateConfiguration();
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
        
        private Amazon.SSOAdmin.Model.UpdateTrustedTokenIssuerResponse CallAWSServiceOperation(IAmazonSSOAdmin client, Amazon.SSOAdmin.Model.UpdateTrustedTokenIssuerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Single Sign-On Admin", "UpdateTrustedTokenIssuer");
            try
            {
                #if DESKTOP
                return client.UpdateTrustedTokenIssuer(request);
                #elif CORECLR
                return client.UpdateTrustedTokenIssuerAsync(request).GetAwaiter().GetResult();
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
            public System.String Name { get; set; }
            public System.String TrustedTokenIssuerArn { get; set; }
            public System.String OidcJwtConfiguration_ClaimAttributePath { get; set; }
            public System.String OidcJwtConfiguration_IdentityStoreAttributePath { get; set; }
            public Amazon.SSOAdmin.JwksRetrievalOption OidcJwtConfiguration_JwksRetrievalOption { get; set; }
            public System.Func<Amazon.SSOAdmin.Model.UpdateTrustedTokenIssuerResponse, UpdateSSOADMNTrustedTokenIssuerCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
