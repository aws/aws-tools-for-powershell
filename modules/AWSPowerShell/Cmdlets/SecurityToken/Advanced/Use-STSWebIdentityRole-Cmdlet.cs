/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Management.Automation;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.SecurityToken;
using Amazon.SecurityToken.Model;

namespace Amazon.PowerShell.Cmdlets.STS
{
    /// <summary>
    /// <para> Returns a set of temporary security credentials for users who have been authenticated in a mobile or web application with a web
    /// identity provider, such as Login with Amazon, Facebook, or Google. <c>AssumeRoleWithWebIdentity</c> is an API call that does not require the
    /// use of AWS security credentials. Therefore, you can distribute an application (for example, on mobile devices) that requests temporary
    /// security credentials without including long-term AWS credentials in the application or by deploying server-based proxy services that use
    /// long-term AWS credentials. For more information, see Creating a Mobile Application with Third-Party Sign-In in <i>AWS Security Token
    /// Service</i> .
    /// </para><para> The temporary security credentials consist of an access key ID, a secret access key, and a security token. Applications can
    /// use these temporary security credentials to sign calls to AWS service APIs. The credentials are valid for the duration that you specified
    /// when calling <c>AssumeRoleWithWebIdentity</c> , which can be from 900 seconds (15 minutes) to 3600 seconds (1 hour). By default, the
    /// temporary security credentials are valid for 1 hour. </para><para> The temporary security credentials that are returned from the
    /// <c>AssumeRoleWithWebIdentity</c> response have the permissions that are associated with the access policy of the role being assumed and any
    /// policies that are associated with the AWS resource being accessed. You can further restrict the permissions of the temporary security
    /// credentials by passing a policy in the request. The resulting permissions are an intersection of both policies. The role's access policy and
    /// the policy that you passed are evaluated when calls to AWS service APIs are made using the temporary security credentials. </para><para>
    /// Before your application can call <c>AssumeRoleWithWebIdentity</c> , you must have an identity token from an identity provider and create a
    /// role that the application can assume. Typically, to get an identity token, you need to register your application with the identity provider
    /// and get a unique application ID from that provider. Also, when you create the role that the application assumes, you must specify the
    /// registered identity provider as a principal (establish trust with the identity provider). For more information, see Creating Temporary
    /// Security Credentials for Mobile Apps Using Third-Party Identity Providers. </para>
    /// </summary>
    [Cmdlet("Use", "STSWebIdentityRole")]
    [OutputType("Amazon.PowerShell.Common.AWSWebIdentityCredentials")]
    [AWSCmdlet("Calls the AWS Security Token Service AssumeRoleWithWebIdentity API operation.", Operation = new[] { "AssumeRoleWithWebIdentity" }, SelectReturnType = typeof(Amazon.SecurityToken.Model.AssumeRoleWithWebIdentityResponse))]
    [AWSCmdletOutput("Amazon.PowerShell.Common.AWSWebIdentityCredentials or Amazon.SecurityToken.Model.AssumeRoleWithWebIdentityResponse",
        "This cmdlet returns an Amazon.SecurityToken.Model.AssumeRoleWithWebIdentityResponse instance. The service call response(s) (type Amazon.SecurityToken.Model.AssumeRoleWithWebIdentityResponse) can be returned by specifying '-Select *'.")]
    [AWSClientCmdlet("AWS Security Token Service", "STS", null, "SecurityToken")]
    public class UseSTSWebIdentityRoleCmdlet : BaseCmdlet, IExecutor
    {
        protected IAmazonSecurityTokenService Client { get; private set; }

        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// The Amazon Resource Name (ARN) of the role that the caller is assuming.
        ///  
        /// <para><b>Constraints:</b><list type="definition"><item><term>Length</term><description>20 - 2048</description></item></list></para>
        /// </para>
        /// </summary>
        [Parameter(Position = 0, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true)]
        public System.String RoleArn { get; set; }
        #endregion

        #region Parameter RoleSessionName
        /// <summary>
        /// <para>
        /// An identifier for the assumed role session. Typically, you pass the name or identifier that is associated with the user who is using your
        /// application. That way, the temporary security credentials that your application will use are associated with that user. This session name is
        /// included as part of the ARN and assumed role ID in the <c>AssumedRoleUser</c> response element.
        ///  
        /// <para><b>Constraints:</b><list type="definition"><item><term>Length</term><description>2 - 32</description></item><item><term>Pattern</term><description>[\w+=,.@-]*</description></item></list></para>
        /// </para>
        /// </summary>
        [Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String RoleSessionName { get; set; }
        #endregion

        #region Parameter WebIdentityToken
        /// <summary>
        /// <para>
        /// The OAuth 2.0 access token or OpenID Connect id token that is provided by the identity provider. Your application must get this token by
        /// authenticating the user who is using your application with a web identity provider before the application makes an
        /// <c>AssumeRoleWithWebIdentity</c> call.
        ///  
        /// <para><b>Constraints:</b><list type="definition"><item><term>Length</term><description>4 - 2048</description></item></list></para>
        /// </para>
        /// </summary>
        [Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        public System.String WebIdentityToken { get; set; }
        #endregion

        #region Parameter ProviderId
        /// <summary>
        /// <para>
        /// Specify this value only for OAuth access tokens. Do not specify this value for OpenID Connect id tokens, such as <c>accounts.google.com</c>.
        /// This is the fully-qualified host component of the domain name of the identity provider. Do not include URL schemes and port numbers.
        /// Currently, <c>www.amazon.com</c> and <c>graph.facebook.com</c> are supported.
        ///  
        /// <para><b>Constraints:</b><list type="definition"><item><term>Length</term><description>4 - 2048</description></item></list></para>
        /// </para>
        /// </summary>
        [Parameter(Position = 3, ValueFromPipelineByPropertyName = true)]
        public System.String ProviderId { get; set; }
        #endregion

        #region Parameter Policy
        /// <summary>
        /// <para>
        /// A supplemental policy that is associated with the temporary security credentials from the <c>AssumeRoleWithWebIdentity</c> call. The
        /// resulting permissions of the temporary security credentials are an intersection of this policy and the access policy that is associated with
        /// the role. Use this policy to further restrict the permissions of the temporary security credentials.
        ///  
        /// <para><b>Constraints:</b><list type="definition"><item><term>Length</term><description>1 - 2048</description></item><item><term>Pattern</term><description>[\u0009\u000A\u000D\u0020-\u00FF]+</description></item></list></para>
        /// </para>
        /// </summary>
        [Parameter(Position = 4, ValueFromPipelineByPropertyName = true)]
        public System.String Policy { get; set; }
        #endregion

        #region Parameter Duration
        /// <summary>
        /// <para>
        /// The duration, in seconds, of the role session. The value can range from 900 seconds (15 minutes) to 3600 seconds (1 hour). By default, the
        /// value is set to 3600 seconds.
        ///  
        /// <para><b>Constraints:</b><list type="definition"><item><term>Range</term><description>900 - 129600</description></item></list></para>
        /// </para>
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DurationSeconds")]
        public System.Int32? Duration { get; set; }
        #endregion

        #region Parameter Region
        /// <summary>
        /// The region to use. STS has a single endpoint irrespective of region, though STS in GovCloud and China (Beijing) has its own endpoint.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Region { get; set; }
        #endregion

        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecurityToken.Model.AssumeRoleWithWebIdentityResponse).
        /// Specifying the name of a property of type Amazon.SecurityToken.Model.AssumeRoleWithWebIdentityResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter]
        public string Select { get; set; } = "*";
        #endregion

        protected IAmazonSecurityTokenService CreateClient()
        {
            var config = new AmazonSecurityTokenServiceConfig();
            Amazon.PowerShell.Utils.Common.PopulateConfig(this, config);

            if (!string.IsNullOrEmpty(this.Region))
            {
                config.RegionEndpoint = RegionEndpoint.GetBySystemName(this.Region);
            }

            AmazonSecurityTokenServiceClient client = new AmazonSecurityTokenServiceClient(new AnonymousAWSCredentials(), config);
            client.BeforeRequestEvent += RequestEventHandler;
            client.AfterResponseEvent += ResponseEventHandler;

            return client;
        }
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            Client = CreateClient();
            
            var context = new CmdletContext
            {
                RoleArn = this.RoleArn,
                RoleSessionName = this.RoleSessionName,
                WebIdentityToken = this.WebIdentityToken,
                ProviderId = this.ProviderId,
                Policy = this.Policy,
                DurationSeconds = this.Duration,
                Region = this.Region
            };

            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SecurityToken.Model.AssumeRoleWithWebIdentityResponse, UseSTSWebIdentityRoleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }

            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new AssumeRoleWithWebIdentityRequest();
            
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            if (cmdletContext.RoleSessionName != null)
            {
                request.RoleSessionName = cmdletContext.RoleSessionName;
            }
            if (cmdletContext.WebIdentityToken != null)
            {
                request.WebIdentityToken = cmdletContext.WebIdentityToken;
            }
            if (cmdletContext.ProviderId != null)
            {
                request.ProviderId = cmdletContext.ProviderId;
            }
            if (cmdletContext.Policy != null)
            {
                request.Policy = cmdletContext.Policy;
            }
            if (cmdletContext.DurationSeconds != null)
            {
                request.DurationSeconds = cmdletContext.DurationSeconds.Value;
            }

            // issue call
            var client = Client ?? CreateClient();
            CmdletOutput output;

            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = cmdletContext.Select(response, this); ;
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

        private Amazon.SecurityToken.Model.AssumeRoleWithWebIdentityResponse CallAWSServiceOperation(IAmazonSecurityTokenService client, Amazon.SecurityToken.Model.AssumeRoleWithWebIdentityRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Security Token Service", "AssumeRoleWithWebIdentity");

            try
            {
#if DESKTOP
                return client.AssumeRoleWithWebIdentity(request);
#elif CORECLR
                return client.AssumeRoleWithWebIdentityAsync(request).GetAwaiter().GetResult();
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

        internal class CmdletContext : ExecutorContext
        {
            public String RoleArn { get; set; }
            public String RoleSessionName { get; set; }
            public String WebIdentityToken { get; set; }
            public String ProviderId { get; set; }
            public String Policy { get; set; }
            public Int32? DurationSeconds { get; set; }
            public String Region { get; set; }
            public System.Func<Amazon.SecurityToken.Model.AssumeRoleWithWebIdentityResponse, UseSTSWebIdentityRoleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => new AWSWebIdentityCredentials(response.Credentials.AccessKeyId,
                                                                    response.Credentials.SecretAccessKey,
                                                                    response.Credentials.SessionToken,
                                                                    response.Credentials.Expiration);
        }
        
    }
}
