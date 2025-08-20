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
    /// Configures the branding settings for a user pool style. This operation is the programmatic
    /// option for the configuration of a style in the branding editor.
    /// 
    ///  
    /// <para>
    /// Provides values for UI customization in a <c>Settings</c> JSON object and image files
    /// in an <c>Assets</c> array.
    /// </para><para>
    ///  This operation has a 2-megabyte request-size limit and include the CSS settings and
    /// image assets for your app client. Your branding settings might exceed 2MB in size.
    /// Amazon Cognito doesn't require that you pass all parameters in one request and preserves
    /// existing style settings that you don't specify. If your request is larger than 2MB,
    /// separate it into multiple requests, each with a size smaller than the limit.
    /// </para><note><para>
    /// Amazon Cognito evaluates Identity and Access Management (IAM) policies in requests
    /// for this API operation. For this operation, you must use IAM credentials to authorize
    /// requests, and you must grant yourself the corresponding IAM permission in a policy.
    /// </para><para><b>Learn more</b></para><ul><li><para><a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/reference_aws-signing.html">Signing
    /// Amazon Web Services API Requests</a></para></li><li><para><a href="https://docs.aws.amazon.com/cognito/latest/developerguide/user-pools-API-operations.html">Using
    /// the Amazon Cognito user pools API and user pool endpoints</a></para></li></ul></note>
    /// </summary>
    [Cmdlet("Update", "CGIPManagedLoginBranding", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CognitoIdentityProvider.Model.ManagedLoginBrandingType")]
    [AWSCmdlet("Calls the Amazon Cognito Identity Provider UpdateManagedLoginBranding API operation.", Operation = new[] {"UpdateManagedLoginBranding"}, SelectReturnType = typeof(Amazon.CognitoIdentityProvider.Model.UpdateManagedLoginBrandingResponse))]
    [AWSCmdletOutput("Amazon.CognitoIdentityProvider.Model.ManagedLoginBrandingType or Amazon.CognitoIdentityProvider.Model.UpdateManagedLoginBrandingResponse",
        "This cmdlet returns an Amazon.CognitoIdentityProvider.Model.ManagedLoginBrandingType object.",
        "The service call response (type Amazon.CognitoIdentityProvider.Model.UpdateManagedLoginBrandingResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateCGIPManagedLoginBrandingCmdlet : AmazonCognitoIdentityProviderClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Asset
        /// <summary>
        /// <para>
        /// <para>An array of image files that you want to apply to roles like backgrounds, logos, and
        /// icons. Each object must also indicate whether it is for dark mode, light mode, or
        /// browser-adaptive mode.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Assets")]
        public Amazon.CognitoIdentityProvider.Model.AssetType[] Asset { get; set; }
        #endregion
        
        #region Parameter ManagedLoginBrandingId
        /// <summary>
        /// <para>
        /// <para>The ID of the managed login branding style that you want to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ManagedLoginBrandingId { get; set; }
        #endregion
        
        #region Parameter Setting
        /// <summary>
        /// <para>
        /// <para>A JSON file, encoded as a <c>Document</c> type, with the the settings that you want
        /// to apply to your style.</para><para>The following components are not currently implemented and reserved for future use:</para><ul><li><para><c>signUp</c></para></li><li><para><c>instructions</c></para></li><li><para><c>sessionTimerDisplay</c></para></li><li><para><c>languageSelector</c> (for localization, see <a href="https://docs.aws.amazon.com/cognito/latest/developerguide/cognito-user-pools-managed-login.html#managed-login-localization">Managed
        /// login localization)</a></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings")]
        public System.Management.Automation.PSObject Setting { get; set; }
        #endregion
        
        #region Parameter UseCognitoProvidedValue
        /// <summary>
        /// <para>
        /// <para>When <c>true</c>, applies the default branding style options. This option reverts
        /// to default style options that are managed by Amazon Cognito. You can modify them later
        /// in the branding editor.</para><para>When you specify <c>true</c> for this option, you must also omit values for <c>Settings</c>
        /// and <c>Assets</c> in the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UseCognitoProvidedValues")]
        public System.Boolean? UseCognitoProvidedValue { get; set; }
        #endregion
        
        #region Parameter UserPoolId
        /// <summary>
        /// <para>
        /// <para>The ID of the user pool that contains the managed login branding style that you want
        /// to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String UserPoolId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ManagedLoginBranding'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CognitoIdentityProvider.Model.UpdateManagedLoginBrandingResponse).
        /// Specifying the name of a property of type Amazon.CognitoIdentityProvider.Model.UpdateManagedLoginBrandingResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ManagedLoginBranding";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CGIPManagedLoginBranding (UpdateManagedLoginBranding)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CognitoIdentityProvider.Model.UpdateManagedLoginBrandingResponse, UpdateCGIPManagedLoginBrandingCmdlet>(Select) ??
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
            if (this.Asset != null)
            {
                context.Asset = new List<Amazon.CognitoIdentityProvider.Model.AssetType>(this.Asset);
            }
            context.ManagedLoginBrandingId = this.ManagedLoginBrandingId;
            context.Setting = this.Setting;
            context.UseCognitoProvidedValue = this.UseCognitoProvidedValue;
            context.UserPoolId = this.UserPoolId;
            
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
            var request = new Amazon.CognitoIdentityProvider.Model.UpdateManagedLoginBrandingRequest();
            
            if (cmdletContext.Asset != null)
            {
                request.Assets = cmdletContext.Asset;
            }
            if (cmdletContext.ManagedLoginBrandingId != null)
            {
                request.ManagedLoginBrandingId = cmdletContext.ManagedLoginBrandingId;
            }
            if (cmdletContext.Setting != null)
            {
                request.Settings = Amazon.PowerShell.Common.DocumentHelper.ToDocument(cmdletContext.Setting);
            }
            if (cmdletContext.UseCognitoProvidedValue != null)
            {
                request.UseCognitoProvidedValues = cmdletContext.UseCognitoProvidedValue.Value;
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
        
        private Amazon.CognitoIdentityProvider.Model.UpdateManagedLoginBrandingResponse CallAWSServiceOperation(IAmazonCognitoIdentityProvider client, Amazon.CognitoIdentityProvider.Model.UpdateManagedLoginBrandingRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Cognito Identity Provider", "UpdateManagedLoginBranding");
            try
            {
                #if DESKTOP
                return client.UpdateManagedLoginBranding(request);
                #elif CORECLR
                return client.UpdateManagedLoginBrandingAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.CognitoIdentityProvider.Model.AssetType> Asset { get; set; }
            public System.String ManagedLoginBrandingId { get; set; }
            public System.Management.Automation.PSObject Setting { get; set; }
            public System.Boolean? UseCognitoProvidedValue { get; set; }
            public System.String UserPoolId { get; set; }
            public System.Func<Amazon.CognitoIdentityProvider.Model.UpdateManagedLoginBrandingResponse, UpdateCGIPManagedLoginBrandingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ManagedLoginBranding;
        }
        
    }
}
