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
using Amazon.QBusiness;
using Amazon.QBusiness.Model;

namespace Amazon.PowerShell.Cmdlets.QBUS
{
    /// <summary>
    /// Updates an existing data accessor. This operation allows modifying the action configurations
    /// (the allowed actions and associated filters) and the display name of the data accessor.
    /// It does not allow changing the IAM role associated with the data accessor or other
    /// core properties of the data accessor.
    /// </summary>
    [Cmdlet("Update", "QBUSDataAccessor", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon QBusiness UpdateDataAccessor API operation.", Operation = new[] {"UpdateDataAccessor"}, SelectReturnType = typeof(Amazon.QBusiness.Model.UpdateDataAccessorResponse))]
    [AWSCmdletOutput("None or Amazon.QBusiness.Model.UpdateDataAccessorResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.QBusiness.Model.UpdateDataAccessorResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateQBUSDataAccessorCmdlet : AmazonQBusinessClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ActionConfiguration
        /// <summary>
        /// <para>
        /// <para>The updated list of action configurations specifying the allowed actions and any associated
        /// filters.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("ActionConfigurations")]
        public Amazon.QBusiness.Model.ActionConfiguration[] ActionConfiguration { get; set; }
        #endregion
        
        #region Parameter ApplicationId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the Amazon Q Business application.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ApplicationId { get; set; }
        #endregion
        
        #region Parameter AuthenticationDetail_AuthenticationType
        /// <summary>
        /// <para>
        /// <para>The type of authentication to use for the data accessor. This determines how the ISV
        /// authenticates when accessing data. You can use one of two authentication types:</para><ul><li><para><c>AWS_IAM_IDC_TTI</c> - Authentication using IAM Identity Center Trusted Token Issuer
        /// (TTI). This authentication type allows the ISV to use a trusted token issuer to generate
        /// tokens for accessing the data.</para></li><li><para><c>AWS_IAM_IDC_AUTH_CODE</c> - Authentication using IAM Identity Center authorization
        /// code flow. This authentication type uses the standard OAuth 2.0 authorization code
        /// flow for authentication.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QBusiness.DataAccessorAuthenticationType")]
        public Amazon.QBusiness.DataAccessorAuthenticationType AuthenticationDetail_AuthenticationType { get; set; }
        #endregion
        
        #region Parameter DataAccessorId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the data accessor to update.</para>
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
        public System.String DataAccessorId { get; set; }
        #endregion
        
        #region Parameter DisplayName
        /// <summary>
        /// <para>
        /// <para>The updated friendly name for the data accessor.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DisplayName { get; set; }
        #endregion
        
        #region Parameter AuthenticationDetail_ExternalId
        /// <summary>
        /// <para>
        /// <para>A list of external identifiers associated with this authentication configuration.
        /// These are used to correlate the data accessor with external systems.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthenticationDetail_ExternalIds")]
        public System.String[] AuthenticationDetail_ExternalId { get; set; }
        #endregion
        
        #region Parameter IdcTrustedTokenIssuerConfiguration_IdcTrustedTokenIssuerArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM Identity Center Trusted Token Issuer that
        /// will be used for authentication.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthenticationDetail_AuthenticationConfiguration_IdcTrustedTokenIssuerConfiguration_IdcTrustedTokenIssuerArn")]
        public System.String IdcTrustedTokenIssuerConfiguration_IdcTrustedTokenIssuerArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QBusiness.Model.UpdateDataAccessorResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DataAccessorId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DataAccessorId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DataAccessorId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DataAccessorId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-QBUSDataAccessor (UpdateDataAccessor)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QBusiness.Model.UpdateDataAccessorResponse, UpdateQBUSDataAccessorCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DataAccessorId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.ActionConfiguration != null)
            {
                context.ActionConfiguration = new List<Amazon.QBusiness.Model.ActionConfiguration>(this.ActionConfiguration);
            }
            #if MODULAR
            if (this.ActionConfiguration == null && ParameterWasBound(nameof(this.ActionConfiguration)))
            {
                WriteWarning("You are passing $null as a value for parameter ActionConfiguration which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ApplicationId = this.ApplicationId;
            #if MODULAR
            if (this.ApplicationId == null && ParameterWasBound(nameof(this.ApplicationId)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplicationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IdcTrustedTokenIssuerConfiguration_IdcTrustedTokenIssuerArn = this.IdcTrustedTokenIssuerConfiguration_IdcTrustedTokenIssuerArn;
            context.AuthenticationDetail_AuthenticationType = this.AuthenticationDetail_AuthenticationType;
            if (this.AuthenticationDetail_ExternalId != null)
            {
                context.AuthenticationDetail_ExternalId = new List<System.String>(this.AuthenticationDetail_ExternalId);
            }
            context.DataAccessorId = this.DataAccessorId;
            #if MODULAR
            if (this.DataAccessorId == null && ParameterWasBound(nameof(this.DataAccessorId)))
            {
                WriteWarning("You are passing $null as a value for parameter DataAccessorId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DisplayName = this.DisplayName;
            
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
            var request = new Amazon.QBusiness.Model.UpdateDataAccessorRequest();
            
            if (cmdletContext.ActionConfiguration != null)
            {
                request.ActionConfigurations = cmdletContext.ActionConfiguration;
            }
            if (cmdletContext.ApplicationId != null)
            {
                request.ApplicationId = cmdletContext.ApplicationId;
            }
            
             // populate AuthenticationDetail
            var requestAuthenticationDetailIsNull = true;
            request.AuthenticationDetail = new Amazon.QBusiness.Model.DataAccessorAuthenticationDetail();
            Amazon.QBusiness.DataAccessorAuthenticationType requestAuthenticationDetail_authenticationDetail_AuthenticationType = null;
            if (cmdletContext.AuthenticationDetail_AuthenticationType != null)
            {
                requestAuthenticationDetail_authenticationDetail_AuthenticationType = cmdletContext.AuthenticationDetail_AuthenticationType;
            }
            if (requestAuthenticationDetail_authenticationDetail_AuthenticationType != null)
            {
                request.AuthenticationDetail.AuthenticationType = requestAuthenticationDetail_authenticationDetail_AuthenticationType;
                requestAuthenticationDetailIsNull = false;
            }
            List<System.String> requestAuthenticationDetail_authenticationDetail_ExternalId = null;
            if (cmdletContext.AuthenticationDetail_ExternalId != null)
            {
                requestAuthenticationDetail_authenticationDetail_ExternalId = cmdletContext.AuthenticationDetail_ExternalId;
            }
            if (requestAuthenticationDetail_authenticationDetail_ExternalId != null)
            {
                request.AuthenticationDetail.ExternalIds = requestAuthenticationDetail_authenticationDetail_ExternalId;
                requestAuthenticationDetailIsNull = false;
            }
            Amazon.QBusiness.Model.DataAccessorAuthenticationConfiguration requestAuthenticationDetail_authenticationDetail_AuthenticationConfiguration = null;
            
             // populate AuthenticationConfiguration
            var requestAuthenticationDetail_authenticationDetail_AuthenticationConfigurationIsNull = true;
            requestAuthenticationDetail_authenticationDetail_AuthenticationConfiguration = new Amazon.QBusiness.Model.DataAccessorAuthenticationConfiguration();
            Amazon.QBusiness.Model.DataAccessorIdcTrustedTokenIssuerConfiguration requestAuthenticationDetail_authenticationDetail_AuthenticationConfiguration_authenticationDetail_AuthenticationConfiguration_IdcTrustedTokenIssuerConfiguration = null;
            
             // populate IdcTrustedTokenIssuerConfiguration
            var requestAuthenticationDetail_authenticationDetail_AuthenticationConfiguration_authenticationDetail_AuthenticationConfiguration_IdcTrustedTokenIssuerConfigurationIsNull = true;
            requestAuthenticationDetail_authenticationDetail_AuthenticationConfiguration_authenticationDetail_AuthenticationConfiguration_IdcTrustedTokenIssuerConfiguration = new Amazon.QBusiness.Model.DataAccessorIdcTrustedTokenIssuerConfiguration();
            System.String requestAuthenticationDetail_authenticationDetail_AuthenticationConfiguration_authenticationDetail_AuthenticationConfiguration_IdcTrustedTokenIssuerConfiguration_idcTrustedTokenIssuerConfiguration_IdcTrustedTokenIssuerArn = null;
            if (cmdletContext.IdcTrustedTokenIssuerConfiguration_IdcTrustedTokenIssuerArn != null)
            {
                requestAuthenticationDetail_authenticationDetail_AuthenticationConfiguration_authenticationDetail_AuthenticationConfiguration_IdcTrustedTokenIssuerConfiguration_idcTrustedTokenIssuerConfiguration_IdcTrustedTokenIssuerArn = cmdletContext.IdcTrustedTokenIssuerConfiguration_IdcTrustedTokenIssuerArn;
            }
            if (requestAuthenticationDetail_authenticationDetail_AuthenticationConfiguration_authenticationDetail_AuthenticationConfiguration_IdcTrustedTokenIssuerConfiguration_idcTrustedTokenIssuerConfiguration_IdcTrustedTokenIssuerArn != null)
            {
                requestAuthenticationDetail_authenticationDetail_AuthenticationConfiguration_authenticationDetail_AuthenticationConfiguration_IdcTrustedTokenIssuerConfiguration.IdcTrustedTokenIssuerArn = requestAuthenticationDetail_authenticationDetail_AuthenticationConfiguration_authenticationDetail_AuthenticationConfiguration_IdcTrustedTokenIssuerConfiguration_idcTrustedTokenIssuerConfiguration_IdcTrustedTokenIssuerArn;
                requestAuthenticationDetail_authenticationDetail_AuthenticationConfiguration_authenticationDetail_AuthenticationConfiguration_IdcTrustedTokenIssuerConfigurationIsNull = false;
            }
             // determine if requestAuthenticationDetail_authenticationDetail_AuthenticationConfiguration_authenticationDetail_AuthenticationConfiguration_IdcTrustedTokenIssuerConfiguration should be set to null
            if (requestAuthenticationDetail_authenticationDetail_AuthenticationConfiguration_authenticationDetail_AuthenticationConfiguration_IdcTrustedTokenIssuerConfigurationIsNull)
            {
                requestAuthenticationDetail_authenticationDetail_AuthenticationConfiguration_authenticationDetail_AuthenticationConfiguration_IdcTrustedTokenIssuerConfiguration = null;
            }
            if (requestAuthenticationDetail_authenticationDetail_AuthenticationConfiguration_authenticationDetail_AuthenticationConfiguration_IdcTrustedTokenIssuerConfiguration != null)
            {
                requestAuthenticationDetail_authenticationDetail_AuthenticationConfiguration.IdcTrustedTokenIssuerConfiguration = requestAuthenticationDetail_authenticationDetail_AuthenticationConfiguration_authenticationDetail_AuthenticationConfiguration_IdcTrustedTokenIssuerConfiguration;
                requestAuthenticationDetail_authenticationDetail_AuthenticationConfigurationIsNull = false;
            }
             // determine if requestAuthenticationDetail_authenticationDetail_AuthenticationConfiguration should be set to null
            if (requestAuthenticationDetail_authenticationDetail_AuthenticationConfigurationIsNull)
            {
                requestAuthenticationDetail_authenticationDetail_AuthenticationConfiguration = null;
            }
            if (requestAuthenticationDetail_authenticationDetail_AuthenticationConfiguration != null)
            {
                request.AuthenticationDetail.AuthenticationConfiguration = requestAuthenticationDetail_authenticationDetail_AuthenticationConfiguration;
                requestAuthenticationDetailIsNull = false;
            }
             // determine if request.AuthenticationDetail should be set to null
            if (requestAuthenticationDetailIsNull)
            {
                request.AuthenticationDetail = null;
            }
            if (cmdletContext.DataAccessorId != null)
            {
                request.DataAccessorId = cmdletContext.DataAccessorId;
            }
            if (cmdletContext.DisplayName != null)
            {
                request.DisplayName = cmdletContext.DisplayName;
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
        
        private Amazon.QBusiness.Model.UpdateDataAccessorResponse CallAWSServiceOperation(IAmazonQBusiness client, Amazon.QBusiness.Model.UpdateDataAccessorRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon QBusiness", "UpdateDataAccessor");
            try
            {
                #if DESKTOP
                return client.UpdateDataAccessor(request);
                #elif CORECLR
                return client.UpdateDataAccessorAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.QBusiness.Model.ActionConfiguration> ActionConfiguration { get; set; }
            public System.String ApplicationId { get; set; }
            public System.String IdcTrustedTokenIssuerConfiguration_IdcTrustedTokenIssuerArn { get; set; }
            public Amazon.QBusiness.DataAccessorAuthenticationType AuthenticationDetail_AuthenticationType { get; set; }
            public List<System.String> AuthenticationDetail_ExternalId { get; set; }
            public System.String DataAccessorId { get; set; }
            public System.String DisplayName { get; set; }
            public System.Func<Amazon.QBusiness.Model.UpdateDataAccessorResponse, UpdateQBUSDataAccessorCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
