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
    /// Links an existing user account in a user pool, or <c>DestinationUser</c>, to an identity
    /// from an external IdP, or <c>SourceUser</c>, based on a specified attribute name and
    /// value from the external IdP.
    /// 
    ///  
    /// <para>
    /// This operation connects a local user profile with a user identity who hasn't yet signed
    /// in from their third-party IdP. When the user signs in with their IdP, they get access-control
    /// configuration from the local user profile. Linked local users can also sign in with
    /// SDK-based API operations like <c>InitiateAuth</c> after they sign in at least once
    /// through their IdP. For more information, see <a href="https://docs.aws.amazon.com/cognito/latest/developerguide/cognito-user-pools-identity-federation-consolidate-users.html">Linking
    /// federated users</a>.
    /// </para><note><para>
    /// The maximum number of federated identities linked to a user is five.
    /// </para></note><important><para>
    /// Because this API allows a user with an external federated identity to sign in as a
    /// local user, it is critical that it only be used with external IdPs and linked attributes
    /// that you trust.
    /// </para></important><note><para>
    /// Amazon Cognito evaluates Identity and Access Management (IAM) policies in requests
    /// for this API operation. For this operation, you must use IAM credentials to authorize
    /// requests, and you must grant yourself the corresponding IAM permission in a policy.
    /// </para><para><b>Learn more</b></para><ul><li><para><a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/reference_aws-signing.html">Signing
    /// Amazon Web Services API Requests</a></para></li><li><para><a href="https://docs.aws.amazon.com/cognito/latest/developerguide/user-pools-API-operations.html">Using
    /// the Amazon Cognito user pools API and user pool endpoints</a></para></li></ul></note>
    /// </summary>
    [Cmdlet("Connect", "CGIPProviderForUserAdmin", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Cognito Identity Provider AdminLinkProviderForUser API operation.", Operation = new[] {"AdminLinkProviderForUser"}, SelectReturnType = typeof(Amazon.CognitoIdentityProvider.Model.AdminLinkProviderForUserResponse))]
    [AWSCmdletOutput("None or Amazon.CognitoIdentityProvider.Model.AdminLinkProviderForUserResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.CognitoIdentityProvider.Model.AdminLinkProviderForUserResponse) be returned by specifying '-Select *'."
    )]
    public partial class ConnectCGIPProviderForUserAdminCmdlet : AmazonCognitoIdentityProviderClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DestinationUser_ProviderAttributeName
        /// <summary>
        /// <para>
        /// <para>The name of the provider attribute to link to, such as <c>NameID</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DestinationUser_ProviderAttributeName { get; set; }
        #endregion
        
        #region Parameter SourceUser_ProviderAttributeName
        /// <summary>
        /// <para>
        /// <para>The name of the provider attribute to link to, such as <c>NameID</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceUser_ProviderAttributeName { get; set; }
        #endregion
        
        #region Parameter DestinationUser_ProviderAttributeValue
        /// <summary>
        /// <para>
        /// <para>The value of the provider attribute to link to, such as <c>xxxxx_account</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DestinationUser_ProviderAttributeValue { get; set; }
        #endregion
        
        #region Parameter SourceUser_ProviderAttributeValue
        /// <summary>
        /// <para>
        /// <para>The value of the provider attribute to link to, such as <c>xxxxx_account</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceUser_ProviderAttributeValue { get; set; }
        #endregion
        
        #region Parameter DestinationUser_ProviderName
        /// <summary>
        /// <para>
        /// <para>The name of the provider, such as Facebook, Google, or Login with Amazon.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DestinationUser_ProviderName { get; set; }
        #endregion
        
        #region Parameter SourceUser_ProviderName
        /// <summary>
        /// <para>
        /// <para>The name of the provider, such as Facebook, Google, or Login with Amazon.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceUser_ProviderName { get; set; }
        #endregion
        
        #region Parameter UserPoolId
        /// <summary>
        /// <para>
        /// <para>The ID of the user pool where you want to link a federated identity.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CognitoIdentityProvider.Model.AdminLinkProviderForUserResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Connect-CGIPProviderForUserAdmin (AdminLinkProviderForUser)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CognitoIdentityProvider.Model.AdminLinkProviderForUserResponse, ConnectCGIPProviderForUserAdminCmdlet>(Select) ??
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
            context.DestinationUser_ProviderAttributeName = this.DestinationUser_ProviderAttributeName;
            context.DestinationUser_ProviderAttributeValue = this.DestinationUser_ProviderAttributeValue;
            context.DestinationUser_ProviderName = this.DestinationUser_ProviderName;
            context.SourceUser_ProviderAttributeName = this.SourceUser_ProviderAttributeName;
            context.SourceUser_ProviderAttributeValue = this.SourceUser_ProviderAttributeValue;
            context.SourceUser_ProviderName = this.SourceUser_ProviderName;
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
            var request = new Amazon.CognitoIdentityProvider.Model.AdminLinkProviderForUserRequest();
            
            
             // populate DestinationUser
            var requestDestinationUserIsNull = true;
            request.DestinationUser = new Amazon.CognitoIdentityProvider.Model.ProviderUserIdentifierType();
            System.String requestDestinationUser_destinationUser_ProviderAttributeName = null;
            if (cmdletContext.DestinationUser_ProviderAttributeName != null)
            {
                requestDestinationUser_destinationUser_ProviderAttributeName = cmdletContext.DestinationUser_ProviderAttributeName;
            }
            if (requestDestinationUser_destinationUser_ProviderAttributeName != null)
            {
                request.DestinationUser.ProviderAttributeName = requestDestinationUser_destinationUser_ProviderAttributeName;
                requestDestinationUserIsNull = false;
            }
            System.String requestDestinationUser_destinationUser_ProviderAttributeValue = null;
            if (cmdletContext.DestinationUser_ProviderAttributeValue != null)
            {
                requestDestinationUser_destinationUser_ProviderAttributeValue = cmdletContext.DestinationUser_ProviderAttributeValue;
            }
            if (requestDestinationUser_destinationUser_ProviderAttributeValue != null)
            {
                request.DestinationUser.ProviderAttributeValue = requestDestinationUser_destinationUser_ProviderAttributeValue;
                requestDestinationUserIsNull = false;
            }
            System.String requestDestinationUser_destinationUser_ProviderName = null;
            if (cmdletContext.DestinationUser_ProviderName != null)
            {
                requestDestinationUser_destinationUser_ProviderName = cmdletContext.DestinationUser_ProviderName;
            }
            if (requestDestinationUser_destinationUser_ProviderName != null)
            {
                request.DestinationUser.ProviderName = requestDestinationUser_destinationUser_ProviderName;
                requestDestinationUserIsNull = false;
            }
             // determine if request.DestinationUser should be set to null
            if (requestDestinationUserIsNull)
            {
                request.DestinationUser = null;
            }
            
             // populate SourceUser
            var requestSourceUserIsNull = true;
            request.SourceUser = new Amazon.CognitoIdentityProvider.Model.ProviderUserIdentifierType();
            System.String requestSourceUser_sourceUser_ProviderAttributeName = null;
            if (cmdletContext.SourceUser_ProviderAttributeName != null)
            {
                requestSourceUser_sourceUser_ProviderAttributeName = cmdletContext.SourceUser_ProviderAttributeName;
            }
            if (requestSourceUser_sourceUser_ProviderAttributeName != null)
            {
                request.SourceUser.ProviderAttributeName = requestSourceUser_sourceUser_ProviderAttributeName;
                requestSourceUserIsNull = false;
            }
            System.String requestSourceUser_sourceUser_ProviderAttributeValue = null;
            if (cmdletContext.SourceUser_ProviderAttributeValue != null)
            {
                requestSourceUser_sourceUser_ProviderAttributeValue = cmdletContext.SourceUser_ProviderAttributeValue;
            }
            if (requestSourceUser_sourceUser_ProviderAttributeValue != null)
            {
                request.SourceUser.ProviderAttributeValue = requestSourceUser_sourceUser_ProviderAttributeValue;
                requestSourceUserIsNull = false;
            }
            System.String requestSourceUser_sourceUser_ProviderName = null;
            if (cmdletContext.SourceUser_ProviderName != null)
            {
                requestSourceUser_sourceUser_ProviderName = cmdletContext.SourceUser_ProviderName;
            }
            if (requestSourceUser_sourceUser_ProviderName != null)
            {
                request.SourceUser.ProviderName = requestSourceUser_sourceUser_ProviderName;
                requestSourceUserIsNull = false;
            }
             // determine if request.SourceUser should be set to null
            if (requestSourceUserIsNull)
            {
                request.SourceUser = null;
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
        
        private Amazon.CognitoIdentityProvider.Model.AdminLinkProviderForUserResponse CallAWSServiceOperation(IAmazonCognitoIdentityProvider client, Amazon.CognitoIdentityProvider.Model.AdminLinkProviderForUserRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Cognito Identity Provider", "AdminLinkProviderForUser");
            try
            {
                #if DESKTOP
                return client.AdminLinkProviderForUser(request);
                #elif CORECLR
                return client.AdminLinkProviderForUserAsync(request).GetAwaiter().GetResult();
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
            public System.String DestinationUser_ProviderAttributeName { get; set; }
            public System.String DestinationUser_ProviderAttributeValue { get; set; }
            public System.String DestinationUser_ProviderName { get; set; }
            public System.String SourceUser_ProviderAttributeName { get; set; }
            public System.String SourceUser_ProviderAttributeValue { get; set; }
            public System.String SourceUser_ProviderName { get; set; }
            public System.String UserPoolId { get; set; }
            public System.Func<Amazon.CognitoIdentityProvider.Model.AdminLinkProviderForUserResponse, ConnectCGIPProviderForUserAdminCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
