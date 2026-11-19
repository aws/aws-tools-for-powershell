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
using Amazon.PartnerCentralSelling;
using Amazon.PartnerCentralSelling.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.PC
{
    /// <summary>
    /// Use <c>UpdateCustomerAccount</c> to replace the customer information on an existing
    /// customer account. AWS matches the account again with the updated information.
    /// 
    ///  
    /// <para>
    /// To prevent concurrent changes from overwriting each other, specify the <c>LastModifiedDate</c>
    /// value that you last read for the account. If the account changed since then, the request
    /// fails with a <c>ConflictException</c>.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "PCCustomerAccount", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.PartnerCentralSelling.Model.UpdateCustomerAccountResponse")]
    [AWSCmdlet("Calls the Partner Central Selling API UpdateCustomerAccount API operation.", Operation = new[] {"UpdateCustomerAccount"}, SelectReturnType = typeof(Amazon.PartnerCentralSelling.Model.UpdateCustomerAccountResponse))]
    [AWSCmdletOutput("Amazon.PartnerCentralSelling.Model.UpdateCustomerAccountResponse",
        "This cmdlet returns an Amazon.PartnerCentralSelling.Model.UpdateCustomerAccountResponse object containing multiple properties."
    )]
    public partial class UpdatePCCustomerAccountCmdlet : AmazonPartnerCentralSellingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Catalog
        /// <summary>
        /// <para>
        /// <para>Specifies the catalog for the request. Valid values:</para><ul><li><para><c>AWS</c>: Production.</para></li><li><para><c>Sandbox</c>: Testing environments.</para></li></ul>
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
        public System.String Catalog { get; set; }
        #endregion
        
        #region Parameter Account_Address_City
        /// <summary>
        /// <para>
        /// <para>Specifies the end <c>Customer</c>'s city associated with the <c>Opportunity</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Account_Address_City { get; set; }
        #endregion
        
        #region Parameter Account_CompanyName
        /// <summary>
        /// <para>
        /// <para>The name of the customer company.</para>
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
        public System.String Account_CompanyName { get; set; }
        #endregion
        
        #region Parameter Account_Address_CountryCode
        /// <summary>
        /// <para>
        /// <para>Specifies the end <c>Customer</c>'s country associated with the <c>Opportunity</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.PartnerCentralSelling.CountryCode")]
        public Amazon.PartnerCentralSelling.CountryCode Account_Address_CountryCode { get; set; }
        #endregion
        
        #region Parameter Account_Domain
        /// <summary>
        /// <para>
        /// <para>The internet domain of the customer company, such as <c>example.com</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Account_Domain { get; set; }
        #endregion
        
        #region Parameter Account_Dun
        /// <summary>
        /// <para>
        /// <para>The Data Universal Numbering System (DUNS) number of the customer company.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Account_Duns")]
        public System.String Account_Dun { get; set; }
        #endregion
        
        #region Parameter Identifier
        /// <summary>
        /// <para>
        /// <para>Specifies the ARN or the identifier of the customer account.</para>
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
        public System.String Identifier { get; set; }
        #endregion
        
        #region Parameter Account_Industry
        /// <summary>
        /// <para>
        /// <para>The industry of the customer company.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Account_Industry { get; set; }
        #endregion
        
        #region Parameter LastModifiedDate
        /// <summary>
        /// <para>
        /// <para>Specifies the <c>LastModifiedDate</c> of the customer account as you last read it.
        /// If it doesn't match the current value, the request fails with a <c>ConflictException</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? LastModifiedDate { get; set; }
        #endregion
        
        #region Parameter Account_OtherIndustry
        /// <summary>
        /// <para>
        /// <para>A description of the industry, used when the industry is <c>Other</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Account_OtherIndustry { get; set; }
        #endregion
        
        #region Parameter Account_ParentCompanyName
        /// <summary>
        /// <para>
        /// <para>The name of the parent company of the customer company, if any.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Account_ParentCompanyName { get; set; }
        #endregion
        
        #region Parameter PartnerAccountIdentifier
        /// <summary>
        /// <para>
        /// <para>Specifies your own identifier for the customer account, such as the account ID in
        /// your CRM system. Use it to correlate the customer account with your records.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PartnerAccountIdentifier { get; set; }
        #endregion
        
        #region Parameter Account_Address_PostalCode
        /// <summary>
        /// <para>
        /// <para>Specifies the end <c>Customer</c>'s postal code associated with the <c>Opportunity</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Account_Address_PostalCode { get; set; }
        #endregion
        
        #region Parameter Account_Address_StateOrRegion
        /// <summary>
        /// <para>
        /// <para>Specifies the end <c>Customer</c>'s state or region associated with the <c>Opportunity</c>.</para><para>Valid values: <c>Alabama | Alaska | American Samoa | Arizona | Arkansas | California
        /// | Colorado | Connecticut | Delaware | Dist. of Columbia | Federated States of Micronesia
        /// | Florida | Georgia | Guam | Hawaii | Idaho | Illinois | Indiana | Iowa | Kansas |
        /// Kentucky | Louisiana | Maine | Marshall Islands | Maryland | Massachusetts | Michigan
        /// | Minnesota | Mississippi | Missouri | Montana | Nebraska | Nevada | New Hampshire
        /// | New Jersey | New Mexico | New York | North Carolina | North Dakota | Northern Mariana
        /// Islands | Ohio | Oklahoma | Oregon | Palau | Pennsylvania | Puerto Rico | Rhode Island
        /// | South Carolina | South Dakota | Tennessee | Texas | Utah | Vermont | Virginia |
        /// Virgin Islands | Washington | West Virginia | Wisconsin | Wyoming | APO/AE | AFO/FPO
        /// | FPO, AP</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Account_Address_StateOrRegion { get; set; }
        #endregion
        
        #region Parameter Account_Address_StreetAddress
        /// <summary>
        /// <para>
        /// <para>Specifies the end <c>Customer</c>'s street address associated with the <c>Opportunity</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Account_Address_StreetAddress { get; set; }
        #endregion
        
        #region Parameter Account_WebsiteUrl
        /// <summary>
        /// <para>
        /// <para>The website URL of the customer company.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Account_WebsiteUrl { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PartnerCentralSelling.Model.UpdateCustomerAccountResponse).
        /// Specifying the name of a property of type Amazon.PartnerCentralSelling.Model.UpdateCustomerAccountResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Identifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-PCCustomerAccount (UpdateCustomerAccount)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PartnerCentralSelling.Model.UpdateCustomerAccountResponse, UpdatePCCustomerAccountCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Account_Address_City = this.Account_Address_City;
            context.Account_Address_CountryCode = this.Account_Address_CountryCode;
            context.Account_Address_PostalCode = this.Account_Address_PostalCode;
            context.Account_Address_StateOrRegion = this.Account_Address_StateOrRegion;
            context.Account_Address_StreetAddress = this.Account_Address_StreetAddress;
            context.Account_CompanyName = this.Account_CompanyName;
            #if MODULAR
            if (this.Account_CompanyName == null && ParameterWasBound(nameof(this.Account_CompanyName)))
            {
                WriteWarning("You are passing $null as a value for parameter Account_CompanyName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Account_Domain = this.Account_Domain;
            context.Account_Dun = this.Account_Dun;
            context.Account_Industry = this.Account_Industry;
            context.Account_OtherIndustry = this.Account_OtherIndustry;
            context.Account_ParentCompanyName = this.Account_ParentCompanyName;
            context.Account_WebsiteUrl = this.Account_WebsiteUrl;
            context.Catalog = this.Catalog;
            #if MODULAR
            if (this.Catalog == null && ParameterWasBound(nameof(this.Catalog)))
            {
                WriteWarning("You are passing $null as a value for parameter Catalog which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Identifier = this.Identifier;
            #if MODULAR
            if (this.Identifier == null && ParameterWasBound(nameof(this.Identifier)))
            {
                WriteWarning("You are passing $null as a value for parameter Identifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LastModifiedDate = this.LastModifiedDate;
            #if MODULAR
            if (this.LastModifiedDate == null && ParameterWasBound(nameof(this.LastModifiedDate)))
            {
                WriteWarning("You are passing $null as a value for parameter LastModifiedDate which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PartnerAccountIdentifier = this.PartnerAccountIdentifier;
            
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
            var request = new Amazon.PartnerCentralSelling.Model.UpdateCustomerAccountRequest();
            
            
             // populate Account
            var requestAccountIsNull = true;
            request.Account = new Amazon.PartnerCentralSelling.Model.CustomerAccountData();
            System.String requestAccount_account_CompanyName = null;
            if (cmdletContext.Account_CompanyName != null)
            {
                requestAccount_account_CompanyName = cmdletContext.Account_CompanyName;
            }
            if (requestAccount_account_CompanyName != null)
            {
                request.Account.CompanyName = requestAccount_account_CompanyName;
                requestAccountIsNull = false;
            }
            System.String requestAccount_account_Domain = null;
            if (cmdletContext.Account_Domain != null)
            {
                requestAccount_account_Domain = cmdletContext.Account_Domain;
            }
            if (requestAccount_account_Domain != null)
            {
                request.Account.Domain = requestAccount_account_Domain;
                requestAccountIsNull = false;
            }
            System.String requestAccount_account_Dun = null;
            if (cmdletContext.Account_Dun != null)
            {
                requestAccount_account_Dun = cmdletContext.Account_Dun;
            }
            if (requestAccount_account_Dun != null)
            {
                request.Account.Duns = requestAccount_account_Dun;
                requestAccountIsNull = false;
            }
            System.String requestAccount_account_Industry = null;
            if (cmdletContext.Account_Industry != null)
            {
                requestAccount_account_Industry = cmdletContext.Account_Industry;
            }
            if (requestAccount_account_Industry != null)
            {
                request.Account.Industry = requestAccount_account_Industry;
                requestAccountIsNull = false;
            }
            System.String requestAccount_account_OtherIndustry = null;
            if (cmdletContext.Account_OtherIndustry != null)
            {
                requestAccount_account_OtherIndustry = cmdletContext.Account_OtherIndustry;
            }
            if (requestAccount_account_OtherIndustry != null)
            {
                request.Account.OtherIndustry = requestAccount_account_OtherIndustry;
                requestAccountIsNull = false;
            }
            System.String requestAccount_account_ParentCompanyName = null;
            if (cmdletContext.Account_ParentCompanyName != null)
            {
                requestAccount_account_ParentCompanyName = cmdletContext.Account_ParentCompanyName;
            }
            if (requestAccount_account_ParentCompanyName != null)
            {
                request.Account.ParentCompanyName = requestAccount_account_ParentCompanyName;
                requestAccountIsNull = false;
            }
            System.String requestAccount_account_WebsiteUrl = null;
            if (cmdletContext.Account_WebsiteUrl != null)
            {
                requestAccount_account_WebsiteUrl = cmdletContext.Account_WebsiteUrl;
            }
            if (requestAccount_account_WebsiteUrl != null)
            {
                request.Account.WebsiteUrl = requestAccount_account_WebsiteUrl;
                requestAccountIsNull = false;
            }
            Amazon.PartnerCentralSelling.Model.Address requestAccount_account_Address = null;
            
             // populate Address
            var requestAccount_account_AddressIsNull = true;
            requestAccount_account_Address = new Amazon.PartnerCentralSelling.Model.Address();
            System.String requestAccount_account_Address_account_Address_City = null;
            if (cmdletContext.Account_Address_City != null)
            {
                requestAccount_account_Address_account_Address_City = cmdletContext.Account_Address_City;
            }
            if (requestAccount_account_Address_account_Address_City != null)
            {
                requestAccount_account_Address.City = requestAccount_account_Address_account_Address_City;
                requestAccount_account_AddressIsNull = false;
            }
            Amazon.PartnerCentralSelling.CountryCode requestAccount_account_Address_account_Address_CountryCode = null;
            if (cmdletContext.Account_Address_CountryCode != null)
            {
                requestAccount_account_Address_account_Address_CountryCode = cmdletContext.Account_Address_CountryCode;
            }
            if (requestAccount_account_Address_account_Address_CountryCode != null)
            {
                requestAccount_account_Address.CountryCode = requestAccount_account_Address_account_Address_CountryCode;
                requestAccount_account_AddressIsNull = false;
            }
            System.String requestAccount_account_Address_account_Address_PostalCode = null;
            if (cmdletContext.Account_Address_PostalCode != null)
            {
                requestAccount_account_Address_account_Address_PostalCode = cmdletContext.Account_Address_PostalCode;
            }
            if (requestAccount_account_Address_account_Address_PostalCode != null)
            {
                requestAccount_account_Address.PostalCode = requestAccount_account_Address_account_Address_PostalCode;
                requestAccount_account_AddressIsNull = false;
            }
            System.String requestAccount_account_Address_account_Address_StateOrRegion = null;
            if (cmdletContext.Account_Address_StateOrRegion != null)
            {
                requestAccount_account_Address_account_Address_StateOrRegion = cmdletContext.Account_Address_StateOrRegion;
            }
            if (requestAccount_account_Address_account_Address_StateOrRegion != null)
            {
                requestAccount_account_Address.StateOrRegion = requestAccount_account_Address_account_Address_StateOrRegion;
                requestAccount_account_AddressIsNull = false;
            }
            System.String requestAccount_account_Address_account_Address_StreetAddress = null;
            if (cmdletContext.Account_Address_StreetAddress != null)
            {
                requestAccount_account_Address_account_Address_StreetAddress = cmdletContext.Account_Address_StreetAddress;
            }
            if (requestAccount_account_Address_account_Address_StreetAddress != null)
            {
                requestAccount_account_Address.StreetAddress = requestAccount_account_Address_account_Address_StreetAddress;
                requestAccount_account_AddressIsNull = false;
            }
             // determine if requestAccount_account_Address should be set to null
            if (requestAccount_account_AddressIsNull)
            {
                requestAccount_account_Address = null;
            }
            if (requestAccount_account_Address != null)
            {
                request.Account.Address = requestAccount_account_Address;
                requestAccountIsNull = false;
            }
             // determine if request.Account should be set to null
            if (requestAccountIsNull)
            {
                request.Account = null;
            }
            if (cmdletContext.Catalog != null)
            {
                request.Catalog = cmdletContext.Catalog;
            }
            if (cmdletContext.Identifier != null)
            {
                request.Identifier = cmdletContext.Identifier;
            }
            if (cmdletContext.LastModifiedDate != null)
            {
                request.LastModifiedDate = cmdletContext.LastModifiedDate.Value;
            }
            if (cmdletContext.PartnerAccountIdentifier != null)
            {
                request.PartnerAccountIdentifier = cmdletContext.PartnerAccountIdentifier;
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
        
        private Amazon.PartnerCentralSelling.Model.UpdateCustomerAccountResponse CallAWSServiceOperation(IAmazonPartnerCentralSelling client, Amazon.PartnerCentralSelling.Model.UpdateCustomerAccountRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Partner Central Selling API", "UpdateCustomerAccount");
            try
            {
                return client.UpdateCustomerAccountAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Account_Address_City { get; set; }
            public Amazon.PartnerCentralSelling.CountryCode Account_Address_CountryCode { get; set; }
            public System.String Account_Address_PostalCode { get; set; }
            public System.String Account_Address_StateOrRegion { get; set; }
            public System.String Account_Address_StreetAddress { get; set; }
            public System.String Account_CompanyName { get; set; }
            public System.String Account_Domain { get; set; }
            public System.String Account_Dun { get; set; }
            public System.String Account_Industry { get; set; }
            public System.String Account_OtherIndustry { get; set; }
            public System.String Account_ParentCompanyName { get; set; }
            public System.String Account_WebsiteUrl { get; set; }
            public System.String Catalog { get; set; }
            public System.String Identifier { get; set; }
            public System.DateTime? LastModifiedDate { get; set; }
            public System.String PartnerAccountIdentifier { get; set; }
            public System.Func<Amazon.PartnerCentralSelling.Model.UpdateCustomerAccountResponse, UpdatePCCustomerAccountCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
