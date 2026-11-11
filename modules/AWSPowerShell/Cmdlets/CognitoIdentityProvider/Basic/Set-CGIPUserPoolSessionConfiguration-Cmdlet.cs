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
    /// Enables or disables session tracking for a user pool, and sets the pool-wide maximum
    /// number of active token sessions that each user can have. This operation performs a
    /// full replacement of the pool-level session configuration; every request parameter
    /// is required. The user pool must be in the Essentials or Plus tier. Otherwise, this
    /// operation returns a <c>FeatureUnavailableInTierException</c>.
    /// </summary>
    [Cmdlet("Set", "CGIPUserPoolSessionConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CognitoIdentityProvider.Model.SetUserPoolSessionConfigurationResponse")]
    [AWSCmdlet("Calls the Amazon Cognito Identity Provider SetUserPoolSessionConfiguration API operation.", Operation = new[] {"SetUserPoolSessionConfiguration"}, SelectReturnType = typeof(Amazon.CognitoIdentityProvider.Model.SetUserPoolSessionConfigurationResponse))]
    [AWSCmdletOutput("Amazon.CognitoIdentityProvider.Model.SetUserPoolSessionConfigurationResponse",
        "This cmdlet returns an Amazon.CognitoIdentityProvider.Model.SetUserPoolSessionConfigurationResponse object containing multiple properties."
    )]
    public partial class SetCGIPUserPoolSessionConfigurationCmdlet : AmazonCognitoIdentityProviderClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter TokenSession_MaxPerUser
        /// <summary>
        /// <para>
        /// <para>The maximum number of active token sessions that a user can have across the user pool.
        /// The minimum value is <c>1</c> and the maximum value is <c>100</c>. The default is
        /// <c>20</c>. When a user reaches this limit, the next successful authentication automatically
        /// evicts that user's least recently used token session before it creates the new session.
        /// Lowering this value doesn't evict existing sessions on its own; the user is brought
        /// back within the limit on their next sign-in.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? TokenSession_MaxPerUser { get; set; }
        #endregion
        
        #region Parameter UserPoolId
        /// <summary>
        /// <para>
        /// <para>The ID of the user pool where you want to configure session tracking.</para>
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
        
        #region Parameter UserSessionTracking
        /// <summary>
        /// <para>
        /// <para>Specifies whether Amazon Cognito tracks sessions for users in the user pool. Set this
        /// value to <c>ENABLED</c> to turn on server-side session tracking, or <c>DISABLED</c>
        /// to turn it off. When you set this value to <c>DISABLED</c> while the user pool remains
        /// active, existing client-level session configurations are retained but dormant, and
        /// are reactivated when you enable tracking again.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CognitoIdentityProvider.UserSessionTrackingType")]
        public Amazon.CognitoIdentityProvider.UserSessionTrackingType UserSessionTracking { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CognitoIdentityProvider.Model.SetUserPoolSessionConfigurationResponse).
        /// Specifying the name of a property of type Amazon.CognitoIdentityProvider.Model.SetUserPoolSessionConfigurationResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.UserPoolId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-CGIPUserPoolSessionConfiguration (SetUserPoolSessionConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CognitoIdentityProvider.Model.SetUserPoolSessionConfigurationResponse, SetCGIPUserPoolSessionConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.TokenSession_MaxPerUser = this.TokenSession_MaxPerUser;
            #if MODULAR
            if (this.TokenSession_MaxPerUser == null && ParameterWasBound(nameof(this.TokenSession_MaxPerUser)))
            {
                WriteWarning("You are passing $null as a value for parameter TokenSession_MaxPerUser which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.UserPoolId = this.UserPoolId;
            #if MODULAR
            if (this.UserPoolId == null && ParameterWasBound(nameof(this.UserPoolId)))
            {
                WriteWarning("You are passing $null as a value for parameter UserPoolId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.UserSessionTracking = this.UserSessionTracking;
            #if MODULAR
            if (this.UserSessionTracking == null && ParameterWasBound(nameof(this.UserSessionTracking)))
            {
                WriteWarning("You are passing $null as a value for parameter UserSessionTracking which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CognitoIdentityProvider.Model.SetUserPoolSessionConfigurationRequest();
            
            
             // populate TokenSession
            var requestTokenSessionIsNull = true;
            request.TokenSession = new Amazon.CognitoIdentityProvider.Model.UserPoolTokenSessionConfigType();
            System.Int32? requestTokenSession_tokenSession_MaxPerUser = null;
            if (cmdletContext.TokenSession_MaxPerUser != null)
            {
                requestTokenSession_tokenSession_MaxPerUser = cmdletContext.TokenSession_MaxPerUser.Value;
            }
            if (requestTokenSession_tokenSession_MaxPerUser != null)
            {
                request.TokenSession.MaxPerUser = requestTokenSession_tokenSession_MaxPerUser.Value;
                requestTokenSessionIsNull = false;
            }
             // determine if request.TokenSession should be set to null
            if (requestTokenSessionIsNull)
            {
                request.TokenSession = null;
            }
            if (cmdletContext.UserPoolId != null)
            {
                request.UserPoolId = cmdletContext.UserPoolId;
            }
            if (cmdletContext.UserSessionTracking != null)
            {
                request.UserSessionTracking = cmdletContext.UserSessionTracking;
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
        
        private Amazon.CognitoIdentityProvider.Model.SetUserPoolSessionConfigurationResponse CallAWSServiceOperation(IAmazonCognitoIdentityProvider client, Amazon.CognitoIdentityProvider.Model.SetUserPoolSessionConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Cognito Identity Provider", "SetUserPoolSessionConfiguration");
            try
            {
                return client.SetUserPoolSessionConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? TokenSession_MaxPerUser { get; set; }
            public System.String UserPoolId { get; set; }
            public Amazon.CognitoIdentityProvider.UserSessionTrackingType UserSessionTracking { get; set; }
            public System.Func<Amazon.CognitoIdentityProvider.Model.SetUserPoolSessionConfigurationResponse, SetCGIPUserPoolSessionConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
