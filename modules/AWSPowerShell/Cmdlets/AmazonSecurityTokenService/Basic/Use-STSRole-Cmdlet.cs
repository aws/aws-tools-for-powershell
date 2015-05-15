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
    /// secret access key, and a security token) that you can use to access AWS resources
    /// that you might not normally have access to. Typically, you use <code>AssumeRole</code>
    /// for cross-account access or federation. 
    /// 
    ///  
    /// <para><b>Important:</b> You cannot call <code>AssumeRole</code> by using AWS account credentials;
    /// access will be denied. You must use IAM user credentials or temporary security credentials
    /// to call <code>AssumeRole</code>. 
    /// </para><para>
    /// For cross-account access, imagine that you own multiple accounts and need to access
    /// resources in each account. You could create long-term credentials in each account
    /// to access those resources. However, managing all those credentials and remembering
    /// which one can access which account can be time consuming. Instead, you can create
    /// one set of long-term credentials in one account and then use temporary security credentials
    /// to access all the other accounts by assuming roles in those accounts. For more information
    /// about roles, see <a href="http://docs.aws.amazon.com/IAM/latest/UserGuide/WorkingWithRoles.html">Roles</a>
    /// in <i>Using IAM</i>. 
    /// </para><para>
    /// For federation, you can, for example, grant single sign-on access to the AWS Management
    /// Console. If you already have an identity and authentication system in your corporate
    /// network, you don't have to recreate user identities in AWS in order to grant those
    /// user identities access to AWS. Instead, after a user has been authenticated, you call
    /// <code>AssumeRole</code> (and specify the role with the appropriate permissions) to
    /// get temporary security credentials for that user. With those temporary security credentials,
    /// you construct a sign-in URL that users can use to access the console. For more information,
    /// see <a href="http://docs.aws.amazon.com/STS/latest/UsingSTS/STSUseCases.html">Scenarios
    /// for Granting Temporary Access</a> in <i>Using Temporary Security Credentials</i>.
    /// 
    /// </para><para>
    /// The temporary security credentials are valid for the duration that you specified when
    /// calling <code>AssumeRole</code>, which can be from 900 seconds (15 minutes) to 3600
    /// seconds (1 hour). The default is 1 hour. 
    /// </para><para>
    /// Optionally, you can pass an IAM access policy to this operation. If you choose not
    /// to pass a policy, the temporary security credentials that are returned by the operation
    /// have the permissions that are defined in the access policy of the role that is being
    /// assumed. If you pass a policy to this operation, the temporary security credentials
    /// that are returned by the operation have the permissions that are allowed by both the
    /// access policy of the role that is being assumed, <i><b>and</b></i> the policy that
    /// you pass. This gives you a way to further restrict the permissions for the resulting
    /// temporary security credentials. You cannot use the passed policy to grant permissions
    /// that are in excess of those allowed by the access policy of the role that is being
    /// assumed. For more information, see <a href="http://docs.aws.amazon.com/STS/latest/UsingSTS/permissions-assume-role.html">Permissions
    /// for AssumeRole</a> in <i>Using Temporary Security Credentials</i>.
    /// </para><para>
    /// To assume a role, your AWS account must be trusted by the role. The trust relationship
    /// is defined in the role's trust policy when the role is created. You must also have
    /// a policy that allows you to call <code>sts:AssumeRole</code>. 
    /// </para><para><b>Using MFA with AssumeRole</b></para><para>
    /// You can optionally include multi-factor authentication (MFA) information when you
    /// call <code>AssumeRole</code>. This is useful for cross-account scenarios in which
    /// you want to make sure that the user who is assuming the role has been authenticated
    /// using an AWS MFA device. In that scenario, the trust policy of the role being assumed
    /// includes a condition that tests for MFA authentication; if the caller does not include
    /// valid MFA information, the request to assume the role is denied. The condition in
    /// a trust policy that tests for MFA authentication might look like the following example.
    /// </para><para><code>"Condition": {"Null": {"aws:MultiFactorAuthAge": false}}</code></para><para>
    /// For more information, see <a href="http://docs.aws.amazon.com/IAM/latest/UserGuide/MFAProtectedAPI.html">Configuring
    /// MFA-Protected API Access</a> in the <i>Using IAM</i> guide. 
    /// </para><para>
    /// To use MFA with <code>AssumeRole</code>, you pass values for the <code>SerialNumber</code>
    /// and <code>TokenCode</code> parameters. The <code>SerialNumber</code> value identifies
    /// the user's hardware or virtual MFA device. The <code>TokenCode</code> is the time-based
    /// one-time password (TOTP) that the MFA devices produces. 
    /// </para><member name="RoleArn" target="arnType"></member><member name="RoleSessionName" target="userNameType"></member><member name="Policy" target="sessionPolicyDocumentType"></member><member name="DurationSeconds" target="roleDurationSecondsType"></member><member name="ExternalId" target="externalIdType"></member>
    /// </summary>
    [Cmdlet("Use", "STSRole", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SecurityToken.Model.AssumeRoleResult")]
    [AWSCmdlet("Invokes the AssumeRole operation against AWS Security Token Service.", Operation = new[] {"AssumeRole"})]
    [AWSCmdletOutput("Amazon.SecurityToken.Model.AssumeRoleResult",
        "This cmdlet returns a AssumeRoleResult object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class UseSTSRoleCmdlet : AmazonSecurityTokenServiceClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The duration, in seconds, of the role session. The value can range from 900 seconds
        /// (15 minutes) to 3600 seconds (1 hour). By default, the value is set to 3600 seconds.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3)]
        [Alias("DurationSeconds")]
        public Int32 DurationInSeconds { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A unique identifier that is used by third parties to assume a role in their customers'
        /// accounts. For each role that the third party can assume, they should instruct their
        /// customers to create a role with the external ID that the third party generated. Each
        /// time the third party assumes the role, they must pass the customer's external ID.
        /// The external ID is useful in order to help third parties bind a role to the customer
        /// who created it. For more information about the external ID, see <a href="http://docs.aws.amazon.com/STS/latest/UsingSTS/sts-delegating-externalid.html" target="_blank">About the External ID</a> in <i>Using Temporary Security Credentials</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 4)]
        public String ExternalId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>An IAM policy in JSON format.</para><para>The policy parameter is optional. If you pass a policy, the temporary security credentials
        /// that are returned by the operation have the permissions that are allowed by both the
        /// access policy of the role that is being assumed, <i><b>and</b></i> the policy that
        /// you pass. This gives you a way to further restrict the permissions for the resulting
        /// temporary security credentials. You cannot use the passed policy to grant permissions
        /// that are in excess of those allowed by the access policy of the role that is being
        /// assumed. For more information, see <a href="http://docs.aws.amazon.com/STS/latest/UsingSTS/permissions-assume-role.html">Permissions
        /// for AssumeRole</a> in <i>Using Temporary Security Credentials</i>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        public String Policy { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the role that the caller is assuming.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public String RoleArn { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>An identifier for the assumed role session. The session name is included as part of
        /// the <code>AssumedRoleUser</code>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public String RoleSessionName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The identification number of the MFA device that is associated with the user who is
        /// making the <code>AssumeRole</code> call. Specify this value if the trust policy of
        /// the role being assumed includes a condition that requires MFA authentication. The
        /// value is either the serial number for a hardware device (such as <code>GAHT12345678</code>)
        /// or an Amazon Resource Name (ARN) for a virtual device (such as <code>arn:aws:iam::123456789012:mfa/user</code>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String SerialNumber { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The value provided by the MFA device, if the trust policy of the role being assumed
        /// requires MFA (that is, if the policy includes a condition that tests for MFA). If
        /// the role being assumed requires MFA and if the <code>TokenCode</code> value is missing
        /// or expired, the <code>AssumeRole</code> call returns an "access denied" error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String TokenCode { get; set; }
        
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("RoleArn", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Use-STSRole (AssumeRole)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (ParameterWasBound("DurationInSeconds"))
                context.DurationInSeconds = this.DurationInSeconds;
            context.ExternalId = this.ExternalId;
            context.Policy = this.Policy;
            context.RoleArn = this.RoleArn;
            context.RoleSessionName = this.RoleSessionName;
            context.SerialNumber = this.SerialNumber;
            context.TokenCode = this.TokenCode;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new AssumeRoleRequest();
            
            if (cmdletContext.DurationInSeconds != null)
            {
                request.DurationSeconds = cmdletContext.DurationInSeconds.Value;
            }
            if (cmdletContext.ExternalId != null)
            {
                request.ExternalId = cmdletContext.ExternalId;
            }
            if (cmdletContext.Policy != null)
            {
                request.Policy = cmdletContext.Policy;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            if (cmdletContext.RoleSessionName != null)
            {
                request.RoleSessionName = cmdletContext.RoleSessionName;
            }
            if (cmdletContext.SerialNumber != null)
            {
                request.SerialNumber = cmdletContext.SerialNumber;
            }
            if (cmdletContext.TokenCode != null)
            {
                request.TokenCode = cmdletContext.TokenCode;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.AssumeRole(request);
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
            public String ExternalId { get; set; }
            public String Policy { get; set; }
            public String RoleArn { get; set; }
            public String RoleSessionName { get; set; }
            public String SerialNumber { get; set; }
            public String TokenCode { get; set; }
        }
        
    }
}
