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
    /// Modifies existing terms documents for the requested app client. When Terms and conditions
    /// and Privacy policy documents are configured, the app client displays links to them
    /// in the sign-up page of managed login for the app client.
    /// 
    ///  
    /// <para>
    /// You can provide URLs for terms documents in the languages that are supported by <a href="https://docs.aws.amazon.com/cognito/latest/developerguide/cognito-user-pools-managed-login.html#managed-login-localization">managed
    /// login localization</a>. Amazon Cognito directs users to the terms documents for their
    /// current language, with fallback to <c>default</c> if no document exists for the language.
    /// </para><para>
    /// Each request accepts one type of terms document and a map of language-to-link for
    /// that document type. You must provide both types of terms documents in at least one
    /// language before Amazon Cognito displays your terms documents. Supply each type in
    /// separate requests.
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/cognito/latest/developerguide/cognito-user-pools-managed-login.html#managed-login-terms-documents">Terms
    /// documents</a>.
    /// </para><note><para>
    /// Amazon Cognito evaluates Identity and Access Management (IAM) policies in requests
    /// for this API operation. For this operation, you must use IAM credentials to authorize
    /// requests, and you must grant yourself the corresponding IAM permission in a policy.
    /// </para><para><b>Learn more</b></para><ul><li><para><a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/reference_aws-signing.html">Signing
    /// Amazon Web Services API Requests</a></para></li><li><para><a href="https://docs.aws.amazon.com/cognito/latest/developerguide/user-pools-API-operations.html">Using
    /// the Amazon Cognito user pools API and user pool endpoints</a></para></li></ul></note>
    /// </summary>
    [Cmdlet("Update", "CGIPTerm", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CognitoIdentityProvider.Model.TermsType")]
    [AWSCmdlet("Calls the Amazon Cognito Identity Provider UpdateTerms API operation.", Operation = new[] {"UpdateTerms"}, SelectReturnType = typeof(Amazon.CognitoIdentityProvider.Model.UpdateTermsResponse))]
    [AWSCmdletOutput("Amazon.CognitoIdentityProvider.Model.TermsType or Amazon.CognitoIdentityProvider.Model.UpdateTermsResponse",
        "This cmdlet returns an Amazon.CognitoIdentityProvider.Model.TermsType object.",
        "The service call response (type Amazon.CognitoIdentityProvider.Model.UpdateTermsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateCGIPTermCmdlet : AmazonCognitoIdentityProviderClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Enforcement
        /// <summary>
        /// <para>
        /// <para>This parameter is reserved for future use and currently accepts only one value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CognitoIdentityProvider.TermsEnforcementType")]
        public Amazon.CognitoIdentityProvider.TermsEnforcementType Enforcement { get; set; }
        #endregion
        
        #region Parameter Link
        /// <summary>
        /// <para>
        /// <para>A map of URLs to languages. For each localized language that will view the requested
        /// <c>TermsName</c>, assign a URL. A selection of <c>cognito:default</c> displays for
        /// all languages that don't have a language-specific URL.</para><para>For example, <c>"cognito:default": "https://terms.example.com", "cognito:spanish":
        /// "https://terms.example.com/es"</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Links")]
        public System.Collections.Hashtable Link { get; set; }
        #endregion
        
        #region Parameter TermsId
        /// <summary>
        /// <para>
        /// <para>The ID of the terms document that you want to update.</para>
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
        public System.String TermsId { get; set; }
        #endregion
        
        #region Parameter TermsName
        /// <summary>
        /// <para>
        /// <para>The new name that you want to apply to the requested terms documents.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TermsName { get; set; }
        #endregion
        
        #region Parameter TermsSource
        /// <summary>
        /// <para>
        /// <para>This parameter is reserved for future use and currently accepts only one value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CognitoIdentityProvider.TermsSourceType")]
        public Amazon.CognitoIdentityProvider.TermsSourceType TermsSource { get; set; }
        #endregion
        
        #region Parameter UserPoolId
        /// <summary>
        /// <para>
        /// <para>The ID of the user pool that contains the terms that you want to update.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Terms'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CognitoIdentityProvider.Model.UpdateTermsResponse).
        /// Specifying the name of a property of type Amazon.CognitoIdentityProvider.Model.UpdateTermsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Terms";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the TermsId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^TermsId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^TermsId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TermsId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CGIPTerm (UpdateTerms)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CognitoIdentityProvider.Model.UpdateTermsResponse, UpdateCGIPTermCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.TermsId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Enforcement = this.Enforcement;
            if (this.Link != null)
            {
                context.Link = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Link.Keys)
                {
                    context.Link.Add((String)hashKey, (System.String)(this.Link[hashKey]));
                }
            }
            context.TermsId = this.TermsId;
            #if MODULAR
            if (this.TermsId == null && ParameterWasBound(nameof(this.TermsId)))
            {
                WriteWarning("You are passing $null as a value for parameter TermsId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TermsName = this.TermsName;
            context.TermsSource = this.TermsSource;
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
            var request = new Amazon.CognitoIdentityProvider.Model.UpdateTermsRequest();
            
            if (cmdletContext.Enforcement != null)
            {
                request.Enforcement = cmdletContext.Enforcement;
            }
            if (cmdletContext.Link != null)
            {
                request.Links = cmdletContext.Link;
            }
            if (cmdletContext.TermsId != null)
            {
                request.TermsId = cmdletContext.TermsId;
            }
            if (cmdletContext.TermsName != null)
            {
                request.TermsName = cmdletContext.TermsName;
            }
            if (cmdletContext.TermsSource != null)
            {
                request.TermsSource = cmdletContext.TermsSource;
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
        
        private Amazon.CognitoIdentityProvider.Model.UpdateTermsResponse CallAWSServiceOperation(IAmazonCognitoIdentityProvider client, Amazon.CognitoIdentityProvider.Model.UpdateTermsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Cognito Identity Provider", "UpdateTerms");
            try
            {
                #if DESKTOP
                return client.UpdateTerms(request);
                #elif CORECLR
                return client.UpdateTermsAsync(request).GetAwaiter().GetResult();
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
            public Amazon.CognitoIdentityProvider.TermsEnforcementType Enforcement { get; set; }
            public Dictionary<System.String, System.String> Link { get; set; }
            public System.String TermsId { get; set; }
            public System.String TermsName { get; set; }
            public Amazon.CognitoIdentityProvider.TermsSourceType TermsSource { get; set; }
            public System.String UserPoolId { get; set; }
            public System.Func<Amazon.CognitoIdentityProvider.Model.UpdateTermsResponse, UpdateCGIPTermCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Terms;
        }
        
    }
}
