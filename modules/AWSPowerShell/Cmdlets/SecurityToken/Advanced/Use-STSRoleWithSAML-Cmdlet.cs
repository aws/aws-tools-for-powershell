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
    /// credentials or configuration. For a comparison of <code>AssumeRoleWithSAML</code>
    /// with the other APIs that produce temporary credentials, see <a href="http://docs.aws.amazon.com/IAM/latest/UserGuide/id_credentials_temp_request.html">Requesting
    /// Temporary Security Credentials</a> and <a href="http://docs.aws.amazon.com/IAM/latest/UserGuide/id_credentials_temp_request.html#stsapi_comparison">Comparing
    /// the AWS STS APIs</a> in the <i>IAM User Guide</i>.
    /// 
    ///  
    /// <para>
    /// The temporary security credentials returned by this operation consist of an access
    /// key ID, a secret access key, and a security token. Applications can use these temporary
    /// security credentials to sign calls to AWS services.
    /// </para><para>
    /// The temporary security credentials are valid for the duration that you specified when
    /// calling <code>AssumeRole</code>, or until the time specified in the SAML authentication
    /// response's <code>SessionNotOnOrAfter</code> value, whichever is shorter. The duration
    /// can be from 900 seconds (15 minutes) to a maximum of 3600 seconds (1 hour). The default
    /// is 1 hour.
    /// </para><para>
    /// The temporary security credentials created by <code>AssumeRoleWithSAML</code> can
    /// be used to make API calls to any AWS service with the following exception: you cannot
    /// call the STS service's <code>GetFederationToken</code> or <code>GetSessionToken</code>
    /// APIs.
    /// </para><para>
    /// Optionally, you can pass an IAM access policy to this operation. If you choose not
    /// to pass a policy, the temporary security credentials that are returned by the operation
    /// have the permissions that are defined in the access policy of the role that is being
    /// assumed. If you pass a policy to this operation, the temporary security credentials
    /// that are returned by the operation have the permissions that are allowed by the intersection
    /// of both the access policy of the role that is being assumed, <i><b>and</b></i> the
    /// policy that you pass. This means that both policies must grant the permission for
    /// the action to be allowed. This gives you a way to further restrict the permissions
    /// for the resulting temporary security credentials. You cannot use the passed policy
    /// to grant permissions that are in excess of those allowed by the access policy of the
    /// role that is being assumed. For more information, see <a href="http://docs.aws.amazon.com/IAM/latest/UserGuide/id_credentials_temp_control-access_assumerole.html">Permissions
    /// for AssumeRole, AssumeRoleWithSAML, and AssumeRoleWithWebIdentity</a> in the <i>IAM
    /// User Guide</i>.
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
    /// </para><important><para>
    /// Calling <code>AssumeRoleWithSAML</code> can result in an entry in your AWS CloudTrail
    /// logs. The entry includes the value in the <code>NameID</code> element of the SAML
    /// assertion. We recommend that you use a NameIDType that is not associated with any
    /// personally identifiable information (PII). For example, you could instead use the
    /// Persistent Identifier (<code>urn:oasis:names:tc:SAML:2.0:nameid-format:persistent</code>).
    /// </para></important><para>
    /// For more information, see the following resources:
    /// </para><ul><li><para><a href="http://docs.aws.amazon.com/IAM/latest/UserGuide/id_roles_providers_saml.html">About
    /// SAML 2.0-based Federation</a> in the <i>IAM User Guide</i>. 
    /// </para></li><li><para><a href="http://docs.aws.amazon.com/IAM/latest/UserGuide/id_roles_providers_create_saml.html">Creating
    /// SAML Identity Providers</a> in the <i>IAM User Guide</i>. 
    /// </para></li><li><para><a href="http://docs.aws.amazon.com/IAM/latest/UserGuide/id_roles_providers_create_saml_relying-party.html">Configuring
    /// a Relying Party and Claims</a> in the <i>IAM User Guide</i>. 
    /// </para></li><li><para><a href="http://docs.aws.amazon.com/IAM/latest/UserGuide/id_roles_create_for-idp_saml.html">Creating
    /// a Role for SAML 2.0 Federation</a> in the <i>IAM User Guide</i>. 
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Use", "STSRoleWithSAML", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SecurityToken.Model.AssumeRoleWithSAMLResponse")]
    [AWSCmdlet("Calls the AWS Security Token Service AssumeRoleWithSAML API operation.", Operation = new[] { "AssumeRoleWithSAML" }, SelectReturnType = typeof(Amazon.SecurityToken.Model.AssumeRoleWithSAMLResponse))]
    [AWSCmdletOutput("Amazon.SecurityToken.Model.AssumeRoleWithSAMLResponse",
        "This cmdlet returns an Amazon.SecurityToken.Model.AssumeRoleWithSAMLResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.")]
    [AWSClientCmdlet("AWS Security Token Service", "STS", null, "SecurityToken")]
    public partial class UseSTSRoleWithSAMLCmdlet : BaseCmdlet, IExecutor
    {
        protected IAmazonSecurityTokenService Client { get; private set; }

        #region Parameter DurationInSeconds
        /// <summary>
        /// <para>
        /// <para>The duration, in seconds, of the role session. The value can range from 900 seconds
        /// (15 minutes) to 3600 seconds (1 hour). By default, the value is set to 3600 seconds.
        /// An expiration can also be specified in the SAML authentication response's <code>SessionNotOnOrAfter</code>
        /// value. The actual expiration time is whichever value is shorter. </para><note><para>This is separate from the duration of a console session that you might request using
        /// the returned credentials. The request to the federation endpoint for a console sign-in
        /// token takes a <code>SessionDuration</code> parameter that specifies the maximum length
        /// of the console session, separately from the <code>DurationSeconds</code> parameter
        /// on this API. For more information, see <a href="http://docs.aws.amazon.com/IAM/latest/UserGuide/id_roles_providers_enable-console-saml.html">Enabling
        /// SAML 2.0 Federated Users to Access the AWS Management Console</a> in the <i>IAM User
        /// Guide</i>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 4, ValueFromPipelineByPropertyName = true)]
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
        /// for AssumeRole, AssumeRoleWithSAML, and AssumeRoleWithWebIdentity</a> in the <i>IAM
        /// User Guide</i>. </para><para>The format for this parameter, as described by its regex pattern, is a string of characters
        /// up to 2048 characters in length. The characters can be any ASCII character from the
        /// space character to the end of the valid character list (\u0020-\u00FF). It can also
        /// include the tab (\u0009), linefeed (\u000A), and carriage return (\u000D) characters.</para><note><para>The policy plain text must be 2048 bytes or shorter. However, an internal conversion
        /// compresses it into a packed binary format with a separate limit. The PackedPolicySize
        /// response element indicates by percentage how close to the upper size limit the policy
        /// is, with 100% equaling the maximum allowed size.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3, ValueFromPipelineByPropertyName = true)]
        public System.String Policy { get; set; }
        #endregion
        
        #region Parameter PrincipalArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the SAML provider in IAM that describes the IdP.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String PrincipalArn { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the role that the caller is assuming.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true)]
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter SAMLAssertion
        /// <summary>
        /// <para>
        /// <para>The base-64 encoded SAML authentication response provided by the IdP.</para><para>For more information, see <a href="http://docs.aws.amazon.com/IAM/latest/UserGuide/create-role-saml-IdP-tasks.html">Configuring
        /// a Relying Party and Adding Claims</a> in the <i>Using IAM</i> guide. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
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

        #region Parameter Region
        /// <summary>
        /// The region to use. STS has a single endpoint irrespective of region, though STS in GovCloud and China (Beijing) has its own endpoint.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Region { get; set; }
        #endregion

        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecurityToken.Model.AssumeRoleWithSAMLResponse).
        /// Specifying the name of a property of type Amazon.SecurityToken.Model.AssumeRoleWithSAMLResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("RoleArn", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Use-STSRoleWithSAML (AssumeRoleWithSAML)"))
            {
                return;
            }

            Client = CreateClient();

            var context = new CmdletContext
            {
                Region = this.Region
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);

            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SecurityToken.Model.AssumeRoleWithSAMLResponse, UseSTSRoleWithSAMLCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }

            if (ParameterWasBound("DurationInSeconds"))
                context.DurationInSeconds = this.DurationInSeconds;
            context.Policy = this.Policy;
            context.PrincipalArn = this.PrincipalArn;
            context.RoleArn = this.RoleArn;
            context.SAMLAssertion = this.SAMLAssertion;
            
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
            var client = Client ?? CreateClient();
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = cmdletContext.Select(response, this);
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
        
        private Amazon.SecurityToken.Model.AssumeRoleWithSAMLResponse CallAWSServiceOperation(IAmazonSecurityTokenService client, Amazon.SecurityToken.Model.AssumeRoleWithSAMLRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Security Token Service", "AssumeRoleWithSAML");

            try
            {
#if DESKTOP
                return client.AssumeRoleWithSAML(request);
#elif CORECLR
                return client.AssumeRoleWithSAMLAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? DurationInSeconds { get; set; }
            public System.String Policy { get; set; }
            public System.String PrincipalArn { get; set; }
            public System.String RoleArn { get; set; }
            public System.String SAMLAssertion { get; set; }
            public String Region { get; set; }
            public System.Func<Amazon.SecurityToken.Model.AssumeRoleWithSAMLResponse, UseSTSRoleWithSAMLCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
