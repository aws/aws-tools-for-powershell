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
using Amazon.SecurityToken;
using Amazon.SecurityToken.Model;

namespace Amazon.PowerShell.Cmdlets.STS
{
    /// <summary>
    /// Returns a signed JSON Web Token (JWT) that represents the calling Amazon Web Services
    /// identity. The returned JWT can be used to authenticate with external services that
    /// support OIDC discovery. The token is signed by Amazon Web Services STS and can be
    /// publicly verified using the verification keys published at the issuer's JWKS endpoint.
    /// </summary>
    [Cmdlet("Get", "STSWebIdentityToken")]
    [OutputType("Amazon.SecurityToken.Model.GetWebIdentityTokenResponse")]
    [AWSCmdlet("Calls the AWS Security Token Service (STS) GetWebIdentityToken API operation.", Operation = new[] {"GetWebIdentityToken"}, SelectReturnType = typeof(Amazon.SecurityToken.Model.GetWebIdentityTokenResponse))]
    [AWSCmdletOutput("Amazon.SecurityToken.Model.GetWebIdentityTokenResponse",
        "This cmdlet returns an Amazon.SecurityToken.Model.GetWebIdentityTokenResponse object containing multiple properties."
    )]
    public partial class GetSTSWebIdentityTokenCmdlet : AmazonSecurityTokenServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Audience
        /// <summary>
        /// <para>
        /// <para>The intended recipient of the web identity token. This value populates the <c>aud</c>
        /// claim in the JWT and should identify the service or application that will validate
        /// and use the token. The external service should verify this claim to ensure the token
        /// was intended for their use.</para>
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
        public System.String[] Audience { get; set; }
        #endregion
        
        #region Parameter DurationSecond
        /// <summary>
        /// <para>
        /// <para>The duration, in seconds, for which the JSON Web Token (JWT) will remain valid. The
        /// value can range from 60 seconds (1 minute) to 3600 seconds (1 hour). If not specified,
        /// the default duration is 300 seconds (5 minutes). The token is designed to be short-lived
        /// and should be used for proof of identity, then exchanged for credentials or short-lived
        /// tokens in the external service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DurationSeconds")]
        public System.Int32? DurationSecond { get; set; }
        #endregion
        
        #region Parameter SigningAlgorithm
        /// <summary>
        /// <para>
        /// <para>The cryptographic algorithm to use for signing the JSON Web Token (JWT). Valid values
        /// are RS256 (RSA with SHA-256) and ES384 (ECDSA using P-384 curve with SHA-384). </para>
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
        public System.String SigningAlgorithm { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>An optional list of tags to include in the JSON Web Token (JWT). These tags are added
        /// as custom claims to the JWT and can be used by the downstream service for authorization
        /// decisions. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.SecurityToken.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecurityToken.Model.GetWebIdentityTokenResponse).
        /// Specifying the name of a property of type Amazon.SecurityToken.Model.GetWebIdentityTokenResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the SigningAlgorithm parameter.
        /// The -PassThru parameter is deprecated, use -Select '^SigningAlgorithm' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^SigningAlgorithm' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.SecurityToken.Model.GetWebIdentityTokenResponse, GetSTSWebIdentityTokenCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.SigningAlgorithm;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.Audience != null)
            {
                context.Audience = new List<System.String>(this.Audience);
            }
            #if MODULAR
            if (this.Audience == null && ParameterWasBound(nameof(this.Audience)))
            {
                WriteWarning("You are passing $null as a value for parameter Audience which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DurationSecond = this.DurationSecond;
            context.SigningAlgorithm = this.SigningAlgorithm;
            #if MODULAR
            if (this.SigningAlgorithm == null && ParameterWasBound(nameof(this.SigningAlgorithm)))
            {
                WriteWarning("You are passing $null as a value for parameter SigningAlgorithm which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.SecurityToken.Model.Tag>(this.Tag);
            }
            
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
            var request = new Amazon.SecurityToken.Model.GetWebIdentityTokenRequest();
            
            if (cmdletContext.Audience != null)
            {
                request.Audience = cmdletContext.Audience;
            }
            if (cmdletContext.DurationSecond != null)
            {
                request.DurationSeconds = cmdletContext.DurationSecond.Value;
            }
            if (cmdletContext.SigningAlgorithm != null)
            {
                request.SigningAlgorithm = cmdletContext.SigningAlgorithm;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.SecurityToken.Model.GetWebIdentityTokenResponse CallAWSServiceOperation(IAmazonSecurityTokenService client, Amazon.SecurityToken.Model.GetWebIdentityTokenRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Security Token Service (STS)", "GetWebIdentityToken");
            try
            {
                #if DESKTOP
                return client.GetWebIdentityToken(request);
                #elif CORECLR
                return client.GetWebIdentityTokenAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> Audience { get; set; }
            public System.Int32? DurationSecond { get; set; }
            public System.String SigningAlgorithm { get; set; }
            public List<Amazon.SecurityToken.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.SecurityToken.Model.GetWebIdentityTokenResponse, GetSTSWebIdentityTokenCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
