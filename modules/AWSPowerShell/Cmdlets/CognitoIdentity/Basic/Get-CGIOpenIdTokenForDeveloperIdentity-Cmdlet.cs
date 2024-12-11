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
using Amazon.CognitoIdentity;
using Amazon.CognitoIdentity.Model;

namespace Amazon.PowerShell.Cmdlets.CGI
{
    /// <summary>
    /// Registers (or retrieves) a Cognito <c>IdentityId</c> and an OpenID Connect token for
    /// a user authenticated by your backend authentication process. Supplying multiple logins
    /// will create an implicit linked account. You can only specify one developer provider
    /// as part of the <c>Logins</c> map, which is linked to the identity pool. The developer
    /// provider is the "domain" by which Cognito will refer to your users.
    /// 
    ///  
    /// <para>
    /// You can use <c>GetOpenIdTokenForDeveloperIdentity</c> to create a new identity and
    /// to link new logins (that is, user credentials issued by a public provider or developer
    /// provider) to an existing identity. When you want to create a new identity, the <c>IdentityId</c>
    /// should be null. When you want to associate a new login with an existing authenticated/unauthenticated
    /// identity, you can do so by providing the existing <c>IdentityId</c>. This API will
    /// create the identity in the specified <c>IdentityPoolId</c>.
    /// </para><para>
    /// You must use AWS Developer credentials to call this API.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "CGIOpenIdTokenForDeveloperIdentity")]
    [OutputType("Amazon.CognitoIdentity.Model.GetOpenIdTokenForDeveloperIdentityResponse")]
    [AWSCmdlet("Calls the Amazon Cognito Identity GetOpenIdTokenForDeveloperIdentity API operation.", Operation = new[] {"GetOpenIdTokenForDeveloperIdentity"}, SelectReturnType = typeof(Amazon.CognitoIdentity.Model.GetOpenIdTokenForDeveloperIdentityResponse))]
    [AWSCmdletOutput("Amazon.CognitoIdentity.Model.GetOpenIdTokenForDeveloperIdentityResponse",
        "This cmdlet returns an Amazon.CognitoIdentity.Model.GetOpenIdTokenForDeveloperIdentityResponse object containing multiple properties."
    )]
    public partial class GetCGIOpenIdTokenForDeveloperIdentityCmdlet : AmazonCognitoIdentityClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter IdentityId
        /// <summary>
        /// <para>
        /// <para>A unique identifier in the format REGION:GUID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IdentityId { get; set; }
        #endregion
        
        #region Parameter IdentityPoolId
        /// <summary>
        /// <para>
        /// <para>An identity pool ID in the format REGION:GUID.</para>
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
        public System.String IdentityPoolId { get; set; }
        #endregion
        
        #region Parameter Login
        /// <summary>
        /// <para>
        /// <para>A set of optional name-value pairs that map provider names to provider tokens. Each
        /// name-value pair represents a user from a public provider or developer provider. If
        /// the user is from a developer provider, the name-value pair will follow the syntax
        /// <c>"developer_provider_name": "developer_user_identifier"</c>. The developer provider
        /// is the "domain" by which Cognito will refer to your users; you provided this domain
        /// while creating/updating the identity pool. The developer user identifier is an identifier
        /// from your backend that uniquely identifies a user. When you create an identity pool,
        /// you can specify the supported logins.</para>
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
        [Alias("Logins")]
        public System.Collections.Hashtable Login { get; set; }
        #endregion
        
        #region Parameter PrincipalTag
        /// <summary>
        /// <para>
        /// <para>Use this operation to configure attribute mappings for custom providers. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PrincipalTags")]
        public System.Collections.Hashtable PrincipalTag { get; set; }
        #endregion
        
        #region Parameter TokenDuration
        /// <summary>
        /// <para>
        /// <para>The expiration time of the token, in seconds. You can specify a custom expiration
        /// time for the token so that you can cache it. If you don't provide an expiration time,
        /// the token is valid for 15 minutes. You can exchange the token with Amazon STS for
        /// temporary AWS credentials, which are valid for a maximum of one hour. The maximum
        /// token duration you can set is 24 hours. You should take care in setting the expiration
        /// time for a token, as there are significant security implications: an attacker could
        /// use a leaked token to access your AWS resources for the token's duration.</para><note><para>Please provide for a small grace period, usually no more than 5 minutes, to account
        /// for clock skew.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? TokenDuration { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CognitoIdentity.Model.GetOpenIdTokenForDeveloperIdentityResponse).
        /// Specifying the name of a property of type Amazon.CognitoIdentity.Model.GetOpenIdTokenForDeveloperIdentityResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CognitoIdentity.Model.GetOpenIdTokenForDeveloperIdentityResponse, GetCGIOpenIdTokenForDeveloperIdentityCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.IdentityId = this.IdentityId;
            context.IdentityPoolId = this.IdentityPoolId;
            #if MODULAR
            if (this.IdentityPoolId == null && ParameterWasBound(nameof(this.IdentityPoolId)))
            {
                WriteWarning("You are passing $null as a value for parameter IdentityPoolId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Login != null)
            {
                context.Login = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Login.Keys)
                {
                    context.Login.Add((String)hashKey, (System.String)(this.Login[hashKey]));
                }
            }
            #if MODULAR
            if (this.Login == null && ParameterWasBound(nameof(this.Login)))
            {
                WriteWarning("You are passing $null as a value for parameter Login which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.PrincipalTag != null)
            {
                context.PrincipalTag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.PrincipalTag.Keys)
                {
                    context.PrincipalTag.Add((String)hashKey, (System.String)(this.PrincipalTag[hashKey]));
                }
            }
            context.TokenDuration = this.TokenDuration;
            
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
            var request = new Amazon.CognitoIdentity.Model.GetOpenIdTokenForDeveloperIdentityRequest();
            
            if (cmdletContext.IdentityId != null)
            {
                request.IdentityId = cmdletContext.IdentityId;
            }
            if (cmdletContext.IdentityPoolId != null)
            {
                request.IdentityPoolId = cmdletContext.IdentityPoolId;
            }
            if (cmdletContext.Login != null)
            {
                request.Logins = cmdletContext.Login;
            }
            if (cmdletContext.PrincipalTag != null)
            {
                request.PrincipalTags = cmdletContext.PrincipalTag;
            }
            if (cmdletContext.TokenDuration != null)
            {
                request.TokenDuration = cmdletContext.TokenDuration.Value;
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
        
        private Amazon.CognitoIdentity.Model.GetOpenIdTokenForDeveloperIdentityResponse CallAWSServiceOperation(IAmazonCognitoIdentity client, Amazon.CognitoIdentity.Model.GetOpenIdTokenForDeveloperIdentityRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Cognito Identity", "GetOpenIdTokenForDeveloperIdentity");
            try
            {
                #if DESKTOP
                return client.GetOpenIdTokenForDeveloperIdentity(request);
                #elif CORECLR
                return client.GetOpenIdTokenForDeveloperIdentityAsync(request).GetAwaiter().GetResult();
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
            public System.String IdentityId { get; set; }
            public System.String IdentityPoolId { get; set; }
            public Dictionary<System.String, System.String> Login { get; set; }
            public Dictionary<System.String, System.String> PrincipalTag { get; set; }
            public System.Int64? TokenDuration { get; set; }
            public System.Func<Amazon.CognitoIdentity.Model.GetOpenIdTokenForDeveloperIdentityResponse, GetCGIOpenIdTokenForDeveloperIdentityCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
