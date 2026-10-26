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
    /// Exchanges a supported token for an OAuth 2.0 access token scoped to a resource, which
    /// you can use to access AWS services from applications.
    /// </summary>
    [Cmdlet("New", "AMSPOAuth2TokenWithTokenExchange", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Signin.Model.CreateOAuth2TokenWithTokenExchangeResponse")]
    [AWSCmdlet("Calls the AWS Sign-In Data Plane CreateOAuth2TokenWithTokenExchange API operation.", Operation = new[] {"CreateOAuth2TokenWithTokenExchange"}, SelectReturnType = typeof(Amazon.Signin.Model.CreateOAuth2TokenWithTokenExchangeResponse))]
    [AWSCmdletOutput("Amazon.Signin.Model.CreateOAuth2TokenWithTokenExchangeResponse",
        "This cmdlet returns an Amazon.Signin.Model.CreateOAuth2TokenWithTokenExchangeResponse object containing multiple properties."
    )]
    public partial class NewAMSPOAuth2TokenWithTokenExchangeCmdlet : AmazonSigninClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter GrantType
        /// <summary>
        /// <para>
        /// The OAuth 2.0 grant type. Currently only supports
        /// "urn:ietf:params:oauth:grant-type:token-exchange".
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
        public System.String GrantType { get; set; }
        #endregion
        
        #region Parameter Resource
        /// <summary>
        /// <para>
        /// The OAuth resource for which the access token
        /// is requested. Required when "grant_type=urn:ietf:params:oauth:grant-type:token-exchange".
        /// Example: "glue.amazonaws.com".
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Resource { get; set; }
        #endregion
        
        #region Parameter Scope
        /// <summary>
        /// <para>
        /// IAM managed policy Amazon Resource Names (ARNs)
        /// to apply as session policies that further scope down the permissions of the issued
        /// access token, provided as a space-delimited list. Example: "arn:aws:iam::444455556666:policy/MyPolicy".
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Scope { get; set; }
        #endregion
        
        #region Parameter SubjectToken
        /// <summary>
        /// <para>
        /// The subject token that represents the identity
        /// of the party on whose behalf the request is made. Required when "grant_type=urn:ietf:params:oauth:grant-type:token-exchange".
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SubjectToken { get; set; }
        #endregion
        
        #region Parameter SubjectTokenType
        /// <summary>
        /// <para>
        /// The token type of the subject token.
        /// Currently only supports "urn:ietf:params:oauth:token-type:jwt". Required when "grant_type=urn:ietf:params:oauth:grant-type:token-exchange".
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SubjectTokenType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Signin.Model.CreateOAuth2TokenWithTokenExchangeResponse).
        /// Specifying the name of a property of type Amazon.Signin.Model.CreateOAuth2TokenWithTokenExchangeResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.GrantType), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-AMSPOAuth2TokenWithTokenExchange (CreateOAuth2TokenWithTokenExchange)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Signin.Model.CreateOAuth2TokenWithTokenExchangeResponse, NewAMSPOAuth2TokenWithTokenExchangeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.GrantType = this.GrantType;
            #if MODULAR
            if (this.GrantType == null && ParameterWasBound(nameof(this.GrantType)))
            {
                WriteWarning("You are passing $null as a value for parameter GrantType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Resource = this.Resource;
            context.Scope = this.Scope;
            context.SubjectToken = this.SubjectToken;
            context.SubjectTokenType = this.SubjectTokenType;
            
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
            var request = new Amazon.Signin.Model.CreateOAuth2TokenWithTokenExchangeRequest();
            
            if (cmdletContext.GrantType != null)
            {
                request.GrantType = cmdletContext.GrantType;
            }
            if (cmdletContext.Resource != null)
            {
                request.Resource = cmdletContext.Resource;
            }
            if (cmdletContext.Scope != null)
            {
                request.Scope = cmdletContext.Scope;
            }
            if (cmdletContext.SubjectToken != null)
            {
                request.SubjectToken = cmdletContext.SubjectToken;
            }
            if (cmdletContext.SubjectTokenType != null)
            {
                request.SubjectTokenType = cmdletContext.SubjectTokenType;
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
        
        private Amazon.Signin.Model.CreateOAuth2TokenWithTokenExchangeResponse CallAWSServiceOperation(IAmazonSignin client, Amazon.Signin.Model.CreateOAuth2TokenWithTokenExchangeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Sign-In Data Plane", "CreateOAuth2TokenWithTokenExchange");
            try
            {
                return client.CreateOAuth2TokenWithTokenExchangeAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String GrantType { get; set; }
            public System.String Resource { get; set; }
            public System.String Scope { get; set; }
            public System.String SubjectToken { get; set; }
            public System.String SubjectTokenType { get; set; }
            public System.Func<Amazon.Signin.Model.CreateOAuth2TokenWithTokenExchangeResponse, NewAMSPOAuth2TokenWithTokenExchangeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
