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

namespace Amazon.PowerShell.Cmdlets.TSA
{
    /// <summary>
    /// Adds or updates tax registration for a single account. You can't set a TRN if there's
    /// a pending TRN. You'll need to delete the pending TRN first.
    /// 
    ///  
    /// <para>
    /// To call this API operation for specific countries, see the following country-specific
    /// requirements.
    /// </para><para><b>Bangladesh</b></para><ul><li><para>
    /// You must specify the tax registration certificate document in the <c>taxRegistrationDocuments</c>
    /// field of the <c>VerificationDetails</c> object.
    /// </para></li></ul><para><b>Brazil</b></para><ul><li><para>
    /// You must complete the tax registration process in the <a href="https://console.aws.amazon.com/billing/home#/paymentpreferences/paymentmethods">Payment
    /// preferences</a> page in the Billing and Cost Management console. After your TRN and
    /// billing address are verified, you can call this API operation.
    /// </para></li><li><para>
    /// For Amazon Web Services accounts created through Organizations, you can call this
    /// API operation when you don't have a billing address.
    /// </para></li></ul><para><b>Georgia</b></para><ul><li><para>
    /// The valid <c>personType</c> values are <c>Physical Person</c> and <c>Business</c>.
    /// </para></li></ul><para><b>Kenya</b></para><ul><li><para>
    /// You must specify the <c>personType</c> in the <c>kenyaAdditionalInfo</c> field of
    /// the <c>additionalTaxInformation</c> object.
    /// </para></li><li><para>
    /// If the <c>personType</c> is <c>Physical Person</c>, you must specify the tax registration
    /// certificate document in the <c>taxRegistrationDocuments</c> field of the <c>VerificationDetails</c>
    /// object.
    /// </para></li></ul><para><b>Malaysia</b></para><ul><li><para>
    /// The sector valid values are <c>Business</c> and <c>Individual</c>.
    /// </para></li><li><para><c>RegistrationType</c> valid values are <c>NRIC</c> for individual, and TIN and
    /// sales and service tax (SST) for Business.
    /// </para></li><li><para>
    /// For individual, you can specify the <c>taxInformationNumber</c> in <c>MalaysiaAdditionalInfo</c>
    /// with NRIC type, and a valid <c>MyKad</c> or NRIC number.
    /// </para></li><li><para>
    /// For business, you must specify a <c>businessRegistrationNumber</c> in <c>MalaysiaAdditionalInfo</c>
    /// with a TIN type and tax identification number.
    /// </para></li><li><para>
    /// For business resellers, you must specify a <c>businessRegistrationNumber</c> and <c>taxInformationNumber</c>
    /// in <c>MalaysiaAdditionalInfo</c> with a sales and service tax (SST) type and a valid
    /// SST number.
    /// </para></li><li><para>
    /// For business resellers with service codes, you must specify <c>businessRegistrationNumber</c>,
    /// <c>taxInformationNumber</c>, and distinct <c>serviceTaxCodes</c> in <c>MalaysiaAdditionalInfo</c>
    /// with a SST type and valid sales and service tax (SST) number. By using this API operation,
    /// Amazon Web Services registers your self-declaration that you’re an authorized business
    /// reseller registered with the Royal Malaysia Customs Department (RMCD), and have a
    /// valid SST number.
    /// </para></li><li><para>
    /// Amazon Web Services reserves the right to seek additional information and/or take
    /// other actions to support your self-declaration as appropriate.
    /// </para></li><li><para>
    /// Amazon Web Services is currently registered under the following service tax codes.
    /// You must include at least one of the service tax codes in the service tax code strings
    /// to declare yourself as an authorized registered business reseller.
    /// </para><para>
    /// Taxable service and service tax codes:
    /// </para><para>
    /// Consultancy - 9907061674
    /// </para><para>
    /// Training or coaching service - 9907071685
    /// </para><para>
    /// IT service - 9907101676
    /// </para><para>
    /// Digital services and electronic medium - 9907121690
    /// </para></li></ul><para><b>Nepal</b></para><ul><li><para>
    /// The sector valid values are <c>Business</c> and <c>Individual</c>.
    /// </para></li></ul><para><b>Saudi Arabia</b></para><ul><li><para>
    /// For <c>address</c>, you must specify <c>addressLine3</c>.
    /// </para></li></ul><para><b>South Korea</b></para><ul><li><para>
    /// You must specify the <c>certifiedEmailId</c> and <c>legalName</c> in the <c>TaxRegistrationEntry</c>
    /// object. Use Korean characters for <c>legalName</c>.
    /// </para></li><li><para>
    /// You must specify the <c>businessRepresentativeName</c>, <c>itemOfBusiness</c>, and
    /// <c>lineOfBusiness</c> in the <c>southKoreaAdditionalInfo</c> field of the <c>additionalTaxInformation</c>
    /// object. Use Korean characters for these fields.
    /// </para></li><li><para>
    /// You must specify the tax registration certificate document in the <c>taxRegistrationDocuments</c>
    /// field of the <c>VerificationDetails</c> object.
    /// </para></li><li><para>
    /// For the <c>address</c> object, use Korean characters for <c>addressLine1</c>, <c>addressLine2</c><c>city</c>, <c>postalCode</c>, and <c>stateOrRegion</c>.
    /// </para></li></ul><para><b>Spain</b></para><ul><li><para>
    /// You must specify the <c>registrationType</c> in the <c>spainAdditionalInfo</c> field
    /// of the <c>additionalTaxInformation</c> object.
    /// </para></li><li><para>
    /// If the <c>registrationType</c> is <c>Local</c>, you must specify the tax registration
    /// certificate document in the <c>taxRegistrationDocuments</c> field of the <c>VerificationDetails</c>
    /// object.
    /// </para></li></ul><para><b>Turkey</b></para><ul><li><para>
    /// You must specify the <c>sector</c> in the <c>taxRegistrationEntry</c> object.
    /// </para></li><li><para>
    /// If your <c>sector</c> is <c>Business</c>, <c>Individual</c>, or <c>Government</c>:
    /// </para><ul><li><para>
    /// Specify the <c>taxOffice</c>. If your <c>sector</c> is <c>Individual</c>, don't enter
    /// this value.
    /// </para></li><li><para>
    /// (Optional) Specify the <c>kepEmailId</c>. If your <c>sector</c> is <c>Individual</c>,
    /// don't enter this value.
    /// </para></li><li><para><b>Note:</b> In the <b>Tax Settings</b> page of the Billing console, <c>Government</c>
    /// appears as <b>Public institutions</b></para></li></ul></li><li><para>
    /// If your <c>sector</c> is <c>Business</c> and you're subject to KDV tax, you must specify
    /// your industry in the <c>industries</c> field.
    /// </para></li><li><para>
    /// For <c>address</c>, you must specify <c>districtOrCounty</c>.
    /// </para></li></ul><para><b>Ukraine</b></para><ul><li><para>
    /// The sector valid values are <c>Business</c> and <c>Individual</c>.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Write", "TSATaxRegistration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.TaxSettings.TaxRegistrationStatus")]
    [AWSCmdlet("Calls the AWS Tax Settings PutTaxRegistration API operation.", Operation = new[] {"PutTaxRegistration"}, SelectReturnType = typeof(Amazon.TaxSettings.Model.PutTaxRegistrationResponse))]
    [AWSCmdletOutput("Amazon.TaxSettings.TaxRegistrationStatus or Amazon.TaxSettings.Model.PutTaxRegistrationResponse",
        "This cmdlet returns an Amazon.TaxSettings.TaxRegistrationStatus object.",
        "The service call response (type Amazon.TaxSettings.Model.PutTaxRegistrationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class WriteTSATaxRegistrationCmdlet : AmazonTaxSettingsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// <para>Your unique account identifier. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AccountId { get; set; }
        #endregion
        
        #region Parameter LegalAddress_AddressLine1
        /// <summary>
        /// <para>
        /// <para>The first line of the address. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaxRegistrationEntry_LegalAddress_AddressLine1")]
        public System.String LegalAddress_AddressLine1 { get; set; }
        #endregion
        
        #region Parameter LegalAddress_AddressLine2
        /// <summary>
        /// <para>
        /// <para>The second line of the address, if applicable. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaxRegistrationEntry_LegalAddress_AddressLine2")]
        public System.String LegalAddress_AddressLine2 { get; set; }
        #endregion
        
        #region Parameter LegalAddress_AddressLine3
        /// <summary>
        /// <para>
        /// <para> The third line of the address, if applicable. Currently, the Tax Settings API accepts
        /// the <c>addressLine3</c> parameter only for Saudi Arabia. When you specify a TRN in
        /// Saudi Arabia, you must enter the <c>addressLine3</c> and specify the building number
        /// for the address. For example, you might enter <c>1234</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaxRegistrationEntry_LegalAddress_AddressLine3")]
        public System.String LegalAddress_AddressLine3 { get; set; }
        #endregion
        
        #region Parameter MalaysiaAdditionalInfo_BusinessRegistrationNumber
        /// <summary>
        /// <para>
        /// <para>The tax registration number (TRN) in Malaysia. </para><para>For individual, you can specify the <c>taxInformationNumber</c> in <c>MalaysiaAdditionalInfo</c>
        /// with NRIC type, and a valid MyKad or NRIC number. For business, you must specify a
        /// <c>businessRegistrationNumber</c> in <c>MalaysiaAdditionalInfo</c> with a TIN type
        /// and tax identification number. For business resellers, you must specify a <c>businessRegistrationNumber</c>
        /// and <c>taxInformationNumber</c> in <c>MalaysiaAdditionalInfo</c> with a sales and
        /// service tax (SST) type and a valid SST number. </para><para>For business resellers with service codes, you must specify <c>businessRegistrationNumber</c>,
        /// <c>taxInformationNumber</c>, and distinct <c>serviceTaxCodes</c> in <c>MalaysiaAdditionalInfo</c>
        /// with a SST type and valid sales and service tax (SST) number. By using this API operation,
        /// Amazon Web Services registers your self-declaration that you’re an authorized business
        /// reseller registered with the Royal Malaysia Customs Department (RMCD), and have a
        /// valid SST number.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaxRegistrationEntry_AdditionalTaxInformation_MalaysiaAdditionalInfo_BusinessRegistrationNumber")]
        public System.String MalaysiaAdditionalInfo_BusinessRegistrationNumber { get; set; }
        #endregion
        
        #region Parameter SouthKoreaAdditionalInfo_BusinessRepresentativeName
        /// <summary>
        /// <para>
        /// <para>The business legal name based on the most recently uploaded tax registration certificate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaxRegistrationEntry_AdditionalTaxInformation_SouthKoreaAdditionalInfo_BusinessRepresentativeName")]
        public System.String SouthKoreaAdditionalInfo_BusinessRepresentativeName { get; set; }
        #endregion
        
        #region Parameter CanadaAdditionalInfo_CanadaQuebecSalesTaxNumber
        /// <summary>
        /// <para>
        /// <para> The Quebec Sales Tax ID number. Leave blank if you do not have a Quebec Sales Tax
        /// ID number. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaxRegistrationEntry_AdditionalTaxInformation_CanadaAdditionalInfo_CanadaQuebecSalesTaxNumber")]
        public System.String CanadaAdditionalInfo_CanadaQuebecSalesTaxNumber { get; set; }
        #endregion
        
        #region Parameter CanadaAdditionalInfo_CanadaRetailSalesTaxNumber
        /// <summary>
        /// <para>
        /// <para> Manitoba Retail Sales Tax ID number. Customers purchasing Amazon Web Services services
        /// for resale in Manitoba must provide a valid Retail Sales Tax ID number for Manitoba.
        /// Leave this blank if you do not have a Retail Sales Tax ID number in Manitoba or are
        /// not purchasing Amazon Web Services services for resale. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaxRegistrationEntry_AdditionalTaxInformation_CanadaAdditionalInfo_CanadaRetailSalesTaxNumber")]
        public System.String CanadaAdditionalInfo_CanadaRetailSalesTaxNumber { get; set; }
        #endregion
        
        #region Parameter TaxRegistrationEntry_CertifiedEmailId
        /// <summary>
        /// <para>
        /// <para>The email address to receive VAT invoices.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TaxRegistrationEntry_CertifiedEmailId { get; set; }
        #endregion
        
        #region Parameter ItalyAdditionalInfo_CigNumber
        /// <summary>
        /// <para>
        /// <para> The tender procedure identification code. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaxRegistrationEntry_AdditionalTaxInformation_ItalyAdditionalInfo_CigNumber")]
        public System.String ItalyAdditionalInfo_CigNumber { get; set; }
        #endregion
        
        #region Parameter LegalAddress_City
        /// <summary>
        /// <para>
        /// <para>The city that the address is in. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaxRegistrationEntry_LegalAddress_City")]
        public System.String LegalAddress_City { get; set; }
        #endregion
        
        #region Parameter GreeceAdditionalInfo_ContractingAuthorityCode
        /// <summary>
        /// <para>
        /// <para>The code of contracting authority for e-invoicing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaxRegistrationEntry_AdditionalTaxInformation_GreeceAdditionalInfo_ContractingAuthorityCode")]
        public System.String GreeceAdditionalInfo_ContractingAuthorityCode { get; set; }
        #endregion
        
        #region Parameter LegalAddress_CountryCode
        /// <summary>
        /// <para>
        /// <para>The country code for the country that the address is in. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaxRegistrationEntry_LegalAddress_CountryCode")]
        public System.String LegalAddress_CountryCode { get; set; }
        #endregion
        
        #region Parameter ItalyAdditionalInfo_CupNumber
        /// <summary>
        /// <para>
        /// <para> Additional tax information to specify for a TRN in Italy. This is managed by the
        /// Interministerial Committee for Economic Planning (CIPE) which characterizes every
        /// public investment project (Individual Project Code). </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaxRegistrationEntry_AdditionalTaxInformation_ItalyAdditionalInfo_CupNumber")]
        public System.String ItalyAdditionalInfo_CupNumber { get; set; }
        #endregion
        
        #region Parameter IsraelAdditionalInfo_CustomerType
        /// <summary>
        /// <para>
        /// <para> Customer type for your TRN in Israel. The value can be <c>Business</c> or <c>Individual</c>.
        /// Use <c>Business</c>for entities such as not-for-profit and financial institutions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaxRegistrationEntry_AdditionalTaxInformation_IsraelAdditionalInfo_CustomerType")]
        [AWSConstantClassSource("Amazon.TaxSettings.IsraelCustomerType")]
        public Amazon.TaxSettings.IsraelCustomerType IsraelAdditionalInfo_CustomerType { get; set; }
        #endregion
        
        #region Parameter VerificationDetails_DateOfBirth
        /// <summary>
        /// <para>
        /// <para>Date of birth to verify your submitted TRN. Use the <c>YYYY-MM-DD</c> format.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaxRegistrationEntry_VerificationDetails_DateOfBirth")]
        public System.String VerificationDetails_DateOfBirth { get; set; }
        #endregion
        
        #region Parameter IsraelAdditionalInfo_DealerType
        /// <summary>
        /// <para>
        /// <para> Dealer type for your TRN in Israel. If you're not a local authorized dealer with
        /// an Israeli VAT ID, specify your tax identification number so that Amazon Web Services
        /// can send you a compliant tax invoice.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaxRegistrationEntry_AdditionalTaxInformation_IsraelAdditionalInfo_DealerType")]
        [AWSConstantClassSource("Amazon.TaxSettings.IsraelDealerType")]
        public Amazon.TaxSettings.IsraelDealerType IsraelAdditionalInfo_DealerType { get; set; }
        #endregion
        
        #region Parameter LegalAddress_DistrictOrCounty
        /// <summary>
        /// <para>
        /// <para>The district or county the address is located. </para><note><para>For addresses in Brazil, this parameter uses the name of the neighborhood. When you
        /// set a TRN in Brazil, use <c>districtOrCounty</c> for the neighborhood name.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaxRegistrationEntry_LegalAddress_DistrictOrCounty")]
        public System.String LegalAddress_DistrictOrCounty { get; set; }
        #endregion
        
        #region Parameter VietnamAdditionalInfo_ElectronicTransactionCodeNumber
        /// <summary>
        /// <para>
        /// <para>The electronic transaction code number on the tax return document. This field must
        /// be provided for successful API operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaxRegistrationEntry_AdditionalTaxInformation_VietnamAdditionalInfo_ElectronicTransactionCodeNumber")]
        public System.String VietnamAdditionalInfo_ElectronicTransactionCodeNumber { get; set; }
        #endregion
        
        #region Parameter VietnamAdditionalInfo_EnterpriseIdentificationNumber
        /// <summary>
        /// <para>
        /// <para>The enterprise identification number for tax registration. This field must be provided
        /// for successful API operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaxRegistrationEntry_AdditionalTaxInformation_VietnamAdditionalInfo_EnterpriseIdentificationNumber")]
        public System.String VietnamAdditionalInfo_EnterpriseIdentificationNumber { get; set; }
        #endregion
        
        #region Parameter PolandAdditionalInfo_IndividualRegistrationNumber
        /// <summary>
        /// <para>
        /// <para> The individual tax registration number (NIP). Individual NIP is valid for other taxes
        /// excluding VAT purposes. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaxRegistrationEntry_AdditionalTaxInformation_PolandAdditionalInfo_IndividualRegistrationNumber")]
        public System.String PolandAdditionalInfo_IndividualRegistrationNumber { get; set; }
        #endregion
        
        #region Parameter TurkeyAdditionalInfo_Industry
        /// <summary>
        /// <para>
        /// <para>The industry information that tells the Tax Settings API if you're subject to additional
        /// withholding taxes. This information required for business-to-business (B2B) customers.
        /// This information is conditionally mandatory for B2B customers who are subject to KDV
        /// tax.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaxRegistrationEntry_AdditionalTaxInformation_TurkeyAdditionalInfo_Industries")]
        [AWSConstantClassSource("Amazon.TaxSettings.Industries")]
        public Amazon.TaxSettings.Industries TurkeyAdditionalInfo_Industry { get; set; }
        #endregion
        
        #region Parameter PolandAdditionalInfo_IsGroupVatEnabled
        /// <summary>
        /// <para>
        /// <para> True if your business is a member of a VAT group with a NIP active for VAT purposes.
        /// Otherwise, this is false. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaxRegistrationEntry_AdditionalTaxInformation_PolandAdditionalInfo_IsGroupVatEnabled")]
        public System.Boolean? PolandAdditionalInfo_IsGroupVatEnabled { get; set; }
        #endregion
        
        #region Parameter CanadaAdditionalInfo_IsResellerAccount
        /// <summary>
        /// <para>
        /// <para> The value for this parameter must be <c>true</c> if the <c>provincialSalesTaxId</c>
        /// value is provided for a TRN in British Columbia, Saskatchewan, or Manitoba provinces.
        /// </para><para>To claim a provincial sales tax (PST) and retail sales tax (RST) reseller exemption,
        /// you must confirm that purchases from this account were made for resale. Otherwise,
        /// remove the PST or RST number from the <c>provincialSalesTaxId</c> parameter from your
        /// request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaxRegistrationEntry_AdditionalTaxInformation_CanadaAdditionalInfo_IsResellerAccount")]
        public System.Boolean? CanadaAdditionalInfo_IsResellerAccount { get; set; }
        #endregion
        
        #region Parameter SouthKoreaAdditionalInfo_ItemOfBusiness
        /// <summary>
        /// <para>
        /// <para>Item of business based on the most recently uploaded tax registration certificate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaxRegistrationEntry_AdditionalTaxInformation_SouthKoreaAdditionalInfo_ItemOfBusiness")]
        public System.String SouthKoreaAdditionalInfo_ItemOfBusiness { get; set; }
        #endregion
        
        #region Parameter TurkeyAdditionalInfo_KepEmailId
        /// <summary>
        /// <para>
        /// <para>The Registered Electronic Mail (REM) that is used to send notarized communication.
        /// This parameter is optional for business-to-business (B2B) and business-to-government
        /// (B2G) customers. It's not required for business-to-consumer (B2C) customers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaxRegistrationEntry_AdditionalTaxInformation_TurkeyAdditionalInfo_KepEmailId")]
        public System.String TurkeyAdditionalInfo_KepEmailId { get; set; }
        #endregion
        
        #region Parameter TaxRegistrationEntry_LegalName
        /// <summary>
        /// <para>
        /// <para>The legal name associated with your TRN. </para><note><para>If you're setting a TRN in Brazil, you don't need to specify the legal name. For TRNs
        /// in other countries, you must specify the legal name.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TaxRegistrationEntry_LegalName { get; set; }
        #endregion
        
        #region Parameter SouthKoreaAdditionalInfo_LineOfBusiness
        /// <summary>
        /// <para>
        /// <para>Line of business based on the most recently uploaded tax registration certificate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaxRegistrationEntry_AdditionalTaxInformation_SouthKoreaAdditionalInfo_LineOfBusiness")]
        public System.String SouthKoreaAdditionalInfo_LineOfBusiness { get; set; }
        #endregion
        
        #region Parameter VietnamAdditionalInfo_PaymentVoucherNumber
        /// <summary>
        /// <para>
        /// <para>The payment voucher number on the tax return payment document. This field must be
        /// provided for successful API operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaxRegistrationEntry_AdditionalTaxInformation_VietnamAdditionalInfo_PaymentVoucherNumber")]
        public System.String VietnamAdditionalInfo_PaymentVoucherNumber { get; set; }
        #endregion
        
        #region Parameter VietnamAdditionalInfo_PaymentVoucherNumberDate
        /// <summary>
        /// <para>
        /// <para>The date on the tax return payment document. This field must be provided for successful
        /// API operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaxRegistrationEntry_AdditionalTaxInformation_VietnamAdditionalInfo_PaymentVoucherNumberDate")]
        public System.String VietnamAdditionalInfo_PaymentVoucherNumberDate { get; set; }
        #endregion
        
        #region Parameter GeorgiaAdditionalInfo_PersonType
        /// <summary>
        /// <para>
        /// <para> The legal person or physical person assigned to this TRN in Georgia. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaxRegistrationEntry_AdditionalTaxInformation_GeorgiaAdditionalInfo_PersonType")]
        [AWSConstantClassSource("Amazon.TaxSettings.PersonType")]
        public Amazon.TaxSettings.PersonType GeorgiaAdditionalInfo_PersonType { get; set; }
        #endregion
        
        #region Parameter KenyaAdditionalInfo_PersonType
        /// <summary>
        /// <para>
        /// <para>The legal person or physical person assigned to this TRN in Kenya.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaxRegistrationEntry_AdditionalTaxInformation_KenyaAdditionalInfo_PersonType")]
        [AWSConstantClassSource("Amazon.TaxSettings.PersonType")]
        public Amazon.TaxSettings.PersonType KenyaAdditionalInfo_PersonType { get; set; }
        #endregion
        
        #region Parameter LegalAddress_PostalCode
        /// <summary>
        /// <para>
        /// <para> The postal code associated with the address. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaxRegistrationEntry_LegalAddress_PostalCode")]
        public System.String LegalAddress_PostalCode { get; set; }
        #endregion
        
        #region Parameter CanadaAdditionalInfo_ProvincialSalesTaxId
        /// <summary>
        /// <para>
        /// <para> The provincial sales tax ID for your TRN in Canada. This parameter can represent
        /// the following: </para><ul><li><para>Provincial sales tax ID number for British Columbia and Saskatchewan provinces</para></li><li><para>Manitoba retail sales tax ID number for Manitoba province</para></li><li><para>Quebec sales tax ID number for Quebec province</para></li></ul><para>The Tax Setting API only accepts this parameter if the TRN is specified for the previous
        /// provinces. For other provinces, the Tax Settings API doesn't accept this parameter.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaxRegistrationEntry_AdditionalTaxInformation_CanadaAdditionalInfo_ProvincialSalesTaxId")]
        public System.String CanadaAdditionalInfo_ProvincialSalesTaxId { get; set; }
        #endregion
        
        #region Parameter TaxRegistrationEntry_RegistrationId
        /// <summary>
        /// <para>
        /// <para>Your tax registration unique identifier. </para>
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
        public System.String TaxRegistrationEntry_RegistrationId { get; set; }
        #endregion
        
        #region Parameter SpainAdditionalInfo_RegistrationType
        /// <summary>
        /// <para>
        /// <para>The registration type in Spain.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaxRegistrationEntry_AdditionalTaxInformation_SpainAdditionalInfo_RegistrationType")]
        [AWSConstantClassSource("Amazon.TaxSettings.RegistrationType")]
        public Amazon.TaxSettings.RegistrationType SpainAdditionalInfo_RegistrationType { get; set; }
        #endregion
        
        #region Parameter TaxRegistrationEntry_RegistrationType
        /// <summary>
        /// <para>
        /// <para> Your tax registration type. This can be either <c>VAT</c> or <c>GST</c>. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.TaxSettings.TaxRegistrationType")]
        public Amazon.TaxSettings.TaxRegistrationType TaxRegistrationEntry_RegistrationType { get; set; }
        #endregion
        
        #region Parameter EstoniaAdditionalInfo_RegistryCommercialCode
        /// <summary>
        /// <para>
        /// <para> Registry commercial code (RCC) for your TRN in Estonia. This value is an eight-numeric
        /// string, such as <c>12345678</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaxRegistrationEntry_AdditionalTaxInformation_EstoniaAdditionalInfo_RegistryCommercialCode")]
        public System.String EstoniaAdditionalInfo_RegistryCommercialCode { get; set; }
        #endregion
        
        #region Parameter ItalyAdditionalInfo_SdiAccountId
        /// <summary>
        /// <para>
        /// <para> Additional tax information to specify for a TRN in Italy. Use CodiceDestinatario
        /// to receive your invoices via web service (API) or FTP. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaxRegistrationEntry_AdditionalTaxInformation_ItalyAdditionalInfo_SdiAccountId")]
        public System.String ItalyAdditionalInfo_SdiAccountId { get; set; }
        #endregion
        
        #region Parameter TurkeyAdditionalInfo_SecondaryTaxId
        /// <summary>
        /// <para>
        /// <para> Secondary tax ID (“harcama birimi VKN”si”). If one isn't provided, we will use your
        /// VKN as the secondary ID. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaxRegistrationEntry_AdditionalTaxInformation_TurkeyAdditionalInfo_SecondaryTaxId")]
        public System.String TurkeyAdditionalInfo_SecondaryTaxId { get; set; }
        #endregion
        
        #region Parameter TaxRegistrationEntry_Sector
        /// <summary>
        /// <para>
        /// <para>The industry that describes your business. For business-to-business (B2B) customers,
        /// specify Business. For business-to-consumer (B2C) customers, specify Individual. For
        /// business-to-government (B2G), specify Government.Note that certain values may not
        /// applicable for the request country. Please refer to country specific information in
        /// API document. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.TaxSettings.Sector")]
        public Amazon.TaxSettings.Sector TaxRegistrationEntry_Sector { get; set; }
        #endregion
        
        #region Parameter MalaysiaAdditionalInfo_ServiceTaxCode
        /// <summary>
        /// <para>
        /// <para>List of service tax codes for your TRN in Malaysia.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaxRegistrationEntry_AdditionalTaxInformation_MalaysiaAdditionalInfo_ServiceTaxCodes")]
        public System.String[] MalaysiaAdditionalInfo_ServiceTaxCode { get; set; }
        #endregion
        
        #region Parameter LegalAddress_StateOrRegion
        /// <summary>
        /// <para>
        /// <para>The state, region, or province that the address is located. This field is only required
        /// for Canada, India, United Arab Emirates, Romania, and Brazil (CPF). It is optional
        /// for all other countries.</para><para>If this is required for tax settings, use the same name as shown on the <b>Tax Settings</b>
        /// page.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaxRegistrationEntry_LegalAddress_StateOrRegion")]
        public System.String LegalAddress_StateOrRegion { get; set; }
        #endregion
        
        #region Parameter ItalyAdditionalInfo_TaxCode
        /// <summary>
        /// <para>
        /// <para>List of service tax codes for your TRN in Italy. You can use your customer tax code
        /// as part of a VAT Group. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaxRegistrationEntry_AdditionalTaxInformation_ItalyAdditionalInfo_TaxCode")]
        public System.String ItalyAdditionalInfo_TaxCode { get; set; }
        #endregion
        
        #region Parameter MalaysiaAdditionalInfo_TaxInformationNumber
        /// <summary>
        /// <para>
        /// <para>The tax information number in Malaysia. </para><para>For individual, you can specify the <c>taxInformationNumber</c> in <c>MalaysiaAdditionalInfo</c>
        /// with NRIC type, and a valid MyKad or NRIC number. For business resellers, you must
        /// specify a <c>businessRegistrationNumber</c> and <c>taxInformationNumber</c> in <c>MalaysiaAdditionalInfo</c>
        /// with a sales and service tax (SST) type and a valid SST number. </para><para>For business resellers with service codes, you must specify <c>businessRegistrationNumber</c>,
        /// <c>taxInformationNumber</c>, and distinct <c>serviceTaxCodes</c> in <c>MalaysiaAdditionalInfo</c>
        /// with a SST type and valid sales and service tax (SST) number. By using this API operation,
        /// Amazon Web Services registers your self-declaration that you’re an authorized business
        /// reseller registered with the Royal Malaysia Customs Department (RMCD), and have a
        /// valid SST number.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaxRegistrationEntry_AdditionalTaxInformation_MalaysiaAdditionalInfo_TaxInformationNumber")]
        public System.String MalaysiaAdditionalInfo_TaxInformationNumber { get; set; }
        #endregion
        
        #region Parameter TurkeyAdditionalInfo_TaxOffice
        /// <summary>
        /// <para>
        /// <para>The tax office where you're registered. You can enter this information as a string.
        /// The Tax Settings API will add this information to your invoice. This parameter is
        /// required for business-to-business (B2B) and business-to-government customers. It's
        /// not required for business-to-consumer (B2C) customers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaxRegistrationEntry_AdditionalTaxInformation_TurkeyAdditionalInfo_TaxOffice")]
        public System.String TurkeyAdditionalInfo_TaxOffice { get; set; }
        #endregion
        
        #region Parameter VerificationDetails_TaxRegistrationDocument
        /// <summary>
        /// <para>
        /// <para>The tax registration document, which is required for specific countries such as Bangladesh,
        /// Kenya, South Korea and Spain.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaxRegistrationEntry_VerificationDetails_TaxRegistrationDocuments")]
        public Amazon.TaxSettings.Model.TaxRegistrationDocument[] VerificationDetails_TaxRegistrationDocument { get; set; }
        #endregion
        
        #region Parameter RomaniaAdditionalInfo_TaxRegistrationNumberType
        /// <summary>
        /// <para>
        /// <para> The tax registration number type. The value can be <c>TaxRegistrationNumber</c> or
        /// <c>LocalRegistrationNumber</c>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaxRegistrationEntry_AdditionalTaxInformation_RomaniaAdditionalInfo_TaxRegistrationNumberType")]
        [AWSConstantClassSource("Amazon.TaxSettings.TaxRegistrationNumberType")]
        public Amazon.TaxSettings.TaxRegistrationNumberType RomaniaAdditionalInfo_TaxRegistrationNumberType { get; set; }
        #endregion
        
        #region Parameter SaudiArabiaAdditionalInfo_TaxRegistrationNumberType
        /// <summary>
        /// <para>
        /// <para> The tax registration number type. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaxRegistrationEntry_AdditionalTaxInformation_SaudiArabiaAdditionalInfo_TaxRegistrationNumberType")]
        [AWSConstantClassSource("Amazon.TaxSettings.SaudiArabiaTaxRegistrationNumberType")]
        public Amazon.TaxSettings.SaudiArabiaTaxRegistrationNumberType SaudiArabiaAdditionalInfo_TaxRegistrationNumberType { get; set; }
        #endregion
        
        #region Parameter UzbekistanAdditionalInfo_TaxRegistrationNumberType
        /// <summary>
        /// <para>
        /// <para> The tax registration number type. The tax registration number type valid values are
        /// <c>Business</c> and <c>Individual</c>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaxRegistrationEntry_AdditionalTaxInformation_UzbekistanAdditionalInfo_TaxRegistrationNumberType")]
        [AWSConstantClassSource("Amazon.TaxSettings.UzbekistanTaxRegistrationNumberType")]
        public Amazon.TaxSettings.UzbekistanTaxRegistrationNumberType UzbekistanAdditionalInfo_TaxRegistrationNumberType { get; set; }
        #endregion
        
        #region Parameter UkraineAdditionalInfo_UkraineTrnType
        /// <summary>
        /// <para>
        /// <para> The tax registration type. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaxRegistrationEntry_AdditionalTaxInformation_UkraineAdditionalInfo_UkraineTrnType")]
        [AWSConstantClassSource("Amazon.TaxSettings.UkraineTrnType")]
        public Amazon.TaxSettings.UkraineTrnType UkraineAdditionalInfo_UkraineTrnType { get; set; }
        #endregion
        
        #region Parameter EgyptAdditionalInfo_UniqueIdentificationNumber
        /// <summary>
        /// <para>
        /// <para>The unique identification number provided by the Egypt Tax Authority.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaxRegistrationEntry_AdditionalTaxInformation_EgyptAdditionalInfo_UniqueIdentificationNumber")]
        public System.String EgyptAdditionalInfo_UniqueIdentificationNumber { get; set; }
        #endregion
        
        #region Parameter EgyptAdditionalInfo_UniqueIdentificationNumberExpirationDate
        /// <summary>
        /// <para>
        /// <para>The expiration date of the unique identification number provided by the Egypt Tax
        /// Authority.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaxRegistrationEntry_AdditionalTaxInformation_EgyptAdditionalInfo_UniqueIdentificationNumberExpirationDate")]
        public System.String EgyptAdditionalInfo_UniqueIdentificationNumberExpirationDate { get; set; }
        #endregion
        
        #region Parameter UzbekistanAdditionalInfo_VatRegistrationNumber
        /// <summary>
        /// <para>
        /// <para> The unique 12-digit number issued to identify VAT-registered identities in Uzbekistan.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaxRegistrationEntry_AdditionalTaxInformation_UzbekistanAdditionalInfo_VatRegistrationNumber")]
        public System.String UzbekistanAdditionalInfo_VatRegistrationNumber { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Status'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.TaxSettings.Model.PutTaxRegistrationResponse).
        /// Specifying the name of a property of type Amazon.TaxSettings.Model.PutTaxRegistrationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Status";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TaxRegistrationEntry_RegistrationId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-TSATaxRegistration (PutTaxRegistration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.TaxSettings.Model.PutTaxRegistrationResponse, WriteTSATaxRegistrationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AccountId = this.AccountId;
            context.CanadaAdditionalInfo_CanadaQuebecSalesTaxNumber = this.CanadaAdditionalInfo_CanadaQuebecSalesTaxNumber;
            context.CanadaAdditionalInfo_CanadaRetailSalesTaxNumber = this.CanadaAdditionalInfo_CanadaRetailSalesTaxNumber;
            context.CanadaAdditionalInfo_IsResellerAccount = this.CanadaAdditionalInfo_IsResellerAccount;
            context.CanadaAdditionalInfo_ProvincialSalesTaxId = this.CanadaAdditionalInfo_ProvincialSalesTaxId;
            context.EgyptAdditionalInfo_UniqueIdentificationNumber = this.EgyptAdditionalInfo_UniqueIdentificationNumber;
            context.EgyptAdditionalInfo_UniqueIdentificationNumberExpirationDate = this.EgyptAdditionalInfo_UniqueIdentificationNumberExpirationDate;
            context.EstoniaAdditionalInfo_RegistryCommercialCode = this.EstoniaAdditionalInfo_RegistryCommercialCode;
            context.GeorgiaAdditionalInfo_PersonType = this.GeorgiaAdditionalInfo_PersonType;
            context.GreeceAdditionalInfo_ContractingAuthorityCode = this.GreeceAdditionalInfo_ContractingAuthorityCode;
            context.IsraelAdditionalInfo_CustomerType = this.IsraelAdditionalInfo_CustomerType;
            context.IsraelAdditionalInfo_DealerType = this.IsraelAdditionalInfo_DealerType;
            context.ItalyAdditionalInfo_CigNumber = this.ItalyAdditionalInfo_CigNumber;
            context.ItalyAdditionalInfo_CupNumber = this.ItalyAdditionalInfo_CupNumber;
            context.ItalyAdditionalInfo_SdiAccountId = this.ItalyAdditionalInfo_SdiAccountId;
            context.ItalyAdditionalInfo_TaxCode = this.ItalyAdditionalInfo_TaxCode;
            context.KenyaAdditionalInfo_PersonType = this.KenyaAdditionalInfo_PersonType;
            context.MalaysiaAdditionalInfo_BusinessRegistrationNumber = this.MalaysiaAdditionalInfo_BusinessRegistrationNumber;
            if (this.MalaysiaAdditionalInfo_ServiceTaxCode != null)
            {
                context.MalaysiaAdditionalInfo_ServiceTaxCode = new List<System.String>(this.MalaysiaAdditionalInfo_ServiceTaxCode);
            }
            context.MalaysiaAdditionalInfo_TaxInformationNumber = this.MalaysiaAdditionalInfo_TaxInformationNumber;
            context.PolandAdditionalInfo_IndividualRegistrationNumber = this.PolandAdditionalInfo_IndividualRegistrationNumber;
            context.PolandAdditionalInfo_IsGroupVatEnabled = this.PolandAdditionalInfo_IsGroupVatEnabled;
            context.RomaniaAdditionalInfo_TaxRegistrationNumberType = this.RomaniaAdditionalInfo_TaxRegistrationNumberType;
            context.SaudiArabiaAdditionalInfo_TaxRegistrationNumberType = this.SaudiArabiaAdditionalInfo_TaxRegistrationNumberType;
            context.SouthKoreaAdditionalInfo_BusinessRepresentativeName = this.SouthKoreaAdditionalInfo_BusinessRepresentativeName;
            context.SouthKoreaAdditionalInfo_ItemOfBusiness = this.SouthKoreaAdditionalInfo_ItemOfBusiness;
            context.SouthKoreaAdditionalInfo_LineOfBusiness = this.SouthKoreaAdditionalInfo_LineOfBusiness;
            context.SpainAdditionalInfo_RegistrationType = this.SpainAdditionalInfo_RegistrationType;
            context.TurkeyAdditionalInfo_Industry = this.TurkeyAdditionalInfo_Industry;
            context.TurkeyAdditionalInfo_KepEmailId = this.TurkeyAdditionalInfo_KepEmailId;
            context.TurkeyAdditionalInfo_SecondaryTaxId = this.TurkeyAdditionalInfo_SecondaryTaxId;
            context.TurkeyAdditionalInfo_TaxOffice = this.TurkeyAdditionalInfo_TaxOffice;
            context.UkraineAdditionalInfo_UkraineTrnType = this.UkraineAdditionalInfo_UkraineTrnType;
            context.UzbekistanAdditionalInfo_TaxRegistrationNumberType = this.UzbekistanAdditionalInfo_TaxRegistrationNumberType;
            context.UzbekistanAdditionalInfo_VatRegistrationNumber = this.UzbekistanAdditionalInfo_VatRegistrationNumber;
            context.VietnamAdditionalInfo_ElectronicTransactionCodeNumber = this.VietnamAdditionalInfo_ElectronicTransactionCodeNumber;
            context.VietnamAdditionalInfo_EnterpriseIdentificationNumber = this.VietnamAdditionalInfo_EnterpriseIdentificationNumber;
            context.VietnamAdditionalInfo_PaymentVoucherNumber = this.VietnamAdditionalInfo_PaymentVoucherNumber;
            context.VietnamAdditionalInfo_PaymentVoucherNumberDate = this.VietnamAdditionalInfo_PaymentVoucherNumberDate;
            context.TaxRegistrationEntry_CertifiedEmailId = this.TaxRegistrationEntry_CertifiedEmailId;
            context.LegalAddress_AddressLine1 = this.LegalAddress_AddressLine1;
            context.LegalAddress_AddressLine2 = this.LegalAddress_AddressLine2;
            context.LegalAddress_AddressLine3 = this.LegalAddress_AddressLine3;
            context.LegalAddress_City = this.LegalAddress_City;
            context.LegalAddress_CountryCode = this.LegalAddress_CountryCode;
            context.LegalAddress_DistrictOrCounty = this.LegalAddress_DistrictOrCounty;
            context.LegalAddress_PostalCode = this.LegalAddress_PostalCode;
            context.LegalAddress_StateOrRegion = this.LegalAddress_StateOrRegion;
            context.TaxRegistrationEntry_LegalName = this.TaxRegistrationEntry_LegalName;
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
            context.TaxRegistrationEntry_Sector = this.TaxRegistrationEntry_Sector;
            context.VerificationDetails_DateOfBirth = this.VerificationDetails_DateOfBirth;
            if (this.VerificationDetails_TaxRegistrationDocument != null)
            {
                context.VerificationDetails_TaxRegistrationDocument = new List<Amazon.TaxSettings.Model.TaxRegistrationDocument>(this.VerificationDetails_TaxRegistrationDocument);
            }
            
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
            var request = new Amazon.TaxSettings.Model.PutTaxRegistrationRequest();
            
            if (cmdletContext.AccountId != null)
            {
                request.AccountId = cmdletContext.AccountId;
            }
            
             // populate TaxRegistrationEntry
            var requestTaxRegistrationEntryIsNull = true;
            request.TaxRegistrationEntry = new Amazon.TaxSettings.Model.TaxRegistrationEntry();
            System.String requestTaxRegistrationEntry_taxRegistrationEntry_CertifiedEmailId = null;
            if (cmdletContext.TaxRegistrationEntry_CertifiedEmailId != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_CertifiedEmailId = cmdletContext.TaxRegistrationEntry_CertifiedEmailId;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_CertifiedEmailId != null)
            {
                request.TaxRegistrationEntry.CertifiedEmailId = requestTaxRegistrationEntry_taxRegistrationEntry_CertifiedEmailId;
                requestTaxRegistrationEntryIsNull = false;
            }
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
            Amazon.TaxSettings.TaxRegistrationType requestTaxRegistrationEntry_taxRegistrationEntry_RegistrationType = null;
            if (cmdletContext.TaxRegistrationEntry_RegistrationType != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_RegistrationType = cmdletContext.TaxRegistrationEntry_RegistrationType;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_RegistrationType != null)
            {
                request.TaxRegistrationEntry.RegistrationType = requestTaxRegistrationEntry_taxRegistrationEntry_RegistrationType;
                requestTaxRegistrationEntryIsNull = false;
            }
            Amazon.TaxSettings.Sector requestTaxRegistrationEntry_taxRegistrationEntry_Sector = null;
            if (cmdletContext.TaxRegistrationEntry_Sector != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_Sector = cmdletContext.TaxRegistrationEntry_Sector;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_Sector != null)
            {
                request.TaxRegistrationEntry.Sector = requestTaxRegistrationEntry_taxRegistrationEntry_Sector;
                requestTaxRegistrationEntryIsNull = false;
            }
            Amazon.TaxSettings.Model.VerificationDetails requestTaxRegistrationEntry_taxRegistrationEntry_VerificationDetails = null;
            
             // populate VerificationDetails
            var requestTaxRegistrationEntry_taxRegistrationEntry_VerificationDetailsIsNull = true;
            requestTaxRegistrationEntry_taxRegistrationEntry_VerificationDetails = new Amazon.TaxSettings.Model.VerificationDetails();
            System.String requestTaxRegistrationEntry_taxRegistrationEntry_VerificationDetails_verificationDetails_DateOfBirth = null;
            if (cmdletContext.VerificationDetails_DateOfBirth != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_VerificationDetails_verificationDetails_DateOfBirth = cmdletContext.VerificationDetails_DateOfBirth;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_VerificationDetails_verificationDetails_DateOfBirth != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_VerificationDetails.DateOfBirth = requestTaxRegistrationEntry_taxRegistrationEntry_VerificationDetails_verificationDetails_DateOfBirth;
                requestTaxRegistrationEntry_taxRegistrationEntry_VerificationDetailsIsNull = false;
            }
            List<Amazon.TaxSettings.Model.TaxRegistrationDocument> requestTaxRegistrationEntry_taxRegistrationEntry_VerificationDetails_verificationDetails_TaxRegistrationDocument = null;
            if (cmdletContext.VerificationDetails_TaxRegistrationDocument != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_VerificationDetails_verificationDetails_TaxRegistrationDocument = cmdletContext.VerificationDetails_TaxRegistrationDocument;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_VerificationDetails_verificationDetails_TaxRegistrationDocument != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_VerificationDetails.TaxRegistrationDocuments = requestTaxRegistrationEntry_taxRegistrationEntry_VerificationDetails_verificationDetails_TaxRegistrationDocument;
                requestTaxRegistrationEntry_taxRegistrationEntry_VerificationDetailsIsNull = false;
            }
             // determine if requestTaxRegistrationEntry_taxRegistrationEntry_VerificationDetails should be set to null
            if (requestTaxRegistrationEntry_taxRegistrationEntry_VerificationDetailsIsNull)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_VerificationDetails = null;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_VerificationDetails != null)
            {
                request.TaxRegistrationEntry.VerificationDetails = requestTaxRegistrationEntry_taxRegistrationEntry_VerificationDetails;
                requestTaxRegistrationEntryIsNull = false;
            }
            Amazon.TaxSettings.Model.Address requestTaxRegistrationEntry_taxRegistrationEntry_LegalAddress = null;
            
             // populate LegalAddress
            var requestTaxRegistrationEntry_taxRegistrationEntry_LegalAddressIsNull = true;
            requestTaxRegistrationEntry_taxRegistrationEntry_LegalAddress = new Amazon.TaxSettings.Model.Address();
            System.String requestTaxRegistrationEntry_taxRegistrationEntry_LegalAddress_legalAddress_AddressLine1 = null;
            if (cmdletContext.LegalAddress_AddressLine1 != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_LegalAddress_legalAddress_AddressLine1 = cmdletContext.LegalAddress_AddressLine1;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_LegalAddress_legalAddress_AddressLine1 != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_LegalAddress.AddressLine1 = requestTaxRegistrationEntry_taxRegistrationEntry_LegalAddress_legalAddress_AddressLine1;
                requestTaxRegistrationEntry_taxRegistrationEntry_LegalAddressIsNull = false;
            }
            System.String requestTaxRegistrationEntry_taxRegistrationEntry_LegalAddress_legalAddress_AddressLine2 = null;
            if (cmdletContext.LegalAddress_AddressLine2 != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_LegalAddress_legalAddress_AddressLine2 = cmdletContext.LegalAddress_AddressLine2;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_LegalAddress_legalAddress_AddressLine2 != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_LegalAddress.AddressLine2 = requestTaxRegistrationEntry_taxRegistrationEntry_LegalAddress_legalAddress_AddressLine2;
                requestTaxRegistrationEntry_taxRegistrationEntry_LegalAddressIsNull = false;
            }
            System.String requestTaxRegistrationEntry_taxRegistrationEntry_LegalAddress_legalAddress_AddressLine3 = null;
            if (cmdletContext.LegalAddress_AddressLine3 != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_LegalAddress_legalAddress_AddressLine3 = cmdletContext.LegalAddress_AddressLine3;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_LegalAddress_legalAddress_AddressLine3 != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_LegalAddress.AddressLine3 = requestTaxRegistrationEntry_taxRegistrationEntry_LegalAddress_legalAddress_AddressLine3;
                requestTaxRegistrationEntry_taxRegistrationEntry_LegalAddressIsNull = false;
            }
            System.String requestTaxRegistrationEntry_taxRegistrationEntry_LegalAddress_legalAddress_City = null;
            if (cmdletContext.LegalAddress_City != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_LegalAddress_legalAddress_City = cmdletContext.LegalAddress_City;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_LegalAddress_legalAddress_City != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_LegalAddress.City = requestTaxRegistrationEntry_taxRegistrationEntry_LegalAddress_legalAddress_City;
                requestTaxRegistrationEntry_taxRegistrationEntry_LegalAddressIsNull = false;
            }
            System.String requestTaxRegistrationEntry_taxRegistrationEntry_LegalAddress_legalAddress_CountryCode = null;
            if (cmdletContext.LegalAddress_CountryCode != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_LegalAddress_legalAddress_CountryCode = cmdletContext.LegalAddress_CountryCode;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_LegalAddress_legalAddress_CountryCode != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_LegalAddress.CountryCode = requestTaxRegistrationEntry_taxRegistrationEntry_LegalAddress_legalAddress_CountryCode;
                requestTaxRegistrationEntry_taxRegistrationEntry_LegalAddressIsNull = false;
            }
            System.String requestTaxRegistrationEntry_taxRegistrationEntry_LegalAddress_legalAddress_DistrictOrCounty = null;
            if (cmdletContext.LegalAddress_DistrictOrCounty != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_LegalAddress_legalAddress_DistrictOrCounty = cmdletContext.LegalAddress_DistrictOrCounty;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_LegalAddress_legalAddress_DistrictOrCounty != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_LegalAddress.DistrictOrCounty = requestTaxRegistrationEntry_taxRegistrationEntry_LegalAddress_legalAddress_DistrictOrCounty;
                requestTaxRegistrationEntry_taxRegistrationEntry_LegalAddressIsNull = false;
            }
            System.String requestTaxRegistrationEntry_taxRegistrationEntry_LegalAddress_legalAddress_PostalCode = null;
            if (cmdletContext.LegalAddress_PostalCode != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_LegalAddress_legalAddress_PostalCode = cmdletContext.LegalAddress_PostalCode;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_LegalAddress_legalAddress_PostalCode != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_LegalAddress.PostalCode = requestTaxRegistrationEntry_taxRegistrationEntry_LegalAddress_legalAddress_PostalCode;
                requestTaxRegistrationEntry_taxRegistrationEntry_LegalAddressIsNull = false;
            }
            System.String requestTaxRegistrationEntry_taxRegistrationEntry_LegalAddress_legalAddress_StateOrRegion = null;
            if (cmdletContext.LegalAddress_StateOrRegion != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_LegalAddress_legalAddress_StateOrRegion = cmdletContext.LegalAddress_StateOrRegion;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_LegalAddress_legalAddress_StateOrRegion != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_LegalAddress.StateOrRegion = requestTaxRegistrationEntry_taxRegistrationEntry_LegalAddress_legalAddress_StateOrRegion;
                requestTaxRegistrationEntry_taxRegistrationEntry_LegalAddressIsNull = false;
            }
             // determine if requestTaxRegistrationEntry_taxRegistrationEntry_LegalAddress should be set to null
            if (requestTaxRegistrationEntry_taxRegistrationEntry_LegalAddressIsNull)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_LegalAddress = null;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_LegalAddress != null)
            {
                request.TaxRegistrationEntry.LegalAddress = requestTaxRegistrationEntry_taxRegistrationEntry_LegalAddress;
                requestTaxRegistrationEntryIsNull = false;
            }
            Amazon.TaxSettings.Model.AdditionalInfoRequest requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation = null;
            
             // populate AdditionalTaxInformation
            var requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformationIsNull = true;
            requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation = new Amazon.TaxSettings.Model.AdditionalInfoRequest();
            Amazon.TaxSettings.Model.EstoniaAdditionalInfo requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_EstoniaAdditionalInfo = null;
            
             // populate EstoniaAdditionalInfo
            var requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_EstoniaAdditionalInfoIsNull = true;
            requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_EstoniaAdditionalInfo = new Amazon.TaxSettings.Model.EstoniaAdditionalInfo();
            System.String requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_EstoniaAdditionalInfo_estoniaAdditionalInfo_RegistryCommercialCode = null;
            if (cmdletContext.EstoniaAdditionalInfo_RegistryCommercialCode != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_EstoniaAdditionalInfo_estoniaAdditionalInfo_RegistryCommercialCode = cmdletContext.EstoniaAdditionalInfo_RegistryCommercialCode;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_EstoniaAdditionalInfo_estoniaAdditionalInfo_RegistryCommercialCode != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_EstoniaAdditionalInfo.RegistryCommercialCode = requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_EstoniaAdditionalInfo_estoniaAdditionalInfo_RegistryCommercialCode;
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_EstoniaAdditionalInfoIsNull = false;
            }
             // determine if requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_EstoniaAdditionalInfo should be set to null
            if (requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_EstoniaAdditionalInfoIsNull)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_EstoniaAdditionalInfo = null;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_EstoniaAdditionalInfo != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation.EstoniaAdditionalInfo = requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_EstoniaAdditionalInfo;
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformationIsNull = false;
            }
            Amazon.TaxSettings.Model.GeorgiaAdditionalInfo requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_GeorgiaAdditionalInfo = null;
            
             // populate GeorgiaAdditionalInfo
            var requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_GeorgiaAdditionalInfoIsNull = true;
            requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_GeorgiaAdditionalInfo = new Amazon.TaxSettings.Model.GeorgiaAdditionalInfo();
            Amazon.TaxSettings.PersonType requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_GeorgiaAdditionalInfo_georgiaAdditionalInfo_PersonType = null;
            if (cmdletContext.GeorgiaAdditionalInfo_PersonType != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_GeorgiaAdditionalInfo_georgiaAdditionalInfo_PersonType = cmdletContext.GeorgiaAdditionalInfo_PersonType;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_GeorgiaAdditionalInfo_georgiaAdditionalInfo_PersonType != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_GeorgiaAdditionalInfo.PersonType = requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_GeorgiaAdditionalInfo_georgiaAdditionalInfo_PersonType;
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_GeorgiaAdditionalInfoIsNull = false;
            }
             // determine if requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_GeorgiaAdditionalInfo should be set to null
            if (requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_GeorgiaAdditionalInfoIsNull)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_GeorgiaAdditionalInfo = null;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_GeorgiaAdditionalInfo != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation.GeorgiaAdditionalInfo = requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_GeorgiaAdditionalInfo;
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformationIsNull = false;
            }
            Amazon.TaxSettings.Model.GreeceAdditionalInfo requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_GreeceAdditionalInfo = null;
            
             // populate GreeceAdditionalInfo
            var requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_GreeceAdditionalInfoIsNull = true;
            requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_GreeceAdditionalInfo = new Amazon.TaxSettings.Model.GreeceAdditionalInfo();
            System.String requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_GreeceAdditionalInfo_greeceAdditionalInfo_ContractingAuthorityCode = null;
            if (cmdletContext.GreeceAdditionalInfo_ContractingAuthorityCode != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_GreeceAdditionalInfo_greeceAdditionalInfo_ContractingAuthorityCode = cmdletContext.GreeceAdditionalInfo_ContractingAuthorityCode;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_GreeceAdditionalInfo_greeceAdditionalInfo_ContractingAuthorityCode != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_GreeceAdditionalInfo.ContractingAuthorityCode = requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_GreeceAdditionalInfo_greeceAdditionalInfo_ContractingAuthorityCode;
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_GreeceAdditionalInfoIsNull = false;
            }
             // determine if requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_GreeceAdditionalInfo should be set to null
            if (requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_GreeceAdditionalInfoIsNull)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_GreeceAdditionalInfo = null;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_GreeceAdditionalInfo != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation.GreeceAdditionalInfo = requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_GreeceAdditionalInfo;
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformationIsNull = false;
            }
            Amazon.TaxSettings.Model.KenyaAdditionalInfo requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_KenyaAdditionalInfo = null;
            
             // populate KenyaAdditionalInfo
            var requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_KenyaAdditionalInfoIsNull = true;
            requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_KenyaAdditionalInfo = new Amazon.TaxSettings.Model.KenyaAdditionalInfo();
            Amazon.TaxSettings.PersonType requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_KenyaAdditionalInfo_kenyaAdditionalInfo_PersonType = null;
            if (cmdletContext.KenyaAdditionalInfo_PersonType != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_KenyaAdditionalInfo_kenyaAdditionalInfo_PersonType = cmdletContext.KenyaAdditionalInfo_PersonType;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_KenyaAdditionalInfo_kenyaAdditionalInfo_PersonType != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_KenyaAdditionalInfo.PersonType = requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_KenyaAdditionalInfo_kenyaAdditionalInfo_PersonType;
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_KenyaAdditionalInfoIsNull = false;
            }
             // determine if requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_KenyaAdditionalInfo should be set to null
            if (requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_KenyaAdditionalInfoIsNull)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_KenyaAdditionalInfo = null;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_KenyaAdditionalInfo != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation.KenyaAdditionalInfo = requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_KenyaAdditionalInfo;
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformationIsNull = false;
            }
            Amazon.TaxSettings.Model.RomaniaAdditionalInfo requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_RomaniaAdditionalInfo = null;
            
             // populate RomaniaAdditionalInfo
            var requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_RomaniaAdditionalInfoIsNull = true;
            requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_RomaniaAdditionalInfo = new Amazon.TaxSettings.Model.RomaniaAdditionalInfo();
            Amazon.TaxSettings.TaxRegistrationNumberType requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_RomaniaAdditionalInfo_romaniaAdditionalInfo_TaxRegistrationNumberType = null;
            if (cmdletContext.RomaniaAdditionalInfo_TaxRegistrationNumberType != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_RomaniaAdditionalInfo_romaniaAdditionalInfo_TaxRegistrationNumberType = cmdletContext.RomaniaAdditionalInfo_TaxRegistrationNumberType;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_RomaniaAdditionalInfo_romaniaAdditionalInfo_TaxRegistrationNumberType != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_RomaniaAdditionalInfo.TaxRegistrationNumberType = requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_RomaniaAdditionalInfo_romaniaAdditionalInfo_TaxRegistrationNumberType;
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_RomaniaAdditionalInfoIsNull = false;
            }
             // determine if requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_RomaniaAdditionalInfo should be set to null
            if (requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_RomaniaAdditionalInfoIsNull)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_RomaniaAdditionalInfo = null;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_RomaniaAdditionalInfo != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation.RomaniaAdditionalInfo = requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_RomaniaAdditionalInfo;
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformationIsNull = false;
            }
            Amazon.TaxSettings.Model.SaudiArabiaAdditionalInfo requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_SaudiArabiaAdditionalInfo = null;
            
             // populate SaudiArabiaAdditionalInfo
            var requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_SaudiArabiaAdditionalInfoIsNull = true;
            requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_SaudiArabiaAdditionalInfo = new Amazon.TaxSettings.Model.SaudiArabiaAdditionalInfo();
            Amazon.TaxSettings.SaudiArabiaTaxRegistrationNumberType requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_SaudiArabiaAdditionalInfo_saudiArabiaAdditionalInfo_TaxRegistrationNumberType = null;
            if (cmdletContext.SaudiArabiaAdditionalInfo_TaxRegistrationNumberType != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_SaudiArabiaAdditionalInfo_saudiArabiaAdditionalInfo_TaxRegistrationNumberType = cmdletContext.SaudiArabiaAdditionalInfo_TaxRegistrationNumberType;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_SaudiArabiaAdditionalInfo_saudiArabiaAdditionalInfo_TaxRegistrationNumberType != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_SaudiArabiaAdditionalInfo.TaxRegistrationNumberType = requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_SaudiArabiaAdditionalInfo_saudiArabiaAdditionalInfo_TaxRegistrationNumberType;
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_SaudiArabiaAdditionalInfoIsNull = false;
            }
             // determine if requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_SaudiArabiaAdditionalInfo should be set to null
            if (requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_SaudiArabiaAdditionalInfoIsNull)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_SaudiArabiaAdditionalInfo = null;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_SaudiArabiaAdditionalInfo != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation.SaudiArabiaAdditionalInfo = requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_SaudiArabiaAdditionalInfo;
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformationIsNull = false;
            }
            Amazon.TaxSettings.Model.SpainAdditionalInfo requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_SpainAdditionalInfo = null;
            
             // populate SpainAdditionalInfo
            var requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_SpainAdditionalInfoIsNull = true;
            requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_SpainAdditionalInfo = new Amazon.TaxSettings.Model.SpainAdditionalInfo();
            Amazon.TaxSettings.RegistrationType requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_SpainAdditionalInfo_spainAdditionalInfo_RegistrationType = null;
            if (cmdletContext.SpainAdditionalInfo_RegistrationType != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_SpainAdditionalInfo_spainAdditionalInfo_RegistrationType = cmdletContext.SpainAdditionalInfo_RegistrationType;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_SpainAdditionalInfo_spainAdditionalInfo_RegistrationType != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_SpainAdditionalInfo.RegistrationType = requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_SpainAdditionalInfo_spainAdditionalInfo_RegistrationType;
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_SpainAdditionalInfoIsNull = false;
            }
             // determine if requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_SpainAdditionalInfo should be set to null
            if (requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_SpainAdditionalInfoIsNull)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_SpainAdditionalInfo = null;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_SpainAdditionalInfo != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation.SpainAdditionalInfo = requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_SpainAdditionalInfo;
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformationIsNull = false;
            }
            Amazon.TaxSettings.Model.UkraineAdditionalInfo requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_UkraineAdditionalInfo = null;
            
             // populate UkraineAdditionalInfo
            var requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_UkraineAdditionalInfoIsNull = true;
            requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_UkraineAdditionalInfo = new Amazon.TaxSettings.Model.UkraineAdditionalInfo();
            Amazon.TaxSettings.UkraineTrnType requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_UkraineAdditionalInfo_ukraineAdditionalInfo_UkraineTrnType = null;
            if (cmdletContext.UkraineAdditionalInfo_UkraineTrnType != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_UkraineAdditionalInfo_ukraineAdditionalInfo_UkraineTrnType = cmdletContext.UkraineAdditionalInfo_UkraineTrnType;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_UkraineAdditionalInfo_ukraineAdditionalInfo_UkraineTrnType != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_UkraineAdditionalInfo.UkraineTrnType = requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_UkraineAdditionalInfo_ukraineAdditionalInfo_UkraineTrnType;
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_UkraineAdditionalInfoIsNull = false;
            }
             // determine if requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_UkraineAdditionalInfo should be set to null
            if (requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_UkraineAdditionalInfoIsNull)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_UkraineAdditionalInfo = null;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_UkraineAdditionalInfo != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation.UkraineAdditionalInfo = requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_UkraineAdditionalInfo;
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformationIsNull = false;
            }
            Amazon.TaxSettings.Model.EgyptAdditionalInfo requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_EgyptAdditionalInfo = null;
            
             // populate EgyptAdditionalInfo
            var requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_EgyptAdditionalInfoIsNull = true;
            requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_EgyptAdditionalInfo = new Amazon.TaxSettings.Model.EgyptAdditionalInfo();
            System.String requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_EgyptAdditionalInfo_egyptAdditionalInfo_UniqueIdentificationNumber = null;
            if (cmdletContext.EgyptAdditionalInfo_UniqueIdentificationNumber != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_EgyptAdditionalInfo_egyptAdditionalInfo_UniqueIdentificationNumber = cmdletContext.EgyptAdditionalInfo_UniqueIdentificationNumber;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_EgyptAdditionalInfo_egyptAdditionalInfo_UniqueIdentificationNumber != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_EgyptAdditionalInfo.UniqueIdentificationNumber = requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_EgyptAdditionalInfo_egyptAdditionalInfo_UniqueIdentificationNumber;
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_EgyptAdditionalInfoIsNull = false;
            }
            System.String requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_EgyptAdditionalInfo_egyptAdditionalInfo_UniqueIdentificationNumberExpirationDate = null;
            if (cmdletContext.EgyptAdditionalInfo_UniqueIdentificationNumberExpirationDate != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_EgyptAdditionalInfo_egyptAdditionalInfo_UniqueIdentificationNumberExpirationDate = cmdletContext.EgyptAdditionalInfo_UniqueIdentificationNumberExpirationDate;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_EgyptAdditionalInfo_egyptAdditionalInfo_UniqueIdentificationNumberExpirationDate != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_EgyptAdditionalInfo.UniqueIdentificationNumberExpirationDate = requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_EgyptAdditionalInfo_egyptAdditionalInfo_UniqueIdentificationNumberExpirationDate;
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_EgyptAdditionalInfoIsNull = false;
            }
             // determine if requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_EgyptAdditionalInfo should be set to null
            if (requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_EgyptAdditionalInfoIsNull)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_EgyptAdditionalInfo = null;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_EgyptAdditionalInfo != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation.EgyptAdditionalInfo = requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_EgyptAdditionalInfo;
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformationIsNull = false;
            }
            Amazon.TaxSettings.Model.IsraelAdditionalInfo requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_IsraelAdditionalInfo = null;
            
             // populate IsraelAdditionalInfo
            var requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_IsraelAdditionalInfoIsNull = true;
            requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_IsraelAdditionalInfo = new Amazon.TaxSettings.Model.IsraelAdditionalInfo();
            Amazon.TaxSettings.IsraelCustomerType requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_IsraelAdditionalInfo_israelAdditionalInfo_CustomerType = null;
            if (cmdletContext.IsraelAdditionalInfo_CustomerType != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_IsraelAdditionalInfo_israelAdditionalInfo_CustomerType = cmdletContext.IsraelAdditionalInfo_CustomerType;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_IsraelAdditionalInfo_israelAdditionalInfo_CustomerType != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_IsraelAdditionalInfo.CustomerType = requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_IsraelAdditionalInfo_israelAdditionalInfo_CustomerType;
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_IsraelAdditionalInfoIsNull = false;
            }
            Amazon.TaxSettings.IsraelDealerType requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_IsraelAdditionalInfo_israelAdditionalInfo_DealerType = null;
            if (cmdletContext.IsraelAdditionalInfo_DealerType != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_IsraelAdditionalInfo_israelAdditionalInfo_DealerType = cmdletContext.IsraelAdditionalInfo_DealerType;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_IsraelAdditionalInfo_israelAdditionalInfo_DealerType != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_IsraelAdditionalInfo.DealerType = requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_IsraelAdditionalInfo_israelAdditionalInfo_DealerType;
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_IsraelAdditionalInfoIsNull = false;
            }
             // determine if requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_IsraelAdditionalInfo should be set to null
            if (requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_IsraelAdditionalInfoIsNull)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_IsraelAdditionalInfo = null;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_IsraelAdditionalInfo != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation.IsraelAdditionalInfo = requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_IsraelAdditionalInfo;
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformationIsNull = false;
            }
            Amazon.TaxSettings.Model.PolandAdditionalInfo requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_PolandAdditionalInfo = null;
            
             // populate PolandAdditionalInfo
            var requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_PolandAdditionalInfoIsNull = true;
            requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_PolandAdditionalInfo = new Amazon.TaxSettings.Model.PolandAdditionalInfo();
            System.String requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_PolandAdditionalInfo_polandAdditionalInfo_IndividualRegistrationNumber = null;
            if (cmdletContext.PolandAdditionalInfo_IndividualRegistrationNumber != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_PolandAdditionalInfo_polandAdditionalInfo_IndividualRegistrationNumber = cmdletContext.PolandAdditionalInfo_IndividualRegistrationNumber;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_PolandAdditionalInfo_polandAdditionalInfo_IndividualRegistrationNumber != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_PolandAdditionalInfo.IndividualRegistrationNumber = requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_PolandAdditionalInfo_polandAdditionalInfo_IndividualRegistrationNumber;
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_PolandAdditionalInfoIsNull = false;
            }
            System.Boolean? requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_PolandAdditionalInfo_polandAdditionalInfo_IsGroupVatEnabled = null;
            if (cmdletContext.PolandAdditionalInfo_IsGroupVatEnabled != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_PolandAdditionalInfo_polandAdditionalInfo_IsGroupVatEnabled = cmdletContext.PolandAdditionalInfo_IsGroupVatEnabled.Value;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_PolandAdditionalInfo_polandAdditionalInfo_IsGroupVatEnabled != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_PolandAdditionalInfo.IsGroupVatEnabled = requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_PolandAdditionalInfo_polandAdditionalInfo_IsGroupVatEnabled.Value;
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_PolandAdditionalInfoIsNull = false;
            }
             // determine if requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_PolandAdditionalInfo should be set to null
            if (requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_PolandAdditionalInfoIsNull)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_PolandAdditionalInfo = null;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_PolandAdditionalInfo != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation.PolandAdditionalInfo = requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_PolandAdditionalInfo;
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformationIsNull = false;
            }
            Amazon.TaxSettings.Model.UzbekistanAdditionalInfo requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_UzbekistanAdditionalInfo = null;
            
             // populate UzbekistanAdditionalInfo
            var requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_UzbekistanAdditionalInfoIsNull = true;
            requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_UzbekistanAdditionalInfo = new Amazon.TaxSettings.Model.UzbekistanAdditionalInfo();
            Amazon.TaxSettings.UzbekistanTaxRegistrationNumberType requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_UzbekistanAdditionalInfo_uzbekistanAdditionalInfo_TaxRegistrationNumberType = null;
            if (cmdletContext.UzbekistanAdditionalInfo_TaxRegistrationNumberType != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_UzbekistanAdditionalInfo_uzbekistanAdditionalInfo_TaxRegistrationNumberType = cmdletContext.UzbekistanAdditionalInfo_TaxRegistrationNumberType;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_UzbekistanAdditionalInfo_uzbekistanAdditionalInfo_TaxRegistrationNumberType != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_UzbekistanAdditionalInfo.TaxRegistrationNumberType = requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_UzbekistanAdditionalInfo_uzbekistanAdditionalInfo_TaxRegistrationNumberType;
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_UzbekistanAdditionalInfoIsNull = false;
            }
            System.String requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_UzbekistanAdditionalInfo_uzbekistanAdditionalInfo_VatRegistrationNumber = null;
            if (cmdletContext.UzbekistanAdditionalInfo_VatRegistrationNumber != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_UzbekistanAdditionalInfo_uzbekistanAdditionalInfo_VatRegistrationNumber = cmdletContext.UzbekistanAdditionalInfo_VatRegistrationNumber;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_UzbekistanAdditionalInfo_uzbekistanAdditionalInfo_VatRegistrationNumber != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_UzbekistanAdditionalInfo.VatRegistrationNumber = requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_UzbekistanAdditionalInfo_uzbekistanAdditionalInfo_VatRegistrationNumber;
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_UzbekistanAdditionalInfoIsNull = false;
            }
             // determine if requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_UzbekistanAdditionalInfo should be set to null
            if (requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_UzbekistanAdditionalInfoIsNull)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_UzbekistanAdditionalInfo = null;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_UzbekistanAdditionalInfo != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation.UzbekistanAdditionalInfo = requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_UzbekistanAdditionalInfo;
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformationIsNull = false;
            }
            Amazon.TaxSettings.Model.MalaysiaAdditionalInfo requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_MalaysiaAdditionalInfo = null;
            
             // populate MalaysiaAdditionalInfo
            var requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_MalaysiaAdditionalInfoIsNull = true;
            requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_MalaysiaAdditionalInfo = new Amazon.TaxSettings.Model.MalaysiaAdditionalInfo();
            System.String requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_MalaysiaAdditionalInfo_malaysiaAdditionalInfo_BusinessRegistrationNumber = null;
            if (cmdletContext.MalaysiaAdditionalInfo_BusinessRegistrationNumber != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_MalaysiaAdditionalInfo_malaysiaAdditionalInfo_BusinessRegistrationNumber = cmdletContext.MalaysiaAdditionalInfo_BusinessRegistrationNumber;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_MalaysiaAdditionalInfo_malaysiaAdditionalInfo_BusinessRegistrationNumber != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_MalaysiaAdditionalInfo.BusinessRegistrationNumber = requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_MalaysiaAdditionalInfo_malaysiaAdditionalInfo_BusinessRegistrationNumber;
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_MalaysiaAdditionalInfoIsNull = false;
            }
            List<System.String> requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_MalaysiaAdditionalInfo_malaysiaAdditionalInfo_ServiceTaxCode = null;
            if (cmdletContext.MalaysiaAdditionalInfo_ServiceTaxCode != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_MalaysiaAdditionalInfo_malaysiaAdditionalInfo_ServiceTaxCode = cmdletContext.MalaysiaAdditionalInfo_ServiceTaxCode;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_MalaysiaAdditionalInfo_malaysiaAdditionalInfo_ServiceTaxCode != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_MalaysiaAdditionalInfo.ServiceTaxCodes = requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_MalaysiaAdditionalInfo_malaysiaAdditionalInfo_ServiceTaxCode;
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_MalaysiaAdditionalInfoIsNull = false;
            }
            System.String requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_MalaysiaAdditionalInfo_malaysiaAdditionalInfo_TaxInformationNumber = null;
            if (cmdletContext.MalaysiaAdditionalInfo_TaxInformationNumber != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_MalaysiaAdditionalInfo_malaysiaAdditionalInfo_TaxInformationNumber = cmdletContext.MalaysiaAdditionalInfo_TaxInformationNumber;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_MalaysiaAdditionalInfo_malaysiaAdditionalInfo_TaxInformationNumber != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_MalaysiaAdditionalInfo.TaxInformationNumber = requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_MalaysiaAdditionalInfo_malaysiaAdditionalInfo_TaxInformationNumber;
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_MalaysiaAdditionalInfoIsNull = false;
            }
             // determine if requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_MalaysiaAdditionalInfo should be set to null
            if (requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_MalaysiaAdditionalInfoIsNull)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_MalaysiaAdditionalInfo = null;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_MalaysiaAdditionalInfo != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation.MalaysiaAdditionalInfo = requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_MalaysiaAdditionalInfo;
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformationIsNull = false;
            }
            Amazon.TaxSettings.Model.SouthKoreaAdditionalInfo requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_SouthKoreaAdditionalInfo = null;
            
             // populate SouthKoreaAdditionalInfo
            var requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_SouthKoreaAdditionalInfoIsNull = true;
            requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_SouthKoreaAdditionalInfo = new Amazon.TaxSettings.Model.SouthKoreaAdditionalInfo();
            System.String requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_SouthKoreaAdditionalInfo_southKoreaAdditionalInfo_BusinessRepresentativeName = null;
            if (cmdletContext.SouthKoreaAdditionalInfo_BusinessRepresentativeName != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_SouthKoreaAdditionalInfo_southKoreaAdditionalInfo_BusinessRepresentativeName = cmdletContext.SouthKoreaAdditionalInfo_BusinessRepresentativeName;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_SouthKoreaAdditionalInfo_southKoreaAdditionalInfo_BusinessRepresentativeName != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_SouthKoreaAdditionalInfo.BusinessRepresentativeName = requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_SouthKoreaAdditionalInfo_southKoreaAdditionalInfo_BusinessRepresentativeName;
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_SouthKoreaAdditionalInfoIsNull = false;
            }
            System.String requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_SouthKoreaAdditionalInfo_southKoreaAdditionalInfo_ItemOfBusiness = null;
            if (cmdletContext.SouthKoreaAdditionalInfo_ItemOfBusiness != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_SouthKoreaAdditionalInfo_southKoreaAdditionalInfo_ItemOfBusiness = cmdletContext.SouthKoreaAdditionalInfo_ItemOfBusiness;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_SouthKoreaAdditionalInfo_southKoreaAdditionalInfo_ItemOfBusiness != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_SouthKoreaAdditionalInfo.ItemOfBusiness = requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_SouthKoreaAdditionalInfo_southKoreaAdditionalInfo_ItemOfBusiness;
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_SouthKoreaAdditionalInfoIsNull = false;
            }
            System.String requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_SouthKoreaAdditionalInfo_southKoreaAdditionalInfo_LineOfBusiness = null;
            if (cmdletContext.SouthKoreaAdditionalInfo_LineOfBusiness != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_SouthKoreaAdditionalInfo_southKoreaAdditionalInfo_LineOfBusiness = cmdletContext.SouthKoreaAdditionalInfo_LineOfBusiness;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_SouthKoreaAdditionalInfo_southKoreaAdditionalInfo_LineOfBusiness != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_SouthKoreaAdditionalInfo.LineOfBusiness = requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_SouthKoreaAdditionalInfo_southKoreaAdditionalInfo_LineOfBusiness;
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_SouthKoreaAdditionalInfoIsNull = false;
            }
             // determine if requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_SouthKoreaAdditionalInfo should be set to null
            if (requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_SouthKoreaAdditionalInfoIsNull)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_SouthKoreaAdditionalInfo = null;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_SouthKoreaAdditionalInfo != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation.SouthKoreaAdditionalInfo = requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_SouthKoreaAdditionalInfo;
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformationIsNull = false;
            }
            Amazon.TaxSettings.Model.CanadaAdditionalInfo requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_CanadaAdditionalInfo = null;
            
             // populate CanadaAdditionalInfo
            var requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_CanadaAdditionalInfoIsNull = true;
            requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_CanadaAdditionalInfo = new Amazon.TaxSettings.Model.CanadaAdditionalInfo();
            System.String requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_CanadaAdditionalInfo_canadaAdditionalInfo_CanadaQuebecSalesTaxNumber = null;
            if (cmdletContext.CanadaAdditionalInfo_CanadaQuebecSalesTaxNumber != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_CanadaAdditionalInfo_canadaAdditionalInfo_CanadaQuebecSalesTaxNumber = cmdletContext.CanadaAdditionalInfo_CanadaQuebecSalesTaxNumber;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_CanadaAdditionalInfo_canadaAdditionalInfo_CanadaQuebecSalesTaxNumber != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_CanadaAdditionalInfo.CanadaQuebecSalesTaxNumber = requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_CanadaAdditionalInfo_canadaAdditionalInfo_CanadaQuebecSalesTaxNumber;
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_CanadaAdditionalInfoIsNull = false;
            }
            System.String requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_CanadaAdditionalInfo_canadaAdditionalInfo_CanadaRetailSalesTaxNumber = null;
            if (cmdletContext.CanadaAdditionalInfo_CanadaRetailSalesTaxNumber != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_CanadaAdditionalInfo_canadaAdditionalInfo_CanadaRetailSalesTaxNumber = cmdletContext.CanadaAdditionalInfo_CanadaRetailSalesTaxNumber;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_CanadaAdditionalInfo_canadaAdditionalInfo_CanadaRetailSalesTaxNumber != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_CanadaAdditionalInfo.CanadaRetailSalesTaxNumber = requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_CanadaAdditionalInfo_canadaAdditionalInfo_CanadaRetailSalesTaxNumber;
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_CanadaAdditionalInfoIsNull = false;
            }
            System.Boolean? requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_CanadaAdditionalInfo_canadaAdditionalInfo_IsResellerAccount = null;
            if (cmdletContext.CanadaAdditionalInfo_IsResellerAccount != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_CanadaAdditionalInfo_canadaAdditionalInfo_IsResellerAccount = cmdletContext.CanadaAdditionalInfo_IsResellerAccount.Value;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_CanadaAdditionalInfo_canadaAdditionalInfo_IsResellerAccount != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_CanadaAdditionalInfo.IsResellerAccount = requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_CanadaAdditionalInfo_canadaAdditionalInfo_IsResellerAccount.Value;
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_CanadaAdditionalInfoIsNull = false;
            }
            System.String requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_CanadaAdditionalInfo_canadaAdditionalInfo_ProvincialSalesTaxId = null;
            if (cmdletContext.CanadaAdditionalInfo_ProvincialSalesTaxId != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_CanadaAdditionalInfo_canadaAdditionalInfo_ProvincialSalesTaxId = cmdletContext.CanadaAdditionalInfo_ProvincialSalesTaxId;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_CanadaAdditionalInfo_canadaAdditionalInfo_ProvincialSalesTaxId != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_CanadaAdditionalInfo.ProvincialSalesTaxId = requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_CanadaAdditionalInfo_canadaAdditionalInfo_ProvincialSalesTaxId;
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_CanadaAdditionalInfoIsNull = false;
            }
             // determine if requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_CanadaAdditionalInfo should be set to null
            if (requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_CanadaAdditionalInfoIsNull)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_CanadaAdditionalInfo = null;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_CanadaAdditionalInfo != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation.CanadaAdditionalInfo = requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_CanadaAdditionalInfo;
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformationIsNull = false;
            }
            Amazon.TaxSettings.Model.ItalyAdditionalInfo requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_ItalyAdditionalInfo = null;
            
             // populate ItalyAdditionalInfo
            var requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_ItalyAdditionalInfoIsNull = true;
            requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_ItalyAdditionalInfo = new Amazon.TaxSettings.Model.ItalyAdditionalInfo();
            System.String requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_ItalyAdditionalInfo_italyAdditionalInfo_CigNumber = null;
            if (cmdletContext.ItalyAdditionalInfo_CigNumber != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_ItalyAdditionalInfo_italyAdditionalInfo_CigNumber = cmdletContext.ItalyAdditionalInfo_CigNumber;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_ItalyAdditionalInfo_italyAdditionalInfo_CigNumber != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_ItalyAdditionalInfo.CigNumber = requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_ItalyAdditionalInfo_italyAdditionalInfo_CigNumber;
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_ItalyAdditionalInfoIsNull = false;
            }
            System.String requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_ItalyAdditionalInfo_italyAdditionalInfo_CupNumber = null;
            if (cmdletContext.ItalyAdditionalInfo_CupNumber != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_ItalyAdditionalInfo_italyAdditionalInfo_CupNumber = cmdletContext.ItalyAdditionalInfo_CupNumber;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_ItalyAdditionalInfo_italyAdditionalInfo_CupNumber != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_ItalyAdditionalInfo.CupNumber = requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_ItalyAdditionalInfo_italyAdditionalInfo_CupNumber;
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_ItalyAdditionalInfoIsNull = false;
            }
            System.String requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_ItalyAdditionalInfo_italyAdditionalInfo_SdiAccountId = null;
            if (cmdletContext.ItalyAdditionalInfo_SdiAccountId != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_ItalyAdditionalInfo_italyAdditionalInfo_SdiAccountId = cmdletContext.ItalyAdditionalInfo_SdiAccountId;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_ItalyAdditionalInfo_italyAdditionalInfo_SdiAccountId != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_ItalyAdditionalInfo.SdiAccountId = requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_ItalyAdditionalInfo_italyAdditionalInfo_SdiAccountId;
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_ItalyAdditionalInfoIsNull = false;
            }
            System.String requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_ItalyAdditionalInfo_italyAdditionalInfo_TaxCode = null;
            if (cmdletContext.ItalyAdditionalInfo_TaxCode != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_ItalyAdditionalInfo_italyAdditionalInfo_TaxCode = cmdletContext.ItalyAdditionalInfo_TaxCode;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_ItalyAdditionalInfo_italyAdditionalInfo_TaxCode != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_ItalyAdditionalInfo.TaxCode = requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_ItalyAdditionalInfo_italyAdditionalInfo_TaxCode;
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_ItalyAdditionalInfoIsNull = false;
            }
             // determine if requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_ItalyAdditionalInfo should be set to null
            if (requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_ItalyAdditionalInfoIsNull)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_ItalyAdditionalInfo = null;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_ItalyAdditionalInfo != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation.ItalyAdditionalInfo = requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_ItalyAdditionalInfo;
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformationIsNull = false;
            }
            Amazon.TaxSettings.Model.TurkeyAdditionalInfo requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_TurkeyAdditionalInfo = null;
            
             // populate TurkeyAdditionalInfo
            var requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_TurkeyAdditionalInfoIsNull = true;
            requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_TurkeyAdditionalInfo = new Amazon.TaxSettings.Model.TurkeyAdditionalInfo();
            Amazon.TaxSettings.Industries requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_TurkeyAdditionalInfo_turkeyAdditionalInfo_Industry = null;
            if (cmdletContext.TurkeyAdditionalInfo_Industry != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_TurkeyAdditionalInfo_turkeyAdditionalInfo_Industry = cmdletContext.TurkeyAdditionalInfo_Industry;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_TurkeyAdditionalInfo_turkeyAdditionalInfo_Industry != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_TurkeyAdditionalInfo.Industries = requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_TurkeyAdditionalInfo_turkeyAdditionalInfo_Industry;
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_TurkeyAdditionalInfoIsNull = false;
            }
            System.String requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_TurkeyAdditionalInfo_turkeyAdditionalInfo_KepEmailId = null;
            if (cmdletContext.TurkeyAdditionalInfo_KepEmailId != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_TurkeyAdditionalInfo_turkeyAdditionalInfo_KepEmailId = cmdletContext.TurkeyAdditionalInfo_KepEmailId;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_TurkeyAdditionalInfo_turkeyAdditionalInfo_KepEmailId != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_TurkeyAdditionalInfo.KepEmailId = requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_TurkeyAdditionalInfo_turkeyAdditionalInfo_KepEmailId;
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_TurkeyAdditionalInfoIsNull = false;
            }
            System.String requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_TurkeyAdditionalInfo_turkeyAdditionalInfo_SecondaryTaxId = null;
            if (cmdletContext.TurkeyAdditionalInfo_SecondaryTaxId != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_TurkeyAdditionalInfo_turkeyAdditionalInfo_SecondaryTaxId = cmdletContext.TurkeyAdditionalInfo_SecondaryTaxId;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_TurkeyAdditionalInfo_turkeyAdditionalInfo_SecondaryTaxId != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_TurkeyAdditionalInfo.SecondaryTaxId = requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_TurkeyAdditionalInfo_turkeyAdditionalInfo_SecondaryTaxId;
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_TurkeyAdditionalInfoIsNull = false;
            }
            System.String requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_TurkeyAdditionalInfo_turkeyAdditionalInfo_TaxOffice = null;
            if (cmdletContext.TurkeyAdditionalInfo_TaxOffice != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_TurkeyAdditionalInfo_turkeyAdditionalInfo_TaxOffice = cmdletContext.TurkeyAdditionalInfo_TaxOffice;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_TurkeyAdditionalInfo_turkeyAdditionalInfo_TaxOffice != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_TurkeyAdditionalInfo.TaxOffice = requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_TurkeyAdditionalInfo_turkeyAdditionalInfo_TaxOffice;
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_TurkeyAdditionalInfoIsNull = false;
            }
             // determine if requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_TurkeyAdditionalInfo should be set to null
            if (requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_TurkeyAdditionalInfoIsNull)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_TurkeyAdditionalInfo = null;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_TurkeyAdditionalInfo != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation.TurkeyAdditionalInfo = requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_TurkeyAdditionalInfo;
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformationIsNull = false;
            }
            Amazon.TaxSettings.Model.VietnamAdditionalInfo requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_VietnamAdditionalInfo = null;
            
             // populate VietnamAdditionalInfo
            var requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_VietnamAdditionalInfoIsNull = true;
            requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_VietnamAdditionalInfo = new Amazon.TaxSettings.Model.VietnamAdditionalInfo();
            System.String requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_VietnamAdditionalInfo_vietnamAdditionalInfo_ElectronicTransactionCodeNumber = null;
            if (cmdletContext.VietnamAdditionalInfo_ElectronicTransactionCodeNumber != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_VietnamAdditionalInfo_vietnamAdditionalInfo_ElectronicTransactionCodeNumber = cmdletContext.VietnamAdditionalInfo_ElectronicTransactionCodeNumber;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_VietnamAdditionalInfo_vietnamAdditionalInfo_ElectronicTransactionCodeNumber != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_VietnamAdditionalInfo.ElectronicTransactionCodeNumber = requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_VietnamAdditionalInfo_vietnamAdditionalInfo_ElectronicTransactionCodeNumber;
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_VietnamAdditionalInfoIsNull = false;
            }
            System.String requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_VietnamAdditionalInfo_vietnamAdditionalInfo_EnterpriseIdentificationNumber = null;
            if (cmdletContext.VietnamAdditionalInfo_EnterpriseIdentificationNumber != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_VietnamAdditionalInfo_vietnamAdditionalInfo_EnterpriseIdentificationNumber = cmdletContext.VietnamAdditionalInfo_EnterpriseIdentificationNumber;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_VietnamAdditionalInfo_vietnamAdditionalInfo_EnterpriseIdentificationNumber != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_VietnamAdditionalInfo.EnterpriseIdentificationNumber = requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_VietnamAdditionalInfo_vietnamAdditionalInfo_EnterpriseIdentificationNumber;
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_VietnamAdditionalInfoIsNull = false;
            }
            System.String requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_VietnamAdditionalInfo_vietnamAdditionalInfo_PaymentVoucherNumber = null;
            if (cmdletContext.VietnamAdditionalInfo_PaymentVoucherNumber != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_VietnamAdditionalInfo_vietnamAdditionalInfo_PaymentVoucherNumber = cmdletContext.VietnamAdditionalInfo_PaymentVoucherNumber;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_VietnamAdditionalInfo_vietnamAdditionalInfo_PaymentVoucherNumber != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_VietnamAdditionalInfo.PaymentVoucherNumber = requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_VietnamAdditionalInfo_vietnamAdditionalInfo_PaymentVoucherNumber;
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_VietnamAdditionalInfoIsNull = false;
            }
            System.String requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_VietnamAdditionalInfo_vietnamAdditionalInfo_PaymentVoucherNumberDate = null;
            if (cmdletContext.VietnamAdditionalInfo_PaymentVoucherNumberDate != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_VietnamAdditionalInfo_vietnamAdditionalInfo_PaymentVoucherNumberDate = cmdletContext.VietnamAdditionalInfo_PaymentVoucherNumberDate;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_VietnamAdditionalInfo_vietnamAdditionalInfo_PaymentVoucherNumberDate != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_VietnamAdditionalInfo.PaymentVoucherNumberDate = requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_VietnamAdditionalInfo_vietnamAdditionalInfo_PaymentVoucherNumberDate;
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_VietnamAdditionalInfoIsNull = false;
            }
             // determine if requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_VietnamAdditionalInfo should be set to null
            if (requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_VietnamAdditionalInfoIsNull)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_VietnamAdditionalInfo = null;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_VietnamAdditionalInfo != null)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation.VietnamAdditionalInfo = requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation_taxRegistrationEntry_AdditionalTaxInformation_VietnamAdditionalInfo;
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformationIsNull = false;
            }
             // determine if requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation should be set to null
            if (requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformationIsNull)
            {
                requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation = null;
            }
            if (requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation != null)
            {
                request.TaxRegistrationEntry.AdditionalTaxInformation = requestTaxRegistrationEntry_taxRegistrationEntry_AdditionalTaxInformation;
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
        
        private Amazon.TaxSettings.Model.PutTaxRegistrationResponse CallAWSServiceOperation(IAmazonTaxSettings client, Amazon.TaxSettings.Model.PutTaxRegistrationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Tax Settings", "PutTaxRegistration");
            try
            {
                return client.PutTaxRegistrationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String CanadaAdditionalInfo_CanadaQuebecSalesTaxNumber { get; set; }
            public System.String CanadaAdditionalInfo_CanadaRetailSalesTaxNumber { get; set; }
            public System.Boolean? CanadaAdditionalInfo_IsResellerAccount { get; set; }
            public System.String CanadaAdditionalInfo_ProvincialSalesTaxId { get; set; }
            public System.String EgyptAdditionalInfo_UniqueIdentificationNumber { get; set; }
            public System.String EgyptAdditionalInfo_UniqueIdentificationNumberExpirationDate { get; set; }
            public System.String EstoniaAdditionalInfo_RegistryCommercialCode { get; set; }
            public Amazon.TaxSettings.PersonType GeorgiaAdditionalInfo_PersonType { get; set; }
            public System.String GreeceAdditionalInfo_ContractingAuthorityCode { get; set; }
            public Amazon.TaxSettings.IsraelCustomerType IsraelAdditionalInfo_CustomerType { get; set; }
            public Amazon.TaxSettings.IsraelDealerType IsraelAdditionalInfo_DealerType { get; set; }
            public System.String ItalyAdditionalInfo_CigNumber { get; set; }
            public System.String ItalyAdditionalInfo_CupNumber { get; set; }
            public System.String ItalyAdditionalInfo_SdiAccountId { get; set; }
            public System.String ItalyAdditionalInfo_TaxCode { get; set; }
            public Amazon.TaxSettings.PersonType KenyaAdditionalInfo_PersonType { get; set; }
            public System.String MalaysiaAdditionalInfo_BusinessRegistrationNumber { get; set; }
            public List<System.String> MalaysiaAdditionalInfo_ServiceTaxCode { get; set; }
            public System.String MalaysiaAdditionalInfo_TaxInformationNumber { get; set; }
            public System.String PolandAdditionalInfo_IndividualRegistrationNumber { get; set; }
            public System.Boolean? PolandAdditionalInfo_IsGroupVatEnabled { get; set; }
            public Amazon.TaxSettings.TaxRegistrationNumberType RomaniaAdditionalInfo_TaxRegistrationNumberType { get; set; }
            public Amazon.TaxSettings.SaudiArabiaTaxRegistrationNumberType SaudiArabiaAdditionalInfo_TaxRegistrationNumberType { get; set; }
            public System.String SouthKoreaAdditionalInfo_BusinessRepresentativeName { get; set; }
            public System.String SouthKoreaAdditionalInfo_ItemOfBusiness { get; set; }
            public System.String SouthKoreaAdditionalInfo_LineOfBusiness { get; set; }
            public Amazon.TaxSettings.RegistrationType SpainAdditionalInfo_RegistrationType { get; set; }
            public Amazon.TaxSettings.Industries TurkeyAdditionalInfo_Industry { get; set; }
            public System.String TurkeyAdditionalInfo_KepEmailId { get; set; }
            public System.String TurkeyAdditionalInfo_SecondaryTaxId { get; set; }
            public System.String TurkeyAdditionalInfo_TaxOffice { get; set; }
            public Amazon.TaxSettings.UkraineTrnType UkraineAdditionalInfo_UkraineTrnType { get; set; }
            public Amazon.TaxSettings.UzbekistanTaxRegistrationNumberType UzbekistanAdditionalInfo_TaxRegistrationNumberType { get; set; }
            public System.String UzbekistanAdditionalInfo_VatRegistrationNumber { get; set; }
            public System.String VietnamAdditionalInfo_ElectronicTransactionCodeNumber { get; set; }
            public System.String VietnamAdditionalInfo_EnterpriseIdentificationNumber { get; set; }
            public System.String VietnamAdditionalInfo_PaymentVoucherNumber { get; set; }
            public System.String VietnamAdditionalInfo_PaymentVoucherNumberDate { get; set; }
            public System.String TaxRegistrationEntry_CertifiedEmailId { get; set; }
            public System.String LegalAddress_AddressLine1 { get; set; }
            public System.String LegalAddress_AddressLine2 { get; set; }
            public System.String LegalAddress_AddressLine3 { get; set; }
            public System.String LegalAddress_City { get; set; }
            public System.String LegalAddress_CountryCode { get; set; }
            public System.String LegalAddress_DistrictOrCounty { get; set; }
            public System.String LegalAddress_PostalCode { get; set; }
            public System.String LegalAddress_StateOrRegion { get; set; }
            public System.String TaxRegistrationEntry_LegalName { get; set; }
            public System.String TaxRegistrationEntry_RegistrationId { get; set; }
            public Amazon.TaxSettings.TaxRegistrationType TaxRegistrationEntry_RegistrationType { get; set; }
            public Amazon.TaxSettings.Sector TaxRegistrationEntry_Sector { get; set; }
            public System.String VerificationDetails_DateOfBirth { get; set; }
            public List<Amazon.TaxSettings.Model.TaxRegistrationDocument> VerificationDetails_TaxRegistrationDocument { get; set; }
            public System.Func<Amazon.TaxSettings.Model.PutTaxRegistrationResponse, WriteTSATaxRegistrationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Status;
        }
        
    }
}
