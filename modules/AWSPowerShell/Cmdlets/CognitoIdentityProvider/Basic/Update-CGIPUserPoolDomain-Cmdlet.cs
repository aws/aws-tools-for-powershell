/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// A user pool domain hosts managed login, an authorization server and web server for
    /// authentication in your application. This operation updates the branding version for
    /// user pool domains between <c>1</c> for hosted UI (classic) and <c>2</c> for managed
    /// login. It also updates the SSL certificate for user pool custom domains.
    /// 
    ///  
    /// <para>
    /// Changes to the domain branding version take up to one minute to take effect for a
    /// prefix domain and up to five minutes for a custom domain.
    /// </para><para>
    /// This operation doesn't change the name of your user pool domain. To change your domain,
    /// delete it with <c>DeleteUserPoolDomain</c> and create a new domain with <c>CreateUserPoolDomain</c>.
    /// </para><para>
    /// You can pass the ARN of a new Certificate Manager certificate in this request. Typically,
    /// ACM certificates automatically renew and you user pool can continue to use the same
    /// ARN. But if you generate a new certificate for your custom domain name, replace the
    /// original configuration with the new ARN in this request.
    /// </para><para>
    /// ACM certificates for custom domains must be in the US East (N. Virginia) Amazon Web
    /// Services Region. After you submit your request, Amazon Cognito requires up to 1 hour
    /// to distribute your new certificate to your custom domain.
    /// </para><para>
    /// For more information about adding a custom domain to your user pool, see <a href="https://docs.aws.amazon.com/cognito/latest/developerguide/cognito-user-pools-add-custom-domain.html">Configuring
    /// a user pool domain</a>.
    /// </para><note><para>
    /// Amazon Cognito evaluates Identity and Access Management (IAM) policies in requests
    /// for this API operation. For this operation, you must use IAM credentials to authorize
    /// requests, and you must grant yourself the corresponding IAM permission in a policy.
    /// </para><para><b>Learn more</b></para><ul><li><para><a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/reference_aws-signing.html">Signing
    /// Amazon Web Services API Requests</a></para></li><li><para><a href="https://docs.aws.amazon.com/cognito/latest/developerguide/user-pools-API-operations.html">Using
    /// the Amazon Cognito user pools API and user pool endpoints</a></para></li></ul></note>
    /// </summary>
    [Cmdlet("Update", "CGIPUserPoolDomain", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Cognito Identity Provider UpdateUserPoolDomain API operation.", Operation = new[] {"UpdateUserPoolDomain"}, SelectReturnType = typeof(Amazon.CognitoIdentityProvider.Model.UpdateUserPoolDomainResponse))]
    [AWSCmdletOutput("System.String or Amazon.CognitoIdentityProvider.Model.UpdateUserPoolDomainResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.CognitoIdentityProvider.Model.UpdateUserPoolDomainResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateCGIPUserPoolDomainCmdlet : AmazonCognitoIdentityProviderClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CustomDomainConfig_CertificateArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of an Certificate Manager SSL certificate. You use
        /// this certificate for the subdomain of your custom domain.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomDomainConfig_CertificateArn { get; set; }
        #endregion
        
        #region Parameter Domain
        /// <summary>
        /// <para>
        /// <para>The name of the domain that you want to update. For custom domains, this is the fully-qualified
        /// domain name, for example <c>auth.example.com</c>. For prefix domains, this is the
        /// prefix alone, such as <c>myprefix</c>.</para>
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
        public System.String Domain { get; set; }
        #endregion
        
        #region Parameter ManagedLoginVersion
        /// <summary>
        /// <para>
        /// <para>A version number that indicates the state of managed login for your domain. Version
        /// <c>1</c> is hosted UI (classic). Version <c>2</c> is the newer managed login with
        /// the branding editor. For more information, see <a href="https://docs.aws.amazon.com/cognito/latest/developerguide/cognito-user-pools-managed-login.html">Managed
        /// login</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ManagedLoginVersion { get; set; }
        #endregion
        
        #region Parameter UserPoolId
        /// <summary>
        /// <para>
        /// <para>The ID of the user pool that is associated with the domain you're updating.</para>
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
        public System.String UserPoolId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CloudFrontDomain'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CognitoIdentityProvider.Model.UpdateUserPoolDomainResponse).
        /// Specifying the name of a property of type Amazon.CognitoIdentityProvider.Model.UpdateUserPoolDomainResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CloudFrontDomain";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the UserPoolId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^UserPoolId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^UserPoolId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.UserPoolId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CGIPUserPoolDomain (UpdateUserPoolDomain)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CognitoIdentityProvider.Model.UpdateUserPoolDomainResponse, UpdateCGIPUserPoolDomainCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.UserPoolId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CustomDomainConfig_CertificateArn = this.CustomDomainConfig_CertificateArn;
            context.Domain = this.Domain;
            #if MODULAR
            if (this.Domain == null && ParameterWasBound(nameof(this.Domain)))
            {
                WriteWarning("You are passing $null as a value for parameter Domain which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ManagedLoginVersion = this.ManagedLoginVersion;
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
            var request = new Amazon.CognitoIdentityProvider.Model.UpdateUserPoolDomainRequest();
            
            
             // populate CustomDomainConfig
            var requestCustomDomainConfigIsNull = true;
            request.CustomDomainConfig = new Amazon.CognitoIdentityProvider.Model.CustomDomainConfigType();
            System.String requestCustomDomainConfig_customDomainConfig_CertificateArn = null;
            if (cmdletContext.CustomDomainConfig_CertificateArn != null)
            {
                requestCustomDomainConfig_customDomainConfig_CertificateArn = cmdletContext.CustomDomainConfig_CertificateArn;
            }
            if (requestCustomDomainConfig_customDomainConfig_CertificateArn != null)
            {
                request.CustomDomainConfig.CertificateArn = requestCustomDomainConfig_customDomainConfig_CertificateArn;
                requestCustomDomainConfigIsNull = false;
            }
             // determine if request.CustomDomainConfig should be set to null
            if (requestCustomDomainConfigIsNull)
            {
                request.CustomDomainConfig = null;
            }
            if (cmdletContext.Domain != null)
            {
                request.Domain = cmdletContext.Domain;
            }
            if (cmdletContext.ManagedLoginVersion != null)
            {
                request.ManagedLoginVersion = cmdletContext.ManagedLoginVersion.Value;
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
        
        private Amazon.CognitoIdentityProvider.Model.UpdateUserPoolDomainResponse CallAWSServiceOperation(IAmazonCognitoIdentityProvider client, Amazon.CognitoIdentityProvider.Model.UpdateUserPoolDomainRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Cognito Identity Provider", "UpdateUserPoolDomain");
            try
            {
                #if DESKTOP
                return client.UpdateUserPoolDomain(request);
                #elif CORECLR
                return client.UpdateUserPoolDomainAsync(request).GetAwaiter().GetResult();
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
            public System.String CustomDomainConfig_CertificateArn { get; set; }
            public System.String Domain { get; set; }
            public System.Int32? ManagedLoginVersion { get; set; }
            public System.String UserPoolId { get; set; }
            public System.Func<Amazon.CognitoIdentityProvider.Model.UpdateUserPoolDomainResponse, UpdateCGIPUserPoolDomainCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CloudFrontDomain;
        }
        
    }
}
