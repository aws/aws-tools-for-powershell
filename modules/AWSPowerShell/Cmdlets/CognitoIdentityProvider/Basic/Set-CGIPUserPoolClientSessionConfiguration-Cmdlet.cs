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
    /// Sets the session configuration for a user pool app client. The configurable client-level
    /// setting is the maximum validity period for silent reuse of an SSO session. This operation
    /// performs a full replacement of the client-level session configuration; every request
    /// parameter is required, and session tracking must be enabled for the user pool. The
    /// user pool must be in the Essentials or Plus tier. Otherwise, this operation returns
    /// a <c>FeatureUnavailableInTierException</c>.
    /// </summary>
    [Cmdlet("Set", "CGIPUserPoolClientSessionConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CognitoIdentityProvider.Model.SetUserPoolClientSessionConfigurationResponse")]
    [AWSCmdlet("Calls the Amazon Cognito Identity Provider SetUserPoolClientSessionConfiguration API operation.", Operation = new[] {"SetUserPoolClientSessionConfiguration"}, SelectReturnType = typeof(Amazon.CognitoIdentityProvider.Model.SetUserPoolClientSessionConfigurationResponse))]
    [AWSCmdletOutput("Amazon.CognitoIdentityProvider.Model.SetUserPoolClientSessionConfigurationResponse",
        "This cmdlet returns an Amazon.CognitoIdentityProvider.Model.SetUserPoolClientSessionConfigurationResponse object containing multiple properties."
    )]
    public partial class SetCGIPUserPoolClientSessionConfigurationCmdlet : AmazonCognitoIdentityProviderClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ClientId
        /// <summary>
        /// <para>
        /// <para>The ID of the app client that you want to configure.</para>
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
        public System.String ClientId { get; set; }
        #endregion
        
        #region Parameter SSOSession_MaxValidityMinute
        /// <summary>
        /// <para>
        /// <para>The maximum amount of time, in minutes, that this app client silently reuses an existing
        /// SSO session, returning a new set of tokens without requiring the user to re-authenticate,
        /// measured from the user's last fresh authentication. The minimum value is <c>0</c>
        /// and the maximum value is <c>129600</c> (90 days). The default is <c>60</c>. A value
        /// of <c>0</c> means that this app client never silently reuses the SSO session and always
        /// re-authenticates the user. The SSO session record and its cookie are still created
        /// regardless of this value, and other app clients in the same user pool can still reuse
        /// the session.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("SSOSession_MaxValidityMinutes")]
        public System.Int32? SSOSession_MaxValidityMinute { get; set; }
        #endregion
        
        #region Parameter UserPoolId
        /// <summary>
        /// <para>
        /// <para>The ID of the user pool that contains the app client.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CognitoIdentityProvider.Model.SetUserPoolClientSessionConfigurationResponse).
        /// Specifying the name of a property of type Amazon.CognitoIdentityProvider.Model.SetUserPoolClientSessionConfigurationResponse will result in that property being returned.
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
                nameof(this.ClientId),
                nameof(this.UserPoolId)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters, new System.Collections.Generic.HashSet<string> { nameof(this.ClientId) });
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-CGIPUserPoolClientSessionConfiguration (SetUserPoolClientSessionConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CognitoIdentityProvider.Model.SetUserPoolClientSessionConfigurationResponse, SetCGIPUserPoolClientSessionConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientId = this.ClientId;
            #if MODULAR
            if (this.ClientId == null && ParameterWasBound(nameof(this.ClientId)))
            {
                WriteWarning("You are passing $null as a value for parameter ClientId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SSOSession_MaxValidityMinute = this.SSOSession_MaxValidityMinute;
            #if MODULAR
            if (this.SSOSession_MaxValidityMinute == null && ParameterWasBound(nameof(this.SSOSession_MaxValidityMinute)))
            {
                WriteWarning("You are passing $null as a value for parameter SSOSession_MaxValidityMinute which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.CognitoIdentityProvider.Model.SetUserPoolClientSessionConfigurationRequest();
            
            if (cmdletContext.ClientId != null)
            {
                request.ClientId = cmdletContext.ClientId;
            }
            
             // populate SSOSession
            var requestSSOSessionIsNull = true;
            request.SSOSession = new Amazon.CognitoIdentityProvider.Model.ClientSSOSessionConfigType();
            System.Int32? requestSSOSession_sSOSession_MaxValidityMinute = null;
            if (cmdletContext.SSOSession_MaxValidityMinute != null)
            {
                requestSSOSession_sSOSession_MaxValidityMinute = cmdletContext.SSOSession_MaxValidityMinute.Value;
            }
            if (requestSSOSession_sSOSession_MaxValidityMinute != null)
            {
                request.SSOSession.MaxValidityMinutes = requestSSOSession_sSOSession_MaxValidityMinute.Value;
                requestSSOSessionIsNull = false;
            }
             // determine if request.SSOSession should be set to null
            if (requestSSOSessionIsNull)
            {
                request.SSOSession = null;
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
        
        private Amazon.CognitoIdentityProvider.Model.SetUserPoolClientSessionConfigurationResponse CallAWSServiceOperation(IAmazonCognitoIdentityProvider client, Amazon.CognitoIdentityProvider.Model.SetUserPoolClientSessionConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Cognito Identity Provider", "SetUserPoolClientSessionConfiguration");
            try
            {
                return client.SetUserPoolClientSessionConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientId { get; set; }
            public System.Int32? SSOSession_MaxValidityMinute { get; set; }
            public System.String UserPoolId { get; set; }
            public System.Func<Amazon.CognitoIdentityProvider.Model.SetUserPoolClientSessionConfigurationResponse, SetCGIPUserPoolClientSessionConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
