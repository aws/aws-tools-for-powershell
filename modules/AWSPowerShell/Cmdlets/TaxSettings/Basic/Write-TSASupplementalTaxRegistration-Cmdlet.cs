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
using Amazon.TaxSettings;
using Amazon.TaxSettings.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.TSA
{
    /// <summary>
    /// Stores supplemental tax registration for a single account.
    /// </summary>
    [Cmdlet("Write", "TSASupplementalTaxRegistration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.TaxSettings.Model.PutSupplementalTaxRegistrationResponse")]
    [AWSCmdlet("Calls the AWS Tax Settings PutSupplementalTaxRegistration API operation.", Operation = new[] {"PutSupplementalTaxRegistration"}, SelectReturnType = typeof(Amazon.TaxSettings.Model.PutSupplementalTaxRegistrationResponse))]
    [AWSCmdletOutput("Amazon.TaxSettings.Model.PutSupplementalTaxRegistrationResponse",
        "This cmdlet returns an Amazon.TaxSettings.Model.PutSupplementalTaxRegistrationResponse object containing multiple properties."
    )]
    public partial class WriteTSASupplementalTaxRegistrationCmdlet : AmazonTaxSettingsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Address_AddressLine1
        /// <summary>
        /// <para>
        /// <para>The first line of the address. </para>
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
        [Alias("TaxRegistrationEntry_Address_AddressLine1")]
        public System.String Address_AddressLine1 { get; set; }
        #endregion
        
        #region Parameter Address_AddressLine2
        /// <summary>
        /// <para>
        /// <para>The second line of the address, if applicable. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaxRegistrationEntry_Address_AddressLine2")]
        public System.String Address_AddressLine2 { get; set; }
        #endregion
        
        #region Parameter Address_AddressLine3
        /// <summary>
        /// <para>
        /// <para> The third line of the address, if applicable. Currently, the Tax Settings API accepts
        /// the <c>addressLine3</c> parameter only for Saudi Arabia. When you specify a TRN in
        /// Saudi Arabia, you must enter the <c>addressLine3</c> and specify the building number
        /// for the address. For example, you might enter <c>1234</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaxRegistrationEntry_Address_AddressLine3")]
        public System.String Address_AddressLine3 { get; set; }
        #endregion
        
        #region Parameter Address_City
        /// <summary>
        /// <para>
        /// <para>The city that the address is in. </para>
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
        [Alias("TaxRegistrationEntry_Address_City")]
        public System.String Address_City { get; set; }
        #endregion
        
        #region Parameter Address_CountryCode
        /// <summary>
        /// <para>
        /// <para>The country code for the country that the address is in. </para>
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
        [Alias("TaxRegistrationEntry_Address_CountryCode")]
        public System.String Address_CountryCode { get; set; }
        #endregion
        
        #region Parameter Address_DistrictOrCounty
        /// <summary>
        /// <para>
        /// <para>The district or county the address is located. </para><note><para>For addresses in Brazil, this parameter uses the name of the neighborhood. When you
        /// set a TRN in Brazil, use <c>districtOrCounty</c> for the neighborhood name.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaxRegistrationEntry_Address_DistrictOrCounty")]
        public System.String Address_DistrictOrCounty { get; set; }
        #endregion
        
        #region Parameter TaxRegistrationEntry_LegalName
        /// <summary>
        /// <para>
        /// <para> The legal name associated with your TRN registration. </para>
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
        public System.String TaxRegistrationEntry_LegalName { get; set; }
        #endregion
        
        #region Parameter Address_PostalCode
        /// <summary>
        /// <para>
        /// <para> The postal code associated with the address. </para>
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
        [Alias("TaxRegistrationEntry_Address_PostalCode")]
        public System.String Address_PostalCode { get; set; }
        #endregion
        
        #region Parameter TaxRegistrationEntry_RegistrationId
        /// <summary>
        /// <para>
        /// <para> The supplemental TRN unique identifier. </para>
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
        public System.String TaxRegistrationEntry_RegistrationId { get; set; }
        #endregion
        
        #region Parameter TaxRegistrationEntry_RegistrationType
        /// <summary>
        /// <para>
        /// <para> Type of supplemental TRN. Currently, this can only be VAT. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.TaxSettings.SupplementalTaxRegistrationType")]
        public Amazon.TaxSettings.SupplementalTaxRegistrationType TaxRegistrationEntry_RegistrationType { get; set; }
        #endregion
        
        #region Parameter Address_StateOrRegion
        /// <summary>
        /// <para>
        /// <para>The state, region, or province that the address is located. This field is only required
        /// for Canada, India, United Arab Emirates, Romania, and Brazil (CPF). It is optional
        /// for all other countries.</para><para>If this is required for tax settings, use the same name as shown on the <b>Tax Settings</b>
        /// page.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaxRegistrationEntry_Address_StateOrRegion")]
        public System.String Address_StateOrRegion { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.TaxSettings.Model.PutSupplementalTaxRegistrationResponse).
        /// Specifying the name of a property of type Amazon.TaxSettings.Model.PutSupplementalTaxRegistrationResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TaxRegistrationEntry_RegistrationId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-TSASupplementalTaxRegistration (PutSupplementalTaxRegistration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.TaxSettings.Model.PutSupplementalTaxRegistrationResponse, WriteTSASupplementalTaxRegistrationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Address_AddressLine1 = this.Address_AddressLine1;
            #if MODULAR
            if (this.Address_AddressLine1 == null && ParameterWasBound(nameof(this.Address_AddressLine1)))
            {
                WriteWarning("You are passing $null as a value for parameter Address_AddressLine1 which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Address_AddressLine2 = this.Address_AddressLine2;
            context.Address_AddressLine3 = this.Address_AddressLine3;
            context.Address_City = this.Address_City;
            #if MODULAR
            if (this.Address_City == null && ParameterWasBound(nameof(this.Address_City)))
            {
                WriteWarning("You are passing $null as a value for parameter Address_City which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Address_CountryCode = this.Address_CountryCode;
            #if MODULAR
            if (this.Address_CountryCode == null && ParameterWasBound(nameof(this.Address_CountryCode)))
            {
                WriteWarning("You are passing $null as a value for parameter Address_CountryCode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Address_DistrictOrCounty = this.Address_DistrictOrCounty;
            context.Address_PostalCode = this.Address_PostalCode;
            #if MODULAR
            if (this.Address_PostalCode == null && ParameterWasBound(nameof(this.Address_PostalCode)))
            {
                WriteWarning("You are passing $null as a value for parameter Address_PostalCode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Address_StateOrRegion = this.Address_StateOrRegion;
            context.TaxRegistrationEntry_LegalName = this.TaxRegistrationEntry_LegalName;
            #if MODULAR
            if (this.TaxRegistrationEntry_LegalName == null && ParameterWasBound(nameof(this.TaxRegistrationEntry_LegalName)))
            {
                WriteWarning("You are passing $null as a value for parameter TaxRegistrationEntry_LegalName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TaxRegistrationEntry_RegistrationId = this.TaxRegistrationEntry_RegistrationId;
            #if MODULAR
            if (this.TaxRegistrationEntry_RegistrationId == null && ParameterWasBound(nameof(this.TaxRegistrationEntry_RegistrationId)))
            {
                WriteWarning("You are passing $null as a value for parameter TaxRegistrationEntry_RegistrationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TaxRegistrationEntry_RegistrationType = this.TaxRegistrationEntry_RegistrationType;
            #if MODULAR
            if (this.TaxRegistrationEntry_RegistrationType == null && ParameterWasBound(nameof(this.TaxRegistrationEntry_RegistrationType)))
            {
                WriteWarning("You are passing $null as a value for parameter TaxRegistrationEntry_RegistrationType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.TaxSettings.Model.PutSupplementalTaxRegistrationRequest();
            
            
             // populate TaxRegistrationEntry
            var requestTaxRegistrationEntryIsNull = true;
            request.TaxRegistrationEntry = new Amazon.TaxSettings.Model.SupplementalTaxRegistrationEntry();
            System.String requestTaxRegistrationEntry_taxRegistrationEntry_LegalName = null;
            if (cmdletContext.TaxRegistrationEntry_LegalName != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_LegalName = cmdletContext.TaxRegistrationEntry_LegalName;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_LegalName != null)
            {
                request.TaxRegistrationEntry.LegalName = requestTaxRegistrationEntry_taxRegistrationEntry_LegalName;
                requestTaxRegistrationEntryIsNull = false;
            }
            System.String requestTaxRegistrationEntry_taxRegistrationEntry_RegistrationId = null;
            if (cmdletContext.TaxRegistrationEntry_RegistrationId != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_RegistrationId = cmdletContext.TaxRegistrationEntry_RegistrationId;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_RegistrationId != null)
            {
                request.TaxRegistrationEntry.RegistrationId = requestTaxRegistrationEntry_taxRegistrationEntry_RegistrationId;
                requestTaxRegistrationEntryIsNull = false;
            }
            Amazon.TaxSettings.SupplementalTaxRegistrationType requestTaxRegistrationEntry_taxRegistrationEntry_RegistrationType = null;
            if (cmdletContext.TaxRegistrationEntry_RegistrationType != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_RegistrationType = cmdletContext.TaxRegistrationEntry_RegistrationType;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_RegistrationType != null)
            {
                request.TaxRegistrationEntry.RegistrationType = requestTaxRegistrationEntry_taxRegistrationEntry_RegistrationType;
                requestTaxRegistrationEntryIsNull = false;
            }
            Amazon.TaxSettings.Model.Address requestTaxRegistrationEntry_taxRegistrationEntry_Address = null;
            
             // populate Address
            var requestTaxRegistrationEntry_taxRegistrationEntry_AddressIsNull = true;
            requestTaxRegistrationEntry_taxRegistrationEntry_Address = new Amazon.TaxSettings.Model.Address();
            System.String requestTaxRegistrationEntry_taxRegistrationEntry_Address_address_AddressLine1 = null;
            if (cmdletContext.Address_AddressLine1 != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_Address_address_AddressLine1 = cmdletContext.Address_AddressLine1;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_Address_address_AddressLine1 != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_Address.AddressLine1 = requestTaxRegistrationEntry_taxRegistrationEntry_Address_address_AddressLine1;
                requestTaxRegistrationEntry_taxRegistrationEntry_AddressIsNull = false;
            }
            System.String requestTaxRegistrationEntry_taxRegistrationEntry_Address_address_AddressLine2 = null;
            if (cmdletContext.Address_AddressLine2 != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_Address_address_AddressLine2 = cmdletContext.Address_AddressLine2;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_Address_address_AddressLine2 != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_Address.AddressLine2 = requestTaxRegistrationEntry_taxRegistrationEntry_Address_address_AddressLine2;
                requestTaxRegistrationEntry_taxRegistrationEntry_AddressIsNull = false;
            }
            System.String requestTaxRegistrationEntry_taxRegistrationEntry_Address_address_AddressLine3 = null;
            if (cmdletContext.Address_AddressLine3 != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_Address_address_AddressLine3 = cmdletContext.Address_AddressLine3;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_Address_address_AddressLine3 != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_Address.AddressLine3 = requestTaxRegistrationEntry_taxRegistrationEntry_Address_address_AddressLine3;
                requestTaxRegistrationEntry_taxRegistrationEntry_AddressIsNull = false;
            }
            System.String requestTaxRegistrationEntry_taxRegistrationEntry_Address_address_City = null;
            if (cmdletContext.Address_City != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_Address_address_City = cmdletContext.Address_City;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_Address_address_City != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_Address.City = requestTaxRegistrationEntry_taxRegistrationEntry_Address_address_City;
                requestTaxRegistrationEntry_taxRegistrationEntry_AddressIsNull = false;
            }
            System.String requestTaxRegistrationEntry_taxRegistrationEntry_Address_address_CountryCode = null;
            if (cmdletContext.Address_CountryCode != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_Address_address_CountryCode = cmdletContext.Address_CountryCode;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_Address_address_CountryCode != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_Address.CountryCode = requestTaxRegistrationEntry_taxRegistrationEntry_Address_address_CountryCode;
                requestTaxRegistrationEntry_taxRegistrationEntry_AddressIsNull = false;
            }
            System.String requestTaxRegistrationEntry_taxRegistrationEntry_Address_address_DistrictOrCounty = null;
            if (cmdletContext.Address_DistrictOrCounty != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_Address_address_DistrictOrCounty = cmdletContext.Address_DistrictOrCounty;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_Address_address_DistrictOrCounty != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_Address.DistrictOrCounty = requestTaxRegistrationEntry_taxRegistrationEntry_Address_address_DistrictOrCounty;
                requestTaxRegistrationEntry_taxRegistrationEntry_AddressIsNull = false;
            }
            System.String requestTaxRegistrationEntry_taxRegistrationEntry_Address_address_PostalCode = null;
            if (cmdletContext.Address_PostalCode != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_Address_address_PostalCode = cmdletContext.Address_PostalCode;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_Address_address_PostalCode != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_Address.PostalCode = requestTaxRegistrationEntry_taxRegistrationEntry_Address_address_PostalCode;
                requestTaxRegistrationEntry_taxRegistrationEntry_AddressIsNull = false;
            }
            System.String requestTaxRegistrationEntry_taxRegistrationEntry_Address_address_StateOrRegion = null;
            if (cmdletContext.Address_StateOrRegion != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_Address_address_StateOrRegion = cmdletContext.Address_StateOrRegion;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_Address_address_StateOrRegion != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_Address.StateOrRegion = requestTaxRegistrationEntry_taxRegistrationEntry_Address_address_StateOrRegion;
                requestTaxRegistrationEntry_taxRegistrationEntry_AddressIsNull = false;
            }
             // determine if requestTaxRegistrationEntry_taxRegistrationEntry_Address should be set to null
            if (requestTaxRegistrationEntry_taxRegistrationEntry_AddressIsNull)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_Address = null;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_Address != null)
            {
                request.TaxRegistrationEntry.Address = requestTaxRegistrationEntry_taxRegistrationEntry_Address;
                requestTaxRegistrationEntryIsNull = false;
            }
             // determine if request.TaxRegistrationEntry should be set to null
            if (requestTaxRegistrationEntryIsNull)
            {
                request.TaxRegistrationEntry = null;
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
        
        private Amazon.TaxSettings.Model.PutSupplementalTaxRegistrationResponse CallAWSServiceOperation(IAmazonTaxSettings client, Amazon.TaxSettings.Model.PutSupplementalTaxRegistrationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Tax Settings", "PutSupplementalTaxRegistration");
            try
            {
                return client.PutSupplementalTaxRegistrationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Address_AddressLine1 { get; set; }
            public System.String Address_AddressLine2 { get; set; }
            public System.String Address_AddressLine3 { get; set; }
            public System.String Address_City { get; set; }
            public System.String Address_CountryCode { get; set; }
            public System.String Address_DistrictOrCounty { get; set; }
            public System.String Address_PostalCode { get; set; }
            public System.String Address_StateOrRegion { get; set; }
            public System.String TaxRegistrationEntry_LegalName { get; set; }
            public System.String TaxRegistrationEntry_RegistrationId { get; set; }
            public Amazon.TaxSettings.SupplementalTaxRegistrationType TaxRegistrationEntry_RegistrationType { get; set; }
            public System.Func<Amazon.TaxSettings.Model.PutSupplementalTaxRegistrationResponse, WriteTSASupplementalTaxRegistrationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
