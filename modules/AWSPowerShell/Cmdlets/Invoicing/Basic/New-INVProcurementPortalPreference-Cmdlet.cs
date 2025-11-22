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
using Amazon.Invoicing;
using Amazon.Invoicing.Model;

namespace Amazon.PowerShell.Cmdlets.INV
{
    /// <summary>
    /// Creates a procurement portal preference configuration for e-invoice delivery and purchase
    /// order retrieval. This preference defines how invoices are delivered to a procurement
    /// portal and how purchase orders are retrieved.
    /// </summary>
    [Cmdlet("New", "INVProcurementPortalPreference", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Invoicing CreateProcurementPortalPreference API operation.", Operation = new[] {"CreateProcurementPortalPreference"}, SelectReturnType = typeof(Amazon.Invoicing.Model.CreateProcurementPortalPreferenceResponse))]
    [AWSCmdletOutput("System.String or Amazon.Invoicing.Model.CreateProcurementPortalPreferenceResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Invoicing.Model.CreateProcurementPortalPreferenceResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewINVProcurementPortalPreferenceCmdlet : AmazonInvoicingClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter BuyerDomain
        /// <summary>
        /// <para>
        /// <para>The domain identifier for the buyer in the procurement portal.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Invoicing.BuyerDomain")]
        public Amazon.Invoicing.BuyerDomain BuyerDomain { get; set; }
        #endregion
        
        #region Parameter TestEnvPreference_BuyerDomain
        /// <summary>
        /// <para>
        /// <para>The domain identifier to use for the buyer in the test environment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Invoicing.BuyerDomain")]
        public Amazon.Invoicing.BuyerDomain TestEnvPreference_BuyerDomain { get; set; }
        #endregion
        
        #region Parameter BuyerIdentifier
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the buyer in the procurement portal. </para>
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
        public System.String BuyerIdentifier { get; set; }
        #endregion
        
        #region Parameter TestEnvPreference_BuyerIdentifier
        /// <summary>
        /// <para>
        /// <para>The unique identifier to use for the buyer in the test environment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TestEnvPreference_BuyerIdentifier { get; set; }
        #endregion
        
        #region Parameter EinvoiceDeliveryPreference_ConnectionTestingMethod
        /// <summary>
        /// <para>
        /// <para>The method to use for testing the connection to the procurement portal.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Invoicing.ConnectionTestingMethod")]
        public Amazon.Invoicing.ConnectionTestingMethod EinvoiceDeliveryPreference_ConnectionTestingMethod { get; set; }
        #endregion
        
        #region Parameter Contact
        /// <summary>
        /// <para>
        /// <para>List of contact information for portal administrators and technical contacts responsible
        /// for the e-invoice integration.</para>
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
        [Alias("Contacts")]
        public Amazon.Invoicing.Model.Contact[] Contact { get; set; }
        #endregion
        
        #region Parameter EinvoiceDeliveryPreference_EinvoiceDeliveryActivationDate
        /// <summary>
        /// <para>
        /// <para>The date when e-invoice delivery should be activated for this preference.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? EinvoiceDeliveryPreference_EinvoiceDeliveryActivationDate { get; set; }
        #endregion
        
        #region Parameter EinvoiceDeliveryPreference_EinvoiceDeliveryAttachmentType
        /// <summary>
        /// <para>
        /// <para>The types of attachments to include with the e-invoice delivery.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EinvoiceDeliveryPreference_EinvoiceDeliveryAttachmentTypes")]
        public System.String[] EinvoiceDeliveryPreference_EinvoiceDeliveryAttachmentType { get; set; }
        #endregion
        
        #region Parameter EinvoiceDeliveryPreference_EinvoiceDeliveryDocumentType
        /// <summary>
        /// <para>
        /// <para>The types of e-invoice documents to be delivered.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EinvoiceDeliveryPreference_EinvoiceDeliveryDocumentTypes")]
        public System.String[] EinvoiceDeliveryPreference_EinvoiceDeliveryDocumentType { get; set; }
        #endregion
        
        #region Parameter EinvoiceDeliveryEnabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether e-invoice delivery is enabled for this procurement portal preference.
        /// Set to true to enable e-invoice delivery, false to disable.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Boolean? EinvoiceDeliveryEnabled { get; set; }
        #endregion
        
        #region Parameter Selector_InvoiceUnitArn
        /// <summary>
        /// <para>
        /// <para> The Amazon Resource Name (ARN) of invoice unit identifiers to which this preference
        /// applies. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Selector_InvoiceUnitArns")]
        public System.String[] Selector_InvoiceUnitArn { get; set; }
        #endregion
        
        #region Parameter ProcurementPortalInstanceEndpoint
        /// <summary>
        /// <para>
        /// <para>The endpoint URL where e-invoices will be delivered to the procurement portal. Must
        /// be a valid HTTPS URL.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProcurementPortalInstanceEndpoint { get; set; }
        #endregion
        
        #region Parameter TestEnvPreference_ProcurementPortalInstanceEndpoint
        /// <summary>
        /// <para>
        /// <para>The endpoint URL where e-invoices will be delivered in the test environment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TestEnvPreference_ProcurementPortalInstanceEndpoint { get; set; }
        #endregion
        
        #region Parameter ProcurementPortalName
        /// <summary>
        /// <para>
        /// <para>The name of the procurement portal.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Invoicing.ProcurementPortalName")]
        public Amazon.Invoicing.ProcurementPortalName ProcurementPortalName { get; set; }
        #endregion
        
        #region Parameter ProcurementPortalSharedSecret
        /// <summary>
        /// <para>
        /// <para>The shared secret or authentication credential used to establish secure communication
        /// with the procurement portal. This value must be encrypted at rest.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProcurementPortalSharedSecret { get; set; }
        #endregion
        
        #region Parameter TestEnvPreference_ProcurementPortalSharedSecret
        /// <summary>
        /// <para>
        /// <para>The shared secret or authentication credential to use for secure communication in
        /// the test environment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TestEnvPreference_ProcurementPortalSharedSecret { get; set; }
        #endregion
        
        #region Parameter EinvoiceDeliveryPreference_Protocol
        /// <summary>
        /// <para>
        /// <para>The communication protocol to use for e-invoice delivery.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Invoicing.Protocol")]
        public Amazon.Invoicing.Protocol EinvoiceDeliveryPreference_Protocol { get; set; }
        #endregion
        
        #region Parameter EinvoiceDeliveryPreference_PurchaseOrderDataSource
        /// <summary>
        /// <para>
        /// <para>The sources of purchase order data to use for e-invoice generation and delivery.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EinvoiceDeliveryPreference_PurchaseOrderDataSources")]
        public Amazon.Invoicing.Model.PurchaseOrderDataSource[] EinvoiceDeliveryPreference_PurchaseOrderDataSource { get; set; }
        #endregion
        
        #region Parameter PurchaseOrderRetrievalEnabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether purchase order retrieval is enabled for this procurement portal
        /// preference. Set to true to enable PO retrieval, false to disable.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Boolean? PurchaseOrderRetrievalEnabled { get; set; }
        #endregion
        
        #region Parameter ResourceTag
        /// <summary>
        /// <para>
        /// <para>The tags to apply to this procurement portal preference resource. Each tag consists
        /// of a key and an optional value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceTags")]
        public Amazon.Invoicing.Model.ResourceTag[] ResourceTag { get; set; }
        #endregion
        
        #region Parameter Selector_SellerOfRecord
        /// <summary>
        /// <para>
        /// <para> The list of seller of record IDs to which this preference applies. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Selector_SellerOfRecords")]
        public System.String[] Selector_SellerOfRecord { get; set; }
        #endregion
        
        #region Parameter SupplierDomain
        /// <summary>
        /// <para>
        /// <para>The domain identifier for the supplier in the procurement portal.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Invoicing.SupplierDomain")]
        public Amazon.Invoicing.SupplierDomain SupplierDomain { get; set; }
        #endregion
        
        #region Parameter TestEnvPreference_SupplierDomain
        /// <summary>
        /// <para>
        /// <para>The domain identifier to use for the supplier in the test environment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Invoicing.SupplierDomain")]
        public Amazon.Invoicing.SupplierDomain TestEnvPreference_SupplierDomain { get; set; }
        #endregion
        
        #region Parameter SupplierIdentifier
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the supplier in the procurement portal.</para>
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
        public System.String SupplierIdentifier { get; set; }
        #endregion
        
        #region Parameter TestEnvPreference_SupplierIdentifier
        /// <summary>
        /// <para>
        /// <para>The unique identifier to use for the supplier in the test environment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TestEnvPreference_SupplierIdentifier { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure idempotency of the
        /// request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ProcurementPortalPreferenceArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Invoicing.Model.CreateProcurementPortalPreferenceResponse).
        /// Specifying the name of a property of type Amazon.Invoicing.Model.CreateProcurementPortalPreferenceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ProcurementPortalPreferenceArn";
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
            
            var targetParameterNames = new string[]
            {
                nameof(this.ProcurementPortalName),
                nameof(this.BuyerIdentifier),
                nameof(this.SupplierIdentifier)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-INVProcurementPortalPreference (CreateProcurementPortalPreference)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Invoicing.Model.CreateProcurementPortalPreferenceResponse, NewINVProcurementPortalPreferenceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BuyerDomain = this.BuyerDomain;
            #if MODULAR
            if (this.BuyerDomain == null && ParameterWasBound(nameof(this.BuyerDomain)))
            {
                WriteWarning("You are passing $null as a value for parameter BuyerDomain which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.BuyerIdentifier = this.BuyerIdentifier;
            #if MODULAR
            if (this.BuyerIdentifier == null && ParameterWasBound(nameof(this.BuyerIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter BuyerIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            if (this.Contact != null)
            {
                context.Contact = new List<Amazon.Invoicing.Model.Contact>(this.Contact);
            }
            #if MODULAR
            if (this.Contact == null && ParameterWasBound(nameof(this.Contact)))
            {
                WriteWarning("You are passing $null as a value for parameter Contact which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EinvoiceDeliveryEnabled = this.EinvoiceDeliveryEnabled;
            #if MODULAR
            if (this.EinvoiceDeliveryEnabled == null && ParameterWasBound(nameof(this.EinvoiceDeliveryEnabled)))
            {
                WriteWarning("You are passing $null as a value for parameter EinvoiceDeliveryEnabled which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EinvoiceDeliveryPreference_ConnectionTestingMethod = this.EinvoiceDeliveryPreference_ConnectionTestingMethod;
            context.EinvoiceDeliveryPreference_EinvoiceDeliveryActivationDate = this.EinvoiceDeliveryPreference_EinvoiceDeliveryActivationDate;
            if (this.EinvoiceDeliveryPreference_EinvoiceDeliveryAttachmentType != null)
            {
                context.EinvoiceDeliveryPreference_EinvoiceDeliveryAttachmentType = new List<System.String>(this.EinvoiceDeliveryPreference_EinvoiceDeliveryAttachmentType);
            }
            if (this.EinvoiceDeliveryPreference_EinvoiceDeliveryDocumentType != null)
            {
                context.EinvoiceDeliveryPreference_EinvoiceDeliveryDocumentType = new List<System.String>(this.EinvoiceDeliveryPreference_EinvoiceDeliveryDocumentType);
            }
            context.EinvoiceDeliveryPreference_Protocol = this.EinvoiceDeliveryPreference_Protocol;
            if (this.EinvoiceDeliveryPreference_PurchaseOrderDataSource != null)
            {
                context.EinvoiceDeliveryPreference_PurchaseOrderDataSource = new List<Amazon.Invoicing.Model.PurchaseOrderDataSource>(this.EinvoiceDeliveryPreference_PurchaseOrderDataSource);
            }
            context.ProcurementPortalInstanceEndpoint = this.ProcurementPortalInstanceEndpoint;
            context.ProcurementPortalName = this.ProcurementPortalName;
            #if MODULAR
            if (this.ProcurementPortalName == null && ParameterWasBound(nameof(this.ProcurementPortalName)))
            {
                WriteWarning("You are passing $null as a value for parameter ProcurementPortalName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ProcurementPortalSharedSecret = this.ProcurementPortalSharedSecret;
            context.PurchaseOrderRetrievalEnabled = this.PurchaseOrderRetrievalEnabled;
            #if MODULAR
            if (this.PurchaseOrderRetrievalEnabled == null && ParameterWasBound(nameof(this.PurchaseOrderRetrievalEnabled)))
            {
                WriteWarning("You are passing $null as a value for parameter PurchaseOrderRetrievalEnabled which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ResourceTag != null)
            {
                context.ResourceTag = new List<Amazon.Invoicing.Model.ResourceTag>(this.ResourceTag);
            }
            if (this.Selector_InvoiceUnitArn != null)
            {
                context.Selector_InvoiceUnitArn = new List<System.String>(this.Selector_InvoiceUnitArn);
            }
            if (this.Selector_SellerOfRecord != null)
            {
                context.Selector_SellerOfRecord = new List<System.String>(this.Selector_SellerOfRecord);
            }
            context.SupplierDomain = this.SupplierDomain;
            #if MODULAR
            if (this.SupplierDomain == null && ParameterWasBound(nameof(this.SupplierDomain)))
            {
                WriteWarning("You are passing $null as a value for parameter SupplierDomain which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SupplierIdentifier = this.SupplierIdentifier;
            #if MODULAR
            if (this.SupplierIdentifier == null && ParameterWasBound(nameof(this.SupplierIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter SupplierIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TestEnvPreference_BuyerDomain = this.TestEnvPreference_BuyerDomain;
            context.TestEnvPreference_BuyerIdentifier = this.TestEnvPreference_BuyerIdentifier;
            context.TestEnvPreference_ProcurementPortalInstanceEndpoint = this.TestEnvPreference_ProcurementPortalInstanceEndpoint;
            context.TestEnvPreference_ProcurementPortalSharedSecret = this.TestEnvPreference_ProcurementPortalSharedSecret;
            context.TestEnvPreference_SupplierDomain = this.TestEnvPreference_SupplierDomain;
            context.TestEnvPreference_SupplierIdentifier = this.TestEnvPreference_SupplierIdentifier;
            
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
            var request = new Amazon.Invoicing.Model.CreateProcurementPortalPreferenceRequest();
            
            if (cmdletContext.BuyerDomain != null)
            {
                request.BuyerDomain = cmdletContext.BuyerDomain;
            }
            if (cmdletContext.BuyerIdentifier != null)
            {
                request.BuyerIdentifier = cmdletContext.BuyerIdentifier;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Contact != null)
            {
                request.Contacts = cmdletContext.Contact;
            }
            if (cmdletContext.EinvoiceDeliveryEnabled != null)
            {
                request.EinvoiceDeliveryEnabled = cmdletContext.EinvoiceDeliveryEnabled.Value;
            }
            
             // populate EinvoiceDeliveryPreference
            var requestEinvoiceDeliveryPreferenceIsNull = true;
            request.EinvoiceDeliveryPreference = new Amazon.Invoicing.Model.EinvoiceDeliveryPreference();
            Amazon.Invoicing.ConnectionTestingMethod requestEinvoiceDeliveryPreference_einvoiceDeliveryPreference_ConnectionTestingMethod = null;
            if (cmdletContext.EinvoiceDeliveryPreference_ConnectionTestingMethod != null)
            {
                requestEinvoiceDeliveryPreference_einvoiceDeliveryPreference_ConnectionTestingMethod = cmdletContext.EinvoiceDeliveryPreference_ConnectionTestingMethod;
            }
            if (requestEinvoiceDeliveryPreference_einvoiceDeliveryPreference_ConnectionTestingMethod != null)
            {
                request.EinvoiceDeliveryPreference.ConnectionTestingMethod = requestEinvoiceDeliveryPreference_einvoiceDeliveryPreference_ConnectionTestingMethod;
                requestEinvoiceDeliveryPreferenceIsNull = false;
            }
            System.DateTime? requestEinvoiceDeliveryPreference_einvoiceDeliveryPreference_EinvoiceDeliveryActivationDate = null;
            if (cmdletContext.EinvoiceDeliveryPreference_EinvoiceDeliveryActivationDate != null)
            {
                requestEinvoiceDeliveryPreference_einvoiceDeliveryPreference_EinvoiceDeliveryActivationDate = cmdletContext.EinvoiceDeliveryPreference_EinvoiceDeliveryActivationDate.Value;
            }
            if (requestEinvoiceDeliveryPreference_einvoiceDeliveryPreference_EinvoiceDeliveryActivationDate != null)
            {
                request.EinvoiceDeliveryPreference.EinvoiceDeliveryActivationDate = requestEinvoiceDeliveryPreference_einvoiceDeliveryPreference_EinvoiceDeliveryActivationDate.Value;
                requestEinvoiceDeliveryPreferenceIsNull = false;
            }
            List<System.String> requestEinvoiceDeliveryPreference_einvoiceDeliveryPreference_EinvoiceDeliveryAttachmentType = null;
            if (cmdletContext.EinvoiceDeliveryPreference_EinvoiceDeliveryAttachmentType != null)
            {
                requestEinvoiceDeliveryPreference_einvoiceDeliveryPreference_EinvoiceDeliveryAttachmentType = cmdletContext.EinvoiceDeliveryPreference_EinvoiceDeliveryAttachmentType;
            }
            if (requestEinvoiceDeliveryPreference_einvoiceDeliveryPreference_EinvoiceDeliveryAttachmentType != null)
            {
                request.EinvoiceDeliveryPreference.EinvoiceDeliveryAttachmentTypes = requestEinvoiceDeliveryPreference_einvoiceDeliveryPreference_EinvoiceDeliveryAttachmentType;
                requestEinvoiceDeliveryPreferenceIsNull = false;
            }
            List<System.String> requestEinvoiceDeliveryPreference_einvoiceDeliveryPreference_EinvoiceDeliveryDocumentType = null;
            if (cmdletContext.EinvoiceDeliveryPreference_EinvoiceDeliveryDocumentType != null)
            {
                requestEinvoiceDeliveryPreference_einvoiceDeliveryPreference_EinvoiceDeliveryDocumentType = cmdletContext.EinvoiceDeliveryPreference_EinvoiceDeliveryDocumentType;
            }
            if (requestEinvoiceDeliveryPreference_einvoiceDeliveryPreference_EinvoiceDeliveryDocumentType != null)
            {
                request.EinvoiceDeliveryPreference.EinvoiceDeliveryDocumentTypes = requestEinvoiceDeliveryPreference_einvoiceDeliveryPreference_EinvoiceDeliveryDocumentType;
                requestEinvoiceDeliveryPreferenceIsNull = false;
            }
            Amazon.Invoicing.Protocol requestEinvoiceDeliveryPreference_einvoiceDeliveryPreference_Protocol = null;
            if (cmdletContext.EinvoiceDeliveryPreference_Protocol != null)
            {
                requestEinvoiceDeliveryPreference_einvoiceDeliveryPreference_Protocol = cmdletContext.EinvoiceDeliveryPreference_Protocol;
            }
            if (requestEinvoiceDeliveryPreference_einvoiceDeliveryPreference_Protocol != null)
            {
                request.EinvoiceDeliveryPreference.Protocol = requestEinvoiceDeliveryPreference_einvoiceDeliveryPreference_Protocol;
                requestEinvoiceDeliveryPreferenceIsNull = false;
            }
            List<Amazon.Invoicing.Model.PurchaseOrderDataSource> requestEinvoiceDeliveryPreference_einvoiceDeliveryPreference_PurchaseOrderDataSource = null;
            if (cmdletContext.EinvoiceDeliveryPreference_PurchaseOrderDataSource != null)
            {
                requestEinvoiceDeliveryPreference_einvoiceDeliveryPreference_PurchaseOrderDataSource = cmdletContext.EinvoiceDeliveryPreference_PurchaseOrderDataSource;
            }
            if (requestEinvoiceDeliveryPreference_einvoiceDeliveryPreference_PurchaseOrderDataSource != null)
            {
                request.EinvoiceDeliveryPreference.PurchaseOrderDataSources = requestEinvoiceDeliveryPreference_einvoiceDeliveryPreference_PurchaseOrderDataSource;
                requestEinvoiceDeliveryPreferenceIsNull = false;
            }
             // determine if request.EinvoiceDeliveryPreference should be set to null
            if (requestEinvoiceDeliveryPreferenceIsNull)
            {
                request.EinvoiceDeliveryPreference = null;
            }
            if (cmdletContext.ProcurementPortalInstanceEndpoint != null)
            {
                request.ProcurementPortalInstanceEndpoint = cmdletContext.ProcurementPortalInstanceEndpoint;
            }
            if (cmdletContext.ProcurementPortalName != null)
            {
                request.ProcurementPortalName = cmdletContext.ProcurementPortalName;
            }
            if (cmdletContext.ProcurementPortalSharedSecret != null)
            {
                request.ProcurementPortalSharedSecret = cmdletContext.ProcurementPortalSharedSecret;
            }
            if (cmdletContext.PurchaseOrderRetrievalEnabled != null)
            {
                request.PurchaseOrderRetrievalEnabled = cmdletContext.PurchaseOrderRetrievalEnabled.Value;
            }
            if (cmdletContext.ResourceTag != null)
            {
                request.ResourceTags = cmdletContext.ResourceTag;
            }
            
             // populate Selector
            var requestSelectorIsNull = true;
            request.Selector = new Amazon.Invoicing.Model.ProcurementPortalPreferenceSelector();
            List<System.String> requestSelector_selector_InvoiceUnitArn = null;
            if (cmdletContext.Selector_InvoiceUnitArn != null)
            {
                requestSelector_selector_InvoiceUnitArn = cmdletContext.Selector_InvoiceUnitArn;
            }
            if (requestSelector_selector_InvoiceUnitArn != null)
            {
                request.Selector.InvoiceUnitArns = requestSelector_selector_InvoiceUnitArn;
                requestSelectorIsNull = false;
            }
            List<System.String> requestSelector_selector_SellerOfRecord = null;
            if (cmdletContext.Selector_SellerOfRecord != null)
            {
                requestSelector_selector_SellerOfRecord = cmdletContext.Selector_SellerOfRecord;
            }
            if (requestSelector_selector_SellerOfRecord != null)
            {
                request.Selector.SellerOfRecords = requestSelector_selector_SellerOfRecord;
                requestSelectorIsNull = false;
            }
             // determine if request.Selector should be set to null
            if (requestSelectorIsNull)
            {
                request.Selector = null;
            }
            if (cmdletContext.SupplierDomain != null)
            {
                request.SupplierDomain = cmdletContext.SupplierDomain;
            }
            if (cmdletContext.SupplierIdentifier != null)
            {
                request.SupplierIdentifier = cmdletContext.SupplierIdentifier;
            }
            
             // populate TestEnvPreference
            var requestTestEnvPreferenceIsNull = true;
            request.TestEnvPreference = new Amazon.Invoicing.Model.TestEnvPreferenceInput();
            Amazon.Invoicing.BuyerDomain requestTestEnvPreference_testEnvPreference_BuyerDomain = null;
            if (cmdletContext.TestEnvPreference_BuyerDomain != null)
            {
                requestTestEnvPreference_testEnvPreference_BuyerDomain = cmdletContext.TestEnvPreference_BuyerDomain;
            }
            if (requestTestEnvPreference_testEnvPreference_BuyerDomain != null)
            {
                request.TestEnvPreference.BuyerDomain = requestTestEnvPreference_testEnvPreference_BuyerDomain;
                requestTestEnvPreferenceIsNull = false;
            }
            System.String requestTestEnvPreference_testEnvPreference_BuyerIdentifier = null;
            if (cmdletContext.TestEnvPreference_BuyerIdentifier != null)
            {
                requestTestEnvPreference_testEnvPreference_BuyerIdentifier = cmdletContext.TestEnvPreference_BuyerIdentifier;
            }
            if (requestTestEnvPreference_testEnvPreference_BuyerIdentifier != null)
            {
                request.TestEnvPreference.BuyerIdentifier = requestTestEnvPreference_testEnvPreference_BuyerIdentifier;
                requestTestEnvPreferenceIsNull = false;
            }
            System.String requestTestEnvPreference_testEnvPreference_ProcurementPortalInstanceEndpoint = null;
            if (cmdletContext.TestEnvPreference_ProcurementPortalInstanceEndpoint != null)
            {
                requestTestEnvPreference_testEnvPreference_ProcurementPortalInstanceEndpoint = cmdletContext.TestEnvPreference_ProcurementPortalInstanceEndpoint;
            }
            if (requestTestEnvPreference_testEnvPreference_ProcurementPortalInstanceEndpoint != null)
            {
                request.TestEnvPreference.ProcurementPortalInstanceEndpoint = requestTestEnvPreference_testEnvPreference_ProcurementPortalInstanceEndpoint;
                requestTestEnvPreferenceIsNull = false;
            }
            System.String requestTestEnvPreference_testEnvPreference_ProcurementPortalSharedSecret = null;
            if (cmdletContext.TestEnvPreference_ProcurementPortalSharedSecret != null)
            {
                requestTestEnvPreference_testEnvPreference_ProcurementPortalSharedSecret = cmdletContext.TestEnvPreference_ProcurementPortalSharedSecret;
            }
            if (requestTestEnvPreference_testEnvPreference_ProcurementPortalSharedSecret != null)
            {
                request.TestEnvPreference.ProcurementPortalSharedSecret = requestTestEnvPreference_testEnvPreference_ProcurementPortalSharedSecret;
                requestTestEnvPreferenceIsNull = false;
            }
            Amazon.Invoicing.SupplierDomain requestTestEnvPreference_testEnvPreference_SupplierDomain = null;
            if (cmdletContext.TestEnvPreference_SupplierDomain != null)
            {
                requestTestEnvPreference_testEnvPreference_SupplierDomain = cmdletContext.TestEnvPreference_SupplierDomain;
            }
            if (requestTestEnvPreference_testEnvPreference_SupplierDomain != null)
            {
                request.TestEnvPreference.SupplierDomain = requestTestEnvPreference_testEnvPreference_SupplierDomain;
                requestTestEnvPreferenceIsNull = false;
            }
            System.String requestTestEnvPreference_testEnvPreference_SupplierIdentifier = null;
            if (cmdletContext.TestEnvPreference_SupplierIdentifier != null)
            {
                requestTestEnvPreference_testEnvPreference_SupplierIdentifier = cmdletContext.TestEnvPreference_SupplierIdentifier;
            }
            if (requestTestEnvPreference_testEnvPreference_SupplierIdentifier != null)
            {
                request.TestEnvPreference.SupplierIdentifier = requestTestEnvPreference_testEnvPreference_SupplierIdentifier;
                requestTestEnvPreferenceIsNull = false;
            }
             // determine if request.TestEnvPreference should be set to null
            if (requestTestEnvPreferenceIsNull)
            {
                request.TestEnvPreference = null;
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
        
        private Amazon.Invoicing.Model.CreateProcurementPortalPreferenceResponse CallAWSServiceOperation(IAmazonInvoicing client, Amazon.Invoicing.Model.CreateProcurementPortalPreferenceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Invoicing", "CreateProcurementPortalPreference");
            try
            {
                #if DESKTOP
                return client.CreateProcurementPortalPreference(request);
                #elif CORECLR
                return client.CreateProcurementPortalPreferenceAsync(request).GetAwaiter().GetResult();
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
            public Amazon.Invoicing.BuyerDomain BuyerDomain { get; set; }
            public System.String BuyerIdentifier { get; set; }
            public System.String ClientToken { get; set; }
            public List<Amazon.Invoicing.Model.Contact> Contact { get; set; }
            public System.Boolean? EinvoiceDeliveryEnabled { get; set; }
            public Amazon.Invoicing.ConnectionTestingMethod EinvoiceDeliveryPreference_ConnectionTestingMethod { get; set; }
            public System.DateTime? EinvoiceDeliveryPreference_EinvoiceDeliveryActivationDate { get; set; }
            public List<System.String> EinvoiceDeliveryPreference_EinvoiceDeliveryAttachmentType { get; set; }
            public List<System.String> EinvoiceDeliveryPreference_EinvoiceDeliveryDocumentType { get; set; }
            public Amazon.Invoicing.Protocol EinvoiceDeliveryPreference_Protocol { get; set; }
            public List<Amazon.Invoicing.Model.PurchaseOrderDataSource> EinvoiceDeliveryPreference_PurchaseOrderDataSource { get; set; }
            public System.String ProcurementPortalInstanceEndpoint { get; set; }
            public Amazon.Invoicing.ProcurementPortalName ProcurementPortalName { get; set; }
            public System.String ProcurementPortalSharedSecret { get; set; }
            public System.Boolean? PurchaseOrderRetrievalEnabled { get; set; }
            public List<Amazon.Invoicing.Model.ResourceTag> ResourceTag { get; set; }
            public List<System.String> Selector_InvoiceUnitArn { get; set; }
            public List<System.String> Selector_SellerOfRecord { get; set; }
            public Amazon.Invoicing.SupplierDomain SupplierDomain { get; set; }
            public System.String SupplierIdentifier { get; set; }
            public Amazon.Invoicing.BuyerDomain TestEnvPreference_BuyerDomain { get; set; }
            public System.String TestEnvPreference_BuyerIdentifier { get; set; }
            public System.String TestEnvPreference_ProcurementPortalInstanceEndpoint { get; set; }
            public System.String TestEnvPreference_ProcurementPortalSharedSecret { get; set; }
            public Amazon.Invoicing.SupplierDomain TestEnvPreference_SupplierDomain { get; set; }
            public System.String TestEnvPreference_SupplierIdentifier { get; set; }
            public System.Func<Amazon.Invoicing.Model.CreateProcurementPortalPreferenceResponse, NewINVProcurementPortalPreferenceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ProcurementPortalPreferenceArn;
        }
        
    }
}
