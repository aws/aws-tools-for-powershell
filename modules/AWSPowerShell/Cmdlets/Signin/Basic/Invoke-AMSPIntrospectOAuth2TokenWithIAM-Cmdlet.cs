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
using System.Threading;
using Amazon.Signin;
using Amazon.Signin.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.AMSP
{
    /// <summary>
    /// Grants permission to inspect the metadata and state of an OAuth 2.0 access token or
    /// refresh token
    /// 
    ///  
    /// <para>
    /// Implements RFC 7662 OAuth 2.0 Token Introspection over a SigV4-authenticated endpoint.
    /// Inspects the metadata of an access_token or refresh_token issued by AWS Sign-In and
    /// returns the claims associated with it.
    /// </para><para>
    /// Inactive token semantics (RFC 7662 §2.2): when the supplied token is unknown, expired,
    /// revoked, malformed, or owned by a different account, the response body is exactly
    /// { "active": false } with all other claims omitted.
    /// </para>
    /// </summary>
    [Cmdlet("Invoke", "AMSPIntrospectOAuth2TokenWithIAM", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Signin.Model.IntrospectOAuth2TokenWithIAMResponse")]
    [AWSCmdlet("Calls the AWS Sign-In Data Plane IntrospectOAuth2TokenWithIAM API operation.", Operation = new[] {"IntrospectOAuth2TokenWithIAM"}, SelectReturnType = typeof(Amazon.Signin.Model.IntrospectOAuth2TokenWithIAMResponse))]
    [AWSCmdletOutput("Amazon.Signin.Model.IntrospectOAuth2TokenWithIAMResponse",
        "This cmdlet returns an Amazon.Signin.Model.IntrospectOAuth2TokenWithIAMResponse object containing multiple properties."
    )]
    public partial class InvokeAMSPIntrospectOAuth2TokenWithIAMCmdlet : AmazonSigninClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Token
        /// <summary>
        /// <para>
        /// <para>The string value of the token to introspect. May be either an access_token or a refresh_token
        /// issued by AWS Sign-In.</para>
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
        public System.String Token { get; set; }
        #endregion
        
        #region Parameter TokenTypeHint
        /// <summary>
        /// <para>
        /// <para>Optional hint about the type of the token submitted for introspection. The server
        /// uses this hint to optimize lookup, but still falls back to the other token type on
        /// miss. Allowed values: access_token, refresh_token.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TokenTypeHint { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Signin.Model.IntrospectOAuth2TokenWithIAMResponse).
        /// Specifying the name of a property of type Amazon.Signin.Model.IntrospectOAuth2TokenWithIAMResponse will result in that property being returned.
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Token), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-AMSPIntrospectOAuth2TokenWithIAM (IntrospectOAuth2TokenWithIAM)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Signin.Model.IntrospectOAuth2TokenWithIAMResponse, InvokeAMSPIntrospectOAuth2TokenWithIAMCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Token = this.Token;
            #if MODULAR
            if (this.Token == null && ParameterWasBound(nameof(this.Token)))
            {
                WriteWarning("You are passing $null as a value for parameter Token which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TokenTypeHint = this.TokenTypeHint;
            
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
            var request = new Amazon.Signin.Model.IntrospectOAuth2TokenWithIAMRequest();
            
            if (cmdletContext.Token != null)
            {
                request.Token = cmdletContext.Token;
            }
            if (cmdletContext.TokenTypeHint != null)
            {
                request.TokenTypeHint = cmdletContext.TokenTypeHint;
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
        
        private Amazon.Signin.Model.IntrospectOAuth2TokenWithIAMResponse CallAWSServiceOperation(IAmazonSignin client, Amazon.Signin.Model.IntrospectOAuth2TokenWithIAMRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Sign-In Data Plane", "IntrospectOAuth2TokenWithIAM");
            try
            {
                return client.IntrospectOAuth2TokenWithIAMAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Token { get; set; }
            public System.String TokenTypeHint { get; set; }
            public System.Func<Amazon.Signin.Model.IntrospectOAuth2TokenWithIAMResponse, InvokeAMSPIntrospectOAuth2TokenWithIAMCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
