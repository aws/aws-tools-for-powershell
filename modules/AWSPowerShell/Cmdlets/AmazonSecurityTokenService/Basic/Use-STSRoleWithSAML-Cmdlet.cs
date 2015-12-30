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
    /// Returns a set of temporary security credentials for users who have been authenticated
    /// via a SAML authentication response. This operation provides a mechanism for tying
    /// an enterprise identity store or directory to role-based AWS access without user-specific
    /// credentials or configuration. 
    /// 
    ///  
    /// <para>
    /// The temporary security credentials returned by this operation consist of an access
    /// key ID, a secret access key, and a security token. Applications can use these temporary
    /// security credentials to sign calls to AWS services. The credentials are valid for
    /// the duration that you specified when calling <code>AssumeRoleWithSAML</code>, which
    /// can be up to 3600 seconds (1 hour) or until the time specified in the SAML authentication
    /// response's <code>SessionNotOnOrAfter</code> value, whichever is shorter.
    /// </para><note>The maximum duration for a session is 1 hour, and the minimum duration is 15
    /// minutes, even if values outside this range are specified. </note><para>
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
    /// for AssumeRole, AssumeRoleWithSAML, and AssumeRoleWithWebIdentity</a> in the <i>Using
    /// IAM</i>.
    /// </para><para>
    /// Before your application can call <code>AssumeRoleWithSAML</code>, you must configure
    /// your SAML identity provider (IdP) to issue the claims required by AWS. Additionally,
    /// you must use AWS Identity and Access Management (IAM) to create a SAML provider entity
    /// in your AWS account that represents your identity provider, and create an IAM role
    /// that specifies this SAML provider in its trust policy. 
    /// </para><para>
    /// Calling <code>AssumeRoleWithSAML</code> does not require the use of AWS security credentials.
    /// The identity of the caller is validated by using keys in the metadata document that
    /// is uploaded for the SAML provider entity for your identity provider. 
    /// </para><para>
    /// For more information, see the following resources:
    /// </para><ul><li><a href="http://docs.aws.amazon.com/IAM/latest/UserGuide/id_roles_providers_saml.html">About
    /// SAML 2.0-based Federation</a> in the <i>Using IAM</i>. </li><li><a href="http://docs.aws.amazon.com/IAM/latest/UserGuide/id_roles_providers_create_saml.html">Creating
    /// SAML Identity Providers</a> in the <i>Using IAM</i>. </li><li><a href="http://docs.aws.amazon.com/IAM/latest/UserGuide/id_roles_providers_create_saml_relying-party.html">Configuring
    /// a Relying Party and Claims</a> in the <i>Using IAM</i>. </li><li><a href="http://docs.aws.amazon.com/IAM/latest/UserGuide/id_roles_create_for-idp_saml.html">Creating
    /// a Role for SAML 2.0 Federation</a> in the <i>Using IAM</i>. </li></ul><member name="RoleArn" target="arnType"></member><member name="SAMLAssertion" target="SAMLAssertionType"></member><member name="Policy" target="sessionPolicyDocumentType"></member><member name="DurationSeconds" target="roleDurationSecondsType"></member>
    /// </summary>
    [Cmdlet("Use", "STSRoleWithSAML", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SecurityToken.Model.AssumeRoleWithSAMLResponse")]
    [AWSCmdlet("Invokes the AssumeRoleWithSAML operation against AWS Security Token Service.", Operation = new[] {"AssumeRoleWithSAML"})]
    [AWSCmdletOutput("Amazon.SecurityToken.Model.AssumeRoleWithSAMLResponse",
        "This cmdlet returns a Amazon.SecurityToken.Model.AssumeRoleWithSAMLResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class UseSTSRoleWithSAMLCmdlet : AmazonSecurityTokenServiceClientCmdlet, IExecutor
    {
        
        #region Parameter DurationInSeconds
        /// <summary>
        /// <para>
        /// <para>The duration, in seconds, of the role session. The value can range from 900 seconds
        /// (15 minutes) to 3600 seconds (1 hour). By default, the value is set to 3600 seconds.
        /// An expiration can also be specified in the SAML authentication response's <code>SessionNotOnOrAfter</code>
        /// value. The actual expiration time is whichever value is shorter. </para><note>The maximum duration for a session is 1 hour, and the minimum duration is 15
        /// minutes, even if values outside this range are specified. </note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 4)]
        [Alias("DurationSeconds")]
        public System.Int32 DurationInSeconds { get; set; }
        #endregion
        
        #region Parameter Policy
        /// <summary>
        /// <para>
        /// <para>An IAM policy in JSON format.</para><para>The policy parameter is optional. If you pass a policy, the temporary security credentials
        /// that are returned by the operation have the permissions that are allowed by both the
        /// access policy of the role that is being assumed, <i><b>and</b></i> the policy that
        /// you pass. This gives you a way to further restrict the permissions for the resulting
        /// temporary security credentials. You cannot use the passed policy to grant permissions
        /// that are in excess of those allowed by the access policy of the role that is being
        /// assumed. For more information, <a href="http://docs.aws.amazon.com/IAM/latest/UserGuide/id_credentials_temp_control-access_assumerole.html">Permissions
        /// for AssumeRole, AssumeRoleWithSAML, and AssumeRoleWithWebIdentity</a> in the <i>Using
        /// IAM</i>. </para><note>The policy plain text must be 2048 bytes or shorter. However, an internal conversion
        /// compresses it into a packed binary format with a separate limit. The PackedPolicySize
        /// response element indicates by percentage how close to the upper size limit the policy
        /// is, with 100% equaling the maximum allowed size. </note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3)]
        public System.String Policy { get; set; }
        #endregion
        
        #region Parameter PrincipalArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the SAML provider in IAM that describes the IdP.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.String PrincipalArn { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the role that the caller is assuming.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter SAMLAssertion
        /// <summary>
        /// <para>
        /// <para>The base-64 encoded SAML authentication response provided by the IdP.</para><para>For more information, see <a href="http://docs.aws.amazon.com/IAM/latest/UserGuide/create-role-saml-IdP-tasks.html">Configuring
        /// a Relying Party and Adding Claims</a> in the <i>Using IAM</i> guide. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        public System.String SAMLAssertion { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Use-STSRoleWithSAML (AssumeRoleWithSAML)"))
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
            context.Policy = this.Policy;
            context.PrincipalArn = this.PrincipalArn;
            context.RoleArn = this.RoleArn;
            context.SAMLAssertion = this.SAMLAssertion;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.SecurityToken.Model.AssumeRoleWithSAMLRequest();
            
            if (cmdletContext.DurationInSeconds != null)
            {
                request.DurationSeconds = cmdletContext.DurationInSeconds.Value;
            }
            if (cmdletContext.Policy != null)
            {
                request.Policy = cmdletContext.Policy;
            }
            if (cmdletContext.PrincipalArn != null)
            {
                request.PrincipalArn = cmdletContext.PrincipalArn;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            if (cmdletContext.SAMLAssertion != null)
            {
                request.SAMLAssertion = cmdletContext.SAMLAssertion;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.AssumeRoleWithSAML(request);
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
            public System.String Policy { get; set; }
            public System.String PrincipalArn { get; set; }
            public System.String RoleArn { get; set; }
            public System.String SAMLAssertion { get; set; }
        }
        
    }
}
