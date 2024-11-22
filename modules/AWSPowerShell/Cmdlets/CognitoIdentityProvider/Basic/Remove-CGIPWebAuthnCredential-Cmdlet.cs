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
    /// Deletes a registered passkey, or webauthN, device for the currently signed-in user.
    /// 
    ///  
    /// <para>
    /// Authorize this action with a signed-in user's access token. It must include the scope
    /// <c>aws.cognito.signin.user.admin</c>.
    /// </para>
    /// </summary>
    [Cmdlet("Remove", "CGIPWebAuthnCredential", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Cognito Identity Provider DeleteWebAuthnCredential API operation.", Operation = new[] {"DeleteWebAuthnCredential"}, SelectReturnType = typeof(Amazon.CognitoIdentityProvider.Model.DeleteWebAuthnCredentialResponse))]
    [AWSCmdletOutput("None or Amazon.CognitoIdentityProvider.Model.DeleteWebAuthnCredentialResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.CognitoIdentityProvider.Model.DeleteWebAuthnCredentialResponse) be returned by specifying '-Select *'."
    )]
    public partial class RemoveCGIPWebAuthnCredentialCmdlet : AmazonCognitoIdentityProviderClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AccessToken
        /// <summary>
        /// <para>
        /// <para>A valid access token that Amazon Cognito issued to the user whose passkey you want
        /// to delete.</para>
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
        public System.String AccessToken { get; set; }
        #endregion
        
        #region Parameter CredentialId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the passkey that you want to delete. Look up registered devices
        /// with <a href="https://docs.aws.amazon.com/cognito-user-identity-pools/latest/APIReference/API_ListWebAuthnCredentials.html">
        /// ListWebAuthnCredentials</a>.</para>
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
        public System.String CredentialId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CognitoIdentityProvider.Model.DeleteWebAuthnCredentialResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the CredentialId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^CredentialId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^CredentialId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CredentialId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-CGIPWebAuthnCredential (DeleteWebAuthnCredential)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CognitoIdentityProvider.Model.DeleteWebAuthnCredentialResponse, RemoveCGIPWebAuthnCredentialCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.CredentialId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AccessToken = this.AccessToken;
            #if MODULAR
            if (this.AccessToken == null && ParameterWasBound(nameof(this.AccessToken)))
            {
                WriteWarning("You are passing $null as a value for parameter AccessToken which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CredentialId = this.CredentialId;
            #if MODULAR
            if (this.CredentialId == null && ParameterWasBound(nameof(this.CredentialId)))
            {
                WriteWarning("You are passing $null as a value for parameter CredentialId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CognitoIdentityProvider.Model.DeleteWebAuthnCredentialRequest();
            
            if (cmdletContext.AccessToken != null)
            {
                request.AccessToken = cmdletContext.AccessToken;
            }
            if (cmdletContext.CredentialId != null)
            {
                request.CredentialId = cmdletContext.CredentialId;
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
        
        private Amazon.CognitoIdentityProvider.Model.DeleteWebAuthnCredentialResponse CallAWSServiceOperation(IAmazonCognitoIdentityProvider client, Amazon.CognitoIdentityProvider.Model.DeleteWebAuthnCredentialRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Cognito Identity Provider", "DeleteWebAuthnCredential");
            try
            {
                #if DESKTOP
                return client.DeleteWebAuthnCredential(request);
                #elif CORECLR
                return client.DeleteWebAuthnCredentialAsync(request).GetAwaiter().GetResult();
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
            public System.String AccessToken { get; set; }
            public System.String CredentialId { get; set; }
            public System.Func<Amazon.CognitoIdentityProvider.Model.DeleteWebAuthnCredentialResponse, RemoveCGIPWebAuthnCredentialCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
