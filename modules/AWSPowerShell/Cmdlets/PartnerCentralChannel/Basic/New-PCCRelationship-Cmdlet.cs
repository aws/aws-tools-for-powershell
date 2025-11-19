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
    /// Creates a new partner relationship between accounts.
    /// </summary>
    [Cmdlet("New", "PCCRelationship", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.PartnerCentralChannel.Model.CreateRelationshipDetail")]
    [AWSCmdlet("Calls the Partner Central Channel API CreateRelationship API operation.", Operation = new[] {"CreateRelationship"}, SelectReturnType = typeof(Amazon.PartnerCentralChannel.Model.CreateRelationshipResponse))]
    [AWSCmdletOutput("Amazon.PartnerCentralChannel.Model.CreateRelationshipDetail or Amazon.PartnerCentralChannel.Model.CreateRelationshipResponse",
        "This cmdlet returns an Amazon.PartnerCentralChannel.Model.CreateRelationshipDetail object.",
        "The service call response (type Amazon.PartnerCentralChannel.Model.CreateRelationshipResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewPCCRelationshipCmdlet : AmazonPartnerCentralChannelClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AssociatedAccountId
        /// <summary>
        /// <para>
        /// <para>The AWS account ID to associate in this relationship.</para>
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
        public System.String AssociatedAccountId { get; set; }
        #endregion
        
        #region Parameter AssociationType
        /// <summary>
        /// <para>
        /// <para>The type of association for the relationship (e.g., reseller, distributor).</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.PartnerCentralChannel.AssociationType")]
        public Amazon.PartnerCentralChannel.AssociationType AssociationType { get; set; }
        #endregion
        
        #region Parameter Catalog
        /// <summary>
        /// <para>
        /// <para>The catalog identifier for the relationship.</para>
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
        
        #region Parameter ResoldEnterprise_ChargeAccountId
        /// <summary>
        /// <para>
        /// <para>The AWS account ID to charge for the support plan.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RequestedSupportPlan_ResoldEnterprise_ChargeAccountId")]
        public System.String ResoldEnterprise_ChargeAccountId { get; set; }
        #endregion
        
        #region Parameter PartnerLedSupport_Coverage
        /// <summary>
        /// <para>
        /// <para>The coverage level for partner-led support.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RequestedSupportPlan_PartnerLedSupport_Coverage")]
        [AWSConstantClassSource("Amazon.PartnerCentralChannel.Coverage")]
        public Amazon.PartnerCentralChannel.Coverage PartnerLedSupport_Coverage { get; set; }
        #endregion
        
        #region Parameter ResoldBusiness_Coverage
        /// <summary>
        /// <para>
        /// <para>The coverage level for resold business support.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RequestedSupportPlan_ResoldBusiness_Coverage")]
        [AWSConstantClassSource("Amazon.PartnerCentralChannel.Coverage")]
        public Amazon.PartnerCentralChannel.Coverage ResoldBusiness_Coverage { get; set; }
        #endregion
        
        #region Parameter ResoldEnterprise_Coverage
        /// <summary>
        /// <para>
        /// <para>The coverage level for resold enterprise support.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RequestedSupportPlan_ResoldEnterprise_Coverage")]
        [AWSConstantClassSource("Amazon.PartnerCentralChannel.Coverage")]
        public Amazon.PartnerCentralChannel.Coverage ResoldEnterprise_Coverage { get; set; }
        #endregion
        
        #region Parameter DisplayName
        /// <summary>
        /// <para>
        /// <para>A human-readable name for the relationship.</para>
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
        public System.String DisplayName { get; set; }
        #endregion
        
        #region Parameter ProgramManagementAccountIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the program management account for this relationship.</para>
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
        public System.String ProgramManagementAccountIdentifier { get; set; }
        #endregion
        
        #region Parameter PartnerLedSupport_Provider
        /// <summary>
        /// <para>
        /// <para>The provider of the partner-led support.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RequestedSupportPlan_PartnerLedSupport_Provider")]
        [AWSConstantClassSource("Amazon.PartnerCentralChannel.Provider")]
        public Amazon.PartnerCentralChannel.Provider PartnerLedSupport_Provider { get; set; }
        #endregion
        
        #region Parameter ResaleAccountModel
        /// <summary>
        /// <para>
        /// <para>The resale account model for the relationship.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.PartnerCentralChannel.ResaleAccountModel")]
        public Amazon.PartnerCentralChannel.ResaleAccountModel ResaleAccountModel { get; set; }
        #endregion
        
        #region Parameter Sector
        /// <summary>
        /// <para>
        /// <para>The business sector for the relationship.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.PartnerCentralChannel.Sector")]
        public Amazon.PartnerCentralChannel.Sector Sector { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Key-value pairs to associate with the relationship.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.PartnerCentralChannel.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter PartnerLedSupport_TamLocation
        /// <summary>
        /// <para>
        /// <para>The location of the Technical Account Manager (TAM).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RequestedSupportPlan_PartnerLedSupport_TamLocation")]
        public System.String PartnerLedSupport_TamLocation { get; set; }
        #endregion
        
        #region Parameter ResoldEnterprise_TamLocation
        /// <summary>
        /// <para>
        /// <para>The location of the Technical Account Manager (TAM).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RequestedSupportPlan_ResoldEnterprise_TamLocation")]
        public System.String ResoldEnterprise_TamLocation { get; set; }
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RelationshipDetail'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PartnerCentralChannel.Model.CreateRelationshipResponse).
        /// Specifying the name of a property of type Amazon.PartnerCentralChannel.Model.CreateRelationshipResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RelationshipDetail";
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
                nameof(this.AssociatedAccountId),
                nameof(this.DisplayName),
                nameof(this.ProgramManagementAccountIdentifier)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-PCCRelationship (CreateRelationship)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PartnerCentralChannel.Model.CreateRelationshipResponse, NewPCCRelationshipCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AssociatedAccountId = this.AssociatedAccountId;
            #if MODULAR
            if (this.AssociatedAccountId == null && ParameterWasBound(nameof(this.AssociatedAccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AssociatedAccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AssociationType = this.AssociationType;
            #if MODULAR
            if (this.AssociationType == null && ParameterWasBound(nameof(this.AssociationType)))
            {
                WriteWarning("You are passing $null as a value for parameter AssociationType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Catalog = this.Catalog;
            #if MODULAR
            if (this.Catalog == null && ParameterWasBound(nameof(this.Catalog)))
            {
                WriteWarning("You are passing $null as a value for parameter Catalog which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.DisplayName = this.DisplayName;
            #if MODULAR
            if (this.DisplayName == null && ParameterWasBound(nameof(this.DisplayName)))
            {
                WriteWarning("You are passing $null as a value for parameter DisplayName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ProgramManagementAccountIdentifier = this.ProgramManagementAccountIdentifier;
            #if MODULAR
            if (this.ProgramManagementAccountIdentifier == null && ParameterWasBound(nameof(this.ProgramManagementAccountIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ProgramManagementAccountIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PartnerLedSupport_Coverage = this.PartnerLedSupport_Coverage;
            context.PartnerLedSupport_Provider = this.PartnerLedSupport_Provider;
            context.PartnerLedSupport_TamLocation = this.PartnerLedSupport_TamLocation;
            context.ResoldBusiness_Coverage = this.ResoldBusiness_Coverage;
            context.ResoldEnterprise_ChargeAccountId = this.ResoldEnterprise_ChargeAccountId;
            context.ResoldEnterprise_Coverage = this.ResoldEnterprise_Coverage;
            context.ResoldEnterprise_TamLocation = this.ResoldEnterprise_TamLocation;
            context.ResaleAccountModel = this.ResaleAccountModel;
            context.Sector = this.Sector;
            #if MODULAR
            if (this.Sector == null && ParameterWasBound(nameof(this.Sector)))
            {
                WriteWarning("You are passing $null as a value for parameter Sector which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.PartnerCentralChannel.Model.CreateRelationshipRequest();
            
            if (cmdletContext.AssociatedAccountId != null)
            {
                request.AssociatedAccountId = cmdletContext.AssociatedAccountId;
            }
            if (cmdletContext.AssociationType != null)
            {
                request.AssociationType = cmdletContext.AssociationType;
            }
            if (cmdletContext.Catalog != null)
            {
                request.Catalog = cmdletContext.Catalog;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DisplayName != null)
            {
                request.DisplayName = cmdletContext.DisplayName;
            }
            if (cmdletContext.ProgramManagementAccountIdentifier != null)
            {
                request.ProgramManagementAccountIdentifier = cmdletContext.ProgramManagementAccountIdentifier;
            }
            
             // populate RequestedSupportPlan
            var requestRequestedSupportPlanIsNull = true;
            request.RequestedSupportPlan = new Amazon.PartnerCentralChannel.Model.SupportPlan();
            Amazon.PartnerCentralChannel.Model.ResoldBusiness requestRequestedSupportPlan_requestedSupportPlan_ResoldBusiness = null;
            
             // populate ResoldBusiness
            var requestRequestedSupportPlan_requestedSupportPlan_ResoldBusinessIsNull = true;
            requestRequestedSupportPlan_requestedSupportPlan_ResoldBusiness = new Amazon.PartnerCentralChannel.Model.ResoldBusiness();
            Amazon.PartnerCentralChannel.Coverage requestRequestedSupportPlan_requestedSupportPlan_ResoldBusiness_resoldBusiness_Coverage = null;
            if (cmdletContext.ResoldBusiness_Coverage != null)
            {
                requestRequestedSupportPlan_requestedSupportPlan_ResoldBusiness_resoldBusiness_Coverage = cmdletContext.ResoldBusiness_Coverage;
            }
            if (requestRequestedSupportPlan_requestedSupportPlan_ResoldBusiness_resoldBusiness_Coverage != null)
            {
                requestRequestedSupportPlan_requestedSupportPlan_ResoldBusiness.Coverage = requestRequestedSupportPlan_requestedSupportPlan_ResoldBusiness_resoldBusiness_Coverage;
                requestRequestedSupportPlan_requestedSupportPlan_ResoldBusinessIsNull = false;
            }
             // determine if requestRequestedSupportPlan_requestedSupportPlan_ResoldBusiness should be set to null
            if (requestRequestedSupportPlan_requestedSupportPlan_ResoldBusinessIsNull)
            {
                requestRequestedSupportPlan_requestedSupportPlan_ResoldBusiness = null;
            }
            if (requestRequestedSupportPlan_requestedSupportPlan_ResoldBusiness != null)
            {
                request.RequestedSupportPlan.ResoldBusiness = requestRequestedSupportPlan_requestedSupportPlan_ResoldBusiness;
                requestRequestedSupportPlanIsNull = false;
            }
            Amazon.PartnerCentralChannel.Model.PartnerLedSupport requestRequestedSupportPlan_requestedSupportPlan_PartnerLedSupport = null;
            
             // populate PartnerLedSupport
            var requestRequestedSupportPlan_requestedSupportPlan_PartnerLedSupportIsNull = true;
            requestRequestedSupportPlan_requestedSupportPlan_PartnerLedSupport = new Amazon.PartnerCentralChannel.Model.PartnerLedSupport();
            Amazon.PartnerCentralChannel.Coverage requestRequestedSupportPlan_requestedSupportPlan_PartnerLedSupport_partnerLedSupport_Coverage = null;
            if (cmdletContext.PartnerLedSupport_Coverage != null)
            {
                requestRequestedSupportPlan_requestedSupportPlan_PartnerLedSupport_partnerLedSupport_Coverage = cmdletContext.PartnerLedSupport_Coverage;
            }
            if (requestRequestedSupportPlan_requestedSupportPlan_PartnerLedSupport_partnerLedSupport_Coverage != null)
            {
                requestRequestedSupportPlan_requestedSupportPlan_PartnerLedSupport.Coverage = requestRequestedSupportPlan_requestedSupportPlan_PartnerLedSupport_partnerLedSupport_Coverage;
                requestRequestedSupportPlan_requestedSupportPlan_PartnerLedSupportIsNull = false;
            }
            Amazon.PartnerCentralChannel.Provider requestRequestedSupportPlan_requestedSupportPlan_PartnerLedSupport_partnerLedSupport_Provider = null;
            if (cmdletContext.PartnerLedSupport_Provider != null)
            {
                requestRequestedSupportPlan_requestedSupportPlan_PartnerLedSupport_partnerLedSupport_Provider = cmdletContext.PartnerLedSupport_Provider;
            }
            if (requestRequestedSupportPlan_requestedSupportPlan_PartnerLedSupport_partnerLedSupport_Provider != null)
            {
                requestRequestedSupportPlan_requestedSupportPlan_PartnerLedSupport.Provider = requestRequestedSupportPlan_requestedSupportPlan_PartnerLedSupport_partnerLedSupport_Provider;
                requestRequestedSupportPlan_requestedSupportPlan_PartnerLedSupportIsNull = false;
            }
            System.String requestRequestedSupportPlan_requestedSupportPlan_PartnerLedSupport_partnerLedSupport_TamLocation = null;
            if (cmdletContext.PartnerLedSupport_TamLocation != null)
            {
                requestRequestedSupportPlan_requestedSupportPlan_PartnerLedSupport_partnerLedSupport_TamLocation = cmdletContext.PartnerLedSupport_TamLocation;
            }
            if (requestRequestedSupportPlan_requestedSupportPlan_PartnerLedSupport_partnerLedSupport_TamLocation != null)
            {
                requestRequestedSupportPlan_requestedSupportPlan_PartnerLedSupport.TamLocation = requestRequestedSupportPlan_requestedSupportPlan_PartnerLedSupport_partnerLedSupport_TamLocation;
                requestRequestedSupportPlan_requestedSupportPlan_PartnerLedSupportIsNull = false;
            }
             // determine if requestRequestedSupportPlan_requestedSupportPlan_PartnerLedSupport should be set to null
            if (requestRequestedSupportPlan_requestedSupportPlan_PartnerLedSupportIsNull)
            {
                requestRequestedSupportPlan_requestedSupportPlan_PartnerLedSupport = null;
            }
            if (requestRequestedSupportPlan_requestedSupportPlan_PartnerLedSupport != null)
            {
                request.RequestedSupportPlan.PartnerLedSupport = requestRequestedSupportPlan_requestedSupportPlan_PartnerLedSupport;
                requestRequestedSupportPlanIsNull = false;
            }
            Amazon.PartnerCentralChannel.Model.ResoldEnterprise requestRequestedSupportPlan_requestedSupportPlan_ResoldEnterprise = null;
            
             // populate ResoldEnterprise
            var requestRequestedSupportPlan_requestedSupportPlan_ResoldEnterpriseIsNull = true;
            requestRequestedSupportPlan_requestedSupportPlan_ResoldEnterprise = new Amazon.PartnerCentralChannel.Model.ResoldEnterprise();
            System.String requestRequestedSupportPlan_requestedSupportPlan_ResoldEnterprise_resoldEnterprise_ChargeAccountId = null;
            if (cmdletContext.ResoldEnterprise_ChargeAccountId != null)
            {
                requestRequestedSupportPlan_requestedSupportPlan_ResoldEnterprise_resoldEnterprise_ChargeAccountId = cmdletContext.ResoldEnterprise_ChargeAccountId;
            }
            if (requestRequestedSupportPlan_requestedSupportPlan_ResoldEnterprise_resoldEnterprise_ChargeAccountId != null)
            {
                requestRequestedSupportPlan_requestedSupportPlan_ResoldEnterprise.ChargeAccountId = requestRequestedSupportPlan_requestedSupportPlan_ResoldEnterprise_resoldEnterprise_ChargeAccountId;
                requestRequestedSupportPlan_requestedSupportPlan_ResoldEnterpriseIsNull = false;
            }
            Amazon.PartnerCentralChannel.Coverage requestRequestedSupportPlan_requestedSupportPlan_ResoldEnterprise_resoldEnterprise_Coverage = null;
            if (cmdletContext.ResoldEnterprise_Coverage != null)
            {
                requestRequestedSupportPlan_requestedSupportPlan_ResoldEnterprise_resoldEnterprise_Coverage = cmdletContext.ResoldEnterprise_Coverage;
            }
            if (requestRequestedSupportPlan_requestedSupportPlan_ResoldEnterprise_resoldEnterprise_Coverage != null)
            {
                requestRequestedSupportPlan_requestedSupportPlan_ResoldEnterprise.Coverage = requestRequestedSupportPlan_requestedSupportPlan_ResoldEnterprise_resoldEnterprise_Coverage;
                requestRequestedSupportPlan_requestedSupportPlan_ResoldEnterpriseIsNull = false;
            }
            System.String requestRequestedSupportPlan_requestedSupportPlan_ResoldEnterprise_resoldEnterprise_TamLocation = null;
            if (cmdletContext.ResoldEnterprise_TamLocation != null)
            {
                requestRequestedSupportPlan_requestedSupportPlan_ResoldEnterprise_resoldEnterprise_TamLocation = cmdletContext.ResoldEnterprise_TamLocation;
            }
            if (requestRequestedSupportPlan_requestedSupportPlan_ResoldEnterprise_resoldEnterprise_TamLocation != null)
            {
                requestRequestedSupportPlan_requestedSupportPlan_ResoldEnterprise.TamLocation = requestRequestedSupportPlan_requestedSupportPlan_ResoldEnterprise_resoldEnterprise_TamLocation;
                requestRequestedSupportPlan_requestedSupportPlan_ResoldEnterpriseIsNull = false;
            }
             // determine if requestRequestedSupportPlan_requestedSupportPlan_ResoldEnterprise should be set to null
            if (requestRequestedSupportPlan_requestedSupportPlan_ResoldEnterpriseIsNull)
            {
                requestRequestedSupportPlan_requestedSupportPlan_ResoldEnterprise = null;
            }
            if (requestRequestedSupportPlan_requestedSupportPlan_ResoldEnterprise != null)
            {
                request.RequestedSupportPlan.ResoldEnterprise = requestRequestedSupportPlan_requestedSupportPlan_ResoldEnterprise;
                requestRequestedSupportPlanIsNull = false;
            }
             // determine if request.RequestedSupportPlan should be set to null
            if (requestRequestedSupportPlanIsNull)
            {
                request.RequestedSupportPlan = null;
            }
            if (cmdletContext.ResaleAccountModel != null)
            {
                request.ResaleAccountModel = cmdletContext.ResaleAccountModel;
            }
            if (cmdletContext.Sector != null)
            {
                request.Sector = cmdletContext.Sector;
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
        
        private Amazon.PartnerCentralChannel.Model.CreateRelationshipResponse CallAWSServiceOperation(IAmazonPartnerCentralChannel client, Amazon.PartnerCentralChannel.Model.CreateRelationshipRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Partner Central Channel API", "CreateRelationship");
            try
            {
                return client.CreateRelationshipAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AssociatedAccountId { get; set; }
            public Amazon.PartnerCentralChannel.AssociationType AssociationType { get; set; }
            public System.String Catalog { get; set; }
            public System.String ClientToken { get; set; }
            public System.String DisplayName { get; set; }
            public System.String ProgramManagementAccountIdentifier { get; set; }
            public Amazon.PartnerCentralChannel.Coverage PartnerLedSupport_Coverage { get; set; }
            public Amazon.PartnerCentralChannel.Provider PartnerLedSupport_Provider { get; set; }
            public System.String PartnerLedSupport_TamLocation { get; set; }
            public Amazon.PartnerCentralChannel.Coverage ResoldBusiness_Coverage { get; set; }
            public System.String ResoldEnterprise_ChargeAccountId { get; set; }
            public Amazon.PartnerCentralChannel.Coverage ResoldEnterprise_Coverage { get; set; }
            public System.String ResoldEnterprise_TamLocation { get; set; }
            public Amazon.PartnerCentralChannel.ResaleAccountModel ResaleAccountModel { get; set; }
            public Amazon.PartnerCentralChannel.Sector Sector { get; set; }
            public List<Amazon.PartnerCentralChannel.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.PartnerCentralChannel.Model.CreateRelationshipResponse, NewPCCRelationshipCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RelationshipDetail;
        }
        
    }
}
