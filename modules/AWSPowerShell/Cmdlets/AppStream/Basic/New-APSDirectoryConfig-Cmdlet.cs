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
using Amazon.AppStream;
using Amazon.AppStream.Model;

namespace Amazon.PowerShell.Cmdlets.APS
{
    /// <summary>
    /// Creates a Directory Config object in AppStream 2.0. This object includes the configuration
    /// information required to join fleets and image builders to Microsoft Active Directory
    /// domains.
    /// </summary>
    [Cmdlet("New", "APSDirectoryConfig", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AppStream.Model.DirectoryConfig")]
    [AWSCmdlet("Calls the Amazon AppStream CreateDirectoryConfig API operation.", Operation = new[] {"CreateDirectoryConfig"}, SelectReturnType = typeof(Amazon.AppStream.Model.CreateDirectoryConfigResponse))]
    [AWSCmdletOutput("Amazon.AppStream.Model.DirectoryConfig or Amazon.AppStream.Model.CreateDirectoryConfigResponse",
        "This cmdlet returns an Amazon.AppStream.Model.DirectoryConfig object.",
        "The service call response (type Amazon.AppStream.Model.CreateDirectoryConfigResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewAPSDirectoryConfigCmdlet : AmazonAppStreamClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        #region Parameter ServiceAccountCredentials_AccountName
        /// <summary>
        /// <para>
        /// <para>The user name of the account. This account must have the following privileges: create
        /// computer objects, join computers to the domain, and change/reset the password on descendant
        /// computer objects for the organizational units specified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceAccountCredentials_AccountName { get; set; }
        #endregion
        
        #region Parameter ServiceAccountCredentials_AccountPassword
        /// <summary>
        /// <para>
        /// <para>The password for the account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceAccountCredentials_AccountPassword { get; set; }
        #endregion
        
        #region Parameter CertificateBasedAuthProperties_CertificateAuthorityArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the AWS Certificate Manager Private CA resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CertificateBasedAuthProperties_CertificateAuthorityArn { get; set; }
        #endregion
        
        #region Parameter DirectoryName
        /// <summary>
        /// <para>
        /// <para>The fully qualified name of the directory (for example, corp.example.com).</para>
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
        public System.String DirectoryName { get; set; }
        #endregion
        
        #region Parameter OrganizationalUnitDistinguishedName
        /// <summary>
        /// <para>
        /// <para>The distinguished names of the organizational units for computer accounts.</para>
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
        [Alias("OrganizationalUnitDistinguishedNames")]
        public System.String[] OrganizationalUnitDistinguishedName { get; set; }
        #endregion
        
        #region Parameter CertificateBasedAuthProperties_Status
        /// <summary>
        /// <para>
        /// <para>The status of the certificate-based authentication properties.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.AppStream.CertificateBasedAuthStatus")]
        public Amazon.AppStream.CertificateBasedAuthStatus CertificateBasedAuthProperties_Status { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DirectoryConfig'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppStream.Model.CreateDirectoryConfigResponse).
        /// Specifying the name of a property of type Amazon.AppStream.Model.CreateDirectoryConfigResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DirectoryConfig";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DirectoryName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DirectoryName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DirectoryName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DirectoryName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-APSDirectoryConfig (CreateDirectoryConfig)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AppStream.Model.CreateDirectoryConfigResponse, NewAPSDirectoryConfigCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DirectoryName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CertificateBasedAuthProperties_CertificateAuthorityArn = this.CertificateBasedAuthProperties_CertificateAuthorityArn;
            context.CertificateBasedAuthProperties_Status = this.CertificateBasedAuthProperties_Status;
            context.DirectoryName = this.DirectoryName;
            #if MODULAR
            if (this.DirectoryName == null && ParameterWasBound(nameof(this.DirectoryName)))
            {
                WriteWarning("You are passing $null as a value for parameter DirectoryName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.OrganizationalUnitDistinguishedName != null)
            {
                context.OrganizationalUnitDistinguishedName = new List<System.String>(this.OrganizationalUnitDistinguishedName);
            }
            #if MODULAR
            if (this.OrganizationalUnitDistinguishedName == null && ParameterWasBound(nameof(this.OrganizationalUnitDistinguishedName)))
            {
                WriteWarning("You are passing $null as a value for parameter OrganizationalUnitDistinguishedName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ServiceAccountCredentials_AccountName = this.ServiceAccountCredentials_AccountName;
            context.ServiceAccountCredentials_AccountPassword = this.ServiceAccountCredentials_AccountPassword;
            
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
            var request = new Amazon.AppStream.Model.CreateDirectoryConfigRequest();
            
            
             // populate CertificateBasedAuthProperties
            var requestCertificateBasedAuthPropertiesIsNull = true;
            request.CertificateBasedAuthProperties = new Amazon.AppStream.Model.CertificateBasedAuthProperties();
            System.String requestCertificateBasedAuthProperties_certificateBasedAuthProperties_CertificateAuthorityArn = null;
            if (cmdletContext.CertificateBasedAuthProperties_CertificateAuthorityArn != null)
            {
                requestCertificateBasedAuthProperties_certificateBasedAuthProperties_CertificateAuthorityArn = cmdletContext.CertificateBasedAuthProperties_CertificateAuthorityArn;
            }
            if (requestCertificateBasedAuthProperties_certificateBasedAuthProperties_CertificateAuthorityArn != null)
            {
                request.CertificateBasedAuthProperties.CertificateAuthorityArn = requestCertificateBasedAuthProperties_certificateBasedAuthProperties_CertificateAuthorityArn;
                requestCertificateBasedAuthPropertiesIsNull = false;
            }
            Amazon.AppStream.CertificateBasedAuthStatus requestCertificateBasedAuthProperties_certificateBasedAuthProperties_Status = null;
            if (cmdletContext.CertificateBasedAuthProperties_Status != null)
            {
                requestCertificateBasedAuthProperties_certificateBasedAuthProperties_Status = cmdletContext.CertificateBasedAuthProperties_Status;
            }
            if (requestCertificateBasedAuthProperties_certificateBasedAuthProperties_Status != null)
            {
                request.CertificateBasedAuthProperties.Status = requestCertificateBasedAuthProperties_certificateBasedAuthProperties_Status;
                requestCertificateBasedAuthPropertiesIsNull = false;
            }
             // determine if request.CertificateBasedAuthProperties should be set to null
            if (requestCertificateBasedAuthPropertiesIsNull)
            {
                request.CertificateBasedAuthProperties = null;
            }
            if (cmdletContext.DirectoryName != null)
            {
                request.DirectoryName = cmdletContext.DirectoryName;
            }
            if (cmdletContext.OrganizationalUnitDistinguishedName != null)
            {
                request.OrganizationalUnitDistinguishedNames = cmdletContext.OrganizationalUnitDistinguishedName;
            }
            
             // populate ServiceAccountCredentials
            var requestServiceAccountCredentialsIsNull = true;
            request.ServiceAccountCredentials = new Amazon.AppStream.Model.ServiceAccountCredentials();
            System.String requestServiceAccountCredentials_serviceAccountCredentials_AccountName = null;
            if (cmdletContext.ServiceAccountCredentials_AccountName != null)
            {
                requestServiceAccountCredentials_serviceAccountCredentials_AccountName = cmdletContext.ServiceAccountCredentials_AccountName;
            }
            if (requestServiceAccountCredentials_serviceAccountCredentials_AccountName != null)
            {
                request.ServiceAccountCredentials.AccountName = requestServiceAccountCredentials_serviceAccountCredentials_AccountName;
                requestServiceAccountCredentialsIsNull = false;
            }
            System.String requestServiceAccountCredentials_serviceAccountCredentials_AccountPassword = null;
            if (cmdletContext.ServiceAccountCredentials_AccountPassword != null)
            {
                requestServiceAccountCredentials_serviceAccountCredentials_AccountPassword = cmdletContext.ServiceAccountCredentials_AccountPassword;
            }
            if (requestServiceAccountCredentials_serviceAccountCredentials_AccountPassword != null)
            {
                request.ServiceAccountCredentials.AccountPassword = requestServiceAccountCredentials_serviceAccountCredentials_AccountPassword;
                requestServiceAccountCredentialsIsNull = false;
            }
             // determine if request.ServiceAccountCredentials should be set to null
            if (requestServiceAccountCredentialsIsNull)
            {
                request.ServiceAccountCredentials = null;
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
        
        private Amazon.AppStream.Model.CreateDirectoryConfigResponse CallAWSServiceOperation(IAmazonAppStream client, Amazon.AppStream.Model.CreateDirectoryConfigRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon AppStream", "CreateDirectoryConfig");
            try
            {
                #if DESKTOP
                return client.CreateDirectoryConfig(request);
                #elif CORECLR
                return client.CreateDirectoryConfigAsync(request).GetAwaiter().GetResult();
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
            public System.String CertificateBasedAuthProperties_CertificateAuthorityArn { get; set; }
            public Amazon.AppStream.CertificateBasedAuthStatus CertificateBasedAuthProperties_Status { get; set; }
            public System.String DirectoryName { get; set; }
            public List<System.String> OrganizationalUnitDistinguishedName { get; set; }
            public System.String ServiceAccountCredentials_AccountName { get; set; }
            public System.String ServiceAccountCredentials_AccountPassword { get; set; }
            public System.Func<Amazon.AppStream.Model.CreateDirectoryConfigResponse, NewAPSDirectoryConfigCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DirectoryConfig;
        }
        
    }
}
