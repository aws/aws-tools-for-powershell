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
using Amazon.CognitoIdentity;
using Amazon.CognitoIdentity.Model;

namespace Amazon.PowerShell.Cmdlets.CGI
{
    /// <summary>
    /// Gets an OpenID token, using a known Cognito ID. This known Cognito ID is returned
    /// by <a>GetId</a>. You can optionally add additional logins for the identity. Supplying
    /// multiple logins creates an implicit link.
    /// 
    ///  
    /// <para>
    /// The OpenID token is valid for 10 minutes.
    /// </para><para>
    /// This is a public API. You do not need any credentials to call this API.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "CGIOpenIdToken")]
    [OutputType("Amazon.CognitoIdentity.Model.GetOpenIdTokenResponse")]
    [AWSCmdlet("Calls the Amazon Cognito Identity GetOpenIdToken API operation. This operation uses anonymous authentication and does not require credential parameters to be supplied.", Operation = new[] {"GetOpenIdToken"}, SelectReturnType = typeof(Amazon.CognitoIdentity.Model.GetOpenIdTokenResponse))]
    [AWSCmdletOutput("Amazon.CognitoIdentity.Model.GetOpenIdTokenResponse",
        "This cmdlet returns an Amazon.CognitoIdentity.Model.GetOpenIdTokenResponse object containing multiple properties."
    )]
    public partial class GetCGIOpenIdTokenCmdlet : AnonymousAmazonCognitoIdentityClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter IdentityId
        /// <summary>
        /// <para>
        /// <para>A unique identifier in the format REGION:GUID.</para>
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
        public System.String IdentityId { get; set; }
        #endregion
        
        #region Parameter Login
        /// <summary>
        /// <para>
        /// <para>A set of optional name-value pairs that map provider names to provider tokens. When
        /// using graph.facebook.com and www.amazon.com, supply the access_token returned from
        /// the provider's authflow. For accounts.google.com, an Amazon Cognito user pool provider,
        /// or any other OpenID Connect provider, always include the <c>id_token</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Logins")]
        public System.Collections.Hashtable Login { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CognitoIdentity.Model.GetOpenIdTokenResponse).
        /// Specifying the name of a property of type Amazon.CognitoIdentity.Model.GetOpenIdTokenResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CognitoIdentity.Model.GetOpenIdTokenResponse, GetCGIOpenIdTokenCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.IdentityId = this.IdentityId;
            #if MODULAR
            if (this.IdentityId == null && ParameterWasBound(nameof(this.IdentityId)))
            {
                WriteWarning("You are passing $null as a value for parameter IdentityId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Login != null)
            {
                context.Login = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Login.Keys)
                {
                    context.Login.Add((String)hashKey, (System.String)(this.Login[hashKey]));
                }
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
            var request = new Amazon.CognitoIdentity.Model.GetOpenIdTokenRequest();
            
            if (cmdletContext.IdentityId != null)
            {
                request.IdentityId = cmdletContext.IdentityId;
            }
            if (cmdletContext.Login != null)
            {
                request.Logins = cmdletContext.Login;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_RegionEndpoint);
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
        
        private Amazon.CognitoIdentity.Model.GetOpenIdTokenResponse CallAWSServiceOperation(IAmazonCognitoIdentity client, Amazon.CognitoIdentity.Model.GetOpenIdTokenRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Cognito Identity", "GetOpenIdToken");
            try
            {
                #if DESKTOP
                return client.GetOpenIdToken(request);
                #elif CORECLR
                return client.GetOpenIdTokenAsync(request).GetAwaiter().GetResult();
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
            public System.String IdentityId { get; set; }
            public Dictionary<System.String, System.String> Login { get; set; }
            public System.Func<Amazon.CognitoIdentity.Model.GetOpenIdTokenResponse, GetCGIOpenIdTokenCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
