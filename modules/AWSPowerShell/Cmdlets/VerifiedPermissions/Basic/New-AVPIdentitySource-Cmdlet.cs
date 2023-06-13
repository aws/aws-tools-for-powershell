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
using Amazon.VerifiedPermissions;
using Amazon.VerifiedPermissions.Model;

namespace Amazon.PowerShell.Cmdlets.AVP
{
    /// <summary>
    /// Creates a reference to an Amazon Cognito user pool as an external identity provider
    /// (IdP). 
    /// 
    ///  
    /// <para>
    /// After you create an identity source, you can use the identities provided by the IdP
    /// as proxies for the principal in authorization queries that use the <a href="https://docs.aws.amazon.com/verifiedpermissions/latest/apireference/API_IsAuthorizedWithToken.html">IsAuthorizedWithToken</a>
    /// operation. These identities take the form of tokens that contain claims about the
    /// user, such as IDs, attributes and group memberships. Amazon Cognito provides both
    /// identity tokens and access tokens, and Verified Permissions can use either or both.
    /// Any combination of identity and access tokens results in the same Cedar principal.
    /// Verified Permissions automatically translates the information about the identities
    /// into the standard Cedar attributes that can be evaluated by your policies. Because
    /// the Amazon Cognito identity and access tokens can contain different information, the
    /// tokens you choose to use determine which principal attributes are available to access
    /// when evaluating Cedar policies.
    /// </para><important><para>
    /// If you delete a Amazon Cognito user pool or user, tokens from that deleted pool or
    /// that deleted user continue to be usable until they expire.
    /// </para></important><note><para>
    /// To reference a user from this identity source in your Cedar policies, use the following
    /// syntax.
    /// </para><para><i>IdentityType::"&lt;CognitoUserPoolIdentifier&gt;|&lt;CognitoClientId&gt;</i></para><para>
    /// Where <code>IdentityType</code> is the string that you provide to the <code>PrincipalEntityType</code>
    /// parameter for this operation. The <code>CognitoUserPoolId</code> and <code>CognitoClientId</code>
    /// are defined by the Amazon Cognito user pool.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "AVPIdentitySource", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.VerifiedPermissions.Model.CreateIdentitySourceResponse")]
    [AWSCmdlet("Calls the Amazon Verified Permissions CreateIdentitySource API operation.", Operation = new[] {"CreateIdentitySource"}, SelectReturnType = typeof(Amazon.VerifiedPermissions.Model.CreateIdentitySourceResponse))]
    [AWSCmdletOutput("Amazon.VerifiedPermissions.Model.CreateIdentitySourceResponse",
        "This cmdlet returns an Amazon.VerifiedPermissions.Model.CreateIdentitySourceResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewAVPIdentitySourceCmdlet : AmazonVerifiedPermissionsClientCmdlet, IExecutor
    {
        
        #region Parameter CognitoUserPoolConfiguration_ClientId
        /// <summary>
        /// <para>
        /// <para>The unique application client IDs that are associated with the specified Amazon Cognito
        /// user pool.</para><para>Example: <code>"ClientIds": ["&amp;ExampleCogClientId;"]</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_CognitoUserPoolConfiguration_ClientIds")]
        public System.String[] CognitoUserPoolConfiguration_ClientId { get; set; }
        #endregion
        
        #region Parameter PolicyStoreId
        /// <summary>
        /// <para>
        /// <para>Specifies the ID of the policy store in which you want to store this identity source.
        /// Only policies and requests made using this policy store can reference identities from
        /// the identity provider configured in the new identity source.</para>
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
        public System.String PolicyStoreId { get; set; }
        #endregion
        
        #region Parameter PrincipalEntityType
        /// <summary>
        /// <para>
        /// <para>Specifies the namespace and data type of the principals generated for identities authenticated
        /// by the new identity source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PrincipalEntityType { get; set; }
        #endregion
        
        #region Parameter CognitoUserPoolConfiguration_UserPoolArn
        /// <summary>
        /// <para>
        /// <para>The <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">Amazon
        /// Resource Name (ARN)</a> of the Amazon Cognito user pool that contains the identities
        /// to be authorized.</para><para>Example: <code>"UserPoolArn": "cognito-idp:us-east-1:123456789012:userpool/us-east-1_1a2b3c4d5"</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_CognitoUserPoolConfiguration_UserPoolArn")]
        public System.String CognitoUserPoolConfiguration_UserPoolArn { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Specifies a unique, case-sensitive ID that you provide to ensure the idempotency of
        /// the request. This lets you safely retry the request without accidentally performing
        /// the same operation a second time. Passing the same value to a later call to an operation
        /// requires that you also pass the same value for all other parameters. We recommend
        /// that you use a <a href="https://wikipedia.org/wiki/Universally_unique_Id">UUID type
        /// of value.</a>.</para><para>If you don't provide this value, then Amazon Web Services generates a random one for
        /// you.</para><para>If you retry the operation with the same <code>ClientToken</code>, but with different
        /// parameters, the retry fails with an <code>IdempotentParameterMismatch</code> error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.VerifiedPermissions.Model.CreateIdentitySourceResponse).
        /// Specifying the name of a property of type Amazon.VerifiedPermissions.Model.CreateIdentitySourceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the PolicyStoreId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^PolicyStoreId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^PolicyStoreId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PolicyStoreId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-AVPIdentitySource (CreateIdentitySource)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.VerifiedPermissions.Model.CreateIdentitySourceResponse, NewAVPIdentitySourceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.PolicyStoreId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            if (this.CognitoUserPoolConfiguration_ClientId != null)
            {
                context.CognitoUserPoolConfiguration_ClientId = new List<System.String>(this.CognitoUserPoolConfiguration_ClientId);
            }
            context.CognitoUserPoolConfiguration_UserPoolArn = this.CognitoUserPoolConfiguration_UserPoolArn;
            context.PolicyStoreId = this.PolicyStoreId;
            #if MODULAR
            if (this.PolicyStoreId == null && ParameterWasBound(nameof(this.PolicyStoreId)))
            {
                WriteWarning("You are passing $null as a value for parameter PolicyStoreId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PrincipalEntityType = this.PrincipalEntityType;
            
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
            var request = new Amazon.VerifiedPermissions.Model.CreateIdentitySourceRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate Configuration
            var requestConfigurationIsNull = true;
            request.Configuration = new Amazon.VerifiedPermissions.Model.Configuration();
            Amazon.VerifiedPermissions.Model.CognitoUserPoolConfiguration requestConfiguration_configuration_CognitoUserPoolConfiguration = null;
            
             // populate CognitoUserPoolConfiguration
            var requestConfiguration_configuration_CognitoUserPoolConfigurationIsNull = true;
            requestConfiguration_configuration_CognitoUserPoolConfiguration = new Amazon.VerifiedPermissions.Model.CognitoUserPoolConfiguration();
            List<System.String> requestConfiguration_configuration_CognitoUserPoolConfiguration_cognitoUserPoolConfiguration_ClientId = null;
            if (cmdletContext.CognitoUserPoolConfiguration_ClientId != null)
            {
                requestConfiguration_configuration_CognitoUserPoolConfiguration_cognitoUserPoolConfiguration_ClientId = cmdletContext.CognitoUserPoolConfiguration_ClientId;
            }
            if (requestConfiguration_configuration_CognitoUserPoolConfiguration_cognitoUserPoolConfiguration_ClientId != null)
            {
                requestConfiguration_configuration_CognitoUserPoolConfiguration.ClientIds = requestConfiguration_configuration_CognitoUserPoolConfiguration_cognitoUserPoolConfiguration_ClientId;
                requestConfiguration_configuration_CognitoUserPoolConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_CognitoUserPoolConfiguration_cognitoUserPoolConfiguration_UserPoolArn = null;
            if (cmdletContext.CognitoUserPoolConfiguration_UserPoolArn != null)
            {
                requestConfiguration_configuration_CognitoUserPoolConfiguration_cognitoUserPoolConfiguration_UserPoolArn = cmdletContext.CognitoUserPoolConfiguration_UserPoolArn;
            }
            if (requestConfiguration_configuration_CognitoUserPoolConfiguration_cognitoUserPoolConfiguration_UserPoolArn != null)
            {
                requestConfiguration_configuration_CognitoUserPoolConfiguration.UserPoolArn = requestConfiguration_configuration_CognitoUserPoolConfiguration_cognitoUserPoolConfiguration_UserPoolArn;
                requestConfiguration_configuration_CognitoUserPoolConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_CognitoUserPoolConfiguration should be set to null
            if (requestConfiguration_configuration_CognitoUserPoolConfigurationIsNull)
            {
                requestConfiguration_configuration_CognitoUserPoolConfiguration = null;
            }
            if (requestConfiguration_configuration_CognitoUserPoolConfiguration != null)
            {
                request.Configuration.CognitoUserPoolConfiguration = requestConfiguration_configuration_CognitoUserPoolConfiguration;
                requestConfigurationIsNull = false;
            }
             // determine if request.Configuration should be set to null
            if (requestConfigurationIsNull)
            {
                request.Configuration = null;
            }
            if (cmdletContext.PolicyStoreId != null)
            {
                request.PolicyStoreId = cmdletContext.PolicyStoreId;
            }
            if (cmdletContext.PrincipalEntityType != null)
            {
                request.PrincipalEntityType = cmdletContext.PrincipalEntityType;
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
        
        private Amazon.VerifiedPermissions.Model.CreateIdentitySourceResponse CallAWSServiceOperation(IAmazonVerifiedPermissions client, Amazon.VerifiedPermissions.Model.CreateIdentitySourceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Verified Permissions", "CreateIdentitySource");
            try
            {
                #if DESKTOP
                return client.CreateIdentitySource(request);
                #elif CORECLR
                return client.CreateIdentitySourceAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> CognitoUserPoolConfiguration_ClientId { get; set; }
            public System.String CognitoUserPoolConfiguration_UserPoolArn { get; set; }
            public System.String PolicyStoreId { get; set; }
            public System.String PrincipalEntityType { get; set; }
            public System.Func<Amazon.VerifiedPermissions.Model.CreateIdentitySourceResponse, NewAVPIdentitySourceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
