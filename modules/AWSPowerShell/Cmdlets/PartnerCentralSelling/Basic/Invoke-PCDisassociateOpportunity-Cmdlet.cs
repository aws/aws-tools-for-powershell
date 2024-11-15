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
using Amazon.PartnerCentralSelling;
using Amazon.PartnerCentralSelling.Model;

namespace Amazon.PowerShell.Cmdlets.PC
{
    /// <summary>
    /// Allows you to remove an existing association between an <c>Opportunity</c> and related
    /// entities, such as a Partner Solution, Amazon Web Services product, or an Amazon Web
    /// Services Marketplace offer. This operation is the counterpart to <c>AssociateOpportunity</c>,
    /// and it provides flexibility to manage associations as business needs change. 
    /// 
    ///  
    /// <para>
    ///  Use this operation to update the associations of an <c>Opportunity</c> due to changes
    /// in the related entities, or if an association was made in error. Ensuring accurate
    /// associations helps maintain clarity and accuracy to track and manage business opportunities.
    /// When you replace an entity, first attach the new entity and then disassociate the
    /// one to be removed, especially if it's the last remaining entity that's required. 
    /// </para>
    /// </summary>
    [Cmdlet("Invoke", "PCDisassociateOpportunity", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Partner Central Selling API DisassociateOpportunity API operation.", Operation = new[] {"DisassociateOpportunity"}, SelectReturnType = typeof(Amazon.PartnerCentralSelling.Model.DisassociateOpportunityResponse))]
    [AWSCmdletOutput("None or Amazon.PartnerCentralSelling.Model.DisassociateOpportunityResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.PartnerCentralSelling.Model.DisassociateOpportunityResponse) be returned by specifying '-Select *'."
    )]
    public partial class InvokePCDisassociateOpportunityCmdlet : AmazonPartnerCentralSellingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Catalog
        /// <summary>
        /// <para>
        /// <para> Specifies the catalog associated with the request. This field takes a string value
        /// from a predefined list: <c>AWS</c> or <c>Sandbox</c>. The catalog determines which
        /// environment the opportunity disassociation is made in. Use <c>AWS</c> to disassociate
        /// opportunities in the Amazon Web Services catalog, and <c>Sandbox</c> for testing in
        /// secure, isolated environments. </para>
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
        
        #region Parameter OpportunityIdentifier
        /// <summary>
        /// <para>
        /// <para>The opportunity's unique identifier for when you want to disassociate it from related
        /// entities. This identifier helps to ensure that the correct opportunity is updated.
        /// </para><para>Validation: Ensure that the provided identifier corresponds to an existing opportunity
        /// in the Amazon Web Services system because incorrect identifiers result in an error
        /// and no changes are made. </para>
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
        public System.String OpportunityIdentifier { get; set; }
        #endregion
        
        #region Parameter RelatedEntityIdentifier
        /// <summary>
        /// <para>
        /// <para>The related entity's identifier that you want to disassociate from the opportunity.
        /// Depending on the type of entity, this could be a simple identifier or an Amazon Resource
        /// Name (ARN) for entities managed through Amazon Web Services Marketplace. </para><para>For Amazon Web Services Marketplace entities, use the Amazon Web Services Marketplace
        /// API to obtain the necessary ARNs. For guidance on retrieving these ARNs, see <a href="https://docs.aws.amazon.com/marketplace-catalog/latest/api-reference/welcome.html">
        /// Amazon Web Services MarketplaceUsing the Amazon Web Services Marketplace Catalog API</a>.
        /// </para><para>Validation: Ensure the identifier or ARN is valid and corresponds to an existing entity.
        /// An incorrect or invalid identifier results in an error. </para>
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
        public System.String RelatedEntityIdentifier { get; set; }
        #endregion
        
        #region Parameter RelatedEntityType
        /// <summary>
        /// <para>
        /// <para>The type of the entity that you're disassociating from the opportunity. When you specify
        /// the entity type, it helps the system correctly process the disassociation request
        /// to ensure that the right connections are removed. </para><para>Examples of entity types include Partner Solution, Amazon Web Services product, and
        /// Amazon Web Services Marketplaceoffer. Ensure that the value matches one of the expected
        /// entity types. </para><para>Validation: Provide a valid entity type to help ensure successful disassociation.
        /// An invalid or incorrect entity type results in an error. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.PartnerCentralSelling.RelatedEntityType")]
        public Amazon.PartnerCentralSelling.RelatedEntityType RelatedEntityType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PartnerCentralSelling.Model.DisassociateOpportunityResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the OpportunityIdentifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^OpportunityIdentifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^OpportunityIdentifier' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.OpportunityIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-PCDisassociateOpportunity (DisassociateOpportunity)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PartnerCentralSelling.Model.DisassociateOpportunityResponse, InvokePCDisassociateOpportunityCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.OpportunityIdentifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Catalog = this.Catalog;
            #if MODULAR
            if (this.Catalog == null && ParameterWasBound(nameof(this.Catalog)))
            {
                WriteWarning("You are passing $null as a value for parameter Catalog which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OpportunityIdentifier = this.OpportunityIdentifier;
            #if MODULAR
            if (this.OpportunityIdentifier == null && ParameterWasBound(nameof(this.OpportunityIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter OpportunityIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RelatedEntityIdentifier = this.RelatedEntityIdentifier;
            #if MODULAR
            if (this.RelatedEntityIdentifier == null && ParameterWasBound(nameof(this.RelatedEntityIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter RelatedEntityIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RelatedEntityType = this.RelatedEntityType;
            #if MODULAR
            if (this.RelatedEntityType == null && ParameterWasBound(nameof(this.RelatedEntityType)))
            {
                WriteWarning("You are passing $null as a value for parameter RelatedEntityType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.PartnerCentralSelling.Model.DisassociateOpportunityRequest();
            
            if (cmdletContext.Catalog != null)
            {
                request.Catalog = cmdletContext.Catalog;
            }
            if (cmdletContext.OpportunityIdentifier != null)
            {
                request.OpportunityIdentifier = cmdletContext.OpportunityIdentifier;
            }
            if (cmdletContext.RelatedEntityIdentifier != null)
            {
                request.RelatedEntityIdentifier = cmdletContext.RelatedEntityIdentifier;
            }
            if (cmdletContext.RelatedEntityType != null)
            {
                request.RelatedEntityType = cmdletContext.RelatedEntityType;
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
        
        private Amazon.PartnerCentralSelling.Model.DisassociateOpportunityResponse CallAWSServiceOperation(IAmazonPartnerCentralSelling client, Amazon.PartnerCentralSelling.Model.DisassociateOpportunityRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Partner Central Selling API", "DisassociateOpportunity");
            try
            {
                #if DESKTOP
                return client.DisassociateOpportunity(request);
                #elif CORECLR
                return client.DisassociateOpportunityAsync(request).GetAwaiter().GetResult();
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
            public System.String Catalog { get; set; }
            public System.String OpportunityIdentifier { get; set; }
            public System.String RelatedEntityIdentifier { get; set; }
            public Amazon.PartnerCentralSelling.RelatedEntityType RelatedEntityType { get; set; }
            public System.Func<Amazon.PartnerCentralSelling.Model.DisassociateOpportunityResponse, InvokePCDisassociateOpportunityCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
