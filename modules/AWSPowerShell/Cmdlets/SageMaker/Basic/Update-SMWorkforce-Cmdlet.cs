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
    /// Use this operation to update your workforce. You can use this operation to require
    /// that workers use specific IP addresses to work on tasks and to update your OpenID
    /// Connect (OIDC) Identity Provider (IdP) workforce configuration.
    /// 
    ///  
    /// <para>
    /// The worker portal is now supported in VPC and public internet.
    /// </para><para>
    ///  Use <c>SourceIpConfig</c> to restrict worker access to tasks to a specific range
    /// of IP addresses. You specify allowed IP addresses by creating a list of up to ten
    /// <a href="https://docs.aws.amazon.com/vpc/latest/userguide/VPC_Subnets.html">CIDRs</a>.
    /// By default, a workforce isn't restricted to specific IP addresses. If you specify
    /// a range of IP addresses, workers who attempt to access tasks using any IP address
    /// outside the specified range are denied and get a <c>Not Found</c> error message on
    /// the worker portal.
    /// </para><para>
    /// To restrict access to all the workers in public internet, add the <c>SourceIpConfig</c>
    /// CIDR value as "10.0.0.0/16".
    /// </para><important><para>
    /// Amazon SageMaker does not support Source Ip restriction for worker portals in VPC.
    /// </para></important><para>
    /// Use <c>OidcConfig</c> to update the configuration of a workforce created using your
    /// own OIDC IdP. 
    /// </para><important><para>
    /// You can only update your OIDC IdP configuration when there are no work teams associated
    /// with your workforce. You can delete work teams using the <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_DeleteWorkteam.html">DeleteWorkteam</a>
    /// operation.
    /// </para></important><para>
    /// After restricting access to a range of IP addresses or updating your OIDC IdP configuration
    /// with this operation, you can view details about your update workforce using the <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_DescribeWorkforce.html">DescribeWorkforce</a>
    /// operation.
    /// </para><important><para>
    /// This operation only applies to private workforces.
    /// </para></important>
    /// </summary>
    [Cmdlet("Update", "SMWorkforce", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SageMaker.Model.Workforce")]
    [AWSCmdlet("Calls the Amazon SageMaker Service UpdateWorkforce API operation.", Operation = new[] {"UpdateWorkforce"}, SelectReturnType = typeof(Amazon.SageMaker.Model.UpdateWorkforceResponse))]
    [AWSCmdletOutput("Amazon.SageMaker.Model.Workforce or Amazon.SageMaker.Model.UpdateWorkforceResponse",
        "This cmdlet returns an Amazon.SageMaker.Model.Workforce object.",
        "The service call response (type Amazon.SageMaker.Model.UpdateWorkforceResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateSMWorkforceCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter OidcConfig_AuthenticationRequestExtraParam
        /// <summary>
        /// <para>
        /// <para>A string to string map of identifiers specific to the custom identity provider (IdP)
        /// being used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OidcConfig_AuthenticationRequestExtraParams")]
        public System.Collections.Hashtable OidcConfig_AuthenticationRequestExtraParam { get; set; }
        #endregion
        
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
        
        #region Parameter OidcConfig_Scope
        /// <summary>
        /// <para>
        /// <para>An array of string identifiers used to refer to the specific pieces of user data or
        /// claims that the client application wants to access.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OidcConfig_Scope { get; set; }
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
        /// <para>The name of the private workforce that you want to update. You can find your workforce
        /// name by using the <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_ListWorkforces.html">ListWorkforces</a>
        /// operation.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Workforce'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.UpdateWorkforceResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.UpdateWorkforceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Workforce";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.WorkforceName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SMWorkforce (UpdateWorkforce)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.UpdateWorkforceResponse, UpdateSMWorkforceCmdlet>(Select) ??
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
            if (this.OidcConfig_AuthenticationRequestExtraParam != null)
            {
                context.OidcConfig_AuthenticationRequestExtraParam = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.OidcConfig_AuthenticationRequestExtraParam.Keys)
                {
                    context.OidcConfig_AuthenticationRequestExtraParam.Add((String)hashKey, (System.String)(this.OidcConfig_AuthenticationRequestExtraParam[hashKey]));
                }
            }
            context.OidcConfig_AuthorizationEndpoint = this.OidcConfig_AuthorizationEndpoint;
            context.OidcConfig_ClientId = this.OidcConfig_ClientId;
            context.OidcConfig_ClientSecret = this.OidcConfig_ClientSecret;
            context.OidcConfig_Issuer = this.OidcConfig_Issuer;
            context.OidcConfig_JwksUri = this.OidcConfig_JwksUri;
            context.OidcConfig_LogoutEndpoint = this.OidcConfig_LogoutEndpoint;
            context.OidcConfig_Scope = this.OidcConfig_Scope;
            context.OidcConfig_TokenEndpoint = this.OidcConfig_TokenEndpoint;
            context.OidcConfig_UserInfoEndpoint = this.OidcConfig_UserInfoEndpoint;
            if (this.SourceIpConfig_Cidr != null)
            {
                context.SourceIpConfig_Cidr = new List<System.String>(this.SourceIpConfig_Cidr);
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
            var request = new Amazon.SageMaker.Model.UpdateWorkforceRequest();
            
            
             // populate OidcConfig
            var requestOidcConfigIsNull = true;
            request.OidcConfig = new Amazon.SageMaker.Model.OidcConfig();
            Dictionary<System.String, System.String> requestOidcConfig_oidcConfig_AuthenticationRequestExtraParam = null;
            if (cmdletContext.OidcConfig_AuthenticationRequestExtraParam != null)
            {
                requestOidcConfig_oidcConfig_AuthenticationRequestExtraParam = cmdletContext.OidcConfig_AuthenticationRequestExtraParam;
            }
            if (requestOidcConfig_oidcConfig_AuthenticationRequestExtraParam != null)
            {
                request.OidcConfig.AuthenticationRequestExtraParams = requestOidcConfig_oidcConfig_AuthenticationRequestExtraParam;
                requestOidcConfigIsNull = false;
            }
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
            System.String requestOidcConfig_oidcConfig_Scope = null;
            if (cmdletContext.OidcConfig_Scope != null)
            {
                requestOidcConfig_oidcConfig_Scope = cmdletContext.OidcConfig_Scope;
            }
            if (requestOidcConfig_oidcConfig_Scope != null)
            {
                request.OidcConfig.Scope = requestOidcConfig_oidcConfig_Scope;
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
        
        private Amazon.SageMaker.Model.UpdateWorkforceResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.UpdateWorkforceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "UpdateWorkforce");
            try
            {
                #if DESKTOP
                return client.UpdateWorkforce(request);
                #elif CORECLR
                return client.UpdateWorkforceAsync(request).GetAwaiter().GetResult();
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
            public Dictionary<System.String, System.String> OidcConfig_AuthenticationRequestExtraParam { get; set; }
            public System.String OidcConfig_AuthorizationEndpoint { get; set; }
            public System.String OidcConfig_ClientId { get; set; }
            public System.String OidcConfig_ClientSecret { get; set; }
            public System.String OidcConfig_Issuer { get; set; }
            public System.String OidcConfig_JwksUri { get; set; }
            public System.String OidcConfig_LogoutEndpoint { get; set; }
            public System.String OidcConfig_Scope { get; set; }
            public System.String OidcConfig_TokenEndpoint { get; set; }
            public System.String OidcConfig_UserInfoEndpoint { get; set; }
            public List<System.String> SourceIpConfig_Cidr { get; set; }
            public System.String WorkforceName { get; set; }
            public List<System.String> WorkforceVpcConfig_SecurityGroupId { get; set; }
            public List<System.String> WorkforceVpcConfig_Subnet { get; set; }
            public System.String WorkforceVpcConfig_VpcId { get; set; }
            public System.Func<Amazon.SageMaker.Model.UpdateWorkforceResponse, UpdateSMWorkforceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Workforce;
        }
        
    }
}
