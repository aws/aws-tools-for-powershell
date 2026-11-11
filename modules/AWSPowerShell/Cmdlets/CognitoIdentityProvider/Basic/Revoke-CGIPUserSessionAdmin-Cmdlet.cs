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
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CGIP
{
    /// <summary>
    /// Revokes a specific user session as an administrator. Amazon Cognito revokes all refresh
    /// and access tokens that are associated with the session and deletes the session record.
    /// You can revoke either a token session or an SSO session, and you can optionally cascade
    /// the revocation to linked sessions.
    /// </summary>
    [Cmdlet("Revoke", "CGIPUserSessionAdmin", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Cognito Identity Provider AdminRevokeUserSession API operation.", Operation = new[] {"AdminRevokeUserSession"}, SelectReturnType = typeof(Amazon.CognitoIdentityProvider.Model.AdminRevokeUserSessionResponse))]
    [AWSCmdletOutput("None or Amazon.CognitoIdentityProvider.Model.AdminRevokeUserSessionResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.CognitoIdentityProvider.Model.AdminRevokeUserSessionResponse) be returned by specifying '-Select *'."
    )]
    public partial class RevokeCGIPUserSessionAdminCmdlet : AmazonCognitoIdentityProviderClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter RevokeAssociatedSession
        /// <summary>
        /// <para>
        /// <para>Specifies whether to also revoke the sessions that are linked to the targeted session.
        /// <c>NONE</c>, the default, revokes only the targeted session. <c>LINKED</c> also revokes
        /// the directly linked session or sessions, interpreted relative to the type of the targeted
        /// session: revoking a token session also revokes the parent SSO session it came through,
        /// and revoking an SSO session also revokes the token sessions that came through it.
        /// The set of linked sessions is eventually consistent, so associated sessions are typically
        /// revoked within a few seconds.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RevokeAssociatedSessions")]
        [AWSConstantClassSource("Amazon.CognitoIdentityProvider.RevokeAssociatedSessionsType")]
        public Amazon.CognitoIdentityProvider.RevokeAssociatedSessionsType RevokeAssociatedSession { get; set; }
        #endregion
        
        #region Parameter SessionId
        /// <summary>
        /// <para>
        /// <para>The ID of the session to revoke. This is a 28-character string of lowercase letters
        /// and digits, prefixed with <c>tkn</c> for a token session or <c>sso</c> for an SSO
        /// session.</para>
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
        public System.String SessionId { get; set; }
        #endregion
        
        #region Parameter Username
        /// <summary>
        /// <para>
        /// <para>The username of the user who owns the session. The username must match the user associated
        /// with the <c>SessionId</c>, to confirm they are the intended target user.</para>
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
        public System.String Username { get; set; }
        #endregion
        
        #region Parameter UserPoolId
        /// <summary>
        /// <para>
        /// <para>The ID of the user pool that contains the session.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CognitoIdentityProvider.Model.AdminRevokeUserSessionResponse).
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
            
            var targetParameterNames = new string[]
            {
                nameof(this.SessionId),
                nameof(this.UserPoolId),
                nameof(this.Username)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters, new System.Collections.Generic.HashSet<string> { nameof(this.Username) });
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Revoke-CGIPUserSessionAdmin (AdminRevokeUserSession)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CognitoIdentityProvider.Model.AdminRevokeUserSessionResponse, RevokeCGIPUserSessionAdminCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.RevokeAssociatedSession = this.RevokeAssociatedSession;
            context.SessionId = this.SessionId;
            #if MODULAR
            if (this.SessionId == null && ParameterWasBound(nameof(this.SessionId)))
            {
                WriteWarning("You are passing $null as a value for parameter SessionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.UserPoolId = this.UserPoolId;
            #if MODULAR
            if (this.UserPoolId == null && ParameterWasBound(nameof(this.UserPoolId)))
            {
                WriteWarning("You are passing $null as a value for parameter UserPoolId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Username = this.Username;
            #if MODULAR
            if (this.Username == null && ParameterWasBound(nameof(this.Username)))
            {
                WriteWarning("You are passing $null as a value for parameter Username which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CognitoIdentityProvider.Model.AdminRevokeUserSessionRequest();
            
            if (cmdletContext.RevokeAssociatedSession != null)
            {
                request.RevokeAssociatedSessions = cmdletContext.RevokeAssociatedSession;
            }
            if (cmdletContext.SessionId != null)
            {
                request.SessionId = cmdletContext.SessionId;
            }
            if (cmdletContext.UserPoolId != null)
            {
                request.UserPoolId = cmdletContext.UserPoolId;
            }
            if (cmdletContext.Username != null)
            {
                request.Username = cmdletContext.Username;
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
        
        private Amazon.CognitoIdentityProvider.Model.AdminRevokeUserSessionResponse CallAWSServiceOperation(IAmazonCognitoIdentityProvider client, Amazon.CognitoIdentityProvider.Model.AdminRevokeUserSessionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Cognito Identity Provider", "AdminRevokeUserSession");
            try
            {
                return client.AdminRevokeUserSessionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.CognitoIdentityProvider.RevokeAssociatedSessionsType RevokeAssociatedSession { get; set; }
            public System.String SessionId { get; set; }
            public System.String UserPoolId { get; set; }
            public System.String Username { get; set; }
            public System.Func<Amazon.CognitoIdentityProvider.Model.AdminRevokeUserSessionResponse, RevokeCGIPUserSessionAdminCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
