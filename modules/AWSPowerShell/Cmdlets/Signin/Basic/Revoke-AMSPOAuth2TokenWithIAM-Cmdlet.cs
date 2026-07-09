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
    /// Grants permission to revoke an OAuth 2.0 refresh token and its associated refresh
    /// tokens
    /// 
    ///  
    /// <para>
    /// Revokes a refresh_token issued by AWS Sign-In, invalidating the entire token chain
    /// so that the refresh_token can no longer be used to mint new access_tokens.
    /// </para><para>
    /// Idempotency: revoking an already-revoked, expired, or otherwise invalid token still
    /// returns 200 OK with an empty body. Only the refresh_token type is accepted.
    /// </para>
    /// </summary>
    [Cmdlet("Revoke", "AMSPOAuth2TokenWithIAM", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Sign-In Data Plane RevokeOAuth2TokenWithIAM API operation.", Operation = new[] {"RevokeOAuth2TokenWithIAM"}, SelectReturnType = typeof(Amazon.Signin.Model.RevokeOAuth2TokenWithIAMResponse))]
    [AWSCmdletOutput("None or Amazon.Signin.Model.RevokeOAuth2TokenWithIAMResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Signin.Model.RevokeOAuth2TokenWithIAMResponse) be returned by specifying '-Select *'."
    )]
    public partial class RevokeAMSPOAuth2TokenWithIAMCmdlet : AmazonSigninClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Token
        /// <summary>
        /// <para>
        /// <para>The refresh_token to revoke. Must be a refresh_token issued by AWS Sign-In (prefix
        /// "ASOR"); access_tokens are not accepted for revocation.</para>
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Signin.Model.RevokeOAuth2TokenWithIAMResponse).
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Revoke-AMSPOAuth2TokenWithIAM (RevokeOAuth2TokenWithIAM)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Signin.Model.RevokeOAuth2TokenWithIAMResponse, RevokeAMSPOAuth2TokenWithIAMCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Token = this.Token;
            #if MODULAR
            if (this.Token == null && ParameterWasBound(nameof(this.Token)))
            {
                WriteWarning("You are passing $null as a value for parameter Token which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Signin.Model.RevokeOAuth2TokenWithIAMRequest();
            
            if (cmdletContext.Token != null)
            {
                request.Token = cmdletContext.Token;
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
        
        private Amazon.Signin.Model.RevokeOAuth2TokenWithIAMResponse CallAWSServiceOperation(IAmazonSignin client, Amazon.Signin.Model.RevokeOAuth2TokenWithIAMRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Sign-In Data Plane", "RevokeOAuth2TokenWithIAM");
            try
            {
                return client.RevokeOAuth2TokenWithIAMAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Func<Amazon.Signin.Model.RevokeOAuth2TokenWithIAMResponse, RevokeAMSPOAuth2TokenWithIAMCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
