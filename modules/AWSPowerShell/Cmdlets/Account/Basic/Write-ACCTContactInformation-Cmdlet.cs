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
using Amazon.Account;
using Amazon.Account.Model;

namespace Amazon.PowerShell.Cmdlets.ACCT
{
    /// <summary>
    /// Updates the primary contact information of an Amazon Web Services account.
    /// 
    ///  
    /// <para>
    /// For complete details about how to use the primary contact operations, see <a href="https://docs.aws.amazon.com/accounts/latest/reference/manage-acct-update-contact.html">Update
    /// the primary and alternate contact information</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "ACCTContactInformation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Account PutContactInformation API operation.", Operation = new[] {"PutContactInformation"}, SelectReturnType = typeof(Amazon.Account.Model.PutContactInformationResponse))]
    [AWSCmdletOutput("None or Amazon.Account.Model.PutContactInformationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Account.Model.PutContactInformationResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteACCTContactInformationCmdlet : AmazonAccountClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// <para>Specifies the 12-digit account ID number of the Amazon Web Services account that you
        /// want to access or modify with this operation. If you don't specify this parameter,
        /// it defaults to the Amazon Web Services account of the identity used to call the operation.
        /// To use this parameter, the caller must be an identity in the <a href="https://docs.aws.amazon.com/organizations/latest/userguide/orgs_getting-started_concepts.html#account">organization's
        /// management account</a> or a delegated administrator account. The specified account
        /// ID must also be a member account in the same organization. The organization must have
        /// <a href="https://docs.aws.amazon.com/organizations/latest/userguide/orgs_manage_org_support-all-features.html">all
        /// features enabled</a>, and the organization must have <a href="https://docs.aws.amazon.com/organizations/latest/userguide/using-orgs-trusted-access.html">trusted
        /// access</a> enabled for the Account Management service, and optionally a <a href="https://docs.aws.amazon.com/organizations/latest/userguide/using-orgs-delegated-admin.html">delegated
        /// admin</a> account assigned.</para><note><para>The management account can't specify its own <code>AccountId</code>. It must call
        /// the operation in standalone context by not including the <code>AccountId</code> parameter.</para></note><para>To call this operation on an account that is not a member of an organization, don't
        /// specify this parameter. Instead, call the operation using an identity belonging to
        /// the account whose contacts you wish to retrieve or modify.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AccountId { get; set; }
        #endregion
        
        #region Parameter ContactInformation_AddressLine1
        /// <summary>
        /// <para>
        /// <para>The first line of the primary contact address.</para>
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
        public System.String ContactInformation_AddressLine1 { get; set; }
        #endregion
        
        #region Parameter ContactInformation_AddressLine2
        /// <summary>
        /// <para>
        /// <para>The second line of the primary contact address, if any.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ContactInformation_AddressLine2 { get; set; }
        #endregion
        
        #region Parameter ContactInformation_AddressLine3
        /// <summary>
        /// <para>
        /// <para>The third line of the primary contact address, if any.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ContactInformation_AddressLine3 { get; set; }
        #endregion
        
        #region Parameter ContactInformation_City
        /// <summary>
        /// <para>
        /// <para>The city of the primary contact address.</para>
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
        public System.String ContactInformation_City { get; set; }
        #endregion
        
        #region Parameter ContactInformation_CompanyName
        /// <summary>
        /// <para>
        /// <para>The name of the company associated with the primary contact information, if any.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ContactInformation_CompanyName { get; set; }
        #endregion
        
        #region Parameter ContactInformation_CountryCode
        /// <summary>
        /// <para>
        /// <para>The ISO-3166 two-letter country code for the primary contact address.</para>
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
        public System.String ContactInformation_CountryCode { get; set; }
        #endregion
        
        #region Parameter ContactInformation_DistrictOrCounty
        /// <summary>
        /// <para>
        /// <para>The district or county of the primary contact address, if any.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ContactInformation_DistrictOrCounty { get; set; }
        #endregion
        
        #region Parameter ContactInformation_FullName
        /// <summary>
        /// <para>
        /// <para>The full name of the primary contact address.</para>
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
        public System.String ContactInformation_FullName { get; set; }
        #endregion
        
        #region Parameter ContactInformation_PhoneNumber
        /// <summary>
        /// <para>
        /// <para>The phone number of the primary contact information. The number will be validated
        /// and, in some countries, checked for activation.</para>
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
        public System.String ContactInformation_PhoneNumber { get; set; }
        #endregion
        
        #region Parameter ContactInformation_PostalCode
        /// <summary>
        /// <para>
        /// <para>The postal code of the primary contact address.</para>
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
        public System.String ContactInformation_PostalCode { get; set; }
        #endregion
        
        #region Parameter ContactInformation_StateOrRegion
        /// <summary>
        /// <para>
        /// <para>The state or region of the primary contact address. This field is required in selected
        /// countries.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ContactInformation_StateOrRegion { get; set; }
        #endregion
        
        #region Parameter ContactInformation_WebsiteUrl
        /// <summary>
        /// <para>
        /// <para>The URL of the website associated with the primary contact information, if any.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ContactInformation_WebsiteUrl { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Account.Model.PutContactInformationResponse).
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-ACCTContactInformation (PutContactInformation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Account.Model.PutContactInformationResponse, WriteACCTContactInformationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AccountId = this.AccountId;
            context.ContactInformation_AddressLine1 = this.ContactInformation_AddressLine1;
            #if MODULAR
            if (this.ContactInformation_AddressLine1 == null && ParameterWasBound(nameof(this.ContactInformation_AddressLine1)))
            {
                WriteWarning("You are passing $null as a value for parameter ContactInformation_AddressLine1 which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ContactInformation_AddressLine2 = this.ContactInformation_AddressLine2;
            context.ContactInformation_AddressLine3 = this.ContactInformation_AddressLine3;
            context.ContactInformation_City = this.ContactInformation_City;
            #if MODULAR
            if (this.ContactInformation_City == null && ParameterWasBound(nameof(this.ContactInformation_City)))
            {
                WriteWarning("You are passing $null as a value for parameter ContactInformation_City which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ContactInformation_CompanyName = this.ContactInformation_CompanyName;
            context.ContactInformation_CountryCode = this.ContactInformation_CountryCode;
            #if MODULAR
            if (this.ContactInformation_CountryCode == null && ParameterWasBound(nameof(this.ContactInformation_CountryCode)))
            {
                WriteWarning("You are passing $null as a value for parameter ContactInformation_CountryCode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ContactInformation_DistrictOrCounty = this.ContactInformation_DistrictOrCounty;
            context.ContactInformation_FullName = this.ContactInformation_FullName;
            #if MODULAR
            if (this.ContactInformation_FullName == null && ParameterWasBound(nameof(this.ContactInformation_FullName)))
            {
                WriteWarning("You are passing $null as a value for parameter ContactInformation_FullName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ContactInformation_PhoneNumber = this.ContactInformation_PhoneNumber;
            #if MODULAR
            if (this.ContactInformation_PhoneNumber == null && ParameterWasBound(nameof(this.ContactInformation_PhoneNumber)))
            {
                WriteWarning("You are passing $null as a value for parameter ContactInformation_PhoneNumber which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ContactInformation_PostalCode = this.ContactInformation_PostalCode;
            #if MODULAR
            if (this.ContactInformation_PostalCode == null && ParameterWasBound(nameof(this.ContactInformation_PostalCode)))
            {
                WriteWarning("You are passing $null as a value for parameter ContactInformation_PostalCode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ContactInformation_StateOrRegion = this.ContactInformation_StateOrRegion;
            context.ContactInformation_WebsiteUrl = this.ContactInformation_WebsiteUrl;
            
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
            var request = new Amazon.Account.Model.PutContactInformationRequest();
            
            if (cmdletContext.AccountId != null)
            {
                request.AccountId = cmdletContext.AccountId;
            }
            
             // populate ContactInformation
            var requestContactInformationIsNull = true;
            request.ContactInformation = new Amazon.Account.Model.ContactInformation();
            System.String requestContactInformation_contactInformation_AddressLine1 = null;
            if (cmdletContext.ContactInformation_AddressLine1 != null)
            {
                requestContactInformation_contactInformation_AddressLine1 = cmdletContext.ContactInformation_AddressLine1;
            }
            if (requestContactInformation_contactInformation_AddressLine1 != null)
            {
                request.ContactInformation.AddressLine1 = requestContactInformation_contactInformation_AddressLine1;
                requestContactInformationIsNull = false;
            }
            System.String requestContactInformation_contactInformation_AddressLine2 = null;
            if (cmdletContext.ContactInformation_AddressLine2 != null)
            {
                requestContactInformation_contactInformation_AddressLine2 = cmdletContext.ContactInformation_AddressLine2;
            }
            if (requestContactInformation_contactInformation_AddressLine2 != null)
            {
                request.ContactInformation.AddressLine2 = requestContactInformation_contactInformation_AddressLine2;
                requestContactInformationIsNull = false;
            }
            System.String requestContactInformation_contactInformation_AddressLine3 = null;
            if (cmdletContext.ContactInformation_AddressLine3 != null)
            {
                requestContactInformation_contactInformation_AddressLine3 = cmdletContext.ContactInformation_AddressLine3;
            }
            if (requestContactInformation_contactInformation_AddressLine3 != null)
            {
                request.ContactInformation.AddressLine3 = requestContactInformation_contactInformation_AddressLine3;
                requestContactInformationIsNull = false;
            }
            System.String requestContactInformation_contactInformation_City = null;
            if (cmdletContext.ContactInformation_City != null)
            {
                requestContactInformation_contactInformation_City = cmdletContext.ContactInformation_City;
            }
            if (requestContactInformation_contactInformation_City != null)
            {
                request.ContactInformation.City = requestContactInformation_contactInformation_City;
                requestContactInformationIsNull = false;
            }
            System.String requestContactInformation_contactInformation_CompanyName = null;
            if (cmdletContext.ContactInformation_CompanyName != null)
            {
                requestContactInformation_contactInformation_CompanyName = cmdletContext.ContactInformation_CompanyName;
            }
            if (requestContactInformation_contactInformation_CompanyName != null)
            {
                request.ContactInformation.CompanyName = requestContactInformation_contactInformation_CompanyName;
                requestContactInformationIsNull = false;
            }
            System.String requestContactInformation_contactInformation_CountryCode = null;
            if (cmdletContext.ContactInformation_CountryCode != null)
            {
                requestContactInformation_contactInformation_CountryCode = cmdletContext.ContactInformation_CountryCode;
            }
            if (requestContactInformation_contactInformation_CountryCode != null)
            {
                request.ContactInformation.CountryCode = requestContactInformation_contactInformation_CountryCode;
                requestContactInformationIsNull = false;
            }
            System.String requestContactInformation_contactInformation_DistrictOrCounty = null;
            if (cmdletContext.ContactInformation_DistrictOrCounty != null)
            {
                requestContactInformation_contactInformation_DistrictOrCounty = cmdletContext.ContactInformation_DistrictOrCounty;
            }
            if (requestContactInformation_contactInformation_DistrictOrCounty != null)
            {
                request.ContactInformation.DistrictOrCounty = requestContactInformation_contactInformation_DistrictOrCounty;
                requestContactInformationIsNull = false;
            }
            System.String requestContactInformation_contactInformation_FullName = null;
            if (cmdletContext.ContactInformation_FullName != null)
            {
                requestContactInformation_contactInformation_FullName = cmdletContext.ContactInformation_FullName;
            }
            if (requestContactInformation_contactInformation_FullName != null)
            {
                request.ContactInformation.FullName = requestContactInformation_contactInformation_FullName;
                requestContactInformationIsNull = false;
            }
            System.String requestContactInformation_contactInformation_PhoneNumber = null;
            if (cmdletContext.ContactInformation_PhoneNumber != null)
            {
                requestContactInformation_contactInformation_PhoneNumber = cmdletContext.ContactInformation_PhoneNumber;
            }
            if (requestContactInformation_contactInformation_PhoneNumber != null)
            {
                request.ContactInformation.PhoneNumber = requestContactInformation_contactInformation_PhoneNumber;
                requestContactInformationIsNull = false;
            }
            System.String requestContactInformation_contactInformation_PostalCode = null;
            if (cmdletContext.ContactInformation_PostalCode != null)
            {
                requestContactInformation_contactInformation_PostalCode = cmdletContext.ContactInformation_PostalCode;
            }
            if (requestContactInformation_contactInformation_PostalCode != null)
            {
                request.ContactInformation.PostalCode = requestContactInformation_contactInformation_PostalCode;
                requestContactInformationIsNull = false;
            }
            System.String requestContactInformation_contactInformation_StateOrRegion = null;
            if (cmdletContext.ContactInformation_StateOrRegion != null)
            {
                requestContactInformation_contactInformation_StateOrRegion = cmdletContext.ContactInformation_StateOrRegion;
            }
            if (requestContactInformation_contactInformation_StateOrRegion != null)
            {
                request.ContactInformation.StateOrRegion = requestContactInformation_contactInformation_StateOrRegion;
                requestContactInformationIsNull = false;
            }
            System.String requestContactInformation_contactInformation_WebsiteUrl = null;
            if (cmdletContext.ContactInformation_WebsiteUrl != null)
            {
                requestContactInformation_contactInformation_WebsiteUrl = cmdletContext.ContactInformation_WebsiteUrl;
            }
            if (requestContactInformation_contactInformation_WebsiteUrl != null)
            {
                request.ContactInformation.WebsiteUrl = requestContactInformation_contactInformation_WebsiteUrl;
                requestContactInformationIsNull = false;
            }
             // determine if request.ContactInformation should be set to null
            if (requestContactInformationIsNull)
            {
                request.ContactInformation = null;
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
        
        private Amazon.Account.Model.PutContactInformationResponse CallAWSServiceOperation(IAmazonAccount client, Amazon.Account.Model.PutContactInformationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Account", "PutContactInformation");
            try
            {
                #if DESKTOP
                return client.PutContactInformation(request);
                #elif CORECLR
                return client.PutContactInformationAsync(request).GetAwaiter().GetResult();
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
            public System.String AccountId { get; set; }
            public System.String ContactInformation_AddressLine1 { get; set; }
            public System.String ContactInformation_AddressLine2 { get; set; }
            public System.String ContactInformation_AddressLine3 { get; set; }
            public System.String ContactInformation_City { get; set; }
            public System.String ContactInformation_CompanyName { get; set; }
            public System.String ContactInformation_CountryCode { get; set; }
            public System.String ContactInformation_DistrictOrCounty { get; set; }
            public System.String ContactInformation_FullName { get; set; }
            public System.String ContactInformation_PhoneNumber { get; set; }
            public System.String ContactInformation_PostalCode { get; set; }
            public System.String ContactInformation_StateOrRegion { get; set; }
            public System.String ContactInformation_WebsiteUrl { get; set; }
            public System.Func<Amazon.Account.Model.PutContactInformationResponse, WriteACCTContactInformationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
