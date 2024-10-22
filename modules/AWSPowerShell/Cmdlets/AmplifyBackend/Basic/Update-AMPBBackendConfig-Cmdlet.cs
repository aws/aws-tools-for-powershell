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
using Amazon.AmplifyBackend;
using Amazon.AmplifyBackend.Model;

namespace Amazon.PowerShell.Cmdlets.AMPB
{
    /// <summary>
    /// Updates the AWS resources required to access the Amplify Admin UI.
    /// </summary>
    [Cmdlet("Update", "AMPBBackendConfig", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AmplifyBackend.Model.UpdateBackendConfigResponse")]
    [AWSCmdlet("Calls the Amplify Backend UpdateBackendConfig API operation.", Operation = new[] {"UpdateBackendConfig"}, SelectReturnType = typeof(Amazon.AmplifyBackend.Model.UpdateBackendConfigResponse))]
    [AWSCmdletOutput("Amazon.AmplifyBackend.Model.UpdateBackendConfigResponse",
        "This cmdlet returns an Amazon.AmplifyBackend.Model.UpdateBackendConfigResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateAMPBBackendConfigCmdlet : AmazonAmplifyBackendClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AppId
        /// <summary>
        /// <para>
        /// <para>The app ID.</para>
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
        public System.String AppId { get; set; }
        #endregion
        
        #region Parameter LoginAuthConfig_AwsCognitoIdentityPoolId
        /// <summary>
        /// <para>
        /// <para>The Amazon Cognito identity pool ID used for the Amplify Admin UI login authorization.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LoginAuthConfig_AwsCognitoIdentityPoolId { get; set; }
        #endregion
        
        #region Parameter LoginAuthConfig_AwsCognitoRegion
        /// <summary>
        /// <para>
        /// <para>The AWS Region for the Amplify Admin UI login.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LoginAuthConfig_AwsCognitoRegion { get; set; }
        #endregion
        
        #region Parameter LoginAuthConfig_AwsUserPoolsId
        /// <summary>
        /// <para>
        /// <para>The Amazon Cognito user pool ID used for Amplify Admin UI login authentication.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LoginAuthConfig_AwsUserPoolsId { get; set; }
        #endregion
        
        #region Parameter LoginAuthConfig_AwsUserPoolsWebClientId
        /// <summary>
        /// <para>
        /// <para>The web client ID for the Amazon Cognito user pools.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LoginAuthConfig_AwsUserPoolsWebClientId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AmplifyBackend.Model.UpdateBackendConfigResponse).
        /// Specifying the name of a property of type Amazon.AmplifyBackend.Model.UpdateBackendConfigResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AppId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-AMPBBackendConfig (UpdateBackendConfig)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AmplifyBackend.Model.UpdateBackendConfigResponse, UpdateAMPBBackendConfigCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AppId = this.AppId;
            #if MODULAR
            if (this.AppId == null && ParameterWasBound(nameof(this.AppId)))
            {
                WriteWarning("You are passing $null as a value for parameter AppId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LoginAuthConfig_AwsCognitoIdentityPoolId = this.LoginAuthConfig_AwsCognitoIdentityPoolId;
            context.LoginAuthConfig_AwsCognitoRegion = this.LoginAuthConfig_AwsCognitoRegion;
            context.LoginAuthConfig_AwsUserPoolsId = this.LoginAuthConfig_AwsUserPoolsId;
            context.LoginAuthConfig_AwsUserPoolsWebClientId = this.LoginAuthConfig_AwsUserPoolsWebClientId;
            
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
            var request = new Amazon.AmplifyBackend.Model.UpdateBackendConfigRequest();
            
            if (cmdletContext.AppId != null)
            {
                request.AppId = cmdletContext.AppId;
            }
            
             // populate LoginAuthConfig
            var requestLoginAuthConfigIsNull = true;
            request.LoginAuthConfig = new Amazon.AmplifyBackend.Model.LoginAuthConfigReqObj();
            System.String requestLoginAuthConfig_loginAuthConfig_AwsCognitoIdentityPoolId = null;
            if (cmdletContext.LoginAuthConfig_AwsCognitoIdentityPoolId != null)
            {
                requestLoginAuthConfig_loginAuthConfig_AwsCognitoIdentityPoolId = cmdletContext.LoginAuthConfig_AwsCognitoIdentityPoolId;
            }
            if (requestLoginAuthConfig_loginAuthConfig_AwsCognitoIdentityPoolId != null)
            {
                request.LoginAuthConfig.AwsCognitoIdentityPoolId = requestLoginAuthConfig_loginAuthConfig_AwsCognitoIdentityPoolId;
                requestLoginAuthConfigIsNull = false;
            }
            System.String requestLoginAuthConfig_loginAuthConfig_AwsCognitoRegion = null;
            if (cmdletContext.LoginAuthConfig_AwsCognitoRegion != null)
            {
                requestLoginAuthConfig_loginAuthConfig_AwsCognitoRegion = cmdletContext.LoginAuthConfig_AwsCognitoRegion;
            }
            if (requestLoginAuthConfig_loginAuthConfig_AwsCognitoRegion != null)
            {
                request.LoginAuthConfig.AwsCognitoRegion = requestLoginAuthConfig_loginAuthConfig_AwsCognitoRegion;
                requestLoginAuthConfigIsNull = false;
            }
            System.String requestLoginAuthConfig_loginAuthConfig_AwsUserPoolsId = null;
            if (cmdletContext.LoginAuthConfig_AwsUserPoolsId != null)
            {
                requestLoginAuthConfig_loginAuthConfig_AwsUserPoolsId = cmdletContext.LoginAuthConfig_AwsUserPoolsId;
            }
            if (requestLoginAuthConfig_loginAuthConfig_AwsUserPoolsId != null)
            {
                request.LoginAuthConfig.AwsUserPoolsId = requestLoginAuthConfig_loginAuthConfig_AwsUserPoolsId;
                requestLoginAuthConfigIsNull = false;
            }
            System.String requestLoginAuthConfig_loginAuthConfig_AwsUserPoolsWebClientId = null;
            if (cmdletContext.LoginAuthConfig_AwsUserPoolsWebClientId != null)
            {
                requestLoginAuthConfig_loginAuthConfig_AwsUserPoolsWebClientId = cmdletContext.LoginAuthConfig_AwsUserPoolsWebClientId;
            }
            if (requestLoginAuthConfig_loginAuthConfig_AwsUserPoolsWebClientId != null)
            {
                request.LoginAuthConfig.AwsUserPoolsWebClientId = requestLoginAuthConfig_loginAuthConfig_AwsUserPoolsWebClientId;
                requestLoginAuthConfigIsNull = false;
            }
             // determine if request.LoginAuthConfig should be set to null
            if (requestLoginAuthConfigIsNull)
            {
                request.LoginAuthConfig = null;
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
        
        private Amazon.AmplifyBackend.Model.UpdateBackendConfigResponse CallAWSServiceOperation(IAmazonAmplifyBackend client, Amazon.AmplifyBackend.Model.UpdateBackendConfigRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amplify Backend", "UpdateBackendConfig");
            try
            {
                #if DESKTOP
                return client.UpdateBackendConfig(request);
                #elif CORECLR
                return client.UpdateBackendConfigAsync(request).GetAwaiter().GetResult();
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
            public System.String AppId { get; set; }
            public System.String LoginAuthConfig_AwsCognitoIdentityPoolId { get; set; }
            public System.String LoginAuthConfig_AwsCognitoRegion { get; set; }
            public System.String LoginAuthConfig_AwsUserPoolsId { get; set; }
            public System.String LoginAuthConfig_AwsUserPoolsWebClientId { get; set; }
            public System.Func<Amazon.AmplifyBackend.Model.UpdateBackendConfigResponse, UpdateAMPBBackendConfigCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
