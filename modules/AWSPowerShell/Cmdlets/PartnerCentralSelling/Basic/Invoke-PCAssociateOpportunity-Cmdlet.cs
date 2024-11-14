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
    /// Enables you to create a formal association between an <c>Opportunity</c> and various
    /// related entities, enriching the context and details of the opportunity for better
    /// collaboration and decision-making. You can associate an opportunity with the following
    /// types of entities: 
    /// 
    ///  <ul><li><para>
    ///  Partner Solution: A software product or consulting practice created and delivered
    /// by Partners. Partner Solutions help customers address specific business challenges
    /// or achieve particular goals using Amazon Web Services services. 
    /// </para></li><li><para>
    ///  Amazon Web Services Product: Amazon Web Services offers a wide range of products
    /// and services designed to provide scalable, reliable, and cost-effective infrastructure
    /// solutions. For the latest list of Amazon Web Services products, refer to <a href="https://github.com/aws-samples/partner-crm-integration-samples/blob/main/resources/aws_products.json">Amazon
    /// Web Services products</a>. 
    /// </para></li><li><para>
    ///  Amazon Web Services Marketplace private offer: Allows Amazon Web Services Marketplace
    /// sellers to extend custom pricing and terms to individual Amazon Web Services customers.
    /// Sellers can negotiate custom prices, payment schedules, and end user license terms
    /// through private offers, enabling Amazon Web Services customers to acquire software
    /// solutions tailored to their specific needs. For more information, refer to <a href="https://docs.aws.amazon.com/marketplace/latest/buyerguide/buyer-private-offers.html">Private
    /// offers in Amazon Web Services Marketplace</a>. 
    /// </para></li></ul><para>
    /// To obtain identifiers for these entities, use the following methods:
    /// </para><ul><li><para>
    /// Solution: Use the <c>ListSolutions</c> operation.
    /// </para></li><li><para>
    ///  AWS products: For the latest list of Amazon Web Services products, refer to the Amazon
    /// Web Services products list.
    /// </para></li><li><para>
    ///  Amazon Web Services Marketplace private offer: Use the <a href="https://docs.aws.amazon.com/marketplace-catalog/latest/api-reference/welcome.html">AWS
    /// Marketplace Catalog API</a> to list entities. Specifically, use the <c>ListEntities</c>
    /// operation to retrieve a list of private offers. The request to the <c>ListEntities</c>
    /// API returns the details of the private offers available to you. For more information,
    /// refer to <a href="https://docs.aws.amazon.com/marketplace-catalog/latest/api-reference/API_ListEntities.html">ListEntities</a>.
    /// 
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Invoke", "PCAssociateOpportunity", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Partner Central Selling API AssociateOpportunity API operation.", Operation = new[] {"AssociateOpportunity"}, SelectReturnType = typeof(Amazon.PartnerCentralSelling.Model.AssociateOpportunityResponse))]
    [AWSCmdletOutput("None or Amazon.PartnerCentralSelling.Model.AssociateOpportunityResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.PartnerCentralSelling.Model.AssociateOpportunityResponse) be returned by specifying '-Select *'."
    )]
    public partial class InvokePCAssociateOpportunityCmdlet : AmazonPartnerCentralSellingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Catalog
        /// <summary>
        /// <para>
        /// <para> Specifies the catalog associated with the request. This field takes a string value
        /// from a predefined list: <c>AWS</c> or <c>Sandbox</c>. The catalog determines whichenvironment
        /// the opportunity association is made in. Use <c>AWS</c> to associate opportunities
        /// in the Amazon Web Services catalog, and <c>Sandbox</c> to test in a secure and isolated
        /// environment. </para>
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
        /// <para>Requires the <c>Opportunity</c>'s unique identifier when you want to associate it
        /// with a related entity. Provide the correct identifier so the intended opportunity
        /// is updated with the association. </para>
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
        /// <para>Requires the related entity's unique identifier when you want to associate it with
        /// the <c> Opportunity</c>. For Amazon Web Services Marketplace entities, provide the
        /// Amazon Resource Name (ARN). Use the <a href="https://docs.aws.amazon.com/marketplace-catalog/latest/api-reference/welcome.html">
        /// Amazon Web Services Marketplace API</a> to obtain the ARN. </para>
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
        /// <para>Specifies the type of the related entity you're associating with the <c> Opportunity</c>.
        /// This helps to categorize and properly process the association. </para>
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PartnerCentralSelling.Model.AssociateOpportunityResponse).
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-PCAssociateOpportunity (AssociateOpportunity)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PartnerCentralSelling.Model.AssociateOpportunityResponse, InvokePCAssociateOpportunityCmdlet>(Select) ??
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
            var request = new Amazon.PartnerCentralSelling.Model.AssociateOpportunityRequest();
            
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
        
        private Amazon.PartnerCentralSelling.Model.AssociateOpportunityResponse CallAWSServiceOperation(IAmazonPartnerCentralSelling client, Amazon.PartnerCentralSelling.Model.AssociateOpportunityRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Partner Central Selling API", "AssociateOpportunity");
            try
            {
                #if DESKTOP
                return client.AssociateOpportunity(request);
                #elif CORECLR
                return client.AssociateOpportunityAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.PartnerCentralSelling.Model.AssociateOpportunityResponse, InvokePCAssociateOpportunityCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
