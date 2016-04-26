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
    /// for cross-account access or federation. For a comparison of <code>AssumeRole</code>
    /// with the other APIs that produce temporary credentials, see <a href="http://docs.aws.amazon.com/IAM/latest/UserGuide/id_credentials_temp_request.html">Requesting
    /// Temporary Security Credentials</a> and <a href="http://docs.aws.amazon.com/IAM/latest/UserGuide/id_credentials_temp_request.html#stsapi_comparison">Comparing
    /// the AWS STS APIs</a> in the <i>IAM User Guide</i>.
    /// 
    ///  
    /// <para><b>Important:</b> You cannot call <code>AssumeRole</code> by using AWS root account
    /// credentials; access is denied. You must use IAM user credentials or temporary security
    /// credentials to call <code>AssumeRole</code>. 
    /// </para><para>
    /// For cross-account access, imagine that you own multiple accounts and need to access
    /// resources in each account. You could create long-term credentials in each account
    /// to access those resources. However, managing all those credentials and remembering
    /// which one can access which account can be time consuming. Instead, you can create
    /// one set of long-term credentials in one account and then use temporary security credentials
    /// to access all the other accounts by assuming roles in those accounts. For more information
    /// about roles, see <a href="http://docs.aws.amazon.com/IAM/latest/UserGuide/roles-toplevel.html">IAM
    /// Roles (Delegation and Federation)</a> in the <i>IAM User Guide</i>. 
    /// </para><para>
    /// For federation, you can, for example, grant single sign-on access to the AWS Management
    /// Console. If you already have an identity and authentication system in your corporate
    /// network, you don't have to recreate user identities in AWS in order to grant those
    /// user identities access to AWS. Instead, after a user has been authenticated, you call
    /// <code>AssumeRole</code> (and specify the role with the appropriate permissions) to
    /// get temporary security credentials for that user. With those temporary security credentials,
    /// you construct a sign-in URL that users can use to access the console. For more information,
    /// see <a href="http://docs.aws.amazon.com/IAM/latest/UserGuide/id_credentials_temp.html#sts-introduction">Common
    /// Scenarios for Temporary Credentials</a> in the <i>IAM User Guide</i>.
    /// </para><para>
    /// The temporary security credentials are valid for the duration that you specified when
    /// calling <code>AssumeRole</code>, which can be from 900 seconds (15 minutes) to a maximum
    /// of 3600 seconds (1 hour). The default is 1 hour. 
    /// </para><para>
    /// The temporary security credentials created by <code>AssumeRole</code> can be used
    /// to make API calls to any AWS service with the following exception: you cannot call
    /// the STS service's <code>GetFederationToken</code> or <code>GetSessionToken</code>
    /// APIs.
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
    /// assumed. For more information, see <a href="http://docs.aws.amazon.com/IAM/latest/UserGuide/id_credentials_temp_control-access_assumerole.html">Permissions
    /// for AssumeRole, AssumeRoleWithSAML, and AssumeRoleWithWebIdentity</a> in the <i>IAM
    /// User Guide</i>.
    /// </para><para>
    /// To assume a role, your AWS account must be trusted by the role. The trust relationship
    /// is defined in the role's trust policy when the role is created. That trust policy
    /// states which accounts are allowed to delegate access to this account's role.
    /// </para><para>
    /// The user who wants to access the role must also have permissions delegated from the
    /// role's administrator. If the user is in a different account than the role, then the
    /// user's administrator must attach a policy that allows the user to call AssumeRole
    /// on the ARN of the role in the other account. If the user is in the same account as
    /// the role, then you can either attach a policy to the user (identical to the previous
    /// different account user), or you can add the user as a principal directly in the role's
    /// trust policy
    /// </para><para><b>Using MFA with AssumeRole</b></para><para>
    /// You can optionally include multi-factor authentication (MFA) information when you
    /// call <code>AssumeRole</code>. This is useful for cross-account scenarios in which
    /// you want to make sure that the user who is assuming the role has been authenticated
    /// using an AWS MFA device. In that scenario, the trust policy of the role being assumed
    /// includes a condition that tests for MFA authentication; if the caller does not include
    /// valid MFA information, the request to assume the role is denied. The condition in
    /// a trust policy that tests for MFA authentication might look like the following example.
    /// </para><para><code>"Condition": {"Bool": {"aws:MultiFactorAuthPresent": true}}</code></para><para>
    /// For more information, see <a href="http://docs.aws.amazon.com/IAM/latest/UserGuide/MFAProtectedAPI.html">Configuring
    /// MFA-Protected API Access</a> in the <i>IAM User Guide</i> guide.
    /// </para><para>
    /// To use MFA with <code>AssumeRole</code>, you pass values for the <code>SerialNumber</code>
    /// and <code>TokenCode</code> parameters. The <code>SerialNumber</code> value identifies
    /// the user's hardware or virtual MFA device. The <code>TokenCode</code> is the time-based
    /// one-time password (TOTP) that the MFA devices produces. 
    /// </para>
    /// </summary>
    [Cmdlet("Use", "STSRole", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SecurityToken.Model.AssumeRoleResponse")]
    [AWSCmdlet("Invokes the AssumeRole operation against AWS Security Token Service.", Operation = new[] {"AssumeRole"})]
    [AWSCmdletOutput("Amazon.SecurityToken.Model.AssumeRoleResponse",
        "This cmdlet returns a Amazon.SecurityToken.Model.AssumeRoleResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class UseSTSRoleCmdlet : AmazonSecurityTokenServiceClientCmdlet, IExecutor
    {
        
        #region Parameter DurationInSeconds
        /// <summary>
        /// <para>
        /// <para>The duration, in seconds, of the role session. The value can range from 900 seconds
        /// (15 minutes) to 3600 seconds (1 hour). By default, the value is set to 3600 seconds.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3)]
        [Alias("DurationSeconds")]
        public System.Int32 DurationInSeconds { get; set; }
        #endregion
        
        #region Parameter ExternalId
        /// <summary>
        /// <para>
        /// <para>A unique identifier that is used by third parties when assuming roles in their customers'
        /// accounts. For each role that the third party can assume, they should instruct their
        /// customers to ensure the role's trust policy checks for the external ID that the third
        /// party generated. Each time the third party assumes the role, they should pass the
        /// customer's external ID. The external ID is useful in order to help third parties bind
        /// a role to the customer who created it. For more information about the external ID,
        /// see <a href="http://docs.aws.amazon.com/IAM/latest/UserGuide/id_roles_create_for-user_externalid.html">How
        /// to Use an External ID When Granting Access to Your AWS Resources to a Third Party</a>
        /// in the <i>IAM User Guide</i>.</para><para>The format for this parameter, as described by its regex pattern, is a string of characters
        /// consisting of upper- and lower-case alphanumeric characters with no spaces. You can
        /// also include any of the following characters: =,.@:\/-</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 4)]
        public System.String ExternalId { get; set; }
        #endregion
        
        #region Parameter Policy
        /// <summary>
        /// <para>
        /// <para>An IAM policy in JSON format.</para><para>This parameter is optional. If you pass a policy, the temporary security credentials
        /// that are returned by the operation have the permissions that are allowed by both (the
        /// intersection of) the access policy of the role that is being assumed, <i>and</i> the
        /// policy that you pass. This gives you a way to further restrict the permissions for
        /// the resulting temporary security credentials. You cannot use the passed policy to
        /// grant permissions that are in excess of those allowed by the access policy of the
        /// role that is being assumed. For more information, see <a href="http://docs.aws.amazon.com/IAM/latest/UserGuide/id_credentials_temp_control-access_assumerole.html">Permissions
        /// for AssumeRole, AssumeRoleWithSAML, and AssumeRoleWithWebIdentity</a> in the <i>IAM
        /// User Guide</i>.</para><para>The format for this parameter, as described by its regex pattern, is a string of characters
        /// up to 2048 characters in length. The characters can be any ASCII character from the
        /// space character to the end of the valid character list (\u0020-\u00FF). It can also
        /// include the tab (\u0009), linefeed (\u000A), and carriage return (\u000D) characters.</para><note><para>The policy plain text must be 2048 bytes or shorter. However, an internal conversion
        /// compresses it into a packed binary format with a separate limit. The PackedPolicySize
        /// response element indicates by percentage how close to the upper size limit the policy
        /// is, with 100% equaling the maximum allowed size.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        public System.String Policy { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the role to assume.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter RoleSessionName
        /// <summary>
        /// <para>
        /// <para>An identifier for the assumed role session.</para><para>Use the role session name to uniquely identify a session when the same role is assumed
        /// by different principals or for different reasons. In cross-account scenarios, the
        /// role session name is visible to, and can be logged by the account that owns the role.
        /// The role session name is also used in the ARN of the assumed role principal. This
        /// means that subsequent cross-account API requests using the temporary security credentials
        /// will expose the role session name to the external account in their CloudTrail logs.</para><para>The format for this parameter, as described by its regex pattern, is a string of characters
        /// consisting of upper- and lower-case alphanumeric characters with no spaces. You can
        /// also include any of the following characters: =,.@-</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.String RoleSessionName { get; set; }
        #endregion
        
        #region Parameter SerialNumber
        /// <summary>
        /// <para>
        /// <para>The identification number of the MFA device that is associated with the user who is
        /// making the <code>AssumeRole</code> call. Specify this value if the trust policy of
        /// the role being assumed includes a condition that requires MFA authentication. The
        /// value is either the serial number for a hardware device (such as <code>GAHT12345678</code>)
        /// or an Amazon Resource Name (ARN) for a virtual device (such as <code>arn:aws:iam::123456789012:mfa/user</code>).</para><para>The format for this parameter, as described by its regex pattern, is a string of characters
        /// consisting of upper- and lower-case alphanumeric characters with no spaces. You can
        /// also include any of the following characters: =,.@-</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SerialNumber { get; set; }
        #endregion
        
        #region Parameter TokenCode
        /// <summary>
        /// <para>
        /// <para>The value provided by the MFA device, if the trust policy of the role being assumed
        /// requires MFA (that is, if the policy includes a condition that tests for MFA). If
        /// the role being assumed requires MFA and if the <code>TokenCode</code> value is missing
        /// or expired, the <code>AssumeRole</code> call returns an "access denied" error.</para><para>The format for this parameter, as described by its regex pattern, is a sequence of
        /// six numeric digits.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TokenCode { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
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
            var request = new Amazon.SecurityToken.Model.AssumeRoleRequest();
            
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
            public System.Int32? DurationInSeconds { get; set; }
            public System.String ExternalId { get; set; }
            public System.String Policy { get; set; }
            public System.String RoleArn { get; set; }
            public System.String RoleSessionName { get; set; }
            public System.String SerialNumber { get; set; }
            public System.String TokenCode { get; set; }
        }
        
    }
}
