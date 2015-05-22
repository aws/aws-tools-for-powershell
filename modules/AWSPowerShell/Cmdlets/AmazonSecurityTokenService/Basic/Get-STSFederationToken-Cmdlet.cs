/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// applications inside a corporate network. Because you must call the <code>GetFederationToken</code>
    /// action using the long-term security credentials of an IAM user, this call is appropriate
    /// in contexts where those credentials can be safely stored, usually in a server-based
    /// application.
    /// 
    ///  <note><para>
    ///  If you are creating a mobile-based or browser-based app that can authenticate users
    /// using a web identity provider like Login with Amazon, Facebook, Google, or an OpenID
    /// Connect-compatible identity provider, we recommend that you use <a href="http://aws.amazon.com/cognito/">Amazon
    /// Cognito</a> or <code>AssumeRoleWithWebIdentity</code>. For more information, see <a href="http://docs.aws.amazon.com/STS/latest/UsingSTS/CreatingWIF.html">Creating Temporary
    /// Security Credentials for Mobile Apps Using Identity Providers</a> in <i>Using Temporary
    /// Security Credentials</i>.
    /// </para></note><para>
    /// The <code>GetFederationToken</code> action must be called by using the long-term AWS
    /// security credentials of an IAM user. You can also call <code>GetFederationToken</code>
    /// using the security credentials of an AWS account (root), but this is not recommended.
    /// Instead, we recommend that you create an IAM user for the purpose of the proxy application
    /// and then attach a policy to the IAM user that limits federated users to only the actions
    /// and resources they need access to. For more information, see <a href="http://docs.aws.amazon.com/IAM/latest/UserGuide/IAMBestPractices.html">IAM
    /// Best Practices</a> in <i>Using IAM</i>. 
    /// </para><para>
    /// The temporary security credentials that are obtained by using the long-term credentials
    /// of an IAM user are valid for the specified duration, between 900 seconds (15 minutes)
    /// and 129600 seconds (36 hours). Temporary credentials that are obtained by using AWS
    /// account (root) credentials have a maximum duration of 3600 seconds (1 hour)
    /// </para><para><b>Permissions</b></para><para>
    /// The permissions for the temporary security credentials returned by <code>GetFederationToken</code>
    /// are determined by a combination of the following: 
    /// </para><ul><li>The policy or policies that are attached to the IAM user whose credentials
    /// are used to call <code>GetFederationToken</code>.</li><li>The policy that is passed
    /// as a parameter in the call.</li></ul><para>
    /// The passed policy is attached to the temporary security credentials that result from
    /// the <code>GetFederationToken</code> API call--that is, to the <i>federated user</i>.
    /// When the federated user makes an AWS request, AWS evaluates the policy attached to
    /// the federated user in combination with the policy or policies attached to the IAM
    /// user whose credentials were used to call <code>GetFederationToken</code>. AWS allows
    /// the federated user's request only when both the federated user <i><b>and</b></i> the
    /// IAM user are explicitly allowed to perform the requested action. The passed policy
    /// cannot grant more permissions than those that are defined in the IAM user policy.
    /// </para><para>
    /// A typical use case is that the permissions of the IAM user whose credentials are used
    /// to call <code>GetFederationToken</code> are designed to allow access to all the actions
    /// and resources that any federated user will need. Then, for individual users, you pass
    /// a policy to the operation that scopes down the permissions to a level that's appropriate
    /// to that individual user, using a policy that allows only a subset of permissions that
    /// are granted to the IAM user. 
    /// </para><para>
    /// If you do not pass a policy, the resulting temporary security credentials have no
    /// effective permissions. The only exception is when the temporary security credentials
    /// are used to access a resource that has a resource-based policy that specifically allows
    /// the federated user to access the resource. 
    /// </para><para>
    /// For more information about how permissions work, see <a href="http://docs.aws.amazon.com/STS/latest/UsingSTS/permissions-get-federation-token.html">Permissions
    /// for GetFederationToken</a> in <i>Using Temporary Security Credentials</i>. For information
    /// about using <code>GetFederationToken</code> to create temporary security credentials,
    /// see <a href="http://docs.aws.amazon.com/STS/latest/UsingSTS/CreatingFedTokens.html">Creating
    /// Temporary Credentials to Enable Access for Federated Users</a> in <i>Using Temporary
    /// Security Credentials</i>. 
    /// </para>
    /// </summary>
    [Cmdlet("Get", "STSFederationToken")]
    [OutputType("Amazon.SecurityToken.Model.GetFederationTokenResponse")]
    [AWSCmdlet("Invokes the GetFederationToken operation against AWS Security Token Service.", Operation = new[] {"GetFederationToken"})]
    [AWSCmdletOutput("Amazon.SecurityToken.Model.GetFederationTokenResponse",
        "This cmdlet returns a GetFederationTokenResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetSTSFederationTokenCmdlet : AmazonSecurityTokenServiceClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The duration, in seconds, that the session should last. Acceptable durations for federation
        /// sessions range from 900 seconds (15 minutes) to 129600 seconds (36 hours), with 43200
        /// seconds (12 hours) as the default. Sessions obtained using AWS account (root) credentials
        /// are restricted to a maximum of 3600 seconds (one hour). If the specified duration
        /// is longer than one hour, the session obtained by using AWS account (root) credentials
        /// defaults to one hour. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        [Alias("DurationSeconds")]
        public Int32 DurationInSeconds { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The name of the federated user. The name is used as an identifier for the temporary
        /// security credentials (such as <code>Bob</code>). For example, you can reference the
        /// federated user name in a resource-based policy, such as in an Amazon S3 bucket policy.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public String Name { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>An IAM policy in JSON format that is passed with the <code>GetFederationToken</code>
        /// call and evaluated along with the policy or policies that are attached to the IAM
        /// user whose credentials are used to call <code>GetFederationToken</code>. The passed
        /// policy is used to scope down the permissions that are available to the IAM user, by
        /// allowing only a subset of the permissions that are granted to the IAM user. The passed
        /// policy cannot grant more permissions than those granted to the IAM user. The final
        /// permissions for the federated user are the most restrictive set based on the intersection
        /// of the passed policy and the IAM user policy.</para><para>If you do not pass a policy, the resulting temporary security credentials have no
        /// effective permissions. The only exception is when the temporary security credentials
        /// are used to access a resource that has a resource-based policy that specifically allows
        /// the federated user to access the resource. </para><para>For more information about how permissions work, see <a href="http://docs.aws.amazon.com/STS/latest/UsingSTS/permissions-get-federation-token.html">Permissions
        /// for GetFederationToken</a> in <i>Using Temporary Security Credentials</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public String Policy { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (ParameterWasBound("DurationInSeconds"))
                context.DurationInSeconds = this.DurationInSeconds;
            context.Name = this.Name;
            context.Policy = this.Policy;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new GetFederationTokenRequest();
            
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
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.GetFederationToken(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public Int32? DurationInSeconds { get; set; }
            public String Name { get; set; }
            public String Policy { get; set; }
        }
        
    }
}
