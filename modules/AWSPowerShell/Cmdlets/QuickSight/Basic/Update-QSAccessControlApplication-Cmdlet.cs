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
using System.Threading;
using Amazon.QuickSight;
using Amazon.QuickSight.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.QS
{
    /// <summary>
    /// Updates an access control application. You can change its name, description, status,
    /// IdP settings such as the client ID and issuer URL, and its Quick Sight authentication
    /// settings such as redirect URIs.
    /// 
    ///  
    /// <para>
    /// You can't change the <c>IdpAuthorizingType</c>, the <c>QuickAuthenticationType</c>,
    /// or the trusted token issuer after the application is created. To manage client secrets,
    /// use <c>CreateAccessControlApplicationSecret</c>, <c>UpdateAccessControlApplicationSecret</c>,
    /// and <c>DeleteAccessControlApplicationSecret</c>.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "QSAccessControlApplication", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.QuickSight.Model.UpdateAccessControlApplicationResponse")]
    [AWSCmdlet("Calls the Amazon QuickSight UpdateAccessControlApplication API operation.", Operation = new[] {"UpdateAccessControlApplication"}, SelectReturnType = typeof(Amazon.QuickSight.Model.UpdateAccessControlApplicationResponse))]
    [AWSCmdletOutput("Amazon.QuickSight.Model.UpdateAccessControlApplicationResponse",
        "This cmdlet returns an Amazon.QuickSight.Model.UpdateAccessControlApplicationResponse object containing multiple properties."
    )]
    public partial class UpdateQSAccessControlApplicationCmdlet : AmazonQuickSightClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ApplicationId
        /// <summary>
        /// <para>
        /// <para>The ID of the access control application.</para>
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
        
        #region Parameter AwsAccountId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Web Services account that contains the Quick Sight account.</para>
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
        public System.String AwsAccountId { get; set; }
        #endregion
        
        #region Parameter IdpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpConfidentialAuthCode_ClientId
        /// <summary>
        /// <para>
        /// <para>The OAuth 2.0 client ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IdpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpConfidentialAuthCode_ClientId { get; set; }
        #endregion
        
        #region Parameter IdpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpPublicAuthCode_ClientId
        /// <summary>
        /// <para>
        /// <para>The OAuth 2.0 client ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IdpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpPublicAuthCode_ClientId { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The new description of the access control application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter IdpAuthorizingConfiguration_IdcTrustedTokenIssuerConfiguration_IdcTrustedTokenIssuerArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the trusted token issuer in IAM Identity Center.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IdpAuthorizingConfiguration_IdcTrustedTokenIssuerConfiguration_IdcTrustedTokenIssuerArn { get; set; }
        #endregion
        
        #region Parameter IdpAuthorizingConfiguration_IdpAuthorizingType
        /// <summary>
        /// <para>
        /// <para>How users of the access control application are authenticated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.IdpAuthorizingType")]
        public Amazon.QuickSight.IdpAuthorizingType IdpAuthorizingConfiguration_IdpAuthorizingType { get; set; }
        #endregion
        
        #region Parameter IdpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpConfidentialAuthCode_IssuerUrl
        /// <summary>
        /// <para>
        /// <para>The issuer URL of the external OpenID Connect IdP.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IdpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpConfidentialAuthCode_IssuerUrl { get; set; }
        #endregion
        
        #region Parameter IdpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpPublicAuthCode_IssuerUrl
        /// <summary>
        /// <para>
        /// <para>The issuer URL of the external OpenID Connect IdP.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IdpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpPublicAuthCode_IssuerUrl { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The new name of the access control application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter QuickAuthenticationConfiguration_QuickAuthenticationType
        /// <summary>
        /// <para>
        /// <para>How the external client authenticates to Quick Sight.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.QuickAuthenticationType")]
        public Amazon.QuickSight.QuickAuthenticationType QuickAuthenticationConfiguration_QuickAuthenticationType { get; set; }
        #endregion
        
        #region Parameter QuickAuthenticationConfiguration_QuickAuthenticationConfigurationDetailInput_QuickManagedPublicAuthCode_RedirectUris
        /// <summary>
        /// <para>
        /// <para>The OAuth 2.0 redirect URIs of the client.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] QuickAuthenticationConfiguration_QuickAuthenticationConfigurationDetailInput_QuickManagedPublicAuthCode_RedirectUris { get; set; }
        #endregion
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>The new status of the access control application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.AccessControlApplicationStatus")]
        public Amazon.QuickSight.AccessControlApplicationStatus Status { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QuickSight.Model.UpdateAccessControlApplicationResponse).
        /// Specifying the name of a property of type Amazon.QuickSight.Model.UpdateAccessControlApplicationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var targetParameterNames = new string[]
            {
                nameof(this.ApplicationId),
                nameof(this.AwsAccountId)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-QSAccessControlApplication (UpdateAccessControlApplication)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QuickSight.Model.UpdateAccessControlApplicationResponse, UpdateQSAccessControlApplicationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApplicationId = this.ApplicationId;
            #if MODULAR
            if (this.ApplicationId == null && ParameterWasBound(nameof(this.ApplicationId)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplicationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AwsAccountId = this.AwsAccountId;
            #if MODULAR
            if (this.AwsAccountId == null && ParameterWasBound(nameof(this.AwsAccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AwsAccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            context.IdpAuthorizingConfiguration_IdcTrustedTokenIssuerConfiguration_IdcTrustedTokenIssuerArn = this.IdpAuthorizingConfiguration_IdcTrustedTokenIssuerConfiguration_IdcTrustedTokenIssuerArn;
            context.IdpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpConfidentialAuthCode_ClientId = this.IdpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpConfidentialAuthCode_ClientId;
            context.IdpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpConfidentialAuthCode_IssuerUrl = this.IdpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpConfidentialAuthCode_IssuerUrl;
            context.IdpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpPublicAuthCode_ClientId = this.IdpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpPublicAuthCode_ClientId;
            context.IdpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpPublicAuthCode_IssuerUrl = this.IdpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpPublicAuthCode_IssuerUrl;
            context.IdpAuthorizingConfiguration_IdpAuthorizingType = this.IdpAuthorizingConfiguration_IdpAuthorizingType;
            context.Name = this.Name;
            if (this.QuickAuthenticationConfiguration_QuickAuthenticationConfigurationDetailInput_QuickManagedPublicAuthCode_RedirectUris != null)
            {
                context.QuickAuthenticationConfiguration_QuickAuthenticationConfigurationDetailInput_QuickManagedPublicAuthCode_RedirectUris = new List<System.String>(this.QuickAuthenticationConfiguration_QuickAuthenticationConfigurationDetailInput_QuickManagedPublicAuthCode_RedirectUris);
            }
            context.QuickAuthenticationConfiguration_QuickAuthenticationType = this.QuickAuthenticationConfiguration_QuickAuthenticationType;
            context.Status = this.Status;
            
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
            var request = new Amazon.QuickSight.Model.UpdateAccessControlApplicationRequest();
            
            if (cmdletContext.ApplicationId != null)
            {
                request.ApplicationId = cmdletContext.ApplicationId;
            }
            if (cmdletContext.AwsAccountId != null)
            {
                request.AwsAccountId = cmdletContext.AwsAccountId;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            
             // populate IdpAuthorizingConfiguration
            var requestIdpAuthorizingConfigurationIsNull = true;
            request.IdpAuthorizingConfiguration = new Amazon.QuickSight.Model.IdpAuthorizingConfigUpdateInput();
            Amazon.QuickSight.IdpAuthorizingType requestIdpAuthorizingConfiguration_idpAuthorizingConfiguration_IdpAuthorizingType = null;
            if (cmdletContext.IdpAuthorizingConfiguration_IdpAuthorizingType != null)
            {
                requestIdpAuthorizingConfiguration_idpAuthorizingConfiguration_IdpAuthorizingType = cmdletContext.IdpAuthorizingConfiguration_IdpAuthorizingType;
            }
            if (requestIdpAuthorizingConfiguration_idpAuthorizingConfiguration_IdpAuthorizingType != null)
            {
                request.IdpAuthorizingConfiguration.IdpAuthorizingType = requestIdpAuthorizingConfiguration_idpAuthorizingConfiguration_IdpAuthorizingType;
                requestIdpAuthorizingConfigurationIsNull = false;
            }
            Amazon.QuickSight.Model.IdcTrustedTokenIssuerConfig requestIdpAuthorizingConfiguration_idpAuthorizingConfiguration_IdcTrustedTokenIssuerConfiguration = null;
            
             // populate IdcTrustedTokenIssuerConfiguration
            var requestIdpAuthorizingConfiguration_idpAuthorizingConfiguration_IdcTrustedTokenIssuerConfigurationIsNull = true;
            requestIdpAuthorizingConfiguration_idpAuthorizingConfiguration_IdcTrustedTokenIssuerConfiguration = new Amazon.QuickSight.Model.IdcTrustedTokenIssuerConfig();
            System.String requestIdpAuthorizingConfiguration_idpAuthorizingConfiguration_IdcTrustedTokenIssuerConfiguration_idpAuthorizingConfiguration_IdcTrustedTokenIssuerConfiguration_IdcTrustedTokenIssuerArn = null;
            if (cmdletContext.IdpAuthorizingConfiguration_IdcTrustedTokenIssuerConfiguration_IdcTrustedTokenIssuerArn != null)
            {
                requestIdpAuthorizingConfiguration_idpAuthorizingConfiguration_IdcTrustedTokenIssuerConfiguration_idpAuthorizingConfiguration_IdcTrustedTokenIssuerConfiguration_IdcTrustedTokenIssuerArn = cmdletContext.IdpAuthorizingConfiguration_IdcTrustedTokenIssuerConfiguration_IdcTrustedTokenIssuerArn;
            }
            if (requestIdpAuthorizingConfiguration_idpAuthorizingConfiguration_IdcTrustedTokenIssuerConfiguration_idpAuthorizingConfiguration_IdcTrustedTokenIssuerConfiguration_IdcTrustedTokenIssuerArn != null)
            {
                requestIdpAuthorizingConfiguration_idpAuthorizingConfiguration_IdcTrustedTokenIssuerConfiguration.IdcTrustedTokenIssuerArn = requestIdpAuthorizingConfiguration_idpAuthorizingConfiguration_IdcTrustedTokenIssuerConfiguration_idpAuthorizingConfiguration_IdcTrustedTokenIssuerConfiguration_IdcTrustedTokenIssuerArn;
                requestIdpAuthorizingConfiguration_idpAuthorizingConfiguration_IdcTrustedTokenIssuerConfigurationIsNull = false;
            }
             // determine if requestIdpAuthorizingConfiguration_idpAuthorizingConfiguration_IdcTrustedTokenIssuerConfiguration should be set to null
            if (requestIdpAuthorizingConfiguration_idpAuthorizingConfiguration_IdcTrustedTokenIssuerConfigurationIsNull)
            {
                requestIdpAuthorizingConfiguration_idpAuthorizingConfiguration_IdcTrustedTokenIssuerConfiguration = null;
            }
            if (requestIdpAuthorizingConfiguration_idpAuthorizingConfiguration_IdcTrustedTokenIssuerConfiguration != null)
            {
                request.IdpAuthorizingConfiguration.IdcTrustedTokenIssuerConfiguration = requestIdpAuthorizingConfiguration_idpAuthorizingConfiguration_IdcTrustedTokenIssuerConfiguration;
                requestIdpAuthorizingConfigurationIsNull = false;
            }
            Amazon.QuickSight.Model.IdpAuthorizingConfigurationDetailUpdateInput requestIdpAuthorizingConfiguration_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput = null;
            
             // populate IdpAuthorizingConfigurationDetailInput
            var requestIdpAuthorizingConfiguration_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInputIsNull = true;
            requestIdpAuthorizingConfiguration_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput = new Amazon.QuickSight.Model.IdpAuthorizingConfigurationDetailUpdateInput();
            Amazon.QuickSight.Model.ExternalIdpConfidentialAuthCodeAuthorizingConfigUpdateInput requestIdpAuthorizingConfiguration_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpConfidentialAuthCode = null;
            
             // populate ExternalIdpConfidentialAuthCode
            var requestIdpAuthorizingConfiguration_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpConfidentialAuthCodeIsNull = true;
            requestIdpAuthorizingConfiguration_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpConfidentialAuthCode = new Amazon.QuickSight.Model.ExternalIdpConfidentialAuthCodeAuthorizingConfigUpdateInput();
            System.String requestIdpAuthorizingConfiguration_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpConfidentialAuthCode_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpConfidentialAuthCode_ClientId = null;
            if (cmdletContext.IdpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpConfidentialAuthCode_ClientId != null)
            {
                requestIdpAuthorizingConfiguration_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpConfidentialAuthCode_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpConfidentialAuthCode_ClientId = cmdletContext.IdpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpConfidentialAuthCode_ClientId;
            }
            if (requestIdpAuthorizingConfiguration_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpConfidentialAuthCode_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpConfidentialAuthCode_ClientId != null)
            {
                requestIdpAuthorizingConfiguration_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpConfidentialAuthCode.ClientId = requestIdpAuthorizingConfiguration_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpConfidentialAuthCode_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpConfidentialAuthCode_ClientId;
                requestIdpAuthorizingConfiguration_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpConfidentialAuthCodeIsNull = false;
            }
            System.String requestIdpAuthorizingConfiguration_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpConfidentialAuthCode_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpConfidentialAuthCode_IssuerUrl = null;
            if (cmdletContext.IdpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpConfidentialAuthCode_IssuerUrl != null)
            {
                requestIdpAuthorizingConfiguration_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpConfidentialAuthCode_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpConfidentialAuthCode_IssuerUrl = cmdletContext.IdpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpConfidentialAuthCode_IssuerUrl;
            }
            if (requestIdpAuthorizingConfiguration_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpConfidentialAuthCode_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpConfidentialAuthCode_IssuerUrl != null)
            {
                requestIdpAuthorizingConfiguration_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpConfidentialAuthCode.IssuerUrl = requestIdpAuthorizingConfiguration_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpConfidentialAuthCode_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpConfidentialAuthCode_IssuerUrl;
                requestIdpAuthorizingConfiguration_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpConfidentialAuthCodeIsNull = false;
            }
             // determine if requestIdpAuthorizingConfiguration_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpConfidentialAuthCode should be set to null
            if (requestIdpAuthorizingConfiguration_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpConfidentialAuthCodeIsNull)
            {
                requestIdpAuthorizingConfiguration_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpConfidentialAuthCode = null;
            }
            if (requestIdpAuthorizingConfiguration_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpConfidentialAuthCode != null)
            {
                requestIdpAuthorizingConfiguration_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput.ExternalIdpConfidentialAuthCode = requestIdpAuthorizingConfiguration_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpConfidentialAuthCode;
                requestIdpAuthorizingConfiguration_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInputIsNull = false;
            }
            Amazon.QuickSight.Model.ExternalIdpPublicAuthCodeAuthorizingConfig requestIdpAuthorizingConfiguration_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpPublicAuthCode = null;
            
             // populate ExternalIdpPublicAuthCode
            var requestIdpAuthorizingConfiguration_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpPublicAuthCodeIsNull = true;
            requestIdpAuthorizingConfiguration_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpPublicAuthCode = new Amazon.QuickSight.Model.ExternalIdpPublicAuthCodeAuthorizingConfig();
            System.String requestIdpAuthorizingConfiguration_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpPublicAuthCode_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpPublicAuthCode_ClientId = null;
            if (cmdletContext.IdpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpPublicAuthCode_ClientId != null)
            {
                requestIdpAuthorizingConfiguration_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpPublicAuthCode_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpPublicAuthCode_ClientId = cmdletContext.IdpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpPublicAuthCode_ClientId;
            }
            if (requestIdpAuthorizingConfiguration_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpPublicAuthCode_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpPublicAuthCode_ClientId != null)
            {
                requestIdpAuthorizingConfiguration_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpPublicAuthCode.ClientId = requestIdpAuthorizingConfiguration_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpPublicAuthCode_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpPublicAuthCode_ClientId;
                requestIdpAuthorizingConfiguration_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpPublicAuthCodeIsNull = false;
            }
            System.String requestIdpAuthorizingConfiguration_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpPublicAuthCode_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpPublicAuthCode_IssuerUrl = null;
            if (cmdletContext.IdpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpPublicAuthCode_IssuerUrl != null)
            {
                requestIdpAuthorizingConfiguration_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpPublicAuthCode_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpPublicAuthCode_IssuerUrl = cmdletContext.IdpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpPublicAuthCode_IssuerUrl;
            }
            if (requestIdpAuthorizingConfiguration_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpPublicAuthCode_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpPublicAuthCode_IssuerUrl != null)
            {
                requestIdpAuthorizingConfiguration_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpPublicAuthCode.IssuerUrl = requestIdpAuthorizingConfiguration_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpPublicAuthCode_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpPublicAuthCode_IssuerUrl;
                requestIdpAuthorizingConfiguration_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpPublicAuthCodeIsNull = false;
            }
             // determine if requestIdpAuthorizingConfiguration_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpPublicAuthCode should be set to null
            if (requestIdpAuthorizingConfiguration_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpPublicAuthCodeIsNull)
            {
                requestIdpAuthorizingConfiguration_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpPublicAuthCode = null;
            }
            if (requestIdpAuthorizingConfiguration_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpPublicAuthCode != null)
            {
                requestIdpAuthorizingConfiguration_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput.ExternalIdpPublicAuthCode = requestIdpAuthorizingConfiguration_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpPublicAuthCode;
                requestIdpAuthorizingConfiguration_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInputIsNull = false;
            }
             // determine if requestIdpAuthorizingConfiguration_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput should be set to null
            if (requestIdpAuthorizingConfiguration_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInputIsNull)
            {
                requestIdpAuthorizingConfiguration_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput = null;
            }
            if (requestIdpAuthorizingConfiguration_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput != null)
            {
                request.IdpAuthorizingConfiguration.IdpAuthorizingConfigurationDetailInput = requestIdpAuthorizingConfiguration_idpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput;
                requestIdpAuthorizingConfigurationIsNull = false;
            }
             // determine if request.IdpAuthorizingConfiguration should be set to null
            if (requestIdpAuthorizingConfigurationIsNull)
            {
                request.IdpAuthorizingConfiguration = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate QuickAuthenticationConfiguration
            var requestQuickAuthenticationConfigurationIsNull = true;
            request.QuickAuthenticationConfiguration = new Amazon.QuickSight.Model.QuickAuthenticationConfigInput();
            Amazon.QuickSight.QuickAuthenticationType requestQuickAuthenticationConfiguration_quickAuthenticationConfiguration_QuickAuthenticationType = null;
            if (cmdletContext.QuickAuthenticationConfiguration_QuickAuthenticationType != null)
            {
                requestQuickAuthenticationConfiguration_quickAuthenticationConfiguration_QuickAuthenticationType = cmdletContext.QuickAuthenticationConfiguration_QuickAuthenticationType;
            }
            if (requestQuickAuthenticationConfiguration_quickAuthenticationConfiguration_QuickAuthenticationType != null)
            {
                request.QuickAuthenticationConfiguration.QuickAuthenticationType = requestQuickAuthenticationConfiguration_quickAuthenticationConfiguration_QuickAuthenticationType;
                requestQuickAuthenticationConfigurationIsNull = false;
            }
            Amazon.QuickSight.Model.QuickAuthenticationConfigurationDetailInput requestQuickAuthenticationConfiguration_quickAuthenticationConfiguration_QuickAuthenticationConfigurationDetailInput = null;
            
             // populate QuickAuthenticationConfigurationDetailInput
            var requestQuickAuthenticationConfiguration_quickAuthenticationConfiguration_QuickAuthenticationConfigurationDetailInputIsNull = true;
            requestQuickAuthenticationConfiguration_quickAuthenticationConfiguration_QuickAuthenticationConfigurationDetailInput = new Amazon.QuickSight.Model.QuickAuthenticationConfigurationDetailInput();
            Amazon.QuickSight.Model.QuickManagedAuthCodeQuickAuthenticationConfigInput requestQuickAuthenticationConfiguration_quickAuthenticationConfiguration_QuickAuthenticationConfigurationDetailInput_quickAuthenticationConfiguration_QuickAuthenticationConfigurationDetailInput_QuickManagedPublicAuthCode = null;
            
             // populate QuickManagedPublicAuthCode
            var requestQuickAuthenticationConfiguration_quickAuthenticationConfiguration_QuickAuthenticationConfigurationDetailInput_quickAuthenticationConfiguration_QuickAuthenticationConfigurationDetailInput_QuickManagedPublicAuthCodeIsNull = true;
            requestQuickAuthenticationConfiguration_quickAuthenticationConfiguration_QuickAuthenticationConfigurationDetailInput_quickAuthenticationConfiguration_QuickAuthenticationConfigurationDetailInput_QuickManagedPublicAuthCode = new Amazon.QuickSight.Model.QuickManagedAuthCodeQuickAuthenticationConfigInput();
            List<System.String> requestQuickAuthenticationConfiguration_quickAuthenticationConfiguration_QuickAuthenticationConfigurationDetailInput_quickAuthenticationConfiguration_QuickAuthenticationConfigurationDetailInput_QuickManagedPublicAuthCode_quickAuthenticationConfiguration_QuickAuthenticationConfigurationDetailInput_QuickManagedPublicAuthCode_RedirectUris = null;
            if (cmdletContext.QuickAuthenticationConfiguration_QuickAuthenticationConfigurationDetailInput_QuickManagedPublicAuthCode_RedirectUris != null)
            {
                requestQuickAuthenticationConfiguration_quickAuthenticationConfiguration_QuickAuthenticationConfigurationDetailInput_quickAuthenticationConfiguration_QuickAuthenticationConfigurationDetailInput_QuickManagedPublicAuthCode_quickAuthenticationConfiguration_QuickAuthenticationConfigurationDetailInput_QuickManagedPublicAuthCode_RedirectUris = cmdletContext.QuickAuthenticationConfiguration_QuickAuthenticationConfigurationDetailInput_QuickManagedPublicAuthCode_RedirectUris;
            }
            if (requestQuickAuthenticationConfiguration_quickAuthenticationConfiguration_QuickAuthenticationConfigurationDetailInput_quickAuthenticationConfiguration_QuickAuthenticationConfigurationDetailInput_QuickManagedPublicAuthCode_quickAuthenticationConfiguration_QuickAuthenticationConfigurationDetailInput_QuickManagedPublicAuthCode_RedirectUris != null)
            {
                requestQuickAuthenticationConfiguration_quickAuthenticationConfiguration_QuickAuthenticationConfigurationDetailInput_quickAuthenticationConfiguration_QuickAuthenticationConfigurationDetailInput_QuickManagedPublicAuthCode.RedirectUris = requestQuickAuthenticationConfiguration_quickAuthenticationConfiguration_QuickAuthenticationConfigurationDetailInput_quickAuthenticationConfiguration_QuickAuthenticationConfigurationDetailInput_QuickManagedPublicAuthCode_quickAuthenticationConfiguration_QuickAuthenticationConfigurationDetailInput_QuickManagedPublicAuthCode_RedirectUris;
                requestQuickAuthenticationConfiguration_quickAuthenticationConfiguration_QuickAuthenticationConfigurationDetailInput_quickAuthenticationConfiguration_QuickAuthenticationConfigurationDetailInput_QuickManagedPublicAuthCodeIsNull = false;
            }
             // determine if requestQuickAuthenticationConfiguration_quickAuthenticationConfiguration_QuickAuthenticationConfigurationDetailInput_quickAuthenticationConfiguration_QuickAuthenticationConfigurationDetailInput_QuickManagedPublicAuthCode should be set to null
            if (requestQuickAuthenticationConfiguration_quickAuthenticationConfiguration_QuickAuthenticationConfigurationDetailInput_quickAuthenticationConfiguration_QuickAuthenticationConfigurationDetailInput_QuickManagedPublicAuthCodeIsNull)
            {
                requestQuickAuthenticationConfiguration_quickAuthenticationConfiguration_QuickAuthenticationConfigurationDetailInput_quickAuthenticationConfiguration_QuickAuthenticationConfigurationDetailInput_QuickManagedPublicAuthCode = null;
            }
            if (requestQuickAuthenticationConfiguration_quickAuthenticationConfiguration_QuickAuthenticationConfigurationDetailInput_quickAuthenticationConfiguration_QuickAuthenticationConfigurationDetailInput_QuickManagedPublicAuthCode != null)
            {
                requestQuickAuthenticationConfiguration_quickAuthenticationConfiguration_QuickAuthenticationConfigurationDetailInput.QuickManagedPublicAuthCode = requestQuickAuthenticationConfiguration_quickAuthenticationConfiguration_QuickAuthenticationConfigurationDetailInput_quickAuthenticationConfiguration_QuickAuthenticationConfigurationDetailInput_QuickManagedPublicAuthCode;
                requestQuickAuthenticationConfiguration_quickAuthenticationConfiguration_QuickAuthenticationConfigurationDetailInputIsNull = false;
            }
             // determine if requestQuickAuthenticationConfiguration_quickAuthenticationConfiguration_QuickAuthenticationConfigurationDetailInput should be set to null
            if (requestQuickAuthenticationConfiguration_quickAuthenticationConfiguration_QuickAuthenticationConfigurationDetailInputIsNull)
            {
                requestQuickAuthenticationConfiguration_quickAuthenticationConfiguration_QuickAuthenticationConfigurationDetailInput = null;
            }
            if (requestQuickAuthenticationConfiguration_quickAuthenticationConfiguration_QuickAuthenticationConfigurationDetailInput != null)
            {
                request.QuickAuthenticationConfiguration.QuickAuthenticationConfigurationDetailInput = requestQuickAuthenticationConfiguration_quickAuthenticationConfiguration_QuickAuthenticationConfigurationDetailInput;
                requestQuickAuthenticationConfigurationIsNull = false;
            }
             // determine if request.QuickAuthenticationConfiguration should be set to null
            if (requestQuickAuthenticationConfigurationIsNull)
            {
                request.QuickAuthenticationConfiguration = null;
            }
            if (cmdletContext.Status != null)
            {
                request.Status = cmdletContext.Status;
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
        
        private Amazon.QuickSight.Model.UpdateAccessControlApplicationResponse CallAWSServiceOperation(IAmazonQuickSight client, Amazon.QuickSight.Model.UpdateAccessControlApplicationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon QuickSight", "UpdateAccessControlApplication");
            try
            {
                return client.UpdateAccessControlApplicationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ApplicationId { get; set; }
            public System.String AwsAccountId { get; set; }
            public System.String Description { get; set; }
            public System.String IdpAuthorizingConfiguration_IdcTrustedTokenIssuerConfiguration_IdcTrustedTokenIssuerArn { get; set; }
            public System.String IdpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpConfidentialAuthCode_ClientId { get; set; }
            public System.String IdpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpConfidentialAuthCode_IssuerUrl { get; set; }
            public System.String IdpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpPublicAuthCode_ClientId { get; set; }
            public System.String IdpAuthorizingConfiguration_IdpAuthorizingConfigurationDetailInput_ExternalIdpPublicAuthCode_IssuerUrl { get; set; }
            public Amazon.QuickSight.IdpAuthorizingType IdpAuthorizingConfiguration_IdpAuthorizingType { get; set; }
            public System.String Name { get; set; }
            public List<System.String> QuickAuthenticationConfiguration_QuickAuthenticationConfigurationDetailInput_QuickManagedPublicAuthCode_RedirectUris { get; set; }
            public Amazon.QuickSight.QuickAuthenticationType QuickAuthenticationConfiguration_QuickAuthenticationType { get; set; }
            public Amazon.QuickSight.AccessControlApplicationStatus Status { get; set; }
            public System.Func<Amazon.QuickSight.Model.UpdateAccessControlApplicationResponse, UpdateQSAccessControlApplicationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
