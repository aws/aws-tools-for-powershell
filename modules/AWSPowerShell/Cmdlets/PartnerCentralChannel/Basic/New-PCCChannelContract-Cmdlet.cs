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
using Amazon.PartnerCentralChannel;
using Amazon.PartnerCentralChannel.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.PCC
{
    /// <summary>
    /// Creates a new channel contract and sends it to the signatory for signature. In the
    /// Sandbox catalog, the channel contract is accepted automatically.
    /// </summary>
    [Cmdlet("New", "PCCChannelContract", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.PartnerCentralChannel.Model.CreateChannelContractDetail")]
    [AWSCmdlet("Calls the Partner Central Channel API CreateChannelContract API operation.", Operation = new[] {"CreateChannelContract"}, SelectReturnType = typeof(Amazon.PartnerCentralChannel.Model.CreateChannelContractResponse))]
    [AWSCmdletOutput("Amazon.PartnerCentralChannel.Model.CreateChannelContractDetail or Amazon.PartnerCentralChannel.Model.CreateChannelContractResponse",
        "This cmdlet returns an Amazon.PartnerCentralChannel.Model.CreateChannelContractDetail object.",
        "The service call response (type Amazon.PartnerCentralChannel.Model.CreateChannelContractResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewPCCChannelContractCmdlet : AmazonPartnerCentralChannelClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Payload_ManagedServicesAttestationPayload_LegalEntityAddress_AddressLine
        /// <summary>
        /// <para>
        /// <para>The first line of the street address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Payload_ManagedServicesAttestationPayload_LegalEntityAddress_AddressLine { get; set; }
        #endregion
        
        #region Parameter Payload_ManagedServicesAttestationPayload_LegalEntityAddress_AddressLine2
        /// <summary>
        /// <para>
        /// <para>The second line of the street address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Payload_ManagedServicesAttestationPayload_LegalEntityAddress_AddressLine2 { get; set; }
        #endregion
        
        #region Parameter Catalog
        /// <summary>
        /// <para>
        /// <para>The catalog identifier for the channel contract.</para>
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
        
        #region Parameter Payload_ManagedServicesAttestationPayload_LegalEntityAddress_City
        /// <summary>
        /// <para>
        /// <para>The city or locality.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Payload_ManagedServicesAttestationPayload_LegalEntityAddress_City { get; set; }
        #endregion
        
        #region Parameter ContractType
        /// <summary>
        /// <para>
        /// <para>The type of channel contract to create (for example, managed services attestation).</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.PartnerCentralChannel.ChannelContractType")]
        public Amazon.PartnerCentralChannel.ChannelContractType ContractType { get; set; }
        #endregion
        
        #region Parameter Payload_ManagedServicesAttestationPayload_LegalEntityAddress_CountryCode
        /// <summary>
        /// <para>
        /// <para>The two-letter ISO 3166-1 country code.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Payload_ManagedServicesAttestationPayload_LegalEntityAddress_CountryCode { get; set; }
        #endregion
        
        #region Parameter Payload_ManagedServicesAttestationPayload_EndDate
        /// <summary>
        /// <para>
        /// <para>The end date of the attestation, which must be after the start date of the relationship.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? Payload_ManagedServicesAttestationPayload_EndDate { get; set; }
        #endregion
        
        #region Parameter Payload_ManagedServicesAttestationPayload_LegalEntityName
        /// <summary>
        /// <para>
        /// <para>The legal name of the end customer's legal entity.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Payload_ManagedServicesAttestationPayload_LegalEntityName { get; set; }
        #endregion
        
        #region Parameter Payload_ManagedServicesAttestationPayload_MemberAccountId
        /// <summary>
        /// <para>
        /// <para>The AWS account IDs of the end customer's member accounts to cover, not allowed when
        /// the account scope is the entire organization.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Payload_ManagedServicesAttestationPayload_MemberAccountIds")]
        public System.String[] Payload_ManagedServicesAttestationPayload_MemberAccountId { get; set; }
        #endregion
        
        #region Parameter Payload_ManagedServicesAttestationPayload_LegalEntityAddress_PostalCode
        /// <summary>
        /// <para>
        /// <para>The postal code.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Payload_ManagedServicesAttestationPayload_LegalEntityAddress_PostalCode { get; set; }
        #endregion
        
        #region Parameter Payload_ManagedServicesAttestationPayload_ProgramManagementAccountIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the program management account for the relationship.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Payload_ManagedServicesAttestationPayload_ProgramManagementAccountIdentifier { get; set; }
        #endregion
        
        #region Parameter Payload_ManagedServicesAttestationPayload_RelationshipIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the managed services relationship to cover with the attestation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Payload_ManagedServicesAttestationPayload_RelationshipIdentifier { get; set; }
        #endregion
        
        #region Parameter Payload_ManagedServicesAttestationPayload_SignatoryEmail
        /// <summary>
        /// <para>
        /// <para>The email address to which the attestation is sent for signature.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Payload_ManagedServicesAttestationPayload_SignatoryEmail { get; set; }
        #endregion
        
        #region Parameter Payload_ManagedServicesAttestationPayload_SignatoryName
        /// <summary>
        /// <para>
        /// <para>The name of the person who signs the attestation for the end customer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Payload_ManagedServicesAttestationPayload_SignatoryName { get; set; }
        #endregion
        
        #region Parameter Payload_ManagedServicesAttestationPayload_LegalEntityAddress_StateOrRegion
        /// <summary>
        /// <para>
        /// <para>The state, province, or prefecture.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Payload_ManagedServicesAttestationPayload_LegalEntityAddress_StateOrRegion { get; set; }
        #endregion
        
        #region Parameter Payload_ManagedServicesAttestationPayload_SupportedService
        /// <summary>
        /// <para>
        /// <para>The managed services that the partner provides to the end customer.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Payload_ManagedServicesAttestationPayload_SupportedServices")]
        public System.String[] Payload_ManagedServicesAttestationPayload_SupportedService { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Key-value pairs to associate with the channel contract.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.PartnerCentralChannel.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier to ensure idempotency of the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ChannelContractDetail'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PartnerCentralChannel.Model.CreateChannelContractResponse).
        /// Specifying the name of a property of type Amazon.PartnerCentralChannel.Model.CreateChannelContractResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ChannelContractDetail";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-PCCChannelContract (CreateChannelContract)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PartnerCentralChannel.Model.CreateChannelContractResponse, NewPCCChannelContractCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Catalog = this.Catalog;
            #if MODULAR
            if (this.Catalog == null && ParameterWasBound(nameof(this.Catalog)))
            {
                WriteWarning("You are passing $null as a value for parameter Catalog which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.ContractType = this.ContractType;
            #if MODULAR
            if (this.ContractType == null && ParameterWasBound(nameof(this.ContractType)))
            {
                WriteWarning("You are passing $null as a value for parameter ContractType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Payload_ManagedServicesAttestationPayload_EndDate = this.Payload_ManagedServicesAttestationPayload_EndDate;
            context.Payload_ManagedServicesAttestationPayload_LegalEntityAddress_AddressLine = this.Payload_ManagedServicesAttestationPayload_LegalEntityAddress_AddressLine;
            context.Payload_ManagedServicesAttestationPayload_LegalEntityAddress_AddressLine2 = this.Payload_ManagedServicesAttestationPayload_LegalEntityAddress_AddressLine2;
            context.Payload_ManagedServicesAttestationPayload_LegalEntityAddress_City = this.Payload_ManagedServicesAttestationPayload_LegalEntityAddress_City;
            context.Payload_ManagedServicesAttestationPayload_LegalEntityAddress_CountryCode = this.Payload_ManagedServicesAttestationPayload_LegalEntityAddress_CountryCode;
            context.Payload_ManagedServicesAttestationPayload_LegalEntityAddress_PostalCode = this.Payload_ManagedServicesAttestationPayload_LegalEntityAddress_PostalCode;
            context.Payload_ManagedServicesAttestationPayload_LegalEntityAddress_StateOrRegion = this.Payload_ManagedServicesAttestationPayload_LegalEntityAddress_StateOrRegion;
            context.Payload_ManagedServicesAttestationPayload_LegalEntityName = this.Payload_ManagedServicesAttestationPayload_LegalEntityName;
            if (this.Payload_ManagedServicesAttestationPayload_MemberAccountId != null)
            {
                context.Payload_ManagedServicesAttestationPayload_MemberAccountId = new List<System.String>(this.Payload_ManagedServicesAttestationPayload_MemberAccountId);
            }
            context.Payload_ManagedServicesAttestationPayload_ProgramManagementAccountIdentifier = this.Payload_ManagedServicesAttestationPayload_ProgramManagementAccountIdentifier;
            context.Payload_ManagedServicesAttestationPayload_RelationshipIdentifier = this.Payload_ManagedServicesAttestationPayload_RelationshipIdentifier;
            context.Payload_ManagedServicesAttestationPayload_SignatoryEmail = this.Payload_ManagedServicesAttestationPayload_SignatoryEmail;
            context.Payload_ManagedServicesAttestationPayload_SignatoryName = this.Payload_ManagedServicesAttestationPayload_SignatoryName;
            if (this.Payload_ManagedServicesAttestationPayload_SupportedService != null)
            {
                context.Payload_ManagedServicesAttestationPayload_SupportedService = new List<System.String>(this.Payload_ManagedServicesAttestationPayload_SupportedService);
            }
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.PartnerCentralChannel.Model.Tag>(this.Tag);
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
            var request = new Amazon.PartnerCentralChannel.Model.CreateChannelContractRequest();
            
            if (cmdletContext.Catalog != null)
            {
                request.Catalog = cmdletContext.Catalog;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.ContractType != null)
            {
                request.ContractType = cmdletContext.ContractType;
            }
            
             // populate Payload
            var requestPayloadIsNull = true;
            request.Payload = new Amazon.PartnerCentralChannel.Model.ChannelContractPayload();
            Amazon.PartnerCentralChannel.Model.ManagedServicesAttestationPayload requestPayload_payload_ManagedServicesAttestationPayload = null;
            
             // populate ManagedServicesAttestationPayload
            var requestPayload_payload_ManagedServicesAttestationPayloadIsNull = true;
            requestPayload_payload_ManagedServicesAttestationPayload = new Amazon.PartnerCentralChannel.Model.ManagedServicesAttestationPayload();
            System.DateTime? requestPayload_payload_ManagedServicesAttestationPayload_payload_ManagedServicesAttestationPayload_EndDate = null;
            if (cmdletContext.Payload_ManagedServicesAttestationPayload_EndDate != null)
            {
                requestPayload_payload_ManagedServicesAttestationPayload_payload_ManagedServicesAttestationPayload_EndDate = cmdletContext.Payload_ManagedServicesAttestationPayload_EndDate.Value;
            }
            if (requestPayload_payload_ManagedServicesAttestationPayload_payload_ManagedServicesAttestationPayload_EndDate != null)
            {
                requestPayload_payload_ManagedServicesAttestationPayload.EndDate = requestPayload_payload_ManagedServicesAttestationPayload_payload_ManagedServicesAttestationPayload_EndDate.Value;
                requestPayload_payload_ManagedServicesAttestationPayloadIsNull = false;
            }
            System.String requestPayload_payload_ManagedServicesAttestationPayload_payload_ManagedServicesAttestationPayload_LegalEntityName = null;
            if (cmdletContext.Payload_ManagedServicesAttestationPayload_LegalEntityName != null)
            {
                requestPayload_payload_ManagedServicesAttestationPayload_payload_ManagedServicesAttestationPayload_LegalEntityName = cmdletContext.Payload_ManagedServicesAttestationPayload_LegalEntityName;
            }
            if (requestPayload_payload_ManagedServicesAttestationPayload_payload_ManagedServicesAttestationPayload_LegalEntityName != null)
            {
                requestPayload_payload_ManagedServicesAttestationPayload.LegalEntityName = requestPayload_payload_ManagedServicesAttestationPayload_payload_ManagedServicesAttestationPayload_LegalEntityName;
                requestPayload_payload_ManagedServicesAttestationPayloadIsNull = false;
            }
            List<System.String> requestPayload_payload_ManagedServicesAttestationPayload_payload_ManagedServicesAttestationPayload_MemberAccountId = null;
            if (cmdletContext.Payload_ManagedServicesAttestationPayload_MemberAccountId != null)
            {
                requestPayload_payload_ManagedServicesAttestationPayload_payload_ManagedServicesAttestationPayload_MemberAccountId = cmdletContext.Payload_ManagedServicesAttestationPayload_MemberAccountId;
            }
            if (requestPayload_payload_ManagedServicesAttestationPayload_payload_ManagedServicesAttestationPayload_MemberAccountId != null)
            {
                requestPayload_payload_ManagedServicesAttestationPayload.MemberAccountIds = requestPayload_payload_ManagedServicesAttestationPayload_payload_ManagedServicesAttestationPayload_MemberAccountId;
                requestPayload_payload_ManagedServicesAttestationPayloadIsNull = false;
            }
            System.String requestPayload_payload_ManagedServicesAttestationPayload_payload_ManagedServicesAttestationPayload_ProgramManagementAccountIdentifier = null;
            if (cmdletContext.Payload_ManagedServicesAttestationPayload_ProgramManagementAccountIdentifier != null)
            {
                requestPayload_payload_ManagedServicesAttestationPayload_payload_ManagedServicesAttestationPayload_ProgramManagementAccountIdentifier = cmdletContext.Payload_ManagedServicesAttestationPayload_ProgramManagementAccountIdentifier;
            }
            if (requestPayload_payload_ManagedServicesAttestationPayload_payload_ManagedServicesAttestationPayload_ProgramManagementAccountIdentifier != null)
            {
                requestPayload_payload_ManagedServicesAttestationPayload.ProgramManagementAccountIdentifier = requestPayload_payload_ManagedServicesAttestationPayload_payload_ManagedServicesAttestationPayload_ProgramManagementAccountIdentifier;
                requestPayload_payload_ManagedServicesAttestationPayloadIsNull = false;
            }
            System.String requestPayload_payload_ManagedServicesAttestationPayload_payload_ManagedServicesAttestationPayload_RelationshipIdentifier = null;
            if (cmdletContext.Payload_ManagedServicesAttestationPayload_RelationshipIdentifier != null)
            {
                requestPayload_payload_ManagedServicesAttestationPayload_payload_ManagedServicesAttestationPayload_RelationshipIdentifier = cmdletContext.Payload_ManagedServicesAttestationPayload_RelationshipIdentifier;
            }
            if (requestPayload_payload_ManagedServicesAttestationPayload_payload_ManagedServicesAttestationPayload_RelationshipIdentifier != null)
            {
                requestPayload_payload_ManagedServicesAttestationPayload.RelationshipIdentifier = requestPayload_payload_ManagedServicesAttestationPayload_payload_ManagedServicesAttestationPayload_RelationshipIdentifier;
                requestPayload_payload_ManagedServicesAttestationPayloadIsNull = false;
            }
            System.String requestPayload_payload_ManagedServicesAttestationPayload_payload_ManagedServicesAttestationPayload_SignatoryEmail = null;
            if (cmdletContext.Payload_ManagedServicesAttestationPayload_SignatoryEmail != null)
            {
                requestPayload_payload_ManagedServicesAttestationPayload_payload_ManagedServicesAttestationPayload_SignatoryEmail = cmdletContext.Payload_ManagedServicesAttestationPayload_SignatoryEmail;
            }
            if (requestPayload_payload_ManagedServicesAttestationPayload_payload_ManagedServicesAttestationPayload_SignatoryEmail != null)
            {
                requestPayload_payload_ManagedServicesAttestationPayload.SignatoryEmail = requestPayload_payload_ManagedServicesAttestationPayload_payload_ManagedServicesAttestationPayload_SignatoryEmail;
                requestPayload_payload_ManagedServicesAttestationPayloadIsNull = false;
            }
            System.String requestPayload_payload_ManagedServicesAttestationPayload_payload_ManagedServicesAttestationPayload_SignatoryName = null;
            if (cmdletContext.Payload_ManagedServicesAttestationPayload_SignatoryName != null)
            {
                requestPayload_payload_ManagedServicesAttestationPayload_payload_ManagedServicesAttestationPayload_SignatoryName = cmdletContext.Payload_ManagedServicesAttestationPayload_SignatoryName;
            }
            if (requestPayload_payload_ManagedServicesAttestationPayload_payload_ManagedServicesAttestationPayload_SignatoryName != null)
            {
                requestPayload_payload_ManagedServicesAttestationPayload.SignatoryName = requestPayload_payload_ManagedServicesAttestationPayload_payload_ManagedServicesAttestationPayload_SignatoryName;
                requestPayload_payload_ManagedServicesAttestationPayloadIsNull = false;
            }
            List<System.String> requestPayload_payload_ManagedServicesAttestationPayload_payload_ManagedServicesAttestationPayload_SupportedService = null;
            if (cmdletContext.Payload_ManagedServicesAttestationPayload_SupportedService != null)
            {
                requestPayload_payload_ManagedServicesAttestationPayload_payload_ManagedServicesAttestationPayload_SupportedService = cmdletContext.Payload_ManagedServicesAttestationPayload_SupportedService;
            }
            if (requestPayload_payload_ManagedServicesAttestationPayload_payload_ManagedServicesAttestationPayload_SupportedService != null)
            {
                requestPayload_payload_ManagedServicesAttestationPayload.SupportedServices = requestPayload_payload_ManagedServicesAttestationPayload_payload_ManagedServicesAttestationPayload_SupportedService;
                requestPayload_payload_ManagedServicesAttestationPayloadIsNull = false;
            }
            Amazon.PartnerCentralChannel.Model.Address requestPayload_payload_ManagedServicesAttestationPayload_payload_ManagedServicesAttestationPayload_LegalEntityAddress = null;
            
             // populate LegalEntityAddress
            var requestPayload_payload_ManagedServicesAttestationPayload_payload_ManagedServicesAttestationPayload_LegalEntityAddressIsNull = true;
            requestPayload_payload_ManagedServicesAttestationPayload_payload_ManagedServicesAttestationPayload_LegalEntityAddress = new Amazon.PartnerCentralChannel.Model.Address();
            System.String requestPayload_payload_ManagedServicesAttestationPayload_payload_ManagedServicesAttestationPayload_LegalEntityAddress_payload_ManagedServicesAttestationPayload_LegalEntityAddress_AddressLine = null;
            if (cmdletContext.Payload_ManagedServicesAttestationPayload_LegalEntityAddress_AddressLine != null)
            {
                requestPayload_payload_ManagedServicesAttestationPayload_payload_ManagedServicesAttestationPayload_LegalEntityAddress_payload_ManagedServicesAttestationPayload_LegalEntityAddress_AddressLine = cmdletContext.Payload_ManagedServicesAttestationPayload_LegalEntityAddress_AddressLine;
            }
            if (requestPayload_payload_ManagedServicesAttestationPayload_payload_ManagedServicesAttestationPayload_LegalEntityAddress_payload_ManagedServicesAttestationPayload_LegalEntityAddress_AddressLine != null)
            {
                requestPayload_payload_ManagedServicesAttestationPayload_payload_ManagedServicesAttestationPayload_LegalEntityAddress.AddressLine = requestPayload_payload_ManagedServicesAttestationPayload_payload_ManagedServicesAttestationPayload_LegalEntityAddress_payload_ManagedServicesAttestationPayload_LegalEntityAddress_AddressLine;
                requestPayload_payload_ManagedServicesAttestationPayload_payload_ManagedServicesAttestationPayload_LegalEntityAddressIsNull = false;
            }
            System.String requestPayload_payload_ManagedServicesAttestationPayload_payload_ManagedServicesAttestationPayload_LegalEntityAddress_payload_ManagedServicesAttestationPayload_LegalEntityAddress_AddressLine2 = null;
            if (cmdletContext.Payload_ManagedServicesAttestationPayload_LegalEntityAddress_AddressLine2 != null)
            {
                requestPayload_payload_ManagedServicesAttestationPayload_payload_ManagedServicesAttestationPayload_LegalEntityAddress_payload_ManagedServicesAttestationPayload_LegalEntityAddress_AddressLine2 = cmdletContext.Payload_ManagedServicesAttestationPayload_LegalEntityAddress_AddressLine2;
            }
            if (requestPayload_payload_ManagedServicesAttestationPayload_payload_ManagedServicesAttestationPayload_LegalEntityAddress_payload_ManagedServicesAttestationPayload_LegalEntityAddress_AddressLine2 != null)
            {
                requestPayload_payload_ManagedServicesAttestationPayload_payload_ManagedServicesAttestationPayload_LegalEntityAddress.AddressLine2 = requestPayload_payload_ManagedServicesAttestationPayload_payload_ManagedServicesAttestationPayload_LegalEntityAddress_payload_ManagedServicesAttestationPayload_LegalEntityAddress_AddressLine2;
                requestPayload_payload_ManagedServicesAttestationPayload_payload_ManagedServicesAttestationPayload_LegalEntityAddressIsNull = false;
            }
            System.String requestPayload_payload_ManagedServicesAttestationPayload_payload_ManagedServicesAttestationPayload_LegalEntityAddress_payload_ManagedServicesAttestationPayload_LegalEntityAddress_City = null;
            if (cmdletContext.Payload_ManagedServicesAttestationPayload_LegalEntityAddress_City != null)
            {
                requestPayload_payload_ManagedServicesAttestationPayload_payload_ManagedServicesAttestationPayload_LegalEntityAddress_payload_ManagedServicesAttestationPayload_LegalEntityAddress_City = cmdletContext.Payload_ManagedServicesAttestationPayload_LegalEntityAddress_City;
            }
            if (requestPayload_payload_ManagedServicesAttestationPayload_payload_ManagedServicesAttestationPayload_LegalEntityAddress_payload_ManagedServicesAttestationPayload_LegalEntityAddress_City != null)
            {
                requestPayload_payload_ManagedServicesAttestationPayload_payload_ManagedServicesAttestationPayload_LegalEntityAddress.City = requestPayload_payload_ManagedServicesAttestationPayload_payload_ManagedServicesAttestationPayload_LegalEntityAddress_payload_ManagedServicesAttestationPayload_LegalEntityAddress_City;
                requestPayload_payload_ManagedServicesAttestationPayload_payload_ManagedServicesAttestationPayload_LegalEntityAddressIsNull = false;
            }
            System.String requestPayload_payload_ManagedServicesAttestationPayload_payload_ManagedServicesAttestationPayload_LegalEntityAddress_payload_ManagedServicesAttestationPayload_LegalEntityAddress_CountryCode = null;
            if (cmdletContext.Payload_ManagedServicesAttestationPayload_LegalEntityAddress_CountryCode != null)
            {
                requestPayload_payload_ManagedServicesAttestationPayload_payload_ManagedServicesAttestationPayload_LegalEntityAddress_payload_ManagedServicesAttestationPayload_LegalEntityAddress_CountryCode = cmdletContext.Payload_ManagedServicesAttestationPayload_LegalEntityAddress_CountryCode;
            }
            if (requestPayload_payload_ManagedServicesAttestationPayload_payload_ManagedServicesAttestationPayload_LegalEntityAddress_payload_ManagedServicesAttestationPayload_LegalEntityAddress_CountryCode != null)
            {
                requestPayload_payload_ManagedServicesAttestationPayload_payload_ManagedServicesAttestationPayload_LegalEntityAddress.CountryCode = requestPayload_payload_ManagedServicesAttestationPayload_payload_ManagedServicesAttestationPayload_LegalEntityAddress_payload_ManagedServicesAttestationPayload_LegalEntityAddress_CountryCode;
                requestPayload_payload_ManagedServicesAttestationPayload_payload_ManagedServicesAttestationPayload_LegalEntityAddressIsNull = false;
            }
            System.String requestPayload_payload_ManagedServicesAttestationPayload_payload_ManagedServicesAttestationPayload_LegalEntityAddress_payload_ManagedServicesAttestationPayload_LegalEntityAddress_PostalCode = null;
            if (cmdletContext.Payload_ManagedServicesAttestationPayload_LegalEntityAddress_PostalCode != null)
            {
                requestPayload_payload_ManagedServicesAttestationPayload_payload_ManagedServicesAttestationPayload_LegalEntityAddress_payload_ManagedServicesAttestationPayload_LegalEntityAddress_PostalCode = cmdletContext.Payload_ManagedServicesAttestationPayload_LegalEntityAddress_PostalCode;
            }
            if (requestPayload_payload_ManagedServicesAttestationPayload_payload_ManagedServicesAttestationPayload_LegalEntityAddress_payload_ManagedServicesAttestationPayload_LegalEntityAddress_PostalCode != null)
            {
                requestPayload_payload_ManagedServicesAttestationPayload_payload_ManagedServicesAttestationPayload_LegalEntityAddress.PostalCode = requestPayload_payload_ManagedServicesAttestationPayload_payload_ManagedServicesAttestationPayload_LegalEntityAddress_payload_ManagedServicesAttestationPayload_LegalEntityAddress_PostalCode;
                requestPayload_payload_ManagedServicesAttestationPayload_payload_ManagedServicesAttestationPayload_LegalEntityAddressIsNull = false;
            }
            System.String requestPayload_payload_ManagedServicesAttestationPayload_payload_ManagedServicesAttestationPayload_LegalEntityAddress_payload_ManagedServicesAttestationPayload_LegalEntityAddress_StateOrRegion = null;
            if (cmdletContext.Payload_ManagedServicesAttestationPayload_LegalEntityAddress_StateOrRegion != null)
            {
                requestPayload_payload_ManagedServicesAttestationPayload_payload_ManagedServicesAttestationPayload_LegalEntityAddress_payload_ManagedServicesAttestationPayload_LegalEntityAddress_StateOrRegion = cmdletContext.Payload_ManagedServicesAttestationPayload_LegalEntityAddress_StateOrRegion;
            }
            if (requestPayload_payload_ManagedServicesAttestationPayload_payload_ManagedServicesAttestationPayload_LegalEntityAddress_payload_ManagedServicesAttestationPayload_LegalEntityAddress_StateOrRegion != null)
            {
                requestPayload_payload_ManagedServicesAttestationPayload_payload_ManagedServicesAttestationPayload_LegalEntityAddress.StateOrRegion = requestPayload_payload_ManagedServicesAttestationPayload_payload_ManagedServicesAttestationPayload_LegalEntityAddress_payload_ManagedServicesAttestationPayload_LegalEntityAddress_StateOrRegion;
                requestPayload_payload_ManagedServicesAttestationPayload_payload_ManagedServicesAttestationPayload_LegalEntityAddressIsNull = false;
            }
             // determine if requestPayload_payload_ManagedServicesAttestationPayload_payload_ManagedServicesAttestationPayload_LegalEntityAddress should be set to null
            if (requestPayload_payload_ManagedServicesAttestationPayload_payload_ManagedServicesAttestationPayload_LegalEntityAddressIsNull)
            {
                requestPayload_payload_ManagedServicesAttestationPayload_payload_ManagedServicesAttestationPayload_LegalEntityAddress = null;
            }
            if (requestPayload_payload_ManagedServicesAttestationPayload_payload_ManagedServicesAttestationPayload_LegalEntityAddress != null)
            {
                requestPayload_payload_ManagedServicesAttestationPayload.LegalEntityAddress = requestPayload_payload_ManagedServicesAttestationPayload_payload_ManagedServicesAttestationPayload_LegalEntityAddress;
                requestPayload_payload_ManagedServicesAttestationPayloadIsNull = false;
            }
             // determine if requestPayload_payload_ManagedServicesAttestationPayload should be set to null
            if (requestPayload_payload_ManagedServicesAttestationPayloadIsNull)
            {
                requestPayload_payload_ManagedServicesAttestationPayload = null;
            }
            if (requestPayload_payload_ManagedServicesAttestationPayload != null)
            {
                request.Payload.ManagedServicesAttestationPayload = requestPayload_payload_ManagedServicesAttestationPayload;
                requestPayloadIsNull = false;
            }
             // determine if request.Payload should be set to null
            if (requestPayloadIsNull)
            {
                request.Payload = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.PartnerCentralChannel.Model.CreateChannelContractResponse CallAWSServiceOperation(IAmazonPartnerCentralChannel client, Amazon.PartnerCentralChannel.Model.CreateChannelContractRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Partner Central Channel API", "CreateChannelContract");
            try
            {
                return client.CreateChannelContractAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Catalog { get; set; }
            public System.String ClientToken { get; set; }
            public Amazon.PartnerCentralChannel.ChannelContractType ContractType { get; set; }
            public System.DateTime? Payload_ManagedServicesAttestationPayload_EndDate { get; set; }
            public System.String Payload_ManagedServicesAttestationPayload_LegalEntityAddress_AddressLine { get; set; }
            public System.String Payload_ManagedServicesAttestationPayload_LegalEntityAddress_AddressLine2 { get; set; }
            public System.String Payload_ManagedServicesAttestationPayload_LegalEntityAddress_City { get; set; }
            public System.String Payload_ManagedServicesAttestationPayload_LegalEntityAddress_CountryCode { get; set; }
            public System.String Payload_ManagedServicesAttestationPayload_LegalEntityAddress_PostalCode { get; set; }
            public System.String Payload_ManagedServicesAttestationPayload_LegalEntityAddress_StateOrRegion { get; set; }
            public System.String Payload_ManagedServicesAttestationPayload_LegalEntityName { get; set; }
            public List<System.String> Payload_ManagedServicesAttestationPayload_MemberAccountId { get; set; }
            public System.String Payload_ManagedServicesAttestationPayload_ProgramManagementAccountIdentifier { get; set; }
            public System.String Payload_ManagedServicesAttestationPayload_RelationshipIdentifier { get; set; }
            public System.String Payload_ManagedServicesAttestationPayload_SignatoryEmail { get; set; }
            public System.String Payload_ManagedServicesAttestationPayload_SignatoryName { get; set; }
            public List<System.String> Payload_ManagedServicesAttestationPayload_SupportedService { get; set; }
            public List<Amazon.PartnerCentralChannel.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.PartnerCentralChannel.Model.CreateChannelContractResponse, NewPCCChannelContractCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ChannelContractDetail;
        }
        
    }
}
