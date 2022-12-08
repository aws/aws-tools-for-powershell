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
    /// Exchanges an access code for a token.
    /// </summary>
    [Cmdlet("Convert", "AMPUICodeForToken", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AmplifyUIBuilder.Model.ExchangeCodeForTokenResponse")]
    [AWSCmdlet("Calls the AWS Amplify UI Builder ExchangeCodeForToken API operation.", Operation = new[] {"ExchangeCodeForToken"}, SelectReturnType = typeof(Amazon.AmplifyUIBuilder.Model.ExchangeCodeForTokenResponse))]
    [AWSCmdletOutput("Amazon.AmplifyUIBuilder.Model.ExchangeCodeForTokenResponse",
        "This cmdlet returns an Amazon.AmplifyUIBuilder.Model.ExchangeCodeForTokenResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class ConvertAMPUICodeForTokenCmdlet : AmazonAmplifyUIBuilderClientCmdlet, IExecutor
    {
        
        #region Parameter Request_Code
        /// <summary>
        /// <para>
        /// <para>The access code to send in the request.</para>
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
        public System.String Request_Code { get; set; }
        #endregion
        
        #region Parameter Provider
        /// <summary>
        /// <para>
        /// <para>The third-party provider for the token. The only valid value is <code>figma</code>.</para>
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
        
        #region Parameter Request_RedirectUri
        /// <summary>
        /// <para>
        /// <para>The location of the application that will receive the access code.</para>
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
        public System.String Request_RedirectUri { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AmplifyUIBuilder.Model.ExchangeCodeForTokenResponse).
        /// Specifying the name of a property of type Amazon.AmplifyUIBuilder.Model.ExchangeCodeForTokenResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Provider parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Provider' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Provider' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Convert-AMPUICodeForToken (ExchangeCodeForToken)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AmplifyUIBuilder.Model.ExchangeCodeForTokenResponse, ConvertAMPUICodeForTokenCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Provider;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Provider = this.Provider;
            #if MODULAR
            if (this.Provider == null && ParameterWasBound(nameof(this.Provider)))
            {
                WriteWarning("You are passing $null as a value for parameter Provider which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Request_Code = this.Request_Code;
            #if MODULAR
            if (this.Request_Code == null && ParameterWasBound(nameof(this.Request_Code)))
            {
                WriteWarning("You are passing $null as a value for parameter Request_Code which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Request_RedirectUri = this.Request_RedirectUri;
            #if MODULAR
            if (this.Request_RedirectUri == null && ParameterWasBound(nameof(this.Request_RedirectUri)))
            {
                WriteWarning("You are passing $null as a value for parameter Request_RedirectUri which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.AmplifyUIBuilder.Model.ExchangeCodeForTokenRequest();
            
            if (cmdletContext.Provider != null)
            {
                request.Provider = cmdletContext.Provider;
            }
            
             // populate Request
            var requestRequestIsNull = true;
            request.Request = new Amazon.AmplifyUIBuilder.Model.ExchangeCodeForTokenRequestBody();
            System.String requestRequest_request_Code = null;
            if (cmdletContext.Request_Code != null)
            {
                requestRequest_request_Code = cmdletContext.Request_Code;
            }
            if (requestRequest_request_Code != null)
            {
                request.Request.Code = requestRequest_request_Code;
                requestRequestIsNull = false;
            }
            System.String requestRequest_request_RedirectUri = null;
            if (cmdletContext.Request_RedirectUri != null)
            {
                requestRequest_request_RedirectUri = cmdletContext.Request_RedirectUri;
            }
            if (requestRequest_request_RedirectUri != null)
            {
                request.Request.RedirectUri = requestRequest_request_RedirectUri;
                requestRequestIsNull = false;
            }
             // determine if request.Request should be set to null
            if (requestRequestIsNull)
            {
                request.Request = null;
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
        
        private Amazon.AmplifyUIBuilder.Model.ExchangeCodeForTokenResponse CallAWSServiceOperation(IAmazonAmplifyUIBuilder client, Amazon.AmplifyUIBuilder.Model.ExchangeCodeForTokenRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Amplify UI Builder", "ExchangeCodeForToken");
            try
            {
                #if DESKTOP
                return client.ExchangeCodeForToken(request);
                #elif CORECLR
                return client.ExchangeCodeForTokenAsync(request).GetAwaiter().GetResult();
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
            public System.String Request_Code { get; set; }
            public System.String Request_RedirectUri { get; set; }
            public System.Func<Amazon.AmplifyUIBuilder.Model.ExchangeCodeForTokenResponse, ConvertAMPUICodeForTokenCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
