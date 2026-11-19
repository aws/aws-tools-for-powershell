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
using Amazon.SecurityToken;
using Amazon.SecurityToken.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.STS
{
    /// <summary>
    /// Returns a set of temporary security credentials that are scoped down from the caller's
    /// existing temporary security credentials. <c>GetScopedCredentials</c> preserves the
    /// caller's identity while narrowing the permissions and optionally shortening the session
    /// lifetime.
    /// 
    ///  
    /// <para>
    /// For a comparison of <c>GetScopedCredentials</c> with the other API operations that
    /// produce temporary security credentials, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/id_credentials_temp_request.html">Requesting
    /// Temporary Security Credentials</a> and <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/id_credentials_sts-comparison.html">Compare
    /// STS credentials</a> in the IAM User Guide.
    /// </para><para><b>Credential requirements</b></para><para>
    /// You can only call <c>GetScopedCredentials</c> with temporary security credentials,
    /// for example, credentials from an assumed role or a federated session. You cannot call
    /// it with IAM user credentials or root credentials. If you want to scope down IAM user
    /// credentials, first call <c>GetSessionToken</c> to get temporary security credentials,
    /// and then call <c>GetScopedCredentials</c> with those credentials.
    /// </para><note><para>
    /// The <c>GetScopedCredentials</c> API is not available on the STS Global endpoint.
    /// </para></note>
    /// </summary>
    [Cmdlet("Get", "STSScopedCredential")]
    [OutputType("Amazon.SecurityToken.Model.GetScopedCredentialsResponse")]
    [AWSCmdlet("Calls the AWS Security Token Service GetScopedCredentials API operation.", Operation = new[] {"GetScopedCredentials"}, SelectReturnType = typeof(Amazon.SecurityToken.Model.GetScopedCredentialsResponse))]
    [AWSCmdletOutput("Amazon.SecurityToken.Model.GetScopedCredentialsResponse",
        "This cmdlet returns an Amazon.SecurityToken.Model.GetScopedCredentialsResponse object containing multiple properties."
    )]
    public partial class GetSTSScopedCredentialCmdlet : AmazonSecurityTokenServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DurationSecond
        /// <summary>
        /// <para>
        /// <para>The duration, in seconds, of the resulting scoped down credentials. The value can
        /// range from 1 second to 129,600 seconds (36 hours).</para><para>If you do not specify this value, the scoped down credentials will inherit the calling
        /// session's expiration time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DurationSeconds")]
        public System.Int32? DurationSecond { get; set; }
        #endregion
        
        #region Parameter MinimumSessionTokenSize
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MinimumSessionTokenSize { get; set; }
        #endregion
        
        #region Parameter Policy
        /// <summary>
        /// <para>
        /// <para>An IAM policy in JSON format that you want to use as a scope down policy.</para><para>A request must provide at least one of <c>Policy</c> or <c>DurationSeconds</c>. Both
        /// parameters are optional individually, but you must specify at least one of them.</para><para>The resulting session's permissions are the intersection of the calling session's
        /// existing permissions and this scope down policy. You cannot use this scope down policy
        /// to grant more permissions than the calling session already has.</para><para>The plaintext of the scope down policy cannot exceed 2,048 characters. The JSON policy
        /// characters can be any ASCII character from the space character to the end of the valid
        /// character list (\u0020 through \u00FF). It can also include the tab (\u0009), linefeed
        /// (\u000A), and carriage return (\u000D) characters.</para><note><para>An internal conversion compresses the inline scope down policy into a packed binary
        /// format that has a separate limit. If the packed policy exceeds this limit, the request
        /// fails with <c>PackedPolicyTooLarge</c>.</para><para>If the document is not valid IAM policy JSON, the request fails with <c>MalformedPolicyDocument</c>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Policy { get; set; }
        #endregion
        
        #region Parameter ScopedSessionDescription
        /// <summary>
        /// <para>
        /// <para>A caller-supplied description of the scoped session. The value cannot exceed 256 characters.
        /// This description is logged to CloudTrail for the request, so you can use it to record
        /// the purpose of the scoped session.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ScopedSessionDescription { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecurityToken.Model.GetScopedCredentialsResponse).
        /// Specifying the name of a property of type Amazon.SecurityToken.Model.GetScopedCredentialsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SecurityToken.Model.GetScopedCredentialsResponse, GetSTSScopedCredentialCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DurationSecond = this.DurationSecond;
            context.MinimumSessionTokenSize = this.MinimumSessionTokenSize;
            context.Policy = this.Policy;
            context.ScopedSessionDescription = this.ScopedSessionDescription;
            
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
            var request = new Amazon.SecurityToken.Model.GetScopedCredentialsRequest();
            
            if (cmdletContext.DurationSecond != null)
            {
                request.DurationSeconds = cmdletContext.DurationSecond.Value;
            }
            if (cmdletContext.MinimumSessionTokenSize != null)
            {
                request.MinimumSessionTokenSize = cmdletContext.MinimumSessionTokenSize.Value;
            }
            if (cmdletContext.Policy != null)
            {
                request.Policy = cmdletContext.Policy;
            }
            if (cmdletContext.ScopedSessionDescription != null)
            {
                request.ScopedSessionDescription = cmdletContext.ScopedSessionDescription;
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
        
        private Amazon.SecurityToken.Model.GetScopedCredentialsResponse CallAWSServiceOperation(IAmazonSecurityTokenService client, Amazon.SecurityToken.Model.GetScopedCredentialsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Security Token Service", "GetScopedCredentials");
            try
            {
                return client.GetScopedCredentialsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? DurationSecond { get; set; }
            public System.Int32? MinimumSessionTokenSize { get; set; }
            public System.String Policy { get; set; }
            public System.String ScopedSessionDescription { get; set; }
            public System.Func<Amazon.SecurityToken.Model.GetScopedCredentialsResponse, GetSTSScopedCredentialCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
