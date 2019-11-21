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
using Amazon.SecurityToken;
using Amazon.SecurityToken.Model;

namespace Amazon.PowerShell.Cmdlets.STS
{
    /// <summary>
    /// Returns a set of temporary security credentials (consisting of an access key ID, a
    /// secret access key, and a security token) for a federated user. A typical use is in
    /// a proxy application that gets temporary security credentials on behalf of distributed
    /// applications inside a corporate network. You must call the <code>GetFederationToken</code>
    /// operation using the long-term security credentials of an IAM user. As a result, this
    /// call is appropriate in contexts where those credentials can be safely stored, usually
    /// in a server-based application. For a comparison of <code>GetFederationToken</code>
    /// with the other API operations that produce temporary credentials, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/id_credentials_temp_request.html">Requesting
    /// Temporary Security Credentials</a> and <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/id_credentials_temp_request.html#stsapi_comparison">Comparing
    /// the AWS STS API operations</a> in the <i>IAM User Guide</i>.
    /// 
    ///  <note><para>
    /// You can create a mobile-based or browser-based app that can authenticate users using
    /// a web identity provider like Login with Amazon, Facebook, Google, or an OpenID Connect-compatible
    /// identity provider. In this case, we recommend that you use <a href="http://aws.amazon.com/cognito/">Amazon
    /// Cognito</a> or <code>AssumeRoleWithWebIdentity</code>. For more information, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/id_credentials_temp_request.html#api_assumerolewithwebidentity">Federation
    /// Through a Web-based Identity Provider</a>.
    /// </para></note><para>
    /// You can also call <code>GetFederationToken</code> using the security credentials of
    /// an AWS account root user, but we do not recommend it. Instead, we recommend that you
    /// create an IAM user for the purpose of the proxy application. Then attach a policy
    /// to the IAM user that limits federated users to only the actions and resources that
    /// they need to access. For more information, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/best-practices.html">IAM
    /// Best Practices</a> in the <i>IAM User Guide</i>. 
    /// </para><para>
    /// The temporary credentials are valid for the specified duration, from 900 seconds (15
    /// minutes) up to a maximum of 129,600 seconds (36 hours). The default is 43,200 seconds
    /// (12 hours). Temporary credentials that are obtained by using AWS account root user
    /// credentials have a maximum duration of 3,600 seconds (1 hour).
    /// </para><para>
    /// The temporary security credentials created by <code>GetFederationToken</code> can
    /// be used to make API calls to any AWS service with the following exceptions:
    /// </para><ul><li><para>
    /// You cannot use these credentials to call any IAM API operations.
    /// </para></li><li><para>
    /// You cannot call any STS API operations except <code>GetCallerIdentity</code>.
    /// </para></li></ul><para><b>Permissions</b></para><para>
    /// You must pass an inline or managed <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/access_policies.html#policies_session">session
    /// policy</a> to this operation. You can pass a single JSON policy document to use as
    /// an inline session policy. You can also specify up to 10 managed policies to use as
    /// managed session policies. The plain text that you use for both inline and managed
    /// session policies shouldn't exceed 2048 characters.
    /// </para><para>
    /// Though the session policy parameters are optional, if you do not pass a policy, then
    /// the resulting federated user session has no permissions. The only exception is when
    /// the credentials are used to access a resource that has a resource-based policy that
    /// specifically references the federated user session in the <code>Principal</code> element
    /// of the policy. When you pass session policies, the session permissions are the intersection
    /// of the IAM user policies and the session policies that you pass. This gives you a
    /// way to further restrict the permissions for a federated user. You cannot use session
    /// policies to grant more permissions than those that are defined in the permissions
    /// policy of the IAM user. For more information, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/access_policies.html#policies_session">Session
    /// Policies</a> in the <i>IAM User Guide</i>. For information about using <code>GetFederationToken</code>
    /// to create temporary security credentials, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/id_credentials_temp_request.html#api_getfederationtoken">GetFederationToken—Federation
    /// Through a Custom Identity Broker</a>. 
    /// </para>
    /// </summary>
    [Cmdlet("Get", "STSFederationToken")]
    [OutputType("Amazon.SecurityToken.Model.GetFederationTokenResponse")]
    [AWSCmdlet("Calls the AWS Security Token Service (STS) GetFederationToken API operation.", Operation = new[] {"GetFederationToken"}, SelectReturnType = typeof(Amazon.SecurityToken.Model.GetFederationTokenResponse))]
    [AWSCmdletOutput("Amazon.SecurityToken.Model.GetFederationTokenResponse",
        "This cmdlet returns an Amazon.SecurityToken.Model.GetFederationTokenResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetSTSFederationTokenCmdlet : AmazonSecurityTokenServiceClientCmdlet, IExecutor
    {
        
        #region Parameter DurationInSeconds
        /// <summary>
        /// <para>
        /// <para>The duration, in seconds, that the session should last. Acceptable durations for federation
        /// sessions range from 900 seconds (15 minutes) to 129,600 seconds (36 hours), with 43,200
        /// seconds (12 hours) as the default. Sessions obtained using AWS account root user credentials
        /// are restricted to a maximum of 3,600 seconds (one hour). If the specified duration
        /// is longer than one hour, the session obtained by using root user credentials defaults
        /// to one hour.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        [Alias("DurationSeconds")]
        public System.Int32? DurationInSeconds { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the federated user. The name is used as an identifier for the temporary
        /// security credentials (such as <code>Bob</code>). For example, you can reference the
        /// federated user name in a resource-based policy, such as in an Amazon S3 bucket policy.</para><para>The regex used to validate this parameter is a string of characters consisting of
        /// upper- and lower-case alphanumeric characters with no spaces. You can also include
        /// underscores or any of the following characters: =,.@-</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Policy
        /// <summary>
        /// <para>
        /// <para>An IAM policy in JSON format that you want to use as an inline session policy.</para><para>You must pass an inline or managed <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/access_policies.html#policies_session">session
        /// policy</a> to this operation. You can pass a single JSON policy document to use as
        /// an inline session policy. You can also specify up to 10 managed policies to use as
        /// managed session policies.</para><para>This parameter is optional. However, if you do not pass any session policies, then
        /// the resulting federated user session has no permissions. The only exception is when
        /// the credentials are used to access a resource that has a resource-based policy that
        /// specifically references the federated user session in the <code>Principal</code> element
        /// of the policy.</para><para>When you pass session policies, the session permissions are the intersection of the
        /// IAM user policies and the session policies that you pass. This gives you a way to
        /// further restrict the permissions for a federated user. You cannot use session policies
        /// to grant more permissions than those that are defined in the permissions policy of
        /// the IAM user. For more information, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/access_policies.html#policies_session">Session
        /// Policies</a> in the <i>IAM User Guide</i>.</para><para>The plain text that you use for both inline and managed session policies shouldn't
        /// exceed 2048 characters. The JSON policy characters can be any ASCII character from
        /// the space character to the end of the valid character list (\u0020 through \u00FF).
        /// It can also include the tab (\u0009), linefeed (\u000A), and carriage return (\u000D)
        /// characters.</para><note><para>The characters in this parameter count towards the 2048 character session policy guideline.
        /// However, an AWS conversion compresses the session policies into a packed binary format
        /// that has a separate limit. This is the enforced limit. The <code>PackedPolicySize</code>
        /// response element indicates by percentage how close the policy is to the upper size
        /// limit.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String Policy { get; set; }
        #endregion
        
        #region Parameter PolicyArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Names (ARNs) of the IAM managed policies that you want to use
        /// as a managed session policy. The policies must exist in the same account as the IAM
        /// user that is requesting federated access.</para><para>You must pass an inline or managed <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/access_policies.html#policies_session">session
        /// policy</a> to this operation. You can pass a single JSON policy document to use as
        /// an inline session policy. You can also specify up to 10 managed policies to use as
        /// managed session policies. The plain text that you use for both inline and managed
        /// session policies shouldn't exceed 2048 characters. You can provide up to 10 managed
        /// policy ARNs. For more information about ARNs, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">Amazon
        /// Resource Names (ARNs) and AWS Service Namespaces</a> in the AWS General Reference.</para><para>This parameter is optional. However, if you do not pass any session policies, then
        /// the resulting federated user session has no permissions. The only exception is when
        /// the credentials are used to access a resource that has a resource-based policy that
        /// specifically references the federated user session in the <code>Principal</code> element
        /// of the policy.</para><para>When you pass session policies, the session permissions are the intersection of the
        /// IAM user policies and the session policies that you pass. This gives you a way to
        /// further restrict the permissions for a federated user. You cannot use session policies
        /// to grant more permissions than those that are defined in the permissions policy of
        /// the IAM user. For more information, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/access_policies.html#policies_session">Session
        /// Policies</a> in the <i>IAM User Guide</i>.</para><note><para>The characters in this parameter count towards the 2048 character session policy guideline.
        /// However, an AWS conversion compresses the session policies into a packed binary format
        /// that has a separate limit. This is the enforced limit. The <code>PackedPolicySize</code>
        /// response element indicates by percentage how close the policy is to the upper size
        /// limit.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PolicyArns")]
        public Amazon.SecurityToken.Model.PolicyDescriptorType[] PolicyArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecurityToken.Model.GetFederationTokenResponse).
        /// Specifying the name of a property of type Amazon.SecurityToken.Model.GetFederationTokenResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SecurityToken.Model.GetFederationTokenResponse, GetSTSFederationTokenCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DurationInSeconds = this.DurationInSeconds;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Policy = this.Policy;
            if (this.PolicyArn != null)
            {
                context.PolicyArn = new List<Amazon.SecurityToken.Model.PolicyDescriptorType>(this.PolicyArn);
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
            var request = new Amazon.SecurityToken.Model.GetFederationTokenRequest();
            
            if (cmdletContext.DurationInSeconds != null)
            {
                request.DurationSeconds = cmdletContext.DurationInSeconds.Value;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Policy != null)
            {
                request.Policy = cmdletContext.Policy;
            }
            if (cmdletContext.PolicyArn != null)
            {
                request.PolicyArns = cmdletContext.PolicyArn;
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
        
        private Amazon.SecurityToken.Model.GetFederationTokenResponse CallAWSServiceOperation(IAmazonSecurityTokenService client, Amazon.SecurityToken.Model.GetFederationTokenRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Security Token Service (STS)", "GetFederationToken");
            try
            {
                #if DESKTOP
                return client.GetFederationToken(request);
                #elif CORECLR
                return client.GetFederationTokenAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? DurationInSeconds { get; set; }
            public System.String Name { get; set; }
            public System.String Policy { get; set; }
            public List<Amazon.SecurityToken.Model.PolicyDescriptorType> PolicyArn { get; set; }
            public System.Func<Amazon.SecurityToken.Model.GetFederationTokenResponse, GetSTSFederationTokenCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
