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
using Amazon.AmplifyUIBuilder;
using Amazon.AmplifyUIBuilder.Model;

namespace Amazon.PowerShell.Cmdlets.AMPUI
{
    /// <summary>
    /// <note><para>
    /// This is for internal use.
    /// </para></note><para>
    /// Amplify uses this action to refresh a previously issued access token that might have
    /// expired.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "AMPUIToken", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AmplifyUIBuilder.Model.RefreshTokenResponse")]
    [AWSCmdlet("Calls the AWS Amplify UI Builder RefreshToken API operation.", Operation = new[] {"RefreshToken"}, SelectReturnType = typeof(Amazon.AmplifyUIBuilder.Model.RefreshTokenResponse))]
    [AWSCmdletOutput("Amazon.AmplifyUIBuilder.Model.RefreshTokenResponse",
        "This cmdlet returns an Amazon.AmplifyUIBuilder.Model.RefreshTokenResponse object containing multiple properties."
    )]
    public partial class UpdateAMPUITokenCmdlet : AmazonAmplifyUIBuilderClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter RefreshTokenBody_ClientId
        /// <summary>
        /// <para>
        /// <para>The ID of the client to request the token from.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RefreshTokenBody_ClientId { get; set; }
        #endregion
        
        #region Parameter Provider
        /// <summary>
        /// <para>
        /// <para>The third-party provider for the token. The only valid value is <c>figma</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.AmplifyUIBuilder.TokenProviders")]
        public Amazon.AmplifyUIBuilder.TokenProviders Provider { get; set; }
        #endregion
        
        #region Parameter RefreshTokenBody_Token
        /// <summary>
        /// <para>
        /// <para>The token to use to refresh a previously issued access token that might have expired.</para>
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
        public System.String RefreshTokenBody_Token { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AmplifyUIBuilder.Model.RefreshTokenResponse).
        /// Specifying the name of a property of type Amazon.AmplifyUIBuilder.Model.RefreshTokenResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Provider), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-AMPUIToken (RefreshToken)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AmplifyUIBuilder.Model.RefreshTokenResponse, UpdateAMPUITokenCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Provider = this.Provider;
            #if MODULAR
            if (this.Provider == null && ParameterWasBound(nameof(this.Provider)))
            {
                WriteWarning("You are passing $null as a value for parameter Provider which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RefreshTokenBody_ClientId = this.RefreshTokenBody_ClientId;
            context.RefreshTokenBody_Token = this.RefreshTokenBody_Token;
            #if MODULAR
            if (this.RefreshTokenBody_Token == null && ParameterWasBound(nameof(this.RefreshTokenBody_Token)))
            {
                WriteWarning("You are passing $null as a value for parameter RefreshTokenBody_Token which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.AmplifyUIBuilder.Model.RefreshTokenRequest();
            
            if (cmdletContext.Provider != null)
            {
                request.Provider = cmdletContext.Provider;
            }
            
             // populate RefreshTokenBody
            var requestRefreshTokenBodyIsNull = true;
            request.RefreshTokenBody = new Amazon.AmplifyUIBuilder.Model.RefreshTokenRequestBody();
            System.String requestRefreshTokenBody_refreshTokenBody_ClientId = null;
            if (cmdletContext.RefreshTokenBody_ClientId != null)
            {
                requestRefreshTokenBody_refreshTokenBody_ClientId = cmdletContext.RefreshTokenBody_ClientId;
            }
            if (requestRefreshTokenBody_refreshTokenBody_ClientId != null)
            {
                request.RefreshTokenBody.ClientId = requestRefreshTokenBody_refreshTokenBody_ClientId;
                requestRefreshTokenBodyIsNull = false;
            }
            System.String requestRefreshTokenBody_refreshTokenBody_Token = null;
            if (cmdletContext.RefreshTokenBody_Token != null)
            {
                requestRefreshTokenBody_refreshTokenBody_Token = cmdletContext.RefreshTokenBody_Token;
            }
            if (requestRefreshTokenBody_refreshTokenBody_Token != null)
            {
                request.RefreshTokenBody.Token = requestRefreshTokenBody_refreshTokenBody_Token;
                requestRefreshTokenBodyIsNull = false;
            }
             // determine if request.RefreshTokenBody should be set to null
            if (requestRefreshTokenBodyIsNull)
            {
                request.RefreshTokenBody = null;
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
        
        private Amazon.AmplifyUIBuilder.Model.RefreshTokenResponse CallAWSServiceOperation(IAmazonAmplifyUIBuilder client, Amazon.AmplifyUIBuilder.Model.RefreshTokenRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Amplify UI Builder", "RefreshToken");
            try
            {
                #if DESKTOP
                return client.RefreshToken(request);
                #elif CORECLR
                return client.RefreshTokenAsync(request).GetAwaiter().GetResult();
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
            public Amazon.AmplifyUIBuilder.TokenProviders Provider { get; set; }
            public System.String RefreshTokenBody_ClientId { get; set; }
            public System.String RefreshTokenBody_Token { get; set; }
            public System.Func<Amazon.AmplifyUIBuilder.Model.RefreshTokenResponse, UpdateAMPUITokenCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
