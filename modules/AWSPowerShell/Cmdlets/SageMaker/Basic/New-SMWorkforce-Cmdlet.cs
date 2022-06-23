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
using Amazon.SageMaker;
using Amazon.SageMaker.Model;

namespace Amazon.PowerShell.Cmdlets.SM
{
    /// <summary>
    /// Use this operation to create a workforce. This operation will return an error if a
    /// workforce already exists in the Amazon Web Services Region that you specify. You can
    /// only create one workforce in each Amazon Web Services Region per Amazon Web Services
    /// account.
    /// 
    ///  
    /// <para>
    /// If you want to create a new workforce in an Amazon Web Services Region where a workforce
    /// already exists, use the API operation to delete the existing workforce and then use
    /// <code>CreateWorkforce</code> to create a new workforce.
    /// </para><para>
    /// To create a private workforce using Amazon Cognito, you must specify a Cognito user
    /// pool in <code>CognitoConfig</code>. You can also create an Amazon Cognito workforce
    /// using the Amazon SageMaker console. For more information, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/sms-workforce-create-private.html">
    /// Create a Private Workforce (Amazon Cognito)</a>.
    /// </para><para>
    /// To create a private workforce using your own OIDC Identity Provider (IdP), specify
    /// your IdP configuration in <code>OidcConfig</code>. Your OIDC IdP must support <i>groups</i>
    /// because groups are used by Ground Truth and Amazon A2I to create work teams. For more
    /// information, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/sms-workforce-create-private-oidc.html">
    /// Create a Private Workforce (OIDC IdP)</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "SMWorkforce", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service CreateWorkforce API operation.", Operation = new[] {"CreateWorkforce"}, SelectReturnType = typeof(Amazon.SageMaker.Model.CreateWorkforceResponse))]
    [AWSCmdletOutput("System.String or Amazon.SageMaker.Model.CreateWorkforceResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SageMaker.Model.CreateWorkforceResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewSMWorkforceCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        #region Parameter OidcConfig_AuthorizationEndpoint
        /// <summary>
        /// <para>
        /// <para>The OIDC IdP authorization endpoint used to configure your private workforce.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OidcConfig_AuthorizationEndpoint { get; set; }
        #endregion
        
        #region Parameter SourceIpConfig_Cidr
        /// <summary>
        /// <para>
        /// <para>A list of one to ten <a href="https://docs.aws.amazon.com/vpc/latest/userguide/VPC_Subnets.html">Classless
        /// Inter-Domain Routing</a> (CIDR) values.</para><para>Maximum: Ten CIDR values</para><note><para>The following Length Constraints apply to individual CIDR values in the CIDR value
        /// list.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceIpConfig_Cidrs")]
        public System.String[] SourceIpConfig_Cidr { get; set; }
        #endregion
        
        #region Parameter CognitoConfig_ClientId
        /// <summary>
        /// <para>
        /// <para>The client ID for your Amazon Cognito user pool.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CognitoConfig_ClientId { get; set; }
        #endregion
        
        #region Parameter OidcConfig_ClientId
        /// <summary>
        /// <para>
        /// <para>The OIDC IdP client ID used to configure your private workforce.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OidcConfig_ClientId { get; set; }
        #endregion
        
        #region Parameter OidcConfig_ClientSecret
        /// <summary>
        /// <para>
        /// <para>The OIDC IdP client secret used to configure your private workforce.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OidcConfig_ClientSecret { get; set; }
        #endregion
        
        #region Parameter OidcConfig_Issuer
        /// <summary>
        /// <para>
        /// <para>The OIDC IdP issuer used to configure your private workforce.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OidcConfig_Issuer { get; set; }
        #endregion
        
        #region Parameter OidcConfig_JwksUri
        /// <summary>
        /// <para>
        /// <para>The OIDC IdP JSON Web Key Set (Jwks) URI used to configure your private workforce.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OidcConfig_JwksUri { get; set; }
        #endregion
        
        #region Parameter OidcConfig_LogoutEndpoint
        /// <summary>
        /// <para>
        /// <para>The OIDC IdP logout endpoint used to configure your private workforce.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OidcConfig_LogoutEndpoint { get; set; }
        #endregion
        
        #region Parameter WorkforceVpcConfig_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>The VPC security group IDs, in the form sg-xxxxxxxx. The security groups must be for
        /// the same VPC as specified in the subnet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WorkforceVpcConfig_SecurityGroupIds")]
        public System.String[] WorkforceVpcConfig_SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter WorkforceVpcConfig_Subnet
        /// <summary>
        /// <para>
        /// <para>The ID of the subnets in the VPC that you want to connect.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WorkforceVpcConfig_Subnets")]
        public System.String[] WorkforceVpcConfig_Subnet { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>An array of key-value pairs that contain metadata to help you categorize and organize
        /// our workforce. Each tag consists of a key and a value, both of which you define.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.SageMaker.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter OidcConfig_TokenEndpoint
        /// <summary>
        /// <para>
        /// <para>The OIDC IdP token endpoint used to configure your private workforce.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OidcConfig_TokenEndpoint { get; set; }
        #endregion
        
        #region Parameter OidcConfig_UserInfoEndpoint
        /// <summary>
        /// <para>
        /// <para>The OIDC IdP user information endpoint used to configure your private workforce.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OidcConfig_UserInfoEndpoint { get; set; }
        #endregion
        
        #region Parameter CognitoConfig_UserPool
        /// <summary>
        /// <para>
        /// <para>A <a href="https://docs.aws.amazon.com/cognito/latest/developerguide/cognito-user-identity-pools.html">
        /// user pool</a> is a user directory in Amazon Cognito. With a user pool, your users
        /// can sign in to your web or mobile app through Amazon Cognito. Your users can also
        /// sign in through social identity providers like Google, Facebook, Amazon, or Apple,
        /// and through SAML identity providers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CognitoConfig_UserPool { get; set; }
        #endregion
        
        #region Parameter WorkforceVpcConfig_VpcId
        /// <summary>
        /// <para>
        /// <para>The ID of the VPC that the workforce uses for communication.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String WorkforceVpcConfig_VpcId { get; set; }
        #endregion
        
        #region Parameter WorkforceName
        /// <summary>
        /// <para>
        /// <para>The name of the private workforce.</para>
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
        public System.String WorkforceName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'WorkforceArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.CreateWorkforceResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.CreateWorkforceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "WorkforceArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the WorkforceName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^WorkforceName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^WorkforceName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.WorkforceName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SMWorkforce (CreateWorkforce)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.CreateWorkforceResponse, NewSMWorkforceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.WorkforceName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CognitoConfig_ClientId = this.CognitoConfig_ClientId;
            context.CognitoConfig_UserPool = this.CognitoConfig_UserPool;
            context.OidcConfig_AuthorizationEndpoint = this.OidcConfig_AuthorizationEndpoint;
            context.OidcConfig_ClientId = this.OidcConfig_ClientId;
            context.OidcConfig_ClientSecret = this.OidcConfig_ClientSecret;
            context.OidcConfig_Issuer = this.OidcConfig_Issuer;
            context.OidcConfig_JwksUri = this.OidcConfig_JwksUri;
            context.OidcConfig_LogoutEndpoint = this.OidcConfig_LogoutEndpoint;
            context.OidcConfig_TokenEndpoint = this.OidcConfig_TokenEndpoint;
            context.OidcConfig_UserInfoEndpoint = this.OidcConfig_UserInfoEndpoint;
            if (this.SourceIpConfig_Cidr != null)
            {
                context.SourceIpConfig_Cidr = new List<System.String>(this.SourceIpConfig_Cidr);
            }
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.SageMaker.Model.Tag>(this.Tag);
            }
            context.WorkforceName = this.WorkforceName;
            #if MODULAR
            if (this.WorkforceName == null && ParameterWasBound(nameof(this.WorkforceName)))
            {
                WriteWarning("You are passing $null as a value for parameter WorkforceName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.WorkforceVpcConfig_SecurityGroupId != null)
            {
                context.WorkforceVpcConfig_SecurityGroupId = new List<System.String>(this.WorkforceVpcConfig_SecurityGroupId);
            }
            if (this.WorkforceVpcConfig_Subnet != null)
            {
                context.WorkforceVpcConfig_Subnet = new List<System.String>(this.WorkforceVpcConfig_Subnet);
            }
            context.WorkforceVpcConfig_VpcId = this.WorkforceVpcConfig_VpcId;
            
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
            var request = new Amazon.SageMaker.Model.CreateWorkforceRequest();
            
            
             // populate CognitoConfig
            var requestCognitoConfigIsNull = true;
            request.CognitoConfig = new Amazon.SageMaker.Model.CognitoConfig();
            System.String requestCognitoConfig_cognitoConfig_ClientId = null;
            if (cmdletContext.CognitoConfig_ClientId != null)
            {
                requestCognitoConfig_cognitoConfig_ClientId = cmdletContext.CognitoConfig_ClientId;
            }
            if (requestCognitoConfig_cognitoConfig_ClientId != null)
            {
                request.CognitoConfig.ClientId = requestCognitoConfig_cognitoConfig_ClientId;
                requestCognitoConfigIsNull = false;
            }
            System.String requestCognitoConfig_cognitoConfig_UserPool = null;
            if (cmdletContext.CognitoConfig_UserPool != null)
            {
                requestCognitoConfig_cognitoConfig_UserPool = cmdletContext.CognitoConfig_UserPool;
            }
            if (requestCognitoConfig_cognitoConfig_UserPool != null)
            {
                request.CognitoConfig.UserPool = requestCognitoConfig_cognitoConfig_UserPool;
                requestCognitoConfigIsNull = false;
            }
             // determine if request.CognitoConfig should be set to null
            if (requestCognitoConfigIsNull)
            {
                request.CognitoConfig = null;
            }
            
             // populate OidcConfig
            var requestOidcConfigIsNull = true;
            request.OidcConfig = new Amazon.SageMaker.Model.OidcConfig();
            System.String requestOidcConfig_oidcConfig_AuthorizationEndpoint = null;
            if (cmdletContext.OidcConfig_AuthorizationEndpoint != null)
            {
                requestOidcConfig_oidcConfig_AuthorizationEndpoint = cmdletContext.OidcConfig_AuthorizationEndpoint;
            }
            if (requestOidcConfig_oidcConfig_AuthorizationEndpoint != null)
            {
                request.OidcConfig.AuthorizationEndpoint = requestOidcConfig_oidcConfig_AuthorizationEndpoint;
                requestOidcConfigIsNull = false;
            }
            System.String requestOidcConfig_oidcConfig_ClientId = null;
            if (cmdletContext.OidcConfig_ClientId != null)
            {
                requestOidcConfig_oidcConfig_ClientId = cmdletContext.OidcConfig_ClientId;
            }
            if (requestOidcConfig_oidcConfig_ClientId != null)
            {
                request.OidcConfig.ClientId = requestOidcConfig_oidcConfig_ClientId;
                requestOidcConfigIsNull = false;
            }
            System.String requestOidcConfig_oidcConfig_ClientSecret = null;
            if (cmdletContext.OidcConfig_ClientSecret != null)
            {
                requestOidcConfig_oidcConfig_ClientSecret = cmdletContext.OidcConfig_ClientSecret;
            }
            if (requestOidcConfig_oidcConfig_ClientSecret != null)
            {
                request.OidcConfig.ClientSecret = requestOidcConfig_oidcConfig_ClientSecret;
                requestOidcConfigIsNull = false;
            }
            System.String requestOidcConfig_oidcConfig_Issuer = null;
            if (cmdletContext.OidcConfig_Issuer != null)
            {
                requestOidcConfig_oidcConfig_Issuer = cmdletContext.OidcConfig_Issuer;
            }
            if (requestOidcConfig_oidcConfig_Issuer != null)
            {
                request.OidcConfig.Issuer = requestOidcConfig_oidcConfig_Issuer;
                requestOidcConfigIsNull = false;
            }
            System.String requestOidcConfig_oidcConfig_JwksUri = null;
            if (cmdletContext.OidcConfig_JwksUri != null)
            {
                requestOidcConfig_oidcConfig_JwksUri = cmdletContext.OidcConfig_JwksUri;
            }
            if (requestOidcConfig_oidcConfig_JwksUri != null)
            {
                request.OidcConfig.JwksUri = requestOidcConfig_oidcConfig_JwksUri;
                requestOidcConfigIsNull = false;
            }
            System.String requestOidcConfig_oidcConfig_LogoutEndpoint = null;
            if (cmdletContext.OidcConfig_LogoutEndpoint != null)
            {
                requestOidcConfig_oidcConfig_LogoutEndpoint = cmdletContext.OidcConfig_LogoutEndpoint;
            }
            if (requestOidcConfig_oidcConfig_LogoutEndpoint != null)
            {
                request.OidcConfig.LogoutEndpoint = requestOidcConfig_oidcConfig_LogoutEndpoint;
                requestOidcConfigIsNull = false;
            }
            System.String requestOidcConfig_oidcConfig_TokenEndpoint = null;
            if (cmdletContext.OidcConfig_TokenEndpoint != null)
            {
                requestOidcConfig_oidcConfig_TokenEndpoint = cmdletContext.OidcConfig_TokenEndpoint;
            }
            if (requestOidcConfig_oidcConfig_TokenEndpoint != null)
            {
                request.OidcConfig.TokenEndpoint = requestOidcConfig_oidcConfig_TokenEndpoint;
                requestOidcConfigIsNull = false;
            }
            System.String requestOidcConfig_oidcConfig_UserInfoEndpoint = null;
            if (cmdletContext.OidcConfig_UserInfoEndpoint != null)
            {
                requestOidcConfig_oidcConfig_UserInfoEndpoint = cmdletContext.OidcConfig_UserInfoEndpoint;
            }
            if (requestOidcConfig_oidcConfig_UserInfoEndpoint != null)
            {
                request.OidcConfig.UserInfoEndpoint = requestOidcConfig_oidcConfig_UserInfoEndpoint;
                requestOidcConfigIsNull = false;
            }
             // determine if request.OidcConfig should be set to null
            if (requestOidcConfigIsNull)
            {
                request.OidcConfig = null;
            }
            
             // populate SourceIpConfig
            var requestSourceIpConfigIsNull = true;
            request.SourceIpConfig = new Amazon.SageMaker.Model.SourceIpConfig();
            List<System.String> requestSourceIpConfig_sourceIpConfig_Cidr = null;
            if (cmdletContext.SourceIpConfig_Cidr != null)
            {
                requestSourceIpConfig_sourceIpConfig_Cidr = cmdletContext.SourceIpConfig_Cidr;
            }
            if (requestSourceIpConfig_sourceIpConfig_Cidr != null)
            {
                request.SourceIpConfig.Cidrs = requestSourceIpConfig_sourceIpConfig_Cidr;
                requestSourceIpConfigIsNull = false;
            }
             // determine if request.SourceIpConfig should be set to null
            if (requestSourceIpConfigIsNull)
            {
                request.SourceIpConfig = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.WorkforceName != null)
            {
                request.WorkforceName = cmdletContext.WorkforceName;
            }
            
             // populate WorkforceVpcConfig
            var requestWorkforceVpcConfigIsNull = true;
            request.WorkforceVpcConfig = new Amazon.SageMaker.Model.WorkforceVpcConfigRequest();
            List<System.String> requestWorkforceVpcConfig_workforceVpcConfig_SecurityGroupId = null;
            if (cmdletContext.WorkforceVpcConfig_SecurityGroupId != null)
            {
                requestWorkforceVpcConfig_workforceVpcConfig_SecurityGroupId = cmdletContext.WorkforceVpcConfig_SecurityGroupId;
            }
            if (requestWorkforceVpcConfig_workforceVpcConfig_SecurityGroupId != null)
            {
                request.WorkforceVpcConfig.SecurityGroupIds = requestWorkforceVpcConfig_workforceVpcConfig_SecurityGroupId;
                requestWorkforceVpcConfigIsNull = false;
            }
            List<System.String> requestWorkforceVpcConfig_workforceVpcConfig_Subnet = null;
            if (cmdletContext.WorkforceVpcConfig_Subnet != null)
            {
                requestWorkforceVpcConfig_workforceVpcConfig_Subnet = cmdletContext.WorkforceVpcConfig_Subnet;
            }
            if (requestWorkforceVpcConfig_workforceVpcConfig_Subnet != null)
            {
                request.WorkforceVpcConfig.Subnets = requestWorkforceVpcConfig_workforceVpcConfig_Subnet;
                requestWorkforceVpcConfigIsNull = false;
            }
            System.String requestWorkforceVpcConfig_workforceVpcConfig_VpcId = null;
            if (cmdletContext.WorkforceVpcConfig_VpcId != null)
            {
                requestWorkforceVpcConfig_workforceVpcConfig_VpcId = cmdletContext.WorkforceVpcConfig_VpcId;
            }
            if (requestWorkforceVpcConfig_workforceVpcConfig_VpcId != null)
            {
                request.WorkforceVpcConfig.VpcId = requestWorkforceVpcConfig_workforceVpcConfig_VpcId;
                requestWorkforceVpcConfigIsNull = false;
            }
             // determine if request.WorkforceVpcConfig should be set to null
            if (requestWorkforceVpcConfigIsNull)
            {
                request.WorkforceVpcConfig = null;
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
        
        private Amazon.SageMaker.Model.CreateWorkforceResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.CreateWorkforceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "CreateWorkforce");
            try
            {
                #if DESKTOP
                return client.CreateWorkforce(request);
                #elif CORECLR
                return client.CreateWorkforceAsync(request).GetAwaiter().GetResult();
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
            public System.String CognitoConfig_ClientId { get; set; }
            public System.String CognitoConfig_UserPool { get; set; }
            public System.String OidcConfig_AuthorizationEndpoint { get; set; }
            public System.String OidcConfig_ClientId { get; set; }
            public System.String OidcConfig_ClientSecret { get; set; }
            public System.String OidcConfig_Issuer { get; set; }
            public System.String OidcConfig_JwksUri { get; set; }
            public System.String OidcConfig_LogoutEndpoint { get; set; }
            public System.String OidcConfig_TokenEndpoint { get; set; }
            public System.String OidcConfig_UserInfoEndpoint { get; set; }
            public List<System.String> SourceIpConfig_Cidr { get; set; }
            public List<Amazon.SageMaker.Model.Tag> Tag { get; set; }
            public System.String WorkforceName { get; set; }
            public List<System.String> WorkforceVpcConfig_SecurityGroupId { get; set; }
            public List<System.String> WorkforceVpcConfig_Subnet { get; set; }
            public System.String WorkforceVpcConfig_VpcId { get; set; }
            public System.Func<Amazon.SageMaker.Model.CreateWorkforceResponse, NewSMWorkforceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.WorkforceArn;
        }
        
    }
}
