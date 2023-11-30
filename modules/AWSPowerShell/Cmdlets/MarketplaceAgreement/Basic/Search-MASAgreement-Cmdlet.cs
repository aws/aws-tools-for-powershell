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
using Amazon.MarketplaceAgreement;
using Amazon.MarketplaceAgreement.Model;

namespace Amazon.PowerShell.Cmdlets.MAS
{
    /// <summary>
    /// Searches across all agreements that a proposer or an acceptor has in AWS Marketplace.
    /// The search returns a list of agreements with basic agreement information.
    /// 
    ///  
    /// <para>
    /// The following filter combinations are supported:
    /// </para><ul><li><para><code>PartyType</code> as <code>Proposer</code> + <code>AgreementType</code> + <code>ResourceIdentifier</code></para></li><li><para><code>PartyType</code> as <code>Proposer</code> + <code>AgreementType</code> + <code>OfferId</code></para></li><li><para><code>PartyType</code> as <code>Proposer</code> + <code>AgreementType</code> + <code>AcceptorAccountId</code></para></li><li><para><code>PartyType</code> as <code>Proposer</code> + <code>AgreementType</code> + <code>Status</code></para></li><li><para><code>PartyType</code> as <code>Proposer</code> + <code>AgreementType</code> + <code>ResourceIdentifier</code>
    /// + <code>Status</code></para></li><li><para><code>PartyType</code> as <code>Proposer</code> + <code>AgreementType</code> + <code>OfferId</code>
    /// + <code>Status</code></para></li><li><para><code>PartyType</code> as <code>Proposer</code> + <code>AgreementType</code> + <code>AcceptorAccountId</code>
    /// + <code>Status</code></para></li><li><para><code>PartyType</code> as <code>Proposer</code> + <code>AgreementType</code> + <code>ResourceType</code>
    /// + <code>Status</code></para></li><li><para><code>PartyType</code> as <code>Proposer</code> + <code>AgreementType</code> + <code>AcceptorAccountId</code>
    /// + <code>ResourceType</code> + <code>Status</code></para></li><li><para><code>PartyType</code> as <code>Proposer</code> + <code>AgreementType</code> + <code>AcceptorAccountId</code>
    /// + <code>OfferId</code></para></li><li><para><code>PartyType</code> as <code>Proposer</code> + <code>AgreementType</code> + <code>AcceptorAccountId</code>
    /// + <code>OfferId</code> + <code>Status</code></para></li><li><para><code>PartyType</code> as <code>Proposer</code> + <code>AgreementType</code> + <code>AcceptorAccountId</code>
    /// + <code>ResourceIdentifier</code></para></li><li><para><code>PartyType</code> as <code>Proposer</code> + <code>AgreementType</code> + <code>AcceptorAccountId</code>
    /// + <code>ResourceIdentifier</code> + <code>Status</code></para></li><li><para><code>PartyType</code> as <code>Proposer</code> + <code>AgreementType</code> + <code>AcceptorAccountId</code>
    /// + <code>ResourceType</code></para></li></ul>
    /// </summary>
    [Cmdlet("Search", "MASAgreement", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MarketplaceAgreement.Model.SearchAgreementsResponse")]
    [AWSCmdlet("Calls the AWS Marketplace Agreement Service SearchAgreements API operation.", Operation = new[] {"SearchAgreements"}, SelectReturnType = typeof(Amazon.MarketplaceAgreement.Model.SearchAgreementsResponse))]
    [AWSCmdletOutput("Amazon.MarketplaceAgreement.Model.SearchAgreementsResponse",
        "This cmdlet returns an Amazon.MarketplaceAgreement.Model.SearchAgreementsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SearchMASAgreementCmdlet : AmazonMarketplaceAgreementClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Catalog
        /// <summary>
        /// <para>
        /// <para>The catalog in which the agreement was created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Catalog { get; set; }
        #endregion
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>The filter name and value pair used to return a specific list of results.</para><para>The following filters are supported:</para><ul><li><para><code>ResourceIdentifier</code> – The unique identifier of the resource.</para></li><li><para><code>ResourceType</code> – Type of the resource, which is the product (<code>AmiProduct</code>,
        /// <code>ContainerProduct</code>, or <code>SaaSProduct</code>).</para></li><li><para><code>PartyType</code> – The party type (either <code>Acceptor</code> or <code>Proposer</code>)
        /// of the caller. For agreements where the caller is the proposer, use the <code>Proposer</code>
        /// filter. For agreements where the caller is the acceptor, use the <code>Acceptor</code>
        /// filter.</para></li><li><para><code>AcceptorAccountId</code> – The AWS account ID of the party accepting the agreement
        /// terms.</para></li><li><para><code>OfferId</code> – The unique identifier of the offer in which the terms are
        /// registered in the agreement token.</para></li><li><para><code>Status</code> – The current status of the agreement. Values include <code>ACTIVE</code>,
        /// <code>ARCHIVED</code>, <code>CANCELLED</code>, <code>EXPIRED</code>, <code>RENEWED</code>,
        /// <code>REPLACED</code>, and <code>TERMINATED</code>.</para></li><li><para><code>BeforeEndTime</code> – A date used to filter agreements with a date before
        /// the <code>endTime</code> of an agreement.</para></li><li><para><code>AfterEndTime</code> – A date used to filter agreements with a date after the
        /// <code>endTime</code> of an agreement.</para></li><li><para><code>AgreementType</code> – The type of agreement. Values include <code>PurchaseAgreement</code>
        /// or <code>VendorInsightsAgreement</code>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public Amazon.MarketplaceAgreement.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter Sort_SortBy
        /// <summary>
        /// <para>
        /// <para>The attribute on which the data is grouped, which can be by <code>StartTime</code>
        /// and <code>EndTime</code>. The default value is <code>EndTime</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Sort_SortBy { get; set; }
        #endregion
        
        #region Parameter Sort_SortOrder
        /// <summary>
        /// <para>
        /// <para>The sorting order, which can be <code>ASCENDING</code> or <code>DESCENDING</code>.
        /// The default value is <code>DESCENDING</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MarketplaceAgreement.SortOrder")]
        public Amazon.MarketplaceAgreement.SortOrder Sort_SortOrder { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of agreements to return in the response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>A token to specify where to start pagination.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MarketplaceAgreement.Model.SearchAgreementsResponse).
        /// Specifying the name of a property of type Amazon.MarketplaceAgreement.Model.SearchAgreementsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Catalog parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Catalog' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Catalog' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Catalog), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Search-MASAgreement (SearchAgreements)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MarketplaceAgreement.Model.SearchAgreementsResponse, SearchMASAgreementCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Catalog;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Catalog = this.Catalog;
            if (this.Filter != null)
            {
                context.Filter = new List<Amazon.MarketplaceAgreement.Model.Filter>(this.Filter);
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.Sort_SortBy = this.Sort_SortBy;
            context.Sort_SortOrder = this.Sort_SortOrder;
            
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
            var request = new Amazon.MarketplaceAgreement.Model.SearchAgreementsRequest();
            
            if (cmdletContext.Catalog != null)
            {
                request.Catalog = cmdletContext.Catalog;
            }
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            
             // populate Sort
            var requestSortIsNull = true;
            request.Sort = new Amazon.MarketplaceAgreement.Model.Sort();
            System.String requestSort_sort_SortBy = null;
            if (cmdletContext.Sort_SortBy != null)
            {
                requestSort_sort_SortBy = cmdletContext.Sort_SortBy;
            }
            if (requestSort_sort_SortBy != null)
            {
                request.Sort.SortBy = requestSort_sort_SortBy;
                requestSortIsNull = false;
            }
            Amazon.MarketplaceAgreement.SortOrder requestSort_sort_SortOrder = null;
            if (cmdletContext.Sort_SortOrder != null)
            {
                requestSort_sort_SortOrder = cmdletContext.Sort_SortOrder;
            }
            if (requestSort_sort_SortOrder != null)
            {
                request.Sort.SortOrder = requestSort_sort_SortOrder;
                requestSortIsNull = false;
            }
             // determine if request.Sort should be set to null
            if (requestSortIsNull)
            {
                request.Sort = null;
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
        
        private Amazon.MarketplaceAgreement.Model.SearchAgreementsResponse CallAWSServiceOperation(IAmazonMarketplaceAgreement client, Amazon.MarketplaceAgreement.Model.SearchAgreementsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Marketplace Agreement Service", "SearchAgreements");
            try
            {
                #if DESKTOP
                return client.SearchAgreements(request);
                #elif CORECLR
                return client.SearchAgreementsAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.MarketplaceAgreement.Model.Filter> Filter { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String Sort_SortBy { get; set; }
            public Amazon.MarketplaceAgreement.SortOrder Sort_SortOrder { get; set; }
            public System.Func<Amazon.MarketplaceAgreement.Model.SearchAgreementsResponse, SearchMASAgreementCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
