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
using Amazon.Wickr;
using Amazon.Wickr.Model;

namespace Amazon.PowerShell.Cmdlets.WIC
{
    /// <summary>
    /// Retrieves the OpenID Connect (OIDC) configuration for a Wickr network, including SSO
    /// settings and optional token information if access token parameters are provided.
    /// </summary>
    [Cmdlet("Get", "WICOidcInfo")]
    [OutputType("Amazon.Wickr.Model.GetOidcInfoResponse")]
    [AWSCmdlet("Calls the AWS Wickr Admin API GetOidcInfo API operation.", Operation = new[] {"GetOidcInfo"}, SelectReturnType = typeof(Amazon.Wickr.Model.GetOidcInfoResponse))]
    [AWSCmdletOutput("Amazon.Wickr.Model.GetOidcInfoResponse",
        "This cmdlet returns an Amazon.Wickr.Model.GetOidcInfoResponse object containing multiple properties."
    )]
    public partial class GetWICOidcInfoCmdlet : AmazonWickrClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Certificate
        /// <summary>
        /// <para>
        /// <para>The CA certificate for secure communication with the OIDC provider (optional).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Certificate { get; set; }
        #endregion
        
        #region Parameter ClientId
        /// <summary>
        /// <para>
        /// <para>The OAuth client ID for retrieving access tokens (optional).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientId { get; set; }
        #endregion
        
        #region Parameter ClientSecret
        /// <summary>
        /// <para>
        /// <para>The OAuth client secret for retrieving access tokens (optional).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientSecret { get; set; }
        #endregion
        
        #region Parameter Code
        /// <summary>
        /// <para>
        /// <para>The authorization code for retrieving access tokens (optional).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Code { get; set; }
        #endregion
        
        #region Parameter CodeVerifier
        /// <summary>
        /// <para>
        /// <para>The PKCE code verifier for enhanced security in the OAuth flow (optional).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CodeVerifier { get; set; }
        #endregion
        
        #region Parameter GrantType
        /// <summary>
        /// <para>
        /// <para>The OAuth grant type for retrieving access tokens (optional).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GrantType { get; set; }
        #endregion
        
        #region Parameter NetworkId
        /// <summary>
        /// <para>
        /// <para>The ID of the Wickr network whose OIDC configuration will be retrieved.</para>
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
        public System.String NetworkId { get; set; }
        #endregion
        
        #region Parameter RedirectUri
        /// <summary>
        /// <para>
        /// <para>The redirect URI for the OAuth flow (optional).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RedirectUri { get; set; }
        #endregion
        
        #region Parameter Url
        /// <summary>
        /// <para>
        /// <para>The URL for the OIDC provider (optional).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Url { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Wickr.Model.GetOidcInfoResponse).
        /// Specifying the name of a property of type Amazon.Wickr.Model.GetOidcInfoResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the NetworkId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^NetworkId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^NetworkId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Wickr.Model.GetOidcInfoResponse, GetWICOidcInfoCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.NetworkId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Certificate = this.Certificate;
            context.ClientId = this.ClientId;
            context.ClientSecret = this.ClientSecret;
            context.Code = this.Code;
            context.CodeVerifier = this.CodeVerifier;
            context.GrantType = this.GrantType;
            context.NetworkId = this.NetworkId;
            #if MODULAR
            if (this.NetworkId == null && ParameterWasBound(nameof(this.NetworkId)))
            {
                WriteWarning("You are passing $null as a value for parameter NetworkId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RedirectUri = this.RedirectUri;
            context.Url = this.Url;
            
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
            var request = new Amazon.Wickr.Model.GetOidcInfoRequest();
            
            if (cmdletContext.Certificate != null)
            {
                request.Certificate = cmdletContext.Certificate;
            }
            if (cmdletContext.ClientId != null)
            {
                request.ClientId = cmdletContext.ClientId;
            }
            if (cmdletContext.ClientSecret != null)
            {
                request.ClientSecret = cmdletContext.ClientSecret;
            }
            if (cmdletContext.Code != null)
            {
                request.Code = cmdletContext.Code;
            }
            if (cmdletContext.CodeVerifier != null)
            {
                request.CodeVerifier = cmdletContext.CodeVerifier;
            }
            if (cmdletContext.GrantType != null)
            {
                request.GrantType = cmdletContext.GrantType;
            }
            if (cmdletContext.NetworkId != null)
            {
                request.NetworkId = cmdletContext.NetworkId;
            }
            if (cmdletContext.RedirectUri != null)
            {
                request.RedirectUri = cmdletContext.RedirectUri;
            }
            if (cmdletContext.Url != null)
            {
                request.Url = cmdletContext.Url;
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
        
        private Amazon.Wickr.Model.GetOidcInfoResponse CallAWSServiceOperation(IAmazonWickr client, Amazon.Wickr.Model.GetOidcInfoRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Wickr Admin API", "GetOidcInfo");
            try
            {
                #if DESKTOP
                return client.GetOidcInfo(request);
                #elif CORECLR
                return client.GetOidcInfoAsync(request).GetAwaiter().GetResult();
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
            public System.String Certificate { get; set; }
            public System.String ClientId { get; set; }
            public System.String ClientSecret { get; set; }
            public System.String Code { get; set; }
            public System.String CodeVerifier { get; set; }
            public System.String GrantType { get; set; }
            public System.String NetworkId { get; set; }
            public System.String RedirectUri { get; set; }
            public System.String Url { get; set; }
            public System.Func<Amazon.Wickr.Model.GetOidcInfoResponse, GetWICOidcInfoCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
